<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/_Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CleanVersion.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
		<h1 class="form-signin-heading text-muted">Sign In</h1>
        <br />
        <asp:TextBox runat="server" CssClass="form-control" placeholder="Username" required="" autofocus="" >
        </asp:TextBox>
        <br />
        <asp:TextBox runat="server" CssClass="form-control" placeholder="Password" required="" ></asp:TextBox>
        <br />
        <asp:Button ID="LoginButton" Cssclass="btn btn-lg btn-primary btn-block" runat="server" Text="Login"  />
        <br />
</div>
</asp:Content>
