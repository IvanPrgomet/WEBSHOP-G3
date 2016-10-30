<%@ Page Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="True" CodeBehind="Products.aspx.cs" Inherits="WebbShop.Categories" %>

<%@ Import Namespace="System.ComponentModel" %>
<%@ Import Namespace="System.Drawing" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script src="Scripts/SessionJQuery.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:PlaceHolder runat="server" ID="dataBasePlace"></asp:PlaceHolder>
    <asp:Image runat="server" ID="productPicture" />
    <aside id="filterAside" class="col-sm-2">
        <div id="CategoryInView" class="text-center">
            <asp:Label ID="CategoryLable" runat="server" BackColor="pink" Font-Bold="True" Height="25px"></asp:Label>
        </div>
        <asp:Repeater runat="server" ID="FilterCategoryRepeater">
            <HeaderTemplate></HeaderTemplate>
            <ItemTemplate>
<%--                <p><%# DataBinder.Eval(Container.DataItem, "Name") %></p>--%>
                <asp:LinkButton ID="LinkButtonCategoryFilter"  runat="server" OnCommand="LinkButtonCategoryFilter_Command" CommandName="MyUpdate" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductCategoryID") %>'><%# DataBinder.Eval(Container.DataItem, "Name") %></asp:LinkButton><br />
            </ItemTemplate>
        </asp:Repeater>
        <script>
            $(function () {
                var minValue = parseInt($('#<%= minPrice.ClientID %>').val());
                var maxValue = parseInt($('#<%= maxPrice.ClientID %>').val());
                var minValueForRange = parseInt($('#<%= minPriceForRange.ClientID %>').val());
                var maxValueForRange = parseInt($('#<%= maxPriceForRange.ClientID %>').val());


                $("#slider-range").slider({
                    range: true,
                    min: minValueForRange,
                    max: maxValueForRange,
                    values: [minValue, maxValue],
                    slide: function (event, ui) {
                        $("#amount").val("SEK " + ui.values[0] + " - SEK " + ui.values[1]);
                        $('#<%= maxPrice.ClientID %>').val($("#slider-range").slider("values", 1).toString());
                        $('#<%= minPrice.ClientID %>').val($("#slider-range").slider("values", 0).toString());
                        <%--<%# CategoryFilterMethod() %>--%>
                    },
                    stop: function (event, ui) {
                        
                        __doPostBack("sliderEvent");
                    }
                });
                $("#amount").val("SEK " + $("#slider-range").slider("values", 0) +
                  " - SEK " + $("#slider-range").slider("values", 1));

            });
        </script>
        <asp:HiddenField ID="maxPrice" runat="server"/>
        <asp:HiddenField ID="minPrice" runat="server"/>
        <asp:HiddenField ID="maxPriceForRange" runat="server"/>
        <asp:HiddenField ID="minPriceForRange" runat="server"/>
        <p>
            <label for="amount">Price range:</label>
            <input type="text" id="amount" readonly style="border: 0; color: #f6931f; background-color: inherit; font-weight: bold;">
        </p>

        <div id="slider-range"></div>
    </aside>

    <div class="col-sm-8">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Repeater ID="CategoryRepeater" OnItemCommand="CategoryRepeater_OnItemCommand"  runat="server" >

        <HeaderTemplate>
        </HeaderTemplate>

        <ItemTemplate>
            <asp:Panel runat="server" CssClass="left">
            <asp:Panel ID="productClicked" CssClass="innerPanel" runat="server" >
                           
              <asp:Image runat="server" CssClass="repeaterImage" ImageUrl='<%# test(DataBinder.Eval(Container.DataItem, "ThumbNailPhoto"))%>'/><br/>
            <%# DataBinder.Eval(Container.DataItem, "Expr1") %><br/>
             <%# DataBinder.Eval(Container.DataItem, "ListPrice", "{0:f}") %>SEK<br/>
           <asp:Button CommandName="hiddenButton" runat="server" CssClass="HiddenImageButton" CommandArgument='<%#Eval("ProductID") + "," + Eval("Expr1") %>' />  <%--CommandName="showProductInfo"--%> 
            </asp:Panel>
                    <asp:Button runat="server" Text="Add to cart" CommandName="cartButton"  CommandArgument='<%#Eval("ProductID") %>' />  
           
            </asp:Panel>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>       
    </div>
</asp:Content>
