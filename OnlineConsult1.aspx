<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="OnlineConsult1.aspx.cs" Inherits="OnlineConsult1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<style type="text/css" >
    .LiuyunYe_InfoCONTENTS font {
color: #003399;
}
.LiuyunYe_Info font {
font-size: 12px;
}
.LiuyunYe_InfoRCONTENTS font {
color: #990000;
margin-right: 5px;
}
.LiuyunYe_Info font {
font-size: 12px;
}
.LiuyunYe_Info td {
padding-top: 3px;
padding-bottom: 3px;
}
.LiuyunYe_InfoCONTENTS {
text-align: left;
color: #000000;
}
.LiuyunYe_Info td {
padding-top: 3px;
padding-bottom: 3px;
}
.LiuyunYe_InfoTIME {
text-align: right;
color: #999999;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center"  id="open" runat="server"><span style=" color:Red; font-weight:bolder;">在线咨询</span></div>
<div id="Div1" runat="server"><span><a href="OnlineConsult.aspx" style="font-size: 12px;font-weight:bolder; padding-left:110px;color: #980266;">发表在线咨询</a></span></div>


    
    <asp:Repeater ID="OnlineRep" runat="server" 
        onitemdatabound="OnlineRep_ItemDataBound" >
        <ItemTemplate>
            <asp:HiddenField ID="hiddenOnlineId" Value='<%# Eval("OnlConId") %>' runat="server" />
            <table style=" font-size:12px; padding-left:20px;" border="0" cellspacing="0" cellpadding="0" class="LiuyunYe_Info">
  <tbody><tr>
    <td align="center" class="LiuyunYe_InfoSEX">
<!--5-->
<img title=' <%# Eval("UserName") %>' height="84" alt="" src="images/boy.gif" width="84">
<br>
      <%# Eval("UserName") %></td>
    <td>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tbody>
        <tr>
          <td style=" padding-left:750px;" class="LiuyunYe_InfoTIME"><%# Eval("OnlineTime") %></td>
        </tr>
        <tr>
          <td class="LiuyunYe_InfoCONTENTS"><font>[咨询]</font>
<!--7-->
<%# Eval("Description") %>
        </td>
        </tr>
        <tr>
         <!-- <td class="LiuyunYe_InfoRCONTENTS">

        <font>[回复]</font>可以以旧换新，直接去店里就可以。
           </td>-->
                    <td class="LiuyunYe_InfoRCONTENTS">

                <font>[回复]</font><asp:Label ID="replyContent" runat="server" Text=""></asp:Label>
                <asp:LinkButton style=" padding-left:100px; font-size:14px; color:#980266; font-family:@宋体;font-weight:bolder;"       ID="replyUserContent" runat="server">回复消息</asp:LinkButton>
                     </td>

        </tr>
      </tbody>
      </table>
      </td>
  </tr>
</tbody>


</table>
        </ItemTemplate>
    </asp:Repeater>
    <div align="center">
        <webdiyer:AspNetPager ID="AspNetPager1" onpagechanged="AspNetPager1_PageChanged" runat="server"   
         HorizontalAlign="Center" Width="100%" 
meta:resourceKey="AspNetPager1" Style="font-size: 14px; padding-left:50px;" 
AlwaysShow="false" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
PrevPageText="上一页" SubmitButtonText="Go" SubmitButtonClass="submitBtn" 
CustomInfoStyle="font-size:14px;text-align:left;" 
InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; " 
TextBeforeInputBox="转到第" TextAfterInputBox="页 " PageIndexBoxType="TextBox" 
ShowPageIndexBox="Always" TextAfterPageIndexBox="页" 
TextBeforePageIndexBox="转到" Font-Size="14px" CustomInfoHTML="" 
ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%" 
PagingButtonSpacing="3px" >
        </webdiyer:AspNetPager>
    
    </div>
    <div style=" padding-bottom:100px;">
    </div>

</asp:Content>

