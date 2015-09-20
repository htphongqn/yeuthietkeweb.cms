<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.Master" AutoEventWireup="true" CodeBehind="ke_toan_vien.aspx.cs" Inherits="dbShop.pages.ke_toan_vien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<!-- DataTables CSS -->
    <link href="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" rel="stylesheet">
    <style>
        #tblFilter td
        {
            padding:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Dành cho kế toán viên</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Kế toán viên
                </div>
                <div class="panel-body">
                    <div class="dataTable_wrapper">
                        <div class="form-group">
                            <table id="tblFilter">
                                <tr>
                                    <td>
                                        <label>Mã số thuế</label>
                                        <input id="txtMasothue" runat="server" class="form-control">
                                    </td>
                                    <td>
                                        <label>Năm</label>
                                        <asp:DropDownList ID="ddlNam" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
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
                                    </td>
                                    <td>
                                        <label>#</label>
                                        <asp:Button ID="btnFilter" runat="server" Text="Lọc dữ liệu" CssClass="btn btn-default form-control" onclick="btnFilter_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>Mã số thuế</th>
                                    <th>Tên công ty</th>
                                    <th>Địa chỉ</th>
                                    <th>Năm</th>
                                    <th>Kỳ</th>
                                    <th>Files</th>
                                   <%-- <th>#</th>--%>
                                </tr>
                            </thead>
                            <tbody>                                
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr class="odd gradeX">
                                            <td><%# Eval("MASOTHUE")%></td>
                                            <td><%# Eval("TENCONGTY")%></td>
                                            <td><%# Eval("DIACHI")%></td>
                                            <td><%# Eval("NAM")%></td>
                                            <td><%# (Eval("KY"))%></td>
                                            <td><%# strFile(Eval("UploadID"), Eval("MASOTHUE"))%></td>
                                            <td class="center">
                                            <%--<a href='<%# getLink(DataBinder.Eval(Container.DataItem, "ID")) %>'>Chỉnh sửa</a> | <a href='<%# getLinkDelete(DataBinder.Eval(Container.DataItem, "ID")) %>'>Xóa</a>--%>
                                            </td>
                                        </tr>    
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <!-- /.table-responsive -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
<!-- DataTables JavaScript -->
    <script src="../bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <script src="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"></script>

    <!-- Page-Level Demo Scripts - Tables - Use for reference -->
    <script>
        $(document).ready(function () {
            $('#dataTables-example').DataTable({
                "sDom": '<"top">rt<"bottom"><"clear">',
                responsive: true
            });
        });
    </script>
</asp:Content>
