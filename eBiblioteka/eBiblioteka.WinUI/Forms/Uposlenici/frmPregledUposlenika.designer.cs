
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmPregledUposlenika
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbUposlenici = new System.Windows.Forms.GroupBox();
            this.dgvUposlenici = new System.Windows.Forms.DataGridView();
            this.cbPrikazAktivnihUposlenika = new System.Windows.Forms.CheckBox();
            this.txtImePretraga = new System.Windows.Forms.TextBox();
            this.labelImeSearch = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.labelPrezimeSearch = new System.Windows.Forms.Label();
            this.txtPrezimePretraga = new System.Windows.Forms.TextBox();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.UposlenikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumZaposlenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Deaktiviraj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbUposlenici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUposlenici
            // 
            this.gbUposlenici.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUposlenici.Controls.Add(this.dgvUposlenici);
            this.gbUposlenici.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbUposlenici.Location = new System.Drawing.Point(12, 116);
            this.gbUposlenici.Name = "gbUposlenici";
            this.gbUposlenici.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbUposlenici.Size = new System.Drawing.Size(1203, 247);
            this.gbUposlenici.TabIndex = 0;
            this.gbUposlenici.TabStop = false;
            this.gbUposlenici.Text = "Uposlenici";
            // 
            // dgvUposlenici
            // 
            this.dgvUposlenici.AllowUserToAddRows = false;
            this.dgvUposlenici.AllowUserToDeleteRows = false;
            this.dgvUposlenici.AllowUserToResizeColumns = false;
            this.dgvUposlenici.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUposlenici.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUposlenici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUposlenici.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUposlenici.ColumnHeadersHeight = 50;
            this.dgvUposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUposlenici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UposlenikId,
            this.Ime,
            this.Prezime,
            this.KorisnickoIme,
            this.DatumZaposlenja,
            this.Aktivan,
            this.Detalji,
            this.Deaktiviraj});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUposlenici.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUposlenici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUposlenici.Location = new System.Drawing.Point(3, 27);
            this.dgvUposlenici.Name = "dgvUposlenici";
            this.dgvUposlenici.ReadOnly = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUposlenici.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUposlenici.RowHeadersVisible = false;
            this.dgvUposlenici.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUposlenici.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUposlenici.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvUposlenici.Size = new System.Drawing.Size(1197, 217);
            this.dgvUposlenici.TabIndex = 0;
            this.dgvUposlenici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUposlenici_CellContentClick);
            this.dgvUposlenici.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUposlenici_DataBindingComplete);
            // 
            // cbPrikazAktivnihUposlenika
            // 
            this.cbPrikazAktivnihUposlenika.AutoSize = true;
            this.cbPrikazAktivnihUposlenika.Checked = true;
            this.cbPrikazAktivnihUposlenika.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrikazAktivnihUposlenika.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPrikazAktivnihUposlenika.Location = new System.Drawing.Point(15, 77);
            this.cbPrikazAktivnihUposlenika.Name = "cbPrikazAktivnihUposlenika";
            this.cbPrikazAktivnihUposlenika.Size = new System.Drawing.Size(256, 24);
            this.cbPrikazAktivnihUposlenika.TabIndex = 1;
            this.cbPrikazAktivnihUposlenika.Text = "Prikaži samo aktivne uposlenike";
            this.cbPrikazAktivnihUposlenika.UseVisualStyleBackColor = true;
            this.cbPrikazAktivnihUposlenika.CheckedChanged += new System.EventHandler(this.cbPrikazAktivnihUposlenika_CheckedChanged);
            // 
            // txtImePretraga
            // 
            this.txtImePretraga.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtImePretraga.Location = new System.Drawing.Point(14, 38);
            this.txtImePretraga.Name = "txtImePretraga";
            this.txtImePretraga.Size = new System.Drawing.Size(119, 23);
            this.txtImePretraga.TabIndex = 2;
            this.txtImePretraga.TextChanged += new System.EventHandler(this.txtImePretraga_TextChanged);
            // 
            // labelImeSearch
            // 
            this.labelImeSearch.AutoSize = true;
            this.labelImeSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelImeSearch.Location = new System.Drawing.Point(29, 16);
            this.labelImeSearch.Name = "labelImeSearch";
            this.labelImeSearch.Size = new System.Drawing.Size(37, 20);
            this.labelImeSearch.TabIndex = 3;
            this.labelImeSearch.Text = "Ime";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 22;
            this.iconPictureBox1.Location = new System.Drawing.Point(10, 16);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox1.TabIndex = 4;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(152, 16);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox2.TabIndex = 7;
            this.iconPictureBox2.TabStop = false;
            // 
            // labelPrezimeSearch
            // 
            this.labelPrezimeSearch.AutoSize = true;
            this.labelPrezimeSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrezimeSearch.Location = new System.Drawing.Point(171, 16);
            this.labelPrezimeSearch.Name = "labelPrezimeSearch";
            this.labelPrezimeSearch.Size = new System.Drawing.Size(65, 20);
            this.labelPrezimeSearch.TabIndex = 6;
            this.labelPrezimeSearch.Text = "Prezime";
            // 
            // txtPrezimePretraga
            // 
            this.txtPrezimePretraga.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrezimePretraga.Location = new System.Drawing.Point(156, 38);
            this.txtPrezimePretraga.Name = "txtPrezimePretraga";
            this.txtPrezimePretraga.Size = new System.Drawing.Size(119, 23);
            this.txtPrezimePretraga.TabIndex = 5;
            this.txtPrezimePretraga.TextChanged += new System.EventHandler(this.txtPrezimePretraga_TextChanged);
            // 
            // btnSljedeca
            // 
            this.btnSljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSljedeca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSljedeca.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btnSljedeca.IconColor = System.Drawing.Color.Black;
            this.btnSljedeca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSljedeca.IconSize = 30;
            this.btnSljedeca.Location = new System.Drawing.Point(1179, 373);
            this.btnSljedeca.Margin = new System.Windows.Forms.Padding(2);
            this.btnSljedeca.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(30, 32);
            this.btnSljedeca.TabIndex = 11;
            this.btnSljedeca.UseVisualStyleBackColor = true;
            this.btnSljedeca.Click += new System.EventHandler(this.btnSljedeca_Click);
            // 
            // labelPage
            // 
            this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPage.AutoSize = true;
            this.labelPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPage.Location = new System.Drawing.Point(1115, 382);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(61, 17);
            this.labelPage.TabIndex = 10;
            this.labelPage.Text = "Page 0/0";
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrethodna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrethodna.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrethodna.IconColor = System.Drawing.Color.Black;
            this.btnPrethodna.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrethodna.IconSize = 30;
            this.btnPrethodna.Location = new System.Drawing.Point(1081, 373);
            this.btnPrethodna.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrethodna.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(30, 32);
            this.btnPrethodna.TabIndex = 9;
            this.btnPrethodna.UseVisualStyleBackColor = true;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click);
            // 
            // UposlenikId
            // 
            this.UposlenikId.DataPropertyName = "UposlenikId";
            this.UposlenikId.HeaderText = "UposlenikId";
            this.UposlenikId.MinimumWidth = 6;
            this.UposlenikId.Name = "UposlenikId";
            this.UposlenikId.ReadOnly = true;
            this.UposlenikId.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.MinimumWidth = 6;
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.MinimumWidth = 6;
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Korisničko ime";
            this.KorisnickoIme.MinimumWidth = 6;
            this.KorisnickoIme.Name = "KorisnickoIme";
            this.KorisnickoIme.ReadOnly = true;
            // 
            // DatumZaposlenja
            // 
            this.DatumZaposlenja.DataPropertyName = "DatumZaposlenja";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DatumZaposlenja.DefaultCellStyle = dataGridViewCellStyle3;
            this.DatumZaposlenja.HeaderText = "Datum zaposlenja";
            this.DatumZaposlenja.MinimumWidth = 6;
            this.DatumZaposlenja.Name = "DatumZaposlenja";
            this.DatumZaposlenja.ReadOnly = true;
            // 
            // Aktivan
            // 
            this.Aktivan.DataPropertyName = "Status";
            this.Aktivan.HeaderText = "Aktivan";
            this.Aktivan.MinimumWidth = 6;
            this.Aktivan.Name = "Aktivan";
            this.Aktivan.ReadOnly = true;
            this.Aktivan.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktivan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Detalji
            // 
            this.Detalji.DataPropertyName = "Detalji";
            this.Detalji.HeaderText = "Detalji";
            this.Detalji.MinimumWidth = 6;
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // Deaktiviraj
            // 
            this.Deaktiviraj.HeaderText = "Brisanje";
            this.Deaktiviraj.MinimumWidth = 6;
            this.Deaktiviraj.Name = "Deaktiviraj";
            this.Deaktiviraj.ReadOnly = true;
            this.Deaktiviraj.Text = "Deaktiviraj";
            this.Deaktiviraj.UseColumnTextForButtonValue = true;
            // 
            // frmPregledUposlenika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.labelPrezimeSearch);
            this.Controls.Add(this.txtPrezimePretraga);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.labelImeSearch);
            this.Controls.Add(this.txtImePretraga);
            this.Controls.Add(this.cbPrikazAktivnihUposlenika);
            this.Controls.Add(this.gbUposlenici);
            this.Name = "frmPregledUposlenika";
            this.Text = "Pregled uposlenika";
            this.Load += new System.EventHandler(this.frmPregledUposlenika_Load);
            this.gbUposlenici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbUposlenici;
        private System.Windows.Forms.DataGridView dgvUposlenici;
        private System.Windows.Forms.CheckBox cbPrikazAktivnihUposlenika;
        private System.Windows.Forms.TextBox txtImePretraga;
        private System.Windows.Forms.Label labelImeSearch;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label labelPrezimeSearch;
        private System.Windows.Forms.TextBox txtPrezimePretraga;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.DataGridViewTextBoxColumn UposlenikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaposlenja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Deaktiviraj;
    }
}