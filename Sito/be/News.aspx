<%@ Page Title="" Language="C#" MasterPageFile="~/be/be.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="be.BeNews" %>
<%@ Register Src="uc/menu.ascx" TagName="menu" TagPrefix="uc2" %>
<%@ Register Src="uc/menunews.ascx" TagName="menunews" TagPrefix="uc1" %>

<asp:Content ID="mnu" ContentPlaceHolderID="menu" runat="server">
    <uc2:menu ID="mnu1" runat="server" SelectedMenu="Notizie" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server" id="frmNews">
        <uc1:menunews ID="menunews1" runat="server" SelectedMenu="Notizie" />
        <asp:GridView ID="grdNews" runat="server"
            EmptyDataText="Non sono presenti notizie" AutoGenerateColumns="False"
            DataKeyNames="ID" OnRowCommand="RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:TemplateField HeaderText="Homepage" ShowHeader="true" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="HomePage" Checked='<%# Eval("isHomeNews") %>' AutoPostBack="true" OnCheckedChanged="CheckBox_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField ButtonType="Link" CommandName="up" HeaderText="Su" ShowHeader="True" Text="Su" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Link" CommandName="down" HeaderText="Giù" ShowHeader="True" Text="Giù" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:BoundField DataField="Titolo" HeaderText="TITOLO" />
                <asp:BoundField DataField="SottoTitolo" HeaderText="SOTTO TITOLO" />
                <asp:BoundField DataField="DataInserimento" HeaderText="DATA CREAZIONE" />
                <asp:BoundField DataField="DataModifica" HeaderText="DATA MODIFICA" />
                <asp:ButtonField ButtonType="Link" CommandName="modifica" HeaderText="Modifica" ShowHeader="True" Text="Modifica" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Link" CommandName="elimina" HeaderText="Elimina" ShowHeader="True" Text="Elimina" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="eliminanews">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
    </form>
</asp:Content>
<asp:Content ID="script" ContentPlaceHolderID="addScript" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.eliminanews').click(function () {
                return (confirm('Eliminare definitivamente l\'elemento?'));
            });
        });
    </script>
</asp:Content>

