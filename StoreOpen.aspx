<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="StoreOpen.aspx.cs" Inherits="OpenStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/m18.css" rel="stylesheet" type="text/css" />
    <link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="main"><!-- InstanceBeginEditable name="编辑区" -->
	<!--页面位置导航_start-->

        
        <div class="trationbj">
            <div class="tration">
                <h1 class="YaHei">
                    新商店注册</h1>
                <div class="fomeinput">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fomeinput">
                        <tbody>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                商店名称：
                            </td>
                            
                            <td width="69%" valign="middle">
                                <asp:TextBox ID="StoreName" runat="server"  class="inputbj" style="width:240px;"></asp:TextBox><h5 id="hint" runat="server" class="hint" style=" display:none; "></h5>
                               <!-- <span id="register_txtUserNameTip" class="msgError">用户名不能为空，必须以汉字或是字母开头,且在2-20个字符之间</span>-->
                            </td>
                            <td width="23%" rowspan="7" valign="top">
                                <ul>
                                    <li class="dotted">已有商店？可以<a href="StoreDisplay.aspx"> 直接查看商店</a></li>
                                </ul>
                            </td>
                        </tr>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                商店地址：
                            </td>
                            
                            <td width="69%" valign="middle">
                                <asp:TextBox ID="storeAddress" runat="server"  class="inputbj" style="width:240px;"></asp:TextBox>
                               <!-- <span id="register_txtUserNameTip" class="msgError">用户名不能为空，必须以汉字或是字母开头,且在2-20个字符之间</span>-->
                            </td>
                        </tr>
                        <tr>
                            <td width="8%" align="right" valign="top">
                                商店商标：
                            </td>
                            <td width="69%" valign="middle">
                                 <div align="left">
                          <input onpropertychange="document.all.img1.src=this.value" type="file" name="uploadFile"
                                id="uploadFile" runat="server">
                        </div>
                        <img height="100" src="images\showimg.gif" width="100" name="img1">
                            </td>
                        </tr>
                        <tr>
                    <td>&nbsp;</td>
                    <td align="left">图片大小不超过200*200像素，仅支持JPG和JIF格式</td>      
                </tr>
                     <tr valign="middle">
                            <td valign="top">
                                商店介绍：
                            </td>
                            <td>
                                <textarea style="resize: none;" id="StoreIntro" name="StoreIntro" rows="5" cols="40" runat="server"></textarea>
                            </td>
                        </tr>
                      
                        
                        <tr>
                            <td align="right">
                            </td>
                            <td>
                               <asp:Button ID="register_Store"  class="btncss register_btn" runat="server" Text="注册商店" onclick="register_Store_Click" />
                            </td>
                        </tr>
                    </tbody></table>
                </div>
            </div>
        </div>
   </div>
</asp:Content>

