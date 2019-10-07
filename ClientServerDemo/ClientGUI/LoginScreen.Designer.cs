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
            this.login = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.patientNumber = new System.Windows.Forms.TextBox();
            this.unknownNumber = new System.Windows.Forms.Label();
            this.selectBike = new System.Windows.Forms.ComboBox();
<<<<<<< Updated upstream
=======
            this.startSession = new System.Windows.Forms.Button();
            this.instructions = new System.Windows.Forms.RichTextBox();
            this.time = new System.Windows.Forms.Timer(this.components);
            this.timePassed = new System.Windows.Forms.Label();
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.login.Location = new System.Drawing.Point(299, 260);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(161, 46);
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
            this.name.Location = new System.Drawing.Point(299, 164);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(161, 26);
            this.name.TabIndex = 1;
            this.name.Text = "Naam";
            this.name.Enter += new System.EventHandler(this.Name_Enter);
            this.name.Leave += new System.EventHandler(this.Name_Leave);
<<<<<<< Updated upstream
            // 
            // patientNumber
            // 
            this.patientNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patientNumber.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.patientNumber.Location = new System.Drawing.Point(299, 196);
            this.patientNumber.Name = "patientNumber";
            this.patientNumber.Size = new System.Drawing.Size(161, 26);
            this.patientNumber.TabIndex = 2;
            this.patientNumber.Text = "Patiëntnummer";
            this.patientNumber.Enter += new System.EventHandler(this.PatientNumber_Enter);
            this.patientNumber.Leave += new System.EventHandler(this.PatientNumber_Leave);
            // 
            // unknownNumber
            // 
            this.unknownNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unknownNumber.AutoSize = true;
            this.unknownNumber.ForeColor = System.Drawing.Color.Red;
            this.unknownNumber.Location = new System.Drawing.Point(271, 309);
            this.unknownNumber.Name = "unknownNumber";
            this.unknownNumber.Size = new System.Drawing.Size(209, 20);
            this.unknownNumber.TabIndex = 3;
            this.unknownNumber.Text = "Patiëntnummer bestaat niet!";
            this.unknownNumber.Visible = false;
=======
>>>>>>> Stashed changes
            // 
            // selectBike
            // 
            this.selectBike.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBike.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBike.FormattingEnabled = true;
            this.selectBike.Location = new System.Drawing.Point(299, 228);
            this.selectBike.Name = "selectBike";
            this.selectBike.Size = new System.Drawing.Size(161, 25);
            this.selectBike.TabIndex = 6;
            this.selectBike.Text = "Selecteer een fiets";
            // 
<<<<<<< Updated upstream
=======
            // startSession
            // 
            this.startSession.Enabled = false;
            this.startSession.Location = new System.Drawing.Point(12, 349);
            this.startSession.Name = "startSession";
            this.startSession.Size = new System.Drawing.Size(145, 89);
            this.startSession.TabIndex = 8;
            this.startSession.Text = "Start";
            this.startSession.UseVisualStyleBackColor = true;
            // 
            // instructions
            // 
            this.instructions.Location = new System.Drawing.Point(235, 12);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(553, 426);
            this.instructions.TabIndex = 9;
            this.instructions.Text = "";
            // 
            // timePassed
            // 
            this.timePassed.AutoSize = true;
            this.timePassed.Location = new System.Drawing.Point(12, 326);
            this.timePassed.Name = "timePassed";
            this.timePassed.Size = new System.Drawing.Size(49, 20);
            this.timePassed.TabIndex = 10;
            this.timePassed.Text = "00:00";
            // 
>>>>>>> Stashed changes
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
<<<<<<< Updated upstream
=======
            this.Controls.Add(this.timePassed);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.startSession);
>>>>>>> Stashed changes
            this.Controls.Add(this.selectBike);
            this.Controls.Add(this.unknownNumber);
            this.Controls.Add(this.patientNumber);
            this.Controls.Add(this.name);
            this.Controls.Add(this.login);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox patientNumber;
        private System.Windows.Forms.Label unknownNumber;
        private System.Windows.Forms.ComboBox selectBike;
<<<<<<< Updated upstream
=======
        private System.Windows.Forms.Button startSession;
        private System.Windows.Forms.RichTextBox instructions;
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Label timePassed;
>>>>>>> Stashed changes
    }
}