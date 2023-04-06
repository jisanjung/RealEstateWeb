<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="RealEstateWeb.frmSearch" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div>
            <h1>Search</h1>
        </div>
        <ul class="searchFunctionality">
            <li style="display:inline-block; padding: 1rem">Location<br />
                <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem"> Minimum Price<br />
                <asp:TextBox ID="txtMinPrice" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem">Maximum Price<br />
                <asp:TextBox ID="txtMaxPrice" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem">Property Type<br />
                <asp:TextBox ID="txtPropType" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem">Number of Beds<br />
                <asp:TextBox ID="txtBeds" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem">Number of Baths<br />
                <asp:TextBox ID="txtBaths" runat="server"></asp:TextBox>
            </li>
            <li style="display:inline-block; padding: 1rem">
                <asp:Button ID="btnSearch" runat="server" Text="Search" />
            </li>
        </ul>

        <div class="homeResults">
            <!--NEED TO POPULATE WITH REPEATER FILLED WITH THE HOMECARD ASCX:
                <uc:HomeCard runat="server" id="HomeCard"/>
                -->
        </div>

    </form>
</body>
</html>
