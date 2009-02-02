<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticlesEditor.ascx.cs" Inherits="Administration_Controls_ArticlesEditor" %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.Articles" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:HiddenField runat="server" id="ihNodeID" />
    <asp:HiddenField runat="server" ID="hfArticleSelected" />
    
    <asp:GridView ID="gwArticles" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="gwArticles_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Заглавие" SortExpression="Title" />
            <asp:BoundField DataField="Alias" HeaderText="Адрес" SortExpression="Alias" />
            <asp:CommandField ShowEditButton="True" />
            <asp:CommandField ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:FormView ID="fwNewArticle" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
        <InsertItemTemplate>
            Заглавие:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
            </asp:TextBox><br />
            Адрес:
            <asp:TextBox ID="AliasTextBox" runat="server" Text='<%# Bind("Alias") %>'>
            </asp:TextBox><br />
            <div style="display:none;">
                <asp:TextBox ID="ScopeIDTextBox" runat="server" Text='<%# Bind("ScopeID")%>'></asp:TextBox>
            </div>
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Добавить">
            </asp:LinkButton>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:PlaceHolder runat="server" ID="phEdit">
        Заголовок:
        <Controls:ResourceEditor runat="server" ID="reTitle"></Controls:ResourceEditor>
        Краткое описание:
        <Controls:ResourceEditor runat="server" Type="MultiLine" ID="reShortDescription"></Controls:ResourceEditor>
        Содержимое:
        <Controls:ResourceEditor runat="server" Type="RichText" RichHeight="400" ID="reDescription"></Controls:ResourceEditor>
        Изображение: <br />
        <asp:Image runat="server" ID="iPicture" /><br />
        <asp:Button runat="server" ID="btnRemovePicture" Text="Удалить изображение" /><br />
        <asp:FileUpload ID="fuPicture" runat="server" /><br />
        <asp:Button ID="btnUpdate" runat="server" Text="Сохранить" />
    </asp:PlaceHolder>