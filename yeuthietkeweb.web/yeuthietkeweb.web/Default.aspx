﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/SiteVI.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="yeuthietkeweb.Default" %>
<%@ Register src="Usercontrols/main.ascx" tagname="main" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltrFavicon" runat="server" EnableViewState="false"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentRight" runat="server">
    <uc1:main ID="main1" runat="server" />
</asp:Content>
