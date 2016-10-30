<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="StartPage.aspx.cs" Inherits="WebbShop.StartPage" Title="StartPage" %>

<%@ MasterType VirtualPath="MasterPage.Master" %>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Image ID="frontPicture" runat="server"
        AlternateText="Image text"
        ImageUrl="Pictures/Mountain_bike_view.jpg" Width="100%" Height="320px" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="mainContentPlaceHolder">


    <div id="popularProducts" class="col-sm-12">
        <%--<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>--%>
        <asp:Repeater ID="ProductRepeater" OnItemCommand="ProductRepeater_OnItemCommand" runat="server">

            <HeaderTemplate>
                <h2 id="headerTile">Popular Products</h2>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Panel runat="server" CssClass="left">
                    <asp:Panel ID="productClicked" CssClass="innerPanel" runat="server">

                        <asp:Image runat="server" CssClass="repeaterImage" ImageUrl='<%# test(DataBinder.Eval(Container.DataItem, "ThumbNailPhoto"))%>' /><br />
                        <%# DataBinder.Eval(Container.DataItem, "Expr1") %><br />
                        <%# DataBinder.Eval(Container.DataItem, "ListPrice", "{0:f}") %>SEK<br />
                        <asp:Button CommandName="hiddenButton" runat="server" CssClass="HiddenImageButton" CommandArgument='<%#Eval("ProductID") %>' />
                        <%--CommandName="showProductInfo"--%>
                    </asp:Panel>
                    <asp:Button runat="server" Text="Add to cart" CommandName="cartButton" CommandArgument='<%#Eval("ProductID") %>' />
                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="asideContentPlaceHolder">
    <div>
        <%--<asp:ImageButton runat="server" ID="annons1" CssClass="pic asidePic" Width="125px" Height="100px" ImageUrl="~/Pictures/ShoppingCart.png" OnClick="Ad1Click_Click" />
        <br />
        <asp:Label ID="labelAnnons1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ImageButton runat="server" ID="annons2" CssClass="pic" Width="125px" Height="100px" ImageUrl="~/Pictures/ShoppingCart.png" OnClick="Ad2Click" />
        <br />
        <asp:Label ID="labelAnnons2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ImageButton runat="server" ID="annons3" CssClass="pic" Width="125px" Height="100px" ImageUrl="~/Pictures/ShoppingCart.png" OnClick="Ad3Click" />
        <br />
        <asp:Label ID="labelAnnons3" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ImageButton runat="server" ID="annons4" CssClass="pic" Width="125px" Height="100px" ImageUrl="~/Pictures/ShoppingCart.png" OnClick="Ad4Click" />
        <br />
        <asp:Label ID="labelAnnons4" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:ImageButton runat="server" ID="annons5" CssClass="pic" Width="125px" Height="100px" ImageUrl="~/Pictures/ShoppingCart.png" OnClick="Ad5Click" />
        <br />
        <asp:Label ID="labelAnnons5" runat="server" Text="Label"></asp:Label>--%>

        <asp:Repeater ID="RepeaterAside" OnItemCommand="AsideRepeater_OnItemCommand" runat="server">

            <HeaderTemplate>
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Panel runat="server" CssClass="ads">
                    <asp:Panel ID="productClicked" CssClass="innerPanel" runat="server">

                        <asp:Image runat="server" CssClass="repeaterImage" ImageUrl='<%# test(DataBinder.Eval(Container.DataItem, "ThumbNailPhoto"))%>' /><br />
                        <%# DataBinder.Eval(Container.DataItem, "Expr1") %><br />
                        <%# DataBinder.Eval(Container.DataItem, "ListPrice", "{0:f}") %>SEK<br />
                        <asp:Button CommandName="hiddenButton" runat="server" CssClass="HiddenImageButton" CommandArgument='<%#Eval("ProductID") %>' />
                        <%--CommandName="showProductInfo"--%>
                    </asp:Panel>
                    <asp:Button runat="server" Text="Add to cart" CommandName="cartButton" CommandArgument='<%#Eval("ProductID") %>' />

                </asp:Panel>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
