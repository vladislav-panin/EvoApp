using EvoApp.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace EvoApp
{
    // Логика и реализация поведения и отрисовки контролов
    public partial class EvoAppForm : Form
    {
        // ****************************************************************************************
        ResourceManager resMgr = Resources.ResourceManager;

        Bitmap bmpBtnColoredDown  ;
        Bitmap bmpBtnColoredLeft  ;
        Bitmap bmpBtnColoredRight ;
        Bitmap bmpBtnColoredUp    ;

        Bitmap bmpBtnGrayDown    ;
        Bitmap bmpBtnGrayLeft    ;
        Bitmap bmpBtnGrayRight   ;
        Bitmap bmpBtnGrayUp      ;
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

            // Подготовка ассинхронной задачи bgWorkerForInit. WinForms запустит её на выполнение в фоне сама.
            bgWorkerForInit = new BackgroundWorker();
            bgWorkerForInit.DoWork += new DoWorkEventHandler(bgWorkerForInit_DoWork);
            bgWorkerForInit.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerForInit_RunWorkerCompleted);

            // Инициализация рисовальшиков панелей игры
            painterEvoPanelSmall.Init(evoPanelSmall.Width, evoPanelSmall.Height);
            painterEvoPanelBig.Init(evoPanelBig.Width, evoPanelBig.Height);

            InitBtns();
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
        
        protected void InitBtns()
        {
                this.bmpBtnColoredDown  = (Bitmap)resMgr.GetObject("btnDown16withBg");
                this.bmpBtnColoredLeft  = (Bitmap)resMgr.GetObject("btnLeft16withBg");
                this.bmpBtnColoredRight = (Bitmap)resMgr.GetObject("btnRight16withBg");
                this.bmpBtnColoredUp    = (Bitmap)resMgr.GetObject("btnUp16withBg");

                this.bmpBtnGrayDown     = (Bitmap)resMgr.GetObject("btnDown16");
                this.bmpBtnGrayLeft     = (Bitmap)resMgr.GetObject("btnLeft16");
                this.bmpBtnGrayRight    = (Bitmap)resMgr.GetObject("btnRight16");
                this.bmpBtnGrayUp       = (Bitmap)resMgr.GetObject("btnUp16");
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

            lbEvoTickTime.Text = "Длительность цикла эволюции (мс): " + Program.app.appThreadInfo.evoCycleTime_millisec;
            this.lbCellCount.Text = "Количество ячеек: " + Convert.ToString(res.cellCount);

            setAppInfoPanel(res);

            this.lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            richTimerInfo.Text = res.sTimerInfo;

            lbTimerInterval.Text = "Таймер перерисовки панелей (мс): " + painterEvoPanelBig.timerPaintInterval;
            lbEvoInitTime.Text = "Время инициализации (мс): " + res.evoInitTime;

            lbWidthCell.Text = "Ширина ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;
            lbHeightCell.Text = "Высота ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;


            updateEvoPanels();
        }
        // ****************************************************************************************       

        private void setAppInfoPanel(AppInitInfo res)
        { 
            lbBiomCountAll                .Text = "Общее число юнитов биома (шт): " + res. countBiomAll () ;
										  
			lbBiomCountHerbivore          .Text = "Травоядные (шт): " + res. countBiomHerbivore();
            lbBiomCountHerbivoreSquirrel  .Text = "Белки (шт): " + res. countBiomHerbivoreSquirrel  ;   
            lbBiomCountHerbivoreDeer      .Text = "Олени (шт): " + res. countBiomHerbivoreDeer      ;
			lbBiomCountHerbivoreRabbit    .Text = "Зайцы (шт): " + res. countBiomHerbivoreRabbit    ; 
										  
			lbBiomCountOmni               .Text = "Всеядные (шт): " + res. countBiomOmni();
            lbBiomCountOmniBoar           .Text = "Кабаны (шт): " + res. countBiomOmniBoar           ;
            lbBiomCountOmniBadger         .Text = "Барсуки (шт): " + res. countBiomOmniBadger         ;
            lbBiomCountOmniBear           .Text = "Медведи (шт): " + res. countBiomOmniBear           ;
										  
            lbBiomCountRaptor             .Text = "Хищники (шт): " + res. countBiomRaptor();
            lbBiomCountRaptorLynx         .Text = "Рыси (шт): " + res. countBiomRaptorLynx         ;
            lbBiomCountRaptorWolf         .Text = "Волки (шт): " + res. countBiomRaptorWolf         ;
			lbBiomCountRaptorFox          .Text = "Лисы (шт): " + res. countBiomRaptorFox          ;
										  
			lbBiomCountVegetable          .Text = "Овощи (шт): " + res. countBiomVegetable();
			lbBiomCountVegetablePatato    .Text = "Картошка (шт): " + res. countBiomVegetablePatato    ; 
            lbBiomCountVegetableCarrot    .Text = "Морковка (шт): " + res. countBiomVegetableCarrot    ; 
            lbBiomCountVegetableMushroom  .Text = "Грибы (шт): " + res. countBiomVegetableMushroom  ;               
            lbBiomCountVegetableTomato    .Text = "Помидоры (шт): " + res. countBiomVegetableTomato    ; 
			lbBiomCountVegetableStrawberry.Text = "Клубника (шт): " + res. countBiomVegetableStrawberry;              
										  
			lbBiomCountHuman              .Text = "Люди (шт): " + res. countBiomHuman();
            lbBiomCountHumanWoman         .Text = "Женщины (шт): " + res. countBiomHumanWoman         ;        
            lbBiomCountHumanMan           .Text = "Мужчины (шт): " + res. countBiomHumanMan           ;
            lbBiomCountHumanChildren      .Text = "Дети (шт): " + res. countBiomHumanChildren      ;
										  
            lbBiomCountVillige            .Text = "Деревни (шт): " + res. countBiomVillige;     
			lbBiomCountVilligeHouse       .Text = "Дома (шт): " + res. countBiomVilligeHouse       ;
			lbBiomCountVilligeBarn        .Text = "Амбары (шт): " + res. countBiomVilligeBarn        ;

			lbBiomCountVilligeBarnAnimal  .Text = "Сушеных овощей (шт): " + res. countBiomVilligeBarnAnimal  ;               
            lbBiomCountVilligeBarnVeg     .Text = "Копченых зверей (шт): " + res. countBiomVilligeBarnVeg     ;
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
            EvoStart();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            EvoStop();
        }

        protected static bool isEvoStopped = true;
        public void EvoStart()
        {
            if (!isEvoStopped)
                return;

            isEvoStopped = false;

            // Инициализация таймера WinForm, брошенного на форму 
            bigEvoPaintTimer.Interval = painterEvoPanelBig.timerPaintInterval;
            bigEvoPaintTimer.Enabled = true; // старт таймера

            lblinit.Text = "Эволюция вычисляется";
            lblinit.ForeColor = Color.SpringGreen;
        }
        public void EvoStop()
        {
            if (isEvoStopped)
                return;

            isEvoStopped = true;
            bigEvoPaintTimer.Enabled = false;

            lblinit.Text = "Эволюция остановлена";
            lblinit.ForeColor = Color.LightGray;
        }

        // ****************************************************************************************
        // Метод формы, который будет выполнятся на каждое срабатывание таймера WinForm, брошенный на форму 
        // Связь с таймром была установлена в графическом редакторе формы
        private void bigEvoPaintTimer_Tick(object sender, EventArgs e)
        {
            Program.app.Run(); // запуск на выполнение эволюции 

            lbEvoTickCount.Text = "Число просчитанных циклов эволюции: " + Program.app.appThreadInfo.evoCycleCounter;
            lbEvoTickTime.Text = "Длительность цикла эволюции (мс): " + Program.app.appThreadInfo.evoCycleTime_millisec;

            lbTimerInterval.Text = "Таймер перерисовки панелей (мс): " + painterEvoPanelBig.timerPaintInterval;
            lbEvoFriquency.Text = "Частота расчета шага эволюции: " + ((float)1000)/((float)painterEvoPanelBig.timerPaintInterval) + " раз/сек";

            lbWidthCell.Text = "Ширина ячейки  в пикселях: " + painterEvoPanelBig.cellWidthPx;
            lbHeightCell.Text = "Высота ячейки  в пикселях: " +  painterEvoPanelBig.cellWidthPx;

            // вызываем рорисовку большой и малой панелей на каждый тик таймера
            updateEvoPanels();
        }       
        // ****************************************************************************************
        private void vSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение вертикального слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxRowOffset (перерассчитан оффсет)
            painterEvoPanelSmall.VSlider_Val = vSlider.Value;
            painterEvoPanelBig.VSlider_Val = vSlider.Value;

            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            updateEvoPanels();
        }

        private void hSlider_Scroll(object sender, EventArgs e)
        {
            // обновляем текущее положение горизонтального  слайдера в большой и малой панелях,
            // одновременно там автоматически будет установлен idxColOffset (перерассчитан оффсет)
            painterEvoPanelSmall.HSlider_Val = hSlider.Value;
            painterEvoPanelBig.HSlider_Val = hSlider.Value;

            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            updateEvoPanels();
        }
        // ****************************************************************************************       
        private void btnRight_Click(object sender, EventArgs e)
        {
            painterEvoPanelBig.ManualShift_X_incr();
            painterEvoPanelSmall.ManualShift_X_incr();
            painterEvoPanelSmall.recalcOnOffsetChanged();
            
            EvoStop();
            onBtnsShiftClicked();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            painterEvoPanelBig.ManualShift_Y_decr();
            painterEvoPanelSmall.ManualShift_Y_decr();
            painterEvoPanelSmall.recalcOnOffsetChanged();

            EvoStop();
            onBtnsShiftClicked();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            painterEvoPanelBig.ManualShift_Y_incr();
            painterEvoPanelSmall.ManualShift_Y_incr();
            painterEvoPanelSmall.recalcOnOffsetChanged();

            EvoStop();
            onBtnsShiftClicked();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            painterEvoPanelBig.ManualShift_X_decr();
            painterEvoPanelSmall.ManualShift_X_decr();
            painterEvoPanelSmall.recalcOnOffsetChanged();

            EvoStop();
            onBtnsShiftClicked();
        }

        // ****************************************************************************************       

        private void onBtnsShiftClicked ()
        {
            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            vSlider.Value = painterEvoPanelBig.VSlider_Val;
            hSlider.Value = painterEvoPanelBig.HSlider_Val;

            updateEvoPanels();
        }
        // ****************************************************************************************       
        private void updateEvoPanels ()
        {
            evoPanelSmall.Invalidate();
            evoPanelSmall.Update();

            evoPanelBig.Invalidate();
            evoPanelBig.Update();
        }

        // ****************************************************************************************       
        private void evoPanelSmall_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EvoStop();

            Point    ptMouse = new Point(e.X, e.Y);
            Invertor invertor = new Invertor(vSlider.Minimum, vSlider.Maximum, 0);            
            
            int hSliderValue = hSlider.Maximum * ptMouse.X / painterEvoPanelSmall.widthPx;
            int vSliderValue = vSlider.Maximum * ptMouse.Y / painterEvoPanelSmall.heightPx;

            invertor.Set(vSliderValue);

            hSlider.Value = hSliderValue;
            vSlider.Value = invertor.Val();

            painterEvoPanelSmall.VSlider_Val = vSlider.Value;
            painterEvoPanelBig.VSlider_Val = vSlider.Value;

            painterEvoPanelSmall.HSlider_Val = hSlider.Value;
            painterEvoPanelBig.HSlider_Val = hSlider.Value;

            lblOffset.Text = "смещение: " + painterEvoPanelBig.GetOffsetString();

            updateEvoPanels();
        }
    }
}
