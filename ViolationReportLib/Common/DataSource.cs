using System;
using System.Linq;
using ViolationReportLib.Db;
using OICDAC;
using System.Collections.Generic;

namespace ViolationReportLib
{
    public static class DataSource
    {
        private static VoltageNsi[] GetVoltageNsi()
        {
            using (var context = new OikDbContext())
            {
                return context.UDef
                    .Where(udef => udef.InControl == true)
                    .Join(
                        context.EnObj,
                        udef => udef.EObject,
                        eobject => eobject.ID,
                        (udef, eobject) => new
                        {
                            Udef = udef,
                            Eobject = eobject
                        }
                    )
                    .Join(
                        context.AllTI,
                        joined => joined.Udef.IDTI,
                        allti => allti.ID,
                        (joined, allti) => new VoltageNsi
                        {
                            ObjectId = joined.Eobject.ID,
                            ObjectName = joined.Eobject.Name,
                            VoltageTiId = allti.ID,
                            VoltageTiName = allti.Name,
                            LowerLimitCategory = joined.Udef.NPP_OI,
                            LowerLimitId = joined.Udef.NPP.Value,
                            UpperLimitCategory = joined.Udef.VPP_OI,
                            UpperLimitId = joined.Udef.VPP.Value
                        }
                    )
                    .ToArray();
            }
        }

        public static IEnumerable<VoltageControlObject> GetControlObjects()
        {
            var controlObjects = new List<VoltageControlObject>();

            var nsiItems = GetVoltageNsi();
            foreach (var nsiItem in nsiItems)
                controlObjects.Add(new VoltageControlObject(nsiItem));

            return controlObjects;
        }

        public static IEnumerable<Measurement> ReadFromOik(string oiLetter, int oiId, DateTime startTime, DateTime endTime)
        {
            Oik.CreateRequest(oiLetter + oiId, startTime, endTime);

            var measurements = Oik.Read();

            var first = measurements.FirstOrDefault();
            var last = measurements.LastOrDefault();

            if (first != null) first.StartTime = startTime;
            if (last != null) last.EndTime = endTime;

            return measurements;
        }
    }
}
