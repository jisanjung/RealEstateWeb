<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="RealEstateWeb.Navbar" %>
<nav class="navbar navbar-expand-lg navbar-dark bg-dark position-relative z-1">
  <div class="container-fluid">
    <a href="#" class="navbar-brand">Homes "R" Us</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0" id="agentLinks" runat="server">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="frmSearch.aspx">Search</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmCreateHome.aspx">Create Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmSellerHomes.aspx">Manage Homes</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmOffers.aspx">Offers <span runat="server" id="agentOfferCount" class="badge text-bg-danger"></span></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmDashboard.aspx">Dashboard</a>
        </li>
      </ul>
      <ul class="navbar-nav me-auto mb-2 mb-lg-0" id="sellerLinks" runat="server">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="frmSearch.aspx">Search</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmCreateHome.aspx">Create Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmSellerHomes.aspx">Manage Homes</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmOffers.aspx">Offers <span runat="server" id="sellerOfferCount" class="badge text-bg-danger"></span></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmDashboard.aspx">Dashboard</a>
        </li>
      </ul>
      <ul class="navbar-nav me-auto mb-2 mb-lg-0" id="buyerLinks" runat="server">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="frmSearch.aspx">Search</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmBuyerScheduledVisits.aspx">Scheduled Showings</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmOffersBuyer.aspx">Your Offers <span runat="server" id="buyerOfferCount" class="badge text-bg-danger"></span></a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="frmDashboard.aspx">Dashboard</a>
        </li>
      </ul>
      <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-outline-light" OnClick="btnLogout_Click"/>
    </div>
  </div>
</nav>