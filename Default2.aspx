<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: small;
        }
        .style8
        {
            width: 68px;
            height: 61px;
        }
        .style11
        {
            width: 212px;
            font-size: 9pt;
            height: 58px;
            color: #0066FF;
        }
        .style12
        {
            font-size: 9pt;
            height: 58px;
            width: 98px;
        }
        .style13
        {
            width: 113px;
            font-size: small;
            height: 58px;
            color: #FF6600;
        }
        .style14
        {
            font-size: 9pt;
            height: 58px;
            width: 223px;
        }
        .style15
        {
            font-size: medium;
            text-align: center;
        }
        .style16
        {
            font-size: medium;
        }
        .style17
        {
            width: 69px;
            font-size: 9pt;
            height: 58px;
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        用户名：<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查询卖家信息" />
        <br />
        <br />
        用户名： 
        <asp:Label ID="Label3" runat="server" Text="usename"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="查询评价" />
        <br />
        <br />
        评价总数： 
        <asp:Label ID="pingjianum" runat="server" Text="评价总数"></asp:Label>
        <br />
        评价详情： 
        <asp:Label ID="评价详情" runat="server" Text="评价详情"></asp:Label>
        <br />
        订单编号： 
        <asp:Label ID="订单编号" runat="server" Text="订单编号"></asp:Label>
        <br />
        <br />
        买家信息： 
        <asp:Label ID="NamePhone" runat="server"></asp:Label>
        <br />
        地址： 
        <asp:Label ID="BuyerAddress" runat="server" Text="BuyerAddress"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
            Text="获取出售中的宝贝信息" />
        <br />
        <asp:Label ID="ItemsInfo" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
    <asp:DataList ID="DataList1" runat="server" BackColor="White" 
        BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" RepeatColumns="8">
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <ItemTemplate>
            <table width="180" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="180" height="180" align="center" valign="middle">&nbsp;<img src='<%#Eval("PicUrl") %>_160x160.jpg' width="160" height="160" alt='<%#Eval("title") %>' style="border:0" /></td>
              </tr>
              <tr>
                <td height="30">&nbsp;<%#Eval("title") %></td>
              </tr>
              <tr>
                <td height="30">&nbsp;价格：￥<%#Eval("Price")%>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("HasShowcase").ToString()%></td>
              </tr>
<%--              <tr>
                <td height="30">&nbsp;蘑菇街地址：<asp:Label ID="mogujiereturn" runat="server"></asp:Label></td>
              </tr>--%>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <p>
        &nbsp;</p>
    <p class="style1">
        请输入宝贝标题：<asp:TextBox ID="baobeiname" runat="server"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="蘑菇街收录查询" 
            onclick="Button4_Click1" />
    </p>
    <p>
        蘑菇街地址：
        <asp:Label ID="mogujiereturn" runat="server"></asp:Label>
    </p>
    <p>
        喜欢：<asp:Label ID="FavoriteNum" runat="server" Text="FavoriteNum"></asp:Label>
    </p>
    <p>
        发布日期： 
        <asp:Label ID="uploadDate" runat="server" Text="uploadDate"></asp:Label>
    </p>
    <p>
        <asp:Button ID="MogujieSearch" runat="server" Text="出售中的宝贝及收录情况" 
            onclick="Button5_Click" />
        <asp:Button ID="Getdate" runat="server" onclick="Getdate_Click" Text="查询发布日期" />
    </p>
    <p>
        您共有<asp:Label ID="baobeinumber" runat="server"></asp:Label>
        个出售中的宝贝</p>
    <p>
        搜索进度： 
        <asp:Label ID="sousuojindu" runat="server" Text="0"></asp:Label>
    </p>
    <asp:DataList ID="MogujieDataList" runat="server" RepeatColumns="1">
        <ItemTemplate>
            <table style="width: 101%; height: 54px;">
              <tr>
                <td class="style8">
                   <%#Eval("index") %> </td>
                  <td class="style8">
                      <img src='<%#Eval("PicUrl") %>_160x160.jpg' alt='<%#Eval("title") %>' 
                            style="border-style: none; border-color: inherit; border-width: 0; height: 70px; width: 70px;" />
                  </td>
                  <td class="style11">
                      <%#Eval("title") %></td>
                  <td class="style17">
                      &nbsp;</td>
                  <td class="style13">
                      <span class="style16"><strong>￥</strong></span><span class="style15"><strong><%#Eval("Price")%></strong></span></td>
                  <td class="style14">
                      <%#Eval("MogujieAddress")%></td>
                  <td class="style12">
                      喜欢：<%#Eval("MogujieFavNum")%></td>
              </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    </form>
</body>
</html>
