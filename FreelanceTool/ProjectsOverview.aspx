<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsOverview.aspx.cs" Inherits="FreelanceTool.ProjectOverview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Projektübersicht - Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,700,300' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
               <h1 class="header__headline">Projektübersicht</h1>
            </div>
            <div class="content">
            <asp:Button ID="btnNewProject" CssClass="left" runat="server" Text="Neues Projekt" OnClick="btnNewProject_Click"/>
            <asp:Button ID="btnToCustomersOverview" CssClass="right" runat="server" Text="zur Kundenübersicht" OnClick="btnToCustomersOverview_Click"/><br /><br />
            <asp:GridView ID="GVProjects" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="false" 
                OnSelectedIndexChanged="GVProjects_SelectedIndexChanged" 
                EmptyDataText="Keine Projekte in der Datenbank">
                <Columns>
                    <asp:BoundField DataField="name" ItemStyle-CssClass="projectRow" HeaderText="Projektname" />
                    <asp:BoundField DataField="customerName" HeaderText="Kunde" />
                    <asp:ButtonField CommandName="Select" text="Details" ItemStyle-CssClass="buttonRow"/>
                </Columns>
            </asp:GridView>
            <br />
            </div>
        </div>
    </form>
</body>
</html>
