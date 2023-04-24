<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="RealEstateWeb.frmSearch" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <style>
        #sideFilter {
            width: 300px;
            bottom: 0;
            top: 0;
            padding-top: 58px !important;
            overflow-y: scroll;
        }
        #homeResults {
            left: 300px;
            margin-right: 17rem;
        }
        #cblAmenities label, #cblContingencies label {
            margin-left: 5px;
        }
        .tint {
            background: rgba(0, 0, 0, 0.5);
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
        }
    </style>
</head>
<body class="overflow-x-hidden">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <uc:Navbar runat="server" id="navbar"/>
        <div class="position-fixed z-1 tint" id="divHomeProfile" runat="server" visible="false">
            <div class="vh-100 d-flex justify-content-center align-items-center">
                <div class="bg-white">
                    <div class="d-flex justify-content-end" style="background: rgba(0, 0, 0, 0.5);">
                        <asp:LinkButton ID="linkbtnClose" runat="server" OnClick="linkbtnClose_Click" CssClass="text-white mb-1">Close</asp:LinkButton>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="d-flex" style="width: 800px; height: 500px;">
                                <div class="w-50 overflow-y-hidden">
                                    <img id="imgHomeProfile" runat="server" class="w-100 h-100 object-fit-cover"/>
                                </div>
                                <div class="overflow-y-scroll w-50 p-4">
                                    <div class="d-none">
                                        <asp:Label ID="lblHomeProfileHomeId" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <h3 class="fw-bold">
                                            <asp:Label ID="lblHomeProfilePrice" runat="server"></asp:Label>
                                        </h3>
                                        <div class="text-secondary">
                                            <asp:Label ID="lblHomeProfileBeds" runat="server"></asp:Label>
                                            <span>| </span>
                                            <asp:Label ID="lblHomeProfileBaths" runat="server"></asp:Label>
                                            <span>| </span>
                                            <asp:Label ID="lblHomeProfileHomeSize" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:Label ID="lblHomeProfileAddress" runat="server"></asp:Label>
                                    </div>
                                    <div class="py-3">
                                        <asp:Button ID="btnRequestShowing" runat="server" Text="Request a Showing" OnClick="btnRequestShowing_Click" CssClass="btn btn-primary"/>
                                        <asp:Button ID="btnFeedback" runat="server" Text="Leave Feedback" OnClick="btnFeedback_Click" CssClass="btn btn-outline-primary"/>
                                    </div>
                                    <div id="divCreateShowing" runat="server" visible="false" class="card p-3 mb-3">
                                        <div>
                                            <label>Home Showing Date</label>
                                            <asp:TextBox ID="txtShowingDate" runat="server" placeholder="Enter desired date" CssClass="form-control mb-2"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label>Home Showing Time</label>
                                            <asp:TextBox ID="txtShowingTime" runat="server" placeholder="Enter desired time" CssClass="form-control mb-2"></asp:TextBox>
                                        </div>
                                        <div class="d-flex justify-content-end">
                                            <asp:Button ID="btnSubmitShowing" runat="server" Text="Submit Showing Request" OnClick="btnSubmitShowing_Click" CssClass="btn btn-primary mt-2"/>
                                        </div>
                                        <asp:Label ID="lblHomeShowingAlert" runat="server"></asp:Label>
                                    </div>
                                    <div id="divLeaveFeedback" runat="server" visible="false" class="card p-3">
                                        <div>
                                            <label>What are your thoughts on the price?</label>
                                            <asp:DropDownList ID="ddlPriceFeedback" runat="server" CssClass="d-block w-100 py-2 px-3 mb-3">
                                                <asp:ListItem>Perfect</asp:ListItem>
                                                <asp:ListItem>Okay</asp:ListItem>
                                                <asp:ListItem>Too High</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>What are your thoughts on the location?</label>
                                            <asp:DropDownList ID="ddlLocationFeedback" runat="server" CssClass="d-block w-100 py-2 px-3 mb-3">
                                                <asp:ListItem>Love it</asp:ListItem>
                                                <asp:ListItem>Not bad</asp:ListItem>
                                                <asp:ListItem>Terrible</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>Please comment on anything else about this home</label>
                                            <textarea id="taOverallFeedback" cols="20" rows="5" placeholder="Overall feedback..." runat="server" class="form-control"></textarea>
                                        </div>
                                        <div class="my-3">
                                            <label>Rate this home</label>
                                            <asp:DropDownList ID="ddlRating" runat="server" CssClass="d-block w-100">
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="d-flex justify-content-end">
                                            <asp:Button ID="btnSubmitFeedback" runat="server" Text="Submit Feedback" OnClick="btnSubmitFeedback_Click" CssClass="btn btn-primary"/>
                                        </div>
                                        <asp:Label ID="lblFeedbackAlert" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <label class="mb-1">About</label>
                                        <div class="list-group">
                                            <div class="list-group-item">
                                                <span class="fw-bold">Property Type: </span>
                                                <asp:Label ID="lblHomeProfilePropertyType" runat="server"></asp:Label>
                                            </div>
                                            <div class="list-group-item">
                                                <span class="fw-bold">Year Built: </span>
                                                <asp:Label ID="lblHomeProfileYearBuilt" runat="server"></asp:Label>
                                            </div>
                                            <div class="list-group-item">
                                                <span class="fw-bold">Amenities: </span>
                                                <asp:Label ID="lblHomeProfileAmenities" runat="server"></asp:Label>
                                            </div>
                                            <div class="list-group-item">
                                                <span class="fw-bold">Heating and Cooling: </span>
                                                <asp:Label ID="lblHomeProfileHVAC" runat="server"></asp:Label>
                                            </div>
                                            <div class="list-group-item">
                                                <span class="fw-bold">Garage: </span>
                                                <asp:Label ID="lblHomeProfileGarage" runat="server"></asp:Label>
                                            </div>
                                            <div class="list-group-item">
                                                <span class="fw-bold">Utilities: </span>
                                                <asp:Label ID="lblHomeProfileUtilities" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="my-3">
                                            <label class="mb-1">Rooms</label>
                                            <asp:Label ID="lblHomeProfileRoomDimensions" runat="server"></asp:Label>
                                        </div>
                                        <div>
                                            <label class="d-block">Description:</label>
                                            <asp:Label ID="lblHomeProfileDescription" runat="server" CssClass="text-secondary"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="my-3">
                                        <asp:Label ID="lblHomeProfileAgentEmail" runat="server"></asp:Label>
                                        <asp:Label ID="lblHomeProfileAgentInfo" runat="server"></asp:Label>
                                    </div>
                                    <div class="d-grid">
                                        <asp:LinkButton ID="linkbtnMakeOffer" runat="server" OnClick="linkbtnMakeOffer_Click" CssClass="btn btn-outline-primary">Make an Offer</asp:LinkButton>
                                    </div>
                                    <div id="divMakeOffer" runat="server" visible="false" class="card p-3 mt-3">
                                        <div>
                                            <label>Type of Sale</label>
                                            <asp:DropDownList ID="ddlSaleType" runat="server" CssClass="d-block w-100 py-2 px-3 mb-3">
                                                <asp:ListItem>Conventional Mortgage</asp:ListItem>
                                                <asp:ListItem>Cash</asp:ListItem>
                                                <asp:ListItem>As is (No contigencies)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div>
                                            <label>Contingencies</label>
                                            <asp:CheckBoxList ID="cblContingencies" runat="server">
                                                <asp:ListItem>Mortgage</asp:ListItem>
                                                <asp:ListItem>Title</asp:ListItem>
                                                <asp:ListItem>Home Inspection</asp:ListItem>
                                                <asp:ListItem>Insurance</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="my-4">
                                            <asp:CheckBox ID="chkSellHomeFirst" runat="server"/>
                                            <span class="ml-2">Do you need to sell your home first?</span>
                                        </div>
                                        <div>
                                            <label>Move-in Date</label>
                                            <asp:TextBox ID="txtMoveinDate" runat="server" placeholder="Enter when you'd like to move in" CssClass="form-control mb-2"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label>Offer Amount</label>
                                            <asp:TextBox ID="txtOfferAmount" runat="server" placeholder="Enter your Offer Amount" CssClass="form-control mb-2"></asp:TextBox>
                                        </div>
                                        <div class="d-flex justify-content-end">
                                            <asp:Button ID="btnSubmitOffer" runat="server" Text="Submit Offer" OnClick="btnSubmitOffer_Click" CssClass="btn btn-primary mt-2"/>
                                        </div>
                                        <asp:Label ID="lblOfferAlert" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div id="sideFilter" class="position-fixed p-4 bg-light border-end">
            <%--<h3 class="display-6 mb-4">Filter by</h3>--%>
            <asp:Label ID="lblSearchAlert" runat="server"></asp:Label>
            <div class="form-group mb-3">
                <label class="fw-bold">Location</label>
                <asp:TextBox ID="txtZipCode" runat="server" placeholder="Enter Zip Code" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group mb-3">
                <label class="fw-bold">Price Range</label>
                <asp:TextBox ID="txtPriceRange" runat="server" placeholder="Enter Target Price" CssClass="form-control"></asp:TextBox> 
                <span>(and under)</span>
            </div>
            <div class="form-group mb-3">
                <label class="fw-bold">Property Type</label>
                <asp:DropDownList ID="ddlPropertyType" runat="server" CssClass="d-block w-100 py-2 px-3">
                    <asp:ListItem>Any</asp:ListItem>
                    <asp:ListItem>Single Family</asp:ListItem>
                    <asp:ListItem>Multi Family</asp:ListItem>
                    <asp:ListItem>Condo</asp:ListItem>
                    <asp:ListItem>Townhouse</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group mb-3">
                <label class="fw-bold">House Size</label>
                <asp:TextBox ID="txtHomeSize" runat="server" placeholder="Enter house size" CssClass="form-control"></asp:TextBox>
                <span>sqft (and under)</span>
            </div>
            <div class="d-flex justify-content-between">
                <div class="form-group mb-3">
                    <label class="fw-bold">Bedrooms</label>
                    <asp:TextBox ID="txtMinBedrooms" runat="server" placeholder="Minimum Bedrooms" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group mb-3">
                    <label class="fw-bold">Bathrooms</label>
                    <asp:TextBox ID="txtMinBathrooms" runat="server" placeholder="Mininum Bathrooms" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group mb-3">
                <label class="fw-bold">Amenities</label>
                <asp:CheckBoxList ID="cblAmenities" runat="server">
                    <asp:ListItem>Fireplace</asp:ListItem>
                    <asp:ListItem>Pool</asp:ListItem>
                    <asp:ListItem>Hot Tub</asp:ListItem>
                    <asp:ListItem>Garden</asp:ListItem>
                    <asp:ListItem>Bar</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary"/>
            </div>
        </div>
        <div id="homeResults" class="position-relative px-5 my-5">
            <h3 class="display-6 mb-4 px-4" id="h3Results" runat="server"></h3>
            <table>
                <asp:Repeater ID="rptHomeResults" runat="server">
                    <ItemTemplate>
                        <tr style="float: left; width: 300px; height: 400px;" class="m-4">
                            <td>
                                <asp:Label ID="lblHomeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeId")%>' CssClass="d-none"></asp:Label>
                                <div class="card">
                                    <div>
                                        <asp:Image ID="imgHome" runat="server" ImageUrl='<%#"~/Storage/"+Eval("Img") %>' Width="300" Height="200" CssClass="card-img-top object-fit-cover"/>
                                     </div>
                                    <div class="card-body">
                                        <h5 class="fw-bold">
                                            <span>$</span>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>'></asp:Label>
                                        </h5>
                                        <div class="text-secondary">
                                            <asp:Label ID="lblHouseSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HouseSize")%>'></asp:Label>
                                            <span>sqft | </span>
                                            <asp:Label ID="lblNumberBed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberBed")%>'></asp:Label>
                                            <span>beds | </span>
                                            <asp:Label ID="lblNumberBath" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberBath")%>'></asp:Label>
                                            <span>baths</span>
                                        </div>
                                        <div class="mb-4">
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                            <span> </span>
                                            <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZipCode")%>'></asp:Label>
                                        </div>
                                        <asp:Button ID="btnViewHome" runat="server" Text="View" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewHome" CssClass="btn btn-primary"/>
                                    </div>
                                </div>
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