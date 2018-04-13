using System;
using System.Linq;
using System.Text;
using ViolationReportLib;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new DateTime(2018, 1, 29, 0, 0, 0);
            var end = new DateTime(2018, 1, 30, 6, 0, 0);

            var voltageReport = new VoltageReport(start, end);
            var reportItems = voltageReport.Generate();

            foreach (var reportItem in reportItems)
                Console.WriteLine(reportItem);
        }
    }
}
