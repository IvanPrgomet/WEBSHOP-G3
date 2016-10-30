<%@ Page Title="Oops" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="WebbShop.ErrorPages.Oops" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    <div id="errorMessage" class="col-sm-5 col-sm-push-1">
        <h1>Oops!</h1>
        <h2>An unexpected error has occurred.</h2>
        <p>The staff has been notified and will solve this problem as soon as possible. </p>
        <p>Please send some information about what you where doing when the error ocured so that the staff can find the problem faster.</p>
        <asp:TextBox ID="TextBoxErrorMessage" runat="server" Height="80" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="ButtonSendErrorMail" runat="server" Text="Send" OnClick="ButtonSendErrorMail_Click" />
        <div id="errorPageLinks">
            <ul>
                <li><a href="StartPage.aspx">Home</a></li>
            </ul>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="asideContentPlaceHolder" runat="server">
</asp:Content>
