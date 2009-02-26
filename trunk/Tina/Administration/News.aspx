<%@ Page Title="" Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Administration_News" %>

<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LinqDataSource ID="ldsNews" runat="server" ContextTypeName="NewsDataContext"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" 
        TableName="NewsItems" Where="Award == false">
    </asp:LinqDataSource>
    <div style="float: left">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-BackColor="#FAFAD2"
            AlternatingRowStyle-ForeColor="#284775" RowStyle-BackColor="#FFFBD6" RowStyle-ForeColor="#333333"
            DataKeyNames="ID" DataSourceID="ldsNews" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating">
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
                <asp:BoundField DataField="Title" HeaderText="Заголовок" SortExpression="Title" />
                <asp:CheckBoxField DataField="Archive" HeaderText="В архиве" SortExpression="Archive" />
                <asp:TemplateField HeaderText="Изображение" SortExpression="Picture">
                    <EditItemTemplate>
                        <cc1:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/News/" UnificateIncrementally="True"
                            Unificator="_" UnificatorPosition="Postfix" UploadedFile='<%# Bind("Picture") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="iPicture" ImageUrl='<%# Eval("Picture", "~/Images/News/{0}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="Отмена" DeleteText="Удалить" EditText="Редактировать"
                    SelectText="Изменить текст" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"
                    UpdateText="Сохранить" />
            </Columns>
            <AlternatingRowStyle BackColor="LightGoldenrodYellow" ForeColor="#284775"></AlternatingRowStyle>
        </asp:GridView>
        <asp:FormView DefaultMode="Insert" runat="server" ID="fwInsert" 
            DataKeyNames="ID" DataSourceID="ldsNews">
            <InsertItemTemplate>
                Заголовок:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                <br />
                В архиве:
                <asp:CheckBox ID="ArchiveCheckBox" runat="server" 
                    Checked='<%# Bind("Archive") %>' />
                <br />
                Изображение:
                <cc1:FolderUpload ID="FolderUpload1" runat="server" Folder="~/Images/News/" 
                    UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                    UploadedFile='<%# Bind("Picture") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Добавить" />
                &nbsp;
            
            </InsertItemTemplate>
        </asp:FormView>
    </div>
    <asp:Panel runat="server" ID="pEdit" Style="float: left; padding-left: 10px;">
        <div>
            Короткий текст:
            <FCKeditor:FCKeditor Height="250px" Width="600" ID="fcText" runat="server" BasePath="~/Administration/Controls/fckeditor/">
            </FCKeditor:FCKeditor>
        </div>
        <div>
            Полный текст:
            <FCKeditor:FCKeditor Height="600px" Width="600" ID="fcDescription" runat="server" BasePath="~/Administration/Controls/fckeditor/">
            </FCKeditor:FCKeditor>
            <asp:LinkButton ID="bSave" runat="server" Text="Сохранить" 
                onclick="bSave_Click" />
        </div>
    </asp:Panel>
</asp:Content>
