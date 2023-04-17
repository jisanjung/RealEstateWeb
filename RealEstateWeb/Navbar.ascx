<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="RealEstateWeb.Navbar" %>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <h1 class="navbar-brand">Homes R Us</h1>
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
          <a class="nav-link" href="frmOffers.aspx">Offers</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" href="frmDashboard.aspx">Dashboard</a>
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
          <a class="nav-link" href="frmOffers.aspx">Offers</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" href="frmDashboard.aspx">Dashboard</a>
        </li>
      </ul>
      <ul class="navbar-nav me-auto mb-2 mb-lg-0" id="buyerLinks" runat="server">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="frmSearch.aspx">Search</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Scheduled Showings</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="frmOffersBuyer.aspx">Your Offers</a>
        </li>
        <li class="nav-item">
          <a class="nav-link disabled" href="frmDashboard.aspx">Dashboard</a>
        </li>
      </ul>
      <button class="btn btn-outline-success">Logout</button>
    </div>
  </div>
</nav>