<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCreateHome.aspx.cs" Inherits="RealEstateWeb.frmCreateHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div>
                <h1>Post a Home For Sale</h1>
            </div>
            <div>
                <div class="form-group">
                    <p>Address</p>
                    <asp:TextBox ID="txtStreetAddress" runat="server" placeholder="Enter Street Address"></asp:TextBox>
                    <asp:TextBox ID="txtCity" runat="server" placeholder="Enter City"></asp:TextBox>
                    <asp:TextBox ID="txtState" runat="server" placeholder="Enter State"></asp:TextBox>
                    <asp:TextBox ID="txtZip" runat="server" placeholder="Enter Zip"></asp:TextBox>
                </div>
                <div>
                    <p>About your Property</p>
                    <asp:TextBox ID="txtYearBuilt" runat="server" placeholder="What year was this home built?"></asp:TextBox>
                    <label>Type</label>
                    <asp:DropDownList ID="ddlPropertyType" runat="server">
                        <asp:ListItem>Single Family</asp:ListItem>
                        <asp:ListItem>Multi Family</asp:ListItem>
                        <asp:ListItem>Townhouse</asp:ListItem>
                        <asp:ListItem>Condo</asp:ListItem>
                    </asp:DropDownList>
                    <label>HVAC System</label>
                    <asp:DropDownList ID="ddlHVAC" runat="server">
                        <asp:ListItem>Central Air</asp:ListItem>
                        <asp:ListItem>Forced Air Heat</asp:ListItem>
                        <asp:ListItem>Oil Heat</asp:ListItem>
                        <asp:ListItem>Propane Heat</asp:ListItem>
                        <asp:ListItem>Hot Water Radiator</asp:ListItem>
                        <asp:ListItem>Electric Heating</asp:ListItem>
                    </asp:DropDownList>
                    <label>Water Supply</label>
                    <asp:DropDownList ID="ddlWater" runat="server">
                        <asp:ListItem>Well Water</asp:ListItem>
                        <asp:ListItem>Public Supply</asp:ListItem>
                    </asp:DropDownList>
                    <label>Sewage System</label>
                    <asp:DropDownList ID="ddlSewage" runat="server">
                        <asp:ListItem>Public Sewer</asp:ListItem>
                        <asp:ListItem>Septic</asp:ListItem>
                    </asp:DropDownList>
                    <div>
                        <label>Amenities</label>
                        <asp:CheckBoxList ID="cblAmenities" runat="server">
                            <asp:ListItem>Fireplace</asp:ListItem>
                            <asp:ListItem>Pool</asp:ListItem>
                            <asp:ListItem>Hot Tub</asp:ListItem>
                            <asp:ListItem>Garden</asp:ListItem>
                            <asp:ListItem>Bar</asp:ListItem>
                        </asp:CheckBoxList>
                        <label>Garage</label>
                        <asp:DropDownList ID="ddlGarage" runat="server">
                            <asp:ListItem>None</asp:ListItem>
                            <asp:ListItem>2 Car</asp:ListItem>
                            <asp:ListItem>3 Car</asp:ListItem>
                            <asp:ListItem>4 Car</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <p>Rooms</p>
                    <label>Bedrooms (<asp:Label ID="lblBedroomCount" runat="server" Text="0"></asp:Label>)</label>
                    <asp:LinkButton ID="linkbtnAddBedroom" runat="server">Add a Bedroom</asp:LinkButton>
                    <div id="divBedroomDimensions" runat="server">
                        <p>Bedroom Dimensions</p>
                        <asp:TextBox ID="txtBedroomLength" runat="server" placeholder="Bedroom Length"></asp:TextBox>
                        <span>by</span>
                        <asp:TextBox ID="txtBedroomWidth" runat="server" placeholder="Bedroom Width"></asp:TextBox>
                        <asp:Button ID="btnAddBedroom" runat="server" Text="Add" />
                    </div>
                    <label>Bathrooms (<asp:Label ID="lblBRCount" runat="server" Text="0"></asp:Label>)</label>
                    <asp:LinkButton ID="linkbtnAddBR" runat="server">Add a Bathroom</asp:LinkButton>
                    <div id="divBRDimensions" runat="server">
                        <p>Bathroom Dimensions</p>
                        <asp:TextBox ID="txtBRLength" runat="server" placeholder="Bathroom Length"></asp:TextBox>
                        <span>by</span>
                        <asp:TextBox ID="txtBRWidth" runat="server" placeholder="Bathroom Width"></asp:TextBox>
                        <asp:Button ID="btnAddBR" runat="server" Text="Add" />
                    </div>
                    <label>Other Rooms</label>
                    <asp:LinkButton ID="linkbtnAddOtherRoom" runat="server">Add another Room</asp:LinkButton>
                    <div id="divOtherRoomDimensions" runat="server">
                        <p>Room Dimensions</p>
                        <asp:TextBox ID="txtOtherRoomLength" runat="server" placeholder="Room Length"></asp:TextBox>
                        <asp:TextBox ID="txtOtherRoomWidth" runat="server" placeholder="Room Width"></asp:TextBox>
                        <asp:Button ID="btnAddOtherRoom" runat="server" Text="Add" />
                    </div>
                </div>
                <div>
                    <label>Description About the Home</label>
                    <textarea id="taHomeDescription" cols="20" rows="5" placeholder="Comment about this home"></textarea>
                    <label>Asking Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Set the Starter Price"></asp:TextBox>
                </div>
                <div>
                    <p>Upload an Image for the Home</p>
                    <asp:FileUpload ID="fuHomeImg" runat="server" />
                    <label>Image Caption</label>
                    <asp:TextBox ID="txtImgCaption" runat="server" placeholder="Write a caption for this Image"></asp:TextBox>
                </div>
                <div>
                    <p>About the Seller / Homeowner</p>
                    <label>Seller / Homeowner Email</label>
                    <asp:TextBox ID="txtSellerEmail" runat="server" placeholder="Enter Seller's Email"></asp:TextBox>
                    <div id="divCreateSellerAcc" runat="server" visible="false">
                        <label>Password</label>
                        <input id="sellerPassword" type="password" runat="server" placeholder="Enter a Password for the Seller"/>
                        <label>Seller's Full Name</label>
                        <asp:TextBox ID="txtSellerName" runat="server" placeholder="Enter Seller's Full Name"></asp:TextBox>
                        <label>Seller's Home Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Seller's Address"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="btnSubmitHome" runat="server" Text="Add Home for Sale" />
    </form>
</body>
</html>
