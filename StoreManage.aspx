<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="StoreManage.aspx.cs" Inherits="StoreManage" %>
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
    <li class="btn-switch-cart switch-cart-0 current"><a href="#" class="J_MakePoint" data-point="tbcart.8.35"><em>商店管理</em></a></li>
    
    </ul>
    <div class="wrap-line"><div class="floater" style="width: 123px; left: -1px;"></div></div></div><div id="J_CartMain" class="cart-main"><div class="cart-table-th"><div class="wp"><div class="th th-chk"><div id="J_SelectAll1" class="select-all J_SelectAll"><div class="cart-checkbox"><input class="J_CheckBoxShop" id="J_SelectAllCbx1" type="checkbox" name="select-all" value="true"><label for="J_SelectAllCbx1">勾选Cart内所有商品</label></div>全选</div></div><div class="th th-item"><div class="td-inner">商店信息</div></div><div class="th th-info"><div class="td-inner">&nbsp;</div></div><div class="th th-price"><div class="td-inner">店主</div></div><div class="th th-amount"><div style=" margin-left:50px;" class="td-inner">地址</div></div><div class="th th-sum"><div class="td-inner"></div></div><div class="th th-op"   style=" margin-left:110px;"><div class="td-inner">操作</div></div></div></div>
        <asp:Repeater ID="rptProducts" runat="server" 
            onitemdatabound="rptProducts_ItemDataBound" 
            onitemcommand="rptProducts_ItemCommand" >
        <ItemTemplate>
            <asp:HiddenField ID="hiddenStoreId" Value='<%# Eval("StoreId")%>' runat="server" />
            <asp:HiddenField ID="hiddenStoreState" Value='<%# Eval("StoreState")%>' runat="server" />
            <div style=" font:15px;" id="J_OrderList" data-spm="1997196601"><div id="J_OrderHolder_s_2182942593_1" style="height: auto;"><div id="J_Order_s_2182942593_1" class="J_Order clearfix order-body  "><div class="J_ItemHead shop clearfix"><div class="shop-info"><div class="cart-checkbox "><input class="J_CheckBoxShop" id="J_CheckShop_s_2182942593_1" type="checkbox" name="orders[]" value="s_2182942593_1"><label for="J_CheckShop_s_2182942593_1">勾选此店铺下所有商品</label></div>
            &nbsp;&nbsp;<span style="font-weight: 700;font-family: verdana;" title='<%#Eval("StoreTime").ToString().Substring(0,15) %>'><%#Eval("StoreTime").ToString().Substring(0,9) %></span>&nbsp;&nbsp;商店编号：</b<a href="StoreDisplay.aspx?StoreId=<%# Eval("StoreId")%>" target="_self" title='<%#Eval("StoreId") %>' class="J_MakePoint" ><strong><%#Eval("StoreId")%></strong></a></div></div><div class="order-content"><div id="J_BundleList_s_2182942593_1" class="item-list"><div id="J_Bundle_s_2182942593_1_0" class="bundle  bundle-last "><div id="J_ItemHolder_109138212368"><div id="J_Item_109138212368" class="J_ItemBody item-body clearfix item-normal  first-item  last-item   "> <ul class="item-content clearfix"> <li class="td td-chk"> <div class="td-inner"><div class="cart-checkbox "><input class="J_CheckBoxItem" id="J_CheckBox_109138212368" type="checkbox" name="items[]" value="109138212368"><label for="J_CheckBox_109138212368">勾选商品</label></div></div> </li> <li class="td td-item"> <div class="td-inner"> 
            <div class="item-pic J_ItemPic img-loaded"><a href="StoreDisplay.aspx?StoreId=<%# Eval("StoreId")%>" target="_self" title='<%# Eval("StoreName")%>' class="J_MakePoint" data-point="tbcart.8.12"><img src="showStoreLogo.aspx?storeId=<%# Eval("StoreId")%>" class="itempic J_ItemImg"></a></div>
             <div style=" margin-top:30px;" class="item-info"> <div class="item-basic-info">
             <a href='StoreDisplay.aspx?StoreId=<%# Eval("StoreId")%>' target="_self" title='<%# Eval("StoreName")%>' class="item-title J_MakePoint" data-point="tbcart.8.11"><strong><%# Eval("StoreName")%></strong></a> </div> <div class="item-other-info">  <div class="promo-logos"></div>  </div> </div> </div> </li>
              <li style=" padding-left:180px;" class="td td-price">
               <div class="td-inner">
               <div class="item-price price-promo-"><div class="price-content">
             
             <div class="price-line">
             <em class="J_Price price-now" tabindex="0" style=" font-size:15px;">
                 <asp:Label ID="Pprice" runat="server" Text='<%# Eval("UserName")%>'></asp:Label><br />
              </em></div></div></div></div> </li> 
             <li class="td td-amount">
              <div class="td-inner">
              <div  style=" font-size:15px; font-weight:bold;" class="amount-wrapper ">
                  <asp:Label style=" padding-left:60px;"  ID="Stock" runat="server" Text='<%# Eval("StoreAddress")%>'></asp:Label><br />
                   
                   <asp:Label  style="font-size:12px;padding-left:40px;" ID="disapear" runat="server" Text=""></asp:Label>
                  
               </div>
             </div> </li>
             <li class="td td-sum">
              <div class="td-inner">
              
              <div class="J_ItemLottery"></div></div> </li>
              <li class="td td-op"> <div class="td-inner"  style=" margin-right:20px;">
              
              <asp:LinkButton  title="批准开店" class="btn-fav J_Fav J_MakePoint" CommandName="upMarket"  ID="agreeOpen" runat="server">批准开店</asp:LinkButton>
               <asp:LinkButton  title="取消批准" class="btn-fav J_Fav J_MakePoint" CommandName="downMarket"  ID="cancelOpen" runat="server">取消批准</asp:LinkButton>
              <asp:LinkButton  title="修改" class="btn-fav J_Fav J_MakePoint"  ID="modifyStore" runat="server">修改</asp:LinkButton>
                  <asp:LinkButton  title="删除" ID="delete" class="J_Del J_MakePoint" CommandName="deleteP" runat="server">删除</asp:LinkButton></div> </li></ul>  </div> </div></div></div></div></div> </div></div></div>
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
AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
PrevPageText="上一页" SubmitButtonText="Go" SubmitButtonClass="submitBtn" 
CustomInfoStyle="font-size:14px;text-align:left;" 
InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; " 
TextBeforeInputBox="转到第" TextAfterInputBox="页 " PageIndexBoxType="TextBox" 
ShowPageIndexBox="Always" TextAfterPageIndexBox="页" 
TextBeforePageIndexBox="转到" Font-Size="14px" CustomInfoHTML="" 
ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%" 
PagingButtonSpacing="3px" onpagechanged="AspNetPager1_PageChanged1" >
</webdiyer:AspNetPager>
    </div>

</div>
</asp:Content>

