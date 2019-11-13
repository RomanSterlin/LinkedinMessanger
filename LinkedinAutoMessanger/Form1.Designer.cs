using System.Drawing;
using System.Windows.Forms;

namespace LinkedinAutoMessanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.searchLinkInput = new System.Windows.Forms.TextBox();
            this.messageInput = new System.Windows.Forms.RichTextBox();
            this.fileNameInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            this.removeConnections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(469, 23);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pause
            // 
            this.pause.Location = new System.Drawing.Point(469, 71);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(75, 23);
            this.pause.TabIndex = 1;
            this.pause.Text = "Pause";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.Button2_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(469, 206);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 2;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Search Link";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Message";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(95, 15);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(100, 20);
            this.usernameInput.TabIndex = 13;
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(95, 54);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 14;
            // 
            // searchLinkInput
            // 
            this.searchLinkInput.Location = new System.Drawing.Point(95, 97);
            this.searchLinkInput.Name = "searchLinkInput";
            this.searchLinkInput.Size = new System.Drawing.Size(285, 20);
            this.searchLinkInput.TabIndex = 15;
            // 
            // messageInput
            // 
            this.messageInput.Location = new System.Drawing.Point(95, 168);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(186, 52);
            this.messageInput.TabIndex = 16;
            this.messageInput.Text = resources.GetString("messageInput.Text");
            // 
            // fileNameInput
            // 
            this.fileNameInput.Location = new System.Drawing.Point(95, 131);
            this.fileNameInput.Name = "fileNameInput";
            this.fileNameInput.Size = new System.Drawing.Size(100, 20);
            this.fileNameInput.TabIndex = 17;
            this.fileNameInput.Text = "Roman Sterlin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "File Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(287, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Include First Name";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(386, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "*To insert name please use the \"UserNameHere\" where ever you want to inser it";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Example : Hi UserNameHere, my name is bob...";
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.connectBtn.ForeColor = System.Drawing.Color.Black;
            this.connectBtn.Location = new System.Drawing.Point(469, 284);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(144, 23);
            this.connectBtn.TabIndex = 22;
            this.connectBtn.Text = "Send Connections";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(469, 168);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Counter";
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Location = new System.Drawing.Point(531, 168);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(0, 13);
            this.counter.TabIndex = 24;
            // 
            // removeConnections
            // 
            this.removeConnections.Location = new System.Drawing.Point(469, 326);
            this.removeConnections.Name = "removeConnections";
            this.removeConnections.Size = new System.Drawing.Size(144, 23);
            this.removeConnections.TabIndex = 25;
            this.removeConnections.Text = "Remove Connections";
            this.removeConnections.UseVisualStyleBackColor = true;
            this.removeConnections.Click += new System.EventHandler(this.RemoveConnections_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 365);
            this.Controls.Add(this.removeConnections);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fileNameInput);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.searchLinkInput);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox searchLinkInput;
        private System.Windows.Forms.RichTextBox messageInput;
        private System.Windows.Forms.TextBox fileNameInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private Button connectBtn;
        private Label label8;
        private Label counter;
        private TextBox passwordInput;
        private Button removeConnections;
    }
}

