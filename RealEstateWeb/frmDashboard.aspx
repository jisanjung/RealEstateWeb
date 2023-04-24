<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="RealEstateWeb.frmDashboard" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<%@ Register Src="~/Footer.ascx" TagPrefix="uc" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homes R Us | Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div class="d-flex justify-content-center mb-5">
            <div style="width: 600px;">
                <h1 class="mt-5 display-5">
                    <asp:Label ID="lblWelcomeText" runat="server"></asp:Label>
                </h1>
                <div id="buyerSpecific" runat="server" class="mt-5">
                    <div class="card">
                      <div class="card-body">
                        <h5 class="card-title fw-bold">View Scheduled Visits</h5>
                        <p class="card-text text-secondary">Take a look at all of the scheduled home showings you have booked.</p>
                        <a href="./frmBuyerScheduledVisits.aspx" class="btn btn-primary">View Scheduled Visits</a>
                      </div>
                    </div>
                </div>
                <div id="agentSellerSpecific" runat="server" class="mt-5">
                    <div class="card">
                      <div class="card-body">
                        <h5 class="card-title fw-bold">Manage Homes</h5>
                        <p class="card-text text-secondary">View, edit or delete all homes you have listed. View home showings as well as feedback for each home</p>
                        <a href="./frmSellerHomes.aspx" class="btn btn-primary">View your homes</a>
                      </div>
                    </div>
                </div>
                <div id="allView" class="card mt-5">
                    <div id="labels" class="card-body">
                        <h5 class="card-title fw-bold">Modify Profile</h5>
                        <ul class="list-group list-group-flush" id="ulUserInfo" runat="server">
                            <li class="list-group-item">
                                <span class="fw-bold">Name: </span>
                                <asp:Label id="lblFullName" runat="server" Text="Your Name"></asp:Label>
                            </li>
                            <li class="list-group-item">
                                <span class="fw-bold">Address: </span>
                                <asp:Label id="lblAddress" runat="server" Text="Your Address"></asp:Label>
                            </li>
                        </ul>
                    </div>
                    <div id="divModifyInputs" class="card-body form-group" runat="server" visible="false">
                        <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name" CssClass="form-control mb-2"></asp:TextBox>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="p-3">
                        <asp:Button ID="btnModify" runat="server" Text="Edit" OnClick="btnModify_Click" CssClass="btn btn-primary"/>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Visible="false" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div>
        <uc:Footer runat="server" id="footer"/>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
