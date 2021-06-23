using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EvoApp
{
    public partial class EvoAppForm : Form
    {
        private bool isAppInited = false;

        private BackgroundWorker bgWorkerForInit;
        private PainterBigEvoPanel painterBigEvoPanel = new PainterBigEvoPanel();
        private PainterSmallEvoPanel painterSmallEvoPanel = new PainterSmallEvoPanel();

        // ****************************************************************************************
        public EvoAppForm()
        {
            InitializeComponent();

            // Чтобы запустить в другом потоке некие вычисления, а затем из этого другого потока изменить значения контролов фомы в этом потоке - 
            // нужно создать и настроить экземпляр BackgroundWorker, а затем запустить его на выполнение.
            // Здесь я сформирую и настрою BackgroundWorker bgWorkerForInit, а запущу его на выполнение в событии EvoAppForm_Load()

            // --------------------------------------------- //
            // Подготовка ассинхронной задачи bgWorkerForInit. WinForms запустит её на выполнение в фоне сама. 

            bgWorkerForInit = new BackgroundWorker();
            bgWorkerForInit.DoWork += new DoWorkEventHandler(bgWorkerForInit_DoWork);
            bgWorkerForInit.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerForInit_RunWorkerCompleted);

            // --------------------------------------------- //
            // Инициализация рисовальшиков панелей игры

            painterSmallEvoPanel.Init (panelEvoSmall.Width, panelEvoSmall.Height);
            painterBigEvoPanel.  Init (panelEvoBig.  Width, panelEvoBig.  Height);

            InitSliders();
            InitCommonGUI_vars();
        }

        // ****************************************************************************************
        protected void InitCommonGUI_vars()
        {
            int cellWidthPx_onBigPanel  = panelEvoBig.Width / PainterBase.colCount;
            int cellHeightPx_onBigPanel = panelEvoBig.Height / PainterBase.rowCount;

            DeskCell.InitCell(cellWidthPx_onBigPanel, cellHeightPx_onBigPanel);
        }
        // ****************************************************************************************
        protected void InitSliders()
        {
            hSlider.Minimum = 0;
            hSlider.Maximum = painterBigEvoPanel.hSlider_xTickCount - 1;
            hSlider.Value = 0;
            hSlider.LargeChange = 1;

            painterBigEvoPanel.HSlider_Val = 0; // одновременно будет инициирован оффсет
            //painterBigEvoPanel.VSlider_Val = vSlider.Maximum; // одновременно будет инициирован оффсет
            painterBigEvoPanel.VSlider_Val = 0;

            vSlider.Minimum = 0;
            vSlider.Maximum = painterBigEvoPanel.vSlider_yTickCount - 1;
            vSlider.Value = vSlider.Maximum;
            vSlider.LargeChange = 1;

            painterSmallEvoPanel.HSlider_Val = 0; // одновременно будет инициирован оффсет
            painterSmallEvoPanel.VSlider_Val = 0; // одновременно будет инициирован оффсет
        }

        // ****************************************************************************************
        private void EvoAppForm_Load(object sender, EventArgs e)
        {
            // InitGame(); - запускаем новый поток и там проводим инициализацию, а на основании полученных при инициализации данных - пробуем
            // изменить надписи на диалаоге. Но так винда не даст изменить значение контролов формы!
            // То есть этот вариант не годиться.

            // Для реализации описанных выше действий есть специальный механизм - этого нужно использовать экземпляр BackgroundWorker, 
            // вот так он запускает на выполнение определенную заранее и связанную с ним выше задачу (bgWorkerForInit_DoWork()) :            
            bgWorkerForInit.RunWorkerAsync();
        }

        // этот метод будет выполнятся асинхронно (в другом потоке?) на объекте bgWorkerForInit
        private void bgWorkerForInit_DoWork(object sender, DoWorkEventArgs e)
        {
            AppInitResult res = this.InitGame(); 
            e.Result = res;
        }

        // ****************************************************************************************
        // после того, как объекте bgWorkerForInit выполнит асинхронно задачу bgWorkerForInit_DoWork(), уже в
        // этом потоке будет запущен на выполнение этот метод
        private void bgWorkerForInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AppInitResult res = (AppInitResult)e.Result;
            SetAppIsInited(res);

            RunGame();            
        }

        // ****************************************************************************************
        // Прорисовка окна приложения
        private void EvoAppForm_Paint(object sender, PaintEventArgs e)
        {
            // Console.WriteLine(" ******** EvoAppForm_Paint()");           
        }

        // ****************************************************************************************
        public AppInitResult InitGame()
        {
            AppInitResult res = Program.app.Init();
            return res;
        }

        // ****************************************************************************************
        public void SetAppIsInited (AppInitResult res)
        {
            // "переворачиваю" вертикальный слайдер, в соответствии с вертикальной нумерацией ячеек - она растет сверху вниз
            painterBigEvoPanel.VSlider_Val = vSlider.Maximum; // одновременно будет инициирован оффсет
            painterSmallEvoPanel.VSlider_Val = vSlider.Maximum; // одновременно будет инициирован оффсет

            isAppInited = true;

            lblinit.Text = "игра запущена!";
            lblinit.ForeColor = Color.Green;
            btnStart.Enabled = true;
            btnStop.Enabled = true;

            this.lblCellCount.Text = "количество ячеек: " + Convert.ToString(res.cellCount);
            this.lblOffset.Text = painterBigEvoPanel.GetOffsetString();

            this.panelEvoBig.Invalidate();
            this.panelEvoBig.Update();
                        
            this.panelEvoSmall.Invalidate();
            this.panelEvoSmall.Update();
        }

        // ****************************************************************************************
        public void RunGame()
        {
            Program.app.Run(); // запуск на выполнение эволюции

            // Инициализация таймера WinForm, брошенный на форму 
            bigGamePaintTimer.Interval = painterBigEvoPanel.paintInterval;
            bigGamePaintTimer.Enabled = true; // старт таймера
        }

        // ****************************************************************************************
        // Метод формы, который будет выполнятся на каждое срабатывание таймера WinForm, брошенный на форму 
        // Связь с таймром была установлена в графическом редакторе формы
        private void bigGamePaintTimer_Tick(object sender, EventArgs e)
        {
            // вызываем рорисовывку большой панели на кажый тик таймера
            // panelBigGame.Invalidate();
            // panelBigGame.Update();

            // вызываем рорисовывку маленькой панели на кажый тик таймера
            // panelSmallGame.Invalidate();
            // panelSmallGame.Update();
        }

        // ****************************************************************************************       
        private void vSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение вертикального слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxColsOffset (перерассчитан оффсет)
            painterSmallEvoPanel.VSlider_Val = vSlider.Value;
            painterBigEvoPanel.VSlider_Val = vSlider.Value;

            lblOffset.Text = painterBigEvoPanel.GetOffsetString();

            panelEvoSmall.Invalidate();
            panelEvoSmall.Update();

            panelEvoBig.Invalidate();
            panelEvoBig.Update();
        }

        private void hSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение горизонтального  слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxColsOffset (перерассчитан оффсет)
            painterSmallEvoPanel.HSlider_Val = hSlider.Value;
            painterBigEvoPanel.HSlider_Val = hSlider.Value;

            lblOffset.Text = painterBigEvoPanel.GetOffsetString();

            panelEvoSmall.Invalidate();
            panelEvoSmall.Update();

            panelEvoBig.Invalidate();
            panelEvoBig.Update();
        }
        // ****************************************************************************************       
        private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (chkBox.Checked)
                PainterBigEvoPanel.isGridRequired = true;
            else
                PainterBigEvoPanel.isGridRequired = false;

            panelEvoBig.Invalidate();
            panelEvoBig.Update();
        }

        private void chkShowCoo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (chkBox.Checked)
                PainterBigEvoPanel.isCoordRequired = true;
            else
                PainterBigEvoPanel.isCoordRequired = false;            

            panelEvoBig.Invalidate();
            panelEvoBig.Update();
        }
        // ****************************************************************************************       
        private void comboEvoSpeed_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            String speed = comboBox.SelectedItem.ToString();

            switch (speed)
            {
                case "Высокая":
                    Program.app.evoSpeed = EvoSpeed.Hi;
                    break;

                case "Средняя":
                    Program.app.evoSpeed = EvoSpeed.Medium;
                    break;

                case "Низкая":
                    Program.app.evoSpeed = EvoSpeed.Slow;
                    break;
            }
        }

        // ****************************************************************************************       
        private void panelSmallGame_Paint(object sender, PaintEventArgs e)
        {
            if (!isAppInited)    
                return;
                   
            Graphics panelCanvasGraph = e.Graphics;
            this.painterSmallEvoPanel.panelPaint(panelCanvasGraph);
        }
        
        // ****************************************************************************************       
        private void panelBigGame_Paint(object sender, PaintEventArgs e)
        {
            if (!isAppInited)
                return;
            
            Graphics panelCanvasGraph = e.Graphics;
            this.painterBigEvoPanel.panelPaint(panelCanvasGraph);
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
             
        }
        // ****************************************************************************************       
    }
}
