using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlyToTheStar
{
    public partial class Rank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Repeater1.DataSource = BLL.RankBLL.Rank();
            this.Repeater1.DataBind();
        }
    }
}