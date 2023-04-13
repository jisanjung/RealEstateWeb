<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffersBuyer.aspx.cs" Inherits="RealEstateWeb.frmOffersBuyer" %>

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
            <table>
                <tr>
                    <th>Offer ID</th>
                    <th>From</th>
                    <th>Amount</th>
                    <th>Status</th>
                </tr>
                <asp:Repeater ID="rptAcceptedOffers" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblOfferId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeOfferId")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSellerEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SellerEmail")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblOfferAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OfferAmount")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblOfferStatus" runat="server" Text="Accepted"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
