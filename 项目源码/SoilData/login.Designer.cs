namespace SoilData
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.ID_box = new System.Windows.Forms.TextBox();
            this.key_box = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.myMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID_box
            // 
            this.ID_box.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ID_box.Location = new System.Drawing.Point(77, 65);
            this.ID_box.Name = "ID_box";
            this.ID_box.Size = new System.Drawing.Size(130, 30);
            this.ID_box.TabIndex = 0;
            this.ID_box.TabStop = false;
            this.ID_box.Text = "用户名";
            // 
            // key_box
            // 
            this.key_box.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.key_box.Location = new System.Drawing.Point(77, 131);
            this.key_box.Name = "key_box";
            this.key_box.Size = new System.Drawing.Size(130, 30);
            this.key_box.TabIndex = 1;
            this.key_box.TabStop = false;
            this.key_box.Text = "密码";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(179, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "注册";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(29, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.myMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "田园系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // myMenu
            // 
            this.myMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.myMenu.Name = "myMenu";
            this.myMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(295, 281);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.key_box);
            this.Controls.Add(this.ID_box);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.myMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        private void Key_box_GotFocus(object sender, System.EventArgs e)
        {
            this.key_box.Text = null;
            this.key_box.PasswordChar = '*';
        }

        private void ID_box_GotFocus(object sender, System.EventArgs e)
        {
            this.ID_box.Text = null;
        }

        #endregion

        private System.Windows.Forms.TextBox ID_box;
        private System.Windows.Forms.TextBox key_box;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip myMenu;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

