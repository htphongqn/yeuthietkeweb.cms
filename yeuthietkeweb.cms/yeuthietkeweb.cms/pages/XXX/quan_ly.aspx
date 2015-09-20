<%@ Page Title="" Language="C#" MasterPageFile="~/master/Index.Master" AutoEventWireup="true" CodeBehind="quan_ly.aspx.cs" Inherits="dbShop.pages.quan_ly" %>
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
            <h1 class="page-header">Dành cho quản lý</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Quản lý
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
                "sDom": '<"top">rt<"bottom"ip><"clear">',
                responsive: true
            });
        });
    </script>
</asp:Content>
