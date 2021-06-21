
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmZaduzenja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbAutori = new System.Windows.Forms.GroupBox();
            this.dgvZaduzenja = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.labelID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.labelPrezime = new System.Windows.Forms.Label();
            this.txtClan = new System.Windows.Forms.TextBox();
            this.cbPrikazAktivnihZaduzenja = new System.Windows.Forms.CheckBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.labelKnjiga = new System.Windows.Forms.Label();
            this.txtKnjiga = new System.Windows.Forms.TextBox();
            this.ZaduzenjeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImePrezimeClana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivKnjige = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DatumZaduzenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumVracanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotvrdiVracanjeKnjige = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbAutori.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvZaduzenja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // gbAutori
            // 
            this.gbAutori.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAutori.Controls.Add(this.dgvZaduzenja);
            this.gbAutori.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbAutori.Location = new System.Drawing.Point(10, 121);
            this.gbAutori.Name = "gbAutori";
            this.gbAutori.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbAutori.Size = new System.Drawing.Size(1205, 185);
            this.gbAutori.TabIndex = 1;
            this.gbAutori.TabStop = false;
            this.gbAutori.Text = "Zaduženja";
            // 
            // dgvZaduzenja
            // 
            this.dgvZaduzenja.AllowUserToAddRows = false;
            this.dgvZaduzenja.AllowUserToDeleteRows = false;
            this.dgvZaduzenja.AllowUserToResizeColumns = false;
            this.dgvZaduzenja.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvZaduzenja.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvZaduzenja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZaduzenja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvZaduzenja.ColumnHeadersHeight = 50;
            this.dgvZaduzenja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvZaduzenja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ZaduzenjeId,
            this.ImePrezimeClana,
            this.NazivKnjige,
            this.Status,
            this.DatumZaduzenja,
            this.DatumVracanja,
            this.PotvrdiVracanjeKnjige});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvZaduzenja.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvZaduzenja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvZaduzenja.Location = new System.Drawing.Point(3, 27);
            this.dgvZaduzenja.Name = "dgvZaduzenja";
            this.dgvZaduzenja.ReadOnly = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvZaduzenja.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvZaduzenja.RowHeadersVisible = false;
            this.dgvZaduzenja.RowHeadersWidth = 50;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvZaduzenja.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvZaduzenja.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvZaduzenja.Size = new System.Drawing.Size(1199, 155);
            this.dgvZaduzenja.TabIndex = 0;
            this.dgvZaduzenja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvZaduzenja_CellContentClick);
            this.dgvZaduzenja.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUplate_DataBindingComplete);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.SystemColors.Control;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(13, 315);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(2);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(169, 32);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "+ Dodaj novo zaduženje";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrethodna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrethodna.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnPrethodna.IconColor = System.Drawing.Color.Black;
            this.btnPrethodna.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrethodna.IconSize = 30;
            this.btnPrethodna.Location = new System.Drawing.Point(1076, 315);
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
            this.labelPage.Location = new System.Drawing.Point(1113, 324);
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
            this.btnSljedeca.Location = new System.Drawing.Point(1178, 315);
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
            this.iconPictureBox1.Location = new System.Drawing.Point(8, 6);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox1.TabIndex = 11;
            this.iconPictureBox1.TabStop = false;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelID.Location = new System.Drawing.Point(28, 7);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(103, 20);
            this.labelID.TabIndex = 10;
            this.labelID.Text = "ID Zaduženja";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtID.Location = new System.Drawing.Point(10, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(141, 23);
            this.txtID.TabIndex = 9;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox2.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 22;
            this.iconPictureBox2.Location = new System.Drawing.Point(176, 6);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox2.TabIndex = 14;
            this.iconPictureBox2.TabStop = false;
            // 
            // labelPrezime
            // 
            this.labelPrezime.AutoSize = true;
            this.labelPrezime.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPrezime.Location = new System.Drawing.Point(196, 7);
            this.labelPrezime.Name = "labelPrezime";
            this.labelPrezime.Size = new System.Drawing.Size(73, 20);
            this.labelPrezime.TabIndex = 13;
            this.labelPrezime.Text = "Član ime";
            // 
            // txtClan
            // 
            this.txtClan.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtClan.Location = new System.Drawing.Point(181, 28);
            this.txtClan.Name = "txtClan";
            this.txtClan.Size = new System.Drawing.Size(141, 23);
            this.txtClan.TabIndex = 12;
            this.txtClan.TextChanged += new System.EventHandler(this.txtClan_TextChanged);
            // 
            // cbPrikazAktivnihZaduzenja
            // 
            this.cbPrikazAktivnihZaduzenja.AutoSize = true;
            this.cbPrikazAktivnihZaduzenja.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPrikazAktivnihZaduzenja.Location = new System.Drawing.Point(10, 70);
            this.cbPrikazAktivnihZaduzenja.Name = "cbPrikazAktivnihZaduzenja";
            this.cbPrikazAktivnihZaduzenja.Size = new System.Drawing.Size(251, 24);
            this.cbPrikazAktivnihZaduzenja.TabIndex = 19;
            this.cbPrikazAktivnihZaduzenja.Text = "Prikaži samo aktivna zaduženja\r\n";
            this.cbPrikazAktivnihZaduzenja.UseVisualStyleBackColor = true;
            this.cbPrikazAktivnihZaduzenja.CheckedChanged += new System.EventHandler(this.cbPrikazAktivnihZaduzenja_CheckedChanged);
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconPictureBox4.IconColor = System.Drawing.Color.Black;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 22;
            this.iconPictureBox4.Location = new System.Drawing.Point(342, 6);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(22, 22);
            this.iconPictureBox4.TabIndex = 22;
            this.iconPictureBox4.TabStop = false;
            // 
            // labelKnjiga
            // 
            this.labelKnjiga.AutoSize = true;
            this.labelKnjiga.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKnjiga.Location = new System.Drawing.Point(362, 7);
            this.labelKnjiga.Name = "labelKnjiga";
            this.labelKnjiga.Size = new System.Drawing.Size(53, 20);
            this.labelKnjiga.TabIndex = 21;
            this.labelKnjiga.Text = "Knjiga";
            // 
            // txtKnjiga
            // 
            this.txtKnjiga.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtKnjiga.Location = new System.Drawing.Point(346, 28);
            this.txtKnjiga.Name = "txtKnjiga";
            this.txtKnjiga.Size = new System.Drawing.Size(141, 23);
            this.txtKnjiga.TabIndex = 20;
            this.txtKnjiga.TextChanged += new System.EventHandler(this.txtKnjiga_TextChanged);
            // 
            // ZaduzenjeId
            // 
            this.ZaduzenjeId.DataPropertyName = "ZaduzenjeId";
            this.ZaduzenjeId.HeaderText = "ZaduzenjeId";
            this.ZaduzenjeId.MinimumWidth = 6;
            this.ZaduzenjeId.Name = "ZaduzenjeId";
            this.ZaduzenjeId.ReadOnly = true;
            this.ZaduzenjeId.Visible = false;
            // 
            // ImePrezimeClana
            // 
            this.ImePrezimeClana.DataPropertyName = "ImePrezimeClana";
            this.ImePrezimeClana.HeaderText = "Član";
            this.ImePrezimeClana.MinimumWidth = 6;
            this.ImePrezimeClana.Name = "ImePrezimeClana";
            this.ImePrezimeClana.ReadOnly = true;
            // 
            // NazivKnjige
            // 
            this.NazivKnjige.DataPropertyName = "NazivKnjige";
            this.NazivKnjige.HeaderText = "Knjiga";
            this.NazivKnjige.MinimumWidth = 6;
            this.NazivKnjige.Name = "NazivKnjige";
            this.NazivKnjige.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Aktivno zaduženje";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // DatumZaduzenja
            // 
            this.DatumZaduzenja.DataPropertyName = "DatumZaduzenja";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DatumZaduzenja.DefaultCellStyle = dataGridViewCellStyle3;
            this.DatumZaduzenja.HeaderText = "Datum zaduženja";
            this.DatumZaduzenja.MinimumWidth = 6;
            this.DatumZaduzenja.Name = "DatumZaduzenja";
            this.DatumZaduzenja.ReadOnly = true;
            // 
            // DatumVracanja
            // 
            this.DatumVracanja.DataPropertyName = "DatumVracanja";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.DatumVracanja.DefaultCellStyle = dataGridViewCellStyle4;
            this.DatumVracanja.HeaderText = "Datum povratka knjige";
            this.DatumVracanja.MinimumWidth = 6;
            this.DatumVracanja.Name = "DatumVracanja";
            this.DatumVracanja.ReadOnly = true;
            // 
            // PotvrdiVracanjeKnjige
            // 
            this.PotvrdiVracanjeKnjige.HeaderText = "Akcija";
            this.PotvrdiVracanjeKnjige.MinimumWidth = 6;
            this.PotvrdiVracanjeKnjige.Name = "PotvrdiVracanjeKnjige";
            this.PotvrdiVracanjeKnjige.ReadOnly = true;
            this.PotvrdiVracanjeKnjige.Text = "Potvrdi vraćanje knjige";
            this.PotvrdiVracanjeKnjige.UseColumnTextForButtonValue = true;
            // 
            // frmZaduzenja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.labelKnjiga);
            this.Controls.Add(this.txtKnjiga);
            this.Controls.Add(this.cbPrikazAktivnihZaduzenja);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.labelPrezime);
            this.Controls.Add(this.txtClan);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.gbAutori);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmZaduzenja";
            this.Text = "Zaduženja";
            this.Load += new System.EventHandler(this.frmUplate_Load);
            this.gbAutori.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvZaduzenja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAutori;
        private System.Windows.Forms.DataGridView dgvZaduzenja;
        private System.Windows.Forms.Button btnDodaj;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox txtID;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label labelPrezime;
        private System.Windows.Forms.TextBox txtClan;
        private System.Windows.Forms.CheckBox cbPrikazAktivnihZaduzenja;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label labelKnjiga;
        private System.Windows.Forms.TextBox txtKnjiga;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZaduzenjeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezimeClana;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivKnjige;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumZaduzenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumVracanja;
        private System.Windows.Forms.DataGridViewButtonColumn PotvrdiVracanjeKnjige;
    }
}