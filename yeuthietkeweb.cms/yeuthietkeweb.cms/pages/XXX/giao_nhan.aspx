<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.master" AutoEventWireup="true" CodeBehind="giao_nhan.aspx.cs" Inherits="dbShop.pages.giao_nhan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Dành cho giao nhận</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Giao nhận
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <form>                               
                                <div class="form-group" style="margin-bottom:0">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <div class="form-group">
                                    <label>Mã số thuế</label>
                                    <asp:TextBox ID="txtMasothue" runat="server" CssClass="form-control" 
                                        AutoPostBack="True" ontextchanged="txtMasothue_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqf1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtMasothue" ErrorMessage="Chưa nhập mã số thuế!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Tên công ty</label>
                                    <input id="txtTencongty" runat="server" class="form-control">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="g1"  ForeColor="Red" ControlToValidate="txtTencongty" ErrorMessage="Chưa nhập tên công ty!" Display="None">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Địa chỉ</label>
                                    <input id="txtAddress" runat="server" class="form-control">
                                </div>                               
                                <div class="form-group">
                                    <label>Năm</label>
                                    <asp:DropDownList ID="ddlNam" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Kỳ</label>
                                    <asp:DropDownList ID="ddlKy" runat="server" CssClass="form-control">
                                        <asp:ListItem Value= "1" Selected="True">T1</asp:ListItem>
                                        <asp:ListItem Value= "2">T2</asp:ListItem>
                                        <asp:ListItem Value= "3">T3</asp:ListItem>
                                        <asp:ListItem Value= "4">T4</asp:ListItem>
                                        <asp:ListItem Value= "5">T5</asp:ListItem>
                                        <asp:ListItem Value= "6">T6</asp:ListItem>
                                        <asp:ListItem Value= "7">T7</asp:ListItem>
                                        <asp:ListItem Value= "8">T8</asp:ListItem>
                                        <asp:ListItem Value= "9">T9</asp:ListItem>
                                        <asp:ListItem Value= "10">T10</asp:ListItem>
                                        <asp:ListItem Value= "11">T11</asp:ListItem>
                                        <asp:ListItem Value= "12">T12</asp:ListItem>
                                        <asp:ListItem Value= "13">Q1</asp:ListItem>
                                        <asp:ListItem Value= "14">Q2</asp:ListItem>
                                        <asp:ListItem Value= "15">Q3</asp:ListItem>
                                        <asp:ListItem Value= "16">Q4</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>Files input</label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" Multiple="Multiple" />
                                </div> 
                                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-default"  ValidationGroup="g1" onclick="btnSave_Click" />
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
