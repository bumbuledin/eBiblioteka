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
using eBiblioteka.Model.Requests;

namespace eBiblioteka.WinUI.Forms.Static
{
    public partial class frmLogin : Form
    {
        APIService _apiService = new APIService("Uposlenik");
        private bool isClicked = false;
        public frmLogin()
        {
            InitializeComponent();
            isClicked = false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(isClicked == false)
            {
                if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
                {
                    try
                    {
                        APIService.Username = txtKorisnickoIme.Text;
                        APIService.Password = txtPassword.Text;

                        AuthenticationRequest request = new AuthenticationRequest
                        {
                            KorisnickoIme = txtKorisnickoIme.Text,
                            Password = txtPassword.Text
                        };

                        var x = await _apiService.Authenticate(request);

                        if (x.UposlenikUloga.Any(s => s.Uloga.Naziv == "Administrator"))
                        {
                            MainForm frm = new MainForm(true);
                            frm.Closed += (s, args) => this.Close();
                            frm.Show();

                        }
                        else
                        {
                            MainForm frm = new MainForm(false);
                            frm.Closed += (s, args) => this.Close();
                            frm.Show();

                        }

                        isClicked = true;
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Autentifikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
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

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                labelLozinka.ForeColor = Color.Red;
                errorProvider.SetError(txtPassword, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelLozinka.ForeColor = Color.Black;
                errorProvider.SetError(txtPassword, null);
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(txtKorisnickoIme).Length > 0)
                return false;

            if (errorProvider.GetError(txtPassword).Length > 0)
                return false;

            return true;
        }
    }
}
