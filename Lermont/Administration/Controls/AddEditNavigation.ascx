<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEditNavigation.ascx.cs" Inherits="Administration_Controls_AddEditNavigation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="superi" Namespace="Superi.CustomControls" Assembly="Superi" %>
<div id="commonProperties">
    <div style="float:left">
        Адресная строка: <br />
        <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
    </div>
    <div style="float:left;">
        Заголовок:
        <superi:ResourceEditor runat="server" ID="reTitle"></superi:ResourceEditor>
    </div>
    <div style="clear:both">
    </div>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1">
        <cc1:TabPanel runat="server" ID="textTab" HeaderText="Тексты">
            
        </cc1:TabPanel>
        <cc1:TabPanel runat="server" ID="articlesTab"></cc1:TabPanel>
        <cc1:TabPanel runat="server" ID="galleryTab"></cc1:TabPanel>
    </cc1:TabContainer>

</div>