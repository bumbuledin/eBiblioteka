using eBiblioteka.Model.Requests;
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
    public partial class frmUplate : Form
    {
        private readonly APIService _uplataService = new APIService("Uplata");
        private int _clanId;
        private MainForm _mainForm;
        private int pageNumber = 1;
        private int pageSize = 10;
        private List<Model.Uplata> apiList;
        private IPagedList<Model.Uplata> uplateList;



        public frmUplate(MainForm mainform, int clanId)
        {
            InitializeComponent();
            _clanId = clanId;
            _mainForm = mainform;

        }
        private void frmUplate_Load(object sender, EventArgs e)
        {
            UplataInit();
        }

        public async void UplataInit()
        {
            var search = new UplataSearchRequest() { ClanId = _clanId };
            apiList = await _uplataService.Get<List<Model.Uplata>>(search);
            uplateList = apiList.ToPagedList(pageNumber, pageSize);

            dgvUplate.AutoGenerateColumns = false;
            dgvUplate.DataSource = uplateList.ToList();

            btnPrethodna.Enabled = uplateList.HasPreviousPage;
            btnSljedeca.Enabled = uplateList.HasNextPage;
            labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uplateList.PageCount);

        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            if(uplateList.HasPreviousPage)
            {
                uplateList = apiList.ToPagedList(--pageNumber, pageSize);

                dgvUplate.AutoGenerateColumns = false;
                dgvUplate.DataSource = uplateList.ToList();

                btnPrethodna.Enabled = uplateList.HasPreviousPage;
                btnSljedeca.Enabled = uplateList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uplateList.PageCount);
            }
        }
        private void btnSljedeca_Click(object sender, EventArgs e)
        {
            if(uplateList.HasNextPage)
            {
                uplateList = apiList.ToPagedList(++pageNumber, pageSize);

                dgvUplate.AutoGenerateColumns = false;
                dgvUplate.DataSource = uplateList.ToList();

                btnPrethodna.Enabled = uplateList.HasPreviousPage;
                btnSljedeca.Enabled = uplateList.HasNextPage;
                labelPage.Text = string.Format("Page {0}/{1}", pageNumber, uplateList.PageCount);
            }
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNovaUplata uplata = new frmNovaUplata(_mainForm, _clanId);
            uplata.ShowDialog();
        }
        private void dgvUplate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 80;
            foreach (DataGridViewRow dr in dgvUplate.Rows)
                height += dr.Height;
            gbUplate.Height = height;
            dgvUplate.Height = height;

            DataGridViewButtonColumn c = (DataGridViewButtonColumn)dgvUplate.Columns["Obrisi"];
            c.FlatStyle = FlatStyle.Popup;
            c.DefaultCellStyle.ForeColor = Color.Black;
            c.DefaultCellStyle.BackColor = Color.Tomato;

            btnPrethodna.Location = new Point(btnPrethodna.Location.X,gbUplate.Location.Y + height + 15);
            labelPage.Location = new Point(labelPage.Location.X, gbUplate.Location.Y + height + 25);
            btnSljedeca.Location = new Point(btnSljedeca.Location.X, gbUplate.Location.Y + height + 15);
            btnDodaj.Location = new Point(btnDodaj.Location.X, gbUplate.Location.Y + height + 15);

        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmPregledClanova(_mainForm));
        }

        private async void dgvUplate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUplate.Columns[e.ColumnIndex].Name == "Obrisi" && e.RowIndex != -1)
            {
                var id = dgvUplate.Rows[e.RowIndex].Cells[0].Value;
                var datum = dgvUplate.Rows[e.RowIndex].Cells[1].Value;
                var iznos = dgvUplate.Rows[e.RowIndex].Cells[4].Value;


                if (MessageBox.Show("Da li ste sigurni da želite izbrisati uplatu u iznosu " + iznos + " , na datum " + datum +" ?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var x = await _uplataService.Delete<bool>((int)id);

                    if (x == true)
                    {
                        MessageBox.Show("Uspješno ste izbrisali uplatu.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _mainForm.OpenForm(new frmUplate(_mainForm,_clanId));

                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom brisanja uplate.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
        }
    }
}
