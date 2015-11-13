<%@ Page Title="My Events :: SocialNet" Language="C#" MasterPageFile="~/SocialNetWeb.Master" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="SocialNetWeb.EventsPage" %>
<asp:Content ID="titleContent" ContentPlaceHolderID="title" Runat="Server">  
    <title>My Events :: SocialNet</title>  
</asp:Content>
<asp:Content ID="eventsContent" ContentPlaceHolderID="eventsPlaceHolder" runat="server">
    <div id="subcontent">
        <asp:GridView ID="eventsGridView" runat="server" AllowPaging="True" 
            AllowSorting="True"
            HorizontalAlign="Center" BorderStyle="Solid" BorderColor="#C8C8C8" 
            AutoGenerateColumns="False" Width="100%" 
            onrowupdating="eventsGridView_RowUpdating" 
            onrowcancelingedit="eventsGridView_RowCancelingEdit" 
            onrowdeleting="eventsGridView_RowDeleting" 
            onrowediting="eventsGridView_RowEditing" 
            onpageindexchanging="eventsGridView_PageIndexChanging" 
            onrowcreated="eventsGridView_RowCreated">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category">
                    <EditItemTemplate>
                        <asp:TextBox ID="categoryTextBox" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="categoryLabel" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Start Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="startDateTextBox" runat="server" Text='<%# Bind("StartDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="startDateLabel" runat="server" Text='<%# Bind("StartDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="End Date">
                    <EditItemTemplate>
                        <asp:TextBox ID="endDateTextBox" runat="server" Text='<%# Bind("EndDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="endDateLabel" runat="server" Text='<%# Bind("EndDate", "{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                        <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="descriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Photo">
                    <EditItemTemplate>
                        <asp:TextBox ID="photoTextBox" runat="server" Text='<%# Bind("Photo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <style>.thumbnail img { width: 50px; height: 50px }</style>
                        <asp:HyperLink ID="photoHyperLink" runat="server" CssClass="thumbnail" Text='<%# Bind("Photo") %>' ImageUrl='<%# Bind("Photo") %>' NavigateUrl='<%# Bind("Photo") %>' Target="_search">
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="State">
                    <EditItemTemplate>
                        <asp:TextBox ID="stateTextBox" runat="server" Text='<%# Bind("State") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="stateLabel" runat="server" Text='<%# Bind("State") %>'></asp:Label>
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