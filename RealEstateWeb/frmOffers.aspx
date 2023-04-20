<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffers.aspx.cs" Inherits="RealEstateWeb.frmOffers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblAlert" runat="server"></asp:Label>
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
                <asp:Button ID="btnAcceptAmount" runat="server" OnClick="btnAcceptAmount_Click" />
                <asp:Button ID="btnDeclineOffer" runat="server" Text="Decline" OnClick="btnDeclineOffer_Click"/>
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
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
