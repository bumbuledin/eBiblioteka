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
    public partial class frmNoviIzdavac : Form
    {
        private APIService _izdavacService = new APIService("Izdavac");
        private MainForm _mainForm;
        public frmNoviIzdavac(MainForm mainForm)
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
                var request = new IzdavacUpsertRequest()
                {
                    Naziv = txtNaziv.Text,
                    KontaktEmail = txtEmail.Text
                };

                var response = await _izdavacService.Insert<Model.Izdavac>(request);

                if (response != null)
                {
                    MessageBox.Show("Uspješno ste dodali izdavača.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mainForm.OpenForm(new frmIzdavaci(_mainForm));
                }
            }

            else
            {
                MessageBox.Show("Sva polja moraju biti ispravno popunjena!", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                labelNaziv.ForeColor = Color.Red;
                errorProvider.SetError(txtNaziv, Properties.Resources.ObaveznoPolje);
            }
            else if (txtNaziv.Text.Length < 3 || txtNaziv.Text.Length > 20)
            {
                labelNaziv.ForeColor = Color.Red;
                errorProvider.SetError(txtNaziv, Properties.Resources.NazivNeispravnaDuzina);
            }
            else
            {
                labelNaziv.ForeColor = Color.Black;
                errorProvider.SetError(txtNaziv, null);
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

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtNaziv).Length > 0)
                return false;

            if (errorProvider.GetError(txtEmail).Length > 0)
                return false;

            return true;
        }
    }
}
