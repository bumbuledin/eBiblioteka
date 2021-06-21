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
    public partial class frmKnjigeZaduzenjaReport : Form
    {
        private APIService _zaduzenjeService = new APIService("Zaduzenje");

        public frmKnjigeZaduzenjaReport()
        {
            InitializeComponent();
        }

        private async void frmKnjigeZaduzenjaReport_Load(object sender, EventArgs e)
        {
            var zaduzenja = await _zaduzenjeService.Get<List<Model.Zaduzenje>>(null);
            ReportDataSource rds = new ReportDataSource("DataSet1", zaduzenja);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eBiblioteka.WinUI.Reports.BrojZaduzenjaKnjiga.rdlc";
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));

            this.reportViewer1.LocalReport.DataSources.Add(rds);


            this.reportViewer1.RefreshReport();

        }
    }
}
