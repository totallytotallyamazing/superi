<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddTradeMarks.ascx.cs" Inherits="Administration_Controls_AddTradeMarks" %>
<script type="text/javascript">
    function hideAddForm() {
        document.getElementById('tradeMarkInsert').style.display = 'none';
    }
    function showAddForm() {
        document.getElementById('tradeMarkInsert').style.display = 'block';
    }
</script>
<div>
    <input type="button" onclick="showAddForm()" value="Добавить ТМ" />
</div>
<div class="smallPopup" id="tradeMarkInsert" style="display:<%= displayMode%>">
    <asp:RadioButtonList runat="server" ID="rbType" RepeatDirection="Horizontal" 
        RepeatLayout="Flow">
        <asp:ListItem Selected="True" Text="Товары" Value="true"></asp:ListItem>
        <asp:ListItem Text="Услуги" Value="False"></asp:ListItem>
    </asp:RadioButtonList>
    <a onclick="hideAddForm()" style="cursor:pointer">X</a>
    <asp:PlaceHolder runat="server" ID="phTradeMarks">
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
        <asp:FileUpload runat="server" CssClass="defaultPopupField" />
    </asp:PlaceHolder>
    <asp:Button runat="server" ID="bAdd" Text="Добавить" onclick="bAdd_Click" />
</div>
