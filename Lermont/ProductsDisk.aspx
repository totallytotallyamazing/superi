﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProductsDisk.aspx.cs" Inherits="ProductsDisk" Title="Untitled Page" %>

<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <div id="disksHolder">
            <asp:UpdatePanel runat="server" ID="upDisks">
                <ContentTemplate>
                    <asp:Repeater ID="rDisks" runat="server" OnItemDataBound="rDisks_ItemDataBound">
                        <ItemTemplate>
                            <div class="disk">
                                <div class="diskCover">
                                    <asp:Image runat="server" CssClass="diskImageLink" ID="hlCover" />
                                </div>
                                <div class="diskInfo">
                                    <div class="diskSubTitle">
                                        <asp:Literal runat="server" ID="lSubTitle"></asp:Literal>
                                    </div>
                                    <div class="diskTitle">
                                        <asp:Label runat="server" ID="lTitle" CssClass="diskTitle"></asp:Label>
                                        &nbsp;
                                        <asp:HyperLink runat="server" ID="hlNewBook" Target="_blank" CssClass="diskNewDiskLink">
                                            <Controls:TextWriter ID="TextWriter1" TextName="newDisk" runat="server"></Controls:TextWriter>
                                        </asp:HyperLink>
                                    </div>
                                    <div class="diskPublisher">
                                        <asp:HyperLink Target="_blank" CssClass="diskPublisherLink" runat="server" ID="hlPublisher"></asp:HyperLink>
                                    </div>
                                    <div>
                                        <Controls:ResourceLabel ID="rlPrice" runat="server" ResourceName="price"></Controls:ResourceLabel>
                                        &nbsp;
                                        <asp:Label ID="tbPrice" runat="server" />
                                        <Controls:ResourceLabel ID="lCurrency" runat="server" ResourceName="currency" />
                                        <br />
                                        <br />
                                        <asp:CheckBox ID="cbBuy" runat="server" />&nbsp;
                                        <Controls:ResourceLabel ID="rlBuy" runat="server" ResourceName="buy" />
                                    </div>
                                    <div class="diskShortDescription">
                                        <asp:Literal runat="server" ID="lDescription"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <div class="diskSeparator">
                            </div>
                        </SeparatorTemplate>
                    </asp:Repeater>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAddToCart" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="btnAddToCart">
                <asp:Button Text="Добавить в корзину" runat="server" ID="btnAddToCart" 
                    onclick="btnAddToCart_Click" />
            </div>
        </div>
</asp:Content>
