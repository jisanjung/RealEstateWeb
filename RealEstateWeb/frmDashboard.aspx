<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" Inherits="RealEstateWeb.frmDashboard" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <!--<uc:Navbar runat="server" id="navbar"/>-->
        <div id="allView" class="card w-50" style="top:500px">
            <div id="labels" class="card-body">
                <h5 class="card-title">Modify Profile</h5>
                <asp:Label id="lblFullName" runat="server" Text="Your Name"></asp:Label><br/>
                <asp:Label id="lblPassword" runat="server" Text="Your Password"></asp:Label><br/>
                <asp:Label id="lblAddress" runat="server" Text="Your Address"></asp:Label><br/>
            </div>
            <div id="inputs" class="card-body">
                <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name"></asp:TextBox><br/>
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password"></asp:TextBox><br/>
                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"></asp:TextBox><br/>
            </div>
            <asp:Button ID="btnModify" runat="server" Text="Edit" OnClick="btnModify_Click" />
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
</body>
</html>
