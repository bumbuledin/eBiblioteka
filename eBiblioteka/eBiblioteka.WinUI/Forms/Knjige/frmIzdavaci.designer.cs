
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmIzdavaci
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
            this.gbIzdavaci = new System.Windows.Forms.GroupBox();
            this.dgvIzdavaci = new System.Windows.Forms.DataGridView();
            this.IzdavacId = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KontaktEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uredi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.labelNazivSearch = new System.Windows.Forms.Label();
            this.txtNazivPretraga = new System.Windows.Forms.TextBox();
            this.gbIzdavaci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzdavaci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbIzdavaci
            // 
            this.gbIzdavaci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbIzdavaci.Controls.Add(this.dgvIzdavaci);
            this.gbIzdavaci.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbIzdavaci.Location = new System.Drawing.Point(94, 106);
            this.gbIzdavaci.Name = "gbIzdavaci";
            this.gbIzdavaci.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbIzdavaci.Size = new System.Drawing.Size(1035, 185);
            this.gbIzdavaci.TabIndex = 1;
            this.gbIzdavaci.TabStop = false;
            this.gbIzdavaci.Text = "Izdavači";
            // 
            // dgvIzdavaci
            // 
            this.dgvIzdavaci.AllowUserToAddRows = false;
            this.dgvIzdavaci.AllowUserToDeleteRows = false;
            this.dgvIzdavaci.AllowUserToResizeColumns = false;
            this.dgvIzdavaci.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvIzdavaci.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIzdavaci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIzdavaci.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIzdavaci.ColumnHeadersHeight = 50;
            this.dgvIzdavaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIzdavaci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IzdavacId,
            this.Naziv,
            this.KontaktEmail,
            this.Uredi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIzdavaci.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIzdavaci.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIzdavaci.Location = new System.Drawing.Point(3, 27);
            this.dgvIzdavaci.Name = "dgvIzdavaci";
            this.dgvIzdavaci.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIzdavaci.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvIzdavaci.RowHeadersVisible = false;
            this.dgvIzdavaci.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvIzdavaci.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvIzdavaci.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvIzdavaci.Size = new System.Drawing.Size(1029, 155);
            this.dgvIzdavaci.TabIndex = 0;
            this.dgvIzdavaci.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIzdavaci_CellContentClick);
            this.dgvIzdavaci.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvIzdavaci_DataBindingComplete);
            // 
            // IzdavacId
            // 
            this.IzdavacId.DataPropertyName = "IzdavacId";
            this.IzdavacId.HeaderText = "IzdavacId";
            this.IzdavacId.MinimumWidth = 6;
            this.IzdavacId.Name = "IzdavacId";
            this.IzdavacId.ReadOnly = true;
            this.IzdavacId.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // KontaktEmail
            // 
            this.KontaktEmail.DataPropertyName = "KontaktEmail";
            this.KontaktEmail.HeaderText = "Email ";
            this.KontaktEmail.MinimumWidth = 6;
            this.KontaktEmail.Name = "KontaktEmail";
            this.KontaktEmail.ReadOnly = true;
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
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.SystemColors.Control;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(97, 297);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(2);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(175, 36);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "+ Dodaj novog izdavača";
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
            this.btnPrethodna.Location = new System.Drawing.Point(992, 299);
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
            this.labelPage.Location = new System.Drawing.Point(1029, 308);
            this.labelPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(61, 17);
            this.labelPage.TabIndex = 7;
            this.labelPage.Text = "Page 1/2";
            // 
            // btnSljedeca
            // 
            this.btnSljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSljedeca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSljedeca.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.btnSljedeca.IconColor = System.Drawing.Color.Black;
            this.btnSljedeca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSljedeca.IconSize = 30;
            this.btnSljedeca.Location = new System.Drawing.Point(1094, 299);
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
            // labelNazivSearch
            // 
            this.labelNazivSearch.AutoSize = true;
            this.labelNazivSearch.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNazivSearch.Location = new System.Drawing.Point(28, 11);
            this.labelNazivSearch.Name = "labelNazivSearch";
            this.labelNazivSearch.Size = new System.Drawing.Size(49, 20);
            this.labelNazivSearch.TabIndex = 10;
            this.labelNazivSearch.Text = "Naziv";
            // 
            // txtNazivPretraga
            // 
            this.txtNazivPretraga.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazivPretraga.Location = new System.Drawing.Point(13, 32);
            this.txtNazivPretraga.Name = "txtNazivPretraga";
            this.txtNazivPretraga.Size = new System.Drawing.Size(119, 23);
            this.txtNazivPretraga.TabIndex = 9;
            this.txtNazivPretraga.TextChanged += new System.EventHandler(this.txtNazivPretraga_TextChanged);
            // 
            // frmIzdavaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.labelNazivSearch);
            this.Controls.Add(this.txtNazivPretraga);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.gbIzdavaci);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmIzdavaci";
            this.Text = "Izdavači";
            this.Load += new System.EventHandler(this.frmUplate_Load);
            this.gbIzdavaci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzdavaci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIzdavaci;
        private System.Windows.Forms.DataGridView dgvIzdavaci;
        private System.Windows.Forms.Button btnDodaj;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label labelNazivSearch;
        private System.Windows.Forms.TextBox txtNazivPretraga;
        private System.Windows.Forms.DataGridViewButtonColumn IzdavacId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn KontaktEmail;
        private System.Windows.Forms.DataGridViewButtonColumn Uredi;
    }
}