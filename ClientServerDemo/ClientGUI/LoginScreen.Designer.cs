namespace ClientGUI
{
    partial class LoginScreen
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.login = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.selectBike = new System.Windows.Forms.ComboBox();
            this.startSession = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.RichTextBox();
            this.timePassed = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.comboGender = new System.Windows.Forms.ComboBox();
            this.comboAge = new System.Windows.Forms.ComboBox();
            this.labelRPM = new System.Windows.Forms.Label();
            this.labelBPM = new System.Windows.Forms.Label();
            this.labelResistance = new System.Windows.Forms.Label();
            this.realtimeRPM = new System.Windows.Forms.Label();
            this.realtimeHF = new System.Windows.Forms.Label();
            this.realtimeResistance = new System.Windows.Forms.Label();
            this.stopSession = new System.Windows.Forms.Button();
            this.labelFase = new System.Windows.Forms.Label();
            this.labelPhaseTime = new System.Windows.Forms.Label();
            this.realtimePhase = new System.Windows.Forms.Label();
            this.realtimePhaseTime = new System.Windows.Forms.Label();
            this.resistanceMessage = new System.Windows.Forms.TextBox();
            this.labelHeart = new System.Windows.Forms.Label();
            this.realtimeGemHF = new System.Windows.Forms.Label();
            this.textWeight = new System.Windows.Forms.TextBox();
            this.rotationMessage = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login.Location = new System.Drawing.Point(12, 175);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(160, 46);
            this.login.TabIndex = 0;
            this.login.Text = "Log-in";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.Login_Click);
            // 
            // name
            // 
            this.name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.name.Location = new System.Drawing.Point(12, 12);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(162, 26);
            this.name.TabIndex = 1;
            this.name.Text = "Naam";
            this.name.Enter += new System.EventHandler(this.Name_Enter);
            this.name.Leave += new System.EventHandler(this.Name_Leave);
            // 
            // selectBike
            // 
            this.selectBike.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBike.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBike.FormattingEnabled = true;
            this.selectBike.Location = new System.Drawing.Point(12, 145);
            this.selectBike.Name = "selectBike";
            this.selectBike.Size = new System.Drawing.Size(162, 25);
            this.selectBike.TabIndex = 6;
            this.selectBike.Text = "Selecteer een fiets";
            // 
            // startSession
            // 
            this.startSession.Location = new System.Drawing.Point(12, 329);
            this.startSession.Name = "startSession";
            this.startSession.Size = new System.Drawing.Size(160, 51);
            this.startSession.TabIndex = 8;
            this.startSession.Text = "Start";
            this.startSession.UseVisualStyleBackColor = true;
            this.startSession.Click += new System.EventHandler(this.StartSession_Click);
            // 
            // instructions
            // 
            this.instructions.Location = new System.Drawing.Point(218, 189);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(558, 75);
            this.instructions.TabIndex = 9;
            this.instructions.Text = "";
            // 
            // timePassed
            // 
            this.timePassed.AutoSize = true;
            this.timePassed.Location = new System.Drawing.Point(12, 308);
            this.timePassed.Name = "timePassed";
            this.timePassed.Size = new System.Drawing.Size(49, 20);
            this.timePassed.TabIndex = 10;
            this.timePassed.Text = "00:00";
            // 
            // comboGender
            // 
            this.comboGender.FormattingEnabled = true;
            this.comboGender.Location = new System.Drawing.Point(12, 45);
            this.comboGender.Name = "comboGender";
            this.comboGender.Size = new System.Drawing.Size(162, 28);
            this.comboGender.TabIndex = 11;
            this.comboGender.Text = "Geslacht";
            // 
            // comboAge
            // 
            this.comboAge.FormattingEnabled = true;
            this.comboAge.Location = new System.Drawing.Point(12, 78);
            this.comboAge.Name = "comboAge";
            this.comboAge.Size = new System.Drawing.Size(162, 28);
            this.comboAge.TabIndex = 12;
            this.comboAge.Text = "Leeftijd";
            // 
            // labelRPM
            // 
            this.labelRPM.AutoSize = true;
            this.labelRPM.Location = new System.Drawing.Point(226, 369);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(52, 20);
            this.labelRPM.TabIndex = 13;
            this.labelRPM.Text = "RPM: ";
            // 
            // labelBPM
            // 
            this.labelBPM.AutoSize = true;
            this.labelBPM.Location = new System.Drawing.Point(226, 408);
            this.labelBPM.Name = "labelBPM";
            this.labelBPM.Size = new System.Drawing.Size(120, 20);
            this.labelBPM.TabIndex = 14;
            this.labelBPM.Text = "Hartfrequentie: ";
            // 
            // labelResistance
            // 
            this.labelResistance.AutoSize = true;
            this.labelResistance.Location = new System.Drawing.Point(226, 329);
            this.labelResistance.Name = "labelResistance";
            this.labelResistance.Size = new System.Drawing.Size(95, 20);
            this.labelResistance.TabIndex = 15;
            this.labelResistance.Text = "Weerstand: ";
            // 
            // realtimeRPM
            // 
            this.realtimeRPM.AutoSize = true;
            this.realtimeRPM.Location = new System.Drawing.Point(364, 369);
            this.realtimeRPM.Name = "realtimeRPM";
            this.realtimeRPM.Size = new System.Drawing.Size(18, 20);
            this.realtimeRPM.TabIndex = 16;
            this.realtimeRPM.Text = "0";
            // 
            // realtimeHF
            // 
            this.realtimeHF.AutoSize = true;
            this.realtimeHF.Location = new System.Drawing.Point(364, 408);
            this.realtimeHF.Name = "realtimeHF";
            this.realtimeHF.Size = new System.Drawing.Size(18, 20);
            this.realtimeHF.TabIndex = 17;
            this.realtimeHF.Text = "0";
            // 
            // realtimeResistance
            // 
            this.realtimeResistance.AutoSize = true;
            this.realtimeResistance.Location = new System.Drawing.Point(364, 329);
            this.realtimeResistance.Name = "realtimeResistance";
            this.realtimeResistance.Size = new System.Drawing.Size(18, 20);
            this.realtimeResistance.TabIndex = 18;
            this.realtimeResistance.Text = "0";
            // 
            // stopSession
            // 
            this.stopSession.Location = new System.Drawing.Point(12, 388);
            this.stopSession.Name = "stopSession";
            this.stopSession.Size = new System.Drawing.Size(160, 51);
            this.stopSession.TabIndex = 19;
            this.stopSession.Text = "Stop";
            this.stopSession.UseVisualStyleBackColor = true;
            this.stopSession.Click += new System.EventHandler(this.StopSession_Click);
            // 
            // labelFase
            // 
            this.labelFase.AutoSize = true;
            this.labelFase.Location = new System.Drawing.Point(508, 332);
            this.labelFase.Name = "labelFase";
            this.labelFase.Size = new System.Drawing.Size(53, 20);
            this.labelFase.TabIndex = 20;
            this.labelFase.Text = "Fase: ";
            // 
            // labelPhaseTime
            // 
            this.labelPhaseTime.AutoSize = true;
            this.labelPhaseTime.Location = new System.Drawing.Point(508, 369);
            this.labelPhaseTime.Name = "labelPhaseTime";
            this.labelPhaseTime.Size = new System.Drawing.Size(73, 20);
            this.labelPhaseTime.TabIndex = 21;
            this.labelPhaseTime.Text = "Fasetijd: ";
            // 
            // realtimePhase
            // 
            this.realtimePhase.AutoSize = true;
            this.realtimePhase.Location = new System.Drawing.Point(734, 332);
            this.realtimePhase.Name = "realtimePhase";
            this.realtimePhase.Size = new System.Drawing.Size(18, 20);
            this.realtimePhase.TabIndex = 22;
            this.realtimePhase.Text = "0";
            // 
            // realtimePhaseTime
            // 
            this.realtimePhaseTime.AutoSize = true;
            this.realtimePhaseTime.Location = new System.Drawing.Point(734, 369);
            this.realtimePhaseTime.Name = "realtimePhaseTime";
            this.realtimePhaseTime.Size = new System.Drawing.Size(18, 20);
            this.realtimePhaseTime.TabIndex = 23;
            this.realtimePhaseTime.Text = "0";
            // 
            // resistanceMessage
            // 
            this.resistanceMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resistanceMessage.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.resistanceMessage.Location = new System.Drawing.Point(218, 302);
            this.resistanceMessage.Name = "resistanceMessage";
            this.resistanceMessage.Size = new System.Drawing.Size(558, 26);
            this.resistanceMessage.TabIndex = 25;
            // 
            // labelHeart
            // 
            this.labelHeart.AutoSize = true;
            this.labelHeart.Location = new System.Drawing.Point(508, 408);
            this.labelHeart.Name = "labelHeart";
            this.labelHeart.Size = new System.Drawing.Size(191, 20);
            this.labelHeart.TabIndex = 26;
            this.labelHeart.Text = "Gemeten Hartfrequentie: ";
            // 
            // realtimeGemHF
            // 
            this.realtimeGemHF.AutoSize = true;
            this.realtimeGemHF.Location = new System.Drawing.Point(734, 408);
            this.realtimeGemHF.Name = "realtimeGemHF";
            this.realtimeGemHF.Size = new System.Drawing.Size(18, 20);
            this.realtimeGemHF.TabIndex = 27;
            this.realtimeGemHF.Text = "0";
            // 
            // textWeight
            // 
            this.textWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWeight.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textWeight.Location = new System.Drawing.Point(12, 112);
            this.textWeight.Name = "textWeight";
            this.textWeight.Size = new System.Drawing.Size(162, 26);
            this.textWeight.TabIndex = 29;
            this.textWeight.Text = "Gewicht in kg";
            this.textWeight.Enter += new System.EventHandler(this.TextWeight_Enter);
            this.textWeight.Leave += new System.EventHandler(this.TextWeight_Leave);
            // 
            // rotationMessage
            // 
            this.rotationMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationMessage.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.rotationMessage.Location = new System.Drawing.Point(218, 270);
            this.rotationMessage.Name = "rotationMessage";
            this.rotationMessage.Size = new System.Drawing.Size(558, 26);
            this.rotationMessage.TabIndex = 30;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(218, -3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "RPM";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Heartrate";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(558, 186);
            this.chart1.TabIndex = 31;
            this.chart1.Text = "chart1";
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.rotationMessage);
            this.Controls.Add(this.textWeight);
            this.Controls.Add(this.realtimeGemHF);
            this.Controls.Add(this.labelHeart);
            this.Controls.Add(this.resistanceMessage);
            this.Controls.Add(this.realtimePhaseTime);
            this.Controls.Add(this.realtimePhase);
            this.Controls.Add(this.labelPhaseTime);
            this.Controls.Add(this.labelFase);
            this.Controls.Add(this.stopSession);
            this.Controls.Add(this.realtimeResistance);
            this.Controls.Add(this.realtimeHF);
            this.Controls.Add(this.realtimeRPM);
            this.Controls.Add(this.labelResistance);
            this.Controls.Add(this.labelBPM);
            this.Controls.Add(this.labelRPM);
            this.Controls.Add(this.comboAge);
            this.Controls.Add(this.comboGender);
            this.Controls.Add(this.timePassed);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.startSession);
            this.Controls.Add(this.selectBike);
            this.Controls.Add(this.name);
            this.Controls.Add(this.login);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.ComboBox selectBike;
        private System.Windows.Forms.Button startSession;
        private System.Windows.Forms.RichTextBox instructions;
        private System.Windows.Forms.Label timePassed;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.ComboBox comboGender;
        private System.Windows.Forms.ComboBox comboAge;
        private System.Windows.Forms.Label labelRPM;
        private System.Windows.Forms.Label labelBPM;
        private System.Windows.Forms.Label labelResistance;
        private System.Windows.Forms.Label realtimeRPM;
        private System.Windows.Forms.Label realtimeHF;
        private System.Windows.Forms.Label realtimeResistance;
        private System.Windows.Forms.Button stopSession;
        private System.Windows.Forms.Label labelFase;
        private System.Windows.Forms.Label labelPhaseTime;
        private System.Windows.Forms.Label realtimePhase;
        private System.Windows.Forms.Label realtimePhaseTime;
        private System.Windows.Forms.TextBox resistanceMessage;
        private System.Windows.Forms.Label labelHeart;
        private System.Windows.Forms.Label realtimeGemHF;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.TextBox rotationMessage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}