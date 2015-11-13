using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetServiceReference;

namespace SocialNetWeb
{
    public partial class RecordsPage : Page
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public HashSet<Record> RecordsCollection { get; private set; }
        public LinkedList<String> EventsNameCollection { get; private set; }
        public DataTable RecordsTable { get; private set; }
        public String Username { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = this.Request.Path;
            this.Username = Session["login"] as String;
            if (this.Username != null)
            {
                this.WcfProxy = new SocialNetServiceClient();
                this.RecordsCollection = new HashSet<Record>();
                this.EventsNameCollection = new LinkedList<String>();
                this.RecordsTable = new DataTable();
                this.RecordsTable.Columns.Add(new DataColumn("Event", typeof(String)));
                this.RecordsTable.Columns.Add(new DataColumn("User", typeof(String)));
                this.FillGrid(false);
            }
            else
                Response.Redirect("~/login.aspx");
        }

        protected void insertIntoRecordsTable(Record r)
        {
            DataRow dr = this.RecordsTable.NewRow();
            dr["Event"] = r.Event;
            dr["User"] = r.User;
            this.RecordsTable.Rows.Add(dr);
        }

        protected void FillGrid(Boolean force)
        {
            this.RecordsCollection = new HashSet<Record>(this.WcfProxy.ListRelatedRecords(this.Username));
            this.EventsNameCollection = new LinkedList<String>(this.WcfProxy.ListEventsName());
            this.RecordsTable.Clear();
            if (this.RecordsCollection != null)
            {
                foreach (Record r in this.RecordsCollection)
                    this.insertIntoRecordsTable(r);
            }
            this.insertIntoRecordsTable(new Record()
            {
                Event = "",
                User = this.Username
            });
            this.recordsGridView.DataSource = this.RecordsTable;
            if (!this.IsPostBack || force)
            {
                this.recordsGridView.DataBind();
                for (int index = 0; index < this.recordsGridView.Rows.Count; index++)
                {
                    DropDownList eventDropDownList = this.recordsGridView.Rows[index].FindControl("eventDropDownList") as DropDownList;
                    eventDropDownList.DataSource = this.EventsNameCollection;
                    eventDropDownList.DataBind();
                    eventDropDownList.SelectedValue = this.RecordsTable.Rows[index]["Event"] as String;
                }
            }
        }

        protected void recordsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String oldEvent = this.RecordsTable.Rows[(this.recordsGridView.PageIndex * this.recordsGridView.PageSize) + e.RowIndex]["Event"] as String;
            String newEvent = (this.recordsGridView.Rows[e.RowIndex].FindControl("eventDropDownList") as DropDownList).SelectedValue as String;
            String oldUser = this.RecordsTable.Rows[e.RowIndex]["User"] as String;
            String newUser = (this.recordsGridView.Rows[e.RowIndex].FindControl("userLabel") as Label).Text as String;
            if (oldEvent.Equals(""))
                this.WcfProxy.AddRecords(newEvent, newUser);
            else
                this.WcfProxy.UpdateRecords(oldEvent, oldUser, newEvent, newUser);
            this.recordsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void recordsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.recordsGridView.EditIndex = e.NewEditIndex;
            this.FillGrid(false);
        }

        protected void recordsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.recordsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void recordsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                String oldEvent = (this.recordsGridView.Rows[e.RowIndex].FindControl("eventDropDownList") as DropDownList).SelectedValue as String;
                String oldUser = (this.recordsGridView.Rows[e.RowIndex].FindControl("userLabel") as Label).Text as String;
                if (!oldEvent.Equals(""))
                    this.WcfProxy.DeleteRecords(oldEvent, oldUser);
                this.FillGrid(true);
            }
            catch (Exception)
            {
                /*FIXME*/
            }
        }

        protected void recordsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.recordsGridView.PageIndex = e.NewPageIndex;
            this.FillGrid(true);
        }

        protected void recordsGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#474747'");
            e.Row.Attributes.Add("onMouseOut", "this.style.background='#202020'");
        }
    }
}