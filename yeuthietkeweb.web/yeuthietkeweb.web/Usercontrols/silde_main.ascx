﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="silde_main.ascx.cs" Inherits="yeuthietkeweb.UIs.silde_main" %>

<figure class="slider" role="slider">
  <div class="container">
    <div class="slider-wrapper theme-default">
      <div id="slider" class="nivoSlider">
        <asp:Repeater ID="rptAds" runat="server">
            <ItemTemplate>                 
                 <%# GetImageAd(Eval("AD_ITEM_ID"), Eval("AD_ITEM_FILENAME"), Eval("AD_ITEM_TARGET"), Eval("AD_ITEM_URL"), Eval("Ad_Item_Desc"))%>
            </ItemTemplate>
        </asp:Repeater> 
      </div>
    </div>
  </div>
</figure>