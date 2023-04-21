<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OffersBuyer.ascx.cs" Inherits="RealEstateWeb.OffersBuyer" %>
<table class="table table-striped">
    <tr>
        <th scope="col">Offer ID</th>
        <th scope="col">From</th>
        <th scope="col">Amount</th>
        <th scope="col">Status</th>
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
                    <span>$</span>
                    <asp:Label ID="lblOfferAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OfferAmount")%>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblOfferStatus" runat="server" Text="Accepted" CssClass="badge text-bg-success"></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</table>