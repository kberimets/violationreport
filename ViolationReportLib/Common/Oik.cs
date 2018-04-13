using System;
using System.Collections.Generic;
using System.Linq;
using OICDAC;

namespace ViolationReportLib
{
    public static class Oik
    {
        private static DAC _oik;
        private static OICConnection _connection;
        private static OIRequest _request;

        private static List<Measurement> _measurements = new List<Measurement>();

        static Oik()
        {
            _oik = new DAC();
            _connection = _oik.Connection;
        }

        public static void CreateRequest(string dataSource, DateTime startTime, DateTime endTime)
        {
            if (_request == null)
            {
                _request = _oik.OIRequests.Add();
                _request.OnGetResult += Request_OnGetResult;
            }
            if (_request.OIRequestItems.Count > 0)
                _request.OIRequestItems.Clear();

            var item = _request.OIRequestItems.Add();
            item.DataSource = dataSource;
            item.KindRefresh = KindRefreshEnum.kr_Period;
            item.TimeStart = startTime;
            item.TimeStop = endTime;
        }

        private static void Request_OnGetResult(string DataSource, KindRefreshEnum KindRefresh, DateTime Time, object Data, int Sign, int Tag)
        {
            var measurement = new Measurement
            {
                StartTime = Time,
                Value = (double)Data,
                QualityCode = Sign
            };

            _measurements.Add(measurement);
        }

        public static IEnumerable<Measurement> Read()
        {
            if (_connection.Connected == false)
            {
                _connection.Connected = true;
            }

            _measurements.Clear();

            _request.Start();
            _request.WaitComplete(DateTime.Now + new TimeSpan(0, 0, 15));
            _request.Stop();

            _measurements = _measurements.OrderBy(m => m.StartTime).ToList();
            for (int i = 0; i < _measurements.Count - 1; i++)
                _measurements[i].EndTime = _measurements[i + 1].StartTime.AddSeconds(-1);

            return _measurements.ToArray();
        }
    }
}
