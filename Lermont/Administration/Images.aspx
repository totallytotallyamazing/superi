<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="Images.aspx.cs" Inherits="Administration_Images" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<%@ Import Namespace="Superi.Common" %>
	<script type="text/javascript">
		function updateImageUrls()
		{
			var imgs = document.documentElement.getElementsByTagName('img');
//			alert(imgs.length);
//			var i =1;
            if(imgs)
            {
			    for (i=0;i<imgs.length; i++)
			    {
                    if(imgs[i].src)
                    {
                        var src = imgs[i].src.substring(+imgs[i].src.lastIndexOf('/')+1);
    				    imgs[i].src = '<%= WebSession.BaseImageUrl %>'+"TextImages/" + src;
    			    }
			    }
			}
		}
		
		function setValue(alias)
		{
			var tbUrl = document.getElementById('<%= tbUrl.ClientID %>');
			tbUrl.value = 'text/' + alias;
		}
	</script>

	<asp:HiddenField ID="hfTextSelected" runat="server" />
	<asp:HiddenField ID="hfImageSelected" runat="server" />
	<table style="width:100%; height:100%; padding-left:0px; border-collapse:collapse" cellpadding="0" cellspacing="0">
		<tr>
			<td style ="border:1px solid grey; overflow:auto; width:10%" valign="top">
				<asp:GridView ID="gwTexts" runat="server" AutoGenerateColumns="False" DataSourceID="odsTexts" OnSelectedIndexChanged="gwTexts_SelectedIndexChanged">
					<Columns>
						<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
						<asp:BoundField DataField="Alias" HeaderText="Текст" SortExpression="Alias" />
						<%-- <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />--%>
						<asp:CommandField SelectText="Выбрать" ShowSelectButton="True" />
					</Columns>
				</asp:GridView>
				<asp:ObjectDataSource ID="odsTexts" runat="server" SelectMethod="GetTexts" TypeName="Superi.Features.Texts">
				</asp:ObjectDataSource>
			</td>
			<td style ="border:1px solid grey" valign="top">
				<asp:GridView ID="gwImages" runat="server" DataKeyNames="ID" AutoGenerateColumns="False" DataSourceID="odsImages" OnSelectedIndexChanged="gwImages_SelectedIndexChanged" OnRowDeleting="gwImages_RowDeleting">
					<Columns>
						<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
						<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
						<asp:ImageField DataImageUrlField="Picture" SortExpression="Picture" HeaderText="Изображение"/>
						<asp:ImageField DataImageUrlField="Preview" SortExpression="Preview" HeaderText="Ч/Б"></asp:ImageField>
						<asp:CommandField SelectText="Изменить" ShowSelectButton="True" />
						<asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
					</Columns>
				</asp:GridView>
				<asp:FormView ID="fwImages" runat="server" DefaultMode="Insert" DataSourceID="odsImages">
					<InsertItemTemplate>
						Title:
						<asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
						</asp:TextBox><br />
						<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
							Text="Insert">
						</asp:LinkButton>
					</InsertItemTemplate>
				</asp:FormView>
				<asp:ObjectDataSource ID="odsImages" runat="server" DeleteMethod="Delete"
					InsertMethod="Insert" SelectMethod="Get" TypeName="Superi.Features.GalleryItems"
					UpdateMethod="Update">
					<DeleteParameters>
						<asp:Parameter Name="ID" Type="Int32" />
					</DeleteParameters>
					<UpdateParameters>
						<asp:Parameter Name="Title" Type="String" />
						<asp:Parameter Name="ID" Type="Int32" />
					</UpdateParameters>
					<SelectParameters>
						<asp:ControlParameter ControlID="hfTextSelected" DefaultValue="-1" Name="GalleryID"
							PropertyName="Value" Type="Int32" />
					</SelectParameters>
					<InsertParameters>
						<asp:Parameter Name="Title" Type="String" />
						<asp:ControlParameter ControlID="hfTextSelected" DefaultValue="-1" Name="GalleryID"
							PropertyName="Value" Type="Int32" />
					</InsertParameters>
				</asp:ObjectDataSource>
				<asp:PlaceHolder ID="phEdit" runat="server">
					<table>
						<tr>
							<td>Подпись 1</td><td><asp:TextBox runat="server" ID="tbTitle"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Подпись 2</td><td><asp:TextBox runat="server" ID="tbSubTitle"></asp:TextBox></td>
						</tr>
						<tr>
							<td>Изображение</td><td><asp:FileUpload runat="server" ID="fuPicture" /></td>
						</tr>
						<tr>
							<td>Ч/Б</td><td><asp:FileUpload runat="server" ID="fuPreview" /></td>
						</tr>
						<tr>
						    <td>
						        Ссылка
						    </td>
						    <td>
						        <asp:TextBox ID="tbUrl" runat="server"></asp:TextBox>
						        <input type="button" value="Текст" onclick = "openPopupWindow('TextsPopUp.aspx?mode=alias', 500, 400);" />
						    </td>
						</tr>
					</table>
					<asp:Button runat="server" ID="bSave" Text="Сохранить" />
				</asp:PlaceHolder>
			</td>
		</tr>
	</table>
	<script type="text/javascript">
		updateImageUrls();
	</script>
</asp:Content>

