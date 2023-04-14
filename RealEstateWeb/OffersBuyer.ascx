<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OffersBuyer.ascx.cs" Inherits="RealEstateWeb.OffersBuyer" %>
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