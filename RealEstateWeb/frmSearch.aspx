﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="RealEstateWeb.frmSearch" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<uc:Navbar runat="server" id="navbar"/>--%>
        <h1>Search</h1>
        <div id="sideFilter">
            <div>
                <label>Location</label>
                <asp:TextBox ID="txtZipCode" runat="server" placeholder="Enter Zip Code"></asp:TextBox>
            </div>
            <div>
                <label>Price Range</label>
                <asp:TextBox ID="txtPriceStarting" runat="server" placeholder="Starting Amount"></asp:TextBox> 
                <span>to</span>
                <asp:TextBox ID="txtEndingPrice" runat="server" placeholder="Ending Amount"></asp:TextBox>
            </div>
            <div>
                <label>Property Type</label>
                <asp:DropDownList ID="ddlPropertyType" runat="server">
                    <asp:ListItem>Single Family</asp:ListItem>
                    <asp:ListItem>Multi Family</asp:ListItem>
                    <asp:ListItem>Condo</asp:ListItem>
                    <asp:ListItem>Townhouse</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label>House Size</label>
                <asp:TextBox ID="txtHomeSize" runat="server" placeholder="Enter house size"></asp:TextBox>
                <span>sqft (and under)</span>
            </div>
            <div>
                <label>Bedrooms</label>
                <asp:TextBox ID="txtMinBedrooms" runat="server" placeholder="Minimum Bedrooms"></asp:TextBox>
            </div>
            <div>
                <label>Bathrooms</label>
                <asp:TextBox ID="txtMinBathrooms" runat="server" placeholder="Mininum Bathrooms"></asp:TextBox>
            </div>
            <div>
                <label>Amenities</label>
                <asp:CheckBoxList ID="cblAmenities" runat="server">
                    <asp:ListItem>Fireplace</asp:ListItem>
                    <asp:ListItem>Pool</asp:ListItem>
                    <asp:ListItem>Hot Tub</asp:ListItem>
                    <asp:ListItem>Garden</asp:ListItem>
                    <asp:ListItem>Bar</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
        </div>
        <div class="homeResults">
        </div>

    </form>
</body>
</html>
