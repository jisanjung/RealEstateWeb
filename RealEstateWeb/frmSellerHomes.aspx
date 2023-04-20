<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSellerHomes.aspx.cs" Inherits="RealEstateWeb.frmSellerHomes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
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
            <div>
                <label>Change Image</label>
                <asp:FileUpload ID="fuChangeImage" runat="server" />
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"/>
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
                                <asp:Button ID="btnShowingRequests" runat="server" Text="View Showing Requests" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ShowingRequests"/>
                                <asp:Button ID="btnViewFeedback" runat="server" Text="View Feedback" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewFeedback"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h4>
                    <asp:Label ID="lblHomeShowingsTitle" runat="server"></asp:Label>
                </h4>
                <!--dynamic display (building my own html)-->
                <ul id="ulHomeShowingList" runat="server">
                
                </ul>
            </div>
            <div>
                <!--dynamic display (building my own html)-->
                <ul id="ulFeedback" runat="server">

                </ul>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
