<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Administration_Gallery" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsGallery" runat="server" 
        ContextTypeName="Galleria.GalleryDataContext" EnableDelete="True" 
        EnableInsert="True" EnableUpdate="True" TableName="Galleries" 
        Where="AlbumID == @AlbumID" OrderBy="SortOrder">
        <WhereParameters>
            <asp:ControlParameter ControlID="ddlAlbums" DefaultValue="0" Name="AlbumID" 
                PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:SqlDataSource ID="sdsGallery" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ContentConnectionString %>" 
        DeleteCommand="DELETE FROM [Gallery] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [Gallery] ([AlbumID], [Picture], [Thumbnail], [Title], [SortOrder]) VALUES (@AlbumID, @Picture, @Thumbnail, @Title, @SortOrder)" 
        SelectCommand="SELECT * FROM [Gallery] WHERE ([AlbumID] = @AlbumID) ORDER BY [SortOrder]" 
        UpdateCommand="UPDATE [Gallery] SET [SortOrder] = @SortOrder WHERE [ID] = @ID">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlAlbums" Name="AlbumID" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="AlbumID" Type="Int32" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="Thumbnail" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="SortOrder" Type="Int32" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="AlbumID" Type="Int32" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="Thumbnail" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="SortOrder" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>
    <center>
        Альбом:
        <asp:DropDownList ID="ddlAlbums" runat="server" AutoPostBack="True" />
        <br />
        Изображение: <cc1:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/Gallery/"
            UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
            UploadedFile='<%# Bind("Picture") %>' /><br />
        Превью: <cc1:FolderUpload ID="fuPreview" runat="server" Folder="~/Images/Gallery/" 
            UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
            UploadedFile='<%# Bind("Thumbnail") %>' />
        <br />
        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
            Text="Добавить" onclick="InsertButton_Click" />
        <br />
        <br />
        <cc2:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" 
            DataSourceID="sdsGallery" PostBackOnReorder="false"
            SortOrderField="SortOrder" DragHandleAlignment="Left" 
            DataKeyField="ID" onitemcommand="ReorderList1_ItemCommand">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server"
                        ImageUrl='<%# Eval("Thumbnail", "~/Images/Gallery/{0}") %>' />
                <br />
                <asp:LinkButton runat="server" Text="Удалить" ID="lbDelete" CommandName="DeleteItem" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton>
                <cc2:ConfirmButtonExtender ID="Image1_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Вы уверенны что хотите удалить картинку?" Enabled="True" TargetControlID="lbDelete">
                </cc2:ConfirmButtonExtender>
            </ItemTemplate>
            <DragHandleTemplate>
                <div style="height:80px; width:80px; cursor:n-resize; background-color:Teal;">
                    Потяните чтобы изменить положение
                </div>
            </DragHandleTemplate>
        </cc2:ReorderList>
    </center>

</asp:Content>

