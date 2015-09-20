using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class quan_ly : System.Web.UI.Page
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
                    //ADMIN
                    //KETOANVIEN
                    //QUANLY
                    //GIAONHAN
                    string code = getUserTypeCode(user.UserTypeID);
                    if (code != "ADMIN" && code != "QUANLY")
                    {
                        Response.Write("<script>alert('Bạn không có quyền truy cập trang này!');location.href='login.aspx'</script>");
                    }
                }
                loadData();
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
        private void loadData()
        {
            var list = (from a in _db.Congties
                        join b in _db.Uploads on a.ID equals b.CongtyID
                        where a.MASOTHUE == txtMasothue.Value || txtMasothue.Value == ""
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
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            loadData();
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