<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="dbShop.pages.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Tài khoản</h1>
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
                        <div class="col-lg-6">
                            <form>
                                <div class="form-group">
                                    <label>Tên đăng nhập</label>
                                    <input id="txtTendangnhap" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="rqf1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtTendangnhap" ErrorMessage="Chưa nhập Tên đăng nhập!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Mật khẩu</label>
                                    <input id="txtMatkhau" runat="server" type="password" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtMatkhau" ErrorMessage="Chưa nhập Mật khẩu!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Nhập lại mật khẩu</label>
                                    <input id="txtNhaplaiMatkhau" runat="server" type="password" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtNhaplaiMatkhau" ErrorMessage="Chưa nhập lại mật khẩu!" Display="None">*</asp:RequiredFieldValidator>

                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="g1"
                                        ErrorMessage="Nhập lại mật khẩu không đúng!" ControlToCompare="txtMatkhau" 
                                        ControlToValidate="txtNhaplaiMatkhau" Display="None" ForeColor="Red">*</asp:CompareValidator>
                                </div>
                                <div class="form-group">
                                    <label>Họ tên</label>
                                    <input id="txtFullname" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtFullname" ErrorMessage="Chưa nhập họ tên!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Số điện thoại</label>
                                    <input id="txtPhone" runat="server" class="form-control">
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ</label>
                                    <input id="txtAddress" runat="server" class="form-control">
                                </div>                                
                                <div class="form-group">
                                    <label>Loại tài khoản</label>
                                    <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control" DataTextField="Name" DataValueField="ID">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Kích hoạt</label>
                                    <asp:DropDownList ID="ddlKichhoat" runat="server" CssClass="form-control">
                                        <asp:ListItem Value= "1" Selected="True">True</asp:ListItem>
                                        <asp:ListItem Value= "0">False</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group" style="margin-bottom:0">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-default"  ValidationGroup="g1" onclick="btnSave_Click" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" Text="Trở lại" PostBackUrl="~/pages/users.aspx" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ShowMessageBox="True" ShowSummary="False" ValidationGroup="g1" />
                            </form>
                        </div>
                        <!-- /.col-lg-6 (nested) -->

                        <!-- /.col-lg-6 (nested) -->
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
</asp:Content>
