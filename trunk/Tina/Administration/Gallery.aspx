<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Administration_Gallery" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsGallery" runat="server" 
        ContextTypeName="Galleria.GalleryDataContext" EnableDelete="True" 
        EnableInsert="True" EnableUpdate="True" TableName="Galleries">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" 
        AlternatingRowStyle-BackColor="#FAFAD2" 
        AlternatingRowStyle-ForeColor="#284775"
        RowStyle-BackColor="#FFFBD6" 
        RowStyle-ForeColor="#333333"
        runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="ldsGallery" 
        onrowcreated="GridView1_RowCreated">
<RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:TemplateField HeaderText="Альбом" SortExpression="AlbumID">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlAlbums" runat="server" 
                        SelectedValue='<%# Bind("AlbumID") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Album.Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" HeaderText="Название" 
                SortExpression="Title" />
            <asp:TemplateField HeaderText="Файл изображения" SortExpression="Picture">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Picture") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Привью">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Thumbnail") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl='<%# Eval("Thumbnail", "~/Images/Gallery/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                CancelText="Отмена" DeleteText="Удалить" EditText="Изменить" 
                UpdateText="Сохранить" />
        </Columns>

<AlternatingRowStyle BackColor="LightGoldenrodYellow" ForeColor="#284775"></AlternatingRowStyle>
    </asp:GridView>
    
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" InsertRowStyle-HorizontalAlign="Right" 
        DataSourceID="ldsGallery" DefaultMode="Insert">
        <InsertItemTemplate>
            Альбом:
            <asp:DropDownList ID="ddlAlbums" runat="server" 
                SelectedValue='<%# Bind("AlbumID") %>'>
            </asp:DropDownList>
            <br />
            Подпись:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
            <br />
            Изображение: <cc1:FolderUpload ID="FolderUpload1" runat="server" Folder="" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Picture") %>' /><br />
            Превью: <cc1:FolderUpload ID="FolderUpload2" runat="server" Folder="" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Thumbnail") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Добавить" />
        </InsertItemTemplate>
    </asp:FormView>
    
</asp:Content>

