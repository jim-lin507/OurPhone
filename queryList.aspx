﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="queryList.aspx.cs" Inherits="QueryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="http://g.tbcdn.cn/tb/global/3.3.35/global-min.css" />
 <link charset="utf-8" rel="stylesheet" href="http://g.tbcdn.cn/tb/??srpbase/0.16.0/beta.css,spusearch/1.20.0/vertical.css" />    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style=" font-size:12px;" class="tb-wrapper-main"><div class="tb-crumbs"><div class="bread-crumbs row"><div class="col crumbs-cont"><a class="cat-name" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;v=auction&amp;s=0&amp;vlist=1&amp;cd=false">所有分类</a><span class="cat-divider"><span class="icon-btn-vbarrow"></span></span><span class="cat-name">手机</span><span class="cat-divider"><span class="icon-btn-vbarrow"></span></span><a class="param-selected icon-tag async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=446:569740385" title="品牌：苹果">品牌：苹果<span class="close-icon icon-btn-x">X</span></a><a class="param-selected icon-tag async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420" title="尺寸：3.0-3.9英寸">尺寸：3.0-3.9英寸<span class="close-icon icon-btn-x">X</span></a></div><div class="col end"><span class="product-num">共<span class="highlight">5</span>款产品</span><a class="product-num highlight" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;v=auction&amp;s=0&amp;vlist=1&amp;cd=false&amp;cat=1512">查看全部相关宝贝</a><a class="nav-toggle-btn J_navSwitchBtn icon-tag" href="javascript:;"><span class="icon-btn-arrow-up-3"></span></a></div></div></div><div class="tb-navigation" style="display: block;"><div class="navigation"><div class="nav-panel"><div class="nav-block J_commonNav0 type-text"><div class="block-head"><h4><span class="nav-title">网络类型</span>:</h4></div><div class="block-body "><div class="params-cont"><a target="_self" trace="spuNavProperty" title="联通3G(WCDMA)" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;10004:477624623" data-ppath="10004:477624623"><span class="icon-btn-check-small param-checkbox"></span>联通3G(WCDMA)</a><a target="_self" trace="spuNavProperty" title="电信3G(CDMA2000)" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;10004:569614899" data-ppath="10004:569614899"><span class="icon-btn-check-small param-checkbox"></span>电信3G(CDMA2000)</a><a target="_self" trace="spuNavProperty" title="电信2G(CDMA)" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;10004:569614930" data-ppath="10004:569614930"><span class="icon-btn-check-small param-checkbox"></span>电信2G(CDMA)</a><a target="_self" trace="spuNavProperty" title="移动2G/联通2G(GSM)" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;10004:292404871" data-ppath="10004:292404871"><span class="icon-btn-check-small param-checkbox"></span>移动2G/联通2G(GSM)</a></div><div class="multi-btn-cont"><a trace="navMutiSelect" href="javascript:;" class="submit-btn J_submitBtn">确定</a><a href="javascript:;" class="cancel-btn J_cancelBtn">取消</a></div></div><div class="block-tail"><a href="javascript:;" class="multi-btn J_multiBtn">多选</a><a href="javascript:;" style="display: none;" class="more-btn J_expandBtn">更多<span class="icon-btn-arrow-down-2"></span></a></div></div><div class="nav-block J_commonNav1 type-text"><div class="block-head"><h4><span class="nav-title">像素</span>:</h4></div><div class="block-body "><div class="params-cont"><a target="_self" trace="spuNavProperty" title="501-800万" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;5741:494072209" data-ppath="5741:494072209">501-800万</a><a target="_self" trace="spuNavProperty" title="300-500万" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;5741:336962649" data-ppath="5741:336962649">300-500万</a><a target="_self" trace="spuNavProperty" title="300万以下" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;5741:493262615" data-ppath="5741:493262615">300万以下</a></div></div><div class="block-tail"><a href="javascript:;" style="display: none;" class="more-btn J_expandBtn">更多<span class="icon-btn-arrow-down-2"></span></a></div></div><div class="nav-block J_commonNav2 type-text"><div class="block-head"><h4><span class="nav-title">核心数</span>:</h4></div><div class="block-body "><div class="params-cont"><a target="_self" trace="spuNavProperty" title="双核" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;33187:3273422" data-ppath="33187:3273422"><span class="icon-btn-check-small param-checkbox"></span>双核</a><a target="_self" trace="spuNavProperty" title="单核" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;33187:8852907" data-ppath="33187:8852907"><span class="icon-btn-check-small param-checkbox"></span>单核</a></div><div class="multi-btn-cont"><a trace="navMutiSelect" href="javascript:;" class="submit-btn J_submitBtn">确定</a><a href="javascript:;" class="cancel-btn J_cancelBtn">取消</a></div></div><div class="block-tail"><a href="javascript:;" class="multi-btn J_multiBtn">多选</a><a href="javascript:;" style="display: none;" class="more-btn J_expandBtn">更多<span class="icon-btn-arrow-down-2"></span></a></div></div><div class="nav-block J_commonNav3 type-text"><div class="block-head"><h4><span class="nav-title">分辨率</span>:</h4></div><div class="block-body "><div class="params-cont"><a target="_self" trace="spuNavProperty" title="960*540" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;933:373270497" data-ppath="933:373270497">960*540</a><a target="_self" trace="spuNavProperty" title="960*640" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;933:18753077" data-ppath="933:18753077">960*640</a><a target="_self" trace="spuNavProperty" title="480*320" class="param-item icon-tag J_navBtn " href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;933:33610199" data-ppath="933:33610199">480*320</a></div></div><div class="block-tail"><a href="javascript:;" style="display: none;" class="more-btn J_expandBtn">更多<span class="icon-btn-arrow-down-2"></span></a></div></div><div class="nav-block last-block overlay-cont J_overlayCont"><div class="block-overlay J_blockOverlay" style="display: none;"><div class="overlay-panel"><a target="_self" trace="spuNavProperty" class="param-item async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;12304004:21573">128MB以下</a><a target="_self" trace="spuNavProperty" class="param-item async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;12304004:21399">512MB</a><a target="_self" trace="spuNavProperty" class="param-item async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;&amp;s=0&amp;vlist=1&amp;from=compass&amp;ppath=2176:21420;446:569740385;12304004:21398">256MB</a></div></div><div class="block-head"><h4>筛选条件:</h4></div><div class="block-body"><a title="运行内存RAM" class="condition-btn J_conditionBtn" href="javascript:;" data-overlayindex="0">运行内存RAM<span class="condition-icon icon-btn-arrow-down-2"></span></a></div></div></div></div></div><div id="J_SPUCombo" class="spu-combo"></div><div class="tb-sortbar"><div class="sortbar"><div class="container"><div class="sortbar-panel row"><div class="sortpanel col row"><div class="sort-item col J_sortItem sort-item-active first-sort-item"><a href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;psort=commend&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1" class="sort-a async-btn" title="综合"><span class="text">综合</span></a></div><div class="sort-item col J_sortItem  "><a href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;psort=_lw_quantity&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1" class="sort-a async-btn" title="销量较高的产品在前"><span class="text">销量</span></a></div><div class="sort-item col J_sortItem  "><a href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;psort=_market_time&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1" class="sort-a async-btn" title="最近上市的产品在前"><span class="text">上市时间</span></a></div><div class="sort-item col J_sortItem"><a href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;psort=_price&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1" class="sort-a async-btn" title="价格较高的产品在前"><span class="text">价格从高到低</span></a></div><div class="sort-item col J_sortItem"><a href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;cat=1512&amp;psort=price&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1" class="sort-a async-btn" title="价格较低的产品在前"><span class="text">价格从低到高</span></a></div></div><div class="col price-range common-dp"><div class="dp-panel J_hoverBtn"><div class="range-default"><input placeholder="¥" type="text" value="" class="price-txt J_startPrice" name="start_price" title="按价格区间筛选 最低价"><span class="divider">-</span><input placeholder="¥" type="text" value="" class="price-txt J_endPrice" name="end_price" title="按价格区间筛选 最高价"><a class="submit-btn J_rangeSubmitBtn" href="javascript:;">确定</a><a class="cancel-btn J_rangeCancelBtn" href="javascript:;">清除</a></div><div class="dplayer"><div class="layer-panel"><a trace="" class="range-cont row async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;start_price=0&amp;end_price=420&amp;cat=1512&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1"><span class="range-left col"><span class="range-text">420以下</span></span><span class="range-right col"><span class="scalebar"><span class="grey-bar"></span><span class="blue-bar" style="width: 25.2%"></span></span><span class="scaletext">25.2%人选择</span></span></a><a trace="" class="range-cont row async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;start_price=420&amp;end_price=910&amp;cat=1512&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1"><span class="range-left col"><span class="range-text">420-910</span></span><span class="range-right col"><span class="scalebar"><span class="grey-bar"></span><span class="blue-bar" style="width: 18.6%"></span></span><span class="scaletext">18.6%人选择</span></span></a><a trace="" class="range-cont row async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;start_price=910&amp;end_price=1620&amp;cat=1512&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1"><span class="range-left col"><span class="range-text">910-1620</span></span><span class="range-right col"><span class="scalebar"><span class="grey-bar"></span><span class="blue-bar" style="width: 21.5%"></span></span><span class="scaletext">21.5%人选择</span></span></a><a trace="" class="range-cont row async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;start_price=1620&amp;end_price=3040&amp;cat=1512&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1"><span class="range-left col"><span class="range-text">1620-3040</span></span><span class="range-right col"><span class="scalebar"><span class="grey-bar"></span><span class="blue-bar" style="width: 23.2%"></span></span><span class="scaletext">23.2%人选择</span></span></a><a trace="" class="range-cont row async-btn" href="/list?tab=all&amp;q=%CA%D6%BB%FA&amp;app=vproduct&amp;cps=yes&amp;from_type=3c&amp;start_price=3040&amp;end_price=0&amp;cat=1512&amp;m=get_vertical&amp;ppath=2176%3A21420%3B446%3A569740385&amp;vlist=1"><span class="range-left col"><span class="range-text">3040以上</span></span><span class="range-right col"><span class="scalebar"><span class="grey-bar"></span><span class="blue-bar" style="width: 11.5%"></span></span><span class="scaletext">11.5%人选择</span></span></a></div></div></div></div><div class="col end style-btns row"></div></div><a title="取消浮动跟随" class="J_fixedBtn fix-btn" href="javascript:;"><span class="icon-btn-x-round"></span></a></div></div></div><div class="tb-baobei"><div class="vbaobei-four row m-vgrid"><div class="grid-item col"><div class="grid-panel"><div class="img-box"><span class="important-key">3.5"</span><span class="special-tag-cont"></span><a trace="vertical_spu" tracenum="2" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4s&amp;pspuid=247025&amp;cat=1512&amp;from_pos=20_1512.default_0_1_247025&amp;from_type=3c&amp;spu_style=grid" target="_blank"><img src="http://img02.taobaocdn.com/bao/uploaded/i2/TB1LrcrHpXXXXcwXpXXXXXXXXXX.jpg_250x250.jpg" data-src="http://img02.taobaocdn.com/bao/uploaded/i2/TB1LrcrHpXXXXcwXpXXXXXXXXXX.jpg_250x250.jpg" alt="苹果 iPhone 4s" style="height: 100%; padding: 0px 12%;"></a></div><div class="info-cont"><div class="title-row "><a class="product-title" trace="vertical_spu" tracenum="2" title="苹果 iPhone 4s800w背照式镜头,Siri语音控制功能,双核A5处理器" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4s&amp;pspuid=247025&amp;cat=1512&amp;from_pos=20_1512.default_0_1_247025&amp;from_type=3c&amp;spu_style=grid" target="_blank">苹果 iPhone 4s<span class="feature"><span class="feature-item">800w背照式镜头</span>，<span class="feature-item">Siri语音控制功能</span>，<span class="feature-item">双核A5处理器</span></span></a></div><div class="sale-row row"><div class="col"><span class="price"><span class="price-yue">约</span><span class="price-sign">¥</span><span class="price-num">1924</span></span></div><div class="col end"><span class="week-sale">月销量<span class="num">21090</span></span></div></div><div class="info-row comment-row"><a class="user-comment" target="_blank" trace="ps_detail_comment" href="http://find.taobao.com/product/247025.html?sppuid=247025#all_koubei">点评 <span class="num">346463</span> 条</a><span class="user-score"><span class="icon-supple-xing-grey"></span><span class="icon-supple-xing-light" style="width: 63.50999999999999px"></span></span></div><div class="info-row seller"><a trace="vertical_seller" class="seller-link" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4s&amp;pspuid=247025&amp;cat=1512&amp;from_pos=20_1512.default_0_1_247025&amp;from_type=3c&amp;spu_style=grid#sortSpuDetail" target="_blank">共有9610商家在售</a></div></div></div></div><div class="grid-item col"><div class="grid-panel"><div class="img-box"><span class="important-key">3.5"</span><span class="special-tag-cont"></span><a trace="vertical_spu" tracenum="2" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4&amp;pspuid=267941&amp;cat=1512&amp;from_pos=20_1512.default_0_2_267941&amp;from_type=3c&amp;spu_style=grid" target="_blank"><img src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1wpwtHpXXXXavXpXXXXXXXXXX.jpg_250x250.jpg" data-src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1wpwtHpXXXXavXpXXXXXXXXXX.jpg_250x250.jpg" alt="苹果 iPhone 4" style="height: 100%; padding: 0px 9.6%;"></a></div><div class="info-cont"><div class="title-row "><a class="product-title" trace="vertical_spu" tracenum="2" title="苹果 iPhone 4iPhone中的经典,性价比高,A4处理器" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4&amp;pspuid=267941&amp;cat=1512&amp;from_pos=20_1512.default_0_2_267941&amp;from_type=3c&amp;spu_style=grid" target="_blank">苹果 iPhone 4<span class="feature"><span class="feature-item">iPhone中的经典</span>，<span class="feature-item">性价比高</span>，<span class="feature-item">A4处理器</span></span></a></div><div class="sale-row row"><div class="col"><span class="price"><span class="price-yue">约</span><span class="price-sign">¥</span><span class="price-num">1103</span></span></div><div class="col end"><span class="week-sale">月销量<span class="num">14440</span></span></div></div><div class="info-row comment-row"><a class="user-comment" target="_blank" trace="ps_detail_comment" href="http://find.taobao.com/product/267941.html?sppuid=267941#all_koubei">点评 <span class="num">125469</span> 条</a><span class="user-score"><span class="icon-supple-xing-grey"></span><span class="icon-supple-xing-light" style="width: 59.129999999999995px"></span></span></div><div class="info-row seller"><a trace="vertical_seller" class="seller-link" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+4&amp;pspuid=267941&amp;cat=1512&amp;from_pos=20_1512.default_0_2_267941&amp;from_type=3c&amp;spu_style=grid#sortSpuDetail" target="_blank">共有4289商家在售</a></div></div></div></div><div class="grid-item col"><div class="grid-panel"><div class="img-box"><span class="important-key">3.5"</span><span class="special-tag-cont"></span><span class="prod-tag icon-supple-4-islower"></span><a trace="vertical_spu" tracenum="2" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3GS&amp;pspuid=246828&amp;cat=1512&amp;from_pos=20_1512.default_0_3_246828&amp;from_type=3c&amp;spu_style=grid" target="_blank"><img src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1.ycnHpXXXXbeXVXXXXXXXXXX.jpg_250x250.jpg" data-src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1.ycnHpXXXXbeXVXXXXXXXXXX.jpg_250x250.jpg" alt="苹果 iPhone 3GS" style="height: 100%; padding: 0px 12%;"></a></div><div class="info-cont"><div class="title-row "><a class="product-title" trace="vertical_spu" tracenum="2" title="苹果 iPhone 3GS电池耐用,性价比高,屏幕清晰" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3GS&amp;pspuid=246828&amp;cat=1512&amp;from_pos=20_1512.default_0_3_246828&amp;from_type=3c&amp;spu_style=grid" target="_blank">苹果 iPhone 3GS<span class="feature"><span class="feature-item">电池耐用</span>，<span class="feature-item">性价比高</span>，<span class="feature-item">屏幕清晰</span></span></a></div><div class="sale-row row"><div class="col"><span class="price"><span class="price-yue">约</span><span class="price-sign">¥</span><span class="price-num">243</span></span></div><div class="col end"><span class="week-sale">月销量<span class="num">2167</span></span></div></div><div class="info-row comment-row"><a class="user-comment" target="_blank" trace="ps_detail_comment" href="http://find.taobao.com/product/246828.html?sppuid=246828#all_koubei">点评 <span class="num">11966</span> 条</a><span class="user-score"><span class="icon-supple-xing-grey"></span><span class="icon-supple-xing-light" style="width: 35.77px"></span></span></div><div class="info-row seller"><a trace="vertical_seller" class="seller-link" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3GS&amp;pspuid=246828&amp;cat=1512&amp;from_pos=20_1512.default_0_3_246828&amp;from_type=3c&amp;spu_style=grid#sortSpuDetail" target="_blank">共有610商家在售</a></div></div></div></div><div class="grid-item col"><div class="grid-panel"><div class="img-box"><span class="important-key">3.5"</span><span class="special-tag-cont"></span><a trace="vertical_spu" tracenum="2" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3G&amp;pspuid=249763&amp;cat=1512&amp;from_pos=20_1512.default_0_4_249763&amp;from_type=3c&amp;spu_style=grid" target="_blank"><img src="http://img01.taobaocdn.com/bao/uploaded/TB1_KbJGXXXXXbRXVXXXXXXXXXX.jpg_250x250.jpg" data-src="http://img01.taobaocdn.com/bao/uploaded/TB1_KbJGXXXXXbRXVXXXXXXXXXX.jpg_250x250.jpg" alt="苹果 iPhone 3G" style="height: 100%; padding: 0px 15.6%;"></a></div><div class="info-cont"><div class="title-row "><a class="product-title" trace="vertical_spu" tracenum="2" title="苹果 iPhone 3G原装苹果二代,ios智能后台" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3G&amp;pspuid=249763&amp;cat=1512&amp;from_pos=20_1512.default_0_4_249763&amp;from_type=3c&amp;spu_style=grid" target="_blank">苹果 iPhone 3G<span class="feature"><span class="feature-item">原装苹果二代</span>，<span class="feature-item">ios智能后台</span></span></a></div><div class="sale-row row"><div class="col"><span class="price"><span class="price-yue">约</span><span class="price-sign">¥</span><span class="price-num">151</span></span></div><div class="col end"><span class="week-sale">月销量<span class="num">350</span></span></div></div><div class="info-row comment-row"><a class="user-comment" target="_blank" trace="ps_detail_comment" href="http://find.taobao.com/product/249763.html?sppuid=249763#all_koubei">点评 <span class="num">859</span> 条</a><span class="user-score"><span class="icon-supple-xing-grey"></span><span class="icon-supple-xing-light" style="width: 29.93px"></span></span></div><div class="info-row seller"><a trace="vertical_seller" class="seller-link" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone+3G&amp;pspuid=249763&amp;cat=1512&amp;from_pos=20_1512.default_0_4_249763&amp;from_type=3c&amp;spu_style=grid#sortSpuDetail" target="_blank">共有225商家在售</a></div></div></div></div><div class="grid-item col"><div class="grid-panel"><div class="img-box"><span class="important-key">3.5"</span><span class="special-tag-cont"></span><a trace="vertical_spu" tracenum="2" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone%A3%A8%B5%DA%D2%BB%B4%FA%A3%A9&amp;pspuid=259032&amp;cat=1512&amp;from_pos=20_1512.default_0_5_259032&amp;from_type=3c&amp;spu_style=grid" target="_blank"><img src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1tq3sHpXXXXaRXpXXXXXXXXXX.jpg_250x250.jpg" data-src="http://img01.taobaocdn.com/bao/uploaded/i1/TB1tq3sHpXXXXaRXpXXXXXXXXXX.jpg_250x250.jpg" alt="苹果 iPhone（第一代）" style="height: 100%; padding: 0px 11.200000000000001%;"></a></div><div class="info-cont"><div class="title-row "><a class="product-title" trace="vertical_spu" tracenum="2" title="苹果 iPhone（第一代）无锁1代手机" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone%A3%A8%B5%DA%D2%BB%B4%FA%A3%A9&amp;pspuid=259032&amp;cat=1512&amp;from_pos=20_1512.default_0_5_259032&amp;from_type=3c&amp;spu_style=grid" target="_blank">苹果 iPhone（第一代）<span class="feature"><span class="feature-item">无锁1代手机</span></span></a></div><div class="sale-row row"><div class="col"><span class="price"><span class="price-yue">约</span><span class="price-sign">¥</span><span class="price-num">100</span></span></div><div class="col end"><span class="week-sale">月销量<span class="num">55</span></span></div></div><div class="info-row comment-row"><a class="user-comment" target="_blank" trace="ps_detail_comment" href="http://find.taobao.com/product/259032.html?sppuid=259032#all_koubei">点评 <span class="num">330</span> 条</a><span class="user-score"><span class="icon-supple-xing-grey"></span><span class="icon-supple-xing-light" style="width: 21.9px"></span></span></div><div class="info-row seller"><a trace="vertical_seller" class="seller-link" href="/list?app=detailproduct&amp;jc=1&amp;q=手机&amp;spu_title=%C6%BB%B9%FB+iPhone%A3%A8%B5%DA%D2%BB%B4%FA%A3%A9&amp;pspuid=259032&amp;cat=1512&amp;from_pos=20_1512.default_0_5_259032&amp;from_type=3c&amp;spu_style=grid#sortSpuDetail" target="_blank">共有39商家在售</a></div></div></div></div></div></div><div class="tb-pagination"></div></div>
</asp:Content>
