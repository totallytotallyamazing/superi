<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FAQEditor.ascx.cs" Inherits="Administration_Controls_FAQEditor" %>
<table>
<tr>
    <td style="height: 21px">
        Комментарий
    </td>
    <td style="height: 21px">
        Читать
    </td>
    <td style="height: 21px">
        Удалить
    </td>
</tr>
<asp:Repeater runat="server" ID="rItems" OnItemCommand="rItems_ItemCommand" OnItemDataBound="rItems_ItemDataBound">
    <ItemTemplate>
        <tr>
            <td><asp:Literal runat="server" ID="lComment"></asp:Literal></td>
            <td><asp:LinkButton CommandName="Answer" Text="Читать" runat="server" ID="lbAnswer"></asp:LinkButton></td>
            <td><asp:LinkButton CommandName="Delete" Text="Удалить" runat="server" ID="lbDelete"></asp:LinkButton></td>
        </tr>
    </ItemTemplate>
</asp:Repeater>
</table>
<asp:HiddenField runat="server" ID="hfItemId" />
<asp:PlaceHolder runat="server" ID="phAnswer">
        <div>
            <asp:Literal runat="server" ID="lQuestion"></asp:Literal>
        </div>
</asp:PlaceHolder>
