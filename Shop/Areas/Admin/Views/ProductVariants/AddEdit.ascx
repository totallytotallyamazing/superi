<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ProductVariant>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<% using (Html.BeginForm("AddEdit", "ProductVariants", FormMethod.Post, new { enctype = "multipart/form-data" })){%>
    <% Html.EnableClientValidation(); %>
    <%: Html.Hidden("ProductId")%>
    <%: Html.HiddenFor(model => model.Id)%>
               <table>
                <tr>
                    <td class="labelCell">
                        <%= Html.LabelFor(model => model.Name)%>
                    </td>                
                    <td>
                        <%= Html.TextBoxFor(model => model.Name)%>
                    </td>
                    <td><%= Html.ValidationMessageFor(model => model.Name)%></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="labelCell">
                            <%= Html.LabelFor(model => model.Image)%>
                        </div>
                            <div class="editor-field">
                                <input type="file" name="Image" />
                            </div>
                        <div style="margin-left:101px">
                            <% if (Model != null && !string.IsNullOrWhiteSpace(Model.Image)) %>
                            <%= Html.CachedImage("~/Content/ProductImages/", Model.Image, "thumbnail2", Model.Name)%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="labelCell">
                        <%= Html.LabelFor(model => model.SortOrder)%>
                    </td>                
                    <td>
                        <%= Html.TextBoxFor(model => model.SortOrder)%>
                    </td>
                    <td><%= Html.ValidationMessageFor(model => model.SortOrder)%></td>
                </tr>
                <tr>
                    <td class="labelCell">
                        <%= Html.LabelFor(model => model.Published)%>
                    </td>                
                    <td>
                        <%= Html.CheckBoxFor(model => model.Published)%>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="labelCell" valign="bottom">
                        <%= Html.LabelFor(model => model.Price)%>
                    </td>                
                    <td valign="bottom">
                        <%= Html.TextBoxFor(model => model.Price)%>
                    </td>
                    <td valign="bottom">
                        <div style="width:35px; float:left; height:20px;">
                            <%= Html.ValidationMessageFor(model => model.Price)%>
                        </div>
                        <span class="labelCell">
                            <%= Html.LabelFor(model => model.OldPrice)%>
                        </span>
                        <span class="comments">(не обязательно)</span>
                        <%= Html.TextBoxFor(model => model.OldPrice)%>
                        <%= Html.ValidationMessageFor(model => model.OldPrice)%>
                    </td>
                </tr>
            </table>

            <div class="labelCell" style="margin-bottom:0px; margin-top:20px;">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <%= Html.TextAreaFor(model => model.Description) %>            
            
            <input type="submit" value="Сохранить" />
<% } %>



