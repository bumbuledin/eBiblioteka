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
    public partial class frmKnjigaUpdate : Form
    {
        private MainForm _mainForm;
        private APIService _knjigaService = new APIService("Knjiga");
        private APIService _autorService = new APIService("Autor");
        private APIService _kategorijaService = new APIService("Kategorija");
        private APIService _izdavacService = new APIService("Izdavac");
        private int? _knjigaId;



        public frmKnjigaUpdate(MainForm mainForm,int? knjigaId = null)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _knjigaId = knjigaId;
        }

        private async void frmClanDetalji_Load(object sender, EventArgs e)
        {
            if (_knjigaId.HasValue)
            {
                var knjiga = await _knjigaService.GetById<Model.Knjiga>(_knjigaId);

                await LoadAutor();
                await LoadKategorija();
                await LoadIzdavac();
                await LoadSlika(knjiga.Slika);

                txtNaziv.Text = knjiga.Naziv;
                txtBrojStranica.Text = knjiga.BrojStranica.ToString();
                txtUkupnoNaStanju.Text = knjiga.BrojKnjigaNaStanju.ToString();
                txtInventarniBroj.Text = knjiga.InventarniBroj;
                txtGodinaIzdavanja.Text = knjiga.GodinaIzdavanja;
                rtbOpis.Text = knjiga.Opis;

                cmbAutor.SelectedIndex = cmbAutor.FindString(knjiga.ImePrezime);
                cmbIzdavac.SelectedIndex = cmbIzdavac.FindString(knjiga.Izdavac.Naziv);
                cmbKategorija.SelectedIndex = cmbKategorija.FindString(knjiga.Kategorija.Naziv);


            }


        }

        private async Task LoadAutor()
        {
            var autori = await _autorService.Get<List<Model.Autor>>(null);

            cmbAutor.DataSource = autori;
            cmbAutor.DisplayMember = "ImePrezime";
            cmbAutor.ValueMember = "AutorId";
        }

        private async Task LoadKategorija()
        {
            var kategorija = await _kategorijaService.Get<List<Model.Kategorija>>(null);

            cmbKategorija.DataSource = kategorija;
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "KategorijaId";
        }
        private async Task LoadIzdavac()
        {
            var izdavac = await _izdavacService.Get<List<Model.Izdavac>>(null);

            cmbIzdavac.DataSource = izdavac;
            cmbIzdavac.DisplayMember = "Naziv";
            cmbIzdavac.ValueMember = "IzdavacId";
        }

        private async Task LoadSlika(byte[] slika)
        {
            if (slika != null && slika.Length > 0)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(slika));
                pbSlika.Image = x;
            }

        }


        #region Button-Click

        KnjigaUpsertRequest request = new KnjigaUpsertRequest();

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
                request.Naziv = txtNaziv.Text;
                request.InventarniBroj = txtInventarniBroj.Text;
                request.Opis = rtbOpis.Text;
                request.GodinaIzdavanja = txtGodinaIzdavanja.Text;

                var autorValue = cmbAutor.SelectedValue;

                if (int.TryParse(autorValue.ToString(), out int autor))
                {
                    request.AutorId = autor;
                }

                var kategorijaValue = cmbKategorija.SelectedValue;

                if (int.TryParse(kategorijaValue.ToString(), out int kategorija))
                {
                    request.KategorijaId = kategorija;
                }

                var izdavacValue = cmbIzdavac.SelectedValue;

                if (int.TryParse(izdavacValue.ToString(), out int izdavac))
                {
                    request.IzdavacId = izdavac;
                }

                if (int.TryParse(txtBrojStranica.Text.ToString(), out int brstr))
                {
                    request.BrojStranica = brstr;
                }

                if (int.TryParse(txtUkupnoNaStanju.Text.ToString(), out int ukupno))
                {
                    request.BrojKnjigaNaStanju = ukupno;
                }

                var response = await _knjigaService.Update<Model.Knjiga>((int)_knjigaId,request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste izmjenuli knjigu - " + response.Naziv, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    request.SlikaPutanja = response.SlikaPutanja;
                }
            }
            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #endregion

        #region Validacija

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            Regex Naziv = new Regex(@"^\p{Lu}{1}[\p{Ll}\p{Lu}\s\d]{2,29}$");

            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                labelNaziv.ForeColor = Color.Red;
                errorProvider.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
            }
            else if (!Naziv.IsMatch(txtNaziv.Text))
            {
                labelNaziv.ForeColor = Color.Red;
                errorProvider.SetError(txtNaziv, Properties.Resources.NazivNeispravanFormat);
            }
            else
            {
                labelNaziv.ForeColor = Color.Black;
                errorProvider.SetError(txtNaziv, null);
            }
        }

        private void txtInventarniBroj_Validating(object sender, CancelEventArgs e)
        {
            Regex broj = new Regex(@"^[0-9]{6,9}$");

            if (string.IsNullOrWhiteSpace(txtInventarniBroj.Text))
            {
                labelInventarniBroj.ForeColor = Color.Red;
                errorProvider.SetError(txtInventarniBroj, Properties.Resources.ObaveznoPolje);
            }
            else if (!broj.IsMatch(txtInventarniBroj.Text))
            {
                labelInventarniBroj.ForeColor = Color.Red;
                errorProvider.SetError(txtInventarniBroj, Properties.Resources.InventarniBrojFormat);
            }
            else
            {
                labelInventarniBroj.ForeColor = Color.Black;
                errorProvider.SetError(txtInventarniBroj, null);
            }
        }

        private void txtGodinaIzdavanja_Validating(object sender, CancelEventArgs e)
        {
            Regex godina = new Regex(@"^[0-9]{4}$");

            if (string.IsNullOrWhiteSpace(txtGodinaIzdavanja.Text))
            {
                labelGodinaIzdavanja.ForeColor = Color.Red;
                errorProvider.SetError(txtGodinaIzdavanja, Properties.Resources.ObaveznoPolje);
            }
            else if (!godina.IsMatch(txtGodinaIzdavanja.Text))
            {
                labelGodinaIzdavanja.ForeColor = Color.Red;
                errorProvider.SetError(txtGodinaIzdavanja, Properties.Resources.GodinaNeispravanFormat);
            }
            else
            {
                labelGodinaIzdavanja.ForeColor = Color.Black;
                errorProvider.SetError(txtGodinaIzdavanja, null);
            }
        }

        private void txtBrojStranica_Validating(object sender, CancelEventArgs e)
        {
            Regex broj = new Regex(@"^[0-9]{1,5}$");

            if (string.IsNullOrWhiteSpace(txtBrojStranica.Text))
            {
                labelBrojStranica.ForeColor = Color.Red;
                errorProvider.SetError(txtBrojStranica, Properties.Resources.ObaveznoPolje);
            }
            else if (!broj.IsMatch(txtBrojStranica.Text))
            {
                labelBrojStranica.ForeColor = Color.Red;
                errorProvider.SetError(txtBrojStranica, Properties.Resources.NeispravanFormat);
            }
            else
            {
                labelBrojStranica.ForeColor = Color.Black;
                errorProvider.SetError(txtBrojStranica, null);
            }
        }

        private void txtUkupnoNaStanju_Validating(object sender, CancelEventArgs e)
        {
            Regex broj = new Regex(@"^[0-9]{1,5}$");

            if (string.IsNullOrWhiteSpace(txtUkupnoNaStanju.Text))
            {
                labelUkupno.ForeColor = Color.Red;
                errorProvider.SetError(txtUkupnoNaStanju, Properties.Resources.ObaveznoPolje);
            }
            else if (!broj.IsMatch(txtUkupnoNaStanju.Text))
            {
                labelUkupno.ForeColor = Color.Red;
                errorProvider.SetError(txtUkupnoNaStanju, Properties.Resources.NeispravanFormat);
            }
            else
            {
                labelUkupno.ForeColor = Color.Black;
                errorProvider.SetError(txtUkupnoNaStanju, null);
            }
        }

        private void rtbOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbOpis.Text))
            {
                gbOpis.ForeColor = Color.Red;
                errorProvider.SetError(rtbOpis, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                gbOpis.ForeColor = Color.Black;
                errorProvider.SetError(rtbOpis, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtNaziv).Length > 0)
                return false;

            if (errorProvider.GetError(cmbAutor).Length > 0)
                return false;

            if (errorProvider.GetError(cmbIzdavac).Length > 0)
                return false;

            if (errorProvider.GetError(cmbKategorija).Length > 0)
                return false;

            if (errorProvider.GetError(txtInventarniBroj).Length > 0)
                return false;

            if (errorProvider.GetError(txtGodinaIzdavanja).Length > 0)
                return false;

            if (errorProvider.GetError(txtBrojStranica).Length > 0)
                return false;

            if (errorProvider.GetError(txtUkupnoNaStanju).Length > 0)
                return false;

            if (errorProvider.GetError(rtbOpis).Length > 0)
                return false;

            return true;
        }

        #endregion

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.OpenForm(new frmKnjige(_mainForm));
        }
    }
}
