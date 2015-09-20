using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class delete_user : System.Web.UI.Page
    {
        private UserRepo _UserRepo = new UserRepo();
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
                LoadInfo();
            }
        }
        private void LoadInfo()
        {
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserRepo = new UserRepo();
            User item = _UserRepo.GetById(id);
            if (item != null)
            {
                lbTen.Text = item.Username;
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
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (!chkChacchan.Checked)
            {
                lbMessage.Text = "Bạn chưa đồng ý chắc chắn xóa!";
                return;
            }
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserRepo = new UserRepo();
            _UserRepo.Remove(id);
            Response.Redirect("~/pages/users.aspx");
        }
        public string formatDate(object date)
        {
            return string.Format("{0:dd/MM/yyyy}", date);
        }
    }
}