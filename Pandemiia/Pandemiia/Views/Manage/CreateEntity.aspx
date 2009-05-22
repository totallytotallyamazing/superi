<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master"
    Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<%@ Import Namespace="Pandemiia.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Создать пост
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function() {
            $(".dateInput").datepicker();
            $.fck.config = { path: '../Controls/fckeditor/', height: 300, config: { SkinPath: "skins/office2003/", DefaultLanguage: "RU", AutoDetectLanguage: false, HtmlEncodeOutput: true} };
            $('textarea#Description').fck();
            $('textarea#Content').fck();
            initTags();
        });

        function initTags() {
            $(".tags a").each(
                function(i) {
                    var val = $("input[name='tags']").val();
                    var tagsTyped = val.split(' ');
                    if ($.inArray(this.innerHTML, tagsTyped) > -1) {
                        this.style.color = "green";
                    }
                    else {
                        this.style.color = "";
                        $(this).unbind("click", addTag);
                        $(this).bind("click", addTag);
                    }
                }
            );
        }

        function addTag(el) {
            var tags = $("input[name='tags']");
            var tagsText = $("input[name='tags']").val();

            if (tagsText != "") {
                tags.val(tags.val() + " ");
            }
            tags.val(tags.val() + this.innerHTML);
            this.style.color = "green";
            $(this).unbind("click", addTag);
        }
    </script>

    <h2>
        Создать пост</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm("CreateEntity", "Manage", FormMethod.Post, new{enctype="multipart/form-data"}))
       {%>
    <fieldset>
        <legend>Поля</legend>
        <div>
            <div style="float: left">
                <p>
                    <label for="Title">
                        Заголовок:</label>
                    <%= Html.TextBox("Title") %>
                    <%= Html.ValidationMessage("Title", "*") %>
                </p>
                <p>
                    <label for="Date">
                        Дата:</label>
                    <%= Html.TextBox("Date", null, new { @class = "dateInput", @readonly = "true"})%>
                    <%= Html.ValidationMessage("Date", "*") %>
                </p>
            </div>
            <div>
                Картинка:<br />
                <input type="file" name="image" style="margin-left:10px; margin-top:15px;" />
            </div>
        </div>
        <div style="float:left; padding-left:10px;">
                <label for="tags">Теги</label>
                <%= Html.TextBox("tags", "", new { style = "width:400px", onkeyup = "initTags();", autocomplete = "off" })%>
                <div class="tags">
                    <%
                        List<Tag> tagList = (List<Tag>)ViewData["tagList"];
                        foreach (Tag tag in tagList)
                      {%>
                        <a href="#"><%= tag.TagName%></a>
                      <%} %>
                </div>
            </div>
        <div style="clear: both">
        </div>
        <p>
            <label for="Description">
                Описание:</label>
            <%= Html.TextArea("Description") %>
            <%= Html.ValidationMessage("Description", "*") %>
        </p>
        <p>
            <label for="Content">
                Содержимое:</label>
            <%= Html.TextArea("Content")%>
            <%= Html.ValidationMessage("Content", "*") %>
        </p>
        <p>
            <label for="TypeID">
                Тип:</label>
            <select name="TypeID" id="TypeID">
                <%foreach (EntityType src in (IEnumerable)ViewData["EntityTypes"])%>
                <%{%>
                <option value="<%= src.ID %>">
                    <%= src.Name %>
                </option>
                <%}%>
            </select>
            <%= Html.ValidationMessage("TypeID", "*") %>
        </p>
        <p>
            <label for="SourceID">
                Чье:</label>
            <select name="SourceID" id="SourceID">
                <%foreach (EntitySource src in (IEnumerable)ViewData["EntitySources"])%>
                <%{%>
                <option value="<%= src.ID %>">
                    <%= src.Name %>
                </option>
                <%}%>
                <%= Html.ValidationMessage("SourceID", "*") %>
            </select>
        </p>
        <p>
            <input type="submit" value="Создать" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("Назад", "Entities") %>
    </div>
</asp:Content>
