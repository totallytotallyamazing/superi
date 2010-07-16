<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Helpers" %>
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
                string currentLang = System.Globalization.CultureInfo.CurrentUICulture.Name;
                result = "~/" + Request.Url.PathAndQuery.Replace(currentLang, currency.ToString());
            }
            return result;
        };

    hrnLink.NavigateUrl = getCurrencyLink(Currencies.Hrivna);
    usdLink.NavigateUrl = getCurrencyLink(Currencies.Dollar);
    euroLink.NavigateUrl = getCurrencyLink(Currencies.Euro);
%>
    
<div id="currency">
    <p>Цены отображаются в</p>
</div>
<div id="currencyBox">
    <h2>
        <asp:HyperLink runat="server" ID="hrnLink" Text="ГРН"></asp:HyperLink> | <asp:HyperLink runat="server" ID="usdLink" Text="USD"></asp:HyperLink> | <asp:HyperLink runat="server" ID="euroLink" Text="EUR"></asp:HyperLink>
    </h2>
</div>