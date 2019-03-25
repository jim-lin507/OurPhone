<%@ Page Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="showshoppingcart.aspx.cs" Inherits="showshoppingcart1" Title="Our Phone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="loginForm" action="" method="post" runat="server">
<h1 style="color:#FF5500" class="dib">确认收货地址</h1><br />
<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="address" runat="server" Text=""></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a style="color:#FF5500" target="_self" href="User_Edit.aspx">修改收货信息</a>
    <!--<asp:RadioButtonList ID="RadioButtonList1" runat="server">
    </asp:RadioButtonList>-->
<div>
    <h1 style="color:#FF5500" class="dib">确认订单信息</h1>
    <table cellspacing="0" cellpadding="0" class="order-table" id="J_OrderTable" summary="统一下单订单信息区域">      
        <thead>
        <tr>
            <th class="s-title">手机<hr></th>
            <th class="s-price">单价(元)<hr></th>
            <th class="s-amount">数量<hr></th>
            <th class="s-agio">优惠方式(元)<hr></th>
            <th class="s-total">小计(元)<hr></th>
        </tr>
        </thead>
<tbody data-spm="3" class="J_Shop">
    <!--<tr>
    <td><span class="orderInfo-shoparea">店铺：<b><a class="orderInfo-shop J_MakePoint" href="" target="_blank" title="心动鞋店" >心动鞋店</a></b>	
	</span>
    &nbsp;&nbsp;&nbsp;&nbsp;<span class="orderInfo-seller">店主：
	<b><a class="orderInfo-sellername J_MakePoint" href="" target="_blank" title="心动鞋行">心动鞋行</a></b>
	</span>
    </td>
	<td colspan="4"></td>
    </tr>-->
            <%=GetInfoShoppingCart() %>
</tbody>
        <tfoot>
        <tr>
            <td colspan="5">
                    <div style="padding-bottom:20px;" class="J_AddressConfirm address-confirm">
                        <div class="kd-popup pop-back">
                            <div class="box">
                                <div class="bd">
<div class="point-in">
       <em class="t">实付款：</em>    <span class="price g_price ">
        <span>¥</span><em class="style-large-bold-red" id="J_ActualFee">
        <asp:Label ID="totalPrice"  runat="server" Text="0"></asp:Label></em>
    </span>
    <br />
    <em class="t">账户余额：</em>    <span class="price g_price ">
        <span>¥</span><em class="style-large-bold-red" id="Em1">
        <asp:Label ID="Label2"  runat="server" Text="0"></asp:Label></em>
    </span>
</div>
                                   <!-- <ul>
                                        <li><em>寄送至:</em><span id="J_AddrConfirm">浙江省 绍兴市 越城区 张三</span></li>
                                        <li><em>收货人:</em><span id="J_AddrNameConfirm">张三 18232324275</span><a href="#" class="J_ChangeAddressHook hook">更换地址</a></li>
                                    </ul> -->
                                   
                                </div>
                            </div>
 <a id="J_Go" class="btn-go" tabindex="0" title="点击此按钮，提交订单。">
     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/submit.jpg" onclick="ImageButton1_Click1" 
                                 /></a>
                        </div>
                    </div>
            </td>
        </tr>
        </tfoot>
    </table>
</div>
    </form>
    <div runat="server" id="shopCart">
        <div style=" float:left" id="empty"><img title="" border="0" alt="" src="./images/shopCart.jpg"/></div><div style=" float:left"><h8><b>您的Cart还是空的，赶紧行动吧！您可以：</b></h8><ul><li>看看 <a style="color:Blue;font-size:14px;" href="#" target="_self">我的收藏</a></li><li>看看 <a  style="color:Blue;font-size:14px;" href="#" target="_self">已买到的宝贝</a></li></ul></div>
    </div>
</asp:Content>

