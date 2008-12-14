<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="framesHolder">
        <div id="framesTop">
            <div id="leftFrameTop">
                
            </div>
            <div id="rightFrameTop">
                
            </div>
        </div>
        <div id="framesMiddle">
            <div id="leftFrame">
                <asp:DataList runat="server" ID="dlGoods" onitemdatabound="dlGoods_ItemDataBound" RepeatColumns="5" CellSpacing="5">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:HyperLink ID="hlTradeMark" runat="server"></asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div id="rightFrame">
                <asp:DataList ID="dlServices" runat="server" onitemdatabound="dlGoods_ItemDataBound" RepeatColumns="5" CellSpacing="5">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:HyperLink runat="server" ID="hlTradeMark"></asp:HyperLink>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div id="framesBottom">
            <div class="frameBottomLeft">
                
            </div>
            <div class="frameBottomRight">
                
            </div>
        </div>

    </div>
</asp:Content>


