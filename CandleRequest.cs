using System.Collections.Generic;

namespace PA.Trading.UAPI
{
    public class CandleRequest
    {
        public CandleRequest()
        {

        }
        public List<UCandle> Fetch(CandleRequestParams param)
        {
            List<UCandle> list = new List<UCandle>();

            switch (param.Api)
            {
                case "fapi":
                    Binance.fapi.BinanceFApi fapi = new Binance.fapi.BinanceFApi();
                    list = fapi.Request(param);
                    break;
            }
            return list;
        }
        public List<USymbolPrice> FetchPrice(CandleRequestParams param)
        {
            List<USymbolPrice> list = new List<USymbolPrice>();

            switch (param.Api)
            {
                case "sapi":
                    Binance.sapi.BinanceSApi fapi = new Binance.sapi.BinanceSApi();
                    list = fapi.Request(param);
                    break;
            }
            return list;
        }
    }
}
