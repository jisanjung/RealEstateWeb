﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffersBuyer.aspx.cs" Inherits="RealEstateWeb.frmOffersBuyer" %>
<%@ Register Src="~/OffersBuyer.ascx" TagPrefix="uc" TagName="OffersBuyer" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<%@ Register Src="~/Footer.ascx" TagPrefix="uc" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Homes "R" Us | Offers</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="https://fonts.cdnfonts.com/css/poppins" rel="stylesheet"/>
    <style>
        html, body {
            font-family: 'Poppins', sans-serif;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div class="container my-5">
            <h1 class="display-6 mb-5">
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </h1>
            <uc:OffersBuyer runat="server" id="ucOffersBuyer"/>
        </div>
        <uc:Footer runat="server" id="footer"/>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
