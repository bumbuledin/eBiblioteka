
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmKnjige
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbKnjige = new System.Windows.Forms.GroupBox();
            this.dgvKnjige = new System.Windows.Forms.DataGridView();
            this.KnjigaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pisac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GodinaIzdavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreostaloNaStanju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrenutnoZaduzeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrenutnoRezervisano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.labelNaziv = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.labelPisac = new System.Windows.Forms.Label();
            this.txtPisac = new System.Windows.Forms.TextBox();
            this.gbKnjige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbKnjige
            // 
            this.gbKnjige.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbKnjige.Controls.Add(this.dgvKnjige);
            this.gbKnjige.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbKnjige.Location = new System.Drawing.Point(10, 83);
            this.gbKnjige.Name = "gbKnjige";
            this.gbKnjige.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbKnjige.Size = new System.Drawing.Size(1205, 185);
            this.gbKnjige.TabIndex = 1;
            this.gbKnjige.TabStop = false;
            this.gbKnjige.Text = "Knjige";
            // 
            // dgvKnjige
            // 
            this.dgvKnjige.AllowUserToAddRows = false;
            this.dgvKnjige.AllowUserToDeleteRows = false;
            this.dgvKnjige.AllowUserToResizeColumns = false;
            this.dgvKnjige.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKnjige.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKnjige.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKnjige.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKnjige.ColumnHeadersHeight = 50;
            this.dgvKnjige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvKnjige.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KnjigaId,
            this.Naziv,
            this.Pisac,
            this.GodinaIzdavanja,
            this.PreostaloNaStanju,
            this.TrenutnoZaduzeno,
            this.TrenutnoRezervisano,
            this.Uredi,
            this.Obrisi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKnjige.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKnjige.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKnjige.Location = new System.Drawing.Point(3, 27);
            this.dgvKnjige.Name = "dgvKnjige";
            this.dgvKnjige.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKnjige.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKnjige.RowHeadersVisible = false;
            this.dgvKnjige.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvKnjige.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvKnjige.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvKnjige.Size = new System.Drawing.Size(1199, 155);
            this.dgvKnjige.TabIndex = 0;
            this.dgvKnjige.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKnjige_CellContentClick);
            this.dgvKnjige.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvKnjige_DataBindingComplete);
            // 
            // KnjigaId
            // 
            this.KnjigaId.DataPropertyName = "KnjigaId";
            this.KnjigaId.HeaderText = "ID";
            this.KnjigaId.MinimumWidth = 6;
            this.KnjigaId.Name = "KnjigaId";
            this.KnjigaId.ReadOnly = true;
            this.KnjigaId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Pisac
            // 
            this.Pisac.DataPropertyName = "ImePrezime";
            this.Pisac.HeaderText = "Autor";
            this.Pisac.MinimumWidth = 6;
            this.Pisac.Name = "Pisac";
            this.Pisac.ReadOnly = true;
            // 
            // GodinaIzdavanja
            // 
            this.GodinaIzdavanja.DataPropertyName = "GodinaIzdavanja";
            this.GodinaIzdavanja.HeaderText = "Godina izdavanja";
            this.GodinaIzdavanja.MinimumWidth = 6;
            this.GodinaIzdavanja.Name = "GodinaIzdavanja";
            this.GodinaIzdavanja.ReadOnly = true;
            // 
            // PreostaloNaStanju
            // 
            this.PreostaloNaStanju.DataPropertyName = "PreostaloNaStanju";
            this.PreostaloNaStanju.HeaderText = "Preostalo na stanju";
            this.PreostaloNaStanju.MinimumWidth = 6;
            this.PreostaloNaStanju.Name = "PreostaloNaStanju";
            this.PreostaloNaStanju.ReadOnly = true;
            // 
            // TrenutnoZaduzeno
            // 
            this.TrenutnoZaduzeno.DataPropertyName = "TrenutnoZaduzeno";
            this.TrenutnoZaduzeno.HeaderText = "Trenutno zaduženo";
            this.TrenutnoZaduzeno.MinimumWidth = 6;
            this.TrenutnoZaduzeno.Name = "TrenutnoZaduzeno";
            this.TrenutnoZaduzeno.ReadOnly = true;
            // 
            // TrenutnoRezervisano
            // 
            this.TrenutnoRezervisano.DataPropertyName = "TrenutnoRezervisano";
            this.TrenutnoRezervisano.HeaderText = "Trenutno rezervisano";
            this.TrenutnoRezervisano.MinimumWidth = 6;
            this.TrenutnoRezervisano.Name = "TrenutnoRezervisano";
            this.TrenutnoRezervisano.ReadOnly = true;
            // 
            // Uredi
            // 
            this.Uredi.HeaderText = "Detalji";
            this.Uredi.MinimumWidth = 6;
            this.Uredi.Name = "Uredi";
            this.Uredi.ReadOnly = true;
            this.Uredi.Text = "Uredi";
            this.Uredi.UseColumnTextForButtonValue = true;
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Brisanje";
            this.Obrisi.MinimumWidth = 6;
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.ReadOnly = true;
            this.Obrisi.Text = "Obriši";
            this.Obrisi.UseColumnTextForButtonValue = true;
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrethodna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrethodna.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrethodna.IconColor = System.Drawing.Color.Black;
            this.btnPrethodna.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrethodna.IconSize = 30;
            this.btnPrethodna.Location = new System.Drawing.Point(1076, 277);
            this.btnPrethodna.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrethodna.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(30, 32);
            this.btnPrethodna.TabIndex = 3;
            this.btnPrethodna.UseVisualStyleBackColor = true;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click);
            // 
            // labelPage
            // 
            this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPage.Location = new System.Drawing.Point(1113, 286);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(61, 17);
            this.labelPage.TabIndex = 7;
            this.labelPage.Text = "Page 0/0";
            // 
            // btnSljedeca
            // 
            this.btnSljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSljedeca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSljedeca.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btnSljedeca.IconColor = System.Drawing.Color.Black;
            this.btnSljedeca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSljedeca.IconSize = 30;
            this.btnSljedeca.Location = new System.Drawing.Point(1178, 277);
            this.btnSljedeca.Margin = new System.Windows.Forms.Padding(2);
            this.btnSljedeca.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(30, 32);
            this.btnSljedeca.TabIndex = 8;
            this.btnSljedeca.UseVisualStyleBackColor = true;
            this.btnSljedeca.Click += new System.EventHandler(this.btnSljedeca_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 22;
            this.iconPictureBox1.Location = new System.Drawing.Point(8, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox1.TabIndex = 11;
            this.iconPictureBox1.TabStop = false;
            // 
            // labelNaziv
            // 
            this.labelNaziv.AutoSize = true;
            this.labelNaziv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNaziv.Location = new System.Drawing.Point(28, 14);
            this.labelNaziv.Name = "labelNaziv";
            this.labelNaziv.Size = new System.Drawing.Size(44, 17);
            this.labelNaziv.TabIndex = 10;
            this.labelNaziv.Text = "Naziv";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNaziv.Location = new System.Drawing.Point(13, 32);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(119, 23);
            this.txtNaziv.TabIndex = 9;
            this.txtNaziv.TextChanged += new System.EventHandler(this.txtNazivPretraga_TextChanged);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(148, 10);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox2.TabIndex = 14;
            this.iconPictureBox2.TabStop = false;
            // 
            // labelPisac
            // 
            this.labelPisac.AutoSize = true;
            this.labelPisac.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPisac.Location = new System.Drawing.Point(167, 14);
            this.labelPisac.Name = "labelPisac";
            this.labelPisac.Size = new System.Drawing.Size(90, 17);
            this.labelPisac.TabIndex = 13;
            this.labelPisac.Text = "Pisac / Autor";
            // 
            // txtPisac
            // 
            this.txtPisac.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPisac.Location = new System.Drawing.Point(152, 32);
            this.txtPisac.Name = "txtPisac";
            this.txtPisac.Size = new System.Drawing.Size(119, 23);
            this.txtPisac.TabIndex = 12;
            this.txtPisac.TextChanged += new System.EventHandler(this.txtPisac_TextChanged);
            // 
            // frmKnjige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.labelPisac);
            this.Controls.Add(this.txtPisac);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.labelNaziv);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.gbKnjige);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmKnjige";
            this.Text = "Pregled knjiga";
            this.Load += new System.EventHandler(this.frmUplate_Load);
            this.gbKnjige.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKnjige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbKnjige;
        private System.Windows.Forms.DataGridView dgvKnjige;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label labelNaziv;
        private System.Windows.Forms.TextBox txtNaziv;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label labelPisac;
        private System.Windows.Forms.TextBox txtPisac;
        private System.Windows.Forms.DataGridViewTextBoxColumn KnjigaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pisac;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodinaIzdavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreostaloNaStanju;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrenutnoZaduzeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrenutnoRezervisano;
        private System.Windows.Forms.DataGridViewButtonColumn Uredi;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
    }
}