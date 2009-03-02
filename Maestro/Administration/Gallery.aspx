<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Administration_Gallery" %>
<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" 
        TypeName="Superi.Features.GalleryItems">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlGalleries" DefaultValue="-1" 
                Name="GalleryID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="TitleTextId" Type="Int32" />
            <asp:ControlParameter ControlID="ddlGalleries" DefaultValue="-1" 
                Name="GalleryID" PropertyName="SelectedValue" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlGalleries"></asp:DropDownList>
    
    <asp:GridView DataKeyNames="ID" ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" ReadOnly="True" 
                SortExpression="ID" />
            <asp:TemplateField HeaderText="Название" SortExpression="TitleTextId">
                <ItemTemplate>
                    <cc1:ResourceWritter ID="ResourceWritter1" runat="server" Language="RU" 
                        ResourceId='<%# Eval("TitleTextId") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TitleTextId") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Привью">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl='<%# Eval("Preview", "~/Images/Gallery/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    
    <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" 
        DefaultMode="Insert">
        <InsertItemTemplate>
            Изображение:
            <cc1:FolderUpload ID="FolderUpload1" runat="server" Folder="~/Images/Gallery/" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Picture") %>' />
            <br />
            Привью:
            <cc1:FolderUpload ID="FolderUpload2" runat="server" Folder="~/Images/Gallery/" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Preview") %>' />
            <br />
            Подпись:
            <cc1:ResourceEditor ID="ResourceWritter2" runat="server" 
                ResourceId='<%# Bind("TitleTextId") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Добавить" />
            &nbsp;
        </InsertItemTemplate>
    </asp:FormView>
    
</asp:Content>

