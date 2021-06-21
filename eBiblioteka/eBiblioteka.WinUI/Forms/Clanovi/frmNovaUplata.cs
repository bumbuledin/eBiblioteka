using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Forms.Static;
using eBiblioteka.WinUI.Services;
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
    public partial class frmNovaUplata : Form
    {
        private int? _clanId = null;
        private MainForm _mainForm;
        private APIService _clanoviService = new APIService("Clan");
        private APIService _vrstaUplateService = new APIService("VrstaUplate");
        private APIService _uplataService = new APIService("Uplata");


        public frmNovaUplata(MainForm mainForm,int? clanId = null)
        {
            InitializeComponent();
            _clanId = clanId;
            _mainForm = mainForm;
        }

        public async Task LoadClanovi()
        {
            var list = new List<Model.Clan>();

            if (_clanId == null)
            {
                var request = await _clanoviService.Get<List<Model.Clan>>(null);
                request.Insert(0, new Model.Clan()); // kako bi na combo boxu izbjegli automatsko selektovanje prvog polja
                list = request;
            }
            else
            {
                var request = await _clanoviService.GetById<Model.Clan>(_clanId);
                list.Add(request);
            }

            cmbClanovi.DataSource = list;
            cmbClanovi.DisplayMember = "ImePrezime";
            cmbClanovi.ValueMember = "ClanId";
        }

        public async Task LoadVrstaUplate()
        {
            var request = await _vrstaUplateService.Get<List<Model.VrstaUplate>>(null);
            request.Insert(0, new Model.VrstaUplate());
            cmbTipUplate.DataSource = request;
            cmbTipUplate.DisplayMember = "Naziv";
            cmbTipUplate.ValueMember = "VrstaUplateId";
        }

        private async void frmNovaUplata_Load(object sender, EventArgs e)
        {
            await LoadClanovi();
            await LoadVrstaUplate();
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                var request = new UplataUpsertRequest()
                {
                    IznosUplate = txtIznos.Value,
                    DatumUplate = dtpDatumUplate.Value
                };

                var clanValue = cmbClanovi.SelectedValue;
                var vrstaUplateValue = cmbTipUplate.SelectedValue;

                if (int.TryParse(clanValue.ToString(), out int id1))
                {
                    request.ClanId = id1;
                }

                if (int.TryParse(vrstaUplateValue.ToString(), out int id2))
                {
                    request.VrstaUplateId = id2;
                }

                var result = await _uplataService.Insert<Model.Uplata>(request);

                if (result != null)
                {
                    MessageBox.Show("Uspješno ste dodali uplatu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var x = _mainForm.GetActiveForm();

                    if (x != null)
                        if(x.Name == "frmUplate" && _clanId != null)
                            _mainForm.OpenForm(new frmUplate(_mainForm, (int)_clanId));


                }
            } 
            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        #region Validacija
        private void cmbClanovi_Validating(object sender, CancelEventArgs e)
        {
            if(cmbClanovi.SelectedValue == null)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbClanovi, Properties.Resources.ObaveznoPolje);
            }
            else if(int.Parse(cmbClanovi.SelectedValue.ToString()) == 0)
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

        private void cmbTipUplate_Validating(object sender, CancelEventArgs e)
        {
            if(cmbTipUplate.SelectedValue == null)
            {
                labelTipUplate.ForeColor = Color.Red;
                errorProvider.SetError(cmbTipUplate, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbTipUplate.SelectedValue.ToString()) == 0)
            {
                labelTipUplate.ForeColor = Color.Red;
                errorProvider.SetError(cmbTipUplate, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelTipUplate.ForeColor = Color.Black;
                errorProvider.SetError(cmbTipUplate, null);
            }
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            if (txtIznos.Value <= 0)
            {
                labelznos.ForeColor = Color.Red;
                errorProvider.SetError(txtIznos, Properties.Resources.IznosUplate);
            }
            else
            {
                labelznos.ForeColor = Color.Black;
                errorProvider.SetError(txtIznos, null);
            }

        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtIznos).Length > 0)
                return false;

            if (errorProvider.GetError(cmbClanovi).Length >0)
                return false;

            if (errorProvider.GetError(cmbTipUplate).Length>0)
                return false;

            return true;
        }

        #endregion

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmUplate(_mainForm, (int)_clanId));

        }
    }
}
