<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Administration_Books" Title="Untitled Page" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
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
    
    <ajax:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" 
            DataSourceID="dsProducts" onitemdatabound="ReorderList1_ItemDataBound" 
            PostBackOnReorder="False" SortOrderField="SortOrder" onitemcommand="ReorderList1_ItemCommand"
            >
        <ItemTemplate>
            <div class="book">
                <div class="bookName"><asp:Literal ID="lTitle" runat="server"></asp:Literal></div>
                <div class="bookActions">
                    <asp:LinkButton runat="server" ID="lbEdit" Text="�������������" CommandName="EditBook"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lbDescription" Text="��������" CommandName="EditDescription"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="lbDelete" Text="�������" CommandName="DeleteBook"></asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <ReorderTemplate>
            <div class="reorderItem"></div>
        </ReorderTemplate>
        <DragHandleTemplate>
            <div class="dragHandle">
                &gt;
            </div>
        </DragHandleTemplate>
    </ajax:ReorderList>


        
        <asp:SqlDataSource ID="dsProducts" runat="server" 
            ConnectionString="<%$ ConnectionStrings:1gb_lermontConnectionString %>" 
            SelectCommand="SELECT [ID], [NameTextID], [SortOrder] FROM [Products] ORDER BY [SortOrder]" 
            DeleteCommand="DELETE FROM [Products] WHERE [ID] = @ID" 
            InsertCommand="INSERT INTO [Products] ([NameTextID], [SortOrder]) VALUES (@NameTextID, @SortOrder)" 
            UpdateCommand="UPDATE [Products] SET [NameTextID] = @NameTextID, [SortOrder] = @SortOrder WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NameTextID" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="NameTextID" Type="Int32" />
                <asp:Parameter Name="SortOrder" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>


        
    <asp:UpdatePanel runat="server" ID="upAddEditBook">
        <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbAdd" Text="��������" OnClick="lbAdd_Click"></asp:LinkButton>
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
            <asp:AsyncPostBackTrigger ControlID="ReorderList1" EventName="ItemCommand" />
            <asp:PostBackTrigger ControlID="baeMain" />
            <asp:PostBackTrigger ControlID="ebdMain" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
</asp:Content>

