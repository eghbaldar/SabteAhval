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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session.Remove("User");
        }
    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        foreach (User obj in SecurityCollections.User.GetAll)
        {
            if (obj.UserName.ToUpper() == Login1.UserName.ToUpper())
            {
                if (obj.Password == Login1.Password)
                {
                    Session["User"] = obj;
                    Response.Redirect("SettingPanel.aspx");
                }
            }
        }
    }
}
