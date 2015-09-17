<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomersOverview.aspx.cs" Inherits="FreelanceTool.CustomersOverview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Kundenübersicht - Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,700,300' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
           <h1 class="header__headline">Kundenübersicht</h1>
        </div>
        <div class="content">
            <asp:Button ID="btnNewCustomer" runat="server" Text="Neuer Kunde" OnClick="btnNewCustomer_Click"/>
            <asp:Button ID="btnToProjectsOverview" runat="server" CssClass="right" Text="zur Projektübersicht" OnClick="btnToProjectsOverview_Click"/><br /><br />
            <asp:GridView ID="GVCustomers" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="False" 
                OnSelectedIndexChanged="GVCustomers_SelectedIndexChanged"
                EmptyDataText="Keine Kunden in der Datenbank">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="phone" HeaderText="Telefon" />
                    <asp:BoundField DataField="mail" HeaderText="E-Mail" />
                    <asp:ButtonField CommandName="Select" text="Details" ItemStyle-CssClass="buttonRow"/>
                </Columns>
            </asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
