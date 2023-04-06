<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="RealEstateWeb.Navbar" %>
<div style="background-color:indianred; height: 75px; z-index: 1; left: 0px; top: 0px; position: absolute; width: 100%;">
    <asp:Button style="z-index: 1; left: 16px; top: 12px; position: absolute; height: 36px; width: 185px" Text="Homes R Us" ID="btnMain" runat="server" OnClick="btnMain_Click"/>
    <ul style="width: 250px; right:5%; z-index: 1; top: 4px; position: absolute; height: 27px;">
        <li style="display:inline">
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </li>        
        <li style="display:inline">
            <asp:Button ID="btnDashboard" runat="server" Text="Dashboard" OnClick="btnDashboard_Click" />
        </li>        
        <li style="display:inline">
            <asp:Button ID="frmAccount" runat="server" Text="Account" OnClick="frmAccount_Click" />
        </li>
    </ul>
</div>