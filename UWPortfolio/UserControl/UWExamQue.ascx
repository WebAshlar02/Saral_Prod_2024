<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UWExamQue.ascx.cs" Inherits="UserControl_UWExamQue" %>

<style type="text/css">
    .auto-style1 {
        width: 324px;
    }
</style>

<script>
    function openBulkModal() {
        $('#divQueFileUpload').modal('show');
    }
</script>

<div id="divUWExamsQue" runat="server" class="panel box box-success">

    <div class="row">

        <div class="col-md-12 form-group">
            <div id="Div1" class="box-body" runat="server">
                <table class="table table-bordered" cellpadding="20" cellspacing="1">
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <label>KBQ Question Uploader<br />
                                </label>
                                &nbsp;<div class="form-group">
                                    <label>Select File</label>
                                    <asp:FileUpload ID="QueFileUploadExcel" class="DocFileUpload" runat="server" />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <asp:GridView ID="gvDecisionLog" CssClass="table table-bordered table-striped" runat="server"></asp:GridView>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />

                                    <asp:Button ID="btnQueUpload" runat="server" CssClass="button_search btn btn-primary" OnClientClick="return fnHasFile();" OnClick="btnQueUpload_Click"  Text="Upload Exams Que" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />
                                    <asp:Label runat="server" ID="lblMsg" Visible="false" Font-Bold="true" Font-Size="Medium" Text="" Style="float: left"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
             <div id="Div2" class="box-body" runat="server">
                <table class="table table-bordered" cellpadding="20" cellspacing="1">
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <label>Application wise Warning Message Uploader<br />
                                </label>
                                &nbsp;<div class="form-group">
                                    <label>Select File</label>
                                    <asp:FileUpload ID="AppWarningFileUpld" class="DocFileUpload" runat="server" />
                                </div>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <asp:GridView ID="gvDecisionLog" CssClass="table table-bordered table-striped" runat="server"></asp:GridView>
                                </div>
                            </div>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />

                                    <asp:Button ID="btnWarningUploader" runat="server" CssClass="button_search btn btn-primary" OnClientClick="return fnHasFile();" OnClick="btnWarningUploader_Click"  Text="Upload" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />
                                    <asp:Label runat="server" ID="lblappwarn" Visible="false" Font-Bold="true" Font-Size="Medium" Text="" Style="float: left"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
             <%--Kavita Start 23/01/2020 CR-27785 upload medical cost--%>
               <div id="Div4" class="box-body" runat="server">
                <table class="table table-bordered" cellpadding="20" cellspacing="1">
                    <tr>
                        <td class="auto-style3">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <label>
                                    Medical Cost Uploader<br />
                                </label>
                                <div  class="form-group">
                                    <asp:Button ID="btnDwnlodExcel" runat="server" CssClass="button_search btn btn-primary" Text="Download Excel Format"  OnClick="btnDwnlodExcel_Click" />
                                    <br />
                                    <br />
                                </div>
                                <div class="form-group">
                                    <label>Select File</label>
                                    <asp:FileUpload ID="MedCostUploaderFileUploader" class="DocFileUpload" runat="server"  />
                                    <br />
                                </div>
                            </div>


                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />
                                    <asp:Button ID="btnMedicalCost" runat="server" CssClass="button_search btn btn-primary" OnClick="btnMedicalCost_Click" Text="Upload" />
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <div class="col-xs-12 col-md-6 col-lg-6">
                                <div class="form-group">
                                    <br />
                                    <asp:Label runat="server" ID="lblMedWarn" Visible="false" Font-Bold="true" Font-Size="Medium" Text="" Style="float: left"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </div>

</div>
