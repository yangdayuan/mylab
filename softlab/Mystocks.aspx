<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mystocks.aspx.cs" Inherits="Mystocks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>投资评级</title>
    <style type="text/css">

        td,input{ font-size:12px; font-size:12px; font-family:"ËÎÌå";
            background-color: #FFFFFF;
        }


a:link,a:visited{ color: #000; text-decoration: none;}
        .style2
        {
            font-size: medium;
        }
        .style4
        {
            width: 100%;
        }
    </style>
</head>
<body style="text-align: center; color: #003366; background-color: #FFFFFF;">
    <form id="form1" runat="server">
    <div style="font-size: small">
    
			    <br />
                <table class="style4">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
    
			    <table cellspacing="1" cellpadding="0" bgcolor="#e0e0e0" border="0" 
            style="border-width:0px; height: 117px; width: 99%;" align="center">
	<tr class="td1">
		<td class="style2">序号</td><td class="style2"><a href="javascript:pSort('STOCK_CODE',1)" target="_self">股票代码</a></td>
        <td class="style2">股票简称</td><td colspan="5" class="style2">投资评级</td>
        <td class="style2"><a href="javascript:pSort('RPT_COUNT',1)" target="_self">报告总数</a></td>
        <td class="style2"><a href="javascript:pSort('STATDATE',0)" target="_self">更新日↓</a></td>
        <td class="style2">相关功能</td>
	</tr><tr class="td1">
		<td></td><td></td><td></td><td class="style2"><a href="javascript:pSort('RATING1_NUM',1)" target="_self">买入</a></td>
                        <td class="style2"><a href="javascript:pSort('RATING2_NUM',1)" target="_self">增持</a></td>
                        <td class="style2"><a href="javascript:pSort('RATING3_NUM',1)" target="_self">中性</a></td>
                        <td class="style2"><a href="javascript:pSort('RATING4_NUM',1)" target="_self">减持</a></td>
                        <td class="style2"><a href="javascript:pSort('RATING5_NUM',1)" target="_self">卖出</a></td><td></td><td></td><td></td>
	</tr>

        <asp:Label ID="Label1" runat="server"></asp:Label>


</table>
    
    </div>







    </form>




</body>
</html>
