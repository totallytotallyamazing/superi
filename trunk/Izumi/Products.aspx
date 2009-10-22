<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" Title="Untitled Page" %>
<%@ Import namespace="Superi.Shop"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <asp:Repeater runat="server" ID="rProducts">
        <ItemTemplate>
            <div id="divContainer" runat="server" class="productContainer fixPng">
                <table style="height:100%; width:100%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td style="height:100%; width:100%;" valign="bottom">
                            <table style="width:100%; height:38px;" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td align="left" valign="middle" class="productTopText"> <asp:Literal ID="lName" runat="server"></asp:Literal></td>
                                    <td align="right" valign="middle">
                                        <div class="productBottomPrice">
                                            <%# ((Product) Container.DataItem).Price.ToString("0.00") %>
                                            <%switch (WebSession.Language) { case "EN": Response.Write("uah"); break; case "RU":Response.Write("грн"); break; case "UA":
                                            Response.Write("грн");break; } %>
                                        </div>
                                        <div class="productBottomWeight">
                                            (<%# ((Product) Container.DataItem).Weight.ToString("0") %><%switch (WebSession.Language) { case "EN": Response.Write("g"); break; case "RU":Response.Write("г"); break; case "UA":
                                            Response.Write("г");break; } %>)
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
<%--                <div class="productTopText">
                <%# ((Product) Container.DataItem).Names[WebSession.Language] %>
                </div>
                <div id="productPriceSpacer" runat="server">
                
                </div>
                <div class="productBottomText">
                    <%# ((Product) Container.DataItem).Price.ToString("0.00") %>
                    <%switch (WebSession.Language) { case "EN": Response.Write("uah"); break; case "RU":Response.Write("грн"); break; case "UA":
                    Response.Write("грн");break; } %>
                    /
                    <span style="background-color:Red;"><%# ((Product) Container.DataItem).Weight.ToString("0") %><%switch (WebSession.Language) { case "EN": Response.Write("g"); break; case "RU":Response.Write("гр"); break; case "UA":
                    Response.Write("гр");break; } %></span></div>
--%>            </div>
        </ItemTemplate>
    </asp:Repeater>
    
    <asp:PlaceHolder ID="phAlco" runat="server">
        <table class="alcoTable">
            <tr>
                <td align="center" class="alcoBlack">
                    <b>
                    <%
                        switch (WebSession.Language)
                        {
                            case "EN":
                                Response.Write("Name");
                                break;
                            case "RU":
                                Response.Write("Название");
                                break;
                            case "UA":
                                Response.Write("Назва");
                                break;
                        }
                     %>
                     </b>
                </td>
                <td align="center" class="alcoBlack">
                    <b>
                    <%
                        switch (WebSession.Language)
                        {
                            case "EN":
                                Response.Write("Weight");
                                break;
                            case "RU":
                                Response.Write("Вес");
                                break;
                            case "UA":
                                Response.Write("Вага");
                                break;
                        }
                     %>
                     </b>
                </td>
                <td align="center" class="alcoRed">
                    <b>
                    <%
                        switch (WebSession.Language)
                        {
                            case "EN":
                                Response.Write("Price");
                                break;
                            case "RU":
                                Response.Write("Цена");
                                break;
                            case "UA":
                                Response.Write("Цiна");
                                break;
                        }
                     %>
                     </b>
                </td>
            </tr>
            <asp:Repeater ID="rAlco" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="alcoBlack" align="left"><asp:Literal ID="lAlcoName" runat="server"></asp:Literal></td>
                        <td class="alcoBlack" align="center"><%# ((Product) Container.DataItem).Weight.ToString("0") %><%switch (WebSession.Language) { case "EN": Response.Write("g"); break; case "RU":Response.Write("г"); break; case "UA":
                                            Response.Write("г");break; } %></td>
                        <td class="alcoRed" align="center"><%# ((Product) Container.DataItem).Price.ToString("0.00") %><%switch (WebSession.Language) { case "EN": Response.Write("uah"); break; case "RU":Response.Write("грн"); break; case "UA":
                                            Response.Write("грн");break; } %></td>
                    </tr>                
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </asp:PlaceHolder>
</center>
</asp:Content>

