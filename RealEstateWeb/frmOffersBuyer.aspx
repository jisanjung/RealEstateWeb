<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffersBuyer.aspx.cs" Inherits="RealEstateWeb.frmOffersBuyer" %>
<%@ Register Src="~/OffersBuyer.ascx" TagPrefix="uc" TagName="OffersBuyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="lblTitle" runat="server"></asp:Label>
            </h1>
            <uc:OffersBuyer runat="server" id="ucOffersBuyer"/>
        </div>
    </form>
</body>
</html>
