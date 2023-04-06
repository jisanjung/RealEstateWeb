<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="RealEstateWeb.frmMain" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<%@ Register Src="~/HomeCard.ascx" TagPrefix="uc" TagName="HomeCard" %>

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
        <div class="mainContent">
            <h2>I dont want to settle, I'm a Homes R Us buyer.</h2>

        </div>
    </form>
</body>
</html>
