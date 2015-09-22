using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yeuthietkeweb.cms.pages
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        private void LoadData()
        {
            //=== Declare Info===//
            List<InfoData> l = new List<InfoData>();
            l.Add(new InfoData { Title = "Chuyên mục", Link = "../page/category_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Tin tức", Link = "../page/news_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Hình ảnh", Link = "../page/aditem_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Hỗ trợ trực tuyến", Link = "../page/online_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Liên hệ", Link = "../page/contact_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Quản trị", Link = "../page/user_list.aspx", Icon = "fa-tasks", Color = "panel-green" });
            l.Add(new InfoData { Title = "Cấu hình", Link = "../page/config_meta.aspx", Icon = "fa-support", Color = "panel-red" });
            //=== End Declare Info===//
            for (int i = 0; i < l.Count; i++)
            {
                liLoadData.Text += String.Format(@"<div class='col-lg-3 col-md-6'>
                        <div class='panel {0}'>
                        <div class='panel-heading'>
                        <div class='row'>
                        <div class='col-xs-3'><i class='fa fa-5x {1}'></i></div>
                        <div class='col-xs-9 text-right'>
                            <div class='huge'>{2}</div>
                            <div>{3}</div>
                        </div>
                    </div>
                </div>
                <a href='{4}'>
                    <div class='panel-footer'>
                        <span class='pull-left'>Chi tiết</span>
                        <span class='pull-right'><i class='fa fa-arrow-circle-right'></i></span>
                        <div class='clearfix'></div>
                    </div></a></div></div>",
                    l[i].Color, l[i].Icon, (i + 1), l[i].Title, l[i].Link);
            }
        }

        public class InfoData
        {
            public string Title { get; set; }
            public string Link { get; set; }
            public string Icon { get; set; }
            public string Color { get; set; }
        }
    }
}