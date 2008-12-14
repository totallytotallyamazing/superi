<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" Title="Untitled Page" %>
<%@ Import namespace="Superi.Features"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList runat="server" ID="dlItems" RepeatDirection="Horizontal" RepeatColumns="4" Width="100%" CellSpacing="0" ItemStyle-HorizontalAlign="Center" CssClass="singleMenuDataList">
        <ItemTemplate>
            <a href="<%# DefaultValues.BaseUrl+((Navigation) Container.DataItem).Name %>">
                <div runat="server" id="divMenuItem" style="cursor:pointer;" class="fixPng">
                    <div id="menuNameSpacer" runat="server"></div>
                    <table>
                        <tr>
                            <td style="padding:0px; margin:0px; width:2px;"></td>
                            <td style="padding:0px; margin:0px; width:75px; height:25px; vertical-align:middle; line-height:10px; text-align:center;" valign="middle" align="center">
                                <b><a style="text-decoration:none; padding:0px;" href="<%# DefaultValues.BaseUrl+((Navigation) Container.DataItem).Name %>"><%# ((Navigation) Container.DataItem).Texts[WebSession.Language] %></a></b>        
                            </td>
                            <td style="padding:0px; margin:0px; text-decoration:none;border:none;"></td>
                        </tr>
                    </table>
                </div>
            </a>
            <%--<a style="color:Black;" href="<%# DefaultValues.BaseUrl+((Navigation) Container.DataItem).Name %>"><img src="<%# DefaultValues.BaseImageUrl + "MenuImages/"+((Navigation) Container.DataItem).Picture %>" alt="<%# ((Navigation) Container.DataItem).Texts[WebSession.Language] %>" /></a><br />--%>
            
        </ItemTemplate>
        <ItemStyle HorizontalAlign="Center" />
    </asp:DataList>
</asp:Content>

