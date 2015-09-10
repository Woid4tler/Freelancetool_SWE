<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="FreelanceTool.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Kundenübersicht - Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Freelancetool - Kundenübersicht</h1>
            <asp:Button ID="btnToDefault" runat="server" Text="Projekteverwaltung" OnClick="btnToDefault_Click"/><br /><br />
            <asp:GridView ID="GVCustomers" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True" 
                BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                EmptyDataText="Keine Kunden in der Datenbank">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="phone" HeaderText="Tel." />
                    <asp:BoundField DataField="mail" HeaderText="E-Mail" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnNewCustomer" runat="server" Text="Neuen Kunden anlegen" OnClick="btnNewCustomer_Click"/><br />
        </div>
    </form>
</body>
</html>
