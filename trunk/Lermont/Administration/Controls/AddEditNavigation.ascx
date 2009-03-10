<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEditNavigation.ascx.cs" Inherits="Administration_Controls_AddEditNavigation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="superi" Namespace="Superi.CustomControls" Assembly="Superi" %>
<script type="text/javascript">
    function popUpTexts() {
        openPopupWindow('TextsPopUp.aspx', 500, 400);
    }

    function setValue(id, name) {
        $('#<%= tbTextID.ClientID %>').attr({ title: id, value: name });
    }

    function updateDivVisibilities() {
        var rbText = document.getElementById("<%= rbText.ClientID %>");
        if (rbText.checked) {
            $("#textContainer").css("display", "block");
            $("#pageContainer").css("display", "none");
        }
        else {
            $("#textContainer").css("display", "none");
            $("#pageContainer").css("display", "block");
        }
    }

    $(function() {
        updateDivVisibilities();
    });
    
</script>
<div id="commonProperties">
    <div style="float:left">
        �������� ������: <br />
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
    </div>
    <div style="float:left;">
        ���������:
        <superi:ResourceEditor runat="server" ID="reTitle"></superi:ResourceEditor>
    </div>
    <div style="clear:both">
        <asp:CheckBox runat="server" ID="cbDisplay" Text="���������� � ����" />
    </div>
    <div style="clear:both">
        <asp:RadioButton Checked="true" runat="server" onclick="updateDivVisibilities();" GroupName="navType" Text="�����" ID="rbText" />
        &nbsp;
        <asp:RadioButton runat="server" onclick="updateDivVisibilities();" GroupName="navType" Text="����" ID="rbPage" />
    </div>
    <div id="textContainer">
        �������� ����� �� ����:<asp:TextBox ToolTip="foo" ReadOnly="true" runat="server" ID="tbTextID"></asp:TextBox>
        <input type="button" value="..." onclick="popUpTexts();" /><br />
        ���<br />
        �������� �����:
        <asp:TextBox runat="server" ID="tbNewTextTitle"></asp:TextBox>
        <asp:Button runat="server" ID="bCreateText" Text="�������" 
            onclick="bCreateText_Click" />
    </div>    
    <div id="pageContainer">
        ������� ������������� ���� � �����:<br />
        <asp:TextBox runat="server" ID="tbPage"></asp:TextBox>
    </div>
    <div>
        <asp:Button runat="server" ID="bSave" Text="���������" onclick="bSave_Click" />
    </div>
</div>