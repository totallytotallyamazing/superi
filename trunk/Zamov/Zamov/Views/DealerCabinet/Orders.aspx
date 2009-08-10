<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Order>>" %>
<%@ Import Namespace="Zamov.Models"%>
<%@ Import Namespace="Zamov.Helpers"%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Orders
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
        string showOrderUrl = Url.Action("ShowOrder");
    %>
<script type="text/javascript">
        var items = new Array();
        $(function() {


            $(".orderDescription")
            .fancybox(
            {
                frameWidth: 700,
                hideOnContentClick: false
            });
        })


        $(function() {
            queryOrders();
            //setInterval(queryOrders, 5000);
        });

        function queryOrders() {

            var lastRequestTime = new Date();
            var webRequest = Sys.Net.WebServiceProxy.invoke(
            "/Services/Tools.asmx",
            "GetNewOrders",
            false,
            { requestTime: lastRequestTime },
            function(response) {
                for (var i in response) {
                    var row = document.createElement("tr");
                    var col1 = document.createElement("td");
                    col1.innerHTML = response[i].Id;
                    row.appendChild(col1);

                    var col2 = document.createElement("td");
                    col2.innerHTML = response[i].DeliveryDate;
                    row.appendChild(col2);

                    var col3 = document.createElement("td");
                    col3.innerHTML = response[i].ClientName + " " + response[i].Address;
                    row.appendChild(col3);

                    var col4 = document.createElement("td");
                    col4.innerHTML = response[i].Status;
                    row.appendChild(col4);


                    var url = '<a href="<%= showOrderUrl%>/{0}" class="orderDescription">{1}</a>';
                    var urlLayout = String.format(url, response[i].Id, '<%= Html.ResourceString("View")%>');
                    var col5 = document.createElement("td");
                    $(urlLayout).appendTo(col5).fancybox({frameWidth: 700,hideOnContentClick: false});
                    row.appendChild(col5);



                    var tableHeader = $get('orderTable').getElementsByTagName("tr")[0];
                    $(row).insertAfter($(tableHeader))
                }



            },
            failureCallback);
        }
        
    </script>
    
    
    
    
    <h3><%=Html.ResourceString("Orders")%></h3>

    <div id="div1"></div>

    <table class="commonTable" id="orderTable">
        <tr>
            <th>
                ¹ <%=Html.ResourceString("OfOrder")%>
            </th>
            <th>
                <%=Html.ResourceString("OrderDeliveryDateTime")%>
            </th>
            <th>
                <%=Html.ResourceString("OrderInfo")%>
            </th>
            <th>
                <%=Html.ResourceString("Status")%>
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DeliveryDate)) %>
            </td>
            <td>
                <%= Html.Encode(item.ClientName+", "+item.Address) %>
            </td>
            <td>
                <%=Html.ResourceString("Status"+(Statuses)item.Status)%>
            </td>
            <td>
                <%=Html.ActionLink(Html.ResourceString("View"), "ShowOrder", new { id = item.Id }, new { @class = "orderDescription" })%>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
</asp:Content>
