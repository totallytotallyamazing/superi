<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Paging.ascx.cs" Inherits="Controls_Paging" %>
<div>
<asp:HyperLink runat="server" ID="hlFirst" Text="&lt;&lt;"></asp:HyperLink>
</div>
&nbsp;
<div>
<asp:HyperLink runat="server" ID="hlPrevious" Text="&lt;"></asp:HyperLink>
</div>
&nbsp;
<asp:Repeater runat="server" ID="rPages" OnItemDataBound="rPages_ItemDataBound">
    <ItemTemplate>
        <asp:HyperLink runat="server" ID="hlPage"></asp:HyperLink>
        <asp:Label runat="server" ID="lCurrentPage" CssClass="currentPage"></asp:Label>
    </ItemTemplate>
    <SeparatorTemplate>
        &nbsp;
    </SeparatorTemplate>
</asp:Repeater>
&nbsp;
<div>
<asp:HyperLink runat="server" ID="hlNext" Text="&gt;"></asp:HyperLink>
</div>
&nbsp;
<div>
<asp:HyperLink runat="server" ID="hlLast" Text="&gt;&gt;"></asp:HyperLink>
</div>