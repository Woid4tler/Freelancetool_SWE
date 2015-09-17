<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="FreelanceTool.ProjectDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Freelancetool</title>
    <link rel="stylesheet" href="styles.css" />
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,700,300' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="header">
           <h1 class="header__headline">Projektdetails</h1>
        </div>
        <div class="content">
            <asp:Label ID="lblError" CssClass="error" runat="server" Font-Bold="True"></asp:Label>
<<<<<<< HEAD
            <asp:Button ID="btnToProjectsOverview" runat="server" CssClass="right" Text="zur Projektübersicht" OnClick="btnToProjectsOverview_Click" CausesValidation="False"/><br /><br />
            <h2>PROJEKT <asp:Label runat="server" ID="lblProjekttitle"></asp:Label><asp:Label ID="lblDateCreate" CssClass="right dateHeading" runat="server"></asp:Label></h2>
=======
            <asp:Button ID="btnToProjectsOverview" runat="server" CssClass="right" Text="zur Projektübersicht" OnClick="btnToProjectsOverview_Click"/><br /><br />
            <h2>PROJEKT <asp:Label runat="server" ID="lblProjekttitle"></asp:Label></h2>
>>>>>>> origin/master
            <asp:Table runat="server" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell CssClass="labelCell">
                        <asp:Label runat="server" Text="Name:"></asp:Label><br />
                        <asp:Label runat="server" Text="Kunde:"></asp:Label><br />
                        <asp:Label runat="server" Text="Ziel-Datum:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtNameProject" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" CssClass="errorMessages" runat="server" ControlToValidate="txtNameProject" ErrorMessage="Name fehlt"></asp:RequiredFieldValidator><br />
                        <asp:DropDownList ID="ddlCustomer" runat="server"></asp:DropDownList><br />
                        <asp:TextBox ID="txtDateEnd" runat="server"></asp:TextBox>
                        <asp:Label runat="server" CssClass="errorMessages" ID="lblDateNotValid"></asp:Label>
                    </asp:TableCell>
<<<<<<< HEAD
                    <asp:TableCell CssClass="buttonCell">
                        <asp:Button ID="btnSaveProject" runat="server" Text="Speichern" OnClick="btnSaveProject_Click" /><br />
                        <asp:Button CausesValidation="False" ID="btnCancel" runat="server" Text="Abbrechen" OnClick="btnCancel_Click" /><br />
=======
                    <asp:TableCell CssClass="buttonRow">
                        <asp:Button ID="btnSaveProject" runat="server" Text="Speichern" OnClick="btnSaveProject_Click" /><br /><br />
>>>>>>> origin/master
                        <asp:Button ID="btnDeleteProject" runat="server" Text="Löschen" OnClick="btnDeleteProject_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:Table runat="server" ID="tblNewTask" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell CssClass="labelCell"><asp:Label runat="server" Text="Neuer Task:"></asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtNewTask" runat="server"></asp:TextBox></asp:TableCell>
                    <asp:TableCell CssClass="buttonCell"><asp:Button ID="btnNewTask" runat="server" Text="Hinzufügen" OnClick="btnNewTask_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:Table runat="server" ID="tblNewComment" cellspacing="0">
                <asp:TableRow>
                    <asp:TableCell CssClass="labelCell">
                        <asp:Label runat="server" Text="Task:"></asp:Label><br />
                        <asp:Label runat="server" Text="Kommentar zum Task:"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="ddlTask" runat="server"></asp:DropDownList><br />
                        <asp:TextBox ID="txtNewComment" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell CssClass="buttonCell"><asp:Button ID="Button1" runat="server" Text="Hinzufügen" OnClick="btnNewComment_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:GridView ID="GVTasks" runat="server"
                AutoGenerateColumns="False"
                EmptyDataText="Keine Tasks gespeichert" 
                onrowdatabound="GVTasks_BoundComments" OnRowDeleting="GVTasks_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Tasks" ItemStyle-CssClass="labelCell taskCell"/>
                    <asp:TemplateField HeaderText="Kommentare" ItemStyle-CssClass="commentsCell">
                        <ItemTemplate>
                            <asp:GridView ID="GVComments" runat="server"
                                AutoGenerateColumns="False" ShowHeader="false">
                                <Columns>
                                    <asp:BoundField DataField="text"/>
                                    <asp:BoundField DataField="dateString" ItemStyle-CssClass="date"/>
                                </Columns>
<<<<<<< HEAD
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:ButtonField CommandName="Delete" text="Löschen" ItemStyle-CssClass="buttonCell"/>
=======
                            </asp:GridView><br />
                            <asp:Table runat="server" cellspacing="0">
                                <asp:TableRow>
                                    <asp:TableCell><asp:TextBox ID="txtNewComment" runat="server"></asp:TextBox></asp:TableCell>
                                    <asp:TableCell CssClass="buttonRow"><asp:Button ID="btnNewComment" runat="server" Text="Hinzufügen" OnClick="btnNewComment_Click"/></asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:ButtonField CommandName="Delete" text="Löschen" ItemStyle-CssClass="buttonRow"/>
>>>>>>> origin/master
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
