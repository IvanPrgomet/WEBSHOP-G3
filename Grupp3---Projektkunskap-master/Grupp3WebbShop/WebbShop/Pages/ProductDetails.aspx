<%@ Page Language="C#" MasterPageFile="../MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebbShop.Pages.WebForm1" %>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Repeater ID="CategoryRepeater" runat="server" OnItemCommand="CategoryRepeater_ItemCommand">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
           
            <asp:ImageButton ID="hiddenButton" runat="server" CssClass="HiddenImageButton" CommandName="showProductInfo" />
            <div class="container-fluid">
                <div class="row">
                <div class="col-sm-4">
                        <asp:Image runat="server" CssClass="repeaterLargeImage" ImageUrl='<%# CallConvertPics(DataBinder.Eval(Container.DataItem, "LargePhoto"))%>' />
                </div>
            <br />
                <div class="col-sm-2">
            <div id="nameAndDescription">
                <div id="Name"><%# DataBinder.Eval(Container.DataItem, "Expr1") %></div>
                <br />
                            <div id="DescriptionAndWeight">
                                <%# DataBinder.Eval(Container.DataItem, "Description") %><br />
                                Weight: <%# DataBinder.Eval(Container.DataItem, "Weight") %> g
                            </div>
                <br />
                <div id="price">Price: <%# DataBinder.Eval(Container.DataItem, "ListPrice", "{0:f}") %> SEK</div>
                <br />
                <br />
                <div id="addToCartButton">
                                <asp:Button runat="server" Text="Add to cart" CommandName="AddToCart" CommandArgument='<%#Eval("ProductID") %>' />
                            </div>
                            <br />
                <br />
                            <%--<div id="ColorDropDownList">
                   Color:<asp:DropDownList ID="ColorDropList" CssClass="colorList" runat="server"></asp:DropDownList>
                </div>
                <div id="SizeDropDownList">
                   Size:<asp:DropDownList ID="SizeDropList" CssClass="SizeList" runat="server"></asp:DropDownList>
                </div>--%>
                </div>
            </div>
        </div>
</div>






         
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="ImageRepeater" runat="server">

        <HeaderTemplate>
        </HeaderTemplate>

        <ItemTemplate>
            <asp:Panel runat="server" CssClass="detailItems2">
                <div id="smallImage">
                    <asp:Image runat="server" CssClass="repeaterSmalImage" ImageUrl='<%# CallConvertPics(DataBinder.Eval(Container.DataItem, "ThumbNailPhoto"))%>' />
                </div>
                <br />
            </asp:Panel>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
   
    <%--<asp:Table ID="Table1" runat="server"></asp:Table> --%>
</asp:Content>
