<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jenkins_report.aspx.cs" Inherits="softlab_jenkins_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 559px;
        }
        .style3
        {
            width: 948px;
        }
        .style13
        {
            width: 263px;
            height: 23px;
            font-size: 11pt;
        }
        .style14
        {
            width: 136px;
            height: 23px;
        }
        .style19
        {
            height: 23px;
            width: 137px;
        }
        .style24
        {
            width: 37px;
        }
        .style25
        {
            width: 263px;
            height: 18px;
            font-size: 11pt;
        }
        .style26
        {
            width: 136px;
            height: 18px;
        }
        .style28
        {
            height: 18px;
            width: 137px;
        }
        .style31
        {
            width: 263px;
            height: 13px;
            font-size: 11pt;
        }
        .style32
        {
            width: 136px;
            height: 13px;
        }
        .style34
        {
            width: 137px;
            height: 13px;
            font-size: 11pt;
        }
        .style38
        {
            width: 136px;
        }
        .style46
        {
            width: 37px;
            height: 26px;
        }
        .style47
        {
            height: 26px;
        }
        .style48
        {
            width: 263px;
            height: 28px;
        }
        .style49
        {
            width: 136px;
            height: 28px;
            font-size: 11pt;
        }
        .style52
        {
            width: 137px;
            height: 28px;
            font-size: 11pt;
        }
        .style55
        {
            width: 100%;
            height: 100%;
        }
        .style56
        {
            width: 267px;
        }
        .style62
        {
            width: 263px;
            font-size: 11pt;
        }
        .style68
        {
            width: 137px;
        }
        .style69
        {
            width: 37px;
            height: 453px;
        }
        .style70
        {
            width: 948px;
            height: 453px;
        }
        .style71
        {
            height: 453px;
        }
        .style72
        {
            width: 137px;
            font-size: 11pt;
        }
        .style73
        {
            width: 136px;
            font-size: 11pt;
        }
        .style74
        {
            font-size: 11pt;
        }
        .style75
        {
            height: 18px;
            width: 137px;
            font-size: 11pt;
        }
        .style76
        {
            width: 136px;
            height: 18px;
            font-size: 11pt;
        }
        .style77
        {
            height: 23px;
            width: 137px;
            font-size: 11pt;
        }
        .style78
        {
            width: 267px;
            font-size: 11pt;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style46">
                    </td>
                <td class="style47" colspan="2">
                    </td>
            </tr>
            <tr>
                <td class="style69">
                    </td>
                <td class="style70">
                    <table class="style55" style="border-collapse: collapse; border-spacing: 0px;">
                        <tr>
                            <td class="style78">
                                &nbsp;</td>
                            <td class="style73">
                                &nbsp;</td>
                            <td class="style73">
                                &nbsp;</td>
                            <td class="style73">
                                &nbsp;</td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style72">
                                &nbsp;</td>
                            <td class="style72">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style48" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Label ID="Datetime" runat="server" Text="Label" CssClass="style74"></asp:Label>
                            </td>
                            <td class="style49" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Trunk</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style49">
                                FB13.05</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style49">
                                FB13.11</td>
                            <td class="style52" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                FB12.11</td>
                            <td class="style52" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Trunk_ECL
                            </td>
                            <td class="style52" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                CA</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Lint</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_Lint" runat="server" CssClass="style74" Width="100%">
                                    <asp:HyperLink ID="uREC_Trunk_Lint_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1305_MAC_Lint" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1305_MAC_Lint_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1311_MAC_Lint" runat="server" CssClass="style74" 
                                    Height="100%">
                                    <asp:HyperLink ID="uREC_FB1311_MAC_Lint_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_DCMPS_Lint" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_DCMPS_Lint_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Dev_trunk_ECL_DCMPS_Lint" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Dev_trunk_ECL_DCMPS_Lint_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                KlocWork</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_Klocwork" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_Klocwork_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1305_MAC_Klocwork" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1305_MAC_Klocwork_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1311_Klocwork" runat="server" CssClass="style74" 
                                    Height="100%">
                                    <asp:HyperLink ID="uREC_FB1311_Klocwork_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_DCMPS_Klocwork" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_DCMPS_Klocwork_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Lib Build</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_DCMPS_Lib_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_DCMPS_Lib_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1305_DCMPS_Lib_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1305_DCMPS_Lib_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1311_DCMPS_Lib_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1311_DCMPS_Lib_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_DCMPS_Lib_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_DCMPS_Lib_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Dev_trunk_ECL_Lib_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Dev_trunk_ECL_Lib_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_CA_DCM_PS_BIN_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_CA_DCM_PS_BIN_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                UT Build</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1305_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1305_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1311_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1311_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Dev_trunk_ECL_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Dev_trunk_ECL_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_CA_UT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_CA_UT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                uREC UT jobs</td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Macro UT jobs</td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                OneSCT Build</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_OneSCT_Build_old" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_OneSCT_Build_old_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_fb1305_OneSCT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_fb1305_OneSCT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_FB1311_OneSCT_Build_old" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1311_OneSCT_Build_old_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_oneSCT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_oneSCT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Dev_trunk_ECL_oneSCT_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Dev_trunk_ECL_oneSCT_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_CA_OneSCT_CA_Cases_Build" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_CA_OneSCT_CA_Cases_Build_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                OneSCT Shock Test</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_OneSCT_ShockTest" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_OneSCT_ShockTest_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_fb1305_OneSCT_ShockTest" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_fb1305_OneSCT_ShockTest_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="uREC_fb1311_OneSCT_ShockTest" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_fb1311_OneSCT_ShockTest_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="FB1211_oneSCT_ShockTest" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1211_oneSCT_ShockTest_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Dev_trunk_ECL_oneSCT_Shock_Test" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="Dev_trunk_ECL_oneSCT_Shock_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="CA_ShockTest" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="CA_ShockTest_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                uREC Regression</td>
                            <td class="style14" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_OneSCT_Regression_Test" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_OneSCT_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style14" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_FB1305_OneSCT_Regression_Test_new" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1305_OneSCT_Regression_Test_new_HyperLink" 
    runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style14" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_FB1311_OneSCT_Regression_Test" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1311_OneSCT_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style77" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style77" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style19" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="CA_Regression_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="CA_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                                </td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Marco Regression</td>
                            <td class="style38" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Trunk_oneSCT_Regression_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Trunk_oneSCT_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="FB1305_oneSCT_Regression_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1305_oneSCT_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style38">
                                <asp:Panel ID="FB1311_oneSCT_Regression_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1311_oneSCT_Regression_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                        </tr>
                        <tr>
                            <td class="style25" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                uREC Regression
                                unstable</td>
                            <td class="style26" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_Trunk_OneSCT_Regression_Test_unstable_new" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="uREC_Trunk_OneSCT_Regression_Test_unstable_new_HyperLink" 
                                        runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style76" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style26" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_FB1311_OneSCT_Regression_Test_unstable_new" runat="server" 
                                    CssClass="style74">
                                    <asp:HyperLink ID="uREC_FB1311_OneSCT_Regression_Test_unstable_new_HyperLink" 
    runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style75" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style75" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style28" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="CA_Regression_Test_Unstable" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="CA_Regression_Test_Unstable_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                                </td>
                        </tr>
                        <tr>
                            <td class="style31" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                Marco Regression
                                unstable</td>
                            <td class="style32" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="Trunk_oneSCT_Unstable_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="Trunk_oneSCT_Unstable_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style32">
                                <asp:Panel ID="FB1305_oneSCT_Unstable_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1305_oneSCT_Unstable_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style32">
                                <asp:Panel ID="FB1311_oneSCT_Unstable_Test" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="FB1311_oneSCT_Unstable_Test_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                            <td class="style34" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style34" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style34" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <a href="https://beling19.china.nsn-net.net:8080/view/DEV/job/uREC_CA_EM_Codesync_LRC/">uREC_CA_EM_Codesync_LRC</a></td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                N/A</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                N/A</td>
                            <td class="style68" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                <asp:Panel ID="uREC_CA_EM_Codesync_LRC" runat="server" CssClass="style74">
                                    <asp:HyperLink ID="uREC_CA_EM_Codesync_LRC_HyperLink" runat="server">HyperLink</asp:HyperLink>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style62" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style73" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;" 
                                class="style73">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                            <td class="style72" 
                                style="margin: 0px; border-width: 1px; border-style: solid; border-spacing: 0px; border-collapse: collapse; table-layout: auto;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style56">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style56">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style38">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                            <td class="style68">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style71">
                    </td>
            </tr>
            <tr>
                <td class="style24">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="Debug_Label" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
