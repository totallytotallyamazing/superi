<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="Articles.aspx.cs" Inherits="Administration_Articles"
    Title="Untitled Page" %>

<%@ Register TagPrefix="Controls" Assembly="Superi" Namespace="Superi.CustomControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function checkScopeName() {
            var tbScopeName = document.getElementById('<%=  tbScopeName.ClientID%>');
            if (tbScopeName && tbScopeName.value != '')
                return true;
            else
                return false;
        }
        //alert("Пожалуйста не трогайте новости (Игроков можно). Когда новости будут готовы, это сообщение появляться не будет");
    </script>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete"
        InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.Articles"
        UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ihNodeID" DefaultValue="-1" Name="ScopeID" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ScopeID" Type="Int32" />
            <asp:Parameter Name="TitleTextID" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField runat="server" ID="ihNodeID" />
    <asp:SqlDataSource ID="sdsArticles" runat="server" ConnectionString="<%$ ConnectionStrings:_1gb_MaestroConnectionString %>"
        SelectCommand="SELECT [ID], [TitleTextID], [SortOrder], [Title], [Alias] FROM [Articles] WHERE ([ScopeID] = @ScopeID) ORDER BY [SortOrder]"
        DeleteCommand="DELETE FROM [Articles] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Articles] ([TitleTextID], [SortOrder], [Title], [Alias]) VALUES (@TitleTextID, @SortOrder, @Title, @Alias)"
        UpdateCommand="UPDATE [Articles] SET [TitleTextID] = @TitleTextID, [SortOrder] = @SortOrder, [Title] = @Title, [Alias] = @Alias WHERE [ID] = @ID">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="ScopeID" Type="Int32" />
        </SelectParameters>
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="TitleTextID" Type="Int32" />
            <asp:Parameter Name="SortOrder" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Alias" Type="String" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="TitleTextID" Type="Int32" />
            <asp:Parameter Name="SortOrder" Type="Int32" />
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Alias" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <table style="width: 100%; min-height: 300px;">
        <tr>
            <td valign="top" style="width: 272px; border: 1px solid #8c8c8c">
                <asp:TreeView runat="server" ID="twScopes" Width="100%" OnSelectedNodeChanged="twScopes_SelectedNodeChanged"
                    ShowCheckBoxes="All">
                </asp:TreeView>
                <br />
                <asp:TextBox runat="server" ID="tbScopeName"></asp:TextBox>
                <asp:Button runat="server" Text="Создаь раздел" ID="btnAddScope" OnClick="btnAddScope_Click" /><br />
                <asp:Button runat="server" Text="(в корне)" ID="btnAddRootScope" OnClick="btnAddRootScope_Click" />
                <asp:Button runat="server" ID="btnRemoveScopes" Text="Удалить отмеченные" OnClick="btnRemoveScopes_Click" />
            </td>
            <td valign="Top">
                <div id="divGrids" runat="server">
                    <asp:GridView ID="gwArticles" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                        DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="gwArticles_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="#" SortExpression="ID" />
                            <asp:TemplateField HeaderText="Заголовок" SortExpression="Title">
                                <ItemTemplate>
                                    <Controls:ResourceWritter ID="ResourceWritter1" runat="server" Language="RU" 
                                        ResourceId='<%# Eval("TitleTextID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField SelectText="Редактировать" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                    <%--                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>
                    <cc1:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" DataSourceID="sdsArticles"
                        PostBackOnReorder="True" OnItemDataBound="ReorderList1_ItemDataBound" CssClass="rl"
                        SortOrderField="SortOrder" OnItemCommand="ReorderList1_ItemCommand">
                        <ItemTemplate>
                            <div class="article">
                                <div class="articleName">
                                    <asp:Literal ID="lTitle" runat="server"></asp:Literal></div>
                                <div class="articleActions">
                                    <asp:LinkButton runat="server" ID="lbEdit" Text="Редактировать" CommandName="EditArticle"></asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="lbDelete" Text="Удалить" CommandName="DeleteArticle"></asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                        <ReorderTemplate>
                            <div class="reorderItem">
                            </div>
                        </ReorderTemplate>
                        <DragHandleTemplate>
                            <div class="dragHandle">
                                &gt;
                            </div>
                        </DragHandleTemplate>
                    </cc1:ReorderList>
                    <%--                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ReorderList1" EventName="ItemReorder" />
                            <asp:AsyncPostBackTrigger ControlID="fwNewArticle" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    <asp:FormView ID="fwNewArticle" runat="server" DataSourceID="ObjectDataSource1" DefaultMode="Insert">
                        <InsertItemTemplate>
                            <div style="display: none;">
                                Title:
                                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
                                </asp:TextBox><br />
                            </div>
                            <div style="display:none"> 
                                Идентификатор:
                                <asp:TextBox ID="AliasTextBox" runat="server" Text='<%# Bind("Alias") %>'>
                                </asp:TextBox><br />
                                <div style="display: none;">
                                    <asp:TextBox ID="ScopeIDTextBox" runat="server" Text='<%# Bind("ScopeID")%>'></asp:TextBox>
                                </div>
                            </div>
                            Имя игрока / Заголовок новости:
                            <Controls:ResourceEditor runat="server" ID="reTitle" ResourceId='<%# Bind("TitleTextID") %>' />
                            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                Text="Добавить">
                            </asp:LinkButton>
                        </InsertItemTemplate>
                    </asp:FormView>
                    <%--                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>--%>
                    <asp:HiddenField runat="server" ID="hfArticleSelected" />
                    <asp:PlaceHolder runat="server" ID="phEdit">Заголовок:
                        <Controls:ResourceEditor runat="server" ID="reTitle">
                        </Controls:ResourceEditor>
                        <asp:PlaceHolder runat="server" ID="phShort">
                            Дата: <asp:TextBox runat="server" ID="tbDate"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="tbDate" Format="dd.MM.yyyy">
                            </cc1:CalendarExtender>
                            Краткое описание:
                            <Controls:ResourceEditor runat="server" Type="MultiLine" ID="reShortDescription">
                            </Controls:ResourceEditor>
                        </asp:PlaceHolder>
                        Содержимое:
                        <Controls:ResourceEditor runat="server" Type="RichText" RichHeight="400" ID="reDescription">
                        </Controls:ResourceEditor>
                        Изображение:
                        <br />
                        <asp:Image runat="server" ID="iPicture" /><br />
                        <asp:Button runat="server" ID="btnRemovePicture" Text="Удалить изображение" /><br />
                        <asp:FileUpload ID="fuPicture" runat="server" /><br />
                        <asp:PlaceHolder runat="server" ID="phLargePicture">Большое изображение:
                            <Controls:FolderUpload Folder="~/Images/ArticleImages/" runat="server" ID="fuLargePicture" />
                        </asp:PlaceHolder>
                        <asp:Button ID="btnUpdate" runat="server" Text="Сохранить" />
                    </asp:PlaceHolder>
                    <%--                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ReorderList1" EventName="ItemCommand" />
                            <asp:PostBackTrigger ControlID="btnUpdate" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
