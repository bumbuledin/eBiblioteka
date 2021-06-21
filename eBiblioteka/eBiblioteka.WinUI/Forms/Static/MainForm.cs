using eBiblioteka.WinUI.Forms.Clanovi;
using eBiblioteka.WinUI.Forms.Izvjestaji;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBiblioteka.WinUI.Forms.Static
{
    
    public partial class MainForm : Form
    {
        private IconButton currentBtn=null;
        private IconButton clickedBtn;
        private bool _administrator = false;
        private Panel menuPanel;
        private Form _activeForm = null;

        public MainForm(bool administrator)
        {
            InitializeComponent();
            CustomoizeDesing();
            menuPanel = new Panel();
            menuPanel.Size = new Size(10, 55);
            _administrator = administrator;
            panelSideMenu.Controls.Add(menuPanel);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            if(_administrator == false)
            {
                btnUposlenici.Visible = false;
                panelUposlenici.Visible = false;
            }

        }
        #region Open-Form

        public void OpenForm(Form FormName)
        {
            if (_activeForm != null)
                _activeForm.Close();

            ActivateCurrentButton(clickedBtn);
            _activeForm = FormName;
            FormName.TopLevel = false;
            FormName.FormBorderStyle = FormBorderStyle.None;
            FormName.Dock = DockStyle.Fill;
            panelFormContainer.Controls.Add(FormName);
            panelFormContainer.Tag = FormName;
            FormName.BringToFront();
            FormName.Show();

            titleChildForm.Text = currentBtn.Text + " / " + FormName.Text;
        }

        public void OpenFormAndAddTitle(Form FormName)
        {
            if (_activeForm != null)
                _activeForm.Close();

            //ActivateCurrentButton(clickedBtn);
            _activeForm = FormName;
            FormName.TopLevel = false;
            FormName.FormBorderStyle = FormBorderStyle.None;
            FormName.Dock = DockStyle.Fill;
            panelFormContainer.Controls.Add(FormName);
            panelFormContainer.Tag = FormName;
            FormName.BringToFront();
            FormName.Show();

            titleChildForm.Text += " / " + FormName.Text;
        }

        public Form GetActiveForm()
        {
            return _activeForm;
        }
        //public void OpenChieldSavedForm()
        //{
        //    _activeForm.Close();
        //    _childFormForNewForm.Show();
        //    //if (_activeForm != null)
        //    //{
        //    //    _activeForm = _childFormForNewForm;
        //    //    _activeForm.Close();
        //    //    //_childFormForNewForm = null;
        //    //}


        //    //_activeForm.TopLevel = false;
        //    //_activeForm.FormBorderStyle = FormBorderStyle.None;
        //    //_activeForm.Dock = DockStyle.Fill;
        //    //panelFormContainer.Controls.Add(_activeForm);
        //    //panelFormContainer.Tag = _activeForm;
        //    //_activeForm.BringToFront();
        //    //_activeForm.Show();

        //    titleChildForm.Text = currentBtn.Text + " / " + _activeForm.Text;
        //}

#endregion

        #region Aktivan button 


        private void ActivateCurrentButton(object btnSender)
        {
            DisableCurrentButton();
            if(btnSender != null)
            {
                currentBtn = (IconButton)btnSender;
                currentBtn.BackColor = Color.WhiteSmoke;
                currentBtn.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
                currentBtn.ForeColor = Color.Black;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

                menuPanel.BackColor = Color.Black;
                menuPanel.Location = new Point(0, currentBtn.Location.Y);
                menuPanel.Visible = true;
                menuPanel.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                titleChildForm.Text = currentBtn.Text;
            }
        }

        private void DisableCurrentButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.SeaGreen;
                currentBtn.FlatAppearance.MouseOverBackColor = Color.Transparent;

                currentBtn.ForeColor = Color.WhiteSmoke;
                currentBtn.IconColor = Color.WhiteSmoke;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

                currentBtn = null;
            }
        }

        private void ChangeLocationOfCurrentBtn(object btnSender)
        {
            if (btnSender != null)
            {
                menuPanel.Location = new Point(0, currentBtn.Location.Y);
            }
        }

        public void Reset()
        {
            DisableCurrentButton();
            menuPanel.Visible = false;
            HideSubMenu();
            if(_activeForm != null)
                _activeForm.Close();
            iconCurrentChildForm.IconChar = IconChar.Home;
            titleChildForm.Text = "Home";
        }
        #endregion

        #region SubMenu- Drop Down za button
        private void CustomoizeDesing()
        {
            panelClanoviSubMenu.Visible = false;
            panelKnjigeSubMenu.Visible = false;
            panelIzvjestaji.Visible = false;
            panelUposlenici.Visible = false;

        }
        private void HideSubMenu()
        {
            if (panelClanoviSubMenu.Visible == true)
                panelClanoviSubMenu.Visible = false;

            if (panelKnjigeSubMenu.Visible == true)
                panelKnjigeSubMenu.Visible = false;


            if (panelIzvjestaji.Visible == true)
                panelIzvjestaji.Visible = false;

            if (panelUposlenici.Visible == true)
                panelUposlenici.Visible = false;

            if (currentBtn != null)
            {
                //ActivateCurrentButton(currentBtn);
                ChangeLocationOfCurrentBtn(currentBtn);
            }
        }

        private void ShowSubMenu(Panel panel)
        {
            if (panel.Visible == false)
            {
                HideSubMenu();
                panel.Visible = true;

                if(currentBtn != null)
                {
                    ChangeLocationOfCurrentBtn(currentBtn);

                }

            }
            // Ukoliko je drop down panel vec otvoren, potrebno ga je sakriti ukoliko uposlenik opet pritisne na istu sekciju.
            else
            {
                HideSubMenu();
            }
        }

        #endregion

        #region Button_Click_Action

        // Panel Buttoni
        private void btnClanovi_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelClanoviSubMenu);
            //ActivateCurrentButton(sender);
        }

        private void btnKnjige_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelKnjigeSubMenu);
            //ActivateCurrentButton(sender);

        }

        private void btnZaduzenja_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnZaduzenja;
            OpenForm(new frmZaduzenja(this));
            HideSubMenu();
            //ShowSubMenu(panelZaduzenja);
            //ActivateCurrentButton(sender);

        }

        private void btnRezervacije_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnRezervacije;
            OpenForm(new frmRezervacije(this));
            HideSubMenu();
            //ShowSubMenu(panelRezervacije);
            //ActivateCurrentButton(sender);

        }

        private void btnIzvjestaji_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelIzvjestaji);
            //ActivateCurrentButton(sender);

        }

        private void btnUposlenici_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panelUposlenici);
            //ActivateCurrentButton(sender);

        }

        private void btnLogoHome_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //Drop-down buttoni

        private void btnNoviClan_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnClanovi;
            OpenForm(new frmNoviClan(this));
            HideSubMenu();
        }

        private void btnPregledClanova_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnClanovi;
            OpenForm(new frmPregledClanova(this));
            HideSubMenu();
        }

        private void btnNovaUplata_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnClanovi;
            frmNovaUplata frm = new frmNovaUplata(this);
            frm.ShowDialog();
            //OpenForm(new frmNovaUplata(this));
            //HideSubMenu();
        }

        private void btnPregledUposlenika_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnUposlenici;
            OpenForm(new frmPregledUposlenika(this));
            HideSubMenu();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnUposlenici;
            OpenForm(new frmNoviUposlenik(this));
            HideSubMenu();
        }


        private void btnIzdavaci_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnKnjige;
            OpenForm(new frmIzdavaci(this));
            HideSubMenu();
        }

        private void btnAutori_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnKnjige;
            OpenForm(new frmAutori(this));
            HideSubMenu();

        }


        private void btnNovaKnjiga_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnKnjige;
            OpenForm(new frmNovaKnjiga(this));
            HideSubMenu();
        }

        private void btnPregledKnjiga_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnKnjige;
            OpenForm(new frmKnjige(this));
            HideSubMenu();
        }

        #endregion

        private void btnIzvjestajUplate_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnIzvjestaji;
            OpenForm(new frmUplateReport());
            HideSubMenu();

        }


        private void btnBrojAktivnihClanova_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnIzvjestaji;
            OpenForm(new frmBrojClanovaReport());
            HideSubMenu();
        }


        private void btnKnjigeZaduženja_Click(object sender, EventArgs e)
        {
            clickedBtn = (IconButton)btnIzvjestaji;
            OpenForm(new frmKnjigeZaduzenjaReport());
            HideSubMenu();
        }
    }
}
