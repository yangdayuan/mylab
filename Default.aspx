<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p>
            <asp:Label ID="LBdebug1" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="LBdebug2" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="LBdebug3" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            蘑菇街收录查询：</p>
    <p class="style1">
        请输入宝贝标题：(如果标题不完整可能搜索结果不准确)</p>
        <p class="style1">
            <asp:TextBox ID="baobeiname" runat="server" Height="23px" Width="430px"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="查询" 
            onclick="Button4_Click1" />
    </p>
    <p>
        蘑菇街地址：
        <asp:Label ID="mogujiereturn" runat="server"></asp:Label>
    </p>
    <p style="height: 20px">
        喜欢：<asp:Label ID="FavoriteNum" runat="server" Text="FavoriteNum"></asp:Label>
    </p>
    <p>
        发布日期： 
        <asp:Label ID="uploadDate" runat="server" Text="uploadDate"></asp:Label>
    </p>
        <p>
            &nbsp;</p>
        <hr />
        <p>
            &nbsp;</p>
        <p>
            宝贝在蘑菇街大分类页码查询：</p>
        <p>
            请选择宝贝在蘑菇街所属大类：<asp:DropDownList ID="DropDownList1" runat="server" 
                AutoPostBack="True" Height="25px" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="80px">
                <asp:ListItem>衣服</asp:ListItem>
                <asp:ListItem>鞋子</asp:ListItem>
                <asp:ListItem>包包</asp:ListItem>
                <asp:ListItem>配饰</asp:ListItem>
                <asp:ListItem>家居</asp:ListItem>
                <asp:ListItem>美妆</asp:ListItem>
            </asp:DropDownList>
&nbsp;英文：<asp:TextBox ID="TBmogujiedalei" runat="server"></asp:TextBox>
    </p>
        <p>
            请输入宝贝在蘑菇街地址，例如：http://www.mogujie.com/note/1aw6pse</p>
        <p>
            <asp:TextBox ID="Labelbaobeinote" runat="server" Height="28px" Width="432px"></asp:TextBox>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="查询" />
    </p>
        <p>
            查询结果：
    
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
    </div>
    <p>
    
        &nbsp;</p>
    <p>
    
        &nbsp;</p>
    </form>
</body>
</html>
