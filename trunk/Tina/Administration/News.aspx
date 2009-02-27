<%@ Page Title="" Language="C#" ValidateRequest="false" EnableEventValidation="false" MasterPageFile="~/Administration/MasterPage.master"
    AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Administration_News" %>

<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>
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
                <asp:BoundField DataField="Title" HeaderText="���������" SortExpression="Title" />
                <asp:CheckBoxField DataField="Archive" HeaderText="� ������" SortExpression="Archive" />
                <asp:TemplateField HeaderText="����" SortExpression="Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="tbDate" runat="server" Text='<%# Bind("Date") %>' 
                            ReadOnly="True"></asp:TextBox>
                        <cc2:CalendarExtender ID="tbDate_CalendarExtender" runat="server" 
                            Enabled="True" Format="dd.MM.yyyy" TargetControlID="tbDate">
                        </cc2:CalendarExtender>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Date", "{0:dd.MM.yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�����������" SortExpression="Picture">
                    <EditItemTemplate>
                        <cc1:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/News/" UnificateIncrementally="True"
                            Unificator="_" UnificatorPosition="Postfix" UploadedFile='<%# Bind("Picture") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="iPicture" ImageUrl='<%# Eval("Picture", "~/Images/News/{0}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="������" DeleteText="�������" EditText="�������������"
                    SelectText="�������� �����" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True"
                    UpdateText="���������" />
            </Columns>
            <AlternatingRowStyle BackColor="LightGoldenrodYellow" ForeColor="#284775"></AlternatingRowStyle>
        </asp:GridView>
<%--        <asp:FormView DefaultMode="Insert" runat="server" ID="fwInsert" 
            DataKeyNames="ID" DataSourceID="ldsNews">
            <InsertItemTemplate>
                ���������:
                <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                    ControlToValidate="TitleTextBox" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                <br />
                ����:
                <asp:TextBox ID="tbDate" runat="server" 
                    Text='<%# Bind("Date", "{0: dd.MM.yyyy}") %>'></asp:TextBox>
                <cc2:CalendarExtender ID="tbDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd.MM.yyyy" TargetControlID="tbDate">
                </cc2:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" 
                    ControlToValidate="tbDate" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                <br />
                � ������:
                <asp:CheckBox ID="ArchiveCheckBox" runat="server" 
                    Checked='<%# Bind("Archive") %>' />
                <br />
                �����������:
                <cc1:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/News/" 
                    UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                    UploadedFile='<%# Bind("Picture") %>' />
                <asp:RequiredFieldValidator ID="rfvPicture" runat="server" 
                    ControlToValidate="fuPicture" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="��������" ValidationGroup="g1" />
            </InsertItemTemplate>
        </asp:FormView>--%>
        <div>
            <br />
            ���������:
            <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTitle" runat="server" 
                ControlToValidate="TitleTextBox" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
            <br />
            ����:
            <asp:TextBox ID="tbDate" runat="server" 
                Text='<%# Bind("Date", "{0: dd.MM.yyyy}") %>'></asp:TextBox>
            <cc2:CalendarExtender ID="tbDate_CalendarExtender" runat="server" 
                Enabled="True" Format="dd.MM.yyyy" TargetControlID="tbDate">
            </cc2:CalendarExtender>
            <asp:RequiredFieldValidator ID="rfvDate" runat="server" 
                ControlToValidate="tbDate" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
            <br />
            � ������:
            <asp:CheckBox ID="ArchiveCheckBox" runat="server" 
                Checked='<%# Bind("Archive") %>' />
            <br />
            �����������:
            <cc1:FolderUpload ID="fuPicture" runat="server" Folder="~/Images/News/" 
                UnificateIncrementally="True" Unificator="_" UnificatorPosition="Postfix" 
                UploadedFile='<%# Bind("Picture") %>' />
            <asp:RequiredFieldValidator ID="rfvPicture" runat="server" 
                ControlToValidate="fuPicture" ErrorMessage="*" ValidationGroup="g1"></asp:RequiredFieldValidator>
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                Text="��������" ValidationGroup="g1" onclick="InsertButton_Click" />
        </div>
    </div>
    <asp:Panel runat="server" ID="pEdit" Style="float: left; padding-left: 10px;">
        <div>
            �������� �����:
            <FCKeditor:FCKeditor Height="250px" Width="600" ID="fcText" runat="server" BasePath="~/Administration/Controls/fckeditor/">
            </FCKeditor:FCKeditor>
        </div>
        <div>
            ������ �����:
            <FCKeditor:FCKeditor Height="600px" Width="600" ID="fcDescription" runat="server" BasePath="~/Administration/Controls/fckeditor/">
            </FCKeditor:FCKeditor>
            <asp:LinkButton ID="bSave" runat="server" Text="���������" 
                onclick="bSave_Click" />
        </div>
    </asp:Panel>
</asp:Content>
