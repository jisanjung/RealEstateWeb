<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOffers.aspx.cs" Inherits="RealEstateWeb.frmOffers" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<%@ Register Src="~/Footer.ascx" TagPrefix="uc" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <style>
        .tint {
            background: rgba(0, 0, 0, 0.5);
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <div>
            <div id="divViewOffer" runat="server" visible="false" class="position-fixed z-1 tint">
                <div class="vh-100 d-flex justify-content-center align-items-center">
                    <div class="bg-white">
                        <div class="d-flex justify-content-end" style="background: rgba(0, 0, 0, 0.5);">
                            <asp:LinkButton ID="linkbtnClose" runat="server" OnClick="linkbtnClose_Click" CssClass="text-white mb-1">Close</asp:LinkButton>
                        </div>
                        <div class="p-4">
                            <div class="d-none">
                                <asp:Label ID="lblViewOfferId" runat="server"></asp:Label>
                            </div>
                            <h5 class="fw-bold mb-3">
                                <asp:Label ID="lblOfferTitle" runat="server"></asp:Label>
                            </h5>
                            <div class="alert alert-primary my-4">
                                <asp:Label ID="lblBuyerEmail" runat="server"></asp:Label>
                            </div>
                            <div class="list-group">
                                <div class="list-group-item">
                                    <span class="fw-bold">Sale Type: </span>
                                    <asp:Label ID="lblSaleType" runat="server"></asp:Label>
                                </div>
                                <div class="list-group-item">
                                    <span class="fw-bold">Contingencies: </span>
                                    <asp:Label ID="lblContingencies" runat="server"></asp:Label>
                                </div>
                                <div class="list-group-item">
                                    <span class="fw-bold">Move-in date: </span>
                                    <asp:Label ID="lblMoveinDate" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="text-secondary my-3">
                                <asp:Label ID="lblSellHomeFirst" runat="server"></asp:Label>
                            </div>
                            <div class="d-flex justify-content-end mt-4">
                                <asp:Button ID="btnAcceptAmount" runat="server" OnClick="btnAcceptAmount_Click" CssClass="btn btn-primary me-2"/>
                                <asp:Button ID="btnDeclineOffer" runat="server" Text="Decline" OnClick="btnDeclineOffer_Click" CssClass="btn btn-outline-primary"/>
                            </div>
                            <asp:Label ID="lblAlert" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container my-5">
                <h1 class="mb-5 display-6">Offers made to your Homes</h1>
                <table class="table table-striped">
                    <tr>
                        <th scope="col">Offer ID</th>
                        <th scope="col">From</th>
                        <th scope="col">Offer Amount</th>
                        <th scope="col"></th>
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
                                    <span>$</span>
                                    <asp:Label ID="lblOfferAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OfferAmount")%>'></asp:Label>
                                </td>
                                <td class="d-flex justify-content-end">
                                    <asp:Button ID="btnViewOffer" runat="server" Text="View" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewOffer" CssClass="btn btn-primary"/>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <uc:Footer runat="server" id="footer"/>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
