<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Matches.ascx.cs" Inherits="Controls_Matches" %>
<%@ Register TagPrefix="m" TagName="Match" Src="~/Controls/Match.ascx" %>
<asp:Repeater ID="rMatches" runat="server" 
    onitemdatabound="rMatches_ItemDataBound">
    <ItemTemplate>
        <m:Match runat="server" ID="mMatch" />
        
<%--                    HostCount='<%# Eval("HostCount") %>' 
            TeamCount='<%# Eval("TeamCount") %>' 
            ImageUrl='<%# Eval("Logo") %>'
            MatchDate='<%# Eval("Date") %>'
            Played='<%# Eval("Played") %>'
            TeamTextId='<%# Eval("TeamTextId") %>'--%>
    </ItemTemplate>
</asp:Repeater>