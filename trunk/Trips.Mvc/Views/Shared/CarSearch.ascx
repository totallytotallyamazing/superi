<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="leftBoxCarSearch">
    <div id="carSearchHeader">
        <p>
            <asp:Literal runat="server" Text="<%$ Resources:WebResources, CarSearch %>"></asp:Literal>
        </p>
    </div>
    <div id="carSearchContent">
        <input type="text" name="field" id="searchField" />
        <p>
            <input type="submit" class="find" value="" />
        </p>
    </div>
    <div id="carSearchFooter">
    </div>
</div>