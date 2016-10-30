<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="WebbShop.ConfirmationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/ConfirmationPageStyle.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1 class="centering">Thank you for placing your order!</h1>
            <div class="centering" id="heading1">Billing information</div>
            <div class="centering" id="confirmationAdress">
                <br />
                <asp:Label runat="server" ID="firstName">First name: </asp:Label>
                <br />
                <asp:Label runat="server" ID="lastName">Last name: </asp:Label>
                <br />
                <asp:Label runat="server" ID="adress">Adress: </asp:Label>
                <br />
                <asp:Label runat="server" ID="city">City: </asp:Label>
                <br />
                <asp:Label runat="server" ID="zip">ZIP: </asp:Label>
                <br />
                <asp:Label runat="server" ID="phoneNumber">Phonenumber: </asp:Label>
                <br />
                <asp:Label runat="server" ID="email">Email: </asp:Label>
                <br />
                <asp:Label runat="server" ID="delivery">Delivery: </asp:Label>
                <br />
                <asp:Label runat="server" ID="cardOption">Payment option: </asp:Label>
                <br />
            </div>
            <div class="centering" id="heading2">Payment</div>
            <div class="centering" id="confirmationPrice">
                <br />
                <asp:Label runat="server" ID="subTotal">Order subtotal: </asp:Label>
                <br />
                <asp:Label runat="server" ID="shipping">Shipping: </asp:Label>
                <br />
                <asp:Label runat="server" ID="totalCost">Total cost: </asp:Label>
                <br />
                <asp:Label runat="server" ID="cartItems">Number of items: </asp:Label>
            </div>
            <br /><br />
            <div class="centering"><a href="StartPage.aspx"> Return to Home </a> </div>
        </div>
    </form>
</body>
</html>
