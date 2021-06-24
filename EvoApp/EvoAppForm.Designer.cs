
namespace EvoApp
{
    partial class EvoAppForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvoAppForm));
            this.hSlider = new System.Windows.Forms.TrackBar();
            this.vSlider = new System.Windows.Forms.TrackBar();
            this.lbDisertPict = new System.Windows.Forms.PictureBox();
            this.lbSeaPict = new System.Windows.Forms.PictureBox();
            this.lbLakePict = new System.Windows.Forms.PictureBox();
            this.lbMountainsPict = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDisert = new System.Windows.Forms.Label();
            this.lbSea = new System.Windows.Forms.Label();
            this.lbLake = new System.Windows.Forms.Label();
            this.lbMountains = new System.Windows.Forms.Label();
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.evoTitlePanel2 = new System.Windows.Forms.Panel();
            this.evoTitlePanel = new System.Windows.Forms.Panel();
            this.evoTitleVersion = new System.Windows.Forms.Label();
            this.evoTitle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblinit = new System.Windows.Forms.Label();
            this.lbCellCount = new System.Windows.Forms.Label();
            this.lbGrassPict = new System.Windows.Forms.PictureBox();
            this.lbGrass = new System.Windows.Forms.Label();
            this.lbTreesPict = new System.Windows.Forms.PictureBox();
            this.lbTrees = new System.Windows.Forms.Label();
            this.bigEvoPaintTimer = new System.Windows.Forms.Timer(this.components);
            this.lblOffset = new System.Windows.Forms.Label();
            this.lbCurrOffsetPict = new System.Windows.Forms.PictureBox();
            this.lbCurrOffset = new System.Windows.Forms.Label();
            this.chkShowCoo = new System.Windows.Forms.CheckBox();
            this.lbEvoTickTime = new System.Windows.Forms.Label();
            this.lblEvoStep = new System.Windows.Forms.Label();
            this.richTimerInfo = new System.Windows.Forms.RichTextBox();
            this.lbEntityCount = new System.Windows.Forms.Label();
            this.lblEntityCount = new System.Windows.Forms.Label();
            this.lbEvoTickCount = new System.Windows.Forms.Label();
            this.lbEvoInitTime = new System.Windows.Forms.Label();
            this.evoPanelBig = new System.Windows.Forms.PictureBox();
            this.evoPanelSmall = new System.Windows.Forms.PictureBox();
            this.lbTimerInterval = new System.Windows.Forms.Label();
            this.lbEvoFriquency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDisertPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSeaPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLakePict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMountainsPict)).BeginInit();
            this.evoTitlePanel2.SuspendLayout();
            this.evoTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbGrassPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTreesPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCurrOffsetPict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoPanelBig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoPanelSmall)).BeginInit();
            this.SuspendLayout();
            // 
            // hSlider
            // 
            this.hSlider.LargeChange = 1;
            resources.ApplyResources(this.hSlider, "hSlider");
            this.hSlider.Maximum = 20;
            this.hSlider.Name = "hSlider";
            this.hSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.hSlider.Scroll += new System.EventHandler(this.hSlider_Scroll);
            // 
            // vSlider
            // 
            resources.ApplyResources(this.vSlider, "vSlider");
            this.vSlider.Maximum = 20;
            this.vSlider.Name = "vSlider";
            this.vSlider.Tag = "";
            this.vSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.vSlider.Scroll += new System.EventHandler(this.vSlider_Scroll);
            // 
            // lbDisertPict
            // 
            this.lbDisertPict.BackColor = System.Drawing.Color.PaleGoldenrod;
            resources.ApplyResources(this.lbDisertPict, "lbDisertPict");
            this.lbDisertPict.Name = "lbDisertPict";
            this.lbDisertPict.TabStop = false;
            // 
            // lbSeaPict
            // 
            this.lbSeaPict.BackColor = System.Drawing.Color.MediumBlue;
            resources.ApplyResources(this.lbSeaPict, "lbSeaPict");
            this.lbSeaPict.Name = "lbSeaPict";
            this.lbSeaPict.TabStop = false;
            // 
            // lbLakePict
            // 
            this.lbLakePict.BackColor = System.Drawing.Color.Aqua;
            resources.ApplyResources(this.lbLakePict, "lbLakePict");
            this.lbLakePict.Name = "lbLakePict";
            this.lbLakePict.TabStop = false;
            // 
            // lbMountainsPict
            // 
            this.lbMountainsPict.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.lbMountainsPict, "lbMountainsPict");
            this.lbMountainsPict.Name = "lbMountainsPict";
            this.lbMountainsPict.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // lbDisert
            // 
            resources.ApplyResources(this.lbDisert, "lbDisert");
            this.lbDisert.ForeColor = System.Drawing.Color.Gold;
            this.lbDisert.Name = "lbDisert";
            // 
            // lbSea
            // 
            resources.ApplyResources(this.lbSea, "lbSea");
            this.lbSea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbSea.Name = "lbSea";
            // 
            // lbLake
            // 
            resources.ApplyResources(this.lbLake, "lbLake");
            this.lbLake.ForeColor = System.Drawing.Color.Aqua;
            this.lbLake.Name = "lbLake";
            // 
            // lbMountains
            // 
            resources.ApplyResources(this.lbMountains, "lbMountains");
            this.lbMountains.ForeColor = System.Drawing.Color.BurlyWood;
            this.lbMountains.Name = "lbMountains";
            // 
            // chkShowGrid
            // 
            resources.ApplyResources(this.chkShowGrid, "chkShowGrid");
            this.chkShowGrid.Checked = true;
            this.chkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGrid.Name = "chkShowGrid";
            this.chkShowGrid.UseVisualStyleBackColor = true;
            this.chkShowGrid.CheckedChanged += new System.EventHandler(this.chkShowGrid_CheckedChanged);
            // 
            // evoTitlePanel2
            // 
            this.evoTitlePanel2.BackColor = System.Drawing.Color.SeaShell;
            this.evoTitlePanel2.Controls.Add(this.evoTitlePanel);
            resources.ApplyResources(this.evoTitlePanel2, "evoTitlePanel2");
            this.evoTitlePanel2.Name = "evoTitlePanel2";
            // 
            // evoTitlePanel
            // 
            this.evoTitlePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.evoTitlePanel.Controls.Add(this.evoTitleVersion);
            this.evoTitlePanel.Controls.Add(this.evoTitle);
            resources.ApplyResources(this.evoTitlePanel, "evoTitlePanel");
            this.evoTitlePanel.Name = "evoTitlePanel";
            // 
            // evoTitleVersion
            // 
            resources.ApplyResources(this.evoTitleVersion, "evoTitleVersion");
            this.evoTitleVersion.ForeColor = System.Drawing.SystemColors.Control;
            this.evoTitleVersion.Name = "evoTitleVersion";
            // 
            // evoTitle
            // 
            resources.ApplyResources(this.evoTitle, "evoTitle");
            this.evoTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.evoTitle.Name = "evoTitle";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblinit
            // 
            resources.ApplyResources(this.lblinit, "lblinit");
            this.lblinit.ForeColor = System.Drawing.Color.Red;
            this.lblinit.Name = "lblinit";
            // 
            // lbCellCount
            // 
            resources.ApplyResources(this.lbCellCount, "lbCellCount");
            this.lbCellCount.Name = "lbCellCount";
            // 
            // lbGrassPict
            // 
            this.lbGrassPict.BackColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.lbGrassPict, "lbGrassPict");
            this.lbGrassPict.Name = "lbGrassPict";
            this.lbGrassPict.TabStop = false;
            // 
            // lbGrass
            // 
            resources.ApplyResources(this.lbGrass, "lbGrass");
            this.lbGrass.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.lbGrass.Name = "lbGrass";
            // 
            // lbTreesPict
            // 
            this.lbTreesPict.BackColor = System.Drawing.Color.DarkGreen;
            resources.ApplyResources(this.lbTreesPict, "lbTreesPict");
            this.lbTreesPict.Name = "lbTreesPict";
            this.lbTreesPict.TabStop = false;
            // 
            // lbTrees
            // 
            resources.ApplyResources(this.lbTrees, "lbTrees");
            this.lbTrees.ForeColor = System.Drawing.Color.LimeGreen;
            this.lbTrees.Name = "lbTrees";
            // 
            // bigEvoPaintTimer
            // 
            this.bigEvoPaintTimer.Tick += new System.EventHandler(this.bigEvoPaintTimer_Tick);
            // 
            // lblOffset
            // 
            resources.ApplyResources(this.lblOffset, "lblOffset");
            this.lblOffset.ForeColor = System.Drawing.Color.Silver;
            this.lblOffset.Name = "lblOffset";
            // 
            // lbCurrOffsetPict
            // 
            this.lbCurrOffsetPict.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.lbCurrOffsetPict, "lbCurrOffsetPict");
            this.lbCurrOffsetPict.Name = "lbCurrOffsetPict";
            this.lbCurrOffsetPict.TabStop = false;
            // 
            // lbCurrOffset
            // 
            resources.ApplyResources(this.lbCurrOffset, "lbCurrOffset");
            this.lbCurrOffset.ForeColor = System.Drawing.Color.Red;
            this.lbCurrOffset.Name = "lbCurrOffset";
            // 
            // chkShowCoo
            // 
            resources.ApplyResources(this.chkShowCoo, "chkShowCoo");
            this.chkShowCoo.Checked = true;
            this.chkShowCoo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowCoo.Name = "chkShowCoo";
            this.chkShowCoo.UseVisualStyleBackColor = true;
            this.chkShowCoo.CheckedChanged += new System.EventHandler(this.chkShowCoo_CheckedChanged);
            // 
            // lbEvoTickTime
            // 
            resources.ApplyResources(this.lbEvoTickTime, "lbEvoTickTime");
            this.lbEvoTickTime.Name = "lbEvoTickTime";
            // 
            // lblEvoStep
            // 
            resources.ApplyResources(this.lblEvoStep, "lblEvoStep");
            this.lblEvoStep.Name = "lblEvoStep";
            // 
            // richTimerInfo
            // 
            this.richTimerInfo.BackColor = System.Drawing.Color.SteelBlue;
            this.richTimerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richTimerInfo, "richTimerInfo");
            this.richTimerInfo.Name = "richTimerInfo";
            // 
            // lbEntityCount
            // 
            resources.ApplyResources(this.lbEntityCount, "lbEntityCount");
            this.lbEntityCount.Name = "lbEntityCount";
            // 
            // lblEntityCount
            // 
            resources.ApplyResources(this.lblEntityCount, "lblEntityCount");
            this.lblEntityCount.Name = "lblEntityCount";
            // 
            // lbEvoTickCount
            // 
            resources.ApplyResources(this.lbEvoTickCount, "lbEvoTickCount");
            this.lbEvoTickCount.Name = "lbEvoTickCount";
            // 
            // lbEvoInitTime
            // 
            resources.ApplyResources(this.lbEvoInitTime, "lbEvoInitTime");
            this.lbEvoInitTime.Name = "lbEvoInitTime";
            // 
            // evoPanelBig
            // 
            this.evoPanelBig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.evoPanelBig, "evoPanelBig");
            this.evoPanelBig.Name = "evoPanelBig";
            this.evoPanelBig.TabStop = false;
            this.evoPanelBig.Paint += new System.Windows.Forms.PaintEventHandler(this.pictBigEvoPanel_Paint);
            // 
            // evoPanelSmall
            // 
            this.evoPanelSmall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.evoPanelSmall, "evoPanelSmall");
            this.evoPanelSmall.Name = "evoPanelSmall";
            this.evoPanelSmall.TabStop = false;
            this.evoPanelSmall.Paint += new System.Windows.Forms.PaintEventHandler(this.pictSmallEvoPanel_Paint);
            // 
            // lbTimerInterval
            // 
            resources.ApplyResources(this.lbTimerInterval, "lbTimerInterval");
            this.lbTimerInterval.Name = "lbTimerInterval";
            // 
            // lbEvoFriquency
            // 
            resources.ApplyResources(this.lbEvoFriquency, "lbEvoFriquency");
            this.lbEvoFriquency.Name = "lbEvoFriquency";
            // 
            // EvoAppForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.evoPanelBig);
            this.Controls.Add(this.evoPanelSmall);
            this.Controls.Add(this.richTimerInfo);
            this.Controls.Add(this.lblEntityCount);
            this.Controls.Add(this.lblEvoStep);
            this.Controls.Add(this.lbEvoInitTime);
            this.Controls.Add(this.lbTimerInterval);
            this.Controls.Add(this.lbEvoFriquency);
            this.Controls.Add(this.lbEvoTickCount);
            this.Controls.Add(this.lbEntityCount);
            this.Controls.Add(this.lbEvoTickTime);
            this.Controls.Add(this.vSlider);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.lbCellCount);
            this.Controls.Add(this.lblinit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.evoTitlePanel2);
            this.Controls.Add(this.chkShowCoo);
            this.Controls.Add(this.chkShowGrid);
            this.Controls.Add(this.lbTrees);
            this.Controls.Add(this.lbGrass);
            this.Controls.Add(this.lbMountains);
            this.Controls.Add(this.lbLake);
            this.Controls.Add(this.lbCurrOffset);
            this.Controls.Add(this.lbSea);
            this.Controls.Add(this.lbDisert);
            this.Controls.Add(this.lbTreesPict);
            this.Controls.Add(this.lbGrassPict);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbMountainsPict);
            this.Controls.Add(this.lbCurrOffsetPict);
            this.Controls.Add(this.lbLakePict);
            this.Controls.Add(this.lbSeaPict);
            this.Controls.Add(this.lbDisertPict);
            this.Controls.Add(this.hSlider);
            this.MaximizeBox = false;
            this.Name = "EvoAppForm";
            this.Load += new System.EventHandler(this.EvoAppForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EvoAppForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.hSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbDisertPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbSeaPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbLakePict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMountainsPict)).EndInit();
            this.evoTitlePanel2.ResumeLayout(false);
            this.evoTitlePanel.ResumeLayout(false);
            this.evoTitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbGrassPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbTreesPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbCurrOffsetPict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoPanelBig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evoPanelSmall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel evoTitlePanel2;
        private System.Windows.Forms.Panel evoTitlePanel;
        private System.Windows.Forms.TrackBar hSlider;
        private System.Windows.Forms.TrackBar vSlider;
        private System.Windows.Forms.PictureBox lbDisertPict;
        private System.Windows.Forms.PictureBox lbSeaPict;
        private System.Windows.Forms.PictureBox lbLakePict;
        private System.Windows.Forms.PictureBox lbMountainsPict;
        private System.Windows.Forms.PictureBox lbGrassPict;
        private System.Windows.Forms.PictureBox lbTreesPict;
        private System.Windows.Forms.CheckBox chkShowGrid;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblinit;
        private System.Windows.Forms.Label lbCellCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDisert;
        private System.Windows.Forms.Label lbSea;
        private System.Windows.Forms.Label lbLake;
        private System.Windows.Forms.Label lbMountains;
        private System.Windows.Forms.Label evoTitle;
        private System.Windows.Forms.Label evoTitleVersion;
        private System.Windows.Forms.Label lbGrass;        
        private System.Windows.Forms.Label lbTrees;
        private System.Windows.Forms.Timer bigEvoPaintTimer;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.PictureBox lbCurrOffsetPict;
        private System.Windows.Forms.Label lbCurrOffset;
        private System.Windows.Forms.CheckBox chkShowCoo;
        private System.Windows.Forms.Label lbEvoTickTime;
        private System.Windows.Forms.Label lblEvoStep;
        private System.Windows.Forms.RichTextBox richTimerInfo;
        private System.Windows.Forms.Label lbEntityCount;
        private System.Windows.Forms.Label lblEntityCount;
        private System.Windows.Forms.Label lbEvoTickCount;
        private System.Windows.Forms.Label lbEvoInitTime;
        private System.Windows.Forms.PictureBox evoPanelBig;
        private System.Windows.Forms.PictureBox evoPanelSmall;
        private System.Windows.Forms.Label lbTimerInterval;
        private System.Windows.Forms.Label lbEvoFriquency;
    }
}

