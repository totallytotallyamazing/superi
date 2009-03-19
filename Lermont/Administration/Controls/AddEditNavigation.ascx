<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEditNavigation.ascx.cs" Inherits="Administration_Controls_AddEditNavigation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="superi" Namespace="Superi.CustomControls" Assembly="Superi" %>
<script type="text/javascript">
    function popUpTexts(el) {
        $("#textsList").css("display", "block").focus();
    }

    function setValue() {
        var lbTexts = document.getElementById('<%= lbTexts.ClientID %>');
        var id = lbTexts.options[lbTexts.selectedIndex].value;
        var name = lbTexts.options[lbTexts.selectedIndex].text;
        $("#textsList").css("display", "none");
        $('#<%= tbTextID.ClientID %>').attr("value", name);
        $("#<%= hfTextId.ClientID %>").attr("value", id);
    }

    function createText() {
        Common.CreateText($("#itNewTextName").attr("value"), createTextSuccess, createTextFail);
    }

    function createTextSuccess(result) {
        var tbTextID = document.getElementById('<%= tbTextID.ClientID %>')
        $(tbTextID).attr("title", result).attr("value", $("#itNewTextName").attr("value"));
        $("#itNewTextName").attr("value", "");
        var lbTexts = document.getElementById('<%= lbTexts.ClientID %>');
        lbTexts.options[lbTexts.length] = new Option(tbTextID.value, result);
    }

    function createTextFail() {
        alert("text fail");
    }

    function addingComplete() {
        window.opener.window.location.reload();
        window.close();
    }

    $(function() {
        $("#<%= lbTexts.ClientID %>").blur(function() { $("#textsList").css("display", "none"); });
    })
</script>
<div id="commonProperties">
    <div>
        �������� ������: <br />
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
    </div>
    <div>
        ���������:
        <superi:ResourceEditor runat="server" ID="reTitle"></superi:ResourceEditor>
    </div>
    <div style="clear:both">
        <asp:CheckBox runat="server" ID="cbDisplay" Text="���������� � ����" />
        <br />
        <cc1:TabContainer ID="tcTabs" runat="server" ActiveTabIndex="0">
            <cc1:TabPanel runat="server" HeaderText="�����">
                <ContentTemplate>
                    �������� ����� �� ����:<asp:TextBox ReadOnly="true" runat="server" ID="tbTextID"></asp:TextBox>
                    <asp:HiddenField runat="server" ID="hfTextId" />
                    <input type="button" value="..." onclick="popUpTexts(this);" /><br />
                    <div id="textsList" style="display:none;position:absolute;">
                        <asp:ListBox runat="server" ID="lbTexts" onclick="setValue();">
                        </asp:ListBox>
                    </div>
                    ���<br />
                    �������� �����:
                    <input type="text" id="itNewTextName" />
                    <input type="button" value="�������" onclick="createText()" />
                    </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" HeaderText="����">
                <ContentTemplate>
                    ������� ������������� ���� � �����:<br />
                    <asp:TextBox runat="server" ID="tbPage"></asp:TextBox>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    <div>
        <asp:Button runat="server" ID="bSave" Text="���������" onclick="bSave_Click" />
    </div>

</div>