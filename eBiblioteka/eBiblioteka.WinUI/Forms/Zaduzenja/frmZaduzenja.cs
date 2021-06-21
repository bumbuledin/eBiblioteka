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
    public partial class frmZaduzenja : Form
    {
        private readonly APIService _zaduzenjeService = new APIService("Zaduzenje");
        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize =13;
        private List<Model.Zaduzenje> apiList;
        private IPagedList<Model.Zaduzenje> zaduzenjeList;

        public frmZaduzenja(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            ZaduzenjeInit();
        }

        public async void ZaduzenjeInit(ZaduzenjeSearchRequest search=null)
        {

            apiList = await _zaduzenjeService.Get<List<Model.Zaduzenje>>(search);
            zaduzenjeList = apiList.ToPagedList(pageNumber, pageSize);

            dgvZaduzenja.AutoGenerateColumns = false;
            dgvZaduzenja.DataSource = zaduzenjeList.ToList();

            btnPrethodna.Enabled = zaduzenjeList.HasPreviousPage;
            btnSljedeca.Enabled = zaduzenjeList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, zaduzenjeList.PageCount);

        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(zaduzenjeList.HasPreviousPage)
            {
                zaduzenjeList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvZaduzenja.AutoGenerateColumns = false;
                dgvZaduzenja.DataSource = zaduzenjeList.ToList();

                btnPrethodna.Enabled = zaduzenjeList.HasPreviousPage;
                btnSljedeca.Enabled = zaduzenjeList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, zaduzenjeList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(zaduzenjeList.HasNextPage)
            {
                zaduzenjeList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvZaduzenja.AutoGenerateColumns = false;
                dgvZaduzenja.DataSource = zaduzenjeList.ToList();

                btnPrethodna.Enabled = zaduzenjeList.HasPreviousPage;
                btnSljedeca.Enabled = zaduzenjeList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, zaduzenjeList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNovoZaduzenje s = new frmNovoZaduzenje(_mainForm);
            s.ShowDialog();
        }
        private void dgvUplate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvZaduzenja.Rows)
                height += dr.Height;
            gbAutori.Height = height;
            dgvZaduzenja.Height = height;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvZaduzenja.Columns["PotvrdiVracanjeKnjige"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.DarkOrange;

            for (int i = 0; i < dgvZaduzenja.Rows.Count; i++)
            {
                var x = (bool)dgvZaduzenja[3, i].Value;

                if (x == false)
                {
                    var cell = dgvZaduzenja[6, i] = new DataGridViewTextBoxCell();
                    cell.Value = String.Empty;
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.White;
                }
            }


            btnPrethodna.Location = new Point(btnPrethodna.Location.X,gbAutori.Location.Y + height + 15);
            labelPage.Location = new Point(labelPage.Location.X, gbAutori.Location.Y + height + 25);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbAutori.Location.Y + height + 15);
            btnDodaj.Location = new Point(btnDodaj.Location.X, gbAutori.Location.Y + height + 15);


        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }


        private async void dgvZaduzenja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvZaduzenja.Columns[e.ColumnIndex].Name == "PotvrdiVracanjeKnjige" && e.RowIndex != -1)
            {
                var id = dgvZaduzenja.Rows[e.RowIndex].Cells[0].Value;
                var clan = dgvZaduzenja.Rows[e.RowIndex].Cells[1].Value;
                var naziv = dgvZaduzenja.Rows[e.RowIndex].Cells[2].Value;


                if (MessageBox.Show("Da li ste sigurni da želite potvrditi vraćanje knjige ˝" + naziv  + "˝ za člana " + clan + " ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ZaduzenjeUpsertRequest request = new ZaduzenjeUpsertRequest()
                    {
                        Status = false,
                        DatumVracanja = DateTime.Now
                    };

                    var result = await _zaduzenjeService.Update<Model.Zaduzenje>((int)id, request);

                    if (result != null)
                        _mainForm.OpenForm(new frmZaduzenja(_mainForm));
                }
            }
        }

        private void cbPrikazAktivnihZaduzenja_CheckedChanged(object sender, EventArgs e)
        {
            var search = new ZaduzenjeSearchRequest()
            {
                ClanIme = txtClan.Text,
                Knjiga = txtKnjiga.Text,

            };

            var state = cbPrikazAktivnihZaduzenja.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            if (int.TryParse(txtID.Text, out int id))
            {
                search.ZaduzenjeId = id;
            }

            ZaduzenjeInit(search);
        }


        private void txtID_TextChanged(object sender, EventArgs e)
        {
            var search = new ZaduzenjeSearchRequest()
            {
                ClanIme = txtClan.Text,
                Knjiga = txtKnjiga.Text,

            };

            var state = cbPrikazAktivnihZaduzenja.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            if(int.TryParse(txtID.Text, out int id))
            {
                search.ZaduzenjeId = id;
            }

            ZaduzenjeInit(search);
        }

        private void txtKnjiga_TextChanged(object sender, EventArgs e)
        {
            var search = new ZaduzenjeSearchRequest()
            {
                ClanIme = txtClan.Text,
                Knjiga = txtKnjiga.Text,

            };

            var state = cbPrikazAktivnihZaduzenja.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            ZaduzenjeInit(search);
        }

        private void txtClan_TextChanged(object sender, EventArgs e)
        {
            var search = new ZaduzenjeSearchRequest()
            {
                ClanIme = txtClan.Text,
                Knjiga = txtKnjiga.Text,
          
            };

            var state = cbPrikazAktivnihZaduzenja.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            ZaduzenjeInit(search);
        }
    }
}
