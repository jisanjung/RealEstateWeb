<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeCard.ascx.cs" Inherits="RealEstateWeb.HomeCard" %>
<div style="border:solid 1px; width: 200px; height: 300px;">
    <img style="max-width:200px" src="https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg"/> <br />
    <asp:Label ID="lblPrice" runat="server" Text="100000"></asp:Label> <br />
    <asp:Label ID="lblAddress" runat="server" Text="123 Address St."></asp:Label> <br />
    <asp:Label ID="lblSize" runat="server" Text="600 sqft"></asp:Label> <br />
    <asp:Label ID="lblBed" runat="server" Text="1 bed"></asp:Label> <br />
    <asp:Label ID="lblBath" runat="server" Text="1 bath"></asp:Label> <br />
</div>