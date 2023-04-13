<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffers.aspx.cs" Inherits="RealEstateWeb.frmOffers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Offers made to your Homes</h1>
            <div id="divViewOffer" runat="server" visible="false">
                <div>
                    <asp:Label ID="lblViewOfferId" runat="server"></asp:Label>
                </div>
                <h4>
                    <asp:Label ID="lblOfferTitle" runat="server"></asp:Label>
                </h4>
                <div>
                    <asp:Label ID="lblBuyerEmail" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblSaleType" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblContingencies" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblMoveinDate" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblSellHomeFirst" runat="server"></asp:Label>
                </div>
                <asp:Button ID="btnAcceptAmount" runat="server" />
            </div>
            <table>
                <tr>
                    <th>Offer ID</th>
                    <th>From</th>
                    <th>Offer Amount</th>
                </tr>
                <asp:Repeater ID="rptOffers" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblOfferId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeOfferId")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblBuyer" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BuyerEmail")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblOfferAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OfferAmount")%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="btnViewOffer" runat="server" Text="View" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewOffer"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
