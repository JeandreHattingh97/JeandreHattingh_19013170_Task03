namespace JeandreHattingh_19013170_Task02
{
    partial class frmBattleSim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblGameMap = new System.Windows.Forms.Label();
            this.rtbGameInfo = new System.Windows.Forms.RichTextBox();
            this.timerRoundTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(522, 328);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(692, 328);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(522, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(692, 390);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(628, 301);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 4;
            this.lblTimer.Text = "Timer";
            // 
            // lblGameMap
            // 
            this.lblGameMap.AutoSize = true;
            this.lblGameMap.Location = new System.Drawing.Point(45, 42);
            this.lblGameMap.Name = "lblGameMap";
            this.lblGameMap.Size = new System.Drawing.Size(59, 13);
            this.lblGameMap.TabIndex = 5;
            this.lblGameMap.Text = "Game Map";
            // 
            // rtbGameInfo
            // 
            this.rtbGameInfo.Location = new System.Drawing.Point(522, 12);
            this.rtbGameInfo.Name = "rtbGameInfo";
            this.rtbGameInfo.Size = new System.Drawing.Size(245, 266);
            this.rtbGameInfo.TabIndex = 6;
            this.rtbGameInfo.Text = "";
            // 
            // timerRoundTimer
            // 
            this.timerRoundTimer.Interval = 1000;
            this.timerRoundTimer.Tick += new System.EventHandler(this.timerRoundTimer_Tick);
            // 
            // frmBattleSim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtbGameInfo);
            this.Controls.Add(this.lblGameMap);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "frmBattleSim";
            this.Text = "Battle Sim";
            this.Load += new System.EventHandler(this.frmBattleSim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblGameMap;
        private System.Windows.Forms.RichTextBox rtbGameInfo;
        private System.Windows.Forms.Timer timerRoundTimer;
    }
}

