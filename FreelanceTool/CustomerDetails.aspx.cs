using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO_FreelanceTool;

namespace FreelanceTool
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        string currentID;
        Customers currentCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentID = (string)Session["id"]; //wurde beim Aufruf übertragen
                if (currentID != "")
                {
                    //Objekt laden und Werte setzen
                    currentCustomer = Main.getCustomerByID(currentID);

                    if (currentCustomer != null)
                    {
                        //kopiere die Properties des Objekts in die Felder der Maske
                        //lblID.Text = currentProject.id;
                        txtNameCustomer.Text = currentCustomer.name;
                        txtTelCustomer.Text = currentCustomer.phone;
                        txtMailCustomer.Text = currentCustomer.mail;
                        Session["Customer"] = currentCustomer; //Projektobjekt in Session speichern
                        //btnDelete.Visible = true;
                    }
                    else
                    {
                        //lblError.Text = "Kunde nicht gefunden - Sie können einen neuen Kunden anlegen!";
                        //btnDelete.Visible = false;
                        //PlaceHolderKommentare.Visible = false;
                        Session["Customer"] = Main.newCustomer(); //neues leeres Kundenobjekt
                    }
                }
                else
                {
                    //leere ID? Dann ist das ein neuer Kunde
                    //btnDelete.Visible = false;
                    //PlaceHolderKommentare.Visible = false;
                    currentCustomer = Main.newCustomer();
                    Session["Customer"] = currentCustomer; //neues leeres Projektobjekt
                }
            }
            else
                currentCustomer = (Customers)Session["Customer"];

            if (currentCustomer != null)
            {
                GVAdresses.DataSource = currentCustomer.getAdresses;
                GVAdresses.DataBind(); //dadurch wirds angezeigt
            }
        }

        //Button zur Kundenverwaltung
        protected void btnToCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomersOverview.aspx"); //Redirect zur Kundenverwaltungseite
        }
    }
}