<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FreelanceTool.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Projektübersicht - Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Freelancetool - Projekteübersicht</h1>
            <asp:Button ID="btnToCustomers" runat="server" Text="Kundenverwaltung" OnClick="btnToCustomers_Click"/><br /><br />
            <asp:GridView ID="GVProjects" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True" 
                OnSelectedIndexChanged="GVProjects_SelectedIndexChanged" 
                EmptyDataText="Keine Projekte in der Datenbank">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Projektname" />
                    <asp:BoundField DataField="customerName" HeaderText="Kunde" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnNewproject" runat="server" Text="Neues Projekt anlegen" OnClick="btnNewproject_Click"/><br />
        </div>
    </form>
</body>
</html>
