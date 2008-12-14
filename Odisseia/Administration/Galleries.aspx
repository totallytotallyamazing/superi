<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Galleries.aspx.cs" Inherits="Administration_Galleries" MasterPageFile="~/Administration/MasterPage.master" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.Galleries" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Title" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Title" Type="String" />
            </InsertParameters>
        </asp:ObjectDataSource>
        
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowCommand="GridView1_RowCommand" OnRowUpdated="GridView1_RowUpdated" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" DeleteText="Удалить" EditText="Редактировать" CancelText="Отмена" UpdateText="Сохранить" />
                <asp:TemplateField HeaderText="Изображение">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="iPicture" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Image runat="server" ID="iPicture" /><br />
                        <asp:FileUpload runat="server" ID="fuPicture" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Название">
                    <ItemTemplate>
                        <asp:Literal ID="lTitle" runat="server"></asp:Literal>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <Controls:ResourceEditor ID="reTitle" runat="server"></Controls:ResourceEditor>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" HeaderStyle-CssClass="invissible" ItemStyle-CssClass="invissible" ControlStyle-CssClass="invissible" />
            </Columns>
        </asp:GridView>
        
        <asp:FormView ID="FormView1" runat="server" DefaultMode="Insert" OnItemCommand="FormView1_ItemCommand" OnItemInserting="FormView1_ItemInserting">
            <InsertItemTemplate>
                Название:
                <Controls:ResourceEditor ID="reTitles" runat="server"></Controls:ResourceEditor>
                Изображение:
                <asp:FileUpload runat="server" ID="fuPicture" />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CommandName="InsertItem" Text="Добавить">
                </asp:LinkButton>
            </InsertItemTemplate>
        </asp:FormView>
</asp:Content>