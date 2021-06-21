
namespace eBiblioteka.WinUI.Forms.Clanovi
{
    partial class frmUplate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbUplate = new System.Windows.Forms.GroupBox();
            this.dgvUplate = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnPrethodna = new FontAwesome.Sharp.IconButton();
            this.labelPage = new System.Windows.Forms.Label();
            this.btnSljedeca = new FontAwesome.Sharp.IconButton();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.UplataId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrstaUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaziDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gbUplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUplate
            // 
            this.gbUplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUplate.Controls.Add(this.dgvUplate);
            this.gbUplate.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbUplate.Location = new System.Drawing.Point(88, 71);
            this.gbUplate.Name = "gbUplate";
            this.gbUplate.Padding = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.gbUplate.Size = new System.Drawing.Size(1042, 185);
            this.gbUplate.TabIndex = 1;
            this.gbUplate.TabStop = false;
            this.gbUplate.Text = "Uplate";
            // 
            // dgvUplate
            // 
            this.dgvUplate.AllowUserToAddRows = false;
            this.dgvUplate.AllowUserToDeleteRows = false;
            this.dgvUplate.AllowUserToResizeColumns = false;
            this.dgvUplate.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUplate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUplate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUplate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUplate.ColumnHeadersHeight = 50;
            this.dgvUplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UplataId,
            this.DatumUplate,
            this.VrstaUplate,
            this.VaziDo,
            this.Iznos,
            this.Obrisi});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUplate.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUplate.Location = new System.Drawing.Point(3, 27);
            this.dgvUplate.Name = "dgvUplate";
            this.dgvUplate.ReadOnly = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUplate.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUplate.RowHeadersVisible = false;
            this.dgvUplate.RowHeadersWidth = 51;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUplate.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvUplate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvUplate.Size = new System.Drawing.Size(1036, 155);
            this.dgvUplate.TabIndex = 0;
            this.dgvUplate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUplate_CellContentClick);
            this.dgvUplate.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUplate_DataBindingComplete);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(88, 265);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(2);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(151, 32);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "+ Dodaj novu uplatu";
            this.btnDodaj.UseVisualStyleBackColor = true;
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
            this.btnPrethodna.Location = new System.Drawing.Point(997, 271);
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
            this.labelPage.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPage.Location = new System.Drawing.Point(1031, 280);
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
            this.btnSljedeca.Location = new System.Drawing.Point(1097, 271);
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
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 28;
            this.btnBack.Location = new System.Drawing.Point(9, 10);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 31);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Nazad";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // UplataId
            // 
            this.UplataId.DataPropertyName = "UplataId";
            this.UplataId.HeaderText = "UplataId";
            this.UplataId.Name = "UplataId";
            this.UplataId.ReadOnly = true;
            this.UplataId.Visible = false;
            // 
            // DatumUplate
            // 
            this.DatumUplate.DataPropertyName = "DatumUplate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DatumUplate.DefaultCellStyle = dataGridViewCellStyle3;
            this.DatumUplate.HeaderText = "Datum uplate";
            this.DatumUplate.MinimumWidth = 6;
            this.DatumUplate.Name = "DatumUplate";
            this.DatumUplate.ReadOnly = true;
            // 
            // VrstaUplate
            // 
            this.VrstaUplate.DataPropertyName = "VrstaUplateNaziv";
            this.VrstaUplate.HeaderText = "Vrsta uplate";
            this.VrstaUplate.MinimumWidth = 6;
            this.VrstaUplate.Name = "VrstaUplate";
            this.VrstaUplate.ReadOnly = true;
            // 
            // VaziDo
            // 
            this.VaziDo.DataPropertyName = "VaziDo";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.VaziDo.DefaultCellStyle = dataGridViewCellStyle4;
            this.VaziDo.HeaderText = "Važi do";
            this.VaziDo.MinimumWidth = 6;
            this.VaziDo.Name = "VaziDo";
            this.VaziDo.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "IznosUplate";
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Iznos.DefaultCellStyle = dataGridViewCellStyle5;
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.MinimumWidth = 6;
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Akcija";
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.ReadOnly = true;
            this.Obrisi.Text = "Obriši";
            this.Obrisi.UseColumnTextForButtonValue = true;
            // 
            // frmUplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1225, 723);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSljedeca);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.gbUplate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUplate";
            this.Text = "Uplate";
            this.Load += new System.EventHandler(this.frmUplate_Load);
            this.gbUplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUplate;
        private System.Windows.Forms.DataGridView dgvUplate;
        private System.Windows.Forms.Button btnDodaj;
        private FontAwesome.Sharp.IconButton btnPrethodna;
        private System.Windows.Forms.Label labelPage;
        private FontAwesome.Sharp.IconButton btnSljedeca;
        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn UplataId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrstaUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaziDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
    }
}