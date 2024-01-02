<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UW_Comments.aspx.cs" Inherits="Appcode_UWProductivity" %>

<%--added by Kavita for view medical data entry on  08 JAN 2020--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Src="~/UserControl/MedicalValues.ascx" TagPrefix="AfiCfiWU" TagName="MedicalValues" %>
<%--End--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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


    <%--Kavita --%>

    <link href="../plugins/jQuery/jquery-ui.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../dist/css/skins/_all-skins.min.css" rel="stylesheet" />
    <script src="../dist/js/html5shiv.min.js"></script>
    <script src="../dist/js/respond.min.js"></script>
    <link href="../dist/css/styles-app.css" rel="stylesheet" />
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />
    <%--<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <%--<script src="jquery-ui/ui/i18n/datepicker-de.js"></script>--%>

    <script src="../plugins/jQuery/jquery-ui.js"></script>
    <script src="../plugins/jQuery/datepicker.js"></script>

    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
        rel="Stylesheet" type="text/css" />



    <script type="text/javascript">
        function hideloading() {
            $("#loaderdiv").hide();
        }

        function showloading() {
            $("#loaderdiv").show();
        }

        $(window).load(function () {

            $('#loaderdiv').fadeOut();
        });

        //function LoaderPop()
        //{
        //    alert('Hi');
        //    $('#ldrModal').show();
        //}        
        function SetTarget() {
            document.forms[0].target = "_blank";
        }

        /*added by shri on 13 june 17 to open on same page*/
        function SetTargetToSelf() {
            document.forms[0].target = "_self";
        }

        /*added by shri on 30 oct 17 to open on policy enquiry*/
        <%--function fnPolicyEnquiery() {
            var enq = '<%=strPolicyEnquiery%>';
           window.open(enq, '_blank')
       }--%>

        /*end here*/

        $(document).ready(function () {
            //    $('#example1').DataTable({
            //        "order": [[9, "desc"]]
            //    });
                btnCollapse();

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () {

                if (!$.fn.DataTable.isDataTable('#example1')) {
                    $('#example1').dataTable({
                        "order": [[1, "desc"]]
                    });
                }
                $('.lnkButton').click(function () {
                    $('#loaderdiv').fadeIn();
                });
            });
            //$("#lnkCommondashbord").click();
            $('.lnkButton').click(function () {
                $('#loaderdiv').fadeIn();
            });

        })

        function fnHideShowButton(type) {
            $('#ModalCommon').html('');
            if (type == 'afi') {
                $('#btnAfiSubmit').show();
                $('#btnCfiSubmit').hide();
                $('#btnUWSubmit').hide();
                $('#ModalCommon').html('AFI');
            }
            else if (type == 'cfi') {
                $('#btnAfiSubmit').hide();
                $('#btnCfiSubmit').show();
                $('#btnUWSubmit').hide();
                $('#ModalCommon').html('CFI');
            }
            else if (type = 'uw') {
                $('#btnAfiSubmit').hide();
                $('#btnCfiSubmit').hide();
                $('#btnUWSubmit').show();
                $('#ModalCommon').html('UW');
            }
            //clear user control values
            $('#txtApplnNumber').val('');
            $('#txtPolicyNumber').val('');
            $('#txtComment').val('');
            $('#ddlAFIType').val('-1');
            $('#txtRCD').val('');
            $('.ddlAssignTo').val('-1');
            $('#tblPolicyDetails').hide();
            $('.main').hide();
            $('.children').hide();
            $('#lblError').addClass('hide');
        }

 

        function btnCollapse() {
          
            debugger;
            alert("Hello! I am an alert box!!");
            $('.btn-box-tool').click(function () {
                if ($(this).find('i').hasClass('fa-plus')) {
                    $(this).find('i').removeClass('fa-plus').addClass('fa-minus');
                } else {
                    $(this).find('i').removeClass('fa-minus').addClass('fa-plus');
                }
                $(this).parents('.HideControl').find('.box-body').slideToggle().parents('.HideControl').siblings().find('.box-body').slideUp();
                $(this).parents('.HideControl').siblings().find('.btn-box-tool i').removeClass('fa-minus').addClass('fa-plus');
            });
        };
    </script>

    <script type="text/javascript">

        function fun1(myurl) {
            debugger;
            var detailsWindow;
            detailsWindow = window.open(myurl, "dfd", "width=600,height=1000, resizable, scrollbars");
            detailsWindow.focus();
            return false;
        }



    </script>
    <style>
        .bg-title {
            background-color: #a81d22;
            color: #fff;
        }

        .loader {
            position: fixed;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url(dist/img/loading1.gif) 50% 50% no-repeat white;
            /* opacity: .75; */
            opacity: .90;
        }

        .small-box .inner a {
            color: #fff;
            font-size: 14px;
        }
    </style>



</head>

<body class="hold-transition skin-maroon fixed">


    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div>
            <div id="divLoadingDetails" runat="server" class="col-md-12">


                <div id="LoadingDtls_container" class="box box-warning box-solid">
                    <div class="box-header with-border">
                        <div class="col-md-12">
                            <div class="col-md-9">
                                <h3 class="box-title ">UW Comments</h3>
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
                            <div class="col-md-12>">
                                <asp:Label runat="server" ID="lblUWComments" CssClass="label-info" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-md-12">
                            <div class="col-md-2">
                                Report Type :                                                                            
                               <br />
                                <asp:DropDownList ID="ddlrpttype" runat="server" Height="30px" Width="130px">
                                    <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="UW Comments"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2" style="right: 100px">
                                Application No/Policy No :                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtAppno" OnTextChanged="txtAppno_TextChanged" AutoPostBack="true" CssClass="box-input"></asp:TextBox>
                            </div>
                            <div class="col-md-2" style="right: 150px">
                                Application No :                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtappnumber" Enabled="false" CssClass="box-input"></asp:TextBox>
                            </div>
                            <div class="col-md-1" style="right: 190px">
                                Policy No :                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtpolicyno" Enabled="false" CssClass="box-input"></asp:TextBox>
                            </div>
                            <div class="col-md-2" style="right: 100px">
                                Life Aisa Status :                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtLAStatus" Enabled="false" CssClass="box-input"></asp:TextBox>
                            </div>
                            <div class="col-md-1" style="right: 150px">
                                Saral Status :                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtSaralStatus" Enabled="false" CssClass="box-input"></asp:TextBox>
                            </div>
                            <div class="col-md-1" style="right: 100px">
                                Risk Score:                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtriskscore" Enabled="false" CssClass="box-input"></asp:TextBox>
                                <%--<asp:Label ID="lblRiskScore" runat="server" Text=""></asp:Label>--%>
                            </div>
                          <%--  <div class="col-md-1" style="right: 50px">
                                ENY Score:                                                                            
                                    <br />
                                <asp:TextBox runat="server" ID="txtenyscore" Enabled="false" CssClass="box-input"></asp:TextBox>
                                <%--<asp:Label ID="lblENYScore" runat="server" Text=""></asp:Label>
                            </div>--%>
                            <div class="col-md-1" style="right: 50px">
                                  <%-- Begin of Changes; Jayendra  - [WebAshlar01]--%>
                                Risk Category:  
                                <%-- End of Changes; Jayendra  - [WebAshlar01]--%>
                                    <br />
                                <asp:TextBox runat="server" ID="txtenyscore" Enabled="false" CssClass="box-input"></asp:TextBox>
                                <%--<asp:Label ID="lblENYScore" runat="server" Text=""></asp:Label>--%>
                            </div>

                        </div>
                        <div class="row">
                            <br />
                        </div>
                        <div class="col-md-2 text-center" style="left: 460px">
                            <br />
                            <asp:Button runat="server" ID="btnFetchRecord" Text="Search" OnClick="btnFetchRecord_Click" CssClass="btn-primary" />
                            <asp:Button runat="server" ID="btnClear" Text="Clear" OnClick="btnClear_Click" CssClass="btn-primary" />
                            <asp:Button runat="server" ID="btnExportToCsv" Text="Export" OnClick="btnExportToCsv_Click" CssClass="btn-primary" />
                            <%--added by Kavita for view medical data entry on  08 JAN 2020--%>
                            <%--<a href="#" data-toggle="modal" data-backdrop="static" data-keyboard="false" data-target="#divMedicalValue">Medical Values</a>--%>
                            <button type="button" id="btnMedical" runat="server" class="btn-primary" data-toggle="modal" data-target="#divMedicalValue">View Medical Value</button>
                            <%--End--%>
                            <asp:Button ID="btnPlvcVideo" CssClass="btn-primary" runat="server" Text="Plvc Video" Visible="true" OnClick="btnPlvcVideo_Click" />
                            <br />
                            <%--Begin of changes by kavita -CR-30489 Phase 2--%>
                            <asp:Button runat="server" ID="btnViewChecklist" Text="View Checklist" Style="width: 120px;" OnClick="btnViewChecklist_Click" CssClass="btn-primary" />
                             <%--Begin of End by kavita -CR-30489 Phase 2--%>
                            <!-- 1.1  Start of changes: Sagar Thorave[MFL00886] Cr-1844 -->    
                            <asp:Button runat="server" ID="btnUpdateComment" Class="btn btn-md center-block" Style="width: 150px;display:none" Text="Update Comment" CssClass="btn-primary" OnClick="btnUpdateComment_Click"/>
                         </div>
                           <!-- 1.1  End of changes: Sagar Thorave[MFL00886] Cr-1844 -->

                    </div>


                    <%--added by Kavita for view medical data entry on  08 JAN 2020--%>
                    <div class="modal fade" id="divMedicalValue" role="dialog">
                        <div class="modal-dialog modal-lg">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header box-header with-border text-center bg-title">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title success"><b><span id="Span111">View Medical Values</span></b></h4>
                                </div>
                                <div class="modal-body" style="height: auto; overflow: auto;">
                                    <asp:UpdatePanel runat="server" ID="UpMedicalValues">
                                        <ContentTemplate>
                                            <AfiCfiWU:MedicalValues runat="server" ID="MedicalValues" />
                                        </ContentTemplate>
                                        <%--<Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnMedical" EventName="Click" />
                                        </Triggers>--%>
                                    </asp:UpdatePanel>
                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <br />
                        <br />
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-2" runat="server" id="divUwComm" visible="false">
                            <b>UW Comments :
                            </b>
                             <!-- 1.1  Start of changes: Sagar Thorave[MFL00886] Cr-1844 -->
                                   <br /><br /><br /><br /><br /><br /><br />
                        </div>
                         <br /><br />
                             
                                 <div class="input-group mb-3" style="margin-left:20px;display:none"  runat="server" id="UwCommAdd"> 
                                   <asp:TextBox ID="AddNewUWComment" runat="server" placeholder="Please enter comment here" TextMode="MultiLine"  Height="80" Width="700" style="margin-right:20px"></asp:TextBox>
                                    <asp:Button runat="server" ID="Btn_SaveComment" Text="Save" CssClass="btn-primary " Width="80px" Style="font-size:15px;" OnClick="Btn_SaveComment_Click" />
                                </div>
                           <!-- 1.1  End of changes: Sagar Thorave[MFL00886]  Cr-1844 -->

                        <div class="row">
                            <br />
                        </div>
                        <div class="table-responsive">
                            <%--<asp:GridView ID="dgUWComments" runat="server" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary" ></asp:GridView>--%>
                            <%-- <asp:DataGrid ID="dgUWComments" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary" runat="server">
                                    <Columns>
                                    </Columns>
                                </asp:DataGrid>--%>
                            <asp:GridView ID="dgUWComments" AutoGenerateColumns="false" CssClass="table table-bordered table-striped" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="USERNAME"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbluserName" Text='<%#Eval("User Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="CATEGORY"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbluserName" Text='<%#Eval("category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="Remark"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="remarks" runat="server" Text='<%#Eval("Remark") %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="CommentsDate"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCommentsDate" Text='<%#Eval("CommentsDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="UserID"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbluserName" Text='<%#Eval("User ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <HeaderTemplate>
                                            <asp:Label ID="Label2" runat="server" Text="BPM Group"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblbpmgrp" Text='<%#Eval("BPM Group") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">

                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-2" runat="server" id="divreqlbl" visible="false">
                            <b>Requirement Summary :
                            </b>
                        </div>
                        <div class="row">
                            <br />
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="dgRequirement" runat="server" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary"></asp:GridView>
                            <%--  <asp:DataGrid ID="dgRequirement" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary" runat="server">
                                    <Columns>
                                    </Columns>
                                </asp:DataGrid>--%>
                        </div>
                    </div>
                    <%-- Added by ajay sahu on 25/05/2018 to get bmp audit trail--%>
                    <div class="row">
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-2" runat="server" id="divStatusDesc" visible="false">
                            <b>BPMS Audit Trail:
                            </b>
                        </div>
                        <div class="row">
                            <br />
                        </div>
                        <div class="table-responsive" style="height: 300px">
                            <asp:GridView ID="dgStatusDesc" runat="server" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary">
                            </asp:GridView>
                            <%--<asp:DataGrid ID="dgStatusDesc" CssClass="table " AutoGenerateColumns="True" HeaderStyle-CssClass="btn-primary" runat="server">
                                    <Columns>
                                    </Columns>
                                </asp:DataGrid>--%>
                        </div>
                    </div>
                    <%-- bmp audit trail end here --%>

                   
                </div>
            </div>
        </div>

    </form>
</body>
</html>


<script type="text/javascript">
    $(function () {
        $('.DatePicker').datepicker({
            autoclose: true,
            format: 'dd/mm/yyyy',
            onSelect: function (date) {
                alert('tail');
            }
        });
    })
</script>
