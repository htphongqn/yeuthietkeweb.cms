﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vpro.functions;
using GiaNguyen.Components;
using Controller;

namespace yeuthietkeweb.UIs
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        #region Declare
        Search_result search = new Search_result();
        Function fun = new Function();
        Pageindex_chage change = new Pageindex_chage();
        Product_Details pro_detail = new Product_Details();
        string _txt = string.Empty;
        int _page = 0;
        clsFormat fm = new clsFormat();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            _page = Utils.CIntDef(Request.QueryString["page"]);
            _txt = Utils.CStrDef(Request.QueryString["keyword"]);
            if (!IsPostBack)
            {
                Load_list();
            }
        }
        #region Loadsearch
        public void Load_list()
        {
            try
            {
                int _sotin = 25;

                if (_txt == "Nhập từ khóa tìm kiếm…")
                {
                    _txt = "";
                }
                else
                {
                    if (!_txt.Contains("%"))
                        _txt = "%" + _txt + "%";
                }
                var _vNews = search.Load_search_result(_txt, -1);
                if (_vNews.ToList().Count > 0)
                {
                    if (_page != 0)
                    {

                        Rplistnews.DataSource = _vNews.Skip(_sotin * _page - _sotin).Take(_sotin);
                        Rplistnews.DataBind();
                    }
                    else
                    {
                        Rplistnews.DataSource = _vNews.Take(_sotin);
                        Rplistnews.DataBind();
                    }
                    ltrPage.Text = change.result(_vNews.ToList().Count, _sotin, _txt, 0, _page, 2);
                }


            }
            catch (Exception ex)
            {

                clsVproErrorHandler.HandlerError(ex);
            }
        }

        public string GetPrice(object News_Price1)
        {
            try
            {
                return fun.Getprice(News_Price1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetLink(object News_Url, object News_Seo_Url, object cat_seo)
        {
            try
            {
                return fun.Getlink_News(News_Url, News_Seo_Url, cat_seo);
            }
            catch (Exception ex)
            {
                vpro.functions.clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT(object News_Id, object News_Image1)
        {

            try
            {
                return fun.GetImageT_News(News_Id, News_Image1);
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string getDate(object News_PublishDate)
        {
            return fun.getDate(News_PublishDate);
        }
        public string Getprice(object price)
        {
            return fun.Getprice(price);
        }
        #endregion
        protected void Rplistnews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddCart")
            {
                string _sNews_Seo_Url = Utils.CStrDef(e.CommandArgument);
                var list = pro_detail.Load_Product_Detail(_sNews_Seo_Url);
                if (list.Count > 0)
                {
                    if (Utils.CDecDef(list[0].NEWS_PRICE1) != 0)
                        Response.Redirect("~/Resources/Addtocart.aspx?id=" + list[0].NEWS_ID + "&quantity=1");
                }
            }
        }
    }
}