namespace FuturesInfoFromSina
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._priceSale = new System.Windows.Forms.Label();
            this._volumeSale = new System.Windows.Forms.Label();
            this._panelSetting = new System.Windows.Forms.FlowLayoutPanel();
            this._textboxStock = new System.Windows.Forms.TextBox();
            this._name = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.期货代码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem界面 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.整数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单精度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双精度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._priceBuy = new System.Windows.Forms.Label();
            this._volumeBuy = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this._panelSetting.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this._priceSale);
            this.flowLayoutPanel1.Controls.Add(this._volumeSale);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(50, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 20);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this.flowLayoutPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // _priceSale
            // 
            this._priceSale.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._priceSale.Location = new System.Drawing.Point(3, 3);
            this._priceSale.Margin = new System.Windows.Forms.Padding(3);
            this._priceSale.Name = "_priceSale";
            this._priceSale.Size = new System.Drawing.Size(80, 12);
            this._priceSale.TabIndex = 0;
            this._priceSale.Text = "3800";
            this._priceSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._priceSale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this._priceSale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this._priceSale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // _volumeSale
            // 
            this._volumeSale.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._volumeSale.Location = new System.Drawing.Point(89, 3);
            this._volumeSale.Margin = new System.Windows.Forms.Padding(3);
            this._volumeSale.Name = "_volumeSale";
            this._volumeSale.Size = new System.Drawing.Size(65, 12);
            this._volumeSale.TabIndex = 0;
            this._volumeSale.Text = "150";
            this._volumeSale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._volumeSale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this._volumeSale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this._volumeSale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // _panelSetting
            // 
            this._panelSetting.Controls.Add(this._textboxStock);
            this._panelSetting.Location = new System.Drawing.Point(0, 0);
            this._panelSetting.Name = "_panelSetting";
            this._panelSetting.Size = new System.Drawing.Size(180, 40);
            this._panelSetting.TabIndex = 1;
            this._panelSetting.Visible = false;
            // 
            // _textboxStock
            // 
            this._textboxStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textboxStock.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._textboxStock.Location = new System.Drawing.Point(0, 0);
            this._textboxStock.Margin = new System.Windows.Forms.Padding(0);
            this._textboxStock.Name = "_textboxStock";
            this._textboxStock.Size = new System.Drawing.Size(133, 19);
            this._textboxStock.TabIndex = 0;
            this._textboxStock.KeyUp += new System.Windows.Forms.KeyEventHandler(this._textboxStock_KeyUp);
            // 
            // _name
            // 
            this._name.BackColor = System.Drawing.Color.Black;
            this._name.ForeColor = System.Drawing.Color.White;
            this._name.Location = new System.Drawing.Point(0, 0);
            this._name.Margin = new System.Windows.Forms.Padding(3);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(50, 40);
            this._name.TabIndex = 0;
            this._name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this._name.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this._name.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.期货代码ToolStripMenuItem,
            this.ToolStripMenuItem界面,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 98);
            // 
            // 期货代码ToolStripMenuItem
            // 
            this.期货代码ToolStripMenuItem.Name = "期货代码ToolStripMenuItem";
            this.期货代码ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.期货代码ToolStripMenuItem.Text = "期货代码";
            this.期货代码ToolStripMenuItem.Click += new System.EventHandler(this.期货代码ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem界面
            // 
            this.ToolStripMenuItem界面.Name = "ToolStripMenuItem界面";
            this.ToolStripMenuItem界面.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem界面.Text = "简洁版";
            this.ToolStripMenuItem界面.Click += new System.EventHandler(this.简洁版ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.整数ToolStripMenuItem,
            this.单精度ToolStripMenuItem,
            this.双精度ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem1.Text = "格式";
            // 
            // 整数ToolStripMenuItem
            // 
            this.整数ToolStripMenuItem.Name = "整数ToolStripMenuItem";
            this.整数ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.整数ToolStripMenuItem.Text = "整数";
            this.整数ToolStripMenuItem.Click += new System.EventHandler(this.整数ToolStripMenuItem_Click);
            // 
            // 单精度ToolStripMenuItem
            // 
            this.单精度ToolStripMenuItem.Name = "单精度ToolStripMenuItem";
            this.单精度ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.单精度ToolStripMenuItem.Text = "单精度";
            this.单精度ToolStripMenuItem.Click += new System.EventHandler(this.单精度ToolStripMenuItem_Click);
            // 
            // 双精度ToolStripMenuItem
            // 
            this.双精度ToolStripMenuItem.Name = "双精度ToolStripMenuItem";
            this.双精度ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.双精度ToolStripMenuItem.Text = "双精度";
            this.双精度ToolStripMenuItem.Click += new System.EventHandler(this.双精度ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._panelSetting);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this._name);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 40);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel2.Controls.Add(this._priceBuy);
            this.flowLayoutPanel2.Controls.Add(this._volumeBuy);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(50, 20);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(160, 20);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // _priceBuy
            // 
            this._priceBuy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._priceBuy.Location = new System.Drawing.Point(3, 3);
            this._priceBuy.Margin = new System.Windows.Forms.Padding(3);
            this._priceBuy.Name = "_priceBuy";
            this._priceBuy.Size = new System.Drawing.Size(80, 12);
            this._priceBuy.TabIndex = 0;
            this._priceBuy.Text = "3800";
            this._priceBuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._priceBuy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this._priceBuy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this._priceBuy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // _volumeBuy
            // 
            this._volumeBuy.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this._volumeBuy.Location = new System.Drawing.Point(89, 3);
            this._volumeBuy.Margin = new System.Windows.Forms.Padding(3);
            this._volumeBuy.Name = "_volumeBuy";
            this._volumeBuy.Size = new System.Drawing.Size(65, 12);
            this._volumeBuy.TabIndex = 0;
            this._volumeBuy.Text = "150";
            this._volumeBuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._volumeBuy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseDown);
            this._volumeBuy.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseMove);
            this._volumeBuy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StackPanel_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(210, 40);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Window_Loaded);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this._panelSetting.ResumeLayout(false);
            this._panelSetting.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.Label _priceSale;
        private System.Windows.Forms.Label _volumeSale;
        private System.Windows.Forms.FlowLayoutPanel _panelSetting;
        private System.Windows.Forms.TextBox _textboxStock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 期货代码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label _priceBuy;
        private System.Windows.Forms.Label _volumeBuy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem界面;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 整数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单精度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双精度ToolStripMenuItem;
    }
}