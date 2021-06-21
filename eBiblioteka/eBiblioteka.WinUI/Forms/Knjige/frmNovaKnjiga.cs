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
    public partial class frmNovaKnjiga : Form
    {
        private MainForm _mainForm;
        private APIService _knjigaService = new APIService("Knjiga");
        private APIService _autorService = new APIService("Autor");
        private APIService _kategorijaService = new APIService("Kategorija");
        private APIService _izdavacService = new APIService("Izdavac");



        public frmNovaKnjiga(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private async void frmClanDetalji_Load(object sender, EventArgs e)
        {
            await LoadAutor();
            await LoadKategorija();
            await LoadIzdavac();

        }

        private async Task LoadAutor()
        {
            var autori = await _autorService.Get<List<Model.Autor>>(null);

            autori.Insert(0, new Model.Autor());
            cmbAutor.DataSource = autori;
            cmbAutor.DisplayMember = "ImePrezime";
            cmbAutor.ValueMember = "AutorId";
        }
        private async Task LoadKategorija()
        {
            var kategorija = await _kategorijaService.Get<List<Model.Kategorija>>(null);

            kategorija.Insert(0, new Model.Kategorija());
            cmbKategorija.DataSource = kategorija;
            cmbKategorija.DisplayMember = "Naziv";
            cmbKategorija.ValueMember = "KategorijaId";
        }
        private async Task LoadIzdavac()
        {
            var izdavac = await _izdavacService.Get<List<Model.Izdavac>>(null);

            izdavac.Insert(0, new Model.Izdavac());
            cmbIzdavac.DataSource = izdavac;
            cmbIzdavac.DisplayMember = "Naziv";
            cmbIzdavac.ValueMember = "IzdavacId";
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
                if (request.Slika == null || request.Slika.Length == 0)
                    MessageBox.Show("Niste dodali sliku.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
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

                    var response = await _knjigaService.Insert<Model.Knjiga>(request);

                    if (response != null)
                    {
                        MessageBox.Show("Uspješno ste dodali knjigu " + response.Naziv + ".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbAutor_Validating(object sender, CancelEventArgs e)
        {
            if (cmbAutor.SelectedValue == null)
            {
                labelAutor.ForeColor = Color.Red;
                errorProvider.SetError(cmbAutor, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbAutor.SelectedIndex.ToString()) == 0)
            {
                labelAutor.ForeColor = Color.Red;
                errorProvider.SetError(cmbAutor, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelAutor.ForeColor = Color.Black;
                errorProvider.SetError(cmbAutor, null);
            }
        }

        private void cmbKategorija_Validating(object sender, CancelEventArgs e)
        {
            if (cmbKategorija.SelectedValue == null)
            {
                labelKategorija.ForeColor = Color.Red;
                errorProvider.SetError(cmbKategorija, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbKategorija.SelectedIndex.ToString()) == 0)
            {
                labelKategorija.ForeColor = Color.Red;
                errorProvider.SetError(cmbKategorija, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelKategorija.ForeColor = Color.Black;
                errorProvider.SetError(cmbKategorija, null);
            }
        }

        private void cmbIzdavac_Validating(object sender, CancelEventArgs e)
        {
            if (cmbIzdavac.SelectedValue == null)
            {
                labelIzdavac.ForeColor = Color.Red;
                errorProvider.SetError(cmbIzdavac, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbIzdavac.SelectedIndex.ToString()) == 0)
            {
                labelIzdavac.ForeColor = Color.Red;
                errorProvider.SetError(cmbIzdavac, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelIzdavac.ForeColor = Color.Black;
                errorProvider.SetError(cmbIzdavac, null);
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
    }
}
