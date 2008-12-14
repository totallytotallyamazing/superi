<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Administration_News" Title="Untitled Page" %>
<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:HiddenField ID="hfNewsItemID" runat="server" />
	<asp:GridView DataKeyNames="ID" ID="gwNews" runat="server" AutoGenerateColumns="False" DataSourceID="odsNews" OnSelectedIndexChanged="gwNews_SelectedIndexChanged">
		<Columns>
			<asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
			<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
			<asp:CommandField CancelText="Отмена" DeleteText="Удалить" EditText="Редактировать"
				InsertText="Добавить" SelectText="Описание" ShowEditButton="True" UpdateText="Сохранить" />
			<asp:CommandField SelectText="Текст" ShowSelectButton="True" />
			<asp:CommandField DeleteText="Удалить" ShowDeleteButton="True" />
		</Columns>
	</asp:GridView>
	<asp:FormView DefaultMode="Insert" ID="fwNews" runat="server" DataSourceID="odsNews">
		<InsertItemTemplate>
			Title:
			<asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>'>
			</asp:TextBox><br />
			<asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
				Text="Добавить">
			</asp:LinkButton>
		</InsertItemTemplate>
	</asp:FormView>
	
	<asp:ObjectDataSource ID="odsNews" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
		SelectMethod="Get" TypeName="Superi.Features.News" UpdateMethod="Update">
		<DeleteParameters>
			<asp:Parameter Name="ID" Type="Int32" />
		</DeleteParameters>
		<UpdateParameters>
			<asp:Parameter Name="Title" Type="String" />
			<asp:Parameter Name="ID" Type="Int32" />
		</UpdateParameters>
		<InsertParameters>
			<asp:Parameter Name="Title" Type="String" />
		</InsertParameters>
	</asp:ObjectDataSource>
	
	<asp:PlaceHolder ID="phEdit" runat="server">
		<table style="width:100%">
			<tr>
				<td>
					Псевдоним:
				</td>
				<td>
					<asp:TextBox ID="tbAlias" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Дата:
				</td>
				<td>
					<asp:Calendar runat="server" ID="cDate"></asp:Calendar>
				</td>
			</tr>
			<tr>
				<td>
					Краткое описание:
				</td>
				<td>
					<textarea cols="9" id="fckeShortDescription" runat="server" style="height:500px; width:100%;">
					
					</textarea>
					<%--<FCKeditor:FCKeditor Height="500" ID="fckeShortDescription" runat="server" BasePath="~/Administration/Controls/fckeditor/"></FCKeditor:FCKeditor>--%>
				</td>
			</tr>
			<tr style="height:500px;">
				<td>
					Полное описание:
				</td>
				<td>
					<FCKeditor:FCKeditor Height="500" ID="fckeDescription" runat="server" BasePath="~/Administration/Controls/fckeditor/"></FCKeditor:FCKeditor>
				</td>
			</tr>
		</table>
		<br />
		<asp:Button ID="btnUpdate" runat="server" Text="Сохранить" />
	</asp:PlaceHolder>

	
</asp:Content>

