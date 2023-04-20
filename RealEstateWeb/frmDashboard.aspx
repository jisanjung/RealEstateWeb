<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="RealEstateWeb.frmDashboard" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homes R Us | Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div id="allView" class="card w-50" style="top:500px">
            <div id="labels" class="card-body">
                <h5 class="card-title">Modify Profile</h5>
                <asp:Label id="lblFullName" runat="server" Text="Your Name"></asp:Label><br/>
                <asp:Label id="lblAddress" runat="server" Text="Your Address"></asp:Label><br/>
            </div>
            <div id="inputs" class="card-body">
                <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name" Visible="false"></asp:TextBox><br/>
                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" Visible="false"></asp:TextBox><br/>
            </div>
            <asp:Button ID="btnModify" runat="server" Text="Edit" OnClick="btnModify_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
        </div>
        <div id="buyerSpecific" runat="server">
            <div class="card w-50">
              <div class="card-body">
                <h5 class="card-title">View Scheduled Visits</h5>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                <a href="./frmBuyerScheduledVisits.aspx" class="btn btn-primary">Proceed</a>
              </div>
            </div>
        </div>


        <div id="agentSellerSpecific" runat="server">
            <div class="card w-50">
              <div class="card-body">
                <h5 class="card-title">Manage Homes</h5>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                <a href="./frmSellerHomes.aspx" class="btn btn-primary">Proceed</a>
              </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
