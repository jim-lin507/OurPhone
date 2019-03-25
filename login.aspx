<%@ Page Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" Title="Log in—Our Phone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/main.css" rel="stylesheet" type="text/css">
<link href="css/m18.css" rel="stylesheet" type="text/css" />
<link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="https://s.tbcdn.cn/g/tb/login/0.2.1/css/full.css?t=20131120">
    <script src="script/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="script/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="script/jquery.validate.js" type="text/javascript"></script>
<script type="text/jscript">
    $(document).ready(function () {
        //alert("sdafsad");
        $("#aspnetForm").validate({
            rules: {
                UserName: "required",
                UserPassword: { required: true, minlength: 3 }
            },
            messages: {
                UserName: "请输入姓名",
                UserPassword: {
                    required: "请输入密码",
                    minlength: jQuery.format("密码不能小于{0}个字符")
                }
            }
        });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="aspnetForm" runat="server">
<div class="main">

<div class="logindiv">
  <div class="loginimg"><img src="images/Login_img.jpg" alt="" border="0"></div>
  <div class="logingbj">
    <div class="logingfome">
    <h1 class="YaHei">Login</h1>
    <h5 id="hint" runat="server" class="hint" style=" display:none; "></h5>
    <table border="0" cellspacing="0" cellpadding="0">
      <tbody><tr>
        <td width="60" height="55" valign="bottom"><b>Username：</b></td>
        <td colspan="2" align="right" valign="bottom">
<input name="UserName" type="text" id="UserName" runat="server" class="inputbj" style="width:240px;" />
        </td>
      </tr>
      <tr>
        <td height="70"><b>Password：</b></td>
        <td colspan="2" align="right"><input runat="server" name="UserPassword" type="password" id="login_txtPassword" class="inputbj" style="width:240px;"/></td>
      </tr>
      <tr>
        <td height="55">&nbsp;</td>
        <td width="100" style=" padding-left:50px;" valign="top">
            <asp:Button  ID="login_btnLogin" runat="server" Text="Sign in" class="btncss" 
                onclick="login_btnLogin_Click"/>
		 </td>
        <td width="143" align="left" valign="top"><a href="#"><!--Fotgot your password?--></a></td>
      </tr>
    </tbody></table>
    <div class="regis">
    <span class="YaHei">You are not a member？</span>
    <span style="font-size:14px"><a href="register.aspx" style="font-size:16px">Sign up</a></span> 
    </div>
    </div>
  </div>
</div>
</div>
</div>
</asp:Content>

