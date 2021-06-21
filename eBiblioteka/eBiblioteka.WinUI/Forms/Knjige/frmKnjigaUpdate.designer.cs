
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmKnjigaUpdate
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
            this.labelNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelUkupno = new System.Windows.Forms.Label();
            this.txtUkupnoNaStanju = new System.Windows.Forms.TextBox();
            this.labelBrojStranica = new System.Windows.Forms.Label();
            this.txtBrojStranica = new System.Windows.Forms.TextBox();
            this.labelGodinaIzdavanja = new System.Windows.Forms.Label();
            this.txtGodinaIzdavanja = new System.Windows.Forms.TextBox();
            this.labelInventarniBroj = new System.Windows.Forms.Label();
            this.txtInventarniBroj = new System.Windows.Forms.TextBox();
            this.cmbIzdavac = new System.Windows.Forms.ComboBox();
            this.labelIzdavac = new System.Windows.Forms.Label();
            this.cmbKategorija = new System.Windows.Forms.ComboBox();
            this.labelKategorija = new System.Windows.Forms.Label();
            this.cmbAutor = new System.Windows.Forms.ComboBox();
            this.labelAutor = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pbSlika = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gbOpis = new System.Windows.Forms.GroupBox();
            this.rtbOpis = new System.Windows.Forms.RichTextBox();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbOpis.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDodajSliku.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodajSliku.Location = new System.Drawing.Point(210, 310);
            this.btnDodajSliku.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(187, 32);
            this.btnDodajSliku.TabIndex = 1;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNaziv.Location = new System.Drawing.Point(18, 38);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(46, 19);
            this.labelNaziv.TabIndex = 2;
            this.labelNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.BackColor = System.Drawing.Color.White;
            this.txtNaziv.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNaziv.Location = new System.Drawing.Point(21, 60);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(231, 24);
            this.txtNaziv.TabIndex = 3;
            this.txtNaziv.Validating += new System.ComponentModel.CancelEventHandler(this.txtNaziv_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.labelUkupno);
            this.groupBox1.Controls.Add(this.txtUkupnoNaStanju);
            this.groupBox1.Controls.Add(this.labelBrojStranica);
            this.groupBox1.Controls.Add(this.txtBrojStranica);
            this.groupBox1.Controls.Add(this.labelGodinaIzdavanja);
            this.groupBox1.Controls.Add(this.txtGodinaIzdavanja);
            this.groupBox1.Controls.Add(this.labelInventarniBroj);
            this.groupBox1.Controls.Add(this.txtInventarniBroj);
            this.groupBox1.Controls.Add(this.cmbIzdavac);
            this.groupBox1.Controls.Add(this.labelIzdavac);
            this.groupBox1.Controls.Add(this.cmbKategorija);
            this.groupBox1.Controls.Add(this.labelKategorija);
            this.groupBox1.Controls.Add(this.cmbAutor);
            this.groupBox1.Controls.Add(this.labelAutor);
            this.groupBox1.Controls.Add(this.labelNaziv);
            this.groupBox1.Controls.Add(this.txtNaziv);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(457, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 326);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji knjige";
            // 
            // labelUkupno
            // 
            this.labelUkupno.AutoSize = true;
            this.labelUkupno.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUkupno.Location = new System.Drawing.Point(304, 249);
            this.labelUkupno.Name = "labelUkupno";
            this.labelUkupno.Size = new System.Drawing.Size(130, 19);
            this.labelUkupno.TabIndex = 32;
            this.labelUkupno.Text = "Ukupno na stanju";
            // 
            // txtUkupnoNaStanju
            // 
            this.txtUkupnoNaStanju.BackColor = System.Drawing.Color.White;
            this.txtUkupnoNaStanju.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUkupnoNaStanju.Location = new System.Drawing.Point(307, 271);
            this.txtUkupnoNaStanju.Name = "txtUkupnoNaStanju";
            this.txtUkupnoNaStanju.Size = new System.Drawing.Size(231, 24);
            this.txtUkupnoNaStanju.TabIndex = 33;
            this.txtUkupnoNaStanju.Validating += new System.ComponentModel.CancelEventHandler(this.txtUkupnoNaStanju_Validating);
            // 
            // labelBrojStranica
            // 
            this.labelBrojStranica.AutoSize = true;
            this.labelBrojStranica.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBrojStranica.Location = new System.Drawing.Point(304, 177);
            this.labelBrojStranica.Name = "labelBrojStranica";
            this.labelBrojStranica.Size = new System.Drawing.Size(92, 19);
            this.labelBrojStranica.TabIndex = 30;
            this.labelBrojStranica.Text = "Broj stranica";
            // 
            // txtBrojStranica
            // 
            this.txtBrojStranica.BackColor = System.Drawing.Color.White;
            this.txtBrojStranica.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBrojStranica.Location = new System.Drawing.Point(307, 199);
            this.txtBrojStranica.Name = "txtBrojStranica";
            this.txtBrojStranica.Size = new System.Drawing.Size(231, 24);
            this.txtBrojStranica.TabIndex = 31;
            this.txtBrojStranica.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojStranica_Validating);
            // 
            // labelGodinaIzdavanja
            // 
            this.labelGodinaIzdavanja.AutoSize = true;
            this.labelGodinaIzdavanja.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGodinaIzdavanja.Location = new System.Drawing.Point(305, 109);
            this.labelGodinaIzdavanja.Name = "labelGodinaIzdavanja";
            this.labelGodinaIzdavanja.Size = new System.Drawing.Size(135, 19);
            this.labelGodinaIzdavanja.TabIndex = 28;
            this.labelGodinaIzdavanja.Text = "Godina izdavanja";
            // 
            // txtGodinaIzdavanja
            // 
            this.txtGodinaIzdavanja.BackColor = System.Drawing.Color.White;
            this.txtGodinaIzdavanja.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtGodinaIzdavanja.Location = new System.Drawing.Point(308, 131);
            this.txtGodinaIzdavanja.Name = "txtGodinaIzdavanja";
            this.txtGodinaIzdavanja.Size = new System.Drawing.Size(231, 24);
            this.txtGodinaIzdavanja.TabIndex = 29;
            this.txtGodinaIzdavanja.Validating += new System.ComponentModel.CancelEventHandler(this.txtGodinaIzdavanja_Validating);
            // 
            // labelInventarniBroj
            // 
            this.labelInventarniBroj.AutoSize = true;
            this.labelInventarniBroj.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInventarniBroj.Location = new System.Drawing.Point(304, 38);
            this.labelInventarniBroj.Name = "labelInventarniBroj";
            this.labelInventarniBroj.Size = new System.Drawing.Size(108, 19);
            this.labelInventarniBroj.TabIndex = 26;
            this.labelInventarniBroj.Text = "Inventarni broj";
            // 
            // txtInventarniBroj
            // 
            this.txtInventarniBroj.BackColor = System.Drawing.Color.White;
            this.txtInventarniBroj.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtInventarniBroj.Location = new System.Drawing.Point(307, 60);
            this.txtInventarniBroj.Name = "txtInventarniBroj";
            this.txtInventarniBroj.Size = new System.Drawing.Size(231, 24);
            this.txtInventarniBroj.TabIndex = 27;
            this.txtInventarniBroj.Validating += new System.ComponentModel.CancelEventHandler(this.txtInventarniBroj_Validating);
            // 
            // cmbIzdavac
            // 
            this.cmbIzdavac.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbIzdavac.FormattingEnabled = true;
            this.cmbIzdavac.Location = new System.Drawing.Point(21, 269);
            this.cmbIzdavac.Name = "cmbIzdavac";
            this.cmbIzdavac.Size = new System.Drawing.Size(231, 27);
            this.cmbIzdavac.TabIndex = 25;
            // 
            // labelIzdavac
            // 
            this.labelIzdavac.AutoSize = true;
            this.labelIzdavac.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIzdavac.Location = new System.Drawing.Point(18, 247);
            this.labelIzdavac.Name = "labelIzdavac";
            this.labelIzdavac.Size = new System.Drawing.Size(65, 19);
            this.labelIzdavac.TabIndex = 24;
            this.labelIzdavac.Text = "Izdavač";
            // 
            // cmbKategorija
            // 
            this.cmbKategorija.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbKategorija.FormattingEnabled = true;
            this.cmbKategorija.Location = new System.Drawing.Point(21, 197);
            this.cmbKategorija.Name = "cmbKategorija";
            this.cmbKategorija.Size = new System.Drawing.Size(231, 27);
            this.cmbKategorija.TabIndex = 23;
            // 
            // labelKategorija
            // 
            this.labelKategorija.AutoSize = true;
            this.labelKategorija.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKategorija.Location = new System.Drawing.Point(18, 175);
            this.labelKategorija.Name = "labelKategorija";
            this.labelKategorija.Size = new System.Drawing.Size(130, 19);
            this.labelKategorija.TabIndex = 22;
            this.labelKategorija.Text = "Kategorija ( žanr )";
            // 
            // cmbAutor
            // 
            this.cmbAutor.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cmbAutor.FormattingEnabled = true;
            this.cmbAutor.Location = new System.Drawing.Point(22, 129);
            this.cmbAutor.Name = "cmbAutor";
            this.cmbAutor.Size = new System.Drawing.Size(230, 27);
            this.cmbAutor.TabIndex = 21;
            // 
            // labelAutor
            // 
            this.labelAutor.AutoSize = true;
            this.labelAutor.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAutor.Location = new System.Drawing.Point(19, 107);
            this.labelAutor.Name = "labelAutor";
            this.labelAutor.Size = new System.Drawing.Size(45, 19);
            this.labelAutor.TabIndex = 20;
            this.labelAutor.Text = "Autor";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSpremi.Location = new System.Drawing.Point(513, 647);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(174, 50);
            this.btnSpremi.TabIndex = 25;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(206, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Slika";
            // 
            // pbSlika
            // 
            this.pbSlika.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbSlika.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSlika.Location = new System.Drawing.Point(210, 69);
            this.pbSlika.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbSlika.Name = "pbSlika";
            this.pbSlika.Size = new System.Drawing.Size(187, 221);
            this.pbSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlika.TabIndex = 0;
            this.pbSlika.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // gbOpis
            // 
            this.gbOpis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbOpis.Controls.Add(this.rtbOpis);
            this.gbOpis.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbOpis.Location = new System.Drawing.Point(210, 389);
            this.gbOpis.Name = "gbOpis";
            this.gbOpis.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.gbOpis.Size = new System.Drawing.Size(810, 236);
            this.gbOpis.TabIndex = 27;
            this.gbOpis.TabStop = false;
            this.gbOpis.Text = "Opis knjige";
            // 
            // rtbOpis
            // 
            this.rtbOpis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbOpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOpis.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbOpis.Location = new System.Drawing.Point(25, 37);
            this.rtbOpis.Name = "rtbOpis";
            this.rtbOpis.Size = new System.Drawing.Size(760, 179);
            this.rtbOpis.TabIndex = 0;
            this.rtbOpis.Text = "";
            this.rtbOpis.Validating += new System.ComponentModel.CancelEventHandler(this.rtbOpis_Validating);
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
            this.btnBack.Location = new System.Drawing.Point(11, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(103, 32);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Nazad";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmKnjigaUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbOpis);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.pbSlika);
            this.Controls.Add(this.btnSpremi);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKnjigaUpdate";
            this.Text = "Knjiga Update";
            this.Load += new System.EventHandler(this.frmClanDetalji_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlika)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbOpis.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSlika;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAutor;
        private System.Windows.Forms.Label labelAutor;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelUkupno;
        private System.Windows.Forms.TextBox txtUkupnoNaStanju;
        private System.Windows.Forms.Label labelBrojStranica;
        private System.Windows.Forms.TextBox txtBrojStranica;
        private System.Windows.Forms.Label labelGodinaIzdavanja;
        private System.Windows.Forms.TextBox txtGodinaIzdavanja;
        private System.Windows.Forms.Label labelInventarniBroj;
        private System.Windows.Forms.TextBox txtInventarniBroj;
        private System.Windows.Forms.ComboBox cmbIzdavac;
        private System.Windows.Forms.Label labelIzdavac;
        private System.Windows.Forms.ComboBox cmbKategorija;
        private System.Windows.Forms.Label labelKategorija;
        private System.Windows.Forms.GroupBox gbOpis;
        private System.Windows.Forms.RichTextBox rtbOpis;
        private FontAwesome.Sharp.IconButton btnBack;
    }
}