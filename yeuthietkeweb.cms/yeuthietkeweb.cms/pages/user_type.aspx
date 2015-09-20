<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.Master" AutoEventWireup="true" CodeBehind="user_type.aspx.cs" Inherits="dbShop.pages.user_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Loại tài khoản</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Chi tiết loại tài khoản
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <form>
                                <div class="form-group">
                                    <label>Code</label>
                                    <input id="txtCode" runat="server" class="form-control" disabled="disabled">
                                    <asp:RequiredFieldValidator ID="rqf1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtCode" ErrorMessage="Chưa nhập Code!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Loại tài khoản</label>
                                    <input id="txtName" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtName" ErrorMessage="Chưa nhập Loại tài khoản!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Sắp xếp</label>
                                    <input id="txtPos" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtPos" ErrorMessage="Chưa nhập sắp xếp!" Display="None">*</asp:RequiredFieldValidator>
                                </div>                                
                                <div class="form-group">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-default"  ValidationGroup="g1" onclick="btnSave_Click" />
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default" Text="Trở lại" PostBackUrl="~/pages/user_types.aspx" />
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
