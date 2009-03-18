<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Match.ascx.cs" Inherits="Controls_Match" %>

<div class="<%= matchMainClass %>">
    <div class="matchTeam">
        <div>
            <asp:Image runat="server" ID="iMaestro" ImageUrl="~/Images/mae.gif" />
        </div>
        <asp:Literal runat="server" ID="lMaestro"></asp:Literal>
    </div>
    <div class="matchDetails">
        <div class="matchCount">
            <asp:Literal runat="server" ID="lHostCount"></asp:Literal>
            :
            <asp:Literal ID="lTeamCount" runat="server"></asp:Literal>
        </div>
        <div class="matchDate">
            <asp:Literal ID="lDate" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="matchTeam">
        <div>
            <asp:Image runat="server" ID="iTeam" ImageUrl="~/Images/mae.gif" />
        </div>
        <asp:Literal runat="server" ID="lTeam"></asp:Literal>
    </div>
</div>
