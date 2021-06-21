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
    public partial class frmNoviAutor : Form
    {
        private APIService _autorService = new APIService("Autor");
        private MainForm _mainForm;
        public frmNoviAutor(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                var request = new AutorUpsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    GodinaRodjenja=txtGodinaRodjenja.Text
                };

                var response = await _autorService.Insert<Model.Autor>(request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste dodali autora - " + response.Ime + " "  + response.Prezime, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mainForm.OpenForm(new frmAutori(_mainForm));
                }
            }

            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            Regex ime = new Regex(@"^\p{Lu}{1}\p{Ll}{2,19}$");

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
            Regex prezime = new Regex(@"^\p{Lu}{1}\p{Ll}{2,19}$");

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


        private void txtGodinaRodjenja_Validating(object sender, CancelEventArgs e)
        {
            Regex godina = new Regex(@"^[0-9]{4}$");

            if (string.IsNullOrWhiteSpace(txtGodinaRodjenja.Text))
            {
                labelGodinaRodjenja.ForeColor = Color.Red;
                errorProvider.SetError(txtGodinaRodjenja, Properties.Resources.ObaveznoPolje);
            }
            else if (!godina.IsMatch(txtGodinaRodjenja.Text))
            {
                labelGodinaRodjenja.ForeColor = Color.Red;
                errorProvider.SetError(txtGodinaRodjenja, Properties.Resources.GodinaNeispravanFormat);
            }
            else
            {
                labelGodinaRodjenja.ForeColor = Color.Black;
                errorProvider.SetError(txtGodinaRodjenja, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtPrezime).Length > 0)
                return false;

            if (errorProvider.GetError(txtGodinaRodjenja).Length > 0)
                return false;

            return true;
        }

    }
}
