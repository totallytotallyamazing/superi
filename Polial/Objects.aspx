<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Objects.aspx.cs" Inherits="Objects" Title="Untitled Page" %>
<%@ Register TagPrefix="polial" TagName="Paging" Src="~/Controls/Paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater runat="server" ID="rObjects" OnItemDataBound="rObjects_ItemDataBound">
        <ItemTemplate>
            <div class="oddObject">
                <div class="objectImageHolder">
                    <asp:HyperLink ID="hlPreview" BorderColor="Black" BorderWidth="1" runat="server"></asp:HyperLink>
                </div>
                <div class="objectDetails">
                    <div class="objectTitle">
                        <asp:Literal runat="server" ID="lTitle"></asp:Literal>
                    </div>
                    <div class="objectLogo">
                        <asp:Image runat="server" ID="iLogo" />
                    </div>
                    <div class="objectProperties">
                        <div>
                            <asp:Literal runat="server" ID="lClient"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lAddress"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lYear"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lSquare"></asp:Literal>
                        </div>
                        <div>
                        <asp:Literal runat="server" ID="lWorkKinds"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="evenObject">
                <div class="objectImageHolder">
                    <asp:HyperLink ID="hlPreview" BorderColor="Black" BorderWidth="1" runat="server"></asp:HyperLink>
                </div>
                <div class="objectDetails">
                    <div class="objectTitle">
                        <asp:Literal runat="server" ID="lTitle"></asp:Literal>
                    </div>
                    <div class="objectLogo">
                        <asp:Image runat="server" ID="iLogo" />
                    </div>
                    <div class="objectProperties">
                        <div>
                            <asp:Literal runat="server" ID="lClient"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lAddress"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lYear"></asp:Literal>
                        </div>
                        <div>
                            <asp:Literal runat="server" ID="lSquare"></asp:Literal>
                        </div>
                        <div>
                        <asp:Literal runat="server" ID="lWorkKinds"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</asp:Content>

