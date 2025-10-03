namespace sgl
{
    partial class sglform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sglform));
            tabcontrol = new TabControl();
            tab_rotas = new TabPage();
            tab_veiculos = new TabPage();
            tab_motoristas = new TabPage();
            tab_combustivel = new TabPage();
            tab_viagem = new TabPage();
            tool_crudtools = new ToolStrip();
            tool_saveicon = new ToolStripButton();
            tool_editicon = new ToolStripButton();
            tool_searchicon = new ToolStripButton();
            tool_trashicon = new ToolStripButton();
            tool_exiticon = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStrip2 = new ToolStrip();
            toolStripButton6 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripButton8 = new ToolStripButton();
            toolStripButton9 = new ToolStripButton();
            toolStripButton10 = new ToolStripButton();
            toolStrip3 = new ToolStrip();
            toolStripButton11 = new ToolStripButton();
            toolStripButton12 = new ToolStripButton();
            toolStripButton13 = new ToolStripButton();
            toolStripButton14 = new ToolStripButton();
            toolStripButton15 = new ToolStripButton();
            toolStrip4 = new ToolStrip();
            toolStripButton16 = new ToolStripButton();
            toolStripButton17 = new ToolStripButton();
            toolStripButton18 = new ToolStripButton();
            toolStripButton19 = new ToolStripButton();
            toolStripButton20 = new ToolStripButton();
            dgv_rotas = new DataGridView();
            label1 = new Label();
            textBox1 = new TextBox();
            tabcontrol.SuspendLayout();
            tab_rotas.SuspendLayout();
            tab_veiculos.SuspendLayout();
            tab_motoristas.SuspendLayout();
            tab_combustivel.SuspendLayout();
            tab_viagem.SuspendLayout();
            tool_crudtools.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip2.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_rotas).BeginInit();
            SuspendLayout();
            // 
            // tabcontrol
            // 
            tabcontrol.Controls.Add(tab_rotas);
            tabcontrol.Controls.Add(tab_veiculos);
            tabcontrol.Controls.Add(tab_motoristas);
            tabcontrol.Controls.Add(tab_combustivel);
            tabcontrol.Controls.Add(tab_viagem);
            tabcontrol.Location = new Point(12, 12);
            tabcontrol.Name = "tabcontrol";
            tabcontrol.SelectedIndex = 0;
            tabcontrol.Size = new Size(981, 488);
            tabcontrol.TabIndex = 0;
            // 
            // tab_rotas
            // 
            tab_rotas.Controls.Add(textBox1);
            tab_rotas.Controls.Add(label1);
            tab_rotas.Controls.Add(dgv_rotas);
            tab_rotas.Controls.Add(toolStrip4);
            tab_rotas.Location = new Point(4, 28);
            tab_rotas.Name = "tab_rotas";
            tab_rotas.Padding = new Padding(3);
            tab_rotas.Size = new Size(973, 456);
            tab_rotas.TabIndex = 0;
            tab_rotas.Text = "rotas";
            tab_rotas.UseVisualStyleBackColor = true;
            // 
            // tab_veiculos
            // 
            tab_veiculos.Controls.Add(toolStrip3);
            tab_veiculos.Location = new Point(4, 28);
            tab_veiculos.Name = "tab_veiculos";
            tab_veiculos.Padding = new Padding(3);
            tab_veiculos.Size = new Size(973, 456);
            tab_veiculos.TabIndex = 1;
            tab_veiculos.Text = "veículos";
            tab_veiculos.UseVisualStyleBackColor = true;
            // 
            // tab_motoristas
            // 
            tab_motoristas.Controls.Add(toolStrip2);
            tab_motoristas.Location = new Point(4, 28);
            tab_motoristas.Name = "tab_motoristas";
            tab_motoristas.Padding = new Padding(3);
            tab_motoristas.Size = new Size(973, 456);
            tab_motoristas.TabIndex = 2;
            tab_motoristas.Text = "motoristas";
            tab_motoristas.UseVisualStyleBackColor = true;
            // 
            // tab_combustivel
            // 
            tab_combustivel.Controls.Add(toolStrip1);
            tab_combustivel.Location = new Point(4, 28);
            tab_combustivel.Name = "tab_combustivel";
            tab_combustivel.Padding = new Padding(3);
            tab_combustivel.Size = new Size(973, 456);
            tab_combustivel.TabIndex = 3;
            tab_combustivel.Text = "combustível";
            tab_combustivel.UseVisualStyleBackColor = true;
            // 
            // tab_viagem
            // 
            tab_viagem.BackColor = Color.Gainsboro;
            tab_viagem.Controls.Add(tool_crudtools);
            tab_viagem.Location = new Point(4, 28);
            tab_viagem.Name = "tab_viagem";
            tab_viagem.Padding = new Padding(3);
            tab_viagem.Size = new Size(973, 456);
            tab_viagem.TabIndex = 4;
            tab_viagem.Text = "viagem";
            // 
            // tool_crudtools
            // 
            tool_crudtools.BackColor = Color.White;
            tool_crudtools.BackgroundImageLayout = ImageLayout.None;
            tool_crudtools.Dock = DockStyle.Left;
            tool_crudtools.ImageScalingSize = new Size(30, 30);
            tool_crudtools.Items.AddRange(new ToolStripItem[] { tool_saveicon, tool_editicon, tool_searchicon, tool_trashicon, tool_exiticon });
            tool_crudtools.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            tool_crudtools.Location = new Point(3, 3);
            tool_crudtools.Name = "tool_crudtools";
            tool_crudtools.Size = new Size(35, 450);
            tool_crudtools.Stretch = true;
            tool_crudtools.TabIndex = 0;
            tool_crudtools.Text = "tool_crudtools";
            // 
            // tool_saveicon
            // 
            tool_saveicon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool_saveicon.Image = (Image)resources.GetObject("tool_saveicon.Image");
            tool_saveicon.ImageTransparentColor = SystemColors.Control;
            tool_saveicon.Name = "tool_saveicon";
            tool_saveicon.Size = new Size(32, 34);
            tool_saveicon.Text = "tool_saveicon";
            // 
            // tool_editicon
            // 
            tool_editicon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool_editicon.Image = (Image)resources.GetObject("tool_editicon.Image");
            tool_editicon.ImageTransparentColor = Color.Magenta;
            tool_editicon.Name = "tool_editicon";
            tool_editicon.Size = new Size(32, 34);
            tool_editicon.Text = "tool_editicon";
            // 
            // tool_searchicon
            // 
            tool_searchicon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool_searchicon.Image = (Image)resources.GetObject("tool_searchicon.Image");
            tool_searchicon.ImageTransparentColor = Color.Magenta;
            tool_searchicon.Name = "tool_searchicon";
            tool_searchicon.Size = new Size(32, 34);
            tool_searchicon.Text = "tool_searchicon";
            // 
            // tool_trashicon
            // 
            tool_trashicon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool_trashicon.Image = (Image)resources.GetObject("tool_trashicon.Image");
            tool_trashicon.ImageTransparentColor = Color.Magenta;
            tool_trashicon.Name = "tool_trashicon";
            tool_trashicon.Size = new Size(32, 34);
            tool_trashicon.Text = "tool_trashicon";
            // 
            // tool_exiticon
            // 
            tool_exiticon.BackColor = Color.Transparent;
            tool_exiticon.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tool_exiticon.Image = (Image)resources.GetObject("tool_exiticon.Image");
            tool_exiticon.ImageTransparentColor = Color.Magenta;
            tool_exiticon.Name = "tool_exiticon";
            tool_exiticon.Size = new Size(32, 34);
            tool_exiticon.Text = "tool_exiticon";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.ImageScalingSize = new Size(30, 30);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 });
            toolStrip1.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip1.Location = new Point(3, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(35, 450);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = SystemColors.Control;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(32, 34);
            toolStripButton1.Text = "tool_saveicon";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(32, 34);
            toolStripButton2.Text = "tool_editicon";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(32, 34);
            toolStripButton3.Text = "tool_searchicon";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(32, 34);
            toolStripButton4.Text = "tool_trashicon";
            // 
            // toolStripButton5
            // 
            toolStripButton5.BackColor = Color.Transparent;
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(32, 34);
            toolStripButton5.Text = "tool_exiticon";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = Color.Transparent;
            toolStrip2.Dock = DockStyle.Left;
            toolStrip2.ImageScalingSize = new Size(30, 30);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton6, toolStripButton7, toolStripButton8, toolStripButton9, toolStripButton10 });
            toolStrip2.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip2.Location = new Point(3, 3);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(35, 450);
            toolStrip2.Stretch = true;
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = SystemColors.Control;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(32, 34);
            toolStripButton6.Text = "tool_saveicon";
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(32, 34);
            toolStripButton7.Text = "tool_editicon";
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(32, 34);
            toolStripButton8.Text = "tool_searchicon";
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(32, 34);
            toolStripButton9.Text = "tool_trashicon";
            // 
            // toolStripButton10
            // 
            toolStripButton10.BackColor = Color.Transparent;
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(32, 34);
            toolStripButton10.Text = "tool_exiticon";
            // 
            // toolStrip3
            // 
            toolStrip3.BackColor = Color.Transparent;
            toolStrip3.Dock = DockStyle.Left;
            toolStrip3.ImageScalingSize = new Size(30, 30);
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripButton11, toolStripButton12, toolStripButton13, toolStripButton14, toolStripButton15 });
            toolStrip3.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip3.Location = new Point(3, 3);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(35, 450);
            toolStrip3.Stretch = true;
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton11
            // 
            toolStripButton11.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton11.Image = (Image)resources.GetObject("toolStripButton11.Image");
            toolStripButton11.ImageTransparentColor = SystemColors.Control;
            toolStripButton11.Name = "toolStripButton11";
            toolStripButton11.Size = new Size(32, 34);
            toolStripButton11.Text = "tool_saveicon";
            // 
            // toolStripButton12
            // 
            toolStripButton12.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton12.Image = (Image)resources.GetObject("toolStripButton12.Image");
            toolStripButton12.ImageTransparentColor = Color.Magenta;
            toolStripButton12.Name = "toolStripButton12";
            toolStripButton12.Size = new Size(32, 34);
            toolStripButton12.Text = "tool_editicon";
            // 
            // toolStripButton13
            // 
            toolStripButton13.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton13.Image = (Image)resources.GetObject("toolStripButton13.Image");
            toolStripButton13.ImageTransparentColor = Color.Magenta;
            toolStripButton13.Name = "toolStripButton13";
            toolStripButton13.Size = new Size(32, 34);
            toolStripButton13.Text = "tool_searchicon";
            // 
            // toolStripButton14
            // 
            toolStripButton14.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton14.Image = (Image)resources.GetObject("toolStripButton14.Image");
            toolStripButton14.ImageTransparentColor = Color.Magenta;
            toolStripButton14.Name = "toolStripButton14";
            toolStripButton14.Size = new Size(32, 34);
            toolStripButton14.Text = "tool_trashicon";
            // 
            // toolStripButton15
            // 
            toolStripButton15.BackColor = Color.Transparent;
            toolStripButton15.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton15.Image = (Image)resources.GetObject("toolStripButton15.Image");
            toolStripButton15.ImageTransparentColor = Color.Magenta;
            toolStripButton15.Name = "toolStripButton15";
            toolStripButton15.Size = new Size(32, 34);
            toolStripButton15.Text = "tool_exiticon";
            // 
            // toolStrip4
            // 
            toolStrip4.BackColor = Color.Transparent;
            toolStrip4.Dock = DockStyle.Left;
            toolStrip4.ImageScalingSize = new Size(30, 30);
            toolStrip4.Items.AddRange(new ToolStripItem[] { toolStripButton16, toolStripButton17, toolStripButton18, toolStripButton19, toolStripButton20 });
            toolStrip4.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip4.Location = new Point(3, 3);
            toolStrip4.Name = "toolStrip4";
            toolStrip4.Size = new Size(35, 450);
            toolStrip4.Stretch = true;
            toolStrip4.TabIndex = 1;
            toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton16
            // 
            toolStripButton16.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton16.Image = (Image)resources.GetObject("toolStripButton16.Image");
            toolStripButton16.ImageTransparentColor = SystemColors.Control;
            toolStripButton16.Name = "toolStripButton16";
            toolStripButton16.Size = new Size(32, 34);
            toolStripButton16.Text = "tool_saveicon";
            // 
            // toolStripButton17
            // 
            toolStripButton17.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton17.Image = (Image)resources.GetObject("toolStripButton17.Image");
            toolStripButton17.ImageTransparentColor = Color.Magenta;
            toolStripButton17.Name = "toolStripButton17";
            toolStripButton17.Size = new Size(32, 34);
            toolStripButton17.Text = "tool_editicon";
            // 
            // toolStripButton18
            // 
            toolStripButton18.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton18.Image = (Image)resources.GetObject("toolStripButton18.Image");
            toolStripButton18.ImageTransparentColor = Color.Magenta;
            toolStripButton18.Name = "toolStripButton18";
            toolStripButton18.Size = new Size(32, 34);
            toolStripButton18.Text = "tool_searchicon";
            // 
            // toolStripButton19
            // 
            toolStripButton19.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton19.Image = (Image)resources.GetObject("toolStripButton19.Image");
            toolStripButton19.ImageTransparentColor = Color.Magenta;
            toolStripButton19.Name = "toolStripButton19";
            toolStripButton19.Size = new Size(32, 34);
            toolStripButton19.Text = "tool_trashicon";
            // 
            // toolStripButton20
            // 
            toolStripButton20.BackColor = Color.Transparent;
            toolStripButton20.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton20.Image = (Image)resources.GetObject("toolStripButton20.Image");
            toolStripButton20.ImageTransparentColor = Color.Magenta;
            toolStripButton20.Name = "toolStripButton20";
            toolStripButton20.Size = new Size(32, 34);
            toolStripButton20.Text = "tool_exiticon";
            // 
            // dgv_rotas
            // 
            dgv_rotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_rotas.Location = new Point(551, 6);
            dgv_rotas.Name = "dgv_rotas";
            dgv_rotas.Size = new Size(416, 444);
            dgv_rotas.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 39);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(71, 61);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 26);
            textBox1.TabIndex = 4;
            // 
            // sglform
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 512);
            Controls.Add(tabcontrol);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "sglform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "sgl - sistema de gerenciamento de logística";
            TransparencyKey = Color.Transparent;
            tabcontrol.ResumeLayout(false);
            tab_rotas.ResumeLayout(false);
            tab_rotas.PerformLayout();
            tab_veiculos.ResumeLayout(false);
            tab_veiculos.PerformLayout();
            tab_motoristas.ResumeLayout(false);
            tab_motoristas.PerformLayout();
            tab_combustivel.ResumeLayout(false);
            tab_combustivel.PerformLayout();
            tab_viagem.ResumeLayout(false);
            tab_viagem.PerformLayout();
            tool_crudtools.ResumeLayout(false);
            tool_crudtools.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStrip4.ResumeLayout(false);
            toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_rotas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabcontrol;
        private TabPage tab_rotas;
        private TabPage tab_veiculos;
        private TabPage tab_motoristas;
        private TabPage tab_combustivel;
        private TabPage tab_viagem;
        private ToolStripButton tool_saveicon;
        private ToolStripButton tool_editicon;
        private ToolStripButton tool_searchicon;
        private ToolStripButton tool_trashicon;
        private ToolStripButton tool_exiticon;
        public ToolStrip tool_crudtools;
        private DataGridView dgv_rotas;
        public ToolStrip toolStrip4;
        private ToolStripButton toolStripButton16;
        private ToolStripButton toolStripButton17;
        private ToolStripButton toolStripButton18;
        private ToolStripButton toolStripButton19;
        private ToolStripButton toolStripButton20;
        public ToolStrip toolStrip3;
        private ToolStripButton toolStripButton11;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton13;
        private ToolStripButton toolStripButton14;
        private ToolStripButton toolStripButton15;
        public ToolStrip toolStrip2;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripButton toolStripButton10;
        public ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private Label label1;
        public TextBox textBox1;
    }
}
