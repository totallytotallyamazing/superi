<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThisDay.ascx.cs" Inherits="Controls_ThisDay" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Flyout2" Assembly="obout_Flyout2_NET"%>
<asp:Panel runat="server" ID="pDay">
    <asp:Label runat="server" ID="lDay"></asp:Label>
</asp:Panel>
<asp:Panel runat="server" ID="pDate">
    <div class="todayMonth">
        <asp:Label runat="server" ID="lMonth"></asp:Label>    
    </div>
    <div class="todayDate">
        <asp:Label runat="server" ID="lDate"></asp:Label>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="pHolidays">
    <asp:Repeater runat="server" ID="rHolidays" 
        onitemdatabound="rHolidays_ItemDataBound">
        <ItemTemplate>
            <div>
                <asp:HyperLink runat="server" ID="hlHoliday" CssClass="todayHoliday"></asp:HyperLink>
                <obout:Flyout AttachTo="hlHoliday" runat="server" OpenEvent="ONCLICK" ID="fDescription">
                    <div class="descriptionDiv">
                        <asp:Literal runat="server" ID="lDescription"></asp:Literal>
                    </div>
                </obout:Flyout>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Panel>