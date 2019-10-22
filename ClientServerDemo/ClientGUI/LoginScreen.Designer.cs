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
            this.steadyStateMessage = new System.Windows.Forms.TextBox();
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
            this.login.Location = new System.Drawing.Point(8, 114);
            this.login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(107, 30);
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
            this.name.Location = new System.Drawing.Point(8, 8);
            this.name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(109, 20);
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
            this.selectBike.Location = new System.Drawing.Point(8, 94);
            this.selectBike.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectBike.Name = "selectBike";
            this.selectBike.Size = new System.Drawing.Size(109, 20);
            this.selectBike.TabIndex = 6;
            this.selectBike.Text = "Selecteer een fiets";
            // 
            // startSession
            // 
            this.startSession.Location = new System.Drawing.Point(8, 214);
            this.startSession.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startSession.Name = "startSession";
            this.startSession.Size = new System.Drawing.Size(107, 33);
            this.startSession.TabIndex = 8;
            this.startSession.Text = "Start";
            this.startSession.UseVisualStyleBackColor = true;
            this.startSession.Click += new System.EventHandler(this.StartSession_Click);
            // 
            // instructions
            // 
            this.instructions.Location = new System.Drawing.Point(145, 8);
            this.instructions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(165, 144);
            this.instructions.TabIndex = 9;
            this.instructions.Text = "";
            // 
            // timePassed
            // 
            this.timePassed.AutoSize = true;
            this.timePassed.Location = new System.Drawing.Point(8, 200);
            this.timePassed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timePassed.Name = "timePassed";
            this.timePassed.Size = new System.Drawing.Size(34, 13);
            this.timePassed.TabIndex = 10;
            this.timePassed.Text = "00:00";
            // 
            // comboGender
            // 
            this.comboGender.FormattingEnabled = true;
            this.comboGender.Location = new System.Drawing.Point(8, 29);
            this.comboGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboGender.Name = "comboGender";
            this.comboGender.Size = new System.Drawing.Size(109, 21);
            this.comboGender.TabIndex = 11;
            this.comboGender.Text = "Geslacht";
            // 
            // comboAge
            // 
            this.comboAge.FormattingEnabled = true;
            this.comboAge.Location = new System.Drawing.Point(8, 51);
            this.comboAge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboAge.Name = "comboAge";
            this.comboAge.Size = new System.Drawing.Size(109, 21);
            this.comboAge.TabIndex = 12;
            this.comboAge.Text = "Leeftijd";
            // 
            // labelRPM
            // 
            this.labelRPM.AutoSize = true;
            this.labelRPM.Location = new System.Drawing.Point(151, 240);
            this.labelRPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(37, 13);
            this.labelRPM.TabIndex = 13;
            this.labelRPM.Text = "RPM: ";
            // 
            // labelBPM
            // 
            this.labelBPM.AutoSize = true;
            this.labelBPM.Location = new System.Drawing.Point(151, 265);
            this.labelBPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBPM.Name = "labelBPM";
            this.labelBPM.Size = new System.Drawing.Size(80, 13);
            this.labelBPM.TabIndex = 14;
            this.labelBPM.Text = "Hartfrequentie: ";
            // 
            // labelResistance
            // 
            this.labelResistance.AutoSize = true;
            this.labelResistance.Location = new System.Drawing.Point(151, 214);
            this.labelResistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelResistance.Name = "labelResistance";
            this.labelResistance.Size = new System.Drawing.Size(65, 13);
            this.labelResistance.TabIndex = 15;
            this.labelResistance.Text = "Weerstand: ";
            // 
            // realtimeRPM
            // 
            this.realtimeRPM.AutoSize = true;
            this.realtimeRPM.Location = new System.Drawing.Point(243, 240);
            this.realtimeRPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimeRPM.Name = "realtimeRPM";
            this.realtimeRPM.Size = new System.Drawing.Size(13, 13);
            this.realtimeRPM.TabIndex = 16;
            this.realtimeRPM.Text = "0";
            // 
            // realtimeHF
            // 
            this.realtimeHF.AutoSize = true;
            this.realtimeHF.Location = new System.Drawing.Point(243, 265);
            this.realtimeHF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimeHF.Name = "realtimeHF";
            this.realtimeHF.Size = new System.Drawing.Size(13, 13);
            this.realtimeHF.TabIndex = 17;
            this.realtimeHF.Text = "0";
            // 
            // realtimeResistance
            // 
            this.realtimeResistance.AutoSize = true;
            this.realtimeResistance.Location = new System.Drawing.Point(243, 214);
            this.realtimeResistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimeResistance.Name = "realtimeResistance";
            this.realtimeResistance.Size = new System.Drawing.Size(13, 13);
            this.realtimeResistance.TabIndex = 18;
            this.realtimeResistance.Text = "0";
            // 
            // stopSession
            // 
            this.stopSession.Location = new System.Drawing.Point(8, 252);
            this.stopSession.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stopSession.Name = "stopSession";
            this.stopSession.Size = new System.Drawing.Size(107, 33);
            this.stopSession.TabIndex = 19;
            this.stopSession.Text = "Stop";
            this.stopSession.UseVisualStyleBackColor = true;
            this.stopSession.Click += new System.EventHandler(this.StopSession_Click);
            // 
            // labelFase
            // 
            this.labelFase.AutoSize = true;
            this.labelFase.Location = new System.Drawing.Point(339, 216);
            this.labelFase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFase.Name = "labelFase";
            this.labelFase.Size = new System.Drawing.Size(36, 13);
            this.labelFase.TabIndex = 20;
            this.labelFase.Text = "Fase: ";
            // 
            // labelPhaseTime
            // 
            this.labelPhaseTime.AutoSize = true;
            this.labelPhaseTime.Location = new System.Drawing.Point(339, 240);
            this.labelPhaseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPhaseTime.Name = "labelPhaseTime";
            this.labelPhaseTime.Size = new System.Drawing.Size(49, 13);
            this.labelPhaseTime.TabIndex = 21;
            this.labelPhaseTime.Text = "Fasetijd: ";
            // 
            // realtimePhase
            // 
            this.realtimePhase.AutoSize = true;
            this.realtimePhase.Location = new System.Drawing.Point(489, 216);
            this.realtimePhase.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimePhase.Name = "realtimePhase";
            this.realtimePhase.Size = new System.Drawing.Size(13, 13);
            this.realtimePhase.TabIndex = 22;
            this.realtimePhase.Text = "0";
            // 
            // realtimePhaseTime
            // 
            this.realtimePhaseTime.AutoSize = true;
            this.realtimePhaseTime.Location = new System.Drawing.Point(489, 240);
            this.realtimePhaseTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimePhaseTime.Name = "realtimePhaseTime";
            this.realtimePhaseTime.Size = new System.Drawing.Size(13, 13);
            this.realtimePhaseTime.TabIndex = 23;
            this.realtimePhaseTime.Text = "0";
            // 
            // resistanceMessage
            // 
            this.resistanceMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resistanceMessage.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.resistanceMessage.Location = new System.Drawing.Point(145, 196);
            this.resistanceMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resistanceMessage.Name = "resistanceMessage";
            this.resistanceMessage.Size = new System.Drawing.Size(373, 20);
            this.resistanceMessage.TabIndex = 25;
            // 
            // labelHeart
            // 
            this.labelHeart.AutoSize = true;
            this.labelHeart.Location = new System.Drawing.Point(339, 265);
            this.labelHeart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeart.Name = "labelHeart";
            this.labelHeart.Size = new System.Drawing.Size(126, 13);
            this.labelHeart.TabIndex = 26;
            this.labelHeart.Text = "Gemeten Hartfrequentie: ";
            // 
            // realtimeGemHF
            // 
            this.realtimeGemHF.AutoSize = true;
            this.realtimeGemHF.Location = new System.Drawing.Point(489, 265);
            this.realtimeGemHF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.realtimeGemHF.Name = "realtimeGemHF";
            this.realtimeGemHF.Size = new System.Drawing.Size(13, 13);
            this.realtimeGemHF.TabIndex = 27;
            this.realtimeGemHF.Text = "0";
            // 
            // steadyStateMessage
            // 
            this.steadyStateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.steadyStateMessage.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.steadyStateMessage.Location = new System.Drawing.Point(145, 175);
            this.steadyStateMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.steadyStateMessage.Name = "steadyStateMessage";
            this.steadyStateMessage.Size = new System.Drawing.Size(373, 20);
            this.steadyStateMessage.TabIndex = 28;
            // 
            // textWeight
            // 
            this.textWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textWeight.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textWeight.Location = new System.Drawing.Point(8, 73);
            this.textWeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textWeight.Name = "textWeight";
            this.textWeight.Size = new System.Drawing.Size(109, 20);
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
            this.rotationMessage.Location = new System.Drawing.Point(145, 154);
            this.rotationMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rotationMessage.Name = "rotationMessage";
            this.rotationMessage.Size = new System.Drawing.Size(373, 20);
            this.rotationMessage.TabIndex = 30;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(325, 8);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.chart1.Size = new System.Drawing.Size(192, 142);
            this.chart1.TabIndex = 31;
            this.chart1.Text = "chart1";
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.rotationMessage);
            this.Controls.Add(this.textWeight);
            this.Controls.Add(this.steadyStateMessage);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.TextBox steadyStateMessage;
        private System.Windows.Forms.TextBox textWeight;
        private System.Windows.Forms.TextBox rotationMessage;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}