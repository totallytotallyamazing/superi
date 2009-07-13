<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<%
    string[] months = { "нул€брь", "€нварь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сент€брь", "окт€брь", "но€брь", "декабрь" };
    int year = 2008;
    int month = 1;
    if (ViewData["year"] != null)
        year = Convert.ToInt32(ViewData["year"]);
    if (ViewData["month"] != null)
        month = Convert.ToInt32(ViewData["month"]);
    %><div><%
    for (int i = 2008; i <= 2012; i++)
    { 
        string color = "";
        if (year == i && ViewData["year"] != null)
            color = "color:red";
        %>
      <span style="padding:0px 5px;">
        <%= Html.ActionLink(i.ToString(), "Entities", new { year = i, month = month }, new { style = color })%>
      </span>  
    <%}
    %></div><%
    %><div><%
    for (int j = 1; j <= 12; j++)
    {
        string color = "";
        if (month == j && ViewData["month"] != null)
            color = "color:red";

         %>
      <span style="padding:0px 5px;">
        <%= Html.ActionLink(months[j], "Entities", new { year = year, month = j }, new { style = color })%>
      </span>  
   <%}
   %></div><%       
 %>