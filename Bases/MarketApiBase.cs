using System.Collections.Generic;

namespace PA.Trading.UAPI
{
    public class MarketApiBase<T>
    {
        public virtual List<T> Request(CandleRequestParams param)
        {
            List<T> list = new List<T>();
            return list;
        }
        public virtual List<T> ConvertStringToSymbolPrice(string[] cArray)
        {
            List<T> list = new List<T>();
            return list;
        }
    }
}
