﻿namespace SoilData.user_form
{
    partial class ChangeXinXi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeXinXi));
            this.where_box = new System.Windows.Forms.TextBox();
            this.Number_box = new System.Windows.Forms.TextBox();
            this.UserName_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // where_box
            // 
            this.where_box.Font = new System.Drawing.Font("楷体", 15F);
            this.where_box.Location = new System.Drawing.Point(181, 187);
            this.where_box.Name = "where_box";
            this.where_box.Size = new System.Drawing.Size(100, 30);
            this.where_box.TabIndex = 28;
            this.where_box.Text = "所在市区";
            // 
            // Number_box
            // 
            this.Number_box.Font = new System.Drawing.Font("楷体", 15F);
            this.Number_box.Location = new System.Drawing.Point(181, 113);
            this.Number_box.Name = "Number_box";
            this.Number_box.Size = new System.Drawing.Size(100, 30);
            this.Number_box.TabIndex = 27;
            this.Number_box.Text = "联系电话";
            // 
            // UserName_box
            // 
            this.UserName_box.Font = new System.Drawing.Font("楷体", 15F);
            this.UserName_box.Location = new System.Drawing.Point(181, 43);
            this.UserName_box.Name = "UserName_box";
            this.UserName_box.Size = new System.Drawing.Size(100, 30);
            this.UserName_box.TabIndex = 29;
            this.UserName_box.Text = "用户名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 15F);
            this.label1.Location = new System.Drawing.Point(52, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 15F);
            this.label2.Location = new System.Drawing.Point(42, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "联系电话：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 15F);
            this.label3.Location = new System.Drawing.Point(52, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "所在市区：";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("华文中宋", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(217, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeXinXi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(352, 329);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.where_box);
            this.Controls.Add(this.Number_box);
            this.Controls.Add(this.UserName_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeXinXi";
            this.Load += new System.EventHandler(this.ChangeXinXi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Where_box_GotFocus(object sender, System.EventArgs e)
        {
            this.where_box.Text = null;
        }

        private void Number_box_GotFocus(object sender, System.EventArgs e)
        {
            this.Number_box.Text = null;
        }


        #endregion

        private System.Windows.Forms.TextBox where_box;
        private System.Windows.Forms.TextBox Number_box;
        private System.Windows.Forms.TextBox UserName_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}