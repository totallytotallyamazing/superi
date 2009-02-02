<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Structure.aspx.cs" Inherits="Administration_Structure" Title="Untitled Page" %>
<%@ Register TagPrefix="admin" TagName="NavigationTree" Src="~/Administration/Controls/NavigationTree.ascx" %>
<%@ Register TagPrefix="admin" TagName="ArticlesEditor" Src="~/Administration/Controls/ArticlesEditor.ascx" %>
<%@ Register TagPrefix="admin" TagName="TextEditor" Src="~/Administration/Controls/TextEditor.ascx" %>
<%@ Register TagPrefix="admin" TagName="GalleryEditor" Src="~/Administration/Controls/GalleryEditor.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="leftSide">
        <admin:NavigationTree runat="server" ID="ntStructure" OnSelectecIndexChanged="ntStructure_SelectecIndexChanged" />
    </div>
    <div id="rightSide">
        <asp:PlaceHolder runat="server" ID="phTextEditor">
            <admin:TextEditor runat="server" ID="teText" DisplayTitle="false" />
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="phArticlesEditor">
            <admin:ArticlesEditor runat="server" ID="aeArticles" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phObjects" runat="server">
            <admin:GalleryEditor runat="server" ID="geObjects" />
        </asp:PlaceHolder>
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Сохранить" />
        
    </div>
</asp:Content>

