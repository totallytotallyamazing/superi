<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Wallpapers.aspx.cs" Inherits="Administration_Wallpapers" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" 
        TypeName="Superi.Features.GalleryItems">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="-1" Name="GalleryID" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="TitleTextId" Type="Int32" />
            <asp:Parameter Name="GalleryId" Type="Int32" DefaultValue="-1" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ObjectDataSource1" DataKeyNames="ID">
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
            <asp:ImageField DataImageUrlField="Preview" ReadOnly="true"
                DataImageUrlFormatString="~/Images/Gallery/{0}" HeaderText="Привью">
            </asp:ImageField>
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

