<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="product_sale.aspx.cs" Inherits="product_sale" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="http://g.tbcdn.cn/tb/global/3.4.4/global-min.css">
    <link rel="stylesheet" href="http://g.alicdn.com/??tb/trademanager/3.0.91/pages/bought/page/index-min.css,tb/dts/1.0.12/eb_trade/eb_trade.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="form1" runat="server">
        <div style="font-size: 12px;" id="main-content">





            <div class="trade-remind" id="J_navbar">
                <ul class="list" data-spm="7">

                    <li class="selected first">
                        <a class="link" style="text-decoration: none;" href="product_sale.aspx" data-spm="d1"><span>Selled Products</span></a>

                    </li>
                    <li class="selected first">
                        <a class="link" style="text-decoration: none;" href="HotStatistics.aspx" data-spm="d1"><span>Hot Products</span></a>

                    </li>






                    <li class="last " style="visibility: hidden;">
                        <a id="J_orderRecyleBin" class="recycle J_MakePoint" href="#" data-spm="d8"></a>
                    </li>
                </ul>

                <div class="wrap-line">
                    <span class="line selected0" style="left: -2px;"></span>
                </div>
            </div>


            <div class="searchbar">
                <form class="skin-gray clearfix bought-search" action="?search" method="post" id="J_QueryConditionForm">

                    <div class="simple">
                        <asp:TextBox ID="J_BaobeiName" runat="server" class="auction-title" name="auctionTitle" value="" MaxLength="30" placeholder="Please enter product name or order number"></asp:TextBox>
                        <span class="search-btn">
                            <asp:Button ID="OrderSearch" Height="25px" Style="cursor: pointer;"
                                class="J_MakePoint button" runat="server" Text="Search Order"
                                OnClick="OrderSearch_Click" />
                        </span>
                    </div>



                </form>


            </div>


            <div class="bought-list">

                <form action="" method="post" id="J_BoughtListForm" autocomplete="off">

                    <table class="bought-table" id="J_BoughtTable" data-spm="9">


                        <colgroup>
                            <col class="baobei">
                            <col class="price">
                            <col class="quantity">
                            <col class="item-operate">
                            <col class="amount">
                            <col class="trade-status">
                            <col class="trade-operate">
                        </colgroup>
                        <thead>
                            <tr class="col-name">
                                <th class="baobei">Product</th>
                                <th class="price">Price</th>
                                <th class="quantity">Quanlity</th>
                                <th class="item-operate">Product Operation</th>
                                <th class="amount">Payment Amount</th>
                                <th class="trade-status">
                                    <div class="trade-status">
                                        <div id="ks-component1798" class="bf-select bf-menu-button bf-button

"
                                            tabindex="0" role="button" title="" style="width: 86px; height: 15px; -webkit-user-select: none;">
                                            <div id="ks-content-ks-component1798" class="bf-select-content bf-menu-button-content bf-button-content" style="-webkit-user-select: none;">Trade Status</div>
                                        </div>

                                    </div>
                                </th>
                                <th class="trade-operate">Trade Operation</th>
                            </tr>
                            <tr class="sep-row">
                                <td colspan="7"></td>
                            </tr>
                            <tr class="toolbar toolbar-top">
                                <td colspan="7">
                                    <div class="operates">
                                        <label>
                                            <input type="checkbox" class="J_AllSelector all-selector">Select All</label>

                                    </div>

                                </td>
                            </tr>
                        </thead>






                        <asp:Repeater ID="repOrderProduct" runat="server"
                            OnItemCommand="repOrderProduct_ItemCommand"
                            OnItemDataBound="repOrderProduct_ItemDataBound">
                            <ItemTemplate>
                                <asp:HiddenField ID="hiddenPrice" Value='<%# Eval("Price")%>' runat="server" />
                                <asp:HiddenField ID="hiddenQuantity" Value='<%# Eval("Quantity")%>' runat="server" />
                                <asp:HiddenField ID="hiddenOrderId" Value='<%#Eval("OrderId") %>' runat="server" />
                                <asp:Label ID="labelOrderId" Visible="false" runat="server" Text='<%#Eval("OrderId") %>'></asp:Label>
                                <tbody class="mainOrder1006473377485320  success-order tm3c-order hover hover-finish-order">


                                    <tr class="sep-row">
                                        <td colspan="7"></td>
                                    </tr>
                                    <tr class="order-hd">
                                        <td class="first">
                                            <div class="summary">
                                                <span style="padding-top: 14px;">
                                                    <input type="checkbox" class="J_Selector selector" id="cb1006473377485320" name="biz_order_id" value="1006473377485320" disabled="disabled">
                                                </span>
                                                &nbsp;&nbsp;&nbsp;&nbsp;<span class="dealtime" title="<%#Eval("OrderTime").ToString().Substring(0,15) %>"><%#Eval("OrderTime").ToString().Substring(0,9) %></span><span class="number last-item">Order ID:<em><%#Eval("OrderId") %></em></span>
                                            </div>
                                        </td>

                                        <td class="last" colspan="6"></td>
                                    </tr>


                                    <tr id="item1006473377485320" class="order-bd 
    last     order-last">
                                        <td class="baobei">





                                            <a target="_self" title='<%# Eval("Name")%>' href='infodetail.aspx?productid=<%# Eval("ProductId")%>' class="pic J_MakePoint">
                                                <img alt='<%# Eval("Name")%>' src='showProductPicture.aspx?productid=<%# Eval("ProductId")%>'>
                                            </a>

                                            &nbsp;&nbsp;&nbsp;&nbsp;<div class="desc">

                                                <p class="baobei-name" style="padding-top: 40px;">
                                                    <a target="_self" href='infodetail.aspx?productid=<%# Eval("ProductId")%>' title='<%# Eval("Name")%>' class="J_MakePoint"><%# Eval("Name")%> </a>
                                                </p>

                                            </div>
                                        </td>

                                        <td class="price">
                                            <i class="special-num">
                                                <asp:Label ID="Pprice" runat="server" Text='<%# Eval("Price")%>'></asp:Label></i><br />
                                            <i class="special-num">
                                                <asp:Label ID="BargainPrice" runat="server" Text='<%# Eval("BargainPrice")%>'></asp:Label></i>
                                        </td>

                                        <td class="quantity" title="1">
                                            <i class="special-num"><%# Eval("Quantity")%></i>
                                        </td>



                                        <td class="item-operate">


                                            <a href="#" class="tousu-weiquan J_MakePoint J_HasBuy J_ApplyRepayTrigger" title="" target="_self">Complaints Buyer</a>


                                        </td>

                                        <td class="amount" rowspan="1">




                                            <p>
                                                <em class="real-price special-num">
                                                    <asp:Label ID="totalPrice" runat="server" Text=""></asp:Label>
                                                </em>
                                            </p>

                                        </td>


                                        <td class="trade-status" rowspan="1">



                                            <span>Successfull Trade</span>


                                        </td>

                                        <td class="trade-operate" rowspan=" 1 ">

                                            <span class="skin-white">
                                                <asp:LinkButton ID="delete" title="Delete" CommandName="deleteOrder" class="J_Rate J_MakePoint tm-btn tm-skin-white" runat="server">Delete</asp:LinkButton>
                                            </span>

                                        </td>
                                    </tr>





                                </tbody>

                            </ItemTemplate>
                        </asp:Repeater>







                        <tfoot>
                        </tfoot>

                    </table>
                </form>

            </div>
            <!--end bought-list-->


        </div>
        <div align="center" runat="server" id="noExist"><span style="color: Red; font-weight: bolder;">该已卖出订单记录不存在！</span></div>
        <div style="padding-top: 20px; padding-left: 50px;" align="center">
            <webdiyer:AspNetPager ID="AspNetPager1" OnPageChanged="AspNetPager1_PageChanged" runat="server"
                HorizontalAlign="Center" Width="100%"
                meta:resourceKey="AspNetPager1" Style="font-size: 14px; padding-left: 50px;"
                AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页"
                PrevPageText="上一页" SubmitButtonText="Go" SubmitButtonClass="submitBtn"
                CustomInfoStyle="font-size:14px;text-align:left;"
                InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; "
                TextBeforeInputBox="转到第" TextAfterInputBox="页 " PageIndexBoxType="TextBox"
                ShowPageIndexBox="Always" TextAfterPageIndexBox="页"
                TextBeforePageIndexBox="转到" Font-Size="14px" CustomInfoHTML=""
                ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%"
                PagingButtonSpacing="3px">
            </webdiyer:AspNetPager>
        </div>
    </div>

</asp:Content>

