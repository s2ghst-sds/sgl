namespace sgl
{
    partial class LandingPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            logo_lp = new PictureBox();
            lbl_lp = new Label();
            entrar_lp = new Button();
            lbl_sair_lp = new Button();
            ((System.ComponentModel.ISupportInitialize)logo_lp).BeginInit();
            SuspendLayout();
            // 
            // logo_lp
            // 
            logo_lp.Image = (Image)resources.GetObject("logo_lp.Image");
            logo_lp.Location = new Point(49, 42);
            logo_lp.Margin = new Padding(4);
            logo_lp.Name = "logo_lp";
            logo_lp.Size = new Size(208, 159);
            logo_lp.SizeMode = PictureBoxSizeMode.Zoom;
            logo_lp.TabIndex = 0;
            logo_lp.TabStop = false;
            // 
            // lbl_lp
            // 
            lbl_lp.AutoSize = true;
            lbl_lp.Font = new Font("Yu Gothic UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_lp.Location = new Point(129, 205);
            lbl_lp.Name = "lbl_lp";
            lbl_lp.Size = new Size(49, 30);
            lbl_lp.TabIndex = 1;
            lbl_lp.Text = "SGL";
            // 
            // entrar_lp
            // 
            entrar_lp.BackColor = Color.LimeGreen;
            entrar_lp.FlatAppearance.BorderColor = Color.Black;
            entrar_lp.FlatAppearance.MouseDownBackColor = Color.Green;
            entrar_lp.FlatAppearance.MouseOverBackColor = Color.Lime;
            entrar_lp.FlatStyle = FlatStyle.Flat;
            entrar_lp.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            entrar_lp.Location = new Point(77, 249);
            entrar_lp.Name = "entrar_lp";
            entrar_lp.Size = new Size(154, 40);
            entrar_lp.TabIndex = 2;
            entrar_lp.Text = "Entrar";
            entrar_lp.UseVisualStyleBackColor = false;
            entrar_lp.Click += entrar_lp_Click;
            // 
            // lbl_sair_lp
            // 
            lbl_sair_lp.BackColor = Color.DarkRed;
            lbl_sair_lp.FlatAppearance.BorderColor = Color.Black;
            lbl_sair_lp.FlatAppearance.BorderSize = 2;
            lbl_sair_lp.FlatAppearance.MouseDownBackColor = Color.DarkRed;
            lbl_sair_lp.FlatAppearance.MouseOverBackColor = Color.Red;
            lbl_sair_lp.FlatStyle = FlatStyle.Flat;
            lbl_sair_lp.Font = new Font("Yu Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_sair_lp.Location = new Point(77, 295);
            lbl_sair_lp.Name = "lbl_sair_lp";
            lbl_sair_lp.Size = new Size(154, 40);
            lbl_sair_lp.TabIndex = 3;
            lbl_sair_lp.Text = "Sair";
            lbl_sair_lp.UseVisualStyleBackColor = false;
            lbl_sair_lp.Click += lbl_sair_lp_Click;
            // 
            // LandingPage
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(309, 384);
            Controls.Add(lbl_sair_lp);
            Controls.Add(entrar_lp);
            Controls.Add(lbl_lp);
            Controls.Add(logo_lp);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "LandingPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LandingPage";
            ((System.ComponentModel.ISupportInitialize)logo_lp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox logo_lp;
        private Label lbl_lp;
        public Button entrar_lp;
        public Button lbl_sair_lp;
    }
}