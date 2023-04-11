<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSellerHomes.aspx.cs" Inherits="RealEstateWeb.frmSellerHomes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAlert" runat="server"></asp:Label>
        </div>
        <div id="divEditHome" runat="server" visible="false">
            <div>
                <asp:Label ID="lblSelectedId" runat="server"></asp:Label>
            </div>
            <div>
                <label>Change Price</label>
                <asp:TextBox ID="txtChangePrice" runat="server" placeholder="Change the price of this house"></asp:TextBox>
            </div>
            <div>
                <label>Change Status</label>
                <asp:TextBox ID="txtChangeStatus" runat="server" placeholder="Change status (Sale, Pending, Sold)"></asp:TextBox>
            </div>
            <div>
                <label>Change Description</label>
                <textarea id="taChangeDescription" cols="20" rows="5" runat="server" placeholder="Change the description of this house"></textarea>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
        <div>
            <h1>Manage Your Homes</h1>
            <div id="sellerHomesResults">
                <asp:Repeater ID="rptSellerHomes" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="lblHomeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeId")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Image ID="imgHome" runat="server" ImageUrl='<%#"~/Storage/"+Eval("Img") %>'  Width="200" Height="200"/>
                                 </div>
                                <div>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                    <span> </span>
                                    <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZipCode")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblHomeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>'></asp:Label>
                                </div>
                                <asp:Button ID="btnEditHome" runat="server" Text="Edit" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_EditHome"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
