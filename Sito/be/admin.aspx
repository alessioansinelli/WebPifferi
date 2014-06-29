<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="be_admin" %>
<%@ Register Src="~/be/uc/menu.ascx" TagPrefix="uc1" TagName="menu" %>

<asp:Content ID="ContentMenu" ContentPlaceHolderID="menu" runat="server">
    <uc1:menu runat="server" ID="menu" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>



