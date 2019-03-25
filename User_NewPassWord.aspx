<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_NewPassWord.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/m18.css" rel="stylesheet" type="text/css" />
    <link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="script/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="script/jquery.validate.js"></script>
     <script type="text/javascript" src="script/register.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="fomeinput">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="fomeinput">
                        <tbody>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                User Name:
                            </td>
                            <td width="69%" valign="middle">
                               
                                <asp:Label ID="userName" runat="server" Text="userName" style="width:240px;"></asp:Label>
                               <!-- <span id="register_txtUserNameTip" class="msgError">用户名不能为空，必须以汉字或是字母开头,且在2-20个字符之间</span>-->
                            </td>
                            
                        </tr>
                         <tr valign="middle">
                            <td align="right">
                                Old Password:
                            </td>
                            <td>
                                <input name="OldPassword" type="password" runat="server" id="OldPassword" class="inputbj" style="width:240px;" />

                                <span runat="server" style=" visibility:hidden;" id="OldPassword_error" >
                                    <img src="images/error.jpg" /><em runat="server" id="OldPasswordempty"></em></span>
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="right">
                                New Password:
                            </td>
                            <td>
                                <input name="UserPassword" type="password" runat="server" id="UserPassword" class="inputbj" style="width:240px;" />
                               <span runat="server" style=" visibility:hidden;" id="Span1" >
                                    <img src="images/error.jpg" /><em runat="server" id="UserPasswordempty"></em></span>
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="right">
                                Confirm Password
                            </td>
                            <td>
                                <input name="UserPassword2" type="password"  runat="server" id="UserPassword2" class="inputbj" style="width:240px;" />
                             <span runat="server" style=" visibility:hidden;" id="UserPassword2_error" >
                                    <img src="images/error.jpg" /><em runat="server" id="UserPassword2empty"></em></span>
                            </td>
                        </tr> 
                        
                      
                        
                        <tr>
                            <td align="right">
                            </td>
                            <td valign="top">
                                
                                        <asp:Button ID="edit" runat="server" Text="Change" class="btncss register_btn" onclick="edit_Click" 
                                            />
                                
                            </td>
                        </tr>
                    </tbody></table>
                </div>
    </form>
</body>
</html>
