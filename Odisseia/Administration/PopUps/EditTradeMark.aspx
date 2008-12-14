<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditTradeMark.aspx.cs" ValidateRequest="false" EnableEventValidation="false" Inherits="Administration_PopUps_EditTradeMark" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Register TagPrefix="Admin" TagName="AddNominals" Src="~/Administration/Controls/AddVouchers.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="../css/admin.css" />
</head>
<body style="text-align:left; padding:10px;">
    <form id="form1" runat="server">
        <div class="adminSection">
            Название:
            <asp:TextBox runat="server" ID="tbName" CssClass="defaultPopupField"></asp:TextBox>
        </div>
        <div class="adminSection">
            <Admin:AddNominals runat="server" />
        </div>
        <div class="adminSection">
            <asp:Repeater runat="server" ID="rVouchers" 
                onitemcommand="rVouchers_ItemCommand" onitemdatabound="rVouchers_ItemDataBound">
                <ItemTemplate>
                    <asp:Label ID="lNominal" runat="server"></asp:Label>
                    &nbsp;
                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="Delete" Text="X"></asp:LinkButton>
                </ItemTemplate>
                <SeparatorTemplate>
                    &nbsp;|&nbsp;
                </SeparatorTemplate>
            </asp:Repeater>
        </div>
        <div class="adminSection">
            <div style="float:left">
                <asp:Image runat="server" ID="iLogo" />
                <br />
                <asp:FileUpload runat="server" ID="fuPicture" />
                <asp:Button ID="bChangeLogo" runat="server" Text="Сменить лого" OnClick="bChangeLogo_Click" />
            </div>
            <div style="float:left; padding-left:10px; position:relative; top:-50px; left:30px;">
                    <asp:CheckBox runat="server" ID="cbMan" Text="Для мужчины" />
                    <br />
                    <asp:CheckBox runat="server" ID="cbWoman" Text="Для женцины" />
                    <br />
                    Праздники:
                    <div class="scrollable bordered">
                        <asp:CheckBoxList runat="server" ID="cblHolidays"></asp:CheckBoxList>
                    </div>                
            </div>
        </div>
        <div class="adminSection">
            Описание:
            <FCKeditor:FCKeditor runat="server" ID="fcDescription" BasePath="~/Administration/Controls/fckeditor/"></FCKeditor:FCKeditor>
        </div>
        <div class="adminSection">
            Резюме:
            <FCKeditor:FCKeditor BasePath="~/Administration/Controls/fckeditor/" runat="server" ID="fcSummary"></FCKeditor:FCKeditor>
        </div>
        <div>
            Кому подарить:
            <asp:TextBox runat="server" ID="tbRecipient" CssClass="defaultPopupField"></asp:TextBox>
        </div>
        <div class="adminSection">
            Когда подарить:
            <asp:TextBox runat="server" ID="tbOcassion" CssClass="defaultPopupField"></asp:TextBox>
        </div>
        <div class="adminSection">
            Что вы получите:
            <asp:TextBox runat="server" ID="tbEventSuggestion" CssClass="defaultPopupField"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="bSave" Text="Сохранить" onclick="bSave_Click"/>
    </form>
</body>
</html>
