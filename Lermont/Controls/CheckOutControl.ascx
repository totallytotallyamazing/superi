<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CheckOutControl.ascx.cs" Inherits="Controls_CheckOutControl" %>
<asp:Repeater runat="server" ID="rCheckOut" OnItemDataBound="rCheckOut_ItemDataBound">
<HeaderTemplate>
<table width="500" class="tabCheckOut" border="1">
<tr>
    <td width="150">
        Тайп
    </td>
    <td width="150">
        Тайтл
    </td>
    <td width="150">
        Прайс
    </td>
    <td>
        Удалить
    </td>
</tr>
</HeaderTemplate>
<ItemTemplate>
<tr>
    <td>
        <asp:Literal runat="server" ID="lType" ></asp:Literal>
    </td>
    <td>
        <asp:Literal runat="server" ID="lTitle" ></asp:Literal>
    </td>
    <td style="text-align:right">
        <asp:Literal runat="server" ID="lPrice" ></asp:Literal>
    </td>
    <td>
        <asp:CheckBox ID="cbRemoveFromCart" runat="server" />
    </td>
</tr>
</ItemTemplate>
<SeparatorTemplate>

</SeparatorTemplate>
<FooterTemplate>
<tr>
    <td colspan="2" style="text-align:right">
        Итого:
    </td>
    <td style="text-align:right">
        <asp:Literal runat="server" ID="lSum" ></asp:Literal>
    </td>
    <td>
        
    </td>
</tr>
</table>
</FooterTemplate>
</asp:Repeater>

<asp:Button runat="server" ID="btnRecalculate" Text="Пересчитать"/>