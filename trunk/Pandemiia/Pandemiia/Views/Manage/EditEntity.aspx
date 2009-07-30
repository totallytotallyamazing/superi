<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Views/Manage/Manage.Master"
    Inherits="System.Web.Mvc.ViewPage<Pandemiia.Models.Entity>" %>

<%@ Register TagPrefix="FCKeditor" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<%@ Import Namespace="Pandemiia.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ������������� ����
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        $(function() {
            $(".dateInput").datepicker({ dateFormat: "dd.mm.yy" });
            $.fck.config = { path: '../../Controls/fckeditor/', height: 300, config: { SkinPath: "skins/office2003/", DefaultLanguage: "RU", AutoDetectLanguage: false, HtmlEncodeOutput: true} };
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
        ������������� ����</h2>
    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm("EditEntity", "Manage", FormMethod.Post, new { enctype = "multipart/form-data" }))
       {%>
    <fieldset>
        <legend>����</legend>
        <p style="display: none">
            <label for="ID">
                ID:</label>
            <%= Html.TextBox("ID", Model.ID) %>
            <%= Html.ValidationMessage("ID", "*") %>
        </p>
        <div>
            <div style="float: left">
                <p>
                    <label for="Title">
                        ���������:</label>
                    <%= Html.TextBox("Title", Model.Title) %>
                    <%= Html.ValidationMessage("Title", "*") %>
                </p>
                <p>
                    <label for="Date">
                        ����:</label>
                    <%= Html.TextBox("Date", String.Format("{0:dd.MM.yyyy}", Model.Date), new { @class = "dateInput", @readonly = "true" })%>
                    <%= Html.ValidationMessage("Date", "*") %>
                </p>
            </div>
            <div class="entityImage">
                <% if (!string.IsNullOrEmpty(Model.Image))
                   { %>
                <img alt="" src="../../EntityImages/<%= Model.Image %>" />
                <%} %>
                <input type="file" name="image" style="margin-left: 10px; margin-top: 15px;" />
            </div>
            <div style="float:left; padding-left:10px;">
                <label for="tags">����</label>
                <%= Html.TextBox("tags", Model.GetTagString(), new{style = "width:400px", onkeyup="initTags();", autocomplete="off"}) %>
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
        </div>
        <br />
        <br />
        <p>
            <label for="Description">
                ��������:</label>
            <%= Html.TextArea("Description", Model.Description) %>
            <%= Html.ValidationMessage("Description", "*") %>
        </p>
        <p>
            <label for="Content">
                ����������:</label>
            <%= Html.TextArea("Content", Model.Content)%>
            <%= Html.ValidationMessage("Content", "*") %>
        </p>
        <p>
            <label for="TypeID">
                ���:</label>
            <%= Html.DropDownList("TypeID", (IEnumerable<SelectListItem>)ViewData["EntytyTypes"], "�������� ���")%>
            <%= Html.ValidationMessage("TypeID", "*") %>
        </p>
        <p>
            <label for="SourceID">
                ���:</label>
            <%= Html.DropDownList("SourceID", (IEnumerable<SelectListItem>)ViewData["EntitySources"], "")%>
            <%= Html.ValidationMessage("SourceID", "*") %>
        </p>
        <p>
            <input type="submit" value="���������" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%=Html.ActionLink("�����", "Entities") %>
    </div>
</asp:Content>
