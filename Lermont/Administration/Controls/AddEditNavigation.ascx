<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEditNavigation.ascx.cs" Inherits="Administration_Controls_AddEditNavigation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="superi" Namespace="Superi.CustomControls" Assembly="Superi" %>
<script type="text/javascript">
    function selectNavType(type) {
        if (type == "text") {
            document.getElementById("textContainer").style.display = "block";
            document.getElementById("pageContainer").style.display = "none";
        }
    }

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
            $
        }
        else { 
        
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
        <%--<superi:ResourceEditor runat="server" ID="reTitle"></superi:ResourceEditor>--%>
    </div>
    <div style="clear:both">
        <asp:RadioButton Checked="true" runat="server" GroupName="navType" Text="�����" ID="rbText" />
        &nbsp;
        <asp:RadioButton runat="server" GroupName="navType" Text="����" ID="rbPage" />
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