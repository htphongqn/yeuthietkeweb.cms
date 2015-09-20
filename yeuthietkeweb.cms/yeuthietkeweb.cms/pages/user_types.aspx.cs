using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class user_types : System.Web.UI.Page
    {
        private UserTypeRepo _UserTypeRepo = new UserTypeRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                if (user != null)
                {
                    string code = getUserTypeCode(user.UserTypeID);
                    if (code != "ADMIN")
                    {
                        Response.Write("<script>alert('Bạn không có quyền truy cập trang này!');location.href='login.aspx'</script>");
                    }
                }
                LoadData();
            }
        }

        public string getUserTypeCode(object userTypeId)
        {
            int typeid = Utils.CIntDef(userTypeId, 0);
            var userType = _UserTypeRepo.GetById(typeid);
            if (userType != null)
            {
                return userType.Code;
            }
            return "";
        }
        private void LoadData()
        {
            _UserTypeRepo = new UserTypeRepo();
            rptList.DataSource = _UserTypeRepo.GetAll();
            rptList.DataBind();
        }
        public string getLink(object id)
        {
            return "user_type.aspx?id=" + Utils.CIntDef(id, 0);
        }
        public string getLinkDelete(object id)
        {
            return "delete_user_type.aspx?id=" + Utils.CIntDef(id, 0);
        }
    }
}