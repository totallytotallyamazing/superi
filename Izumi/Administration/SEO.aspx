<%@ Page Language="C#" MasterPageFile="~/Administration/MasterPage.master" AutoEventWireup="true" CodeFile="SEO.aspx.cs" Inherits="Administration_SEO" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type="text/javascript">
		function popUpTexts()
		{
			openPopupWindow('TextsPopUp.aspx', 500, 400);
		}
		
	    function popUpArticles()
		{
			openPopupWindow('ArticlesPopUp.aspx', 300, 400);
		}
		
        function popUpProducts()
		{
			openPopupWindow('ProductGroupsPopUp.aspx', 300, 400);
		}
		
		function setValue(id)
		{
			var tbTextID = document.getElementById('<%= tbTextID.ClientID %>');
			tbTextID.value = id;
		}
		
		function setArticleValue(id)
		{
			var tbArticleScopeID = document.getElementById('<%= tbArticleScopeID.ClientID %>');
			tbArticleScopeID.value = id;
		}
	    
	    function setProductGroupValue(id)
		{
			var tbProductGroupID = document.getElementById('<%= tbProductGroupID.ClientID %>');
			tbProductGroupID.value = id;
		}
		
		function adjustItemDependantButtonsEnabled()
		{
			var NodeID = document.getElementById('<%= ihNodeID.ClientID %>').value;
			var btnDelete = document.getElementById('<%= btnDelete.ClientID %>');
			var btnUp = document.getElementById('<%= btnUp.ClientID %>');
			var btnDown = document.getElementById('<%= btnDown.ClientID %>');
			var btnSave = document.getElementById('<%= btnSave.ClientID %>');
			
			if (NodeID.length === 0)
			{
				btnDelete.disabled = true;
				btnUp.disabled = true;
				btnDown.disabled = true;
				btnSave.disabled = true;
			}
			else
			{
				btnDelete.disabled = false;
				btnUp.disabled = false;
				btnDown.disabled = false;
				btnSave.disabled = false;
			}
		}
		
		function adjustContentDivsVisibility()
		{
			var rbSingleMenuPage = document.getElementById('<%= rbSingleMenuPage.ClientID %>');
			
			var rbText = document.getElementById('<%= rbText.ClientID %>');
			var rbPage = document.getElementById('<%= rbPage.ClientID %>');
			var rbArticles = document.getElementById('<%= rbArticles.ClientID %>');
			var rbProductGroup = document.getElementById('<%= rbProductGroup.ClientID %>');
						
			var divText = document.getElementById('divText');
			var divPage = document.getElementById('divPage');
			var divArticles = document.getElementById('divArticles');
			var divProducts = document.getElementById('divProducts');
			
			
			if(rbText.checked)
			{
				divText.style.display='block';
				divPage.style.display='none';
				divArticles.style.display = 'none';
				divProducts.style.display = 'none';
			}
			if(rbPage.checked)
			{
				divText.style.display='none';
				divPage.style.display='block';
				divArticles.style.display = 'none';
				divProducts.style.display = 'none';
			}
			if(rbArticles.checked)
			{
				divText.style.display='none';
				divPage.style.display='none';
				divArticles.style.display = 'block';
				divProducts.style.display = 'none';
			}
			if(rbProductGroup.checked)
			{
				divText.style.display='none';
				divPage.style.display='none';
				divArticles.style.display = 'none';
				divProducts.style.display = 'block';
			}
			if(rbSingleMenuPage.checked)
			{
				divText.style.display='none';
				divPage.style.display='none';
				divArticles.style.display = 'none';
				divProducts.style.display = 'none';
			}
		}
		
		function validateForm()
		{
			var Name = document.getElementById('<%= tbName.ClientID %>').value;
			if(Name.length===0)
			{
				alert('Название не заполнено');
				return false;
			}
//			var Text = document.getElementById('<%= tbText.ClientID %>').value;
//			if(Text.length === 0)
//			{
//				alert('Заголовок не заполнен');
//				return false;
//			}
            var isSingleMenuPage = document.getElementById('<%= rbSingleMenuPage.ClientID %>').checked;
            
            if(isSingleMenuPage)
            {
                return true;
            }
		    var isText = document.getElementById('<%= rbText.ClientID %>').checked;
		    if(isText)
		    {
			    var TextID = document.getElementById('<%= tbTextID.ClientID %>').value;
			    if(TextID.length === 0)
			    {
				    alert('Выберите текст');
				    return false;
			    }
		    }
		    var isPage = document.getElementById('<%= rbPage.ClientID %>').checked;
		    if(isPage)
		    {
			    var Page = document.getElementById('<%= tbPage.ClientID %>').value;
			    if(Page.length === 0)
			    {
				    alert('Введите ссылку');
				    return false;
			    }
		    }
		    var isArticle = document.getElementById('<%= rbArticles.ClientID %>').checked;
		    if(isArticle)
		    {
		        var ArticleScopeID = document.getElementById('<%= tbArticleScopeID.ClientID %>').value;
		        if(ArticleScopeID.length===0)
		        {
		            alert('Введите раздел');
		            return false;
		        }
		    }
			return true;
		}
		
		function clearForm(isNew)
		{
			var cbSeparator = document.getElementById('<%= cbSeparator.ClientID %>');
			cbSeparator.checked = false;
			
			var tbName = document.getElementById('<%= tbName.ClientID %>');
			tbName.value = '';
			var tbText = document.getElementById('<%= tbText.ClientID %>');
			tbText.value = '';
			var rbText = document.getElementById('<%= rbText.ClientID %>');
			rbText.checked = true;
			adjustContentDivsVisibility();
			var tbTextID = document.getElementById('<%= tbTextID.ClientID %>');
			tbTextID.value = '';
			var tbPage = document.getElementById('<%= tbPage.ClientID %>');
			tbPage.value='';
			if(isNew)
			{
				var ihNodeID = document.getElementById('<%= ihNodeID.ClientID %>');
				ihNodeID.value = '';
				adjustItemDependantButtonsEnabled();
			}
		}
		
		function removeImageConfirm()
		{
		    return confirm("Вы уверены что хотите удалить изображение?");
		}
    </script>


	<input type="hidden" runat="server" id="ihNodeID" />
	<table style="width:100%; height:100%; padding-left:0px; border-collapse:collapse" cellpadding="0" cellspacing="0" >
		<tr>
			<td style ="border:1px solid grey; overflow:auto; width:10%" valign="top">
				<asp:TreeView runat="server" ID="twPages" OnSelectedNodeChanged="twPages_SelectedNodeChanged">
				</asp:TreeView>
			</td>
			<td style ="border:1px solid grey" valign="top">
			<div style="display:none;">
				<asp:CheckBox ID="cbSeparator" Text="Разделитель" runat="server" /><br />
				<asp:CheckBox ID="cbIncludeInMenu" runat="server" Text="Включать в меню" />
				<table id="tDetails">
					<tr>
						<td>
							Название(англ.):
						</td>
						<td>
							<asp:TextBox ID="tbName" runat="server"></asp:TextBox><br />		
						</td>
					</tr>
					<tr>
					    <td>
					        Названия
					    </td>
					    <td>
					        <Controls:ResourceEditor runat="server" ID="reNames"></Controls:ResourceEditor>
					    </td>
					</tr>
					<tr>
						<td>
							Заголовок:
						</td>
						<td>
							<asp:TextBox ID="tbText" runat="server"></asp:TextBox><br />		
						</td>
					</tr>
					<tr>
						<td>
							Контент:	
						</td>
						<td style="width:100%;">
						    <div style="float:left;">
							    <asp:RadioButton ID="rbText" runat="server" Text="Текст" GroupName="rbgContentType" Checked="true" /><br />
							    <div id="divText">
								    <asp:TextBox ReadOnly="true" runat="server" ID="tbTextID"></asp:TextBox>
								    <input type="button" value="..." onclick="popUpTexts();" />
							    </div>
							    <asp:RadioButton ID="rbPage" runat="server" Text="Страница" GroupName="rbgContentType" /><br />
							    <div id="divPage">
								    Ссылка:<br />
								    <asp:TextBox ID="tbPage" runat="server"></asp:TextBox>
							    </div>
							    <asp:RadioButton ID="rbArticles" runat="server" Text="Статьи" GroupName="rbgContentType" /><br />
							    <div id="divArticles">
							        <asp:TextBox ReadOnly="true" runat="server" ID="tbArticleScopeID"></asp:TextBox>
							        <input type="button" value="..." onclick="popUpArticles()" />
							    </div>
							    <asp:RadioButton ID="rbProductGroup" runat="server" Text="Продукты" GroupName="rbgContentType" /><br />
							    <div id="divProducts">
							        <asp:TextBox ReadOnly="true" runat="server" ID="tbProductGroupID"></asp:TextBox>
							        <input type="button" value="..." onclick="popUpProducts()" />
							    </div>
                                <asp:RadioButton ID="rbSingleMenuPage" runat="server" GroupName="rbgContentType" Text="Большое меню" />
							</div>

							
						</td>
					</tr>
<%--					<tr>
						<td>Description:</td>
						<td style="padding-left:5px;">
							<asp:TextBox Rows="5" runat="server" ID="tbDescription" TextMode="MultiLine" Width="100%"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>Keywords:</td>
						<td style="padding-left:5px;">
							<asp:TextBox Rows="5" runat="server" ID="tbKeywords" TextMode="MultiLine" Width="100%"></asp:TextBox>
						</td>
					</tr>--%>
				</table>

				<input type="button" value="Новый пункт" onclick="clearForm(true);" />
				<input type="button" value="Очистить" onclick="clearForm(false);" /><br />
				<asp:Button ID="btnAddNode" runat="server" Text="Добавить в корень" OnClick="btnAddNode_Click" Width="141px" />
				<asp:Button ID="btnAddSub" runat="server" Text="Добавить подзаголовок" OnClick="btnAddSub_Click" Width="177px" />
				<asp:Button ID="btnDelete" Text="Удалить" runat="server" OnClick="btnDelete_Click" />
				</div>
				<div style="margin-left:10px; border:1px solid grey; display:none;">
				    Изображение:<br />
				    <asp:ImageButton runat="server" ID="ibPicture" AlternateText="Нет изображения" /><br />
				    <asp:FileUpload runat="server" ID="fuPicture" />
				</div>
				<table>
				    <tr>
						<td>Description:</td>
						<td style="padding-left:5px;">
							<asp:TextBox Rows="5" runat="server" ID="tbDescription" TextMode="MultiLine" Width="100%"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>Keywords:</td>
						<td style="padding-left:5px;">
							<asp:TextBox Rows="5" runat="server" ID="tbKeywords" TextMode="MultiLine" Width="100%"></asp:TextBox>
						</td>
					</tr>
					<tr>
					    <td>
					        Дополнительный Title:
					    </td>
					    <td>
					        <Controls:ResourceEditor runat="server" ID="reAdditionalTitle"></Controls:ResourceEditor>
					    </td>
					</tr>
				</table>
				   <div style="display:none;">
                <asp:Button ID="btnUp" Text="/\" runat="server" OnClick="btnUp_Click" />
				<asp:Button ID="btnDown" Text="\/" runat="server" OnClick="btnDown_Click" /><br />
                </div>
				<asp:Button ID="btnSave" Text="Сохранить изменения" runat="server" OnClick="btnSave_Click" Width="157px" /> 
							
			</td>
		</tr>
	</table>
	<script type="text/javascript">
		adjustContentDivsVisibility();
		adjustItemDependantButtonsEnabled();
	</script>
</asp:Content>