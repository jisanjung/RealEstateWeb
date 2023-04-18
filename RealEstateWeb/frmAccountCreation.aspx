<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAccountCreation.aspx.cs" Inherits="RealEstateWeb.frmAccountCreation" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <h1>Homes R Us</h1>
        </div>        
    
    <div class="login" id="divLogin" style="border:solid 1px; display: inline-block" runat="server">
        email
        <asp:TextBox ID="txtEmailLogin" runat="server" required></asp:TextBox><br />
        password
        <asp:TextBox ID="txtPasswordLogin" runat="server" required></asp:TextBox>
        <br />
        <asp:CheckBox ID="chkRememberLogin" runat="server" Text="Remember Me" />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br />
        <asp:LinkButton ID="linkForgotPassword" runat="server" OnClick="linkForgotPassword_Click">Forgot Password</asp:LinkButton>
            
        <div class="forgotFunction" id="forgotFun" runat="server" visible="false" style="display:block; border: solid 1px; margin: 1rem;">
            <br />
            Enter your Email:
            <asp:TextBox ID="txtForgotEmail" runat="server" required></asp:TextBox>
            <asp:Label ID="lblForgot" runat="server" Text="Answer Correctly and we'll send you your email"></asp:Label>
            <br />
            <asp:TextBox ID="txtForgotAnswer" runat="server" required></asp:TextBox>
            <br />
            <asp:Button ID="btnForgotPassword" runat="server" OnClick="btnForgotPassword_Click" Text="Forgot Password" />
            <br />
        </div>
    </div>
    <div id="divOpenSignup" runat="server">or <asp:LinkButton ID="linkbtnCreateAccount" runat="server" OnClick="linkbtnCreateAccount_Click">create an account</asp:LinkButton></div>
    <div class="signup" id="divSignup" style="border:solid 1px; margin:1rem;" runat="server" visible="false">
        email
        <asp:TextBox ID="txtEmail" runat="server" required></asp:TextBox><br />
        password
        <asp:TextBox ID="txtPassword" runat="server" required></asp:TextBox><br />
        current address
        <asp:TextBox ID="txtCurrAddress" runat="server" required></asp:TextBox><br />
        Full name
        <asp:TextBox ID="txtFullName" runat="server" required></asp:TextBox>
        <br />
        What kind of user are you?<br />
        <asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem Value="Agent"></asp:ListItem>
            <asp:ListItem Value="Buyer"></asp:ListItem>
            <asp:ListItem Value="Seller"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <h4>Security Question 1: What is your mother's maiden name?</h4>
        <asp:TextBox ID="txtSecureQuestion1" runat="server" required></asp:TextBox><br />
        <h4>Security Question 2: What University did/do you attend?</h4>
        <asp:TextBox ID="txtSecureQuestion2" runat="server" required></asp:TextBox><br />
        <h4>Security Question 3: What is your favorite food?</h4>
        <asp:TextBox ID="txtSecureQuestion3" runat="server" required></asp:TextBox>
        <br />
        <br />
        <asp:CheckBox ID="chkRememberSignup" runat="server" Text="Remember Me" />
        <br />
        <asp:Button ID="btnSignup" runat="server" Text="Sign up" OnClick="btnSignup_Click" />        
    </div>
    <div id="divOpenLogin" runat="server" visible="false">
        or <asp:LinkButton ID="linkbtnLogin" runat="server" OnClick="linkbtnLogin_Click">login</asp:LinkButton>
    </div>
    <div class="verification" id="divVerify" runat="server" visible="false">
        <br />
        <asp:TextBox ID="txtVerification" runat="server"></asp:TextBox>
        <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" />
    </div>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </form>
</body>
</html>
