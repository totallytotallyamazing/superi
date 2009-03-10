<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Galleries" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    
    <asp:ObjectDataSource ID="odsGalleries" runat="server" DeleteMethod="Delete" 
        InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.Galleries" 
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TitleTextId" Type="Int32" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="ParentId" Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="TitleTextId" Type="Int32" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="ParentId" Type="Int32" DefaultValue="1" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="odsGalleries" DataKeyNames="ID">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="#" ReadOnly="True" 
                SortExpression="ID" />
            <asp:TemplateField HeaderText="Название" SortExpression="TitleTextId">
                <ItemTemplate>
                    <cc1:ResourceWritter ID="ResourceWritter1" ResourceId='<%# Bind("TitleTextId") %>' Language="RU" runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <cc1:ResourceEditor ResourceId='<%# Bind("TitleTextId") %>' ID="ResourceEditor1" runat="server">
                    </cc1:ResourceEditor>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Изображение">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl='<%# Eval("Picture", "~/Images/Gallery/{0}") %>' />
                </ItemTemplate>
                <EditItemTemplate>
                <cc1:FolderUpload ID="FolderUpload1" runat="server" Folder="~/Images/Gallery/" 
                    UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                    UploadedFile='<%# Bind("Picture") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField CancelText="Отмена" DeleteText="Удалить" 
                EditText="Редактировать" ShowDeleteButton="True" ShowEditButton="True" 
                UpdateText="Сохранить" />
        </Columns>
    </asp:GridView>
    <asp:FormView DefaultMode="Insert" ID="FormView1" runat="server" DataSourceID="odsGalleries">
        <InsertItemTemplate>
            Название:
                    <cc1:ResourceEditor ResourceId='<%# Bind("TitleTextId") %>' ID="ResourceEditor1" runat="server">
                    </cc1:ResourceEditor>

            <br />
            Изображение:
            <cc1:FolderUpload ID="FolderUpload1" runat="server" Folder="~/Images/Gallery/" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Picture") %>' />
            <br />
            <asp:LinkButton ID="lbAdd" runat="server" CausesValidation="True" 
                CommandName="Insert" Text="Добавить" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>

