<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateWorkItem.aspx.cs" Inherits="Appcode_CreateWorkItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../dist/css/skins/_all-skins.min.css" rel="stylesheet" />
    <script src="../dist/js/html5shiv.min.js"></script>
    <script src="../dist/js/respond.min.js"></script>
    <link href="../dist/css/styles-app.css" rel="stylesheet" />
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />
    <script src="../plugins/jQueryUI/jquery-ui.js"></script>
    <link href="../plugins/datepicker/datepicker3.css" rel="stylesheet" />
    <script src="../plugins/datepicker/bootstrap-datepicker.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script src="jquery.sumoselect.min.js"></script>
    <link href="../dist/css/sumoselect.css" rel="stylesheet" />
    <script src="../dist/js/jquery.sumoselect.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divLoadingDetails" runat="server" class="col-md-12">


                <div id="LoadingDtls_container" class="box box-warning box-solid">
                    <div class="box-header with-border">
                        <div class="col-md-12">
                            <div class="col-md-9">
                                <h3 class="box-title ">Create Work Item</h3>
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
                                <asp:Label runat="server" ID="lblUWNote" ForeColor="Red" CssClass="label-danger" Text="Note :- Please check Life Asia status before create work item.Staus should be in 'PS'"></asp:Label>
                            </div>
                        </div>
                        <div class="row"></div>
                        <div class="col-md-12">
                             
                            <div class="col-md-2">
                                Application Nos :
                                <asp:TextBox ID="txtappno" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-1">
                                <br />
                                <asp:Button runat="server" ID="btnubmit_Single" Text="Submit-Single" OnClick="btnubmit_Single_Click" CssClass="btn-primary" />            
                            </div>
                              <div class="col-md-1">
                                   <br />
                                  <asp:Button runat="server" ID="btnubmit_Bulk" Text="Submit-Bulk" OnClick="btnubmit_Bulk_Click" CssClass="btn-primary" />
                                     </div>

                        </div>
                         <div class="col-md-12">
                            <div class="col-md-12>">
                                <asp:Label runat="server" ID="lblmsg" Visible="false" CssClass="label-default" Text=""></asp:Label>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
