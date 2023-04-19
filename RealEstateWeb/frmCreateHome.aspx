<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCreateHome.aspx.cs" Inherits="RealEstateWeb.frmCreateHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container">
            <asp:Label ID="lblAlert" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblCreateSellerAlert" runat="server" Text=""></asp:Label>
            <div>
                <h1>Post a Home For Sale</h1>
            </div>
            <div>
                <div class="form-group">
                    <p>Address</p>
                    <asp:TextBox ID="txtStreetAddress" runat="server" placeholder="Enter Street Address" required></asp:TextBox>
                    <asp:TextBox ID="txtCity" runat="server" placeholder="Enter City" required></asp:TextBox>
                    <asp:TextBox ID="txtState" runat="server" placeholder="Enter State" required></asp:TextBox>
                    <asp:TextBox ID="txtZip" runat="server" placeholder="Enter Zip" required></asp:TextBox>
                </div>
                <div>
                    <p>About your Property</p>
                    <asp:TextBox ID="txtYearBuilt" runat="server" placeholder="What year was this home built?" required></asp:TextBox>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <p>Rooms</p>
                                <div>
                                    <label>Bedrooms (<asp:Label ID="lblBedroomCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddBedroom" runat="server" OnClick="linkbtnAddBedroom_Click">Add a Bedroom</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblBedrooms" runat="server" Text=""></asp:Label>
                                <div id="divBedroomDimensions" runat="server" visible="false">
                                    <p>Bedroom Dimensions</p>
                                    <asp:TextBox ID="txtBedroomLength" runat="server" placeholder="Bedroom Length"></asp:TextBox>
                                    <span>by</span>
                                    <asp:TextBox ID="txtBedroomWidth" runat="server" placeholder="Bedroom Width"></asp:TextBox>
                                    <asp:Button ID="btnAddBedroom" runat="server" Text="Add" OnClick="btnAddBedroom_Click" formnovalidate="formnovalidate"/>
                                </div>
                                <div>
                                    <label>Bathrooms (<asp:Label ID="lblBRCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddBR" runat="server" OnClick="linkbtnAddBR_Click">Add a Bathroom</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblBathrooms" runat="server" Text=""></asp:Label>
                                <div id="divBRDimensions" runat="server" visible="false">
                                    <p>Bathroom Dimensions</p>
                                    <asp:TextBox ID="txtBRLength" runat="server" placeholder="Bathroom Length"></asp:TextBox>
                                    <span>by</span>
                                    <asp:TextBox ID="txtBRWidth" runat="server" placeholder="Bathroom Width"></asp:TextBox>
                                    <asp:Button ID="btnAddBR" runat="server" Text="Add" OnClick="btnAddBR_Click" formnovalidate="formnovalidate"/>
                                </div>
                                <div>
                                    <label>Other Rooms (<asp:Label ID="lblOtherRoomsCount" runat="server" Text="0"></asp:Label>)</label>
                                    <asp:LinkButton ID="linkbtnAddOtherRoom" runat="server" OnClick="linkbtnAddOtherRoom_Click">Add another Room</asp:LinkButton>
                                </div>
                                <asp:Label ID="lblOtherRooms" runat="server" Text=""></asp:Label>
                                <div id="divOtherRoomDimensions" runat="server" visible="false">
                                    <p>Room Dimensions</p>
                                    <asp:TextBox ID="txtRoomName" runat="server" placeholder="What kind of room is this"></asp:TextBox>
                                    <asp:TextBox ID="txtOtherRoomLength" runat="server" placeholder="Room Length"></asp:TextBox>
                                    <asp:TextBox ID="txtOtherRoomWidth" runat="server" placeholder="Room Width"></asp:TextBox>
                                    <asp:Button ID="btnAddOtherRoom" runat="server" Text="Add" OnClick="btnAddOtherRoom_Click" formnovalidate="formnovalidate"/>
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                </div>
                <div>
                    <label>Description About the Home</label>
                    <textarea id="taHomeDescription" cols="20" rows="5" placeholder="Comment about this home" runat="server"></textarea>
                    <label>Asking Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Set the Starter Price" required></asp:TextBox>
                </div>
                <div>
                    <p>Upload an Image for the Home</p>
                    <asp:FileUpload ID="fuHomeImg" runat="server" />
                    <label>Image Caption</label>
                    <asp:TextBox ID="txtImgCaption" runat="server" placeholder="Write a caption for this Image"></asp:TextBox>
                </div>
                <div>
                    <p>About the Seller / Homeowner</p>
                    <div id="divAgentInfo" runat="server" visible="false">
                        <label>Real Estate Agent Email</label>
                        <asp:TextBox ID="txtAgentEmail" runat="server" placeholder="Enter Real Estate Agent Email" required></asp:TextBox>
                        <label>Real Estate Company Name</label>
                        <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Enter Company Name"></asp:TextBox>
                    </div>
                    <div>
                        <p id="pCreateSeller" runat="server" visible="false">Create an account for the seller</p>
                        <label>Seller / Homeowner Email</label>
                        <asp:TextBox ID="txtSellerEmail" runat="server" placeholder="Enter Seller's Email" required></asp:TextBox>
                        <div id="divCreateSellerAcc" runat="server" visible="false">
                            <label>Seller Password</label>
                            <input id="sellerPassword" type="password" runat="server" placeholder="Enter a Password for the Seller" required/>
                            <label>Seller's Full Name</label>
                            <asp:TextBox ID="txtSellerName" runat="server" placeholder="Enter Seller's Full Name" required></asp:TextBox>
                            <label>Seller's Home Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Seller's Address" required></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="btnSubmitHome" runat="server" Text="Add Home for Sale" OnClick="btnSubmitHome_Click" />
    </form>
</body>
</html>
