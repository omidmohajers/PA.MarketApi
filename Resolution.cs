using System.ComponentModel;

namespace PA.Trading.UAPI
{
    public enum Resolution
    {
        [Description("1m")]
        _1m = 1,
        [Description("3m")]
        _3m = 3,
        [Description("5m")]
        _5m = 5,
        [Description("15m")]
        _15m = 15,
        [Description("30m")]
        _30m = 30,
        [Description("1h")]
        _1h = 60,
        [Description("2h")]
        _2h = 120,
        [Description("4h")]
        _4h = 240,
        [Description("6h")]
        _6h = 360,
        [Description("8h")]
        _8h = 480,
        [Description("12h")]
        _12h = 720,
        [Description("1d")]
        _1d = 1440,
        [Description("3d")]
        _3d = 4320,
        [Description("1w")]
        _1w = 10080,
        [Description("1M")]
        _1M = 43200,
    }
}
