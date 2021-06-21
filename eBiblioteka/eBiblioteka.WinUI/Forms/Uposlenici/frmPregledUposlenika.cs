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
    public partial class frmPregledUposlenika : Form
    {
        private readonly APIService _apiService = new APIService("Uposlenik");
        private readonly MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize = 8;
        private List<Model.Uposlenik> apiList;
        private IPagedList<Model.Uposlenik> uposlenikList;

        public frmPregledUposlenika(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void frmPregledUposlenika_Load(object sender, EventArgs e)
        {
            UposlenikInit();

        }

        public async void UposlenikInit(UposlenikSearchRequest search = null)
        {
            if (search == null && cbPrikazAktivnihUposlenika.Checked == true)
            {
                search = new UposlenikSearchRequest();
                search.Status = true;
            }

            apiList = await _apiService.Get<List<Model.Uposlenik>>(search);
            uposlenikList = apiList.ToPagedList(pageNumber, pageSize);

            dgvUposlenici.AutoGenerateColumns = false;
            dgvUposlenici.DataSource = uposlenikList.ToList();

            btnPrethodna.Enabled = uposlenikList.HasPreviousPage;
            btnSljedeca.Enabled = uposlenikList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uposlenikList.PageCount);

        }

        private void dgvUposlenici_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvUposlenici.Rows)
                height += dr.Height;
        
            gbUposlenici.MaximumSize = new Size(2000, height);
            dgvUposlenici.MaximumSize = new Size(2000, height);


            gbUposlenici.Height = height;
            dgvUposlenici.Height = height;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvUposlenici.Columns["Deaktiviraj"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.Tomato;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvUposlenici.Columns["Detalji"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.LimeGreen;

            for (int i = 0; i < dgvUposlenici.Rows.Count; i++)
            {
                var x = (bool)dgvUposlenici[5, i].Value;
                if (x == false)
                {
                    var cell = dgvUposlenici[7, i] = new DataGridViewTextBoxCell();
                    cell.Value = String.Empty;
                    cell.ReadOnly = true;
                    cell.Style.BackColor = Color.White;
                }
            }

            btnPrethodna.Location = new Point(btnPrethodna.Location.X, gbUposlenici.Location.Y + height + 10);
            labelPage.Location = new Point(labelPage.Location.X, gbUposlenici.Location.Y + height + 20);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbUposlenici.Location.Y + height + 10);
        }

        private async void dgvUposlenici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUposlenici.Columns[e.ColumnIndex].Name == "Deaktiviraj" && e.RowIndex != -1)
            {
                var id = dgvUposlenici.Rows[e.RowIndex].Cells[0].Value;
                var ime = dgvUposlenici.Rows[e.RowIndex].Cells[1].Value;
                var prezime = dgvUposlenici.Rows[e.RowIndex].Cells[2].Value;

                if (MessageBox.Show("Da li ste sigurni da želite izmjenuti status uposlenika " + ime + " " + prezime + " u neaktivan ? Opcija logiranja će biti zabranjenja za odabranog uposlenika. Želite li nastaviti ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        var x = await _apiService.Delete<bool>((int)id);
                        if (x == true)
                        {
                            MessageBox.Show("Uspješno ste izmjenuli status uposlenika " + ime + " " + prezime + " u neaktivan.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _mainForm.OpenForm(new frmPregledUposlenika(_mainForm));

                        }
                            

                    }
                    catch (Exception)
                    {
                    }
                    
                    //else
                    //{
                    //    MessageBox.Show("Došlo je do greške prilikom izmjene statusa uposlenika " + ime + " " + prezime + ".", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //}
                }
            }
            else if (dgvUposlenici.Columns[e.ColumnIndex].Name == "Detalji" && e.RowIndex != -1)
            {
                var id = (int)dgvUposlenici.Rows[e.RowIndex].Cells[0].Value;

                _mainForm.OpenFormAndAddTitle(new frmUposlenikDetalji(_mainForm, id));

            }
        }

        private void cbPrikazAktivnihUposlenika_CheckedChanged(object sender, EventArgs e)
        {
            var search = new UposlenikSearchRequest()
            {
                Ime = txtImePretraga.Text,
                Prezime = txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihUposlenika.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            UposlenikInit(search);

        }

        private void txtPrezimePretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new UposlenikSearchRequest()
            {
                Ime=txtImePretraga.Text,
                Prezime=txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihUposlenika.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            UposlenikInit(search);
        }

        private void txtImePretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new UposlenikSearchRequest()
            {
                Ime = txtImePretraga.Text,
                Prezime = txtPrezimePretraga.Text
            };

            var state = cbPrikazAktivnihUposlenika.Checked;

            if (state == true)
            {
                search.Status = true;
            }

            UposlenikInit(search);
        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if (uposlenikList.HasPreviousPage)
            {
                uposlenikList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvUposlenici.AutoGenerateColumns = false;
                dgvUposlenici.DataSource = uposlenikList.ToList();

                btnPrethodna.Enabled = uposlenikList.HasPreviousPage;
                btnSljedeca.Enabled = uposlenikList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uposlenikList.PageCount);
            }
        }

        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if (uposlenikList.HasNextPage)
            {
                uposlenikList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvUposlenici.AutoGenerateColumns = false;
                dgvUposlenici.DataSource = uposlenikList.ToList();

                btnPrethodna.Enabled = uposlenikList.HasPreviousPage;
                btnSljedeca.Enabled = uposlenikList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uposlenikList.PageCount);
            }
        }

    }
    
}
