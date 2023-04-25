<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAccountCreation.aspx.cs" Inherits="RealEstateWeb.frmAccountCreation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homes "R" Us | Signup</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="https://fonts.cdnfonts.com/css/poppins" rel="stylesheet"/>
    <style>
        html, body {
            font-family: 'Poppins', sans-serif;
        }
        .bg-image {
            background: url('https://images.unsplash.com/photo-1484154218962-a197022b5858?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1748&q=80');
            background-repeat: no-repeat;
            background-size: cover;
        }
        .tint {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
            background: rgba(0, 0, 0, 0.75);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="d-flex vh-100">
            <div class="bg-image w-50 position-relative d-flex justify-content-center align-items-center">
                <div class="tint"></div>
                <div class="text-white text-center position-relative z-1 w-25">
                    <h1 class="display-4">Homes "R" Us</h1>
                    <p class="lead">We have options for every lifestyle.</p>
                </div>
            </div>
            <div class="w-50 d-flex justify-content-center align-items-center">
                <div class="px-5">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    <div class="form-group" id="divLogin" runat="server">
                        <h3 class="mb-4">Login</h3>
                        <label>Email</label>
                        <asp:TextBox ID="txtEmailLogin" runat="server" required CssClass="form-control mb-2" placeholder="Enter Email"></asp:TextBox>
                        <label>Password</label>
                        <asp:TextBox ID="txtPasswordLogin" runat="server" required type="password" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
                        <asp:LinkButton ID="linkForgotPassword" runat="server" OnClick="linkForgotPassword_Click">Forgot Password</asp:LinkButton>
                        <div class="my-4">
                            <asp:CheckBox ID="chkRememberLogin" runat="server" />
                            <label>Remember me</label>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
                        </div>
                        <div id="divOpenSignup" runat="server" class="my-2">
                            <span>Don't have an account? </span>
                            <asp:LinkButton ID="linkbtnCreateAccount" runat="server" OnClick="linkbtnCreateAccount_Click">Create an Account</asp:LinkButton>
                        </div>
                        <div class="forgotFunction form-group" id="forgotFun" runat="server" visible="false">
                            <h3 class="mt-5 mb-4">Retrieve your Password</h3>
                            <label>Your Email:</label>
                            <asp:TextBox ID="txtForgotEmail" runat="server" required CssClass="form-control mb-2" placeholder="Enter Email"></asp:TextBox>
                            <asp:Label ID="lblForgot" runat="server" Text="Answer Correctly and we'll send you your email"></asp:Label>
                            <asp:TextBox ID="txtForgotAnswer" runat="server" required CssClass="form-control" placeholder="Security Answer"></asp:TextBox>
                            <div class="d-grid">
                                <asp:Button ID="btnForgotPassword" runat="server" OnClick="btnForgotPassword_Click" Text="Send Password via Email" CssClass="btn btn-outline-primary my-3" formnovalidate="formnovalidate"/>
                            </div>
                            <asp:Label ID="lblForgotPassAlert" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="signup" id="divSignup" runat="server" visible="false">
                        <h3 class="mb-4">Create an Account</h3>
                        <div class="d-flex justify-content-center">
                            <div class="w-50 me-3">
                                <label>Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" required CssClass="form-control mb-2" placeholder="Enter Email"></asp:TextBox>
                                <label>Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" required type="password" CssClass="form-control mb-2" placeholder="Enter Password"></asp:TextBox>
                                <label>Current Address</label>
                                <asp:TextBox ID="txtCurrAddress" runat="server" required CssClass="form-control mb-2" placeholder="Enter Home Address"></asp:TextBox>
                                <label>Full Name</label>
                                <asp:TextBox ID="txtFullName" runat="server" required CssClass="form-control mb-2" placeholder="Enter First and Last Name"></asp:TextBox>
                                <label>What kind of user are you?</label>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="d-block w-100 py-2 px-3">
                                    <asp:ListItem Value="Agent"></asp:ListItem>
                                    <asp:ListItem Value="Buyer"></asp:ListItem>
                                    <asp:ListItem Value="Seller"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="w-50 ms-3">
                                <label>Security Question 1: What is your mother's maiden name?</label>
                                <asp:TextBox ID="txtSecureQuestion1" runat="server" required CssClass="form-control mb-2" placeholder="Security Answer 1"></asp:TextBox>
                                <label>Security Question 2: What University did/do you attend?</label>
                                <asp:TextBox ID="txtSecureQuestion2" runat="server" required CssClass="form-control mb-2" placeholder="Security Answer 2"></asp:TextBox>
                                <label>Security Question 3: What is your favorite food?</label>
                                <asp:TextBox ID="txtSecureQuestion3" runat="server" required CssClass="form-control mb-2" placeholder="Security Answer 3"></asp:TextBox>
                            </div>
                        </div>
                        <div class="my-4">
                            <asp:CheckBox ID="chkRememberSignup" runat="server"/>
                            <label>Remember me</label>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnSignup" runat="server" Text="Sign up" OnClick="btnSignup_Click" CssClass="btn btn-primary"/>
                        </div>
                    </div>
                    <div id="divOpenLogin" runat="server" visible="false" class="my-2">
                        <span>Already have an account? </span>
                        <asp:LinkButton ID="linkbtnLogin" runat="server" OnClick="linkbtnLogin_Click">Login</asp:LinkButton>
                    </div>
                    <div class="verification" id="divVerify" runat="server" visible="false">
                        <h3 class="mb-4 mt-5">Verify your Identity</h3>
                        <div class="d-flex align-items-center">
                            <asp:TextBox ID="txtVerification" runat="server" CssClass="form-control my-2" placeholder="Verification Code" style="margin-right: 0.5rem;"></asp:TextBox>
                            <asp:Button ID="btnVerify" runat="server" Text="Verify" OnClick="btnVerify_Click" CssClass="btn btn-primary"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
