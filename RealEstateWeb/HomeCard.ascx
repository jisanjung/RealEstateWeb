<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeCard.ascx.cs" Inherits="RealEstateWeb.HomeCard" %>
<div style="border:solid 1px; width: 200px; height: 300px;">
    <img id="imgHome" style="max-width:200px;" src="https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg" runat="server"/> <br />
    <asp:Label ID="lblPrice" runat="server"></asp:Label>
    <div>
        <asp:Label ID="lblSize" runat="server"></asp:Label>
        <span> | </span>
        <asp:Label ID="lblBed" runat="server"></asp:Label>
        <span> | </span>
        <asp:Label ID="lblBath" runat="server"></asp:Label>
    </div>
    <asp:Label ID="lblAddress" runat="server"></asp:Label>
</div>