using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Forms.Knjige;
using eBiblioteka.WinUI.Forms.Static;
using eBiblioteka.WinUI.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBiblioteka.WinUI.Forms.Clanovi
{
    public partial class frmKnjige : Form
    {
        private readonly APIService _knjigeService = new APIService("Knjiga");
        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize =13;
        private List<Model.Knjiga> apiList;
        private IPagedList<Model.Knjiga> knjigaList;

        public frmKnjige(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            KnjigaInit();
        }

        public async void KnjigaInit(KnjigaSearchRequest search=null)
        {

            apiList = await _knjigeService.Get<List<Model.Knjiga>>(search);
            knjigaList = apiList.ToPagedList(pageNumber, pageSize);

            dgvKnjige.AutoGenerateColumns = false;
            dgvKnjige.DataSource = knjigaList.ToList();

            btnPrethodna.Enabled = knjigaList.HasPreviousPage;
            btnSljedeca.Enabled = knjigaList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, knjigaList.PageCount);

        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(knjigaList.HasPreviousPage)
            {
                knjigaList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvKnjige.AutoGenerateColumns = false;
                dgvKnjige.DataSource = knjigaList.ToList();

                btnPrethodna.Enabled = knjigaList.HasPreviousPage;
                btnSljedeca.Enabled = knjigaList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, knjigaList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(knjigaList.HasNextPage)
            {
                knjigaList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvKnjige.AutoGenerateColumns = false;
                dgvKnjige.DataSource = knjigaList.ToList();

                btnPrethodna.Enabled = knjigaList.HasPreviousPage;
                btnSljedeca.Enabled = knjigaList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, knjigaList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNoviAutor s = new frmNoviAutor(_mainForm);
            s.ShowDialog();
        }
        private void dgvKnjige_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvKnjige.Rows)
                height += dr.Height;
            gbKnjige.Height = height;
            dgvKnjige.Height = height;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvKnjige.Columns["Obrisi"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.Tomato;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvKnjige.Columns["Uredi"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.LimeGreen;

            btnPrethodna.Location = new Point(btnPrethodna.Location.X,gbKnjige.Location.Y + height + 15);
            labelPage.Location = new Point(labelPage.Location.X, gbKnjige.Location.Y + height + 25);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbKnjige.Location.Y + height + 15);

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }
        private void txtNazivPretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new KnjigaSearchRequest()
            {
                Naziv = txtNaziv.Text,
                ImePrezime=txtPisac.Text
            };

            KnjigaInit(search);
        }
        private void txtPisac_TextChanged(object sender, EventArgs e)
        {
            var search = new KnjigaSearchRequest()
            {
                Naziv = txtNaziv.Text,
                ImePrezime = txtPisac.Text
            };

            KnjigaInit(search);
        }
        private async void dgvKnjige_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKnjige.Columns[e.ColumnIndex].Name == "Obrisi" && e.RowIndex != -1)
            {
                var id = dgvKnjige.Rows[e.RowIndex].Cells[0].Value;
                var naziv = dgvKnjige.Rows[e.RowIndex].Cells[1].Value;

                if (MessageBox.Show("Da li ste sigurni da želite izbrisati knjigu - " + naziv  + " ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var x = await _knjigeService.Delete<bool>((int)id);

                    if (x == true)
                    {
                        MessageBox.Show("Uspješno ste izbrisali knjigu " + naziv + ".", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainForm.OpenForm(new frmKnjige(_mainForm));

                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom brisanja knjige " + naziv + ".", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            else if (dgvKnjige.Columns[e.ColumnIndex].Name == "Uredi" && e.RowIndex != -1)
            {
                var id = (int)dgvKnjige.Rows[e.RowIndex].Cells[0].Value;

                _mainForm.OpenFormAndAddTitle(new frmKnjigaUpdate(_mainForm, id));

            }
        }

    }
}
