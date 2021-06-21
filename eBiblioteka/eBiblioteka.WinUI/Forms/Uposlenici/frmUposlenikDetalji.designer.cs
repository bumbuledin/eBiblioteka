
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmUposlenikDetalji
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
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.labelIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDatumZaposlenja = new System.Windows.Forms.Label();
            this.dtpDatumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumZaposlenja = new System.Windows.Forms.DateTimePicker();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.labelKorisnickoIme = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.labelTelefon = new System.Windows.Forms.Label();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.labelAdresa = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAktivanNe = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.rbAktivanDa = new System.Windows.Forms.RadioButton();
            this.cmbGrad = new System.Windows.Forms.ComboBox();
            this.labelGrad = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbUloge = new System.Windows.Forms.GroupBox();
            this.clbUloge = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbLozinka = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.labelLozinkaPotvrda = new System.Windows.Forms.Label();
            this.labelLozinka = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbUloge.SuspendLayout();
            this.gbLozinka.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDodajSliku.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodajSliku.Location = new System.Drawing.Point(262, 304);
            this.btnDodajSliku.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(190, 32);
            this.btnDodajSliku.TabIndex = 1;
            this.btnDodajSliku.Text = "Dodaj novu sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // labelIme
            // 
            this.labelIme.AutoSize = true;
            this.labelIme.Location = new System.Drawing.Point(18, 67);
            this.labelIme.Name = "labelIme";
            this.labelIme.Size = new System.Drawing.Size(32, 17);
            this.labelIme.TabIndex = 2;
            this.labelIme.Text = "Ime";
            // 
            // txtIme
            // 
            this.txtIme.BackColor = System.Drawing.Color.White;
            this.txtIme.Location = new System.Drawing.Point(21, 89);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(177, 23);
            this.txtIme.TabIndex = 3;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(21, 146);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(177, 23);
            this.txtPrezime.TabIndex = 5;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // labelPrezime
            // 
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.Location = new System.Drawing.Point(18, 124);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(58, 17);
            this.labelPrezime.TabIndex = 4;
            this.labelPrezime.Text = "Prezime";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Datum rođenja";
            // 
            // labelDatumZaposlenja
            // 
            this.labelDatumZaposlenja.AutoSize = true;
            this.labelDatumZaposlenja.Location = new System.Drawing.Point(18, 240);
            this.labelDatumZaposlenja.Name = "labelDatumZaposlenja";
            this.labelDatumZaposlenja.Size = new System.Drawing.Size(126, 17);
            this.labelDatumZaposlenja.TabIndex = 8;
            this.labelDatumZaposlenja.Text = "Datum zaposlenja";
            // 
            // dtpDatumRodjenja
            // 
            this.dtpDatumRodjenja.Location = new System.Drawing.Point(21, 206);
            this.dtpDatumRodjenja.Name = "dtpDatumRodjenja";
            this.dtpDatumRodjenja.Size = new System.Drawing.Size(177, 23);
            this.dtpDatumRodjenja.TabIndex = 10;
            // 
            // dtpDatumZaposlenja
            // 
            this.dtpDatumZaposlenja.Location = new System.Drawing.Point(21, 262);
            this.dtpDatumZaposlenja.Name = "dtpDatumZaposlenja";
            this.dtpDatumZaposlenja.Size = new System.Drawing.Size(177, 23);
            this.dtpDatumZaposlenja.TabIndex = 11;
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(21, 319);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(177, 23);
            this.txtKorisnickoIme.TabIndex = 15;
            this.txtKorisnickoIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtKorisnickoIme_Validating);
            // 
            // labelKorisnickoIme
            // 
            this.labelKorisnickoIme.AutoSize = true;
            this.labelKorisnickoIme.Location = new System.Drawing.Point(18, 297);
            this.labelKorisnickoIme.Name = "labelKorisnickoIme";
            this.labelKorisnickoIme.Size = new System.Drawing.Size(100, 17);
            this.labelKorisnickoIme.TabIndex = 14;
            this.labelKorisnickoIme.Text = "Korisničko ime";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(234, 89);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(177, 23);
            this.txtTelefon.TabIndex = 13;
            this.txtTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefon_Validating);
            // 
            // labelTelefon
            // 
            this.labelTelefon.AutoSize = true;
            this.labelTelefon.Location = new System.Drawing.Point(231, 67);
            this.labelTelefon.Name = "labelTelefon";
            this.labelTelefon.Size = new System.Drawing.Size(53, 17);
            this.labelTelefon.TabIndex = 12;
            this.labelTelefon.Text = "Telefon";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(234, 207);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(177, 23);
            this.txtAdresa.TabIndex = 19;
            this.txtAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdresa_Validating);
            // 
            // labelAdresa
            // 
            this.labelAdresa.AutoSize = true;
            this.labelAdresa.Location = new System.Drawing.Point(231, 185);
            this.labelAdresa.Name = "labelAdresa";
            this.labelAdresa.Size = new System.Drawing.Size(52, 17);
            this.labelAdresa.TabIndex = 18;
            this.labelAdresa.Text = "Adresa";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(234, 145);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(177, 23);
            this.txtEmail.TabIndex = 17;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(231, 123);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(43, 17);
            this.labelEmail.TabIndex = 16;
            this.labelEmail.Text = "Email";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rbAktivanNe);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rbAktivanDa);
            this.groupBox1.Controls.Add(this.cmbGrad);
            this.groupBox1.Controls.Add(this.labelGrad);
            this.groupBox1.Controls.Add(this.txtAdresa);
            this.groupBox1.Controls.Add(this.labelIme);
            this.groupBox1.Controls.Add(this.labelAdresa);
            this.groupBox1.Controls.Add(this.txtIme);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.labelPrezime);
            this.groupBox1.Controls.Add(this.labelEmail);
            this.groupBox1.Controls.Add(this.txtPrezime);
            this.groupBox1.Controls.Add(this.txtKorisnickoIme);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelKorisnickoIme);
            this.groupBox1.Controls.Add(this.labelDatumZaposlenja);
            this.groupBox1.Controls.Add(this.txtTelefon);
            this.groupBox1.Controls.Add(this.dtpDatumRodjenja);
            this.groupBox1.Controls.Add(this.labelTelefon);
            this.groupBox1.Controls.Add(this.dtpDatumZaposlenja);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(531, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 389);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji";
            // 
            // rbAktivanNe
            // 
            this.rbAktivanNe.AutoSize = true;
            this.rbAktivanNe.Location = new System.Drawing.Point(358, 300);
            this.rbAktivanNe.Name = "rbAktivanNe";
            this.rbAktivanNe.Size = new System.Drawing.Size(44, 21);
            this.rbAktivanNe.TabIndex = 24;
            this.rbAktivanNe.TabStop = true;
            this.rbAktivanNe.Text = "Ne";
            this.rbAktivanNe.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Aktivan";
            // 
            // rbAktivanDa
            // 
            this.rbAktivanDa.AutoSize = true;
            this.rbAktivanDa.Location = new System.Drawing.Point(307, 300);
            this.rbAktivanDa.Name = "rbAktivanDa";
            this.rbAktivanDa.Size = new System.Drawing.Size(45, 21);
            this.rbAktivanDa.TabIndex = 22;
            this.rbAktivanDa.TabStop = true;
            this.rbAktivanDa.Text = "Da";
            this.rbAktivanDa.UseVisualStyleBackColor = true;
            // 
            // cmbGrad
            // 
            this.cmbGrad.FormattingEnabled = true;
            this.cmbGrad.Location = new System.Drawing.Point(234, 260);
            this.cmbGrad.Name = "cmbGrad";
            this.cmbGrad.Size = new System.Drawing.Size(177, 25);
            this.cmbGrad.TabIndex = 21;
            // 
            // labelGrad
            // 
            this.labelGrad.AutoSize = true;
            this.labelGrad.Location = new System.Drawing.Point(231, 238);
            this.labelGrad.Name = "labelGrad";
            this.labelGrad.Size = new System.Drawing.Size(41, 17);
            this.labelGrad.TabIndex = 20;
            this.labelGrad.Text = "Grad";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSpremi.Location = new System.Drawing.Point(797, 599);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(176, 44);
            this.btnSpremi.TabIndex = 25;
            this.btnSpremi.Text = "Spremi promjene";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(260, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Slika";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 28;
            this.btnBack.Location = new System.Drawing.Point(13, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 31);
            this.btnBack.TabIndex = 21;
            this.btnBack.Text = "Nazad";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pbSlika
            // 
            this.pbSlika.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(263, 106);
            this.pbSlika.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Padding = new System.Windows.Forms.Padding(5);
            this.pbSlika.Size = new System.Drawing.Size(189, 189);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 0;
            this.pbSlika.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // gbUloge
            // 
            this.gbUloge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbUloge.Controls.Add(this.clbUloge);
            this.gbUloge.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbUloge.Location = new System.Drawing.Point(264, 356);
            this.gbUloge.Name = "gbUloge";
            this.gbUloge.Size = new System.Drawing.Size(188, 119);
            this.gbUloge.TabIndex = 27;
            this.gbUloge.TabStop = false;
            this.gbUloge.Text = "Uloge";
            // 
            // clbUloge
            // 
            this.clbUloge.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clbUloge.FormattingEnabled = true;
            this.clbUloge.Location = new System.Drawing.Point(20, 31);
            this.clbUloge.Name = "clbUloge";
            this.clbUloge.Size = new System.Drawing.Size(142, 58);
            this.clbUloge.TabIndex = 0;
            this.clbUloge.Validating += new System.ComponentModel.CancelEventHandler(this.clbUloge_Validating);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // gbLozinka
            // 
            this.gbLozinka.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbLozinka.Controls.Add(this.txtPassword);
            this.gbLozinka.Controls.Add(this.txtPasswordConfirm);
            this.gbLozinka.Controls.Add(this.labelLozinkaPotvrda);
            this.gbLozinka.Controls.Add(this.labelLozinka);
            this.gbLozinka.Location = new System.Drawing.Point(531, 481);
            this.gbLozinka.Name = "gbLozinka";
            this.gbLozinka.Size = new System.Drawing.Size(442, 95);
            this.gbLozinka.TabIndex = 35;
            this.gbLozinka.TabStop = false;
            this.gbLozinka.Text = "Nova Lozinka";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(21, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(177, 22);
            this.txtPassword.TabIndex = 31;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Location = new System.Drawing.Point(234, 50);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.PasswordChar = '*';
            this.txtPasswordConfirm.Size = new System.Drawing.Size(177, 22);
            this.txtPasswordConfirm.TabIndex = 33;
            this.txtPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordConfirm_Validating);
            // 
            // labelLozinkaPotvrda
            // 
            this.labelLozinkaPotvrda.AutoSize = true;
            this.labelLozinkaPotvrda.Location = new System.Drawing.Point(231, 29);
            this.labelLozinkaPotvrda.Name = "labelLozinkaPotvrda";
            this.labelLozinkaPotvrda.Size = new System.Drawing.Size(102, 17);
            this.labelLozinkaPotvrda.TabIndex = 32;
            this.labelLozinkaPotvrda.Text = "Lozinka Potvrda";
            // 
            // labelLozinka
            // 
            this.labelLozinka.AutoSize = true;
            this.labelLozinka.Location = new System.Drawing.Point(18, 25);
            this.labelLozinka.Name = "labelLozinka";
            this.labelLozinka.Size = new System.Drawing.Size(51, 17);
            this.labelLozinka.TabIndex = 30;
            this.labelLozinka.Text = "Lozinka";
            // 
            // frmUposlenikDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.gbLozinka);
            this.Controls.Add(this.gbUloge);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.pbSlika);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUposlenikDetalji";
            this.Text = "Detalji uposlenika";
            this.Load += new System.EventHandler(this.frmClanDetalji_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbUloge.ResumeLayout(false);
            this.gbLozinka.ResumeLayout(false);
            this.gbLozinka.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDatumZaposlenja;
        private System.Windows.Forms.DateTimePicker dtpDatumRodjenja;
        private System.Windows.Forms.DateTimePicker dtpDatumZaposlenja;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label labelKorisnickoIme;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.Label labelAdresa;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAktivanNe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbAktivanDa;
        private System.Windows.Forms.ComboBox cmbGrad;
        private System.Windows.Forms.Label labelGrad;
        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox gbUloge;
        private System.Windows.Forms.CheckedListBox clbUloge;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox gbLozinka;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordConfirm;
        private System.Windows.Forms.Label labelLozinkaPotvrda;
        private System.Windows.Forms.Label labelLozinka;
    }
}