using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ViolationReportLib;

namespace ViolationReport
{
    public class MainViewModel : BaseViewModel
    {
        private VoltageReportViewItem[] _voltageReportView;

        private ICommand _generateCommand;
        private ICommand _generateVoltageReportCommand;

        public MainViewModel()
        {
            _generateCommand = new DelegateCommand((noParameters) => GenerateReport());
        }

        public VoltageReportViewItem[] VoltageReportView
        {
            get { return _voltageReportView; }
            set
            {
                _voltageReportView = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateCommand { get { return _generateCommand; } }

        private void GenerateReport()
        {
            var voltageReport = new VoltageReport(new DateTime(2018, 1, 29, 0, 0, 0), new DateTime(2018, 1, 30, 6, 0, 0));
            var reportItems = voltageReport.Generate();

            var reportView = new List<VoltageReportViewItem>();
            foreach (var reportItem in reportItems)
            {
                if (reportItem.LongViolations.Any())
                    reportView.Add(new VoltageReportViewItem(reportItem));
            }

            VoltageReportView = reportView.ToArray();
        }

        private void GenerateVoltageReport()
        {

        }
    }
}
