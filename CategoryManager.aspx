<%@ Page Title="" Language="C#" MasterPageFile="~/ShowShoppingCartMasterPage.master" AutoEventWireup="true" CodeFile="CategoryManager.aspx.cs" Inherits="CategoryManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="1000px;" align="center" border="0px">
    <asp:Repeater ID="reType" runat="server" onitemdatabound="reType_ItemDataBound" 
        onitemcreated="reType_ItemCreated">
        <ItemTemplate>
        <asp:Label ID="lbTypeId" runat="server" Text='<%#Eval("TypeId") %>' Visible="false"></asp:Label>
            <tr align="center"  style=" background-color:#088BB5; color:#941714;">
                <td colspan="3"><strong><%#Eval("TypeName") %></strong>
                    <asp:LinkButton  style=" font-size:15px; font-weight:bold;color:Yellow; padding-left:250px;" ID="addType" runat="server">添加<%#Eval("TypeName") %></asp:LinkButton></td>
             </tr>
             <tr align="center"  style=" background-color:#61C8F3;">
                <td>类别编号</td>
                <td>类别名称</td>
                <td>操作</td>
            </tr>
    <asp:Repeater ID="reSmallType" runat="server">
        <ItemTemplate>
         <asp:HiddenField ID="hiddenSmallTypeId" Value='<%# Eval("SmallTypeId")%>' runat="server" />
        <tr align="center" style=" background-color:#EDF8FE;">
            <td><%#Eval("SmallTypeId") %></td>
            <td><%#Eval("SmallTypeName") %></td>
            <td>
            <a href="CategoryEdit.aspx?SmallTypeId=<%#Eval("SmallTypeId") %>">修改</a>
                <asp:LinkButton ID="deleteSmallTypeName" CommandName="deleteP"  runat="server">删除</asp:LinkButton>
            </td>
        </tr>
        </ItemTemplate>
    </asp:Repeater>
     </ItemTemplate>
    </asp:Repeater>   
</table>
</asp:Content>

