
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
            this.panelEvoBig = new System.Windows.Forms.Panel();
            this.hSlider = new System.Windows.Forms.TrackBar();
            this.vSlider = new System.Windows.Forms.TrackBar();
            this.panelEvoSmall = new System.Windows.Forms.Panel();
            this.pbLandDesert = new System.Windows.Forms.PictureBox();
            this.pbLandSea = new System.Windows.Forms.PictureBox();
            this.pbLandLake = new System.Windows.Forms.PictureBox();
            this.pbLandMountains = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboEvoSpeed = new System.Windows.Forms.ComboBox();
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblinit = new System.Windows.Forms.Label();
            this.lblCellCount = new System.Windows.Forms.Label();
            this.pbLandGrass = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pbLandTrees = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bigGamePaintTimer = new System.Windows.Forms.Timer(this.components);
            this.lblOffsetCaption = new System.Windows.Forms.Label();
            this.lblOffset = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkShowCoo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandDesert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandSea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandLake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandMountains)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandGrass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandTrees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEvoBig
            // 
            this.panelEvoBig.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.panelEvoBig, "panelEvoBig");
            this.panelEvoBig.Name = "panelEvoBig";
            this.panelEvoBig.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBigGame_Paint);
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
            // panelEvoSmall
            // 
            this.panelEvoSmall.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelEvoSmall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.panelEvoSmall, "panelEvoSmall");
            this.panelEvoSmall.Name = "panelEvoSmall";
            this.panelEvoSmall.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSmallGame_Paint);
            // 
            // pbLandDesert
            // 
            this.pbLandDesert.BackColor = System.Drawing.Color.PaleGoldenrod;
            resources.ApplyResources(this.pbLandDesert, "pbLandDesert");
            this.pbLandDesert.Name = "pbLandDesert";
            this.pbLandDesert.TabStop = false;
            // 
            // pbLandSea
            // 
            this.pbLandSea.BackColor = System.Drawing.Color.MediumBlue;
            resources.ApplyResources(this.pbLandSea, "pbLandSea");
            this.pbLandSea.Name = "pbLandSea";
            this.pbLandSea.TabStop = false;
            // 
            // pbLandLake
            // 
            this.pbLandLake.BackColor = System.Drawing.Color.Aqua;
            resources.ApplyResources(this.pbLandLake, "pbLandLake");
            this.pbLandLake.Name = "pbLandLake";
            this.pbLandLake.TabStop = false;
            // 
            // pbLandMountains
            // 
            this.pbLandMountains.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.pbLandMountains, "pbLandMountains");
            this.pbLandMountains.Name = "pbLandMountains";
            this.pbLandMountains.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.BurlyWood;
            this.label5.Name = "label5";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // comboEvoSpeed
            // 
            this.comboEvoSpeed.FormattingEnabled = true;
            this.comboEvoSpeed.Items.AddRange(new object[] {
            resources.GetString("comboEvoSpeed.Items"),
            resources.GetString("comboEvoSpeed.Items1"),
            resources.GetString("comboEvoSpeed.Items2")});
            resources.ApplyResources(this.comboEvoSpeed, "comboEvoSpeed");
            this.comboEvoSpeed.Name = "comboEvoSpeed";
            this.comboEvoSpeed.SelectedValueChanged += new System.EventHandler(this.comboEvoSpeed_SelectedValueChanged);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaShell;
            this.panel3.Controls.Add(this.panel4);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SteelBlue;
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Name = "label8";
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lblinit
            // 
            resources.ApplyResources(this.lblinit, "lblinit");
            this.lblinit.ForeColor = System.Drawing.Color.Red;
            this.lblinit.Name = "lblinit";
            // 
            // lblCellCount
            // 
            resources.ApplyResources(this.lblCellCount, "lblCellCount");
            this.lblCellCount.Name = "lblCellCount";
            // 
            // pbLandGrass
            // 
            this.pbLandGrass.BackColor = System.Drawing.Color.MediumSeaGreen;
            resources.ApplyResources(this.pbLandGrass, "pbLandGrass");
            this.pbLandGrass.Name = "pbLandGrass";
            this.pbLandGrass.TabStop = false;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.label10.Name = "label10";
            // 
            // pbLandTrees
            // 
            this.pbLandTrees.BackColor = System.Drawing.Color.DarkGreen;
            resources.ApplyResources(this.pbLandTrees, "pbLandTrees");
            this.pbLandTrees.Name = "pbLandTrees";
            this.pbLandTrees.TabStop = false;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.LimeGreen;
            this.label11.Name = "label11";
            // 
            // bigGamePaintTimer
            // 
            this.bigGamePaintTimer.Tick += new System.EventHandler(this.bigGamePaintTimer_Tick);
            // 
            // lblOffsetCaption
            // 
            resources.ApplyResources(this.lblOffsetCaption, "lblOffsetCaption");
            this.lblOffsetCaption.ForeColor = System.Drawing.Color.Silver;
            this.lblOffsetCaption.Name = "lblOffsetCaption";
            // 
            // lblOffset
            // 
            resources.ApplyResources(this.lblOffset, "lblOffset");
            this.lblOffset.ForeColor = System.Drawing.Color.Silver;
            this.lblOffset.Name = "lblOffset";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Name = "label6";
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
            // EvoAppForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.panelEvoBig);
            this.Controls.Add(this.vSlider);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.lblOffsetCaption);
            this.Controls.Add(this.lblCellCount);
            this.Controls.Add(this.lblinit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.chkShowCoo);
            this.Controls.Add(this.chkShowGrid);
            this.Controls.Add(this.comboEvoSpeed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbLandTrees);
            this.Controls.Add(this.pbLandGrass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbLandMountains);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbLandLake);
            this.Controls.Add(this.pbLandSea);
            this.Controls.Add(this.pbLandDesert);
            this.Controls.Add(this.panelEvoSmall);
            this.Controls.Add(this.hSlider);
            this.MaximizeBox = false;
            this.Name = "EvoAppForm";
            this.Load += new System.EventHandler(this.EvoAppForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EvoAppForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.hSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandDesert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandSea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandLake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandMountains)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandGrass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLandTrees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelEvoBig;
        private System.Windows.Forms.Panel panelEvoSmall;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TrackBar hSlider;
        private System.Windows.Forms.TrackBar vSlider;
        private System.Windows.Forms.PictureBox pbLandDesert;
        private System.Windows.Forms.PictureBox pbLandSea;
        private System.Windows.Forms.PictureBox pbLandLake;
        private System.Windows.Forms.PictureBox pbLandMountains;
        private System.Windows.Forms.PictureBox pbLandGrass;
        private System.Windows.Forms.PictureBox pbLandTrees;
        private System.Windows.Forms.ComboBox comboEvoSpeed;
        private System.Windows.Forms.CheckBox chkShowGrid;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblinit;
        private System.Windows.Forms.Label lblCellCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;        
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Timer bigGamePaintTimer;
        private System.Windows.Forms.Label lblOffsetCaption;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkShowCoo;
    }
}

