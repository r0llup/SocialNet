using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetServiceReference;

namespace SocialNetWeb
{
    public partial class CommentsPage : Page
    {
        public SocialNetServiceClient WcfProxy { get; private set; }
        public HashSet<Comment> CommentsCollection { get; private set; }
        public Dictionary<String, String> EventsNamePhotoCollection { get; private set; }
        public DataTable CommentsTable { get; private set; }
        public String Username { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["currentPage"] = this.Request.Path;
            this.Username = Session["login"] as String;
            if (this.Username != null)
            {
                this.WcfProxy = new SocialNetServiceClient();
                this.CommentsCollection = new HashSet<Comment>();
                this.EventsNamePhotoCollection = new Dictionary<String, String>();
                this.CommentsTable = new DataTable();
                this.CommentsTable.Columns.Add(new DataColumn("Event", typeof(String)));
                this.CommentsTable.Columns.Add(new DataColumn("User", typeof(String)));
                this.CommentsTable.Columns.Add(new DataColumn("Photo", typeof(String)));
                this.CommentsTable.Columns.Add(new DataColumn("Commentary", typeof(String)));
                this.FillGrid(false);
            }
            else
                Response.Redirect("~/login.aspx");
        }

        protected void insertIntoCommentsTable(Comment c)
        {
            DataRow dr = this.CommentsTable.NewRow();
            dr["Event"] = c.Event;
            dr["User"] = c.User;
            dr["Photo"] = c.Photo;
            dr["Commentary"] = c.Commentaire;
            this.CommentsTable.Rows.Add(dr);
        }

        protected void FillGrid(Boolean force)
        {
            this.CommentsCollection = new HashSet<Comment>(this.WcfProxy.ListRelatedComments(this.Username));
            this.EventsNamePhotoCollection = this.WcfProxy.ListEventsNamePhoto();
            this.CommentsTable.Clear();
            if (this.CommentsCollection != null)
            {
                foreach (Comment c in this.CommentsCollection)
                    this.insertIntoCommentsTable(c);
            }
            this.insertIntoCommentsTable(new Comment()
            {
                Event = "",
                User = this.Username,
                Photo = "",
                Commentaire = ""
            });
            this.commentsGridView.DataSource = this.CommentsTable;
            if (!this.IsPostBack || force)
            {
                this.commentsGridView.DataBind();
                for (int index = 0; index < this.commentsGridView.Rows.Count; index++)
                {
                    DropDownList eventDropDownList = this.commentsGridView.Rows[index].FindControl("eventDropDownList") as DropDownList;
                    eventDropDownList.DataSource = this.EventsNamePhotoCollection.Keys;
                    eventDropDownList.DataBind();
                    eventDropDownList.SelectedValue = this.CommentsTable.Rows[index]["Event"] as String;
                    HyperLink photoHyperlink = this.commentsGridView.Rows[index].FindControl("photoHyperlink") as HyperLink;
                    photoHyperlink.NavigateUrl = this.EventsNamePhotoCollection[eventDropDownList.SelectedValue];
                    Image photoImage = this.commentsGridView.Rows[index].FindControl("photoImage") as Image;
                    photoImage.ImageUrl = photoHyperlink.NavigateUrl;
                }
            }
        }

        protected void commentsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String oldEvent = this.CommentsTable.Rows[(this.commentsGridView.PageIndex * this.commentsGridView.PageSize) + e.RowIndex]["Event"] as String;
            String newEvent = (this.commentsGridView.Rows[e.RowIndex].FindControl("eventDropDownList") as DropDownList).SelectedValue as String;
            String oldUser = this.CommentsTable.Rows[e.RowIndex]["User"] as String;
            String newUser = (this.commentsGridView.Rows[e.RowIndex].FindControl("userLabel") as Label).Text as String;
            String newPhoto = (this.commentsGridView.Rows[e.RowIndex].FindControl("photoHyperLink") as HyperLink).NavigateUrl as String;
            String newCommentary = (this.commentsGridView.Rows[e.RowIndex].FindControl("commentaryTextBox") as TextBox).Text as String;
            if (oldEvent.Equals(""))
                this.WcfProxy.AddComments(newEvent, newUser, newPhoto, newCommentary);
            else
                this.WcfProxy.UpdateComments(oldEvent, oldUser, newEvent, newUser, newPhoto, newCommentary);
            this.commentsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void commentsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.commentsGridView.EditIndex = e.NewEditIndex;
            this.FillGrid(false);
        }

        protected void commentsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.commentsGridView.EditIndex = -1;
            this.FillGrid(true);
        }

        protected void commentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                String oldEvent = (this.commentsGridView.Rows[e.RowIndex].FindControl("eventDropDownList") as DropDownList).SelectedValue as String;
                String oldUser = (this.commentsGridView.Rows[e.RowIndex].FindControl("userLabel") as Label).Text as String;
                if (!oldEvent.Equals(""))
                    this.WcfProxy.DeleteComments(oldEvent, oldUser);
                this.FillGrid(true);
            }
            catch (Exception)
            {
                /*FIXME*/
            }
        }

        protected void commentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.commentsGridView.PageIndex = e.NewPageIndex;
            this.FillGrid(true);
        }

        protected void commentsGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.background='#474747'");
            e.Row.Attributes.Add("onMouseOut", "this.style.background='#202020'");
        }
    }
}