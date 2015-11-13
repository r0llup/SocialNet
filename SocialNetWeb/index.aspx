<%@ Page Title="Index :: SocialNet" Language="C#" MasterPageFile="~/SocialNetWeb.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SocialNetWeb.IndexPage" %>
<asp:Content ID="titleContent" ContentPlaceHolderID="title" Runat="Server">  
    <title>Index :: SocialNet</title>  
</asp:Content> 
<asp:Content ID="indexContent" ContentPlaceHolderID="indexPlaceHolder" Runat="Server">
    <object id="carousel" data="data:application/x-silverlight-2," type="application/x-silverlight-2">
        <param name="source" value="ClientBin/SocialNetSilverlight.xap"/>
        <param name="onError" value="onSilverlightError" />
        <param name="background" value="#474747" />
        <param name="minRuntimeVersion" value="4.0.50826.0" />
        <param name="autoUpgrade" value="true" />
        <param name="pluginbackground" value="Transparent" /> 
        <param name="windowless" value="true" />
        <param name="initparams" id="initParams" runat="server" value="login=False"/>
        <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 	        <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
        </a>
    </object>
</asp:Content>