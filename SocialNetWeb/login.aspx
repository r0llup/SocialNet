<%@ Page Title="Login :: SocialNet" Language="C#" MasterPageFile="~/SocialNetWeb.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SocialNetWeb.LoginPage" %>
<asp:Content ID="titleContent" ContentPlaceHolderID="title" Runat="Server">  
    <title>Login :: SocialNet</title>  
</asp:Content>
<asp:Content ID="loginContent" ContentPlaceHolderID="loginPlaceHolder" Runat="Server">
    <div id="subcontent">
        <asp:Login ID="loginControl" runat="server" onauthenticate="LoginControl_Authenticate" onloggedin="LoginControl_LoggedIn">
            <CheckBoxStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#C8C8C8" />
            <HyperLinkStyle Font-Names="Verdana" Font-Size="10pt" />
            <InstructionTextStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#C8C8C8" />
            <LabelStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#C8C8C8" />
            <FailureTextStyle Font-Names="Verdana" Font-Size="10pt" />
            <LoginButtonStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#202020" />
            <TitleTextStyle Font-Names="Verdana" Font-Size="12pt" Font-Underline="True" ForeColor="#C8C8C8" Wrap="False" />
        </asp:Login>
    </div>
</asp:Content>