<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCreateHome.aspx.cs" Inherits="RealEstateWeb.frmCreateHome" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <style>
        #cblAmenities label {
            margin-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc:Navbar runat="server" id="navbar"/>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container mb-5" style="width: 700px;">
            <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCreateSellerAlert" runat="server" Text=""></asp:Label>
            <div>
                <h1 class="display-6 mt-5 mb-4">Post a Home For Sale</h1>
            </div>
            <div>
                <div class="form-group mb-4">
                    <label class="fw-bold">Address</label>
                    <div class="d-flex">
                        <div class="w-50 me-3">
                            <asp:TextBox ID="txtStreetAddress" runat="server" placeholder="Enter Street Address" required CssClass="form-control mb-2"></asp:TextBox>
                            <asp:TextBox ID="txtCity" runat="server" placeholder="Enter City" required CssClass="form-control mb-2"></asp:TextBox>
                        </div>
                        <div class="w-50 ms-3">
                            <asp:TextBox ID="txtState" runat="server" placeholder="Enter State" required CssClass="form-control mb-2"></asp:TextBox>
                            <asp:TextBox ID="txtZip" runat="server" placeholder="Enter Zip" required CssClass="form-control mb-2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="mb-5">
                    <label class="fw-bold">About your Property</label>
                    <asp:TextBox ID="txtYearBuilt" runat="server" placeholder="What year was this home built?" required CssClass="form-control mb-4"></asp:TextBox>
                    <div class="d-flex">
                        <div class="w-50 me-3">
                            <label>Type</label>
                            <asp:DropDownList ID="ddlPropertyType" runat="server" CssClass="d-block w-100 py-2 px-3 mb-2">
                                <asp:ListItem>Single Family</asp:ListItem>
                                <asp:ListItem>Multi Family</asp:ListItem>
                                <asp:ListItem>Townhouse</asp:ListItem>
                                <asp:ListItem>Condo</asp:ListItem>
                            </asp:DropDownList>
                            <label>HVAC System</label>
                            <asp:DropDownList ID="ddlHVAC" runat="server" CssClass="d-block w-100 py-2 px-3 mb-2">
                                <asp:ListItem>Central Air</asp:ListItem>
                                <asp:ListItem>Forced Air Heat</asp:ListItem>
                                <asp:ListItem>Oil Heat</asp:ListItem>
                                <asp:ListItem>Propane Heat</asp:ListItem>
                                <asp:ListItem>Hot Water Radiator</asp:ListItem>
                                <asp:ListItem>Electric Heating</asp:ListItem>
                            </asp:DropDownList>
                            <label>Water Supply</label>
                            <asp:DropDownList ID="ddlWater" runat="server" CssClass="d-block w-100 py-2 px-3 mb-2">
                                <asp:ListItem>Well Water</asp:ListItem>
                                <asp:ListItem>Public Supply</asp:ListItem>
                            </asp:DropDownList>
                            <label>Sewage System</label>
                            <asp:DropDownList ID="ddlSewage" runat="server" CssClass="d-block w-100 py-2 px-3 mb-2">
                                <asp:ListItem>Public Sewer</asp:ListItem>
                                <asp:ListItem>Septic</asp:ListItem>
                            </asp:DropDownList>
                            <label>Garage</label>
                            <asp:DropDownList ID="ddlGarage" runat="server" CssClass="d-block w-100 py-2 px-3 mb-2">
                                <asp:ListItem>None</asp:ListItem>
                                <asp:ListItem>2 Car</asp:ListItem>
                                <asp:ListItem>3 Car</asp:ListItem>
                                <asp:ListItem>4 Car</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="w-50 ms-3">
                            <label>Amenities</label>
                            <asp:CheckBoxList ID="cblAmenities" runat="server">
                                <asp:ListItem>Fireplace</asp:ListItem>
                                <asp:ListItem>Pool</asp:ListItem>
                                <asp:ListItem>Hot Tub</asp:ListItem>
                                <asp:ListItem>Garden</asp:ListItem>
                                <asp:ListItem>Bar</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                <div class="mb-5">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <label class="fw-bold">Rooms</label>
                                <div class="mb-2">
                                    <label>Bedrooms (<asp:Label ID="lblBedroomCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddBedroom" runat="server" OnClick="linkbtnAddBedroom_Click">Add a Bedroom</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblBedrooms" runat="server" Text=""></asp:Label>
                                <div id="divBedroomDimensions" runat="server" visible="false" class="mb-4">
                                    <asp:TextBox ID="txtBedroomLength" runat="server" placeholder="Bedroom Length"></asp:TextBox>
                                    <span>by</span>
                                    <asp:TextBox ID="txtBedroomWidth" runat="server" placeholder="Bedroom Width"></asp:TextBox>
                                    <asp:Button ID="btnAddBedroom" runat="server" Text="Add" OnClick="btnAddBedroom_Click" formnovalidate="formnovalidate" CssClass="btn btn-primary"/>
                                </div>
                                <div class="mb-2 mt-3">
                                    <label>Bathrooms (<asp:Label ID="lblBRCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddBR" runat="server" OnClick="linkbtnAddBR_Click">Add a Bathroom</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblBathrooms" runat="server" Text=""></asp:Label>
                                <div id="divBRDimensions" runat="server" visible="false">
                                    <asp:TextBox ID="txtBRLength" runat="server" placeholder="Bathroom Length"></asp:TextBox>
                                    <span>by</span>
                                    <asp:TextBox ID="txtBRWidth" runat="server" placeholder="Bathroom Width"></asp:TextBox>
                                    <asp:Button ID="btnAddBR" runat="server" Text="Add" OnClick="btnAddBR_Click" formnovalidate="formnovalidate" CssClass="btn btn-primary"/>
                                </div>
                                <div class="mb-2 mt-3">
                                    <label>Other Rooms (<asp:Label ID="lblOtherRoomsCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddOtherRoom" runat="server" OnClick="linkbtnAddOtherRoom_Click">Add another Room</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblOtherRooms" runat="server" Text=""></asp:Label>
                                <div id="divOtherRoomDimensions" runat="server" visible="false">
                                    <asp:TextBox ID="txtRoomName" runat="server" placeholder="What kind of room is this"></asp:TextBox>
                                    <asp:TextBox ID="txtOtherRoomLength" runat="server" placeholder="Room Length"></asp:TextBox>
                                    <asp:TextBox ID="txtOtherRoomWidth" runat="server" placeholder="Room Width"></asp:TextBox>
                                    <asp:Button ID="btnAddOtherRoom" runat="server" Text="Add" OnClick="btnAddOtherRoom_Click" formnovalidate="formnovalidate" CssClass="btn btn-primary"/>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <label class="fw-bold">Description About the Home</label>
                    <textarea id="taHomeDescription" cols="20" rows="5" placeholder="Comment about this home" runat="server" class="form-control mb-4"></textarea>
                    <label class="fw-bold">Asking Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Set the Starter Price" required CssClass="form-control mb-5"></asp:TextBox>
                </div>
                <div class="d-flex mb-5">
                    <div class="w-50 me-3">
                        <label class="fw-bold">Upload an Image for the Home</label>
                        <asp:FileUpload ID="fuHomeImg" runat="server" CssClass="d-block"/>
                    </div>
                    <div class="w-50 ms-3">
                        <label class="fw-bold">Image Caption</label>
                        <asp:TextBox ID="txtImgCaption" runat="server" placeholder="Write a caption for this Image" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div>
                    <label class="fw-bold">About the Seller / Homeowner</label>
                    <div id="divAgentInfo" runat="server" visible="false" class="d-flex mb-4">
                        <div class="w-50 me-3">
                            <label>Real Estate Agent Email</label>
                            <asp:TextBox ID="txtAgentEmail" runat="server" placeholder="Enter Real Estate Agent Email" required CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="w-50 ms-3">
                            <label>Real Estate Company Name</label>
                            <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Enter Company Name" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <label id="pCreateSeller" runat="server" visible="false" class="d-block fw-bold">Create an account for the seller</label>
                        <label>Seller / Homeowner Email</label>
                        <asp:TextBox ID="txtSellerEmail" runat="server" placeholder="Enter Seller's Email" required CssClass="form-control mb-2"></asp:TextBox>
                        <div id="divCreateSellerAcc" runat="server" visible="false">
                            <label>Seller Password</label>
                            <input id="sellerPassword" type="password" runat="server" placeholder="Enter a Password for the Seller" required class="form-control mb-2"/>
                            <label>Seller's Full Name</label>
                            <asp:TextBox ID="txtSellerName" runat="server" placeholder="Enter Seller's Full Name" required CssClass="form-control mb-2"></asp:TextBox>
                            <label>Seller's Home Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Seller's Address" required CssClass="form-control mb-2"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnSubmitHome" runat="server" Text="Add Home for Sale" OnClick="btnSubmitHome_Click" CssClass="btn btn-primary my-4"/>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.7/dist/umd/popper.min.js" integrity="sha384-zYPOMqeu1DAVkHiLqWBUTcbYfZ8osu1Nd6Z89ify25QV9guujx43ITvfi12/QExE" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.min.js" integrity="sha384-Y4oOpwW3duJdCWv5ly8SCFYWqFDsfob/3GkgExXKV4idmbt98QcxXYs9UoXAB7BZ" crossorigin="anonymous"></script>
</body>
</html>
