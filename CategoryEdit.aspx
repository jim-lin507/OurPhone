﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="CategoryEdit.aspx.cs" Inherits="CategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" href="http://g.tbcdn.cn/tb/idle/1.2.9/??common/base-min.css,widget/header/header-min.css,pages/publish/page/publish-min.css" /> 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="registerForm"  runat="server">
            <div id="form-bd">
            <div  style="padding-left:210px;" class="control-group ">
    <label class="control-label" for="title">
        <strong>
            <asp:Label ID="TypeName" runat="server" Text=""></asp:Label></strong>
    </label>
</div>
    
    
</div>

            <div id="J_Price">
               <div   style="padding-left:110px;" class="control-group ">
    <label class="control-label" for="price">
        <strong>类型编号：</strong>
    </label>
    <div class="controls">
        <div class="input-wrap input-append">
            <asp:Label ID="SmallTypeId" runat="server" Text="Label"></asp:Label>
			        </div>
    </div>
</div>
<div   style="padding-left:110px;" class="control-group ">
    <label class="control-label" for="price">
        <strong>类型名称：</strong>
    </label>
    <div class="controls">
        <div class="input-wrap input-append">
            <input id="SmallTypeName" runat="server" type="text" class="input J_PriceCheck" name="ProductNum" value="" />
	    </div>
    </div>
</div>
	

               


               


            </div>
            
			
            
            
			
</div>

            

            <div class="control-group">
                <div class="controls">
                    <asp:Button style=" background-color:Green;" ID="event_submit_do_publish"  class="btn btn-green btn-publish" 
                        runat="server" Text="立即修改" onclick="event_submit_do_publish_Click"  />
                </div>
            </div>
</asp:Content>

