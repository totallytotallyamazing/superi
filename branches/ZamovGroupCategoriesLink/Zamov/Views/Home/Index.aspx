<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CategoryPresentation>>" %>

<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Title") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
        <div class="mainCategory">
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <style type="text/css">
        .mainCategory
        {
            float: left;
            width: 171px;
            height: 215px;
            background: transparent url(/img/categoryBg.gif);
            border:1px solid lime;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentTop" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="leftMenu" runat="server">
<pre>
fsldkjf
s df
sdf
 sd
 f sd
 f
 sd
 f
 sd
 fsd
 f
 s
 df
 sd
 fsd
 f
 sd
 fsdddddddf
 sd
  fsd
   f
   sd
   fsd
   fsd
   f
   sdf
   sd
   fsd
   f
   sdf
   sd
   fs
   df
   sd
   fsd
   f
   sd
   fsd
   f
   </pre>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="dealerLogo" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentBottom" runat="server">
</asp:Content>
