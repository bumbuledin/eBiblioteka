
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmPregledClanova
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbClanovi = new System.Windows.Forms.GroupBox();
            this.dgvClanovi = new System.Windows.Forms.DataGridView();
            this.cbPrikazAktivnihClanova = new System.Windows.Forms.CheckBox();
            this.txtImePretraga = new System.Windows.Forms.TextBox();
            this.labelImeSearch = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.labelPrezimeSearch = new System.Windows.Forms.Label();
            this.txtPrezimePretraga = new System.Windows.Forms.TextBox();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.ClanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUclanjenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Uplate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Deaktiviraj = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbClanovi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbClanovi
            // 
            this.gbClanovi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbClanovi.Controls.Add(this.dgvClanovi);
            this.gbClanovi.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbClanovi.Location = new System.Drawing.Point(12, 116);
            this.gbClanovi.Name = "gbClanovi";
            this.gbClanovi.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbClanovi.Size = new System.Drawing.Size(1203, 247);
            this.gbClanovi.TabIndex = 0;
            this.gbClanovi.TabStop = false;
            this.gbClanovi.Text = "Članovi";
            // 
            // dgvClanovi
            // 
            this.dgvClanovi.AllowUserToAddRows = false;
            this.dgvClanovi.AllowUserToDeleteRows = false;
            this.dgvClanovi.AllowUserToResizeColumns = false;
            this.dgvClanovi.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvClanovi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvClanovi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClanovi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvClanovi.ColumnHeadersHeight = 50;
            this.dgvClanovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvClanovi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClanId,
            this.Ime,
            this.Prezime,
            this.KorisnickoIme,
            this.DatumUclanjenja,
            this.Aktivan,
            this.Detalji,
            this.Uplate,
            this.Deaktiviraj});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClanovi.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvClanovi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClanovi.Location = new System.Drawing.Point(3, 27);
            this.dgvClanovi.Name = "dgvClanovi";
            this.dgvClanovi.ReadOnly = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClanovi.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvClanovi.RowHeadersVisible = false;
            this.dgvClanovi.RowHeadersWidth = 51;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvClanovi.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvClanovi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvClanovi.Size = new System.Drawing.Size(1197, 217);
            this.dgvClanovi.TabIndex = 0;
            this.dgvClanovi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClanovi_CellContentClick);
            this.dgvClanovi.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvClanovi_DataBindingComplete);
            // 
            // cbPrikazAktivnihClanova
            // 
            this.cbPrikazAktivnihClanova.AutoSize = true;
            this.cbPrikazAktivnihClanova.Checked = true;
            this.cbPrikazAktivnihClanova.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrikazAktivnihClanova.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPrikazAktivnihClanova.Location = new System.Drawing.Point(15, 77);
            this.cbPrikazAktivnihClanova.Name = "cbPrikazAktivnihClanova";
            this.cbPrikazAktivnihClanova.Size = new System.Drawing.Size(240, 24);
            this.cbPrikazAktivnihClanova.TabIndex = 1;
            this.cbPrikazAktivnihClanova.Text = "Prikaži samo aktivne članove";
            this.cbPrikazAktivnihClanova.UseVisualStyleBackColor = true;
            this.cbPrikazAktivnihClanova.CheckedChanged += new System.EventHandler(this.cbPrikazAktivnihClanova_CheckedChanged);
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
            this.labelImeSearch.Location = new System.Drawing.Point(29, 15);
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
            this.iconPictureBox1.Location = new System.Drawing.Point(10, 15);
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
            this.iconPictureBox2.Location = new System.Drawing.Point(147, 15);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox2.TabIndex = 7;
            this.iconPictureBox2.TabStop = false;
            // 
            // labelPrezimeSearch
            // 
            this.labelPrezimeSearch.AutoSize = true;
            this.labelPrezimeSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrezimeSearch.Location = new System.Drawing.Point(166, 15);
            this.labelPrezimeSearch.Name = "labelPrezimeSearch";
            this.labelPrezimeSearch.Size = new System.Drawing.Size(65, 20);
            this.labelPrezimeSearch.TabIndex = 6;
            this.labelPrezimeSearch.Text = "Prezime";
            // 
            // txtPrezimePretraga
            // 
            this.txtPrezimePretraga.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPrezimePretraga.Location = new System.Drawing.Point(151, 38);
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
            this.btnSljedeca.Location = new System.Drawing.Point(1181, 376);
            this.btnSljedeca.Margin = new System.Windows.Forms.Padding(2);
            this.btnSljedeca.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnSljedeca.Name = "btnSljedeca";
            this.btnSljedeca.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSljedeca.Size = new System.Drawing.Size(30, 32);
            this.btnSljedeca.TabIndex = 14;
            this.btnSljedeca.UseVisualStyleBackColor = true;
            this.btnSljedeca.Click += new System.EventHandler(this.btnSljedeca_Click);
            // 
            // labelPage
            // 
            this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPage.Location = new System.Drawing.Point(1116, 385);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(61, 17);
            this.labelPage.TabIndex = 13;
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
            this.btnPrethodna.Location = new System.Drawing.Point(1079, 376);
            this.btnPrethodna.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrethodna.MaximumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.MinimumSize = new System.Drawing.Size(30, 32);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnPrethodna.Size = new System.Drawing.Size(30, 32);
            this.btnPrethodna.TabIndex = 12;
            this.btnPrethodna.UseVisualStyleBackColor = true;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click);
            // 
            // ClanId
            // 
            this.ClanId.DataPropertyName = "ClanId";
            this.ClanId.HeaderText = "ClanId";
            this.ClanId.MinimumWidth = 6;
            this.ClanId.Name = "ClanId";
            this.ClanId.ReadOnly = true;
            this.ClanId.Visible = false;
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
            // DatumUclanjenja
            // 
            this.DatumUclanjenja.DataPropertyName = "DatumUclanjenja";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.DatumUclanjenja.DefaultCellStyle = dataGridViewCellStyle9;
            this.DatumUclanjenja.HeaderText = "Datum učlanjenja";
            this.DatumUclanjenja.MinimumWidth = 6;
            this.DatumUclanjenja.Name = "DatumUclanjenja";
            this.DatumUclanjenja.ReadOnly = true;
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
            // Uplate
            // 
            this.Uplate.HeaderText = "Uplate";
            this.Uplate.MinimumWidth = 6;
            this.Uplate.Name = "Uplate";
            this.Uplate.ReadOnly = true;
            this.Uplate.Text = "Uplate";
            this.Uplate.UseColumnTextForButtonValue = true;
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
            // frmPregledClanova
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
            this.Controls.Add(this.cbPrikazAktivnihClanova);
            this.Controls.Add(this.gbClanovi);
            this.Name = "frmPregledClanova";
            this.Text = "Pregled članova";
            this.Load += new System.EventHandler(this.frmPregledClanova_Load);
            this.gbClanovi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClanovi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbClanovi;
        private System.Windows.Forms.DataGridView dgvClanovi;
        private System.Windows.Forms.CheckBox cbPrikazAktivnihClanova;
        private System.Windows.Forms.TextBox txtImePretraga;
        private System.Windows.Forms.Label labelImeSearch;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label labelPrezimeSearch;
        private System.Windows.Forms.TextBox txtPrezimePretraga;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUclanjenja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivan;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.DataGridViewButtonColumn Uplate;
        private System.Windows.Forms.DataGridViewButtonColumn Deaktiviraj;
    }
}