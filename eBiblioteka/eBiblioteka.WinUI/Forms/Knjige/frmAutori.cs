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
    public partial class frmAutori : Form
    {
        private readonly APIService _autorService = new APIService("Autor");
        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize =7;
        private List<Model.Autor> apiList;
        private IPagedList<Model.Autor> autoriList;

        public frmAutori(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            AutorInit();
        }

        public async void AutorInit(AutorSearchRequest search=null)
        {
            
            apiList = await _autorService.Get<List<Model.Autor>>(search);
            autoriList = apiList.ToPagedList(pageNumber, pageSize);

            dgvAutori.AutoGenerateColumns = false;
            dgvAutori.DataSource = autoriList.ToList();

            btnPrethodna.Enabled = autoriList.HasPreviousPage;
            btnSljedeca.Enabled = autoriList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, autoriList.PageCount);

        }

        //Button click actions
        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(autoriList.HasPreviousPage)
            {
                autoriList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvAutori.AutoGenerateColumns = false;
                dgvAutori.DataSource = autoriList.ToList();

                btnPrethodna.Enabled = autoriList.HasPreviousPage;
                btnSljedeca.Enabled = autoriList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, autoriList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(autoriList.HasNextPage)
            {
                autoriList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvAutori.AutoGenerateColumns = false;
                dgvAutori.DataSource = autoriList.ToList();

                btnPrethodna.Enabled = autoriList.HasPreviousPage;
                btnSljedeca.Enabled = autoriList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, autoriList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNoviAutor s = new frmNoviAutor(_mainForm);
            s.ShowDialog();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }



        //DataGridView actions
        private void dgvAutori_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvAutori.Rows)
                height += dr.Height;
            gbAutori.Height = height;
            dgvAutori.Height = height;

            DataGridViewButtonColumn d = (DataGridViewButtonColumn)dgvAutori.Columns["Uredi"];
            d.FlatStyle = FlatStyle.Popup;
            d.DefaultCellStyle.ForeColor = Color.Black;
            d.DefaultCellStyle.BackColor = Color.LimeGreen;

            btnPrethodna.Location = new Point(btnPrethodna.Location.X,gbAutori.Location.Y + height + 15);
            labelPage.Location = new Point(labelPage.Location.X, gbAutori.Location.Y + height + 25);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbAutori.Location.Y + height + 15);
            btnDodaj.Location = new Point(btnDodaj.Location.X, gbAutori.Location.Y + height + 15);
        }

        private  void dgvAutori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dgvAutori.Columns[e.ColumnIndex].Name == "Uredi" && e.RowIndex != -1)
            {
                var id = (int)dgvAutori.Rows[e.RowIndex].Cells[0].Value;

                frmAutorUpdate frm = new frmAutorUpdate(_mainForm, id);
                frm.ShowDialog();

            }
        }



        //Search
       
        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            var search = new AutorSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };

            

            AutorInit(search);
        }

        private void txtIme_TextChanged(object sender, EventArgs e)
        {
            var search = new AutorSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };


            AutorInit(search);
        }
    }
}
