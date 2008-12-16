<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WeekEvents.ascx.cs" Inherits="Controls_WeekEvents" %>
<%@ Register TagPrefix="od" TagName="ThisDay" Src="~/Controls/ThisDay.ascx" %>
<asp:Repeater runat="server" ID="rDays" onitemdatabound="rDays_ItemDataBound">
    <ItemTemplate>
        <div class="weekDay">
            <od:ThisDay runat="server" Mode="Small" ID="tdDate" />
        </div>
        <br />
    </ItemTemplate>
</asp:Repeater>