using RestSharp;
using System;
using System.Collections.Generic;

namespace PA.Trading.UAPI
{
    public class KucoinApi : MarketApiBase<UCandle>
    {
        public override List<UCandle> Request(CandleRequestParams param)
        {
            List<UCandle> list = new List<UCandle>();

            try
            {
                var client = new RestClient("https://api.kucoin.com/");
                // "https://api.kucoin.com/api/v1/market/candles?type=1hour&symbol=BTC-USDT&limit=5";
                string requestString = "api/";
                if (param.CadleCount > 0)
                {
                    requestString = string.Format("api/{0}/market/candles?symbol={1}&type={2}", param.Version, param.Symbol, param.Interval.ToString().Substring(1), param.CadleCount);
                }
                else
                {
                    requestString = string.Format("api/{0}/market/candles?symbol={1}&interval={2}&startAt={3}&endAt={4}", param.Version, param.Symbol, param.Interval.ToString(),
                                        param.StartDate.Subtract(new DateTime(1970,1,1)).TotalSeconds,
                                        param.EndDate.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                }
                var request = new RestRequest(requestString);
                var response = client.Post(request);
                var content = response.Content;
                string[] data = content.Split(new string[] { "],[" }, StringSplitOptions.RemoveEmptyEntries);
                list = ConvertStringToSymbolPrice(data);
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public override List<UCandle> ConvertStringToSymbolPrice(string[] cArray)
        {
            List<UCandle> list = new List<UCandle>();
            foreach (string s in cArray)
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
