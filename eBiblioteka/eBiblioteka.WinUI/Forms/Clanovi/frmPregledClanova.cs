using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Forms.Static;
using eBiblioteka.WinUI.Services;
using Flurl.Http;
using PagedList;

namespace eBiblioteka.WinUI.Forms.Clanovi
{
    public partial class frmPregledClanova : Form
    {
        private readonly APIService _apiService = new APIService("Clan");
        private readonly MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize = 8;
        private List<Model.Clan> apiList;
        private IPagedList<Model.Clan> clanList;

        public frmPregledClanova(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void frmPregledClanova_Load(object sender, EventArgs e)
        {
            ClanInit();
        }
        public async void ClanInit(ClanSearchRequest search = null)
        {
            if (search == null && cbPrikazAktivnihClanova.Checked == true)
            {
                search = new ClanSearchRequest();
                search.Status = true;
            }

            apiList = await _apiService.Get<List<Model.Clan>>(search);
            clanList = apiList.ToPagedList(pageNumber, pageSize);

            dgvClanovi.AutoGenerateColumns = false;
            dgvClanovi.DataSource = clanList.ToList();

            btnPrethodna.Enabled = clanList.HasPreviousPage;
            btnSljedeca.Enabled = clanList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, clanList.PageCount);

        }

        private void dgvClanovi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvClanovi.Rows)
                height += dr.Height;
        
            gbClanovi.MaximumSize = new Size(2000, height);
            dgvClanovi.MaximumSize = new Size(2000, height);


            gbClanovi.Height = height;
            dgvClanovi.Height = height;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvClanovi.Columns["Deaktiviraj"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.Tomato;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvClanovi.Columns["Detalji"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.LimeGreen;

            DataGridViewButtonColumn ed = (DataGridViewButtonColumn)dgvClanovi.Columns["Uplate"];
            ed.FlatStyle = FlatStyle.Popup;
            ed.DefaultCellStyle.ForeColor = Color.Black;
            ed.DefaultCellStyle.BackColor = Color.MediumTurquoise;

            for (int i = 0; i < dgvClanovi.Rows.Count; i++)
            {
                var x = (bool)dgvClanovi[5, i].Value;
                if (x == false)
                {
                    var cell = dgvClanovi[8, i] = new DataGridViewTextBoxCell();
                    cell.Value = String.Empty;
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.White;
                }
            }

            btnPrethodna.Location = new Point(btnPrethodna.Location.X, gbClanovi.Location.Y + height + 10);
            labelPage.Location = new Point(labelPage.Location.X, gbClanovi.Location.Y + height + 20);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbClanovi.Location.Y + height + 10);
        }

        private async void dgvClanovi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClanovi.Columns[e.ColumnIndex].Name == "Deaktiviraj" && e.RowIndex != -1)
            {
                var id = dgvClanovi.Rows[e.RowIndex].Cells[0].Value;
                var ime = dgvClanovi.Rows[e.RowIndex].Cells[1].Value;
                var prezime = dgvClanovi.Rows[e.RowIndex].Cells[2].Value;

                if (MessageBox.Show("Da li ste sigurni da želite izmjenuti status člana " + ime + " " + prezime + " u neaktivan ? Opcija logiranja će biti zabranjenja za odabranog člana. Želite li nastaviti ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var x = await _apiService.Delete<bool>((int)id);

                    if(x == true)
                    {
                        MessageBox.Show("Uspješno ste izmjenuli status člana " + ime + " " + prezime + " u neaktivan.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainForm.OpenForm(new frmPregledClanova(_mainForm));

                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom izmjene statusa člana " + ime + " " + prezime + ".", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                }
            }
            else if (dgvClanovi.Columns[e.ColumnIndex].Name == "Uplate" && e.RowIndex != -1)
            {
                var id = (int)dgvClanovi.Rows[e.RowIndex].Cells[0].Value;

                _mainForm.OpenFormAndAddTitle(new frmUplate(_mainForm, id));

            }
            else if (dgvClanovi.Columns[e.ColumnIndex].Name == "Detalji" && e.RowIndex != -1)
            {
                var id = (int)dgvClanovi.Rows[e.RowIndex].Cells[0].Value;

                _mainForm.OpenFormAndAddTitle(new frmClanDetalji(_mainForm, id));

            }
        }

        private void cbPrikazAktivnihClanova_CheckedChanged(object sender, EventArgs e)
        {
            var search = new ClanSearchRequest()
            {
                Ime = txtImePretraga.Text,
                Prezime = txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihClanova.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            ClanInit(search);

        }

        private void txtPrezimePretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new ClanSearchRequest()
            {
                Ime=txtImePretraga.Text,
                Prezime=txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihClanova.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            ClanInit(search);
        }

        private void txtImePretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new ClanSearchRequest()
            {
                Ime = txtImePretraga.Text,
                Prezime = txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihClanova.Checked;

            if (state == true)
            {
                search.Status = true;
            }
            ClanInit(search);
        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if (clanList.HasPreviousPage)
            {
                clanList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvClanovi.AutoGenerateColumns = false;
                dgvClanovi.DataSource = clanList.ToList();

                btnPrethodna.Enabled = clanList.HasPreviousPage;
                btnSljedeca.Enabled = clanList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, clanList.PageCount);
            }
        }

        private void btnSljedeca_Click(object sender, EventArgs e)
        {

            if (clanList.HasNextPage)
            {
                clanList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvClanovi.AutoGenerateColumns = false;
                dgvClanovi.DataSource = clanList.ToList();

                btnPrethodna.Enabled = clanList.HasPreviousPage;
                btnSljedeca.Enabled = clanList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, clanList.PageCount);
            }
        }
    }
    
}
