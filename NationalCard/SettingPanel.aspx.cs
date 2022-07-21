using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HNP.Security.Difinition;

public partial class SettingPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null || Session["User"].GetType().FullName != "HNP.Security.Difinition.User")
        {
            Response.Redirect("~/Login.aspx");
        }

        //if (!IsPostBack)
        //{
        //    User user = (User)Session["User"];
        //    UserGroup obj = SecurityCollections.UserGroup.GetByUserID(user.UserID);
        //    if (obj != null)
        //    {
        //        foreach (ActivityGroup act in SecurityCollections.ActivityGroup.GetByGroupID(obj.Group.GroupID))
        //        {
        //            TreeView1.Nodes.Remove(new TreeNode(""));
        //        }
        //    }
        //}
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode.ChildNodes.Count == 0)
            Response.Redirect(TreeView1.SelectedNode.Target);
    }
}
