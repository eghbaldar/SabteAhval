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

public partial class CreateInstance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCreateInstance_Click(object sender, EventArgs e)
    {
        foreach (ListItem lst in this.chklCreateInstance.Items)
        {
            if (lst.Selected)
            {
                switch (lst.Value.ToLower())
                {
                    case "pnationalcard":
                        PNationalCard.Definition.NCollections.CreateInstance();
                        break;
                    case "security":
                        HNP.Security.Difinition.SecurityCollections.CreateInstance();
                        break;
                }
            }
        }
    }
}
