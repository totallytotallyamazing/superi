<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Helpers" %>
<%@ Import Namespace="Dev.Helpers" %>
<% 
    Func<Currencies, string> getCurrencyLink = currency =>
        {
            string result;
            if (Request.QueryString["curr"] == null)
            {
                string separator = (string.IsNullOrEmpty(Request.Url.Query)) ? "?" : "&";
                result = "~/" + Request.Url.PathAndQuery + separator + "curr=" + currency;
            }
            else
            {
                string currentCurrency = WebSession.Currency.ToString();
                result = "~/" + Request.Url.PathAndQuery.Replace(currentCurrency, currency.ToString());
            }
            return result;
        };

    hrnLink.NavigateUrl = getCurrencyLink(Currencies.Hrivna);
    usdLink.NavigateUrl = getCurrencyLink(Currencies.Dollar);
    euroLink.NavigateUrl = getCurrencyLink(Currencies.Euro);

    switch (WebSession.Currency)
    {
        case Currencies.Dollar:
            usdLink.CssClass = "current";
            usdLink.NavigateUrl = string.Empty;
            break;
        case Currencies.Euro:
            euroLink.CssClass = "current";
            euroLink.NavigateUrl = string.Empty;
            break;
        case Currencies.Hrivna:
            hrnLink.CssClass = "current";
            hrnLink.NavigateUrl = string.Empty;
            break;
    }
%>

  <div id="topCurrencyCB"> 
                <form action="" method="post">
                    <p><select style="width : 120px">
                        <option value="UAH"><asp:HyperLink runat="server" ID="hrnLink" Text="ГРН"></asp:HyperLink>   </option>
                        <option value="USD"><asp:HyperLink runat="server" ID="usdLink" Text="USD"></asp:HyperLink>   </option>
                        <option value="EUR"><asp:HyperLink runat="server" ID="euroLink" Text="EUR"></asp:HyperLink>   </option>                        
                    </select></p>                    
                </form>                
            </div> 
    
<%--<div id="currency">
    <p>Цены отображаются в</p>
</div>
<div id="currencyBox">
    <h2>
        <asp:HyperLink runat="server" ID="hrnLink" Text="ГРН"></asp:HyperLink> | <asp:HyperLink runat="server" ID="usdLink" Text="USD"></asp:HyperLink> | <asp:HyperLink runat="server" ID="euroLink" Text="EUR"></asp:HyperLink>
    </h2>
</div>--%>