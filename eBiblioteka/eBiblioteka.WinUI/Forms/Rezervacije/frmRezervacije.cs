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
    public partial class frmRezervacije : Form
    {
        private readonly APIService _zaduzenjeService = new APIService("Zaduzenje");
        private readonly APIService _rezervacijaService = new APIService("Rezervacija");

        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize =13;
        private List<Model.Rezervacija> apiList;
        private IPagedList<Model.Rezervacija> rezervacijaList;

        public frmRezervacije(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            RezervacijaInit();
        }

        public async void RezervacijaInit(RezervacijaSearchRequest search=null)
        {
            if(search == null && cbPrikazAktivnihRezervacija.Checked == true)
            {
                search = new RezervacijaSearchRequest();
                search.Status = true;
            }

            apiList = await _rezervacijaService.Get<List<Model.Rezervacija>>(search);
            rezervacijaList = apiList.ToPagedList(pageNumber, pageSize);

            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = rezervacijaList.ToList();

            btnPrethodna.Enabled = rezervacijaList.HasPreviousPage;
            btnSljedeca.Enabled = rezervacijaList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, rezervacijaList.PageCount);

        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(rezervacijaList.HasPreviousPage)
            {
                rezervacijaList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvRezervacije.AutoGenerateColumns = false;
                dgvRezervacije.DataSource = rezervacijaList.ToList();

                btnPrethodna.Enabled = rezervacijaList.HasPreviousPage;
                btnSljedeca.Enabled = rezervacijaList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, rezervacijaList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(rezervacijaList.HasNextPage)
            {
                rezervacijaList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvRezervacije.AutoGenerateColumns = false;
                dgvRezervacije.DataSource = rezervacijaList.ToList();

                btnPrethodna.Enabled = rezervacijaList.HasPreviousPage;
                btnSljedeca.Enabled = rezervacijaList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, rezervacijaList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNovoZaduzenje s = new frmNovoZaduzenje(_mainForm);
            s.ShowDialog();
        }
        private void dgvRezervacije_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvRezervacije.Rows)
                height += dr.Height;
            gbRezervacije.Height = height;
            dgvRezervacije.Height = height;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvRezervacije.Columns["IzdajKnjigu"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.DarkOrange;

            for (int i = 0; i < dgvRezervacije.Rows.Count; i++)
            {
                var x = (bool)dgvRezervacije[5, i].Value;


                if (x == false)
                {
                    var cell = dgvRezervacije[7, i] = new DataGridViewTextBoxCell();
                    cell.Value = String.Empty;
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.White;
                }
            }


            btnPrethodna.Location = new Point(btnPrethodna.Location.X,gbRezervacije.Location.Y + height + 10);
            labelPage.Location = new Point(labelPage.Location.X, gbRezervacije.Location.Y + height + 20);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbRezervacije.Location.Y + height + 10);


        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }


        private async void dgvZaduzenja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRezervacije.Columns[e.ColumnIndex].Name == "IzdajKnjigu" && e.RowIndex != -1)
            {
                var rezervacijaid = dgvRezervacije.Rows[e.RowIndex].Cells[0].Value;
                var clanid = dgvRezervacije.Rows[e.RowIndex].Cells[1].Value;
                var knjigaid = dgvRezervacije.Rows[e.RowIndex].Cells[2].Value;

                var clan = dgvRezervacije.Rows[e.RowIndex].Cells[3].Value;
                var naziv = dgvRezervacije.Rows[e.RowIndex].Cells[4].Value;


                if (MessageBox.Show("Da li ste sigurni da želite izdati knjigu ˝" + naziv  + "˝ za člana " + clan + " ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RezervacijaUpsertRequest statusChange = new RezervacijaUpsertRequest();
                    statusChange.Status = false;

                    await _rezervacijaService.Update<Model.Rezervacija>((int)rezervacijaid, statusChange);

                    ZaduzenjeUpsertRequest request = new ZaduzenjeUpsertRequest()
                    {
                        ClanId = (int)clanid,
                        KnjigaId = (int)knjigaid,
                        Status = true,
                        DatumZaduzenja = DateTime.Now,
                        ProvjeriBrojZaduzenjaRezervacija = false

                    };

                    var result = await _zaduzenjeService.Insert<Model.Zaduzenje>(request);

                    if (result != null)
                    {
                        MessageBox.Show("Uspješno ste izdali knjigu ¨" + naziv + "¨ za člana " + clan + ".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainForm.OpenForm(new frmRezervacije(_mainForm));

                    }
                }
            }
        }

        private void txtKnjiga_TextChanged(object sender, EventArgs e)
        {
            var search = new RezervacijaSearchRequest()
            {
                Naziv = txtKnjiga.Text

            };

            var state = cbPrikazAktivnihRezervacija.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            if (int.TryParse(txtID.Text, out int id))
            {
                search.RezervacijaId = id;
            }

            RezervacijaInit(search);
        }

        private void cbPrikazAktivnihRezervacija_CheckedChanged(object sender, EventArgs e)
        {
            var search = new RezervacijaSearchRequest()
            {
                Naziv = txtKnjiga.Text

            };

            var state = cbPrikazAktivnihRezervacija.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            if (int.TryParse(txtID.Text, out int id))
            {
                search.RezervacijaId = id;
            }

            RezervacijaInit(search);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            var search = new RezervacijaSearchRequest()
            {
                Naziv = txtKnjiga.Text

            };

            var state = cbPrikazAktivnihRezervacija.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            if (int.TryParse(txtID.Text, out int id))
            {
                search.RezervacijaId = id;
            }

            RezervacijaInit(search);
        }
    }
}
