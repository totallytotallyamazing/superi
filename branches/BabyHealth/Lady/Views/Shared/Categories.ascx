<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.Category>>" %>
<%@ Import Namespace="Lady.Models" %>
            <div id="menuBox">
                <div id="liHeader">
                </div>
                <div id="newsContent">
                    <div id="classMenuItems">
                        <div class="classMenuItem">
                            <p>
                                <a class="active" href="#">Детские вещички</a></p>
                        </div>
                        <ul class="treeview" id="productGroups">
                            <li>
                                <div class="subMenuItem">
                                    <a class="" href="#">Шапочки</a></div>
                            </li>
                            <li>
                                <div class="subMenuItem">
                                    <a class="" href="#">Тапочки</a></div>
                            </li>
                            <li>
                                <div class="subMenuItem">
                                    <a class="" href="#">Воротнички</a></div>
                            </li>
                            <li class="last">
                                <div class="subMenuItem">
                                    <a class="" href="#">Коротыши</a></div>
                            </li>
                        </ul>
                        <div class="classMenuItem">
                            <a class="active" href="#">Детская комната</a>
                        </div>
                        <div class="classMenuItem">
                            <a class="active" href="#">Родительский гардероб</a>
                        </div>
                    </div>
                </div>
                <div id="newsFooter">
                </div>
            </div>

    <ul>
    
    <% if(Roles.IsUserInRole("Administrators")){ %>    
        <p class="adminLink categoriesAdmin">
            <a href="/Admin/Categories/AddEdit">Добавить категорию</a>
        </p>
    <%} %>

