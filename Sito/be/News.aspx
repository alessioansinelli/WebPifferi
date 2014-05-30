<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="be_news" %>
<%@ Register Assembly="Moxiecode.TinyMCE" Namespace="Moxiecode.TinyMCE.Web" TagPrefix="TinyMCE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<%@ Register src="uc/menunews.ascx" tagname="menunews" tagprefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="frmNews">
<uc1:menunews ID="menunews1" runat="server" />
<asp:GridView ID="grdNews" runat="server" 
    EmptyDataText="Non sono presenti notizie" AutoGenerateColumns="False" 
    DataKeyNames="ID" onrowcommand="RowCommand">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" />
        <asp:TemplateField HeaderText="Homepage" ShowHeader="true" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="HomePage" Checked='<%# Eval("isHomeNews") %>' AutoPostback="true" OnCheckedChanged="CheckBox_CheckedChanged" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:ButtonField ButtonType="Link" CommandName="up" HeaderText="Su" ShowHeader="True" Text="Su" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:ButtonField ButtonType="Link" CommandName="down" HeaderText="Giù" ShowHeader="True" Text="Giù" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:BoundField DataField="Titolo" HeaderText="TITOLO" />
        <asp:BoundField DataField="SottoTitolo"  HeaderText="SOTTO TITOLO" />
        <asp:BoundField DataField="DataInserimento"  HeaderText="DATA CREAZIONE" />
        <asp:BoundField DataField="DataModifica" HeaderText="DATA MODIFICA" />
        <asp:ButtonField ButtonType="Link" CommandName="modifica" HeaderText="Modifica" ShowHeader="True" Text="Modifica" ItemStyle-HorizontalAlign="Center" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
        <asp:ButtonField ButtonType="Link" CommandName="elimina" HeaderText="Elimina" ShowHeader="True" Text="Elimina" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="eliminanews">
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
        </asp:ButtonField>
    </Columns>
</asp:GridView>
</form>
<script language="javascript" type="text/javascript">
        $(document).ready(function() {
            $('.eliminanews').click(function() {
                return (confirm('Eliminare definitivamente l\'elemento?'));
            });
        });
    </script>
</asp:Content>

