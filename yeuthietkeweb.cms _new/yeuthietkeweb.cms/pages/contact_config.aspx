<%@ Page Title="" Language="C#" MasterPageFile="~/master/Site.Master" AutoEventWireup="true" CodeBehind="contact_config.aspx.cs" Inherits="yeuthietkeweb.cms.pages.contact_config" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMain" runat="server">
<div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Cấu hình liên hệ</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    Cấu hình liên hệ
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6" style="width:100%;">
                            <form>
                                <div class="form-group">
                                    <label>Thông tin liên hệ</label>
                                    <textarea id="mrk" cols="20" rows="10" class="mrk" style="height: 500px;" runat="server"></textarea>
                                </div>
                                <div class="form-group">
                                    <label>Thông tin liên hệ tiếng anh</label>
                                    <textarea id="mrke" cols="20" rows="10" class="mrk" style="height: 500px;" runat="server"></textarea>
                                </div>
                                <div class="form-group">
                                    <label>Cấu hình bản đồ</label>
                                    <textarea id="mrk1" cols="20" rows="10" class="mrk1" style="height: 500px;" runat="server"></textarea>
                                </div>
                                <div class="form-group" style="margin-bottom:0">
                                    <label><asp:Literal ID="lbMessage" runat="server" Text=""></asp:Literal></label>
                                </div>
                                <asp:Button ID="lbtSave" runat="server" Text="Lưu" CssClass="btn btn-default"  ValidationGroup="g1" onclick="lbtSave_Click" />
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
    <script src="../tinymce/js/tinymce/tinymce.min.js"></script>
    <script src="../js/TinymiceEditor.js" type="text/javascript"></script>
</asp:Content>
