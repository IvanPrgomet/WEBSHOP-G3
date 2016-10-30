<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="404Error.aspx.cs" Inherits="WebbShop._404Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="errorMessage" class="col-sm-5 col-sm-push-1">
        <h1>Error 404!</h1>
        <h2>Page does not exist.</h2>
        <p>The site path entered does not exist. Double check the URL to see if you mispelled something. </p>
        <div id="errorPageLinks">
            <ul>
                <li><a href="StartPage.aspx">Home</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="asideContentPlaceHolder" runat="server">
</asp:Content>
