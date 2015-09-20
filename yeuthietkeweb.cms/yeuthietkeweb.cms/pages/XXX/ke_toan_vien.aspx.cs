using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class ke_toan_vien : System.Web.UI.Page
    {
        private dbShopDataContext _db = new dbShopDataContext();
        private FileRepo _FileRepo = new FileRepo();
        private UserTypeRepo _UserTypeRepo = new UserTypeRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = (User)Session["user"];
                if (user != null)
                {
                    string code = getUserTypeCode(user.UserTypeID);
                    if (code != "ADMIN" && code != "QUANLY" && code != "KETOANVIEN")
                    {
                        Response.Write("<script>alert('Bạn không có quyền truy cập trang này!');location.href='login.aspx'</script>");
                    }
                }
                loadNam();
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
        private void loadNam()
        {
            for (int i = 2000; i <= DateTime.Now.Year; i++)
            {
                ddlNam.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlNam.Text = DateTime.Now.Year.ToString();
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var list = (from a in _db.Congties
                        join b in _db.Uploads on a.ID equals b.CongtyID
                        where a.MASOTHUE == txtMasothue.Value && b.NAM == Utils.CIntDef(ddlNam.SelectedItem.Value, 0) && b.KY == Utils.CIntDef(ddlKy.SelectedItem.Value, 0)
                        select new
                        {
                            a.MASOTHUE,
                            a.TENCONGTY,
                            a.DIACHI,
                            UploadID = b.ID,
                            b.NAM,
                            b.KY
                        });
            rptList.DataSource = list;
            rptList.DataBind();
        }
        public string strFile(object uploadId, object masothue)
        {
            int _uploadId = Utils.CIntDef(uploadId, 0);
            var list = _FileRepo.GetByUploadId(_uploadId);
            string s = "";
            foreach (var item in list)
            {
                string pathfile = "/Files/" + Utils.CStrDef(masothue, "");
                string fullpathfile = pathfile + "/" + item.Filename;
                s += "<a href='" + fullpathfile + "'>" + item.Filename + "</a><br/>";
            }
            return s;
        }
    }
}