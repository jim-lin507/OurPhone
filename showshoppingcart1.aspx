<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="showshoppingcart1.aspx.cs" Inherits="showshoppingcart2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="http://g.tbcdn.cn/tb/global/3.3.35/global-min.css">
    <!-- E GLOBAL JS -->
    <link href="css/cart-min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="loginForm" runat="server">
        <h1 style="color: #FF5500; font-weight: bold;" class="dib">Address</h1>
        <br />
        <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="address" runat="server" Text=""></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="color: #FF5500" target="_self" href="User_Edit.aspx">Edit Address</a>
        <!--<asp:RadioButtonList ID="RadioButtonList1" runat="server">
    </asp:RadioButtonList>-->
        <div style="">
            <div id="content" style="font-weight: bold; font-size: 13px;">
                <div class="cart-layout-TB">
                    <div id="J_Cart" class="cart">
                        <div id="J_FilterBar" class="cart-filter-bar">
                            <ul id="J_CartSwitch" class="switch-cart">
                                <li class="btn-switch-cart switch-cart-0 current"><a href="#" class="J_MakePoint" data-point="tbcart.8.35"><em>My Cart</em></a></li>

                            </ul>



                            <div class="wrap-line">
                                <div class="floater" style="width: 123px; left: -1px;"></div>
                            </div>
                        </div>
                        <div id="J_CartMain" class="cart-main">
                            <div class="cart-table-th">
                                <div class="wp">
                                    <div class="th th-chk">
                                        <div id="J_SelectAll1" class="select-all J_SelectAll">
                                            <div class="cart-checkbox">
                                                <input class="J_CheckBoxShop" id="J_SelectAllCbx1" type="checkbox" name="select-all" value="true"><label for="J_SelectAllCbx1">勾选Cart内所有商品</label></div>
                                            Select All</div>
                                    </div>
                                    <div class="th th-item">
                                        <div class="td-inner">Product</div>
                                    </div>
                                    <div class="th th-info">
                                        <div class="td-inner">&nbsp;</div>
                                    </div>
                                    <div class="th th-price">
                                        <div class="td-inner">Price</div>
                                    </div>
                                    <div class="th th-amount">
                                        <div class="td-inner">Quanlity</div>
                                    </div>
                                    <div class="th th-sum">
                                        <div class="td-inner">Total Amount</div>
                                    </div>
                                    <div class="th th-op">
                                        <div class="td-inner">Operation</div>
                                    </div>
                                </div>
                            </div>
                            <asp:Repeater ID="rpShoppingCart" runat="server"
                                OnItemDataBound="rpShoppingCart_ItemDataBound" OnItemCreated="rpShoppingCart_ItemCreated">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hiddenStoreId" Value='<%# Eval("StoreId")%>' runat="server" />
                                    <div style="font: 15px;" id="J_OrderList" data-spm="1997196601">
                                        <div id="J_OrderHolder_s_2182942593_1" style="height: auto;">

                                            <div id="J_Order_s_2182942593_1" class="J_Order clearfix order-body  ">
                                                <div class="J_ItemHead shop clearfix">
                                                    <div class="shop-info">
                                                        <div class="cart-checkbox ">
                                                            <input class="J_CheckBoxShop" id="J_CheckShop_s_2182942593_1" type="checkbox" name="orders[]" value="s_2182942593_1"><label for="J_CheckShop_s_2182942593_1">勾选此店铺下所有商品</label></div>
                                                        &nbsp;&nbsp;Store Name:<a href='StoreDisplay.aspx?storeId=<%# Eval("StoreId")%>' target="_self" title='<%#Eval("StoreName") %>' class="J_MakePoint"><strong><%#Eval("StoreName") %></strong></a>&nbsp;&nbsp;Store Owner:<a href="#" target="_self" title='<%#Eval("UserName") %>' class="J_MakePoint"><strong><%#Eval("Username") %></strong></a></div>
                                                </div>
                                                <asp:Repeater ID="rpProduct" runat="server">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hiddenProductId" Value='<%# Eval("ProductId")%>' runat="server" />
                                                        <asp:HiddenField ID="hiddenStoreId2" Value='<%# Eval("StoreId")%>' runat="server" />
                                                        <asp:HiddenField ID="hiddenProductStock" Value='<%# Eval("Stock")%>' runat="server" />
                                                        <asp:HiddenField ID="hiddenProductState" Value='<%# Eval("ProductState")%>' runat="server" />
                                                        <div class="order-content">
                                                            <div id="J_BundleList_s_2182942593_1" class="item-list">
                                                                <div id="J_Bundle_s_2182942593_1_0" class="bundle  bundle-last ">
                                                                    <div id="J_ItemHolder_109138212368">
                                                                        <div id="J_Item_109138212368" class="J_ItemBody item-body clearfix item-normal  first-item  last-item   ">
                                                                            <ul class="item-content clearfix">
                                                                                <li class="td td-chk">
                                                                                    <div class="td-inner">
                                                                                        <div class="cart-checkbox ">
                                                                                            <input class="J_CheckBoxItem" id="J_CheckBox_109138212368" type="checkbox" name="items[]" value="109138212368"><label for="J_CheckBox_109138212368">勾选商品</label></div>
                                                                                    </div>
                                                                                </li>
                                                                                <li class="td td-item">
                                                                                    <div class="td-inner">
                                                                                        <div class="item-pic J_ItemPic img-loaded"><a href="infodetail.aspx?productid=<%# Eval("ProductId")%>" target="_self" title='<%# Eval("Name")%>' class="J_MakePoint" data-point="tbcart.8.12">
                                                                                            <img src="showProductPicture.aspx?productid=<%# Eval("ProductId")%>" class="itempic J_ItemImg"></a></div>
                                                                                        <div style="margin-top: 30px;" class="item-info">
                                                                                            <div class="item-basic-info">
                                                                                                <a href='infodetail.aspx?productid=<%# Eval("ProductId")%>' target="_self" title='<%# Eval("Name")%>' class="item-title J_MakePoint" data-point="tbcart.8.11"><strong><%# Eval("Name")%></strong></a>
                                                                                            </div>
                                                                                            <div class="item-other-info">
                                                                                                <div class="promo-logos"></div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </li>
                                                                                <li class="td td-info">
                                                                                    <div class="item-props item-props-can">
                                                                                        <p class="sku-line" tabindex="0">Screen:<%# Eval("Size")%>inches</p>
                                                                                        <p class="sku-line" tabindex="0">Operating System:<%# Eval("OperatingSystem")%></p>
                                                                                        <p class="sku-line" tabindex="0">Resolution:<%# Eval("Pixel")%></p>
                                                                                        <%--<p class="sku-line" tabindex="0">网络类型：<%# Eval("NetworkType")%></p>--%></div>
                                                                                </li>
                                                                                <li class="td td-price">
                                                                                    <div class="td-inner">
                                                                                        <div class="item-price price-promo-">
                                                                                            <div class="price-content">
                                                                                                <div class="price-line">
                                                                                                    <em class="J_Price price-now" tabindex="0" style="font-size: 15px;">
                                                                                                        <asp:Label ID="Pprice" runat="server" Text='<%# Eval("Price")%>'></asp:Label><br />
                                                                                                        <asp:Label ID="BargainPrice" runat="server" Text='<%# Eval("BargainPrice")%>'></asp:Label>
                                                                                                    </em>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </li>
                                                                                <li class="td td-amount">
                                                                                    <div class="td-inner">
                                                                                        <div class="amount-wrapper ">
                                                                                            <div class="item-amount ">
                                                                                                <asp:LinkButton CommandName="minusP" class="J_Minus minus" ID="minus" runat="server">-</asp:LinkButton>
                                                                                                <asp:TextBox AutoPostBack="true" Height="15px" class="text text-amount J_ItemAmount" ID="productNum" Text='<%# Eval("ProductNum")%>' runat="server"></asp:TextBox>
                                                                                                <asp:LinkButton CommandName="plusP" class="J_Plus plus" ID="plus" runat="server">+</asp:LinkButton>
                                                                                            </div>
                                                                                            <div style="margin-left: 15px; color: #f40;" class="amount-msg J_AmountMsg">
                                                                                                <asp:Label ID="productStock" runat="server" Visible="false" Text="Stock is not enough"></asp:Label>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </li>
                                                                                <li class="td td-sum">
                                                                                    <div class="td-inner">
                                                                                        <em tabindex="0" class="J_ItemSum number">
                                                                                            <asp:Label ID="productPrice" runat="server" Text="1000"></asp:Label>
                                                                                        </em>
                                                                                        <div class="J_ItemLottery"></div>
                                                                                    </div>
                                                                                </li>
                                                                                <li class="td td-op">
                                                                                    <div class="td-inner">
                                                                                        <asp:LinkButton ID="addWishList" CommandName="addWishListP" runat="server" title="Add To Watchlist" class="btn-fav J_Fav J_MakePoint">Add To Watchlist</asp:LinkButton>
                                                                                        <asp:LinkButton ID="delete" class="J_Del J_MakePoint" CommandName="deleteP" title="Delete" runat="server">Delete</asp:LinkButton>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:Repeater>



                                            </div>
                                        </div>
                                    </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                            <div id="J_FloatBarHolder" style="font-size: 10px;" class="float-bar-holder">
                                <div id="J_FloatBar" class="float-bar clearfix default" style="position: static;">
                                    <div id="J_SelectedItems" class="group-wrapper group-popup hidden" style="display: none;">
                                        <div id="J_SelectedItemsList" class="group-content"></div>
                                        <span class="arrow" style="left: 674px;"></span>
                                    </div>


                                    <div class="float-bar-wrapper">
                                        <div id="J_SelectAll2" class="select-all J_SelectAll">
                                            <div class="cart-checkbox">
                                            </div>
                                        </div>
                                        <div class="operations"><a href="#" hidefocus="true" class="J_ClearInvalid hidden"></a></div>
                                        <div class="float-bar-right">
                                            <!--<div id="J_ShowSelectedItems" class="amount-sum"><span class="txt">已选商品</span><em id="J_SelectedItemsCount">0</em><span class="txt">件</span><div class="arrow-box"><span class="selected-items-arrow"></span><span class="arrow"></span></div></div>-->
                                            <div id="J_CheckCOD" class="check-cod" style="display: none;"><span class="icon-cod"></span><span class="s-checkbox J_CheckCOD"></span>货到付款</div>
                                            <div class="pipe"></div>

                                            <div class="price-sum"style="font-size: 24px;font-weight:bold;">
                                                <span class="txt">Balance:</span><strong class="price"><em id="Em1">
                                                    <asp:Label ID="balance" runat="server" Text="0"></asp:Label></em></strong><span style="padding-left: 20px;" class="txt">Total:</span><strong class="price"><em id="J_Total">
                                                        <asp:Label ID="totalPrice" runat="server" Text="0"></asp:Label></em></strong>
                                            </div>
                                            <div class="btn-area" style="padding-left:10px;padding-right:10px;">
                                                <asp:LinkButton ID="submitShoppingCart" class="submit-btn" runat="server"
                                                    OnClick="submitShoppingCart_Click"><span>Check Out</span></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div runat="server" id="shopCart">
        <li style="padding-left: 120px;">Balance:
            <asp:Label ID="emptyBalance" Style="color: #f40; font-size: 14px; font-weight: bolder;" runat="server" Text=""></asp:Label>
        </li>
        <div style="float: left">

            <img title="" border="0" alt="" src="./images/shopCart.jpg" />
        </div>
        <div style="float: left; padding-top: 60px; padding-bottom: 80px;">
            <h8><b>Your cart is still empty!</b></h8>
            <ul>
                <li>Look At <a style="color: Blue; font-size: 14px;" href="WishList.aspx" target="_self">My Watchlist</a></li>
                <li>Look At <a style="color: Blue; font-size: 14px;" href="product_buy.aspx" target="_self">Purchased Products</a></li>

            </ul>
        </div>
    </div>

</asp:Content>

