<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Disks.aspx.cs" Inherits="Administration_Disks" Title="Untitled Page" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<%@ Register TagPrefix="admin" TagName="DiskAddEdit" Src="~/Administration/Controls/DiskAddEdit.ascx" %>
<%@ Register TagPrefix="admin" TagName="EditDiskDescription" Src="~/Administration/Controls/EditDiskDescription.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
        
        function BeginRequest(sender, args)
        {

        }
        
        function EndRequest(sender, args)
        {
            if(getAction()==='addEditDisk')
            {
                $find("<%= mpeAddEdit.ClientID %>").show();
            }
            else if(getAction()==='editDescription')
            {
                $find("<%= mpeDescription.ClientID %>").show();
            }
            setAction('');
        }

        function closeParams(elId) {
            $find(elId).hide();
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
    <%--<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Get" TypeName="Disks"></asp:ObjectDataSource>--%>
    <div style="text-align:left;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <ajax:ReorderList ID="ReorderList1" runat="server" AllowReorder="True" 
                    DataSourceID="dsProducts" onitemdatabound="ReorderList1_ItemDataBound" 
                    PostBackOnReorder="True" SortOrderField="SortOrder" onitemcommand="ReorderList1_ItemCommand">
                <ItemTemplate>
                    <div class="book">
                        <div class="bookName"><asp:Literal ID="lTitle" runat="server"></asp:Literal></div>
                        <div class="bookActions">
                            <asp:LinkButton runat="server" ID="lbEdit" Text="Редактировать" CommandName="EditDisk"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbDescription" Text="Описание" CommandName="EditDescription"></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbDelete" Text="Удалить" CommandName="DeleteDisk"></asp:LinkButton>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ReorderList1" EventName="ItemReorder" />
        </Triggers>
    </asp:UpdatePanel>

        <asp:SqlDataSource ID="dsProducts" runat="server" 
            ConnectionString="<%$ ConnectionStrings:1gb_lermontConnectionString %>" 
            SelectCommand="SELECT [ID], [NameTextID], [SortOrder] FROM [Products] WHERE [TypeId] = 2 ORDER BY [SortOrder] " 
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


        
    <asp:UpdatePanel runat="server" ID="upAddEditDisk">
        <ContentTemplate>
        <asp:LinkButton runat="server" ID="lbAdd" Text="Добавить" OnClick="lbAdd_Click"></asp:LinkButton>
            <asp:Panel runat="server" id="addDiskHolder" CssClass="addBookHolder">
                <div style="text-align:right;"><a href="javascript:closeParams('<%= mpeAddEdit.ClientID %>')">X</a></div>
                <admin:DiskAddEdit runat="server" ID="baeMain" />
            </asp:Panel>
            <asp:Panel id="editDiskDescription" runat="server" CssClass="editBookDescription" >
                <div style="text-align:right;"><a href="javascript:closeParams('<%= mpeDescription.ClientID %>')">X</a></div>
                <admin:EditDiskDescription runat="server" ID="ebdMain"/>
            </asp:Panel>
            <asp:LinkButton runat="server" ID="lbStub1" style="display:none"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="lbStub2" style="display:none"></asp:LinkButton>
            <ajax:ModalPopupExtender runat="server" 
                TargetControlID="lbStub1"
                ID="mpeAddEdit"
                PopupControlID="addDiskHolder"
                DropShadow="true"
                BackgroundCssClass="shaded"
            />
            
           <ajax:ModalPopupExtender runat="server" 
                TargetControlID="lbStub2"
                ID="mpeDescription"
                PopupControlID="editDiskDescription"
                DropShadow="true"
                BackgroundCssClass="shaded"
            />

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

