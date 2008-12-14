<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarMonth.ascx.cs" Inherits="Controls_CalendarMonth" %>
<div class="week">
    <asp:Repeater runat="server" ID="rMonday" onitemdatabound="rWednesday_ItemDataBound">
        <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rTuesday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rWednesday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rThursday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rFriday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rSaturday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="week">
    <asp:Repeater runat="server" ID="rSunday" onitemdatabound="rWednesday_ItemDataBound">
            <ItemTemplate>
            <div class="day">
                <asp:HyperLink runat="server" CssClass="dayLink" ID="hlDay"></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>