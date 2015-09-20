<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="top_menu.ascx.cs" Inherits="THVDev.UIs.top_menu" %>
<nav class="menu" role="navigation">
  <div class="container">
    <div class="navx"> <a href="#" id="pull" class="clearfix"><i class="openIco fa fa-align-justify"></i> <i class="closeIco fa fa-remove"></i></a>
      <ul>
        <asp:Repeater ID="Rpmenu" runat="server">
            <ItemTemplate>
                <li class='<%#GetStyleActive(Eval("cat_seo_url"),Eval("cat_url")) %>'>
                    <a href="<%#GetLink_Cat(Eval("cat_url"),Eval("cat_seo_url"))%>" title="<%#Eval("cat_name")%>">
                        <%#Eval("cat_name")%>
                    </a>
                <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Load_Menu2(Eval("Cat_ID")) %>'>
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="<%#GetLink_Cat(Eval("cat_url"),Eval("cat_seo_url"))%>" title="<%#Eval("cat_name")%>">                               
                            <%#Eval("cat_name")%>
                            </a>
                            <asp:Repeater ID="Repeater2" runat="server" DataSource='<%# Load_Menu2(Eval("Cat_ID")) %>'>
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <a href="<%#GetLink_Cat(Eval("cat_url"),Eval("cat_seo_url"))%>" title="<%#Eval("cat_name")%>">
                                        <%#Eval("cat_name")%>
                                        </a>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
            </ItemTemplate>
        </asp:Repeater>
      </ul>
    </div>
  </div>
</nav>