<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddVouchers.ascx.cs" Inherits="Administration_Controls_AddVouchers" %>
<script type="text/javascript">
    function verifyVoucherValues() {
        var addVouchers = document.getElementById('validationZone');
        var enteredValues = 0;
        for (var i in addVouchers.childNodes) {
            if (addVouchers.childNodes[i].value && addVouchers.childNodes[i].value !== '') {
                if (!checkInteger(addVouchers.childNodes[i].value)) {
                    alert('Введите целое число');
                    addVouchers.childNodes[i].focus();
                    return false;
                }
                else {
                    enteredValues = enteredValues + 1;
                }
            }
        }
        if (enteredValues == 0) {
            alert('Введите хотя бы одно значение');
            return false;
        }
        return true;
    }
    
    function checkInteger(value){
        if (isNaN(parseInt(value))) {
            return false;
        }
        else {
            return true;
        }
    }

    function hideVouchersAdd() {
        document.getElementById('addVouchers').style.display = 'none';
    }

    function showAddVoucher() {
        document.getElementById('addVouchers').style.display = 'block';
    }
    
</script>
<div>
    <input type="button" onclick="showAddVoucher()" value="Добавить сертификаты"/>
</div>
<div id="addVouchers" class="smallPopup" style="display:<%= displayMode%>">
    <div>
        <a style="cursor:pointer;" onclick="hideVouchersAdd()">X</a>
    </div>
    <div id="validationZone">
        <asp:PlaceHolder runat="server" ID="phNominals">
            <asp:TextBox runat="server" CssClass="defaultPopupField"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="defaultPopupField"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="defaultPopupField"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="defaultPopupField"></asp:TextBox>
            <asp:TextBox runat="server" CssClass="defaultPopupField"></asp:TextBox>
        </asp:PlaceHolder>
    </div>
    <asp:Button runat="server" ID="bAdd" onclick="bAdd_Click" Text="Добавить" />
</div>
