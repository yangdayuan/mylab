<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="baiduTinyURL.aspx.cs" Inherits="softlab_baiduTinyURL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
        URL：&nbsp; 
        <asp:TextBox ID="TextBox1" runat="server" Height="41px" Width="298px"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="转换成短网址" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        百度短网址： 
        <asp:TextBox ID="TextBox_baidu" runat="server" Width="308px"></asp:TextBox>
    </p>
    <p>
        Google 短网址： 
        <asp:TextBox ID="TextBox_google" runat="server" Width="289px"></asp:TextBox>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

