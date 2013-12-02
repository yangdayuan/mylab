<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Encoding.aspx.cs" Inherits="zahuopu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: large;
            color: #CC6600;
            font-family: 新宋体;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 494px;
        }
        .style4
        {
            width: 494px;
            height: 47px;
        }
        .style5
        {
            height: 47px;
        }
        .style6
        {
            width: 65px;
            height: 47px;
        }
        .style7
        {
            width: 65px;
        }
        .style8
        {
            height: 47px;
            width: 606px;
        }
        .style9
        {
            width: 606px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <table class="style2">
            <tr>
                <td class="style6">
                    &nbsp;</td>
                <td class="style4">
                </td>
                <td class="style8">
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style7" valign="top">
                    &nbsp;</td>
                <td class="style3" valign="top">
                    <strong><span class="style1">正则表达式的unicode编码转为汉字</span></strong><br />
                    <br />
                    举例：输入\u6843\u7ea2\u8272，转换后为：桃红色<br />
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Height="36px" Width="551px"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="转换" />
                    <br />
                    <br />
                    <br />
                    汉字： 
                    <asp:Label ID="hanzistring" runat="server"></asp:Label>
                </td>
                <td class="style9">
                    <span class="style1"><strong>汉字转为其他字符编码</strong></span><br />
                    <br />
                    <br />
    
        <asp:TextBox ID="TextBox1" runat="server" Height="36px" Width="574px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="转换" />
        <br />
        <br />
        unicode:<asp:Label ID="unicodestring" runat="server"></asp:Label>
    
                    <br />
                    <br />
                    unicodeFFFE:
                    <asp:Label ID="unicodeFFFEstring" runat="server"></asp:Label>
                    <br />
    
        <br />
        utf8:
        <asp:Label ID="utf8string" runat="server"></asp:Label>
                    <br />
        <br />
        gbk:
        <asp:Label ID="gbkstring" runat="server"></asp:Label>
                    <br />
        <br />
        big5:
        <asp:Label ID="big5string" runat="server"></asp:Label>
    
                    <br />
                    <br />
                    GBK包括所有的汉字，包括简体和繁体。而gb2312则只包括简体汉字，因此简体汉字转换gb2312的结果与gbk是一样的。<br />
                    <br />
                    gb2312:
                    <asp:Label ID="gb2312string" runat="server"></asp:Label>
                    <br />
                    <br />
                    gb3212
                    URL地址格式（数字0到9保持不变，空格转换成&#39;+&#39;）：<br />
                    <asp:Label ID="urlstring" runat="server"></asp:Label>
                    <br />
                    <br />
                    utf8 URL地址格式（数字0到9保持不变，空格转换成&#39;+&#39;）：<br />
                    <asp:Label ID="utf8urlstring" runat="server"></asp:Label>
                    <br />
                    <br />
                    ...........................</td>
                <td valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style7">
                    &nbsp;</td>
                <td class="style3">
                    <br />
                    <br />
                    正则表达式搜索<br />
                    <br />
                    <br />
                    在<br />
                    <asp:TextBox ID="TextBox4" runat="server" Height="29px" Width="321px"></asp:TextBox>
                    <br />
                    中搜索<br />
                    <br />
                    <asp:TextBox ID="TextBox3" runat="server" Height="31px" Width="324px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="搜索" />
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style9">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>

    <script src="http://s21.cnzz.com/stat.php?id=4989757&web_id=4989757&show=pic" language="JavaScript"></script>


</body>
</html>
