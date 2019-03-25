<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="StoreDisplay.aspx.cs" Inherits="StoreDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<LINK href="style.css" type="text/css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div   align="center" id="open" runat="server"><span style=" color:Red; font-weight:bolder;">It is not approved by admin yet！！！</span></div>
<TABLE id="Table1" bgcolor="#fff" cellSpacing="0" cellPadding="1" width="960">
			<tr>
				<TD background="" height="33" colspan="3" align="left">
                    <asp:LinkButton style=" color:Red; padding-left:140px;" ID="storeModify" runat="server">Edit Store Details</asp:LinkButton>
				</TD>
			</tr>
			<tr bgcolor="#99001E"   style="height: 32px">
                <TD align=center><font color="#fff"><b>
                    <asp:Label ID="storeName" runat="server" Text="Label"></asp:Label></b></font></TD>
                <td ></td>
				<TD   align="center"><font color="#fff"><b>Store Introdution</b></font></TD>
			</tr>
			<TR>
				<TD align="center">
							<img width="259" height="110" id="shopLogo" name="shopLogo" src="" runat="server">
				</TD>
				<td width="175">
					<pre><B>Store Owner：</B><asp:Label ID="storeUser" runat="server" Text=""></asp:Label></pre>
					<pre><B>Date of Foundation：</B> <asp:Label ID="storeTime" runat="server" Text=""></asp:Label></pre>
					<pre><B>Location：</B> <asp:Label ID="storeAddress" runat="server" Text=""></asp:Label></pre>
				</td>
				<td background="images/storeIntro.jpg" valign="top" width="399" height="166"><b>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="StoreIntro" runat="server" Text=""></asp:Label></b>
				</td>
			</TR>
		</TABLE>
        <TABLE id="Table2" cellSpacing="1" cellPadding="1" bgcolor="" width="960">
			<tr height="25">
				<TD bgcolor="#99001E"  style="height: 32px" align="center"><font color="#fff"><b>Store Owner Recommendation</b></font></TD>
			</tr>
            <tr>
				<TD style="height: 50px"    runat="server" id="noExist" ><div   align="center"><span style=" color:Red; font-weight:bolder;">There are no recommended products~!!</span></div></TD>
			</tr>
			<tr>
				<TD align="center">
                <asp:Repeater ID="rptProducts" runat="server">
    <ItemTemplate>

<div   style="height: 250px"  class='cmimgfix' style='float:left; padding-left:10px;'><a style='' name='fwfw' title='<%# Eval("Name")%>' id='Default_ctl2' class='imgborder' href='infodetail.aspx?productid=<%# Eval("ProductId")%> '>
<img id='ProductImg'  width='150px' height='150px' src='showProductPicture.aspx?productid=<%# Eval("ProductId")%>' style='border-width:0px;'/></a>

<a style=''  id='Default_ctl28' href='infodetail.aspx?productid=<%# Eval("ProductId")%>'><%# Eval("Name")%></a><br>
<span style=" color:#a10101;font-size: 13px;" class='SalePrice'>¥<span id='Default_ctl30'><%# Eval("Price")%></span></span></div>

    </ItemTemplate>
    </asp:Repeater></TD>
			</tr>
			
		</TABLE>
</asp:Content>

