using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Forms.Static;
using eBiblioteka.WinUI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBiblioteka.WinUI.Forms.Clanovi
{
    public partial class frmNoviUposlenik : Form
    {
        private MainForm _mainForm;
        private APIService _apiService = new APIService("Uposlenik");
        private APIService _gradService = new APIService("Grad");
        private APIService _ulogaService = new APIService("Uloga");
        public frmNoviUposlenik(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private async void frmClanDetalji_Load(object sender, EventArgs e)
        {
            await LoadGradovi();
            await LoadUloge();
        }

        private async Task LoadGradovi()
        {
            var gradovi = await _gradService.Get<List<Model.Grad>>(null);

            gradovi.Insert(0, new Model.Grad()); // kako bi na combo boxu izbjegli automatsko selektovanje prvog polja
            cmbGrad.DataSource = gradovi;
            cmbGrad.DisplayMember = "Naziv";
            cmbGrad.ValueMember = "GradId";

        }

        private async Task LoadSlika(byte[] slika)
        {
            if(slika != null && slika.Length>0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
            }        
        }

        private async Task LoadUloge()
        {
            var uloge = await _ulogaService.Get<List<Model.Uloga>>(null);

            clbUloge.DataSource = uloge;
            clbUloge.DisplayMember = "Naziv";
        }

        #region Button-Click

        UposlenikInsertRequest request = new UposlenikInsertRequest();

        private void cbAvatar_CheckedChanged(object sender, EventArgs e)
        {
            pbSlika.Image = Properties.Resources.uposlenikavatar;
            request.SlikaPutanja = nameof(Properties.Resources.uposlenikavatar) + ".png";
            request.Slika = ImageToByte(Properties.Resources.uposlenikavatar);
        }
        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                request.SlikaPutanja = filename;

                var file = File.ReadAllBytes(filename);

                request.Slika = file;

                Image img = Image.FromFile(filename);
                pbSlika.Image = img;

            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                if (request.Slika == null || request.Slika.Length == 0)
                    MessageBox.Show("Niste dodali sliku niti postavili defaultni avatar!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    request.Ime = txtIme.Text;
                    request.Prezime = txtPrezime.Text;
                    request.DatumRodjenja = dtpDatumRodjenja.Value;
                    request.KorisnickoIme = txtKorisnickoIme.Text;
                    request.Email = txtEmail.Text;
                    request.Adresa = txtAdresa.Text;
                    request.Telefon = txtTelefon.Text;
                    request.Lozinka = txtPassword.Text;
                    request.LozinkaPotrvda = txtPasswordConfirm.Text;

                    var gradValue = cmbGrad.SelectedValue;

                    if (int.TryParse(gradValue.ToString(), out int id2))
                    {
                        request.GradId = id2;
                    }

                    request.DatumIzmjene = DateTime.Now;
                    request.DatumZaposlenja = DateTime.Now;

                    var uloge = clbUloge.CheckedItems.Cast<Model.Uloga>();
                    var ulogeList = uloge.Select(s => s.UlogaId).ToList();

                    request.Uloge = ulogeList;

                    var response = await _apiService.Insert<Model.Uposlenik>(request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste dodali uposlenika.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion


        #region Validacija

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            Regex ime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");

            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                labelIme.ForeColor = Color.Red;
                errorProvider.SetError(txtIme, Properties.Resources.ObaveznoPolje);
            }
            else if (!ime.IsMatch(txtIme.Text))
            {
                labelIme.ForeColor = Color.Red;
                errorProvider.SetError(txtIme, Properties.Resources.ImeNeispravanFormat);
            }
            else
            {
                labelIme.ForeColor = Color.Black;
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            Regex prezime = new Regex(@"^\p{Lu}{1}[\p{Ll}\s\d]{2,29}$");

            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                labelPrezime.ForeColor = Color.Red;
                errorProvider.SetError(txtPrezime, Properties.Resources.ObaveznoPolje);
            }
            else if (!prezime.IsMatch(txtPrezime.Text))
            {
                labelPrezime.ForeColor = Color.Red;
                errorProvider.SetError(txtPrezime, Properties.Resources.ImeNeispravanFormat);
            }
            else
            {
                labelPrezime.ForeColor = Color.Black;
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            Regex telefon = new Regex(@"^([0-9]){3}(-|/|\s)?([0-9]){3}(-|/|\s)?([0-9]){3,4}$");

            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                labelTelefon.ForeColor = Color.Red;
                errorProvider.SetError(txtTelefon, Properties.Resources.ObaveznoPolje);
            }
            else if (!telefon.IsMatch(txtTelefon.Text))
            {
                labelTelefon.ForeColor = Color.Red;
                errorProvider.SetError(txtTelefon, Properties.Resources.TelefonNeispravanFormat);
            }
            else
            {
                labelTelefon.ForeColor = Color.Black;
                errorProvider.SetError(txtTelefon, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex email = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                labelEmail.ForeColor = Color.Red;
                errorProvider.SetError(txtEmail, Properties.Resources.ObaveznoPolje);
            }
            else if (!email.IsMatch(txtEmail.Text))
            {
                labelEmail.ForeColor = Color.Red;
                errorProvider.SetError(txtEmail, Properties.Resources.NeispravanFormat);
            }
            else
            {
                labelEmail.ForeColor = Color.Black;
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdresa.Text))
            {
                labelAdresa.ForeColor = Color.Red;
                errorProvider.SetError(txtAdresa, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelAdresa.ForeColor = Color.Black;
                errorProvider.SetError(txtAdresa, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text))
            {
                labelKorisnickoIme.ForeColor = Color.Red;
                errorProvider.SetError(txtKorisnickoIme, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelKorisnickoIme.ForeColor = Color.Black;
                errorProvider.SetError(txtKorisnickoIme, null);
            }
        }

        private void cmbGrad_Validating(object sender, CancelEventArgs e)
        {

            if (cmbGrad.SelectedValue == null)
            {
                labelGrad.ForeColor = Color.Red;
                errorProvider.SetError(cmbGrad, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbGrad.SelectedIndex.ToString()) == 0)
            {
                labelGrad.ForeColor = Color.Red;
                errorProvider.SetError(cmbGrad, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelGrad.ForeColor = Color.Black;
                errorProvider.SetError(cmbGrad, null);
            }
        }


        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                labelLozinka.ForeColor = Color.Red;
                errorProvider.SetError(txtPassword, Properties.Resources.ObaveznoPolje);
            }
            else if (!string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text.Length < 4)
            {
                labelLozinka.ForeColor = Color.Red;
                errorProvider.SetError(txtPassword, Properties.Resources.DuzinaFormat);
            }
            else
            {
                labelLozinka.ForeColor = Color.Black;
                errorProvider.SetError(txtPassword, null);
            }
        }
        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordConfirm.Text))
            {
                labelLozinkaPotvrda.ForeColor = Color.Red;
                errorProvider.SetError(txtPasswordConfirm, Properties.Resources.ObaveznoPolje);
            }
            else if (!string.IsNullOrWhiteSpace(txtPasswordConfirm.Text) && txtPasswordConfirm.Text.Length < 4)
            {
                labelLozinkaPotvrda.ForeColor = Color.Red;
                errorProvider.SetError(txtPasswordConfirm, Properties.Resources.DuzinaFormat);
            }
            else if (txtPasswordConfirm.Text.Length >= 4 && txtPassword.Text.Length >= 4 && txtPasswordConfirm.Text != txtPassword.Text)
            {
                labelLozinkaPotvrda.ForeColor = Color.Red;
                errorProvider.SetError(txtPasswordConfirm, Properties.Resources.LozinkaFail);
            }
            else
            {
                labelLozinkaPotvrda.ForeColor = Color.Black;
                errorProvider.SetError(txtPasswordConfirm, null);
            }
        }


        private void clbUloge_Validating(object sender, CancelEventArgs e)
        {
            if (clbUloge.CheckedItems.Count == 0)
            {
                gbUloge.ForeColor = Color.Red;
                errorProvider.SetError(clbUloge, Properties.Resources.UlogeFormat);
            }
            else
            {
                gbUloge.ForeColor = Color.Black;
                errorProvider.SetError(clbUloge, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtPrezime).Length > 0)
                return false;

            if (errorProvider.GetError(txtKorisnickoIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtTelefon).Length > 0)
                return false;

            if (errorProvider.GetError(txtEmail).Length > 0)
                return false;

            if (errorProvider.GetError(txtAdresa).Length > 0)
                return false;

            if (errorProvider.GetError(cmbGrad).Length > 0)
                return false;

            if (errorProvider.GetError(txtPassword).Length > 0)
                return false;

            if (errorProvider.GetError(clbUloge).Length > 0)
                return false;

            return true;
        }

        #endregion


        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

    }
}
