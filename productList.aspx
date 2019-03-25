<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="productList.aspx.cs" Inherits="productList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="http://g.tbcdn.cn/tb/global/3.3.35/global-min.css" />
    <link href="css/vertical.css" rel="stylesheet" />
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style=" font-size:12px;" class="tb-wrapper-main">
<div class="tb-crumbs">
<div class="bread-crumbs row">
<div class="col crumbs-cont">
All Categories<span class="cat-divider"><span class="icon-btn-vbarrow"></span></span><span class="cat-name">Phone</span><span class="cat-divider"><span class="icon-btn-vbarrow"></span></span>

 <%=GetInfoShoppingCart() %>

</div>

<div class="col end"><span class="product-num">Total Amount:<span class="highlight">
<asp:Label ID="productNumber" runat="server"   Text="0"></asp:Label></span></span>
<!--<a class="product-num highlight" href="">查看全部相关宝贝</a><a class="nav-toggle-btn J_navSwitchBtn icon-tag" href="javascript:;"><span class="icon-btn-arrow-up-3"></span>
</a>-->
</div>
</div>
</div>


<div class="tb-navigation" style="display: block;"><div class="navigation">
<div class="nav-panel">

    <asp:Repeater ID="rpt" runat="server" onitemdatabound="rpt_ItemDataBound">
        <ItemTemplate>
            <asp:Label ID="lbTypeId" runat="server" Text='<%#Eval("TypeId") %>' Visible="false"></asp:Label>
            <div class="nav-block J_commonNav0 type-text">
<div class="block-head">

<h4><span class="nav-title"><%#Eval("TypeName") %></span>:</h4>

</div>

<div class="block-body ">
<div class="params-cont">

    <asp:Repeater ID="rptSmallType" runat="server">
        <ItemTemplate>
            <a target="_self" trace="spuNavProperty" title="<%#Eval("SmallTypeName") %>" class="param-item icon-tag J_navBtn " href="productList.aspx?smallTypeId=<%#Eval("SmallTypeId") %>&operate=add">
            <span class="icon-btn-check-small param-checkbox"></span><%#Eval("SmallTypeName") %>
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>
</div>

<!--<div class="multi-btn-cont">
<a trace="navMutiSelect" href="javascript:;" class="submit-btn J_submitBtn">
确定</a><a href="javascript:;" class="cancel-btn J_cancelBtn">取消</a></div></div>
<div class="block-tail"><a href="javascript:;" class="multi-btn J_multiBtn">多选</a>
<a href="javascript:;" style="display: none;" class="more-btn J_expandBtn">更多<span class="icon-btn-arrow-down-2"></span></a>
</div>
</div>-->

        </ItemTemplate>
    </asp:Repeater>
</div>




<div class="tb-sortbar" style=" padding-top:20px;">
<div class="sortbar">
<div class="container">
<div class="sortbar-panel row">
<div class="sortpanel col row">
<div class="sort-item col J_sortItem sort-item-active first-sort-item">
<a href="#" class="sort-a async-btn" title="Results"><span class="text">Results</span></a>
</div>
<!--<div class="sort-item col J_sortItem  ">
<a href="" class="sort-a async-btn" title="最近上市的产品在前"><span class="text">上市时间</span></a>
</div>
<div class="sort-item col J_sortItem">
<a href="" class="sort-a async-btn" title="价格较高的产品在前"><span class="text">价格从高到低</span></a>
</div>
<div class="sort-item col J_sortItem">
<a href="" class="sort-a async-btn" title="价格较低的产品在前"><span class="text">价格从低到高</span></a>
</div>
</div>-->

<div class="col end style-btns row">
</div>
</div>
<a title="取消浮动跟随" class="J_fixedBtn fix-btn" href="javascript:;"><span class="icon-btn-x-round"></span></a>
</div>
</div>
</div>


<div class="tb-baobei" style=" padding-bottom:20px;">


<div class="vbaobei-four row m-vgrid">


    <asp:Repeater ID="reProductList" runat="server">
        <ItemTemplate>
            <div style=" padding-left:10px;" class="grid-item col">
<div class="grid-panel">
<div class="img-box">
<a  href='infodetail.aspx?productid=<%# Eval("ProductId")%>'  title="<%#Eval("Name") %>" target="_self"><img src="showProductPicture.aspx?productid=<%# Eval("ProductId")%>"  alt="<%#Eval("Name") %>" style="height: 100%; padding: 0px 12%;"></a>
</div>
<div  align="center" class="info-cont">
<div class="title-row ">
<a class="product-title"  title="<%#Eval("Name") %>" href='infodetail.aspx?productid=<%# Eval("ProductId")%>' target="_self"><%#Eval("Name") %></a>
<br />
<span class="price-sign" style="color: #a10101;">¥<%#Eval("Price") %></span></div>
</div>
</div>
</div>
        </ItemTemplate>
    </asp:Repeater>

<div style=" padding-top:20px;" runat="server" id="noExist" visible="false"    align="center"><span style=" color:Red; font-weight:bolder;font-size:20px;">No products</span></div>

    </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>

