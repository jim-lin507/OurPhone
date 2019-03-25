<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="OnlineConsult.aspx.cs" Inherits="OnlineConsult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/ComplaintSuggestion.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center"  id="open" runat="server"><span style=" color:Red; font-weight:bolder;">在线咨询</span></div>



<div class="help_keyword help_keyword2">
            <label><span>*</span>您的E-mail地址：</label>
            <input runat="server" name="txt_email" type="text" id="txt_email" value="" />
            <div class="clear">
            </div>
            <label><span>*</span>您的姓名：</label>
            <input runat="server" name="txt_name" type="text" id="txt_name" />
            <div class="clear">
            </div>
            <label>您的联系电话：</label>
            <input runat="server" name="txt_tel" type="text" id="txt_tel" />
            <div class="clear">
            </div>
            <p class="description">
                <label><span>*</span>问题详细描述：</label>
                <textarea runat="server" name="txt_content" id="txt_content" type="text"></textarea>  
                <span class="nowrong" id="content_err"></span>
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

