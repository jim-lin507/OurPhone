<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="HotStatistics.aspx.cs" Inherits="HotStatistics" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

 <link href="css/cart-min.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="form1" runat="server">
<div>
   
    <div id="content"  style=" font-size:10px;">
     <div class="cart-layout-TB">
    <div id="J_Cart" class="cart"><div id="J_FilterBar" class="cart-filter-bar">
    <ul id="J_CartSwitch" class="switch-cart">
    <li class="btn-switch-cart switch-cart-0 current"><a runat="server" id="sale" style=" text-decoration:none;" href="product_sale.aspx" class="J_MakePoint" data-point="tbcart.8.35"><em>Selled Products</em></a></li>
    <li class="btn-switch-cart switch-cart-0 current"><a style=" text-decoration:none;" href="HotStatistics.aspx" class="J_MakePoint" data-point="tbcart.8.35"><em>Hot Products</em></a></li>
    </ul>
    <div class="wrap-line"><div class="floater" style="width: 123px; left: -1px;"></div></div></div><div id="J_CartMain" class="cart-main"><div class="cart-table-th"><div class="wp"><div class="th th-chk"><div id="J_SelectAll1" class="select-all J_SelectAll"><div class="cart-checkbox"><input class="J_CheckBoxShop" id="J_SelectAllCbx1" type="checkbox" name="select-all" value="true"><label for="J_SelectAllCbx1"></label></div>Select All</div></div><div class="th th-item"><div class="td-inner">Product</div></div><div class="th th-info"><div class="td-inner">&nbsp;</div></div><div class="th th-price"><div class="td-inner">Price</div></div><div class="th th-amount"><div style=" margin-left:50px;" class="td-inner">Quanlity</div></div><div class="th th-sum"><div class="td-inner"></div></div><div class="th th-op"   style=" padding-left:90px; width:120px;"><div class="td-inner">Total Amount</div></div></div></div>
        <asp:Repeater ID="rptProducts" runat="server" onitemdatabound="rptProducts_ItemDataBound" >
        <ItemTemplate>
            <asp:HiddenField ID="hiddenPrice" Value='<%# Eval("Price")%>' runat="server" />
            <asp:HiddenField ID="hiddenQuantity" Value='<%# Eval("Quantity")%>' runat="server" />
            <div style=" font:15px;" id="J_OrderList" data-spm="1997196601"><div id="J_OrderHolder_s_2182942593_1" style="height: auto;"><div id="J_Order_s_2182942593_1" class="J_Order clearfix order-body  "><div class="J_ItemHead shop clearfix"><div class="shop-info"><div class="cart-checkbox "><input class="J_CheckBoxShop" id="J_CheckShop_s_2182942593_1" type="checkbox" name="orders[]" value="s_2182942593_1"><label for="J_CheckShop_s_2182942593_1"></label></div>
            &nbsp;&nbsp;Product ID:</b<a href="infodetail.aspx?productId=<%# Eval("ProductId")%>" target="_self" title='<%#Eval("ProductId") %>' class="J_MakePoint" ><strong><%#Eval("ProductId")%></strong></a></div></div><div class="order-content"><div id="J_BundleList_s_2182942593_1" class="item-list"><div id="J_Bundle_s_2182942593_1_0" class="bundle  bundle-last "><div id="J_ItemHolder_109138212368"><div id="J_Item_109138212368" class="J_ItemBody item-body clearfix item-normal  first-item  last-item   "> <ul class="item-content clearfix"> <li class="td td-chk"> <div class="td-inner"><div class="cart-checkbox "><input class="J_CheckBoxItem" id="J_CheckBox_109138212368" type="checkbox" name="items[]" value="109138212368"><label for="J_CheckBox_109138212368"></label></div></div> </li> <li class="td td-item"> <div class="td-inner"> <div class="item-pic J_ItemPic img-loaded"><a href="infodetail.aspx?productid=<%# Eval("ProductId")%>" target="_self" title='<%# Eval("Name")%>' class="J_MakePoint" data-point="tbcart.8.12"><img src="showProductPicture.aspx?productid=<%# Eval("ProductId")%>" class="itempic J_ItemImg"></a></div>
             <div style=" margin-top:30px;" class="item-info"> <div class="item-basic-info">
             <a href='infodetail.aspx?productid=<%# Eval("ProductId")%>' target="_self" title='<%# Eval("Name")%>' class="item-title J_MakePoint" data-point="tbcart.8.11"><strong><%# Eval("Name")%></strong></a> </div> <div class="item-other-info">  <div class="promo-logos"></div>  </div> </div> </div> </li>

              <li style=" padding-left:197px;" class="td td-price">
               <div class="td-inner">
               <div class="item-price price-promo-">
              <div class="price-content">
             
             <div class="price-line">
             <em class="J_Price price-now" tabindex="0" style=" font-size:15px;">
                 <asp:Label ID="Pprice" runat="server" Text='<%# Eval("Price")%>'></asp:Label><br />
                 <asp:Label ID="BargainPrice" runat="server" Text='<%# Eval("BargainPrice")%>'></asp:Label>
              </em></div></div></div></div> </li> 
             <li class="td td-amount">
              <div class="td-inner">
              <div  style=" font-size:15px; font-weight:bold;color: #f40;" class="amount-wrapper ">
                  <asp:Label style=" padding-left:60px;"  ID="Stock" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label><br />
                   
                   <asp:Label  style="font-size:12px;padding-left:40px;" ID="disapear" runat="server" Text=""></asp:Label>
                  
               </div>
             </div> </li>
             <li class="td td-sum">
              <div class="td-inner">
              
              <div class="J_ItemLottery"></div></div> </li>
              <li class="td td-op"> <div class="td-inner"  style=" margin-right:20px;">
                  <asp:Label style=" font-size:15px; font-weight:bold;color: #f40;" class="btn-fav J_Fav J_MakePoint" ID="lbTotalPrice" runat="server" Text=""></asp:Label>
              <!--<a  title="修改" class="btn-fav J_Fav J_MakePoint" href="product_modify.aspx?productId=<%# Eval("ProductId")%>"  id="modifyProduct">修改</a>-->
                </div> </li></ul>  </div> </div></div></div></div></div> </div></div></div>
        </ItemTemplate>
        </asp:Repeater>

    <div id="J_FloatBarHolder"  style=" font-size:10px;" class="float-bar-holder">
    <div id="J_FloatBar" class="float-bar clearfix default" style="position: static;">
    <div id="J_SelectedItems" class="group-wrapper group-popup hidden" style="display: none;">
    <div id="J_SelectedItemsList" class="group-content"></div><span class="arrow" style="left: 674px;"></span>
    </div>
    
    
     </div></div>
    </div>
       </div> 
     </div>
     </div>
     </div>
     <div  align="center">
     <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                HorizontalAlign="Center" Width="100%" 
meta:resourceKey="AspNetPager1" Style="font-size: 14px; padding-left:200px;" 
AlwaysShow="false" FirstPageText="Home" LastPageText="End" NextPageText="Next" 
PrevPageText="Previous" SubmitButtonText="Go" SubmitButtonClass="submitBtn" 
CustomInfoStyle="font-size:14px;text-align:left;" 
InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; " 
TextBeforeInputBox="Go to" TextAfterInputBox="Page " PageIndexBoxType="TextBox" 
ShowPageIndexBox="Always" TextAfterPageIndexBox="Page" 
TextBeforePageIndexBox="Go to" Font-Size="14px" CustomInfoHTML="" 
ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%" 
PagingButtonSpacing="3px" onpagechanged="AspNetPager1_PageChanged1" >
</webdiyer:AspNetPager>
    </div>

</div>

</asp:Content>

