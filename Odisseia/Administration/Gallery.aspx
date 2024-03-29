<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Administration_Gallery" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="Superi.CustomControls" Assembly="Superi" %>
<%@ Register TagPrefix="Controls" TagName="GalleryUpload" Src="~/Administration/Controls/GalleryUpload.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%--    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="Get" TypeName="Superi.Features.Galleries">
    </asp:ObjectDataSource>--%>
    
    <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlGalleries">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" SelectMethod="Get" UpdateMethod="Update" TypeName="Superi.Features.GalleryItems">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="ID" Type="Int32"/>
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlGalleries" DefaultValue="-1" Name="GalleryID"
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <div style="float:left">
    <asp:GridView ID="gwGallery" DataKeyNames="ID" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnRowDataBound="gwGallery_RowDataBound" OnRowDeleting="gwGallery_RowDeleting">
        <Columns>
            <asp:BoundField DataField="ID" SortExpression="ID" HeaderText="ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="�����������">
                <ItemTemplate><asp:Image ID="iPreview" runat="server" /></ItemTemplate>
                <AlternatingItemTemplate><asp:Image ID="iPreview" runat="server" /></AlternatingItemTemplate>
                <EditItemTemplate><asp:Image ID="iPreview" runat="server" /></EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Title" SortExpression="Title" HeaderText="�������" >
                <ItemStyle CssClass="hdn" />
            </asp:BoundField>
            <asp:CommandField ShowEditButton="True" UpdateText="���������" EditText="�������" CancelText="������" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="�������" />
        </Columns>
    </asp:GridView>
    </div>
    
    <div style="float:left; padding-left:20px;">
       <div style="float:left;">����������</div><%--<div style="float:left;padding-left:165px;">�������</div>--%>
        <div style="clear:both"></div>
        <asp:PlaceHolder ID="phUpload" runat="server">
            
        </asp:PlaceHolder>
        <div style="clear:both;">
            <asp:Button ID="btnAdd" runat="server" Text="��������" OnClick="btnAdd_Click" />
        </div>
    </div>

    
</asp:Content>

