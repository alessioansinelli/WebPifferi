<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true"
    CodeFile="photogalleryedit.aspx.cs" Inherits="be_photogalleryedit" ValidateRequest="false" %>
<%@ Register Src="uc/menunews.ascx" TagName="menunews" TagPrefix="uc1" %>
<%@ Register src="uc/ucoggetto.ascx" tagname="ucoggetto" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" id="frmNews">
        <uc2:ucoggetto ID="ucnews1" runat="server" TipoOggetto="Photogallery"  />
    </form>
</asp:Content>
