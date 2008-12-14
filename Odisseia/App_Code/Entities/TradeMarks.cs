using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for TradeMarks
/// </summary>
public static class TradeMarks
{
    public static TradeMarkList Get()
    {
        return new TradeMarkList(true);
    }

    public static TradeMarkList Get(bool ForMan, bool ForWoman)
    {
        return new TradeMarkList(ForMan, ForWoman);
    }

    public static TradeMarkList Get(bool Goods)
    {
        TradeMarkList result = new TradeMarkList();
        result.LoadByType(Goods);
        return result;
    }
}
