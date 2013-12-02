<%@ Page Title="" Language="C#" Trace="false" MasterPageFile="~/softlab/softwaregrocery.master" AutoEventWireup="true" CodeFile="taobao-search.aspx.cs" Inherits="softlab_taobao_search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 944px;
        }
    .search-form{margin:40px auto 0;width:591px;position:static;padding:0;}.search-form{margin:-67px 0 0 156px;width:604px;position:relative;padding-top:26px;}.search-tab{*zoom:1;}.search-tab{position:static;}.search-tab{position:absolute;left:0;top:0;z-index:2;}ul,ol{list-style:none;}
                .search-form .l{
                    background-image: url("http://img04.taobaocdn.com/tps/i4/T1lq38XddjXXXUJmrx-151-270.png");
                }
            .search-auto,.search-form .input,.search-tab li.selected,.search-tab li.selected .l,.search-tab li.selected .r,.search-form .l,.search-form form button,.search-form .r{background:url("http://img02.taobaocdn.com/tps/i2/T1qn0NXelCXXXXXXXX-151-270.png");}
                .search-form .r{
                    background-image: url("http://img04.taobaocdn.com/tps/i4/T1lq38XddjXXXUJmrx-151-270.png");
                }
                .search-auto{
                    background-image: url("http://img04.taobaocdn.com/tps/i4/T1lq38XddjXXXUJmrx-151-270.png");
                }
            .search-auto{padding:3px;background-color:#f57a04;background-position:0 -126px;width:594px;height:32px;position:relative;}.search-auto .l{background-position:-142px -27px;left:0;}.search-auto .l,.search-auto .r{width:3px;height:39px;position:absolute;top:0;}.search-auto .r{background-position:-148px -27px;right:0;}.search-form form .input{float:left;width:463px;height:32px;background-color:#fff;background-position:0 -68px;position:relative;}
                .search-form .input{
                    background-image: url("http://img04.taobaocdn.com/tps/i4/T1lq38XddjXXXUJmrx-151-270.png");
                }
                .search-form form button{
                    background-image: url("http://img04.taobaocdn.com/tps/i4/T1lq38XddjXXXUJmrx-151-270.png");
                }
            .search-form form button{background-color:#f57a04;background-position:0 -36px;width:131px;height:32px;text-indent:-9999px;border:none;float:left;}
        #title
        {
            height: 30px;
            width: 460px;
        }
        .style6
        {
            width: 309px;
            height: 98px;
        }
        .style8
        {
            height: 98px;
            width: 10px;
        }
        .style10
        {
            width: 10px;
        }
        .style11
        {
            width: 927px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    /p>
    <table class="style1">
        <tr>
            <td class="style8">
                </td>
            <td class="style6">
            </td>
        </tr>
        <tr>
            <td class="style10" rowspan="2">
                &nbsp;</td>
            <td class="style11">
                <br />
                <br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" 
                    style="margin-left: 181px; mn-right: 6px" Width="464px" Height="28px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="同款宝贝搜索" 
                    Height="29px" Width="98px" />
                <br />
              
            
              
                <br />
                <asp:Label ID="Label4" runat="server" Text="http://www.mogujie.com/book/bags/"></asp:Label>
                <br />
                <asp:Button ID="DownloadMogujiePage" runat="server" 
                    onclick="DownloadMogujiePage_Click" Text="下载蘑菇街大类页面源码" />
&nbsp; 输出文件： mogujiePage.htm<br />
                <br />
&nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="根据蘑菇街大类搜索宝贝地址" />
                &nbsp;&nbsp; 输入文件：mogujiePage.htm&nbsp;&nbsp;&nbsp; 输出文件： 1_mogujie_地址.txt<br />
                同款宝贝地址：&nbsp; 
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                    Text="根据蘑菇街大类搜索宝贝标题" />
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                输入文件：mogujiePage.htm&nbsp;&nbsp;&nbsp; 输出文件： 2_mogujie_标题.txt<br />
                <br />
                保留的字符串： 
                <asp:Label ID="baoliu" runat="server" 
                    Text="(?&lt;=title=\\&quot;).*?(?=\\&quot;&gt;&lt;)"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="baoliu12" runat="server" 
                    Text="(?&lt;=title=&quot;).{5,}(?=&quot;\&gt;\&lt;\/a)"></asp:Label>
                <br />
                删掉的字符串：&nbsp; 
                <asp:Label ID="shandiao" runat="server" Text="(\\u).{1,3}-.*?(?=\\u)"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                    Text="根据标题列表获得淘客地址" />
                &nbsp;输入文件： 2_mogujie_标题.txt&nbsp; 输出文件： 3_mogujie_标题+链接.txt ， 4_mogujie_短链接.txt<br />
                <br />
                <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="发评论" />
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style11">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

