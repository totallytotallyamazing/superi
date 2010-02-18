<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.ascx.cs" Inherits="Trips.Web.Controls.MainMenu" %>
<div id="box">
    <div class="headerMenuItem">
        <a href="/Request.aspx">
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Catalogue.aspx">
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Catalogue %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Conditions.aspx">
            <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Conditions %>"></asp:Literal>
        </a>
    </div>
    <div class="headerMenuItem">
        <a href="/Contacts.aspx">
            <asp:Literal ID="Literal4" runat="server" Text="<%$ Resources:WebResources, Contacts %>"></asp:Literal>
        </a>
    </div>
</div>
