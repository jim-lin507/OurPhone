<%@ Page Language="C#" AutoEventWireup="true" CodeFile="total.aspx.cs" Inherits="total" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.6.1.min.js"></script> 
<script  type="text/javascript">
    $(function () {
        $(".add").click(function () {
            var t = $(this).parent().find('input[class*=text_box]');
            t.val(parseInt(t.val()) + 1)
            setTotal();
        })
        $(".min").click(function () {
            var t = $(this).parent().find('input[class*=text_box]');
            t.val(parseInt(t.val()) - 1)
            if (parseInt(t.val()) < 0) {
                t.val(0);
            }
            setTotal();
        })
        function setTotal() {
            var s = 0;
            $("#tab td").each(function () {
                s += parseInt($(this).find('input[class*=text_box]').val()) * parseFloat($(this).find('span[class*=price]').text());
            });
            $("#total").html(s.toFixed(2));
        }
        setTotal();

    }) 
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="tab"> 
<tr> 
<td> 
<span>单价:</span><span class="price">1.50</span> 
<input class="min" name="" type="button" value="-" /> 
<input class="text_box" name="" type="text" value="1" /> 
<input class="add" name="" type="button" value="+" /> 
</td> 
</tr> 
<tr> 
<td> 
<span>单价:</span><span class="price">3.95</span> 
<input class="min" name="" type="button" value="-" /> 
<input class="text_box" name="" id="num2" type="text" value="" runat="server" /> 
<input class="add" name="" type="button" value="+" /> 
</td> 
</tr> 
</table> 
<p>总价：<label id="total"></label></p> 

    </div>
    </form>
</body>
</html>
