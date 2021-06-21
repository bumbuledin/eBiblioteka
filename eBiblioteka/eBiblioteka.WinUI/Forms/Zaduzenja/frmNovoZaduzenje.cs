using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Forms.Clanovi;
using eBiblioteka.WinUI.Forms.Static;
using eBiblioteka.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBiblioteka.WinUI.Forms.Knjige
{
    public partial class frmNovoZaduzenje : Form
    {
        private APIService _zaduzenjeService = new APIService("Zaduzenje");
        private APIService _clanService = new APIService("Clan");
        private APIService _knjigaService = new APIService("Knjiga");

        private MainForm _mainForm;
        public frmNovoZaduzenje(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private async void frmNovoZaduzenje_Load(object sender, EventArgs e)
        {
            await LoadClan();
            await LoadKnjige();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private async Task LoadClan()
        {
            var clanovi = await _clanService.Get<List<Model.Clan>>(null);

            clanovi.Insert(0, new Model.Clan());
            cmbClanovi.DataSource = clanovi;
            cmbClanovi.DisplayMember = "ImePrezime";
            cmbClanovi.ValueMember = "ClanId";
        }

        private async Task LoadKnjige()
        {
            var knjige = await _knjigaService.Get<List<Model.Knjiga>>(null);

            knjige.Insert(0, new Model.Knjiga());
            cmbKnjige.DataSource = knjige;
            cmbKnjige.DisplayMember = "Naziv";
            cmbKnjige.ValueMember = "KnjigaId";
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {

                ZaduzenjeUpsertRequest request = new ZaduzenjeUpsertRequest();

                var clanValue = cmbClanovi.SelectedValue;

                if (int.TryParse(clanValue.ToString(), out int clan))
                {
                    request.ClanId = clan;
                }

                var knjigaValue = cmbKnjige.SelectedValue;

                if (int.TryParse(knjigaValue.ToString(), out int knjiga))
                {
                    request.KnjigaId = knjiga;
                }

                request.Status = true;
                request.DatumZaduzenja = DateTime.Now;
                request.ProvjeriBrojZaduzenjaRezervacija = true;

                var response = await _zaduzenjeService.Insert<Model.Zaduzenje>(request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste dodali zaduženje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mainForm.OpenForm(new frmZaduzenja(_mainForm));
                }
            }

            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cmbClanovi_Validating(object sender, CancelEventArgs e)
        {
            if (cmbClanovi.SelectedValue == null)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbClanovi, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbClanovi.SelectedIndex.ToString()) == 0)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbClanovi, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelClan.ForeColor = Color.Black;
                errorProvider.SetError(cmbClanovi, null);
            }
        }

        private void cmbKnjige_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKnjige.SelectedValue == null)
            {
                labelKnjiga.ForeColor = Color.Red;
                errorProvider.SetError(cmbKnjige, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbKnjige.SelectedIndex.ToString()) == 0)
            {
                labelKnjiga.ForeColor = Color.Red;
                errorProvider.SetError(cmbKnjige, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelKnjiga.ForeColor = Color.Black;
                errorProvider.SetError(cmbKnjige, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(cmbKnjige).Length > 0)
                return false;

            if (errorProvider.GetError(cmbClanovi).Length > 0)
                return false;

            return true;
        }

    }
}
