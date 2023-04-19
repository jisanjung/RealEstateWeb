﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSearch.aspx.cs" Inherits="RealEstateWeb.frmSearch" %>
<%@ Register Src="~/Navbar.ascx" TagPrefix="uc" TagName="Navbar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div id="divHomeProfile" runat="server" visible="false">
                    <div>
                        <asp:Label ID="lblHomeProfileHomeId" runat="server"></asp:Label>
                    </div>
                    <div>
                        <img id="imgHomeProfile" runat="server" style="max-width: 200px;" />
                    </div>
                    <div>
                        <asp:Label ID="lblHomeProfilePrice" runat="server"></asp:Label>
                        <div>
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
                    <asp:Button ID="btnRequestShowing" runat="server" Text="Request a Showing" OnClick="btnRequestShowing_Click" />
                    <asp:Button ID="btnFeedback" runat="server" Text="Leave Feedback" OnClick="btnFeedback_Click" />
                    <div id="divCreateShowing" runat="server" visible="false">
                        <div>
                            <label>Home Showing Date</label>
                            <asp:TextBox ID="txtShowingDate" runat="server" placeholder="Enter desired date"></asp:TextBox>
                        </div>
                        <div>
                            <label>Home Showing Time</label>
                            <asp:TextBox ID="txtShowingTime" runat="server" placeholder="Enter desired time"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmitShowing" runat="server" Text="Submit Showing Request" OnClick="btnSubmitShowing_Click" />
                        <asp:Label ID="lblHomeShowingAlert" runat="server"></asp:Label>
                    </div>
                    <div id="divLeaveFeedback" runat="server" visible="false">
                        <div>
                            <label>What are your thoughts on the price?</label>
                            <asp:DropDownList ID="ddlPriceFeedback" runat="server">
                                <asp:ListItem>Perfect</asp:ListItem>
                                <asp:ListItem>Okay</asp:ListItem>
                                <asp:ListItem>Too High</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <label>What are your thoughts on the location?</label>
                            <asp:DropDownList ID="ddlLocationFeedback" runat="server">
                                <asp:ListItem>Love it</asp:ListItem>
                                <asp:ListItem>Not bad</asp:ListItem>
                                <asp:ListItem>Terrible</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>
                            <label>Please comment on anything else about this home</label>
                            <textarea id="taOverallFeedback" cols="20" rows="5" placeholder="Overall feedback..." runat="server"></textarea>
                        </div>
                        <div>
                            <label>Rate this home</label>
                            <asp:DropDownList ID="ddlRating" runat="server">
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:Button ID="btnSubmitFeedback" runat="server" Text="Submit Feedback" OnClick="btnSubmitFeedback_Click" />
                        <asp:Label ID="lblFeedbackAlert" runat="server"></asp:Label>
                    </div>
                    <div>
                        <div>
                            <asp:Label ID="lblHomeProfilePropertyType" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileYearBuilt" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileAmenities" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileHVAC" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileGarage" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileUtilities" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileDescription" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblHomeProfileRoomDimensions" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="lblHomeProfileAgentEmail" runat="server"></asp:Label>
                        <asp:Label ID="lblHomeProfileAgentInfo" runat="server"></asp:Label>
                    </div>
                    <asp:LinkButton ID="linkbtnMakeOffer" runat="server" OnClick="linkbtnMakeOffer_Click">Make an Offer</asp:LinkButton>
                    <div id="divMakeOffer" runat="server" visible="false">
                        <div>
                            <label>Type of Sale</label>
                            <asp:DropDownList ID="ddlSaleType" runat="server">
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
                        <div>
                            <asp:CheckBox ID="chkSellHomeFirst" runat="server" Text="Do you need sell your home first?" />
                        </div>
                        <div>
                            <label>Move-in Date</label>
                            <asp:TextBox ID="txtMoveinDate" runat="server" placeholder="Enter when you'd like to move in"></asp:TextBox>
                        </div>
                        <div>
                            <label>Offer Amount</label>
                            <asp:TextBox ID="txtOfferAmount" runat="server" placeholder="Enter your Offer Amount"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmitOffer" runat="server" Text="Submit Offer" OnClick="btnSubmitOffer_Click" />
                        <asp:Label ID="lblOfferAlert" runat="server"></asp:Label>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<uc:Navbar runat="server" id="navbar"/>--%>
        <h1>Search</h1>
        <div id="sideFilter">
            <asp:Label ID="lblSearchAlert" runat="server"></asp:Label>
            <div>
                <label>Location</label>
                <asp:TextBox ID="txtZipCode" runat="server" placeholder="Enter Zip Code"></asp:TextBox>
            </div>
            <div>
                <label>Price Range</label>
                <asp:TextBox ID="txtPriceRange" runat="server" placeholder="Enter Target Price"></asp:TextBox> 
                <span>(and under)</span>
            </div>
            <div>
                <label>Property Type</label>
                <asp:DropDownList ID="ddlPropertyType" runat="server">
                    <asp:ListItem>Any</asp:ListItem>
                    <asp:ListItem>Single Family</asp:ListItem>
                    <asp:ListItem>Multi Family</asp:ListItem>
                    <asp:ListItem>Condo</asp:ListItem>
                    <asp:ListItem>Townhouse</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label>House Size</label>
                <asp:TextBox ID="txtHomeSize" runat="server" placeholder="Enter house size"></asp:TextBox>
                <span>sqft (and under)</span>
            </div>
            <div>
                <label>Bedrooms</label>
                <asp:TextBox ID="txtMinBedrooms" runat="server" placeholder="Minimum Bedrooms"></asp:TextBox>
            </div>
            <div>
                <label>Bathrooms</label>
                <asp:TextBox ID="txtMinBathrooms" runat="server" placeholder="Mininum Bathrooms"></asp:TextBox>
            </div>
            <div>
                <label>Amenities</label>
                <asp:CheckBoxList ID="cblAmenities" runat="server">
                    <asp:ListItem>Fireplace</asp:ListItem>
                    <asp:ListItem>Pool</asp:ListItem>
                    <asp:ListItem>Hot Tub</asp:ListItem>
                    <asp:ListItem>Garden</asp:ListItem>
                    <asp:ListItem>Bar</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
        <div id="homeResults">
            <table>
                <asp:Repeater ID="rptHomeResults" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="lblHomeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HomeId")%>'></asp:Label>
                                <div>
                                    <asp:Image ID="imgHome" runat="server" ImageUrl='<%#"~/Storage/"+Eval("Img") %>'  Width="200" Height="200"/>
                                 </div>
                                <div>
                                    <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblHouseSize" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HouseSize")%>'></asp:Label>
                                    <span> | </span>
                                    <asp:Label ID="lblNumberBed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberBed")%>'></asp:Label>
                                    <span> | </span>
                                    <asp:Label ID="lblNumberBath" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NumberBath")%>'></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label>
                                    <span> </span>
                                    <asp:Label ID="lblZipCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ZipCode")%>'></asp:Label>
                                </div>
                                <asp:Button ID="btnViewHome" runat="server" Text="View" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_ViewHome"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>