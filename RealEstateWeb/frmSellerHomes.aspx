<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSellerHomes.aspx.cs" Inherits="RealEstateWeb.frmSellerHomes" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>
<%@ Register Src="~/Footer.ascx" TagPrefix="uc" TagName="Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css"/>
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
        <div id="divEditHome" runat="server" visible="false" class="position-fixed z-1 tint">
            <div class="vh-100 d-flex justify-content-center align-items-center">
                <div class="bg-white">
                    <div class="d-flex justify-content-end" style="background: rgba(0, 0, 0, 0.5);">
                        <asp:LinkButton ID="linkbtnClose" runat="server" OnClick="linkbtnClose_Click" CssClass="text-white mb-1">Close</asp:LinkButton>
                    </div>
                    <div class="card p-4">
                        <div class="d-none">
                            <asp:Label ID="lblSelectedId" runat="server"></asp:Label>
                        </div>
                        <div>
                            <label class="fw-bold">Change Price</label>
                            <asp:TextBox ID="txtChangePrice" runat="server" placeholder="Change the price of this house" CssClass="form-control mb-3"></asp:TextBox>
                        </div>
                        <div>
                            <label class="fw-bold">Change Status</label>
                            <asp:TextBox ID="txtChangeStatus" runat="server" placeholder="Change status (Sale, Pending, Sold)" CssClass="form-control mb-3"></asp:TextBox>
                        </div>
                        <div>
                            <label class="fw-bold">Change Description</label>
                            <textarea id="taChangeDescription" cols="20" rows="5" runat="server" placeholder="Change the description of this house" class="form-control mb-3"></textarea>
                        </div>
                        <div>
                            <label class="fw-bold">Change Image</label>
                            <asp:FileUpload ID="fuChangeImage" runat="server" CssClass="d-block mb-3"/>
                        </div>
                        <div class="d-flex justify-content-end mt-3">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary me-2"/>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-outline-primary"/>
                        </div>
                        <div>
                            <asp:Label ID="lblEditHomeAlert" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container my-5">
            <h1 class="mb-5 display-6">Manage Your Homes</h1>
            <div id="sellerHomesResults">
                <asp:Repeater ID="rptSellerHomes" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <div class="d-none">
                                    <asp:Label ID="lblHomeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeId")%>'></asp:Label>
                                </div>
                                <div class="card my-4">
                                    <div class="d-flex justify-content-between">
                                        <div class="d-flex">
                                            <asp:Image ID="imgHome" runat="server" ImageUrl='<%#"~/Storage/"+Eval("Img") %>' Width="300" Height="200" CssClass="object-fit-cover rounded-start-1"/>
                                            <div class="p-4">
                                                <h3 class="fw-bold">
                                                    <span>$</span>
                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>'></asp:Label>
                                                </h3>
                                                <div>
                                                    <asp:Label ID="lblHomeStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' CssClass="badge text-bg-warning"></asp:Label>
                                                </div>
                                                <div class="my-2">
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                                    <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZipCode")%>'></asp:Label>
                                                </div>
                                                <%--<asp:LinkButton ID="linkbtnEditHome" runat="server" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_EditHome">Edit this Home</asp:LinkButton>--%>
                                                <asp:Button ID="btnEditHome" runat="server" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_EditHome" Text="Edit this Home" CssClass="btn btn-primary mt-2"/>
                                            </div>
                                        </div>
                                        <div class="d-flex flex-column justify-content-center p-4">
                                            <asp:Button ID="btnShowingRequests" runat="server" Text="View Showing Requests" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ShowingRequests" CssClass="btn btn-primary mb-2"/>
                                            <asp:Button ID="btnViewFeedback" runat="server" Text="View Feedback" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewFeedback" CssClass="btn btn-outline-primary"/>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="divHomeShowingResults" runat="server" visible="false" class="position-fixed z-1 tint">
                <div class="vh-100 d-flex justify-content-center align-items-center">
                    <div class="bg-white">
                        <div class="d-flex justify-content-end" style="background: rgba(0, 0, 0, 0.5);">
                            <asp:LinkButton ID="linkbtnCloseHomeShowing" runat="server" OnClick="linkbtnCloseHomeShowing_Click" CssClass="text-white mb-1">Close</asp:LinkButton>
                        </div>
                        <div class="card p-4">
                            <h5 class="fw-bold mb-4">
                                <asp:Label ID="lblHomeShowingsTitle" runat="server"></asp:Label>
                            </h5>
                            <!--dynamic display (building my own html)-->
                            <ul id="ulHomeShowingList" runat="server" class="list-group">
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divFeedbackResults" runat="server" visible="false" class="position-fixed z-1 tint">
                <div class="vh-100 d-flex justify-content-center align-items-center">
                    <div class="bg-white">
                        <div class="d-flex justify-content-end" style="background: rgba(0, 0, 0, 0.5);">
                            <asp:LinkButton ID="linkbtnCloseFeedback" runat="server" OnClick="linkbtnCloseFeedback_Click" CssClass="text-white mb-1">Close</asp:LinkButton>
                        </div>
                        <div class="card p-4">
                            <h5 class="fw-bold mb-4">
                                <asp:Label ID="lblFeedbackTitle" runat="server"></asp:Label>
                            </h5>
                            <!--dynamic display (building my own html)-->
                            <ul id="ulFeedback" runat="server" class="list-group">

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc:Footer runat="server" id="footer"/>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
