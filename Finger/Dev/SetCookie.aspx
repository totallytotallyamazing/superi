<%@ Page Language="C#"%>

<% 
    Response.Cookies.Add(new HttpCookie("mooo", "true"));
    Response.Redirect("~/Home");    
%>