<%@ Page Language="C#" MasterPageFile="~/IndexMasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" Title="Our Phone" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Repeater ID="rptProducts" runat="server"
        OnItemDataBound="rptProducts_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID="hiddenPrice" Value='<%# Eval("Price")%>' runat="server" />
            <asp:HiddenField ID="hiddenBargainPrice" Value='<%# Eval("BargainPrice")%>' runat="server" />
            <li>
                <div class='cmimgfix' >
                    <a name='fwfw' title='<%# Eval("Name")%>' id='Default_ctl2' class='imgborder' href='infodetail.aspx?productid=<%# Eval("ProductId")%> '>
                        <img id='ProductImg' width='150px' height='150px' src='showProductPicture.aspx?productid=<%# Eval("ProductId")%>' style='border-width: 0px;' /></a>
                </div>
                <div align="center" >
                    <a id='Default_ctl28' href='infodetail.aspx?productid=<%# Eval("ProductId")%>'><%# Eval("Name")%></a><br>
                    <span class='SalePrice'>¥<asp:Label ID="price" runat="server" Text='<%# Eval("Price")%>'></asp:Label></span>
                </div>
            </li>
        </ItemTemplate>
    </asp:Repeater>
    <div style="clear: both"></div>
    <div align="center">
        <webdiyer:AspNetPager ID="AspNetPager1" OnPageChanged="AspNetPager1_PageChanged" runat="server"
            HorizontalAlign="Center" Width="100%"
            meta:resourceKey="AspNetPager1" Style="font-size: 14px; padding-left: 50px;"
            AlwaysShow="false" FirstPageText="Home" LastPageText="End" NextPageText="Next"
            PrevPageText="Previous" SubmitButtonText="Go" SubmitButtonClass="submitBtn"
            CustomInfoStyle="font-size:14px;text-align:left;"
            InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; "
            TextBeforeInputBox="Go to" TextAfterInputBox="Page" PageIndexBoxType="TextBox"
            ShowPageIndexBox="Always" TextAfterPageIndexBox="Page"
            TextBeforePageIndexBox="Go to" Font-Size="14px" CustomInfoHTML=""
            ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%"
            PagingButtonSpacing="3px">
        </webdiyer:AspNetPager>

    </div>
</asp:Content>

