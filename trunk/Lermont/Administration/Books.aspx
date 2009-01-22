<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Administration_Books" Title="Untitled Page" ValidateRequest="false" EnableEventValidation="false" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<%@ Register TagPrefix="admin" TagName="BookAddEdit" Src="~/Administration/Controls/BookAddEdit.ascx" %>
<%@ Register TagPrefix="admin" TagName="EditBookDescription" Src="~/Administration/Controls/EditBokDescription.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
        
        function BeginRequest(sender, args)
        {

        }
        
        function EndRequest(sender, args)
        {
            if(getAction()==='addEditBook')
            {
                var paramDiv = document.getElementById('addBookHolder');
                paramDiv.style.display='block';
                paramDiv.style.left=mousePosition.x+'px';
                paramDiv.style.top=mousePosition.y+'px';
            }
            else if(getAction()==='editDescription')
            {
                var editDiv = document.getElementById('editBookDescription');
                editDiv.style.display='block';
                editDiv.style.left=mousePosition.x+'px';
                editDiv.style.top=mousePosition.y+'px';
            }
            setAction('');
        }

        function closeParams(elId)
        {
            var paramDiv = document.getElementById(elId);
            paramDiv.style.display='none';
        }
        
        function setAction(action)
        {
            var ihAction = document.getElementById('ihAction');
            ihAction.value = action;
        }
        
        function getAction()
        {
            var ihAction = document.getElementById('ihAction');
            return ihAction.value;
        }
    </script>

    <input type="hidden" id="ihAction" />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Get" TypeName="Books"></asp:ObjectDataSource>
    <div style="text-align:left;">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Заголовок">
                <ItemTemplate>
                    <asp:Literal ID="lTitle" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbEdit" Text="Редактировать" CommandName="EditBook"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDescription" Text="Описание" CommandName="EditDescription"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbDelete" Text="Удалить" CommandName="DeleteBook"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:UpdatePanel runat="server" ID="upAddEditBook">
        <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbAdd" Text="Добавить" OnClick="lbAdd_Click"></asp:LinkButton>
            <div id="addBookHolder" style="display:none; position:absolute;">
                <div style="text-align:right;"><a href="javascript:closeParams('addBookHolder')">X</a></div>
                <admin:BookAddEdit runat="server" ID="baeMain" />
            </div>
            <div id="editBookDescription" style="display:none; position:absolute;">
                <div style="text-align:right;"><a href="javascript:closeParams('editBookDescription')">X</a></div>
                <admin:EditBookDescription runat="server" ID="ebdMain"/>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            <asp:PostBackTrigger ControlID="baeMain" />
            <asp:PostBackTrigger ControlID="ebdMain" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
</asp:Content>

