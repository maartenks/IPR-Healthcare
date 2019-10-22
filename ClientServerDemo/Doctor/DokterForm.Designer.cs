namespace Doctor
{
    partial class DokterForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.AvailableLabel = new System.Windows.Forms.Label();
            this.selectedListView = new System.Windows.Forms.ListView();
            this.availableListBox = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.allHistroy = new System.Windows.Forms.ListBox();
            this.BeschikbareHistroy = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableLabel
            // 
            this.AvailableLabel.AutoSize = true;
            this.AvailableLabel.Location = new System.Drawing.Point(30, 20);
            this.AvailableLabel.Name = "AvailableLabel";
            this.AvailableLabel.Size = new System.Drawing.Size(126, 15);
            this.AvailableLabel.TabIndex = 0;
            this.AvailableLabel.Text = "Beschikbare Patienten:";
            // 
            // selectedListView
            // 
            this.selectedListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedListView.HideSelection = false;
            this.selectedListView.Location = new System.Drawing.Point(492, 38);
            this.selectedListView.Name = "selectedListView";
            this.selectedListView.Size = new System.Drawing.Size(0, 0);
            this.selectedListView.TabIndex = 3;
            this.selectedListView.UseCompatibleStateImageBehavior = false;
            // 
            // availableListBox
            // 
            this.availableListBox.FormattingEnabled = true;
            this.availableListBox.ItemHeight = 15;
            this.availableListBox.Location = new System.Drawing.Point(33, 39);
            this.availableListBox.Name = "availableListBox";
            this.availableListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.availableListBox.Size = new System.Drawing.Size(306, 94);
            this.availableListBox.TabIndex = 10;
            this.availableListBox.SelectedIndexChanged += new System.EventHandler(this.AvailableListBox_SelectedIndexChanged_1);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(33, 160);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "VO2Now";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(727, 300);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.Chart1_Click);
            // 
            // allHistroy
            // 
            this.allHistroy.FormattingEnabled = true;
            this.allHistroy.ItemHeight = 15;
            this.allHistroy.Location = new System.Drawing.Point(463, 39);
            this.allHistroy.Name = "allHistroy";
            this.allHistroy.Size = new System.Drawing.Size(297, 94);
            this.allHistroy.TabIndex = 14;
            this.allHistroy.SelectedIndexChanged += new System.EventHandler(this.AllHistroy_SelectedIndexChanged);
            // 
            // BeschikbareHistroy
            // 
            this.BeschikbareHistroy.AutoSize = true;
            this.BeschikbareHistroy.Location = new System.Drawing.Point(463, 20);
            this.BeschikbareHistroy.Name = "BeschikbareHistroy";
            this.BeschikbareHistroy.Size = new System.Drawing.Size(106, 15);
            this.BeschikbareHistroy.TabIndex = 15;
            this.BeschikbareHistroy.Text = "Beschikbar hystory";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(367, 466);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 16;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(367, 39);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 17;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // DokterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(821, 501);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.BeschikbareHistroy);
            this.Controls.Add(this.allHistroy);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.availableListBox);
            this.Controls.Add(this.selectedListView);
            this.Controls.Add(this.AvailableLabel);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DokterForm";
            this.Text = "Dokter";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AvailableLabel;
        private System.Windows.Forms.ListView selectedListView;
        private System.Windows.Forms.ListBox availableListBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox allHistroy;
        private System.Windows.Forms.Label BeschikbareHistroy;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button refresh;
    }
}

