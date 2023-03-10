using System;

namespace PA.Trading.UAPI
{
    public class UCandle
    {
        public DateTime OpenTime { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
        public double Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public double QuoteAssetVolume { get; set; }
        public long NumberOfTrades { get; set; }

        public DateTime OpenUTC
        {
            get
            {
                return OpenTime.ToUniversalTime();
            }
        }
        public DateTime CloseUTC
        {
            get
            {
                return CloseTime.ToUniversalTime();
            }
        }
        public double RSI
        {
            get;
            set;
        }
        public double ATR { get; set; }
        public double EMA { get; set; }
        public double SMA { get; set; }
        public double RMA { get; set; }

        public UCandle()
        {
            HighPrice = 3.7;
        }
        public string GetSerialize()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\"",
                Helper.DateTimeToUnixTimeStamp(OpenUTC),
                Helper.DateTimeToUnixTimeStamp(CloseUTC),
                OpenPrice,
                HighPrice,
                LowPrice,
                ClosePrice,
                RSI,
                ATR,
                SMA,
                EMA
                );
        }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}]",
                Helper.DateTimeToUnixTimeStamp(OpenUTC),
                Helper.DateTimeToUnixTimeStamp(CloseUTC),
                OpenPrice,
                HighPrice,
                LowPrice,
                ClosePrice,
                RSI,
                ATR,
                SMA,
                EMA,
                RMA
                );
        }
    }
}
