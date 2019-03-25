<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="product_modify.aspx.cs" Inherits="product_modify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- S GLOBAL CSS -->
    <link href="css/publish-min.css" rel="stylesheet" />
    <script src="script/jquery-1.3.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="registerForm" runat="server">

        <div id="Div2">
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="title">
                    <strong>Product ID：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap">
                        <asp:Label ID="ProductId" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>


        </div>

        <div id="form-bd">
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="title">
                    <strong>Product Name：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap">
                        <input runat="server" id="ProductName" type="text" class="input title" name="ProductName" value="" />
                    </div>
                </div>
            </div>


        </div>

        <div id="J_Price">
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="price">
                    <strong>Price：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        $<input runat="server" id="ProductPrice" type="text" class="input J_PriceCheck" name="ProductPrice" value="" />
                    </div>
                </div>
            </div>
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="price">
                    <strong>Bargain Price：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        $<input runat="server" id="BargainPrice" type="text" class="input J_PriceCheck" name="ProductPrice" value="" />
                    </div>
                </div>
            </div>
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="price">
                    <strong>Quanlity：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        <input id="ProductNum" runat="server" type="text" class="input J_PriceCheck" name="ProductNum" value="" />
                    </div>
                </div>
            </div>
            <%--<div id="Div1">
                <div style="padding-left: 110px;" class="control-group ">
                    <label class="control-label" for="title">
                        <strong>Product Speciality：</strong>
                    </label>
                    <div class="controls">
                        <div class="input-wrap">
                            <input id="ProductSpeciality" runat="server" type="text" class="input title" name="ProductSpeciality" value="" />
                        </div>
                    </div>
                </div>


            </div>--%>



            <div style="padding-left: 110px;" id="J_FreightGroup" class=" control-group ">
                <label class="control-label" for="freight">
                    <strong>Model Year：</strong>
                </label>
                <div class="controls">
                    <div class="input-prepend">
                        <asp:DropDownList Style="width: 80px;" ID="MarketTimeYear" runat="server">
                        </asp:DropDownList>
                        <%--<asp:DropDownList style=" width:60px;" ID="MarketTimeMonth" runat="server">
            </asp:DropDownList>
            <asp:DropDownList style=" width:60px;" ID="MarketTimeDay" runat="server">
            </asp:DropDownList>--%>
                    </div>
                </div>
            </div>
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="mobile">
                    <strong>Screen：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        <input id="Size" runat="server" type="text" class="input J_PriceCheck" name="Size" value="" />inches
                    </div>
                </div>
            </div>
           <%-- <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="mobile">
                    <strong>Core：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        <input id="CoreNumber" runat="server" type="text" class="input J_PriceCheck" name="CoreNumber" value="" />核
                    </div>
                </div>
            </div>--%>
            <div style="padding-left: 110px;" class="control-group ">
                <label class="control-label" for="mobile">
                    <strong>Resolution：</strong>
                </label>
                <div class="controls">
                    <div class="input-wrap input-append">
                        <input id="Pixel" runat="server" type="text" class="input J_PriceCheck" name="Pixel" value="" />
                    </div>
                </div>
            </div>
        </div>


        <div style="padding-left: 110px;" class="control-group location-group ">
            <label class="control-label">
                <strong>Operating System：</strong>
            </label>
            <div>
                <asp:DropDownList Style="width: 130px;" ID="OperatingSystem2" runat="server">
                </asp:DropDownList>
                <a style="color: Red;" href="CategoryManager.aspx">Categories Management</a>
            </div>
        </div>
        <%-- <div    style="padding-left:110px;" class="control-group location-group ">
    <label class="control-label">
        <strong>Network：</strong>
    </label>
    <div>
	       <asp:DropDownList  style=" width:130px;" ID="NetworkType1" runat="server">
        </asp:DropDownList>                   				        
    </div>
</div>--%>
        <div style="padding-left: 110px;" class="control-group">
            <label class="control-label" for="pic">
                <strong>Product Image：</strong>
            </label>
            <div class="controls">

                <input type="file" onpropertychange="document.all.myimg.src='file:///'+this.value" id="uploadFile" runat="server" name="uploadFile" />
            </div>
            <div align="left">
                <img id="myimg" runat="server" height="100" src="images\showimg.gif" width="100" border="0" /></div>
            <span class="upload-tip">Best 200*200</span>
        </div>
    </div>



    <div class="control-group">
        <div class="controls">
            <asp:Button ID="submit_update" class="btn btn-green btn-publish"
                Style="background-color: Green;" runat="server" Text="Edit"
                OnClick="submit_update_Click" />
        </div>
    </div>
    </div>
        </div>

</asp:Content>

