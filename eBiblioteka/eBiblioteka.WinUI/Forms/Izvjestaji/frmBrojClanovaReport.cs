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
    public partial class frmBrojClanovaReport : Form
    {
        private APIService _uplateService = new APIService("Uplata");

        public frmBrojClanovaReport()
        {
            InitializeComponent();
        }

        private async void frmBrojClanovaReport_Load(object sender, EventArgs e)
        {
            var uplate = await _uplateService.Get<List<Model.Uplata>>(null);
            ReportDataSource rds = new ReportDataSource("DataSet1", uplate);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eBiblioteka.WinUI.Reports.BrojClanovaReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));
            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();

        }
    }
}
