<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigationTree.ascx.cs" Inherits="Administration_Controls_NavigationTree" %>
<input type="hidden" runat="server" id="ihNodeID" />
<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged">
</asp:TreeView>