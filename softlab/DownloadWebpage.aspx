<%@ Page Title="" Language="C#" MasterPageFile="~/softlab/softwaregrocery.master" AutoEventWireup="true" CodeFile="DownloadWebpage.aspx.cs" Inherits="softwaregrocery_DownloadWebpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="738px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        style="margin-right: 0px" Text="通过GET命令下载页面" />
</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
<p>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="通过WebBrowser类下载页面" />
    <input id="Checkbox1" runat="server" checked type="checkbox" />&nbsp;Display form and 
    WebBrowser control</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

