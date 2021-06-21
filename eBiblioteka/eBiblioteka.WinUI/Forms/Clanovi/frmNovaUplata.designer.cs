
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmNovaUplata
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
            this.labelClan = new System.Windows.Forms.Label();
            this.cmbClanovi = new System.Windows.Forms.ComboBox();
            this.cmbTipUplate = new System.Windows.Forms.ComboBox();
            this.labelTipUplate = new System.Windows.Forms.Label();
            this.labelDatumUplate = new System.Windows.Forms.Label();
            this.dtpDatumUplate = new System.Windows.Forms.DateTimePicker();
            this.labelznos = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.txtIznos = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.txtIznos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelClan
            // 
            this.labelClan.AutoSize = true;
            this.labelClan.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelClan.Location = new System.Drawing.Point(68, 92);
            this.labelClan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelClan.Name = "labelClan";
            this.labelClan.Size = new System.Drawing.Size(35, 17);
            this.labelClan.TabIndex = 0;
            this.labelClan.Text = "Član";
            // 
            // cmbClanovi
            // 
            this.cmbClanovi.FormattingEnabled = true;
            this.cmbClanovi.Location = new System.Drawing.Point(70, 111);
            this.cmbClanovi.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClanovi.Name = "cmbClanovi";
            this.cmbClanovi.Size = new System.Drawing.Size(164, 21);
            this.cmbClanovi.TabIndex = 1;
            this.cmbClanovi.Validating += new System.ComponentModel.CancelEventHandler(this.cmbClanovi_Validating);
            // 
            // cmbTipUplate
            // 
            this.cmbTipUplate.FormattingEnabled = true;
            this.cmbTipUplate.Location = new System.Drawing.Point(70, 167);
            this.cmbTipUplate.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTipUplate.Name = "cmbTipUplate";
            this.cmbTipUplate.Size = new System.Drawing.Size(164, 21);
            this.cmbTipUplate.TabIndex = 3;
            this.cmbTipUplate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTipUplate_Validating);
            // 
            // labelTipUplate
            // 
            this.labelTipUplate.AutoSize = true;
            this.labelTipUplate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTipUplate.Location = new System.Drawing.Point(68, 147);
            this.labelTipUplate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTipUplate.Name = "labelTipUplate";
            this.labelTipUplate.Size = new System.Drawing.Size(66, 17);
            this.labelTipUplate.TabIndex = 2;
            this.labelTipUplate.Text = "Tip uplate";
            // 
            // labelDatumUplate
            // 
            this.labelDatumUplate.AutoSize = true;
            this.labelDatumUplate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDatumUplate.Location = new System.Drawing.Point(274, 91);
            this.labelDatumUplate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDatumUplate.Name = "labelDatumUplate";
            this.labelDatumUplate.Size = new System.Drawing.Size(90, 17);
            this.labelDatumUplate.TabIndex = 4;
            this.labelDatumUplate.Text = "Datum uplate";
            // 
            // dtpDatumUplate
            // 
            this.dtpDatumUplate.Location = new System.Drawing.Point(276, 111);
            this.dtpDatumUplate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDatumUplate.Name = "dtpDatumUplate";
            this.dtpDatumUplate.Size = new System.Drawing.Size(164, 20);
            this.dtpDatumUplate.TabIndex = 5;
            // 
            // labelznos
            // 
            this.labelznos.AutoSize = true;
            this.labelznos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelznos.Location = new System.Drawing.Point(274, 149);
            this.labelznos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelznos.Name = "labelznos";
            this.labelznos.Size = new System.Drawing.Size(36, 17);
            this.labelznos.TabIndex = 6;
            this.labelznos.Text = "Iznos";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSpremi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSpremi.Location = new System.Drawing.Point(183, 223);
            this.btnSpremi.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(163, 36);
            this.btnSpremi.TabIndex = 8;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // txtIznos
            // 
            this.txtIznos.DecimalPlaces = 2;
            this.txtIznos.Location = new System.Drawing.Point(276, 168);
            this.txtIznos.Margin = new System.Windows.Forms.Padding(2);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(164, 20);
            this.txtIznos.TabIndex = 9;
            this.txtIznos.Validating += new System.ComponentModel.CancelEventHandler(this.txtIznos_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 57);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::eBiblioteka.WinUI.Properties.Resources.whitelogo;
            this.pictureBox1.Location = new System.Drawing.Point(125, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(9, 244);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SeaGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(510, 57);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 244);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SeaGreen;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(9, 293);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(501, 8);
            this.panel4.TabIndex = 4;
            // 
            // frmNovaUplata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(518, 301);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbTipUplate);
            this.Controls.Add(this.labelClan);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.dtpDatumUplate);
            this.Controls.Add(this.cmbClanovi);
            this.Controls.Add(this.labelDatumUplate);
            this.Controls.Add(this.labelTipUplate);
            this.Controls.Add(this.labelznos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNovaUplata";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Uplata";
            this.Load += new System.EventHandler(this.frmNovaUplata_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtIznos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelClan;
        private System.Windows.Forms.ComboBox cmbClanovi;
        private System.Windows.Forms.ComboBox cmbTipUplate;
        private System.Windows.Forms.Label labelTipUplate;
        private System.Windows.Forms.Label labelDatumUplate;
        private System.Windows.Forms.DateTimePicker dtpDatumUplate;
        private System.Windows.Forms.Label labelznos;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.NumericUpDown txtIznos;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
    }
}