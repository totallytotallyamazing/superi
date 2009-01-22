<%@ Import Namespace="Superi.Features"%>
<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Administration_Gallery" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<%@ Register TagPrefix="Controls" TagName="GalleryUpload" Src="~/Administration/Controls/GalleryUpload.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--<style type="text/css">
    .hdn{overflow:hidden; width:100px;}
</style>--%>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
        
        function BeginRequest(sender, args)
        {

        }
        
        function EndRequest(sender, args)
        {
            if(getAction()==='changeParams')
            {
                var paramDiv = document.getElementById('paramDiv');
                paramDiv.style.display='block';
                paramDiv.style.left=mousePosition.x+'px';
                paramDiv.style.top=mousePosition.y+'px';
            }
            setAction('');
        }
        
        function closeParams()
        {
            var paramDiv = document.getElementById('paramDiv');
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
    <input type="hidden" id="ihCloseParams" />
    <input type="hidden" id="ihAction" />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" SelectMethod="Get" UpdateMethod="Update" TypeName="Superi.Features.GalleryItems">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ID" Type="Int32"/>
        </UpdateParameters>
    </asp:ObjectDataSource>
    <div style="float:left">
    <asp:UpdatePanel runat="server" ID="upGrid">
        <ContentTemplate>
            <asp:GridView ID="gwGallery" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDataBound="gwGallery_RowDataBound" OnRowDeleting="gwGallery_RowDeleting" OnRowCommand="gwGallery_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Изображение">
                        <ItemTemplate><asp:Image ID="iPreview" runat="server" /></ItemTemplate>
                        <AlternatingItemTemplate><asp:Image ID="iPreview" runat="server" /></AlternatingItemTemplate>
                        <EditItemTemplate><asp:Image ID="iPreview" runat="server" /></EditItemTemplate>
                        <InsertItemTemplate><asp:Image ID="iPreview" runat="server" /></InsertItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Лого">
                        <ItemTemplate>
                            <asp:Image ID="iLogo" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Название">
                        <ItemTemplate>
                            <%# ((Container.DataItem as GalleryItem).Titles != null && (Container.DataItem as GalleryItem).Titles.Items.Count>0)?(Container.DataItem as GalleryItem).Titles["RU"]:""%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Параметры">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lbChange" Text="изменить"></asp:LinkButton>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Удалить">
                        <ItemTemplate>
                            <asp:CheckBox ID="cbDelete" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div style="text-align:left;">
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Удалить выбранные" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click"></asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>

    </div>
    <div style="float:left; padding-left:20px;">
        <div style="text-align:left;">
            Добавить в <asp:DropDownList ID="ddlNavigation" runat="server"></asp:DropDownList>
        </div>
        <div style="float:left;">Маленькие</div><div style="float:left;padding-left:165px;">Большие</div>
        <div style="clear:both"></div>
        <asp:PlaceHolder ID="phUpload" runat="server">
            
        </asp:PlaceHolder>
        <div style="clear:both;">
            <asp:Button ID="btnAdd" runat="server" Text="Добавить" OnClick="btnAdd_Click" />
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="upProperties">
        <ContentTemplate>
            <div style="position:absolute" id="paramDiv" class="paramsDiv">
                <asp:HiddenField runat="server" ID="hfGalleryItemId" />
                <div class="paramsCloseLabel">
                    <A href="javascript:closeParams()">X</A> 
                </div>
                <div class="labelDiv">Раздел</div>
                <div class="inputDiv"><asp:DropDownList runat="server" ID="ddlNavigationsProperty"></asp:DropDownList></div>
                <div class="labelDiv">Название</div>
                <div class="inputDiv">
                    <Controls:ResourceEditor ID="reNames" runat="server"></Controls:ResourceEditor>
                </div>
                <div class="labelDiv">Клиент </div>
                <div class="inputDiv">
                    <Controls:ResourceEditor ID="reClient" runat="server"></Controls:ResourceEditor>
                </div>
                <div class="labelDiv">Лого </div>
                <div class="inputDiv"><asp:FileUpload id="fuLogo" runat="server"></asp:FileUpload> </div>
                <div class="labelDiv">Превью</div>
                <div class="inputDiv"><asp:FileUpload id="fuPreview" runat="server"/></div>
                <div class="labelDiv">Изображение</div>
                <div class="inputDiv"><asp:FileUpload id="fuPicture" runat="server"/></div>
                <div class="labelDiv">Адрес </div>
                <div class="inputDiv">
                    <Controls:ResourceEditor ID="reAddress" runat="server"></Controls:ResourceEditor>
                </div>
                <div class="labelDiv">Год </div><div class="inputDiv"><asp:TextBox id="tbYear" runat="server"></asp:TextBox> </div>
                <div class="labelDiv">Площадь </div><div class="inputDiv"><asp:TextBox id="tbSquare" runat="server"></asp:TextBox> </div>
                <div class="labelDiv">Виды работ </div>
                <div class="inputDiv">
                    <Controls:ResourceEditor ID="reWorkKinds" runat="server"></Controls:ResourceEditor>
                </div>
                <div class="paramsSubmitContainer">
                    <asp:Button id="btnSaveProperties" runat="server" Text="Сохранить" OnClick="btnSaveProperties_Click"></asp:Button> 
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gwGallery" EventName="RowCommand"></asp:AsyncPostBackTrigger>
            <asp:PostBackTrigger ControlID="btnSaveProperties" />
        </Triggers>
    </asp:UpdatePanel>
    
    
</asp:Content>

