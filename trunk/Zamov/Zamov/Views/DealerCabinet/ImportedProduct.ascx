<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>

<%
    bool isNew = (bool)ViewData["isNew"];
    string changeFunction = "tableChanged({0}, this)";
    if (isNew)
        changeFunction = String.Format(changeFunction, "newItems");
    else
        changeFunction = String.Format(changeFunction, "updatedItems");
    string divId = (isNew) ? "newProductDescription_" + ViewData["id"] : "updatedProductDescription_" + ViewData["id"];
    string fckUkId = (isNew) ? "newUkDescription_" + ViewData["id"] : "updatedUkDescription_" + ViewData["id"];
    string fckRuId = (isNew) ? "newRuDescription_" + ViewData["id"] : "updatedRuDescription_" + ViewData["id"];
%>

<tr>
    <td>
        <%= Html.DropDownList("groupPath_" + ViewData["id"], (List<SelectListItem>)ViewData["groupList"], new { onblur = changeFunction })%>
    </td>
    <td>
        <%= Html.TextBox("partNumber_" + ViewData["id"], ViewData["partNumber"], new { onblur = changeFunction })%>
    </td>
    <td>
        <%= Html.TextBox("name_" + ViewData["id"], ViewData["name"], new { onblur = changeFunction })%>
    </td>
    <td>
        <%= Html.TextBox("price_" + ViewData["id"], ViewData["name"], new { onblur = changeFunction })%>
    </td>
    <td align="center">
        <a href="javascript:openDescriptionDialog('<%= divId %>')" class="productDescriptionLink">
            i
        </a>
        <div class="productDescriptionContainer" title="<%= Html.ResourceString("Description") %>" id="<%= divId %>">
            <table>
                <tr class="adminTable">
                    <td align="center"><%= Html.ResourceString("Ukr")%></td>
                    <td align="center"><%= Html.ResourceString("Rus")%></td>
                </tr>
                <tr>
                    <td style="width:330px;">
                        <%= Html.TextArea(fckUkId, (string)ViewData["ukDescription"], new { onblur = changeFunction, @class = "fck" })%>
                    </td>
                    <td style="width:330px;">
                        <%= Html.TextArea(fckRuId, (string)ViewData["ruDescription"], new { onblur = changeFunction, @class = "fck" })%>
                    </td>
                </tr>
            </table>
        </div>
    </td>
</tr>