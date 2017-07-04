using MatchingDash.Model;
using MatchingDash.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchingDash.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Window
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportViewerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            rpv.rreportViewer.LocalReport.DataSources.Clear();
            List<TableResult> myitems = new List<TableResult>();
            foreach (TableResult item in Val.Items)
            {
                myitems.Add(item);
            }

            ReportDataSource rd = new ReportDataSource("Schedule_table_result", myitems);
            rd.Name = "Schedule_table_result";
            rpv.rreportViewer.LocalReport.DataSources.Add(rd);
            rpv.DataSource = myitems;
            //      var control = (ReportViewerUserControl)sender;
            //control.reportViewer.LocalReport.DataSources.Clear();
            //if (args.NewValue == null) return;
            rpv.rreportViewer.LocalReport.ReportPath = @"\Reports\SampleReport.rdlc";
            //var reportDataSource = CreateReportDataSource(args.NewValue);
            //control.reportViewer.LocalReport.DataSources.Add(reportDataSource);
            rpv.rreportViewer.Refresh();
        }

       
    }
}
