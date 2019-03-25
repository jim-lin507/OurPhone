<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="User_InfoEdit.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/m18.css" rel="stylesheet" type="text/css" />
    <link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="script/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="script/jquery.validate.js"></script>
     <script type="text/javascript" src="script/register.js"></script>
    <!-- <script language="Javascript" type="text/javascript">
         setTimeout("parent.location.reload();", 3000);
</script>-->
    <title>无标题页</title>
</head>
<body>
    <form id="form1" action="User_InfoEdit.aspx" method="post" runat="server">
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

                        
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                Nickname:
                            </td>
                            <td width="69%" valign="middle">
                                
                                    <asp:TextBox ID="nickName"  class="inputbj" style="width:240px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="8%" align="right" valign="middle">
                                Full Name:
                            </td>
                            <td width="69%" valign="middle">
                                <asp:TextBox ID="trueName"  class="inputbj" style="width:240px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                     <tr valign="middle">
                            <td align="right">
                                Phone Number:
                            </td>
                            <td>
                                <asp:TextBox ID="phoneNum"  class="inputbj" style="width:240px;" runat="server"></asp:TextBox><span id="register_txtMobileTip" class=""></span>
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td align="right">
                                Address:
                            </td>
                            <td>
                                <asp:TextBox ID="address"  class="inputbj" style="width:240px;" runat="server"></asp:TextBox><span id="Span1" class=""></span>
                            </td>
                        </tr>
                      
                        
                        <tr>
                            <td align="right">
                            </td>
                            <td valign="top">
                                
                                        <asp:Button ID="edit" runat="server" Text="Edit" class="btncss register_btn" onclick="edit_Click" 
                                            />
                                
                            </td>
                        </tr>
                    </tbody></table>
                </div>
    </form>
</body>
</html>
