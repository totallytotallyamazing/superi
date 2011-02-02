<%@ Page Language="C#"%>

<% 
    HttpCookie cookie = new HttpCookie("listelliShow", "true");
    HttpCookie newCookie = new HttpCookie("favorites", "12,34,67,23,12334,676,34,123");
    newCookie.Path = "/";
    newCookie.Expires = DateTime.Now.AddYears(1);
    cookie.Expires = DateTime.Now.AddYears(1);
    Response.Cookies.Add(cookie);
    Response.Cookies.Add(newCookie);
    Response.Redirect("~/Home");    
    
%>