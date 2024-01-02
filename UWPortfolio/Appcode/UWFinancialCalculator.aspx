<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UWFinancialCalculator.aspx.cs" Inherits="Appcode_UWFinancialCalculator" %>

<!DOCTYPE html>
<script runat="server">

    protected void gvITR_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvITRHeader_ItemCreated(object sender, RepeaterItemEventArgs e)
    {

    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../plugins/jQuery/jquery-2.2.3.min.js"></script>
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../dist/css/skins/_all-skins.min.css" rel="stylesheet" />
    <script src="../dist/js/html5shiv.min.js"></script>
    <script src="../dist/js/respond.min.js"></script>
    <link href="../dist/css/styles-app.css" rel="stylesheet" />
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />
    <link href="../plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script>
        if ($("html").hasClass("no-touch")) {
            $(document).on('keypress', '.Numeric', function (e) {
                var keycode = e.keyCode ? e.keyCode : e.which ? e.which : e.charCode;
                return ((keycode == 8 || keycode == 9) || (keycode >= 48 && keycode <= 57));
            });
        } else {
            $(document).on('keyup', '.Numeric', function (e) {

                this.value = this.value.replace(/[^\d\.\-]/g, '');
            });
        }
    </script>
</head>
<body>
    <form id="frmUWDashboardMedicalManagement" runat="server">
        <div id="Appdtls_container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-12">
                        <div class="col-md-6">
                            <h3 class="box-title ">UW Saral Medical Management Dashboard</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                </div>
            </div>
            <div id="Appdtls_containerBody" class="box-body">
                <div class="col-md-12 error-container-div">
                    <div class="col-md-12 ">
                        <div class="form-group">
                            <asp:Label ID="lblErrorUWFinancialCalculator" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Application Number</label>
                            <asp:TextBox runat="server" ID="txtApplicationNo" MaxLength="20" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Date Of Birth</label>
                            <asp:TextBox runat="server" ID="txtDateOfBirth" CssClass="form-control DatePicker" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Existing Insurance Cover</label>
                            <asp:TextBox runat="server" ID="txtExistingInsuranceCover" MaxLength="9" CssClass="form-control Numeric" autocomplete="off"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
            <br />
        </div>
        <div class="box box-warning box-solid ">
            </br>
            <div class="row">
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnSaveITRValues" Text="Calculate" OnClick="btnSaveITRValues_Click" CssClass="btn-primary btn" />
                </div>
            </div>
            </br>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <div class="table-responsive btn-block">
                            <asp:Repeater runat="server" ID="gvITR" OnItemDataBound="gvITR_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-bordered" style="overflow: auto; width: 100%;">
                                        <tr class="btn-primary ">
                                            <asp:Repeater ID="gvITRHeader" runat="server">
                                                <ItemTemplate>
                                                    <th align="left">
                                                        <asp:Label runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                                    </th>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="">
                                        <asp:Repeater ID="gvITItem" runat="server">
                                            <ItemTemplate>
                                                <td>
                                                    <asp:TextBox runat="server" CssClass="form-control Numeric" Text='<%# Container.DataItem %>'></asp:TextBox>
                                                </td>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <asp:DataGrid runat="server" ID="dgLiquidInvestment" HeaderStyle-CssClass="text-bold btn-primary" CssClass="table table-bordered" AutoGenerateColumns="false" OnItemDataBound="dgLiquidInvestment_ItemDataBound">
                            <%----%>
                            <Columns>
                                <asp:BoundColumn DataField="LiquidInvestmentkey"></asp:BoundColumn>
                                <asp:BoundColumn DataField="LiquidInvestment" HeaderText="Liquid Investment Category"></asp:BoundColumn>
                                <asp:TemplateColumn>
                                    <HeaderTemplate>
                                        Invested Amount
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" Text='<%#Eval("InvestedAmount")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 form-group">
                    <div class="table-responsive">
                        <asp:DataGrid runat="server" ID="dgShowCalculation" HeaderStyle-CssClass="text-bold btn-primary" AutoGenerateColumns="false" CssClass="table table-bordered">
                            <%----%>
                            <Columns>
                                <asp:BoundColumn DataField="TOTALINCOME" HeaderText="Total Income"></asp:BoundColumn>
                                <asp:BoundColumn DataField="AVERAGEINCOME" HeaderText="Average Income"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FINANCIALELIGIBILITY" HeaderText="Financial Eligibility"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Balance Eligibility</label>
                        <asp:TextBox runat="server" ID="txtBalanceEligibility" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Total Investment</label>
                        <asp:TextBox runat="server" ID="txtTotalInvestment" CssClass="form-control" Enabled="false" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Premium Paying Capacity</label>
                        <asp:TextBox runat="server" ID="txtPremiumPayingCapacity" CssClass="form-control" Enabled="false" autocomplete="off"></asp:TextBox>
                    </div>
                </div>
            </div>
            </br>
        </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $('.DatePicker').datepicker({
                autoclose: true,
                format: 'dd-mm-yyyy',
                onSelect: function (date) {
                }
            });
        })
    </script>
</body>
</html>
