<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="yeuthietkeweb.cms.pages.category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Chuyên mục</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Chi tiết tài khoản
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6" id="seo">
                            <form>
                                <div class="form-group">
                                    <asp:Label CssClass="user" ID="lblError" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Cấp chuyên mục</label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Mã</label>
                                    <input type="text" name="txtCode" id="txtCode" runat="server" class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <label>Tên chuyên mục</label>
                                    <input type="text" name="txtName" id="txtName" runat="server" class="form-control"
                                        onkeyup="ParseText(this);" onblur="ParseText(this);" />
                                </div>
                                <div class="form-group">
                                    <label>Mô tả</label>
                                    <textarea id="txtDesc" runat="server" onkeyup="ParseDesc(this);" class="form-control"
                                    onblur="ParseDesc(this);"></textarea>
                                </div>                                
                                <div class="form-group">
                                    <label>Liên kết</label>
                                    <input type="text" name="txtUrl" id="txtUrl" runat="server" class="form-control"/>
                                    <asp:DropDownList ID="ddlTarget" runat="server" class="form-control" style="margin-top: 10px;width: 80px;">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Số tin / 1 trang</label>
                                    <input type="text" name="txtpageItem" id="txtpageItem" runat="server" onblur="this.value=formatNumeric(this.value);"
                                        maxlength="4" value="12" class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <label>Hiển thị</label>
                                    <asp:RadioButtonList ID="rblStatus" runat="server" RepeatColumns="2">
                                        <asp:ListItem Text="Không" Value="0"></asp:ListItem>
                                        <asp:ListItem Selected="True" Text="Có" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Hiển thị trang chủ</label>
                                    <asp:RadioButtonList ID="rblCatPeriod" runat="server" RepeatColumns="2">
                                        <asp:ListItem Selected="True" Text="Không" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Có" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Kiểu hiển thị</label>
                                    <asp:RadioButtonList ID="rblCatType" runat="server" RepeatColumns="5">
                                        <asp:ListItem Text="Tin tức" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Vị trí</label>
                                    <asp:RadioButtonList ID="rblPos" runat="server" RepeatColumns="3">
                                        <asp:ListItem Selected="True" Text="Trên" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Trái" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Phải" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Hiển thị Footer</label>
                                    <asp:RadioButtonList ID="rblShowFooter" runat="server" RepeatColumns="2">
                                        <asp:ListItem Selected="True" Text="Không" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Có" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Hiển thị tức thời</label>
                                    <asp:RadioButtonList ID="rblShowItems" runat="server" RepeatColumns="2">
                                        <asp:ListItem Selected="True" Text="Không" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Có" Value="1"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Ngôn ngữ</label>
                                    <asp:RadioButtonList ID="rblLanguage" runat="server" RepeatColumns="2">
                                    </asp:RadioButtonList>
                                </div>
                                <div class="form-group">
                                    <label>Thứ tự</label>
                                    <input type="text" name="txtOrder" id="txtOrder" runat="server" onblur="this.value=formatNumeric(this.value);"
                                        maxlength="4" value="1" onkeyup="this.value=formatNumeric(this.value);" class="form-control"/>
                                </div>
                                <div class="form-group">
                                    <label>Thứ tự trang chủ</label>
                                    <input type="text" name="txtOrderPeriod" id="txtOrderPeriod" runat="server" onblur="this.value=formatNumeric(this.value);"
                                        maxlength="4" value="1" onkeyup="this.value=formatNumeric(this.value);" class="form-control"/>
                                </div>
                                <div class="form-group" id="trUploadImage1" runat="server">
                                    <label>Ảnh đại diện</label>
                                    <input id="fileImage1" type="file" name="fileImage1" size="50" runat="server" class="form-control"/>
                                </div>
                                <div class="form-group" id="trImage1" runat="server">
                                    <asp:ImageButton ID="btnDelete1" runat="server" ImageUrl="../images/delete_icon.gif"
                                        BorderWidth="0" Width="13px" OnClick="btnDelete1_Click" ToolTip="Xóa hình minh họa này">
                                    </asp:ImageButton>
                                    <asp:HyperLink runat="server" ID="hplImage1" Target="_blank"></asp:HyperLink><br />
                                    <img id="Image1" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label>SEO Title</label>
                                    <input type="text" name="txtSeoTitle" id="txtSeoTitle" runat="server" class="form-control"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vui lòng nhập SEO Title"
                                        Text="Vui lòng nhập Seo Title" ControlToValidate="txtSeoTitle" CssClass="errormes"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>SEO URL</label>
                                    <input type="text" name="txtSeoUrl" id="txtSeoUrl" runat="server" class="form-control"/>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Vui lòng nhập SEO URL"
                                        Text="Vui lòng nhập Seo URL" ControlToValidate="txtSeoUrl" CssClass="errormes"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>SEO Keyword</label>
                                    <textarea id="txtSeoKeyword" runat="server" class="form-control"></textarea>
                                </div>
                                <div class="form-group">
                                    <label>SEO Description</label>
                                    <textarea id="txtSeoDescription" runat="server" class="form-control"></textarea>
                                </div>
                                <div class="form-group" style="margin-bottom:0">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <asp:LinkButton ID="lbtDelete" runat="server" OnClick="lbtDelete_Click" OnClientClick="return confirm('Bạn có chắc chắn xóa không?');"
                                    CssClass="btn btn-default" CausesValidation="false">Xóa</asp:LinkButton>
                                <asp:LinkButton ID="lbtSaveNew" runat="server" OnClick="lbtSaveNew_Click" CssClass="btn btn-default">
                                    Lưu và thêm mới
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtSave" runat="server" OnClick="lbtSave_Click" CssClass="btn btn-default">Lưu</asp:LinkButton>
                                <a href="category_list.aspx" class="btn btn-default">
                                    Quay lại
                                </a>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" ValidationGroup="g1" />
                            </form>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="../js/jquery.min.1.7.2.js" type="text/javascript"></script>
    <script src="../js/JqueryCollapse/jquery.collapse.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        new jQueryCollapse($("#seo"), {
            query: 'div h2'
        });

        function ParseText(objsent) {
            ParseUrl(objsent, document.getElementById('ContentMain_txtSeoUrl'));
            document.getElementById('ContentMain_txtSeoTitle').value = objsent.value;
            document.getElementById('ContentMain_txtSeoKeyword').value = objsent.value;
            //document.getElementById('MainContent_txtSeoDescription').value = objsent.value;
        }
        function ParseTextEn(objsent) {
            ParseUrl(objsent, document.getElementById('ContentMain_txtSeoUrlEn'));
            document.getElementById('ContentMain_txtSeoTitleEn').value = objsent.value;
            document.getElementById('ContentMain_txtSeoKeywordEn').value = objsent.value;
            //document.getElementById('MainContent_txtSeoDescription').value = objsent.value;
        }
        function ParseDesc(objsent) {
            document.getElementById('ContentMain_txtSeoDescription').value = objsent.value;
        }
        function ParseDescEn(objsent) {
            document.getElementById('ContentMain_txtSeoDescriptionEn').value = objsent.value;
        }
    </script>
</asp:Content>