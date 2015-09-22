﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using vpro.functions;

namespace yeuthietkeweb.UIs
{
    public partial class header : System.Web.UI.UserControl
    {
        #region Decclare
        Propertity per = new Propertity();
        Function fun = new Function();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_logo();
            }
        }
        protected void load_logo()
        {
            var _logoSlogan = per.Load_logo_and_sologan(2);
            if (_logoSlogan.ToList().Count > 0)
            {
                rptLogo.DataSource = _logoSlogan;
                rptLogo.DataBind();
            }
        }        
        public string Getbanner(object Banner_type, object banner_field, object Banner_ID, object Banner_Image)
        {
            return fun.Getbanner(Banner_type, banner_field, Banner_ID, Banner_Image);
        }        
    }
}