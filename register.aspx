<%@ Page Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" Title="Sign up—Our Phone" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/m18.css" rel="stylesheet" type="text/css" />
    <link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="script/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="script/jquery.validate.js"></script>
     <script type="text/javascript" src="script/register.js"></script>
  <script type="text/javascript">
      /* $(document).ready(function () {
          $("#registerForm").validate(
      { rules: {
          UserName: "required",
           UserPassword:
       { required: true, minlength: 6 },
           UserPassword2: {
              required: true, minlength: 6, equalTo: "#UserPassword"
          }
      }, messages: {
          UserName: "请输入姓名",
           UserPassword:
          { required: "请输入密码", minlength: jQuery.format("密码不能小于{0}个字符")
          },
           UserPassword2: {
              required: "请输入确认密码", minlength: "确认密码不能小于6个字符", equalTo: "两次输入密码不一致"
          }
      }
  });
            });
     if (document.getElementById("UserName").value=null) {
          alert("用户名不能为空！");
            }*/
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="registerForm"  runat="server">
<div class="main"><!-- InstanceBeginEditable name="编辑区" -->
	<!--页面位置导航_start-->

        
        <div class="trationbj">
            <div class="tration">
                <h1 class="YaHei">
                    Create a New Account</h1>
                <div class="fomeinput">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fomeinput">
                        <tbody>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                Username：
                            </td>
                            <td width="69%" valign="middle">
                                <input runat="server" name="UserName" type="text" id="UserName" class="inputbj" style="width:240px;" /><h5 id="hint" runat="server" class="hint" style=" display:none; "></h5>
                               <!-- <span id="register_txtUserNameTip" class="msgError">用户名不能为空，必须以汉字或是字母开头,且在2-20个字符之间</span>-->
                            </td>
                            <td width="23%" rowspan="7" valign="top">
                                <ul>
                                    <li class="dotted">Already a member?<a href="login.aspx"> Sign in</a></li>
                                </ul>
                            </td>
                        </tr>

                        <tr valign="middle">
                            <td align="right">
                                Password:
                            </td>
                            <td>
                                <input runat="server" name="UserPassword" type="password" id="UserPassword" class="inputbj" style="width:240px;" /><!--<span id="register_txtPasswordTip" class="msgError">密码不能为空，且在6-20个字符之间</span>-->
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="right">
                                Confirm password:
                            </td>
                            <td>
                                <input runat="server" name="UserPassword2" type="password" id="UserPassword2" class="inputbj" style="width:240px;" />
                              <!--  <span id="register_txtPassword2Tip" class="msgError">确认密码不能为空，且在6-20个字符之间</span>-->
                            </td>
                        </tr> 
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                Nickname：
                            </td>
                            <td width="69%" valign="middle">
                                <input runat="server" name="NickName" type="text" id="NickName" class="inputbj" style="width:240px;" />
                            </td>
                        </tr>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                Full Name：
                            </td>
                            <td width="69%" valign="middle">
                                <input runat="server" name="TrueName" type="text" id="TrueName" class="inputbj" style="width:240px;" />
                            </td>
                        </tr>
                     <tr valign="middle">
                            <td align="right">
                                Phone Number：
                            </td>
                            <td>
                                <input runat="server" name="PhoneNum" type="text" id="PhoneNum" class="inputbj" style="width:240px;" /><span id="register_txtMobileTip" class=""></span>
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="right">
                                Address：
                            </td>
                            <td>
                                <input runat="server" name="Address" type="text" id="Address" class="inputbj" style="width:240px;" /><span id="Span1" class=""></span>
                            </td>
                        </tr>
                      
                        
                        <tr>
                            <td align="right">
                            </td>
                            <td valign="top">
                                
                                <asp:Button ID="register_btnRegister" runat="server" Text="Sign Up"  
                                    class="btncss register_btn" onclick="register_btnRegister_Click" />
                                
                            </td>
                        </tr>
                    </tbody></table>
                </div>
            </div>
        </div>
   </div>
   </div>
</asp:Content>

