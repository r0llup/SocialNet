using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetServiceReference;

namespace SocialNetWeb
{
    public partial class EventsPage : Page
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public HashSet<Event> EventsCollection { get; private set; }
        public DataTable EventsTable { get; private set; }
        public String Username { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = this.Request.Path;
            this.Username = Session["login"] as String;
            if (this.Username != null)
            {
                this.WcfProxy = new SocialNetServiceClient();
                this.EventsCollection = new HashSet<Event>();
                this.EventsTable = new DataTable();
                this.EventsTable.Columns.Add(new DataColumn("Name", typeof(String)));
                this.EventsTable.Columns.Add(new DataColumn("Category", typeof(String)));
                this.EventsTable.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));
                this.EventsTable.Columns.Add(new DataColumn("EndDate", typeof(DateTime)));
                this.EventsTable.Columns.Add(new DataColumn("Description", typeof(String)));
                this.EventsTable.Columns.Add(new DataColumn("Photo", typeof(String)));
                this.EventsTable.Columns.Add(new DataColumn("State", typeof(String)));
                this.EventsTable.Columns.Add(new DataColumn("User", typeof(String)));
                this.FillGrid(false);
            }
            else
                Response.Redirect("~/login.aspx");
        }

        protected void insertIntoEventsTable(Event e)
        {
            DataRow dr = this.EventsTable.NewRow();
            dr["Name"] = e.Nom;
            dr["Category"] = e.Categorie;
            dr["StartDate"] = e.DateDebut;
            dr["EndDate"] = e.DateFin;
            dr["Description"] = e.Description;
            dr["Photo"] = ResolveUrl(e.Photo);
            dr["State"] = e.Statut;
            dr["User"] = e.User;
            this.EventsTable.Rows.Add(dr);
        }

        protected void FillGrid(Boolean force)
        {
            this.EventsCollection = new HashSet<Event>(this.WcfProxy.ListRelatedEvents(this.Username));
            this.EventsTable.Clear();
            if (this.EventsCollection != null)
            {
                foreach (Event e in this.EventsCollection)
                    this.insertIntoEventsTable(e);
            }
            this.insertIntoEventsTable(new Event()
            {
                Nom = "",
                Categorie = "",
                DateDebut = DateTime.Now,
                DateFin = DateTime.Now,
                Description = "",
                Photo = "",
                Statut = "",
                User = this.Username
            });
            this.eventsGridView.DataSource = this.EventsTable;
            if (!this.IsPostBack || force)
                this.eventsGridView.DataBind();
        }

        protected void eventsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String oldName = this.EventsTable.Rows[(this.eventsGridView.PageIndex * this.eventsGridView.PageSize) + e.RowIndex]["Name"] as String;
            String newName = (this.eventsGridView.Rows[e.RowIndex].FindControl("nameTextBox") as TextBox).Text as String;
            String newCategory = (this.eventsGridView.Rows[e.RowIndex].FindControl("categoryTextBox") as TextBox).Text as String;
            String newStartDate = (this.eventsGridView.Rows[e.RowIndex].FindControl("startDateTextBox") as TextBox).Text as String;
            String newEndDate = (this.eventsGridView.Rows[e.RowIndex].FindControl("endDateTextBox") as TextBox).Text as String;
            String newDescription = (this.eventsGridView.Rows[e.RowIndex].FindControl("descriptionTextBox") as TextBox).Text as String;
            String newPhoto = (this.eventsGridView.Rows[e.RowIndex].FindControl("photoTextBox") as TextBox).Text as String;
            String newState = (this.eventsGridView.Rows[e.RowIndex].FindControl("stateTextBox") as TextBox).Text as String;
            String newUser = (this.eventsGridView.Rows[e.RowIndex].FindControl("userLabel") as Label).Text as String;
            if (oldName.Equals(""))
                this.WcfProxy.AddEvents(newName, newCategory, DateTime.Parse(newStartDate),
                    DateTime.Parse(newEndDate), newDescription, newPhoto, newState, newUser);
            else
                this.WcfProxy.UpdateEvents(oldName, newName, newCategory, DateTime.Parse(newStartDate),
                    DateTime.Parse(newEndDate), newDescription, newPhoto, newState, newUser);
            this.eventsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void eventsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.eventsGridView.EditIndex = e.NewEditIndex;
            this.FillGrid(false);
        }

        protected void eventsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.eventsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void eventsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                String oldName = (this.eventsGridView.Rows[e.RowIndex].FindControl("nameLabel") as Label).Text as String;
                if (!oldName.Equals(""))
                    this.WcfProxy.DeleteEvents(oldName);
                this.FillGrid(true);
            }
            catch (Exception)
            {
                /*FIXME*/
            }
        }

        protected void eventsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.eventsGridView.PageIndex = e.NewPageIndex;
            this.FillGrid(true);
        }

        protected void eventsGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#474747'");
            e.Row.Attributes.Add("onMouseOut", "this.style.background='#202020'");
        }
    }
}