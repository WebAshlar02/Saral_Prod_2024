<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RiskAllocPendingCases.aspx.cs" Inherits="RiskAllocPendingCases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />--%>
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../dist/css/skins/_all-skins.min.css" rel="stylesheet" />
    <script src="../dist/js/html5shiv.min.js"></script>
    <script src="../dist/js/respond.min.js"></script>
    <link href="../dist/css/styles-app.css" rel="stylesheet" />
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />--%>

    <%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>--%>
    <script src="../plugins/jQueryUI/jquery-ui.js"></script>
    <%--<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>--%>
    <%--<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />--%>
    <link href="../plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>

    <script type="text/javascript">

        function CloseWindow() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div id="divLoadingDetails" runat="server" class="col-md-12">
            <br />
            <div id="LoadingDtls_container" class="box box-warning box-solid">
                <div class="box-header with-border">
                    <div class="col-md-12">
                        <div class="col-md-9">
                            <h3 class="box-title ">Risk Allocation</h3>
                            <i class="fa fa-hourglass-start"></i>
                        </div>
                    </div>
                    <div class="box-tools ">
                        <button type="button" class="btn btn-box-tool" data-widget="collapse">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                </div>
                <div class="box-body">
                    <div class="col-md-12">
                        <div class="col-md-12">
                            <div class="col-md-12>">
                                <asp:Label runat="server" ID="Label1" CssClass="label-info" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Application Number</label>
                                    <asp:TextBox ID="txtAppno" CssClass="form-control lblLable" Text="" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Vender Name</label>
                                    <asp:DropDownList ID="ddlvender" CssClass="form-control " runat="server">
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Total Premium</label>
                                    <asp:TextBox ID="txtTotalPremium" CssClass="form-control lblLable" Text="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Product Code</label>
                                    <asp:TextBox ID="txtProductCode" Enabled="false" CssClass="form-control lblLable" Text="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Product Name</label>
                                    <asp:DropDownList ID="ddlprodName" CssClass="form-control lblLable" OnSelectedIndexChanged="ddlprodName_SelectedIndexChanged" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                  
                                </div>
                            </div>
                                                       
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>FollowUp Code</label>
                                    <asp:DropDownList ID="ddlFollowUpCode" CssClass="form-control lblLable" OnSelectedIndexChanged="ddlprodName_SelectedIndexChanged" runat="server" ></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Status</label>
                                    <asp:DropDownList ID="ddlStatus" CssClass="form-control lblLable" OnSelectedIndexChanged="ddlprodName_SelectedIndexChanged" runat="server" ></asp:DropDownList>
                                  
                                </div>
                            </div>
                                                       
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>UW Comment</label>
                                    <asp:TextBox ID="txtUWComment" CssClass="form-control lblLable" Text="" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>RCU Report Decision</label>
                                    <asp:DropDownList ID="ddlRCUDecision" CssClass="form-control lblLable" runat="server" ></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkIsMailsend" Enabled="false" runat="server" /><br />
                                    <label>Is Mail Send</label>

                                </div>
                            </div>

                        </div>

                         <div class="col-md-12">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label>Comment</label>
                                    <asp:TextBox ID="txtComment" CssClass="form-control lblLable" Text="" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             </div>
                    </div>


                    <div class="col-md-12">
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="btnSave" CssClass="btn-primary HideControl" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn-primary HideControl" runat="server" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="javaScript:window.close(); return false;" />
                            </div>
                        </div>


                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
