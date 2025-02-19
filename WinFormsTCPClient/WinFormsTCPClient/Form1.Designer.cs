namespace WinFormsTCPClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.robotPanel = new System.Windows.Forms.Panel();
            this.robotLabel = new System.Windows.Forms.Label();
            this.lstatPanel = new System.Windows.Forms.Panel();
            this.lstatLabel = new System.Windows.Forms.Label();
            this.cranePanel = new System.Windows.Forms.Panel();
            this.craneLabel = new System.Windows.Forms.Label();
            this.mcentPanel = new System.Windows.Forms.Panel();
            this.mcentLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.robotPercentageTextBox = new System.Windows.Forms.TextBox();
            this.lstatPercentageTextBox = new System.Windows.Forms.TextBox();
            this.cranePercentageTextBox = new System.Windows.Forms.TextBox();
            this.mcentPercentageTextBox = new System.Windows.Forms.TextBox();
            this.robotPanel.SuspendLayout();
            this.lstatPanel.SuspendLayout();
            this.cranePanel.SuspendLayout();
            this.mcentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(27, 30);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(131, 30);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LogListBox
            // 
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(27, 59);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(392, 368);
            this.LogListBox.TabIndex = 2;
            // 
            // robotPanel
            // 
            this.robotPanel.BackColor = System.Drawing.Color.Gray;
            this.robotPanel.Controls.Add(this.robotLabel);
            this.robotPanel.Location = new System.Drawing.Point(445, 59);
            this.robotPanel.Name = "robotPanel";
            this.robotPanel.Size = new System.Drawing.Size(100, 100);
            this.robotPanel.TabIndex = 3;
            // 
            // robotLabel
            // 
            this.robotLabel.AutoSize = true;
            this.robotLabel.Location = new System.Drawing.Point(35, 40);
            this.robotLabel.Name = "robotLabel";
            this.robotLabel.Size = new System.Drawing.Size(36, 13);
            this.robotLabel.TabIndex = 0;
            this.robotLabel.Text = "Robot";
            // 
            // lstatPanel
            // 
            this.lstatPanel.BackColor = System.Drawing.Color.Gray;
            this.lstatPanel.Controls.Add(this.lstatLabel);
            this.lstatPanel.Location = new System.Drawing.Point(564, 59);
            this.lstatPanel.Name = "lstatPanel";
            this.lstatPanel.Size = new System.Drawing.Size(100, 100);
            this.lstatPanel.TabIndex = 4;
            // 
            // lstatLabel
            // 
            this.lstatLabel.AutoSize = true;
            this.lstatLabel.Location = new System.Drawing.Point(35, 40);
            this.lstatLabel.Name = "lstatLabel";
            this.lstatLabel.Size = new System.Drawing.Size(30, 13);
            this.lstatLabel.TabIndex = 0;
            this.lstatLabel.Text = "Lstat";
            // 
            // cranePanel
            // 
            this.cranePanel.BackColor = System.Drawing.Color.Gray;
            this.cranePanel.Controls.Add(this.craneLabel);
            this.cranePanel.Location = new System.Drawing.Point(674, 59);
            this.cranePanel.Name = "cranePanel";
            this.cranePanel.Size = new System.Drawing.Size(100, 100);
            this.cranePanel.TabIndex = 5;
            // 
            // craneLabel
            // 
            this.craneLabel.AutoSize = true;
            this.craneLabel.Location = new System.Drawing.Point(35, 40);
            this.craneLabel.Name = "craneLabel";
            this.craneLabel.Size = new System.Drawing.Size(35, 13);
            this.craneLabel.TabIndex = 0;
            this.craneLabel.Text = "Crane";
            // 
            // mcentPanel
            // 
            this.mcentPanel.BackColor = System.Drawing.Color.Gray;
            this.mcentPanel.Controls.Add(this.mcentLabel);
            this.mcentPanel.Location = new System.Drawing.Point(788, 59);
            this.mcentPanel.Name = "mcentPanel";
            this.mcentPanel.Size = new System.Drawing.Size(100, 100);
            this.mcentPanel.TabIndex = 6;
            // 
            // mcentLabel
            // 
            this.mcentLabel.AutoSize = true;
            this.mcentLabel.Location = new System.Drawing.Point(35, 40);
            this.mcentLabel.Name = "mcentLabel";
            this.mcentLabel.Size = new System.Drawing.Size(37, 13);
            this.mcentLabel.TabIndex = 0;
            this.mcentLabel.Text = "Mcent";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(585, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 32);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Active machine";
            // 
            // robotPercentageTextBox
            // 
            this.robotPercentageTextBox.Location = new System.Drawing.Point(445, 170);
            this.robotPercentageTextBox.Name = "robotPercentageTextBox";
            this.robotPercentageTextBox.Size = new System.Drawing.Size(100, 20);
            this.robotPercentageTextBox.TabIndex = 11;
            // 
            // lstatPercentageTextBox
            // 
            this.lstatPercentageTextBox.Location = new System.Drawing.Point(567, 170);
            this.lstatPercentageTextBox.Name = "lstatPercentageTextBox";
            this.lstatPercentageTextBox.Size = new System.Drawing.Size(97, 20);
            this.lstatPercentageTextBox.TabIndex = 12;
            // 
            // cranePercentageTextBox
            // 
            this.cranePercentageTextBox.Location = new System.Drawing.Point(673, 170);
            this.cranePercentageTextBox.Name = "cranePercentageTextBox";
            this.cranePercentageTextBox.Size = new System.Drawing.Size(100, 20);
            this.cranePercentageTextBox.TabIndex = 13;
            // 
            // mcentPercentageTextBox
            // 
            this.mcentPercentageTextBox.Location = new System.Drawing.Point(786, 170);
            this.mcentPercentageTextBox.Name = "mcentPercentageTextBox";
            this.mcentPercentageTextBox.Size = new System.Drawing.Size(100, 20);
            this.mcentPercentageTextBox.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.mcentPercentageTextBox);
            this.Controls.Add(this.cranePercentageTextBox);
            this.Controls.Add(this.lstatPercentageTextBox);
            this.Controls.Add(this.robotPercentageTextBox);
            this.Controls.Add(this.mcentPanel);
            this.Controls.Add(this.cranePanel);
            this.Controls.Add(this.lstatPanel);
            this.Controls.Add(this.robotPanel);
            this.Controls.Add(this.LogListBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.robotPanel.ResumeLayout(false);
            this.robotPanel.PerformLayout();
            this.lstatPanel.ResumeLayout(false);
            this.lstatPanel.PerformLayout();
            this.cranePanel.ResumeLayout(false);
            this.cranePanel.PerformLayout();
            this.mcentPanel.ResumeLayout(false);
            this.mcentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Panel robotPanel;
        private System.Windows.Forms.Panel lstatPanel;
        private System.Windows.Forms.Panel cranePanel;
        private System.Windows.Forms.Panel mcentPanel;
        private System.Windows.Forms.Label robotLabel;
        private System.Windows.Forms.Label lstatLabel;
        private System.Windows.Forms.Label craneLabel;
        private System.Windows.Forms.Label mcentLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox robotPercentageTextBox;
        private System.Windows.Forms.TextBox lstatPercentageTextBox;
        private System.Windows.Forms.TextBox cranePercentageTextBox;
        private System.Windows.Forms.TextBox mcentPercentageTextBox;
    }
}