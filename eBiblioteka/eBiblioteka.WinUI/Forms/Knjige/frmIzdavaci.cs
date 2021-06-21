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
    public partial class frmIzdavaci : Form
    {
        private readonly APIService _izdavacService = new APIService("Izdavac");
        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize =7;
        private List<Model.Izdavac> apiList;
        private IPagedList<Model.Izdavac> izdavacList;



        public frmIzdavaci(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            IzdavacInit();
        }

        public async void IzdavacInit(IzdavacSearchRequest search=null)
        {
            
            apiList = await _izdavacService.Get<List<Model.Izdavac>>(search);
            izdavacList = apiList.ToPagedList(pageNumber, pageSize);

            dgvIzdavaci.AutoGenerateColumns = false;
            dgvIzdavaci.DataSource = izdavacList.ToList();

            btnPrethodna.Enabled = izdavacList.HasPreviousPage;
            btnSljedeca.Enabled = izdavacList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, izdavacList.PageCount);

        }


        //Button click actions
        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(izdavacList.HasPreviousPage)
            {
                izdavacList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvIzdavaci.AutoGenerateColumns = false;
                dgvIzdavaci.DataSource = izdavacList.ToList();

                btnPrethodna.Enabled = izdavacList.HasPreviousPage;
                btnSljedeca.Enabled = izdavacList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, izdavacList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(izdavacList.HasNextPage)
            {
                izdavacList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvIzdavaci.AutoGenerateColumns = false;
                dgvIzdavaci.DataSource = izdavacList.ToList();

                btnPrethodna.Enabled = izdavacList.HasPreviousPage;
                btnSljedeca.Enabled = izdavacList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, izdavacList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNoviIzdavac s = new frmNoviIzdavac(_mainForm);
            s.ShowDialog();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }


        // DataGridView actions
        private void dgvIzdavaci_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvIzdavaci.Rows)
                height += dr.Height;
            gbIzdavaci.Height = height;
            dgvIzdavaci.Height = height;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvIzdavaci.Columns["Uredi"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.LimeGreen;


            btnPrethodna.Location = new Point(btnPrethodna.Location.X, gbIzdavaci.Location.Y + height + 15);
            labelPage.Location = new Point(labelPage.Location.X, gbIzdavaci.Location.Y + height + 25);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbIzdavaci.Location.Y + height + 15);
            btnDodaj.Location = new Point(btnDodaj.Location.X, gbIzdavaci.Location.Y + height + 15);


        }
        private  void dgvIzdavaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dgvIzdavaci.Columns[e.ColumnIndex].Name == "Uredi" && e.RowIndex != -1)
            {
                var id = (int)dgvIzdavaci.Rows[e.RowIndex].Cells[0].Value;

                frmIzdavacUpdate frm = new frmIzdavacUpdate(_mainForm, id);
                frm.ShowDialog();

            }
        }


        //Search
        private void cbPrikazAktivnihIzdavaca_CheckedChanged(object sender, EventArgs e)
        {
            var search = new IzdavacSearchRequest()
            {
                Naziv = txtNazivPretraga.Text
            };


            IzdavacInit(search);
        }
        private void txtNazivPretraga_TextChanged(object sender, EventArgs e)
        {
            var search = new IzdavacSearchRequest()
            {
                Naziv = txtNazivPretraga.Text
            };

            IzdavacInit(search);
        }

    }
}
