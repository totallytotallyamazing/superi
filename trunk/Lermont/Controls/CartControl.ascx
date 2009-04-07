<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartControl.ascx.cs" Inherits="Controls_CartControl" %>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(CartEndRequestHandler);
//        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(CartBeginRequestHandler);

        function CartEndRequestHandler(sender, args) {
            CartService.Count(success, failure);
        }

        function success(response) {
            $("#cartItemsCount").html(response);
        }

        function failure(args) { 
            alert("we're fucked up")
        }
    </script>
<a href="cart">
    <img src="http://musicalmart.net/shop/images/shopping_cart_img.gif" alt="cart" />
</a>
<div>
    В вашей корзине: <span id="cartItemsCount"><asp:Literal runat="server" ID="lCount" Text="0"></asp:Literal></span>    
</div>