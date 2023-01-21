using System;

namespace PA.Trading.UAPI
{
    public class CandleRequestParams
    {
        public string Version { get; set; }
        public string Symbol { get; set; }
        public string Api { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CadleCount { get; set; }
        public Resolution Interval { get; set; }
    }
}
