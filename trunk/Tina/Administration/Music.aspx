<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Music.aspx.cs" Inherits="Administration_Music" %>

<%@ Register assembly="Superi" namespace="Superi.CustomControls" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:LinqDataSource ID="ldsSongs" runat="server" 
        ContextTypeName="MusicDataContext" EnableDelete="True" EnableInsert="True" 
        TableName="Songs" Where="AlbumId == @AlbumId1">
        <WhereParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="0" 
                Name="AlbumId1" PropertyName="SelectedValue" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="ldsAlbums" runat="server" 
        ContextTypeName="Musics.MusicDataContext" EnableDelete="True" EnableInsert="True" 
        EnableUpdate="True" TableName="Albums">
    </asp:LinqDataSource>
    <div style="float:left;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" DataSourceID="ldsAlbums">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name" />
                <asp:BoundField DataField="Year" HeaderText="Год" SortExpression="Year" />
                <asp:TemplateField HeaderText="Фон">
                    <ItemTemplate>
                        <asp:Image Width="102" Height="77" ID="Image1" runat="server" 
                            ImageUrl='<%# Eval("Image", "~/Images/AlbumImages/{0}") %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="imageSmall" Height="76px" Width="102px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Фон для фото">
<%--                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>--%>
                    <ItemTemplate>
                        <asp:Image Width="102" Height="77"  ID="Image2" runat="server" ImageUrl='<%# Eval("PhotoImage", "~/Images/AlbumImages/{0}")%>' />
                    </ItemTemplate>
                     <ItemStyle CssClass="imageSmall" Height="76px" Width="102px" />
                </asp:TemplateField>
                <asp:CheckBoxField DataField="InvertColors" HeaderText="Черный" 
                    SortExpression="InvertColors" />
                <asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
            </Columns>
            <EmptyDataTemplate>
                empty
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ID" 
            DataSourceID="ldsAlbums" DefaultMode="Insert">
            <InsertItemTemplate>
                Название:
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="NameTextBox" ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                <br />
                Год:
                <asp:TextBox ID="YearTextBox" runat="server" Text='<%# Bind("Year") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="YearTextBox" ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                <br />
                Изображение:
                <cc1:FolderUpload ID="FolderUpload1" runat="server" 
                    Folder="~/Images/AlbumImages/" UnificateIncrementally="True" Unificator="_" 
                    UnificatorPosition="Postfix" UploadedFile='<%# Bind("Image") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="FolderUpload1" ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                    
                Фон для фото:
                <cc1:FolderUpload ID="FolderUpload3" runat="server" 
                    Folder="~/Images/AlbumImages/" UnificateIncrementally="True" Unificator="_" 
                    UnificatorPosition="Postfix" UploadedFile='<%# Bind("PhotoImage") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="FolderUpload3" ErrorMessage="*" ValidationGroup="v1"></asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Добавить" ValidationGroup="v1" />
                &nbsp;
            </InsertItemTemplate>
        </asp:FormView>
    </div>
    <div style="float:left; padding-left:100px;">
    
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ldsAlbums" 
            DataTextField="Name" DataValueField="ID" AutoPostBack="True" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="ID" DataSourceID="ldsSongs">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="#" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Название" SortExpression="Name" />
                <asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    
        <asp:FormView ID="FormView2" runat="server" DataKeyNames="ID" 
            DataSourceID="ldsSongs" DefaultMode="Insert" 
            FooterStyle-VerticalAlign="NotSet" onitemcommand="FormView2_ItemCommand">
            <InsertItemTemplate>
                Название:
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="NameTextBox" ErrorMessage="*" ValidationGroup="v2"></asp:RequiredFieldValidator>
                <br />
                Файл MP3:
                <cc1:FolderUpload ID="FolderUpload2" runat="server" Folder="~/Songs/" 
                    UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                    UploadedFile='<%# Bind("Source") %>' />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FolderUpload2" 
                    ErrorMessage="*" ValidationGroup="v2"></asp:RequiredFieldValidator>
                <br />
                <asp:HiddenField ID="hfAlbumID" runat="server" Value='<%# Bind("AlbumId") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Добавить" ValidationGroup="v2" />
                &nbsp;
            </InsertItemTemplate>
        </asp:FormView>
    
    </div>
</asp:Content>

