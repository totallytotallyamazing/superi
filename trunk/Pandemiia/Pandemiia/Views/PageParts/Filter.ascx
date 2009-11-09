<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Pandemiia.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<%
    string source = ViewData["source"].ToString();
    string typeName = ViewData["typeName"].ToString();
%>

<div class="filterTop">
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Ours", typeName) %>">
            <%= Html.Image("~/Content/img/ours.jpg", "����")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (source == "Ours")
          {
              Response.Write("����");
          }
          else
          {%>
        
        <a href="<%= Utils.GetFilterPath("Ours", typeName) %>">
            ����
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Yours", typeName) %>">
            <%= Html.Image("~/Content/img/yours.jpg", "����")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (source == "Yours")
          {
              Response.Write("����");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath("Yours", typeName) %>">
            ����
        </a>
<%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("Theirs", typeName) %>">
            <%= Html.Image("~/Content/img/theirs.jpg", "�����")%>
        </a>    
    </div>
    <div class="filterLabel">
          <%if (source == "Theirs")
          {
              Response.Write("�����");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath("Theirs", typeName) %>">
            �����
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath("All", typeName) %>">
            <%= Html.Image("~/Content/img/allSources.jpg", "���")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (source == "All")
            {
                Response.Write("���");
            }
            else
            {%>
        <a href="<%= Utils.GetFilterPath("All", typeName) %>">
            ���
        </a>
        <%} %>
    </div>
</div>
<div class="filterBottom">
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Image") %>">
            <%= Html.Image("~/Content/img/imageFilter.jpg", "�����������")%>
        </a>
    </div>
    <div class="filterLabel">
            <%if (typeName == "Image")
              {
                  Response.Write("�����������");
              }
              else
              {%>
        <a href="<%= Utils.GetFilterPath(source, "Image") %>">
            �����������
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Video") %>">
            <%= Html.Image("~/Content/img/videoFilter.jpg", "�����")%>
        </a>
    </div>
    <div class="filterLabel">
                <%if (typeName == "Video")
                  {
                      Response.Write("�����");
                  }
                  else
                  {%>
        <a href="<%= Utils.GetFilterPath(source, "Video") %>">
            �����
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            <%= Html.Image("~/Content/img/readingFilter.jpg", "�����")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (typeName == "Reading")
          {
              Response.Write("�����");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            �����
        </a>
        <%} %>
    </div>
        <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Reading") %>">
            <%= Html.Image("~/Content/img/musicFilter.jpg", "�����")%>
        </a>
    </div>
    <div class="filterLabel">
        <%if (typeName == "Music")
          {
              Response.Write("������");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Music") %>">
            ������
        </a>
        <%} %>
    </div>

    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "Other") %>">
            <%= Html.Image("~/Content/img/miscFilter.jpg", "������")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (typeName == "Other")
          {
              Response.Write("������");
          }
          else
          {%>
        <a href="<%= Utils.GetFilterPath(source, "Other") %>">
            ������
        </a>
        <%} %>
    </div>
    <div class="filterIcon">
        <a href="<%= Utils.GetFilterPath(source, "All") %>">
            <%= Html.Image("~/Content/img/allTypesFilter.jpg", "���")%>
        </a>
    </div>
    <div class="filterLabel">
          <%if (typeName == "All")
            {
                Response.Write("���");
            }
            else
            {%>
        <a href="<%= Utils.GetFilterPath(source, "All") %>">
            ���
        </a>
        <%} %>
    </div>
</div>