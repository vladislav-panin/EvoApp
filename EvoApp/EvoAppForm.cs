using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EvoApp
{
    public partial class EvoAppForm : Form
    {
        // ****************************************************************************************
        private bool isAppInited = false;

        private BackgroundWorker bgWorkerForInit;

        private PainterEvoPanelBig painterEvoPanelBig = new PainterEvoPanelBig();
        private PainterEvoPanelSmall painterEvoPanelSmall = new PainterEvoPanelSmall();
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

            painterEvoPanelSmall.Init(evoPanelSmall.Width, evoPanelSmall.Height);
            painterEvoPanelBig.Init(evoPanelBig.Width, evoPanelBig.Height);
            
            InitSliders();
            InitCommonGUI_vars();
        }

        // ****************************************************************************************
        protected void InitCommonGUI_vars()
        {
            int cellWidthPx_onBigPanel = evoPanelBig.Width / PainterBase.colCount;
            int cellHeightPx_onBigPanel = evoPanelBig.Height / PainterBase.rowCount;

            DeskCell.InitCell(cellWidthPx_onBigPanel, cellHeightPx_onBigPanel);
        }
        // ****************************************************************************************
        protected void InitSliders()
        {
            hSlider.Minimum = 0;
            hSlider.Maximum = painterEvoPanelBig.hSlider_xTickCount - 1;
            hSlider.Value = 0;
            hSlider.LargeChange = 1;

            painterEvoPanelBig.HSlider_Val = 0; // одновременно будет инициирован оффсет            
            painterEvoPanelBig.VSlider_Val = 0;

            vSlider.Minimum = 0;
            vSlider.Maximum = painterEvoPanelBig.vSlider_yTickCount - 1;
            vSlider.Value = vSlider.Maximum;
            vSlider.LargeChange = 1;

            painterEvoPanelSmall.HSlider_Val = 0; // одновременно будет инициирован оффсет
            painterEvoPanelSmall.VSlider_Val = 0; // одновременно будет инициирован оффсет            
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
            AppInitInfo res = this.InitGame();
            e.Result = res;
        }

        // ****************************************************************************************
        // после того, как объекте bgWorkerForInit выполнит асинхронно задачу bgWorkerForInit_DoWork(), уже в
        // этом потоке будет запущен на выполнение этот метод
        private void bgWorkerForInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AppInitInfo res = (AppInitInfo)e.Result;
            SetAppIsInited(res);
        }

        // ****************************************************************************************
        // Прорисовка окна приложения
        private void EvoAppForm_Paint(object sender, PaintEventArgs e)
        {
            // Console.WriteLine(" ******** EvoAppForm_Paint()");           
        }

        // ****************************************************************************************
        public AppInitInfo InitGame()
        {
            AppInitInfo res = Program.app.Init();
            return res;
        }

        // ****************************************************************************************
        public void SetAppIsInited(AppInitInfo res)
        {
            // "переворачиваю" вертикальный слайдер, в соответствии с вертикальной нумерацией ячеек - она растет сверху вниз
            painterEvoPanelBig.VSlider_Val = vSlider.Maximum; // одновременно будет инициирован оффсет
            painterEvoPanelSmall.VSlider_Val = vSlider.Maximum; // одновременно будет инициирован оффсет

            evoPanelBig.BorderStyle = BorderStyle.None;
            evoPanelSmall.BorderStyle = BorderStyle.None;

            isAppInited = true;

            lblinit.Text = "Эволюция готова к запуску!";
            lblinit.ForeColor = Color.Green;
            btnStart.Enabled = true;
            btnStop.Enabled = true;

            lbEvoTickTime.Text = "Длительность цикла эволюции (мс): " + Program.app.getThreadInfo().evoCycleTime_millisec;
            this.lbCellCount.Text = "Количество ячеек: " + Convert.ToString(res.cellCount);
            lbEntityCount.Text = "Число особей: " + res.entityCount;
            this.lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            richTimerInfo.Text = res.sTimerInfo;

            lbTimerInterval.Text = "Таймер перерисовки панелей (мс): " + painterEvoPanelBig.timerPaintInterval;
            lbEvoInitTime.Text = "Время инициализации (мс): " + res.evoInitTime_millisec;

            lbWidthCell.Text = "Ширина ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;
            lbHeightCell.Text = "Высота ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;


            this.evoPanelBig.Invalidate();
            this.evoPanelBig.Update();

            this.evoPanelSmall.Invalidate();
            this.evoPanelSmall.Update();
        }

        // ****************************************************************************************       
        private void vSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение вертикального слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxColsOffset (перерассчитан оффсет)
            painterEvoPanelSmall.VSlider_Val = vSlider.Value;
            painterEvoPanelBig.VSlider_Val = vSlider.Value;

            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            evoPanelSmall.Invalidate();
            evoPanelSmall.Update();

            evoPanelBig.Invalidate();
            evoPanelBig.Update();
        }

        private void hSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение горизонтального  слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxColsOffset (перерассчитан оффсет)
            painterEvoPanelSmall.HSlider_Val = hSlider.Value;
            painterEvoPanelBig.HSlider_Val = hSlider.Value;

            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            evoPanelSmall.Invalidate();
            evoPanelSmall.Update();

            evoPanelBig.Invalidate();
            evoPanelBig.Update();
        }
        // ****************************************************************************************       
        private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (chkBox.Checked)
                PainterEvoPanelBig.isGridRequired = true;
            else
                PainterEvoPanelBig.isGridRequired = false;

            evoPanelBig.Invalidate();
            evoPanelBig.Update();
        }

        private void chkShowCoo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = (CheckBox)sender;
            if (chkBox.Checked)
                PainterEvoPanelBig.isCoordRequired = true;
            else
                PainterEvoPanelBig.isCoordRequired = false;

            evoPanelBig.Invalidate();
            evoPanelBig.Update();
        }
       
        // ****************************************************************************************       
        private void pictSmallEvoPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!isAppInited)
                return;

            Graphics panelCanvasGraph = e.Graphics;
            this.painterEvoPanelSmall.panelPaint(panelCanvasGraph);
        }

        // ****************************************************************************************       
        private void pictBigEvoPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!isAppInited)
                return;

            Graphics panelCanvasGraph = e.Graphics;
            this.painterEvoPanelBig.panelPaint(panelCanvasGraph);
        }
        // ****************************************************************************************                   
        public void btnStart_Click(object sender, EventArgs e)
        {
            // Инициализация таймера WinForm, брошенного на форму 
            bigEvoPaintTimer.Interval = painterEvoPanelBig.timerPaintInterval;
            bigEvoPaintTimer.Enabled = true; // старт таймера
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bigEvoPaintTimer.Enabled = false; 
        }

        // ****************************************************************************************
        // Метод формы, который будет выполнятся на каждое срабатывание таймера WinForm, брошенный на форму 
        // Связь с таймром была установлена в графическом редакторе формы
        private void bigEvoPaintTimer_Tick(object sender, EventArgs e)
        {
            Program.app.Run(); // запуск на выполнение эволюции 

            lbEntityCount.Text = "Число особей: " + Program.app.population.EntityCount();

            lbEvoTickCount.Text = "Число просчитанных циклов эволюции: " + Program.app.getThreadInfo().evoCycleCounter;
            lbEvoTickTime.Text = "Длительность цикла эволюции (мс): " + Program.app.getThreadInfo().evoCycleTime_millisec;

            lbTimerInterval.Text = "Таймер перерисовки панелей (мс): " + painterEvoPanelBig.timerPaintInterval;
            lbEvoFriquency.Text = "Частота расчета шага эволюции: " + ((float)1000)/((float)painterEvoPanelBig.timerPaintInterval) + " раз/сек";

            lbWidthCell.Text = "Ширина ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;
            lbHeightCell.Text = "Высота ячейки  в пикселях: " +  painterEvoPanelBig.cellWidthPx;

            // вызываем рорисовывку большой панели на каждый тик таймера
            evoPanelBig.Invalidate();
            evoPanelBig.Update();

            // вызываем рорисовывку маленькой панели на кажый тик таймера
            evoPanelSmall.Invalidate();
            evoPanelSmall.Update();
        }
    }
}
