using eBiblioteka.Model.Requests;
using eBiblioteka.WinUI.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eBiblioteka.WinUI.Forms.Izvjestaji
{
    public partial class frmUplateReport : Form
    {
        private APIService _uplateService = new APIService("Uplata");
        private APIService _clanService = new APIService("Clan");

        public frmUplateReport()
        {
            InitializeComponent();
        }

        private async void frmUplateReport_Load(object sender, EventArgs e)
        {
            await LoadClan();
            
        }

        private async Task LoadClan()
        {
            var clan = await _clanService.Get<List<Model.Clan>>(null);

            clan.Insert(0, new Model.Clan());
            cmbClan.DataSource = clan;
            cmbClan.DisplayMember = "ImePrezime";
            cmbClan.ValueMember = "ClanId";

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren() && ProvjeraValidnostiPolja() == true)
            {
                var clanValue = cmbClan.SelectedValue;

                var clanIme = cmbClan.Text;

                UplataSearchRequest request = new UplataSearchRequest();

                if (int.TryParse(clanValue.ToString(), out int id2))
                {
                    request.ClanId = id2;
                }

                this.reportViewer1.Reset();
                this.reportViewer1.LocalReport.DataSources.Clear();
                var uplate = await _uplateService.Get<List<Model.Uplata>>(request);
                ReportDataSource rds = new ReportDataSource("DataSet1", uplate);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "eBiblioteka.WinUI.Reports.ClanUplateReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ID", request.ClanId.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Clan", clanIme));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumIzvjestaja", DateTime.Now.ToString("dd.MM.yyyy")));


                this.reportViewer1.RefreshReport();
            }
        }

        private bool ProvjeraValidnostiPolja()
        {
            if (errorProvider.GetError(cmbClan).Length > 0)
                return false;
            else
                return true;
        }
        private void cmbClan_Validating(object sender, CancelEventArgs e)
        {
            if (cmbClan.SelectedValue == null)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbClan, Properties.Resources.ObaveznoPolje);
            }
            else if (int.Parse(cmbClan.SelectedIndex.ToString()) == 0)
            {
                labelClan.ForeColor = Color.Red;
                errorProvider.SetError(cmbClan, Properties.Resources.ObaveznoPolje);
            }
            else
            {
                labelClan.ForeColor = Color.Black;
                errorProvider.SetError(cmbClan, null);
            }
        }
    }
}
