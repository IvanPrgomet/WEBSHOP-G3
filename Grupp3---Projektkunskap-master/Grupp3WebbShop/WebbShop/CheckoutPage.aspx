<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="WebbShop.CheckoutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <link href="Styles/checkoutStyle.css" rel="stylesheet" />
    <title>Checkout Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <header id="checkoutHeader" runat="server">
            <asp:Image runat="server" ImageUrl="Pictures/TestLogo.png" />
        </header>
        <div>
            <div class="container-fluid">
                <div class="row">
                    <div id="picture" class="col-sm-3">
                        <asp:Image runat="server" />
                    </div>
                    <div id="productName" class="col-sm-3">
                        Product  
                    <asp:Label runat="server" ID="product" CssClass="cartSummary"></asp:Label>
                    <asp:Repeater runat="server"></asp:Repeater>
                    </div>
                    <div id="itemNumber" class="col-sm-3">
                        Items
                    <asp:DropDownList runat="server" CssClass="cartSummary" ID="itemNumberList">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                    </asp:DropDownList>

                    </div>
                    <div id="priceBox" class="col-sm-3">
                        Price
                    <asp:Label runat="server" ID="price" CssClass="cartSummary"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-3">
                        <h2>Delivery adress: </h2>
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">First name: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutFirstname" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutFirstname" ErrorMessage="First name needs to be 3 - 15 characters long, no numbers allowed." ValidationExpression="[a-zA-ZÅÄÖåäö]{3,15}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">Last name: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutLastname" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutLastname" ErrorMessage="Last name needs to be 3 - 15 characters long, no numbers allowed." ValidationExpression="[a-zA-ZÅÄÖåäö]{3,15}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">Adress: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutAdress" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutAdress" ErrorMessage="Adress needs to be 3 - 25 characters long." ValidationExpression="[a-zA-ZÅÄÖåäö 0-9]{3,25}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">City: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutCity" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutCity" ErrorMessage="City needs to be 3 - 30 characters long, no numbers allowed." ValidationExpression="[a-zA-ZÅÄÖåäö ]{3,15}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">Zip: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutZip" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutZip" ErrorMessage="Zip may only contain numbers and a maximum of 15 characters!" ValidationExpression="[0-9 -]{3,15}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">Phone number: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutPhonenumber" CssClass="checkoutTextBoxes" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutPhonenumber" ErrorMessage="Phone number may only contain numbers and a maximum of 15 characters!" ValidationExpression="[0-9 -+]{3,15}" />
                        <br />
                        <asp:Label CssClass="checkoutLabels" runat="server">Email adress: </asp:Label>
                        <br />
                        <asp:TextBox ID="checkoutEmail" CssClass="checkoutTextBoxes" runat="server" TextMode="Email"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="checkoutPhonenumber" ErrorMessage="You must fill in a valid e-mail!"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-sm-3">
                        <h2>Payment & Delivery options</h2>
                        <label>Delivery options  </label>
                        <asp:DropDownList runat="server" ID="checkoutDelivery" OnSelectedIndexChanged="checkoutDelivery_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="55">Schenker 55kr</asp:ListItem>
                            <asp:ListItem Value="199">Posten 199kr</asp:ListItem>
                            <asp:ListItem Value="79">DHL 79kr</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <h2>Payment options </h2>
                        <asp:RadioButtonList runat="server" ID="paymentList">
                            <asp:ListItem>VISA</asp:ListItem>
                            <asp:ListItem>Master Card</asp:ListItem>
                            <asp:ListItem>PayPal</asp:ListItem>
                            <asp:ListItem>Invoice</asp:ListItem>
                        </asp:RadioButtonList>
                        <br />
                        <asp:Button runat="server" ID="submitButton" OnClick="submitButton_Click"></asp:Button>
                    </div>
                    <div class="col-sm-3">
                        <div id="totalPrice">
                            <asp:Label runat="server" CssClass="labelPay" ID="orderSubtotal"> Order subtotal: </asp:Label>
                            <br />
                            <br />
                            <asp:Label runat="server" CssClass="labelPay" ID="orderShipping">Shipping: </asp:Label>
                            <br />
                            <br />
                            <asp:Label runat="server" CssClass="labelPay" ID="orderTotal">Order total: </asp:Label>
                            <br />
                            <br />
                            <asp:Label runat="server" CssClass="labelPay" ID="cartItemAmount">Total number of items: </asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
