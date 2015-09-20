using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class user_type : System.Web.UI.Page
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
                LoadInfo();
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
        private void LoadInfo()
        {
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserTypeRepo = new UserTypeRepo();
            UserType item = _UserTypeRepo.GetById(id);
            if (item != null)
            {
                txtCode.Disabled = true;
                txtCode.Value = item.Code;
                txtName.Value = item.Name;
                txtPos.Value = Utils.CStrDef(item.Pos, "");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Utils.CIntDef(Request.QueryString["id"], 0);
            _UserTypeRepo = new UserTypeRepo();
            UserType item = _UserTypeRepo.GetById(id);
            if (item != null)
            {
                item.Name = txtName.Value;
                item.Pos = Utils.CIntDef(txtPos.Value, 0);                
                _UserTypeRepo.Update(item);
            }
            else
            {
            }
            Response.Redirect("~/pages/user_types.aspx");
        }
        public string formatDate(object date)
        {
            return string.Format("{0:dd/MM/yyyy}", date);
        }
    }
}