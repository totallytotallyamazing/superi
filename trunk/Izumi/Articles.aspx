<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Articles.aspx.cs" Inherits="Articles" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater runat="server" ID="rArticles">
        <ItemTemplate>
            <table class="article" cellpadding="0" cellspacing="0"> 
                <tr>
                    <td valign="top">
                        <a class="textLink" href="<%# DefaultValues.BaseUrl+"articleid/"+Eval("Alias") %>"><asp:Image ID="iPicture" runat="server" CssClass="articleImage" /></a>    
                    </td>
                    <td align="left" style="width:99%; padding:0px;" valign="top">
                        <table style="height:100%; border:none; width:100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding-left:5px;" id="topTr" runat="server" valign="top">
                                <div style="overflow:hidden;" id="divCutter" runat="server">
                                    <span class="articleTitle">
                                        <asp:Literal ID="lTitle" runat="server"></asp:Literal>
                                        <span style="font-weight:normal; font-size:12px;">
                                            &nbsp; | &nbsp;
                                            <asp:Literal ID="lDate" runat="server"></asp:Literal>
                                        </span>
                                    </span>
                                    <span class="articleContent"><asp:Literal ID="lText" runat="server"></asp:Literal></span>
                                </div>
                                </td>
                            </tr>
                            <tr style="height:100%;">
                                <td style="height:20px;" class="articleBottomTr fixPng" align="right">
                                    <a class="textLink" href="<%# DefaultValues.BaseUrl+"articleid/"+Eval("Alias") %>"><Controls:TextWriter TextName="readNews" runat="server"></Controls:TextWriter></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

