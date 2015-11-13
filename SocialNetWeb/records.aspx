<%@ Page Title="My Records :: SocialNet" Language="C#" MasterPageFile="~/SocialNetWeb.Master" AutoEventWireup="true" CodeBehind="records.aspx.cs" Inherits="SocialNetWeb.RecordsPage" %>
<asp:Content ID="titleContent" ContentPlaceHolderID="title" Runat="Server">  
    <title>My Records :: SocialNet</title>  
</asp:Content>
<asp:Content ID="recordsContent" ContentPlaceHolderID="recordsPlaceHolder" runat="server">
    <div id="subcontent">
        <asp:GridView ID="recordsGridView" runat="server" AllowPaging="True" 
            AllowSorting="True"
            HorizontalAlign="Center" BorderStyle="Solid" BorderColor="#C8C8C8" 
            AutoGenerateColumns="False" Width="100%" 
            onrowupdating="recordsGridView_RowUpdating" 
            onrowcancelingedit="recordsGridView_RowCancelingEdit" 
            onrowdeleting="recordsGridView_RowDeleting" 
            onrowediting="recordsGridView_RowEditing" 
            onpageindexchanging="recordsGridView_PageIndexChanging" 
            onrowcreated="recordsGridView_RowCreated">
            <Columns>
                <asp:TemplateField HeaderText="Event">
                    <EditItemTemplate>
                        <asp:DropDownList ID="eventDropDownList" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="eventDropDownList" runat="server" Enabled="false"></asp:DropDownList>	
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User">
                    <EditItemTemplate>
                        <asp:Label ID="userLabel" runat="server" Text='<%# Bind("User") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="userLabel" runat="server" Text='<%# Bind("User") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update" Font-Names="Verdana" Font-Size="10pt" Font-Underline="True"
                            ForeColor="#C8C8C8"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="CancelButton" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel" Font-Names="Verdana" Font-Size="10pt" Font-Underline="True"
                            ForeColor="#C8C8C8"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit" Font-Names="Verdana" Font-Size="10pt" Font-Underline="True"
                            ForeColor="#C8C8C8"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="True" 
                            CommandName="Delete" Text="Delete" Font-Names="Verdana" Font-Size="10pt" Font-Underline="True" 
                            ForeColor="#C8C8C8"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle Font-Names="Verdana" Font-Size="10pt" Font-Underline="True" 
                ForeColor="#C8C8C8" />
            <PagerStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#C8C8C8" />
            <RowStyle Font-Names="Verdana" Font-Size="10pt" ForeColor="#C8C8C8" 
                HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>