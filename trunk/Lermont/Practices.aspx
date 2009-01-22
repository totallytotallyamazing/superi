<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Practices.aspx.cs" Inherits="Practices" Title="Untitled Page" %>
<%@ Register TagPrefix="lermont" TagName="Paging" Src="~/Controls/Paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="practicesHolder">
        <asp:Repeater runat="server" ID="rItems" OnItemDataBound="rItems_ItemDataBound">
            <ItemTemplate>
                <table class="practiceItem" cellpadding="0" cellspacing="0">
                    <tr>
                        <asp:Repeater runat="server" ID="rImages">
                            <ItemTemplate>
                                <td valign="middle">
                                    <div class="practiceImage">
                                        <asp:Image runat="server" ID="iPicture" />
                                    </div>
                                </td>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <td class="imageSpacer"></td>
                            </SeparatorTemplate>
                        </asp:Repeater>
                        <td class="practiceTextHolder" valign="middle">
                            <div class="practiceText">
                                <asp:Literal ID="lPracticeText" runat="server"></asp:Literal>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SeparatorTemplate>
                <div class="practiceItemsSeparator"></div>
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
    <div class="paging">
        <lermont:Paging runat="server" ID="pPages" />
    </div>
</asp:Content>