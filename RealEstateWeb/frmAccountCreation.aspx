<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAccountCreation.aspx.cs" Inherits="RealEstateWeb.frmAccountCreation" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div>
            <h1>Homes R Us</h1>
        </div>
    
    <div class="login">
        email
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        password
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /><br />
    </div>
    <div class="signup">
        username
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
        email
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        password
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
        current address
        <asp:TextBox ID="txtCurrAddress" runat="server"></asp:TextBox><br />
        Full name
        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox><br />
        <h4>Security Question 1: What is your mother's maiden name?</h4>
        <asp:TextBox ID="txtSecureQuestion1" runat="server"></asp:TextBox><br />
        <h4>Security Question 2: What University did/do you attend?</h4>
        <asp:TextBox ID="txtSecureQuestion2" runat="server"></asp:TextBox><br />
        <h4>Security Question 3: What is your favorite food?</h4>
        <asp:TextBox ID="txtSecureQuestion3" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSignup" runat="server" Text="Sign up" OnClick="btnSignup_Click" />        
    </div>
    <div class="verification">
        We have emailed you a code, please input to verify your account:<br />
        <asp:TextBox ID="txtVerification" runat="server"></asp:TextBox>
        <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />
    </div>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </form>
</body>
</html>
