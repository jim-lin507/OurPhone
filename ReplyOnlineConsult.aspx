<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="ReplyOnlineConsult.aspx.cs" Inherits="ReplyOnlineConsult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="css/ComplaintSuggestion.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div align="center"  id="open" runat="server"><span style=" color:Red; font-weight:bolder;">回复在线咨询</span></div>


<table width="1000px;" align="center" border="0px">
        <tr align="center"  style=" background-color:#088BB5; color:#941714;">
                <td>在线咨询编号</td>
                <td>E-Mail</td>
                <td>姓名</td>
                <td>联系电话</td>
                <td>问题详细描述</td>
                <td>管理员回复</td>
          </tr>
    <asp:Repeater ID="reOnCo" runat="server">
        <ItemTemplate>
        <tr align="center"  style=" background-color:#61C8F3;">
                <td><%# Eval("OnlConId")%></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("PhoneNum") %></td>
                <td><%# Eval("Description") %></td>
                <td><%# Eval("ReplyContent")%></td>
          </tr>
     </ItemTemplate>
    </asp:Repeater>   
</table>

<div class="help_keyword help_keyword2">
            <label>在线咨询编号：</label>
            <asp:Label style=" font-weight:bolder;" ID="onlConNum" runat="server" Text="Label"></asp:Label>
            <div class="clear">
            </div>
            <label>用户的E-mail地址：</label>
            <asp:Label style=" font-weight:bolder;" ID="txt_email" runat="server" Text="Label"></asp:Label>
            <div class="clear">
            </div>

            <label>用户的姓名：</label>
    <asp:Label ID="txt_name" style=" font-weight:bolder;" runat="server" Text="Label"></asp:Label>
            <div class="clear">
            </div>
            <label>用户的联系电话：</label>
    <asp:Label ID="txt_tel" style=" font-weight:bolder;" runat="server" Text="Label"></asp:Label>
            <div class="clear">
            </div>
            <p class="description">
                <label>用户的问题详细描述：</label>
                <asp:Label style=" font-weight:bolder;" ID="txt_content" runat="server" Text="Label"></asp:Label> 
                <span class="nowrong" id="content_err"></span>
            </p>
            <div class="clear"></div>
            <p class="description">
                <label><span>*</span>管理员回复：</label>
                <textarea runat="server" name="txt_replyContent" id="txt_replyContent" type="text"></textarea>  
                <span class="nowrong" id="Span1"></span>
                <span class="hint">不超过<span id="content_input">2000</span>字</span>
            </p>
            <div class="clear"></div>
            <p class="description">            
                <asp:Button class="button_ok" Width="100px" Height="35px" 
                    style=" font-size: 14px;font-weight: 700;background-color:Green;color:White;Cursor: pointer;" 
                    ID="btnSubmit" runat="server" Text="提交" onclick="btnSubmit_Click" />
            </p>
            <div class="clear"></div>        
        </div>



</asp:Content>

