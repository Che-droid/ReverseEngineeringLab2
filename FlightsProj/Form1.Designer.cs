namespace FlightsProj
{
    partial class Form1
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.departureLocation = new System.Windows.Forms.TextBox();
            this.departureLabel = new System.Windows.Forms.Label();
            this.arrivalLabel = new System.Windows.Forms.Label();
            this.willDoButton = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.departureDate = new System.Windows.Forms.DateTimePicker();
            this.arrivalDate = new System.Windows.Forms.DateTimePicker();
            this.arrivalLocation = new System.Windows.Forms.TextBox();
            this.sendViaGmailCheckBox = new System.Windows.Forms.CheckBox();
            this.gmailFromTextBox = new System.Windows.Forms.TextBox();
            this.gmailToTextBox = new System.Windows.Forms.TextBox();
            this.gmailPasswordTextBox = new System.Windows.Forms.TextBox();
            this.attachementPathTextBox = new System.Windows.Forms.TextBox();
            this.attachementPathLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(294, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(527, 418);
            this.webBrowser1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // departureLocation
            // 
            this.departureLocation.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureLocation.Location = new System.Drawing.Point(12, 34);
            this.departureLocation.Name = "departureLocation";
            this.departureLocation.Size = new System.Drawing.Size(100, 21);
            this.departureLocation.TabIndex = 2;
            this.departureLocation.Text = "Locatie";
            // 
            // departureLabel
            // 
            this.departureLabel.AutoSize = true;
            this.departureLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureLabel.Location = new System.Drawing.Point(9, 18);
            this.departureLabel.Name = "departureLabel";
            this.departureLabel.Size = new System.Drawing.Size(56, 15);
            this.departureLabel.TabIndex = 10;
            this.departureLabel.Text = "Departure";
            // 
            // arrivalLabel
            // 
            this.arrivalLabel.AutoSize = true;
            this.arrivalLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalLabel.Location = new System.Drawing.Point(9, 96);
            this.arrivalLabel.Name = "arrivalLabel";
            this.arrivalLabel.Size = new System.Drawing.Size(41, 15);
            this.arrivalLabel.TabIndex = 11;
            this.arrivalLabel.Text = "Arrival";
            // 
            // willDoButton
            // 
            this.willDoButton.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.willDoButton.Location = new System.Drawing.Point(12, 326);
            this.willDoButton.Name = "willDoButton";
            this.willDoButton.Size = new System.Drawing.Size(224, 104);
            this.willDoButton.TabIndex = 12;
            this.willDoButton.Text = "Will do!";
            this.willDoButton.UseVisualStyleBackColor = true;
            this.willDoButton.Click += new System.EventHandler(this.WillDoButton_Click);
            // 
            // departureDate
            // 
            this.departureDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDate.Location = new System.Drawing.Point(12, 60);
            this.departureDate.Name = "departureDate";
            this.departureDate.Size = new System.Drawing.Size(200, 21);
            this.departureDate.TabIndex = 15;
            this.departureDate.Value = new System.DateTime(2018, 9, 28, 15, 49, 0, 0);
            // 
            // arrivalDate
            // 
            this.arrivalDate.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDate.Location = new System.Drawing.Point(12, 138);
            this.arrivalDate.Name = "arrivalDate";
            this.arrivalDate.Size = new System.Drawing.Size(200, 21);
            this.arrivalDate.TabIndex = 16;
            // 
            // arrivalLocation
            // 
            this.arrivalLocation.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalLocation.Location = new System.Drawing.Point(12, 112);
            this.arrivalLocation.Name = "arrivalLocation";
            this.arrivalLocation.Size = new System.Drawing.Size(100, 21);
            this.arrivalLocation.TabIndex = 3;
            this.arrivalLocation.Text = "Locatie";
            // 
            // sendViaGmailCheckBox
            // 
            this.sendViaGmailCheckBox.AutoSize = true;
            this.sendViaGmailCheckBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendViaGmailCheckBox.Location = new System.Drawing.Point(12, 194);
            this.sendViaGmailCheckBox.Name = "sendViaGmailCheckBox";
            this.sendViaGmailCheckBox.Size = new System.Drawing.Size(186, 19);
            this.sendViaGmailCheckBox.TabIndex = 17;
            this.sendViaGmailCheckBox.Text = "Create text file and send via gmail";
            this.sendViaGmailCheckBox.UseVisualStyleBackColor = true;
            this.sendViaGmailCheckBox.CheckedChanged += new System.EventHandler(this.SendViaGmailCheckBox_CheckedChanged);
            // 
            // gmailFromTextBox
            // 
            this.gmailFromTextBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmailFromTextBox.Location = new System.Drawing.Point(12, 217);
            this.gmailFromTextBox.Name = "gmailFromTextBox";
            this.gmailFromTextBox.Size = new System.Drawing.Size(100, 21);
            this.gmailFromTextBox.TabIndex = 18;
            this.gmailFromTextBox.Text = "From (gmail)";
            // 
            // gmailToTextBox
            // 
            this.gmailToTextBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmailToTextBox.Location = new System.Drawing.Point(136, 217);
            this.gmailToTextBox.Name = "gmailToTextBox";
            this.gmailToTextBox.Size = new System.Drawing.Size(100, 21);
            this.gmailToTextBox.TabIndex = 19;
            this.gmailToTextBox.Text = "Send to";
            // 
            // gmailPasswordTextBox
            // 
            this.gmailPasswordTextBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gmailPasswordTextBox.Location = new System.Drawing.Point(12, 243);
            this.gmailPasswordTextBox.Name = "gmailPasswordTextBox";
            this.gmailPasswordTextBox.Size = new System.Drawing.Size(100, 21);
            this.gmailPasswordTextBox.TabIndex = 20;
            this.gmailPasswordTextBox.Text = "Password";
            // 
            // attachementPathTextBox
            // 
            this.attachementPathTextBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachementPathTextBox.Location = new System.Drawing.Point(136, 271);
            this.attachementPathTextBox.Name = "attachementPathTextBox";
            this.attachementPathTextBox.Size = new System.Drawing.Size(100, 21);
            this.attachementPathTextBox.TabIndex = 21;
            // 
            // attachementPathLabel
            // 
            this.attachementPathLabel.AutoSize = true;
            this.attachementPathLabel.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachementPathLabel.Location = new System.Drawing.Point(12, 278);
            this.attachementPathLabel.Name = "attachementPathLabel";
            this.attachementPathLabel.Size = new System.Drawing.Size(94, 15);
            this.attachementPathLabel.TabIndex = 22;
            this.attachementPathLabel.Text = "Attachement path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 442);
            this.Controls.Add(this.attachementPathLabel);
            this.Controls.Add(this.attachementPathTextBox);
            this.Controls.Add(this.gmailPasswordTextBox);
            this.Controls.Add(this.gmailToTextBox);
            this.Controls.Add(this.gmailFromTextBox);
            this.Controls.Add(this.sendViaGmailCheckBox);
            this.Controls.Add(this.arrivalDate);
            this.Controls.Add(this.departureDate);
            this.Controls.Add(this.willDoButton);
            this.Controls.Add(this.arrivalLabel);
            this.Controls.Add(this.departureLabel);
            this.Controls.Add(this.arrivalLocation);
            this.Controls.Add(this.departureLocation);
            this.Controls.Add(this.webBrowser1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox departureLocation;
        private System.Windows.Forms.Label departureLabel;
        private System.Windows.Forms.Label arrivalLabel;
        private System.Windows.Forms.Button willDoButton;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DateTimePicker departureDate;
        private System.Windows.Forms.DateTimePicker arrivalDate;
        private System.Windows.Forms.TextBox arrivalLocation;
        private System.Windows.Forms.CheckBox sendViaGmailCheckBox;
        private System.Windows.Forms.TextBox gmailFromTextBox;
        private System.Windows.Forms.TextBox gmailToTextBox;
        private System.Windows.Forms.TextBox gmailPasswordTextBox;
        private System.Windows.Forms.TextBox attachementPathTextBox;
        private System.Windows.Forms.Label attachementPathLabel;
    }
}

