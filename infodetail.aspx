<%@ Page Language="C#" MasterPageFile="~/InfoDetailMasterPage.master" AutoEventWireup="true" CodeFile="infodetail.aspx.cs" Inherits="infodetail" Title="Our Phone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .wishListImgLink {
            /*background: url(images/wishList.jpg) no-repeat;*/
            display: block;
            float: left;
            font-size: 20px;
            font-weight: bold;
            background-color: green;
            padding:10px;
            color: white;
            margin-left:20px;
        }
        .wishListImgLink:hover {
            text-decoration: none;
                color: white;
        }
        .shoppingCartImgLink {
            /*background: url(images/shoppingCart.jpg) no-repeat;*/
            display: block;
            float: left;
            font-size: 20px;
            font-weight: bold;
            background-color: red;
            color: white;
            padding: 10px;
        }

            .shoppingCartImgLink:hover {
                text-decoration: none;
                color: white;
            }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="padding-right: 400px;" class="head" name="Title_pub">
        <h1><strong>
            <asp:Label ID="laName" runat="server" Text=""></asp:Label></strong></h1>
    </div>
    <div class="show clearfix" style="margin-bottom: 0px;">


        <div class="show_pic" name="Mainimg_pub">
            <div class='big'>
                <a title='' runat="server" id="title" class='pic' name='__bigpic_pub' href='#' target='_self'>
                    <asp:Image ID="Image1" Width="350px" Height="350px" runat="server" /></a>
            </div>
        </div>


        <div class="show_info">
            <div class="sale">
                <p class="item_id" id="prd_item_id">
                    Product ID：<i><asp:Label ID="lbNumber" runat="server"
                        Text=""></asp:Label></i>
                </p>
                <p>
                    Price：<b class="d_price "><span id="d_price" runat="server" class="yen">$</span>
                        <asp:Label ID="lbPrice" runat="server" Text=""></asp:Label></b><span class="break"></span>
                </p>
                <p runat="server" id="bp">
                    Promotion Price：<b id="B1" class="d_price "><span class="yen">$</span>
                        <asp:Label ID="bargainPrice" runat="server" Text=""></asp:Label></b><span class="break"></span>
                </p>
                <p>Reviews：<span class="starlevel s5"><img src="images/pingfen.jpg" /></span><span id="comm_num_up"><a id="comm_num_down" name="__Commentnum_pub" href="#"><i>13754</i></a> reviews</span></p>
            </div>

            <ul class="intro clearfix" name="Infodetail_pub">
                <%-- <li>
                <span><span class="ws2">特点：</span><b><asp:Label ID="speciality" runat="server"
                    Text=""></asp:Label></b></span>
            </li>--%>
                <li>
                    <span class="c3"><span class="ws2">Model Year：</span><b><asp:Label ID="markettime" runat="server"
                        Text=""></asp:Label></b></span>
                    <span class="c3"><span class="ws2">Screen：</span><b><asp:Label ID="size" runat="server"
                        Text=""></asp:Label></b></span>
                    <span class="c3"><span class="ws2">Operating System：</span><b><asp:Label ID="operatingsystem" runat="server"
                        Text=""></asp:Label></b></span>
                </li>
                <li>
                    <%--<span class="c3"><span class="ws2">网络类型：</span><b><asp:Label ID="networktype" runat="server"
                    Text=""></asp:Label></b></span>--%>
                    <span class="c3"><span class="ws2">Resolution：</span><b><asp:Label ID="pixel" runat="server"
                        Text=""></asp:Label></b></span>
                    <%--  <span class="c3"><span class="ws2">核心数：</span><b><asp:Label ID="corenumber" runat="server"
                    Text=""></asp:Label></b></span>--%>
                </li>

            </ul>
            <br />

            <span class="c3"><span class="ws2" style="font-size: 20px;">Store Name：<b><asp:Label ID="storeName" runat="server" Text=""></asp:Label></b></span><a id="storeDisplay" runat="server" href="" style="color: Red"> Browse shop directly</a></li><br />
                <span class="c3"><span class="ws2" style="font-size: 20px;">Store Owner：<b><asp:Label ID="storeUser" runat="server" Text=""></asp:Label></b></span>
                    <input type="hidden" name="storeId" id="storeId" runat="server" /><br />
                    <div runat="server" style="display: none" id="down">
                        <span style="font-size: 30px; color: Red;"><strong>
                            <asp:Label ID="disapear" runat="server" Text=""></asp:Label></strong></span>
                    </div>
                    <div runat="server" id="downMarketProduct" style="padding-top: 30px;">
                        QTY：<asp:TextBox ID="TextBox1" runat="server" Width="20px">1</asp:TextBox>
                        <br />
                        <div style="padding-top: 30px;">
                            <div>
                                <asp:LinkButton ID="shoppingCart" class="shoppingCartImgLink" runat="server"
                                    OnClick="shoppingCart_Click">Add To Cart</asp:LinkButton>
                                <asp:LinkButton ID="wishList" class="wishListImgLink" runat="server"
                                    OnClick="wishList_Click">Add To Watchlist</asp:LinkButton>
                            </div>
                        </div>
                    </div>
        </div>

    </div>

</asp:Content>


