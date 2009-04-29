<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tour.aspx.cs" Inherits="TourPage" %>

<link href="css/main.css" rel="stylesheet" type="text/css" />
<% if(SelectedTour!=null) {%>
<div class="tourContainer">
    <div class="tourLeft" style='color:<%= SelectedTour.LeftTextColor %>'>
        <%= SelectedTour.LeftText.Replace(Environment.NewLine, "<br />") %> 
    </div>
    <div class="tourRight">
        <div class="tourPics">
            <ul>
            <% foreach (TourPicture picture in SelectedTour.TourPictures)
               { %>
                <li>
                    <a class="thumb" href="MakeThumbnail.aspx?dim=600&loc=tour&file=<%= picture.Picture %>">
                        <img alt="" src="Images/Gallery/Tours/<%= picture.Preview %>" />
                    </a>
                </li>
            <%} %>
            </ul>
        </div>
        <div class="tourPicsPager"></div>
        <div class="tourDescription">
            <div class="tourTitle">
                <%= SelectedTour.RightTitle %>
            </div>
            <div class="tourSubTitle">
                <%= SelectedTour.RightSubTitle %>
            </div>
            <div class="tourText">
                <%= SelectedTour.RightText %>
            </div>
        </div>
    </div>
</div>
<%} %>