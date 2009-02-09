<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Articles.aspx.cs" Inherits="Administration_Articles" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function checkScopeName()
    {
        var tbScopeName = document.getElementById(<%=  tbScopeName.ClientID%>);
        if(tbScopeName && tbScopeName.value!='')
            return true;
        else
            return false;
    }   
</script>

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
            <asp:ControlParameter ControlID="ihNodeID" DefaultValue="1" Name="ScopeID" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:HiddenField runat="server" id="ihNodeID" Value="1" />
    <asp:HiddenField runat="server" ID="hfArticleSelected" />
    
<table style="width:100%; min-height:300px;">
    <tr>
        <td valign="top" style="width:272px; border:1px solid #8c8c8c;display:none;">
            <asp:TreeView runat="server" ID="twScopes" Width="100%" OnSelectedNodeChanged="twScopes_SelectedNodeChanged" ShowCheckBoxes="All"></asp:TreeView><br />
            <asp:TextBox runat="server" ID="tbScopeName"></asp:TextBox>
            <asp:Button runat="server" Text="Создаь раздел" ID="btnAddScope" OnClick="btnAddScope_Click" /><br />
            <asp:Button runat ="server" Text="(в корне)" ID="btnAddRootScope" OnClick="btnAddRootScope_Click" />
            <asp:Button runat="server" ID="btnRemoveScopes" Text="Удалить отмеченные" OnClick="btnRemoveScopes_Click" />
        </td>
        <td valign="Top">
            <div id="divGrids" runat="server">
                <asp:GridView ID="gwArticles" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="gwArticles_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                        <asp:BoundField DataField="Title" HeaderText="Заголовок" SortExpression="Title" />
                        <asp:BoundField DataField="Alias" HeaderText="Адресная строка" SortExpression="Alias" />
                        <asp:CommandField ShowEditButton="True" EditText="Изменить адрес и заголовок" UpdateText="Сохранить" CancelText="Отмена" />
                        <asp:CommandField ShowSelectButton="True" SelectText="Редактировать" />
                        <asp:CommandField ShowDeleteButton="True" DeleteText="Удалить" />
                    </Columns>
                </asp:GridView>
                <asp:FormView ID="fwNewArticle" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
                    <InsertItemTemplate>
                        Заголовок:
                        <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
                        </asp:TextBox><br />
                        Адресная строка:
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
            </div>
        </td>
    </tr>
</table>

</asp:Content>

