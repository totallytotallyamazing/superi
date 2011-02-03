<%@ Page Language="C#"%>

<% 
    HttpCookie cookie = new HttpCookie("listelliShow", "true");
    HttpCookie newCookie = new HttpCookie("favorites", "182,191,");
    newCookie.Path = "/";
    newCookie.Expires = DateTime.Now.AddYears(1);
    cookie.Expires = DateTime.Now.AddYears(1);
    Response.Cookies.Add(cookie);
    Response.Cookies.Add(newCookie);
    Response.Redirect("~/Home");    
    
%>