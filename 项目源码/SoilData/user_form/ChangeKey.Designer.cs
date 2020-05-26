namespace SoilData
{
    partial class ChangeKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeKey));
            this.button1 = new System.Windows.Forms.Button();
            this.Old_Key = new System.Windows.Forms.TextBox();
            this.New_Key = new System.Windows.Forms.TextBox();
            this.Right_Key = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("华文中宋", 15F);
            this.button1.Location = new System.Drawing.Point(43, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Old_Key
            // 
            this.Old_Key.Font = new System.Drawing.Font("楷体", 12F);
            this.Old_Key.Location = new System.Drawing.Point(137, 48);
            this.Old_Key.Name = "Old_Key";
            this.Old_Key.Size = new System.Drawing.Size(100, 26);
            this.Old_Key.TabIndex = 2;
            this.Old_Key.Text = "旧密码";
            // 
            // New_Key
            // 
            this.New_Key.Font = new System.Drawing.Font("楷体", 12F);
            this.New_Key.Location = new System.Drawing.Point(137, 109);
            this.New_Key.Name = "New_Key";
            this.New_Key.Size = new System.Drawing.Size(100, 26);
            this.New_Key.TabIndex = 3;
            this.New_Key.Text = "新密码";
            // 
            // Right_Key
            // 
            this.Right_Key.Font = new System.Drawing.Font("楷体", 12F);
            this.Right_Key.Location = new System.Drawing.Point(137, 165);
            this.Right_Key.Name = "Right_Key";
            this.Right_Key.Size = new System.Drawing.Size(100, 26);
            this.Right_Key.TabIndex = 4;
            this.Right_Key.Text = "确认密码";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Font = new System.Drawing.Font("华文中宋", 15F);
            this.button3.Location = new System.Drawing.Point(269, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChangeKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(391, 324);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Right_Key);
            this.Controls.Add(this.New_Key);
            this.Controls.Add(this.Old_Key);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private void Right_Key_GotFocus(object sender, System.EventArgs e)
        {
            Right_Key.Text = null;
            Right_Key.PasswordChar = '*';
        }

        private void New_Key_GotFocus(object sender, System.EventArgs e)
        {
            New_Key.Text = null;
            New_Key.PasswordChar = '*';
        }

        private void Old_Key_GotFocus(object sender, System.EventArgs e)
        {
            Old_Key.Text = null;
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Old_Key;
        private System.Windows.Forms.TextBox New_Key;
        private System.Windows.Forms.TextBox Right_Key;
        private System.Windows.Forms.Button button3;
    }
}