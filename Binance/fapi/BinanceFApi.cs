using RestSharp;
using System;
using System.Collections.Generic;

namespace PA.Trading.UAPI.Binance.fapi
{
    public class BinanceFApi : MarketApiBase<UCandle>
    {
        public override List<UCandle> Request(CandleRequestParams param)
        {
            List<UCandle> list = new List<UCandle>();

            try
            {
                var client = new RestClient("https://binance.com/");
                // "https://fapi.binance.com/fapi/v1/klines?symbol=BTCUSDT&interval=5m&limit=3";
                string requestString = "fapi/";
                if (param.CadleCount > 0)
                {
                    requestString = string.Format("fapi/{0}/klines?symbol={1}&interval={2}&limit={3}", param.Version, param.Symbol, param.Interval.ToString().Substring(1), param.CadleCount);
                }
                else
                {
                    requestString = string.Format("fapi/{0}/klines?symbol={1}&interval={2}&startTime={3}&endTime={4}", param.Version, param.Symbol, param.Interval.ToString(), Helper.DateTimeToUnixTimeStamp(param.StartDate), Helper.DateTimeToUnixTimeStamp(param.EndDate));
                }
                var request = new RestRequest(requestString);
                var response = client.Post(request);
                var content = response.Content; 
                string[] data = content.Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
                list = ConvertStringToSymbolPrice(data);
            }
            catch(Exception ex)
            {
                
            }

            return list;
        }

        public override List<UCandle> ConvertStringToSymbolPrice(string[] cArray)
        {
            List<UCandle> list = new List<UCandle>();
            foreach(string s in cArray)
            {
                string[] fields = s.Split(',');
                UCandle uc = new UCandle();
                uc.OpenTime = Helper.GetJsonTime(fields[0]);
                uc.OpenPrice = Helper.ConvertStringToDecimal(fields[1]);
                uc.HighPrice = Helper.ConvertStringToDecimal(fields[2]);
                uc.LowPrice = Helper.ConvertStringToDecimal(fields[3]);
                uc.ClosePrice = Helper.ConvertStringToDecimal(fields[4]);
                uc.Volume = Helper.ConvertStringToDecimal(fields[5]);
                uc.CloseTime = Helper.GetJsonTime(fields[6]);
                uc.NumberOfTrades = Helper.ConvertStringToLong(fields[7]);
                list.Add(uc);
            }
            return list;
        }
    }
}
