<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="User_Edit.aspx.cs" Inherits="User_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/m18.css" rel="stylesheet" type="text/css" />
    <link href="css/pagevalidator.css" rel="stylesheet" type="text/css" />
       <script type="text/javascript" src="script/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="script/jquery.validate.js"></script>
     <script type="text/javascript" src="script/register.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="registerForm"   runat="server">
<div class="main"><!-- InstanceBeginEditable name="编辑区" -->
	<!--页面位置导航_start-->

        
        <div class="trationbj">
            <div class="tration">
                <h1 class="YaHei">
                    
    <asp:LinkButton ID="userInfoEdit" runat="server" onclick="userInfoEdit_Click">Edit Profile</asp:LinkButton>
    <asp:LinkButton   ID="userPasswordEdit" style=" padding-left:50px;" runat="server" 
                        onclick="userPasswordEdit_Click">Change Password</asp:LinkButton></h1>
                     <iframe width="700px" height="900px" src="User_InfoEdit.aspx"   runat="server" id="userPage"></iframe>
                
            </div>
        </div>
   </div>
   </div>
</asp:Content>

