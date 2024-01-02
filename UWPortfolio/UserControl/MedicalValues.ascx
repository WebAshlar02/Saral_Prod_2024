<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MedicalValues.ascx.cs" Inherits="UserControl_MedicalValues" %>

<style type="text/css">
    .lblLable {
        background-color: #E5E5E5;
        /*font-weight: bold;*/
        pointer-events: none;
    }

    .CheckSave {
    }

    html, body {
        font-family: Verdana,sans-serif;
        font-size: 10px;
        line-height: 18px;
    }

    .divfloatLeft1 {
        float: left;
        padding-right: 10px;
    }

    .divflaotLeft2 {
        float: left;
        padding-right: 50px;
    }

    .divfloatRight {
        float: right;
        padding-right: 10px;
    }
</style>
<asp:Panel class="box box-health-question box-warning box-solid " runat="server" ID="Panel1">
    <script type="text/javascript">
        function btnCollapse() {
          //  debugger;
           // alert("Hello! I am an alert box!!");
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


    <asp:HiddenField runat="server" ID="hdnValue" ClientIDMode="Static" />



    <div id="divMRFDetails" runat="server" class="col-md-12 HideControl">

        <div id="MRF_container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">MRF</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkMRFDtls" CssClass="CheckSave" runat="server" ClientIDMode="Static" Text="Edit" EnableViewState="False" />
                            <%--<input id="chkMRFDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>

                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>

            </div>

            <div id="main" class="box-body" style="display: none;">
                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1">
                        <label>Application Number:</label>
                    </div>
                    <div class="form-group divflaotLeft2">
                        <asp:TextBox ID="txtAppNo" ClientIDMode="Static" CssClass="form-control validate lblLable"  ReadOnly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Systolic 1: </label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtSystolic1" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 85px">
                        <label>Gender</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 70px">
                        <asp:DropDownList ID="ddlGender" Width="190px" Height="22px" AutoPostBack="false" Enabled="false" ClientIDMode="Static" runat="server"  >
                            <asp:ListItem Value="Select">Select</asp:ListItem>
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group divfloatLeft1" style="padding-right:10px">
                        <label>Systolic 2: </label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtSystolic2" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 53px">
                        <label>Date Of Birth</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtDOB" ClientIDMode="Static" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Systolic 3: </label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtSystolic3" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 103px">
                        <label>AGE</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtAge" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Diastolic 1:</label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtDiastolic1" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>


                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 43px">
                        <label>Height (in Cm)</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtHeight"  ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Diastolic 2: </label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtDiastolic2" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>


                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 43px">
                        <label>Weight (in Kg)</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtWeight" ClientIDMode="Static" Text="" CssClass="form-control validate lblLable"  runat="server" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Diastolic 3:</label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtDiastolic3" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 103px">
                        <label>BMI</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtBMI" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1" style="padding-right: 50px">
                        <label>Girth</label>
                    </div>
                    <div class="form-group divfloatRight">
                        <asp:TextBox ID="txtGirth" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 95px">
                        <label>Pulse</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtPulse" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <label>Known Case of HTN</label>
                    </div>
                    <div class="form-group divfloatRight">
                        No<input type="Checkbox" class="simple-switch-input" runat="server" id="ChekHTN" /><span class="simple-switch dark"></span>Yes
                    </div>
                </div>


                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 30px">
                        <label>Chest Inspiration</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 50px">
                        <asp:TextBox ID="txtChestInsp" ClientIDMode="Static" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1" style="padding-right: 10px">
                        <label>Known Case of DM</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 88px">
                        <label class="lblDMCase">
                            No<input type="checkbox" class="simple-switch-input " runat="server" id="ChekDMCase" /><span class="simple-switch dark"></span>Yes
                        </label>
                    </div>
                </div>


                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 85px">
                        <label>Smoker</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 150px">
                        <label class="lblDMCase">
                            No<input type="checkbox" class="simple-switch-input " runat="server" id="chekSmoker" /><span class="simple-switch dark"></span>Yes
                        </label>
                    </div>
                    <div class="form-group divfloatLeft1" style="padding-right: 30px">

                        <label>Alcohol</label><br />
                    </div>
                    <div class="form-group divfloatRight">
                        <label class="lblDMCase">
                            No<input type="checkbox" class="simple-switch-input " runat="server" id="ChekAlcohol" /><span class="simple-switch dark"></span>Yes
                        </label>
                    </div>
                </div>

                <div style="float: left; padding-right: 100px">

                    <div class="form-group divfloatLeft1" style="padding-right: 25px">
                        <label>Smoker Comments</label>
                    </div>
                    <div class="form-group divflaotLeft2" style="padding-right: 80px">
                        <asp:TextBox ID="txtSmokerComment" TextMode="MultiLine" Font-Size="X-Small" ClientIDMode="Static" Rows="3" Text=""  CssClass="form-control validate lblLable"  runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1" style="padding-right: 20px">
                        <label>Comment on Case DM</label>

                    </div>
                    <div class="form-group divfloatLeft1">
                        <asp:TextBox ID="txtDMComment" TextMode="MultiLine" Font-Size="X-Small" ClientIDMode="Static" Rows="3" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>

                </div>

                <div style="float: left; padding-right: 100px">
                    <div class="form-group" style="float: left;">
                        <label>Comment on Case HTN</label>
                    </div>
                    <div class="form-group" style="float: right;">
                        <asp:TextBox ID="txtHTNComment" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" Rows="3" Text="" runat="server" CssClass="form-control validate lblLable" ></asp:TextBox>
                    </div>
                    <div class="form-group divfloatLeft1">
                        <asp:Label runat="server" ClientIDMode="Static" ID="Label1" Font-Bold="true" ForeColor="Red"></asp:Label>

                    </div>
                </div>

            </div>



        </div>
    </div>


    <div id="divCBC_ESR" runat="server" class="col-md-12 HideControl">

        <div id="CBC_ESR_Container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">CBC & ESR</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkCBC_ESR" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="CBC_ESR_ContainerBody" class="box-body" style="display: none;">


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>HB:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtHB" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>PCV:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtPCV" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>RBC:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtRBC1" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>MCV:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtMCV" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>MCH:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtMCH" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>MCHC:</label>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtMCHC" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>WBC:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtWBC" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>NEUTROPHILS:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtNEUTROPHILS" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>LYMPHOCYTES:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtLYMPHOCYTES" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>EOSINOPHILS:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtEOSINOPHILS" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>MONOCYTES:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtMONOCYTES" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>BASOPHILS:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtBASOPHILS" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>PLATELET COUNT:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtPLATELETCOUNT" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>ESR:</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtESR" CssClass="form-control lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>


        </div>


    </div>


    <div id="divHBSAG" runat="server" class="col-md-12 HideControl">

        <div id="HBSAG_Container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">HBSAG</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkHBSAG" CssClass="CheckSave" runat="server" Text="Edit" EnableViewState="False" ClientIDMode="Static" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="HBSAG_ContainerBody" class="box-body" style="display: none">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkHBSAG_NA" runat="server" Text="NA" GroupName="HBSG" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkHBSAG_POSITITVE" runat="server" Text="POSITIVE" GroupName="HBSG" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkHBSAG_NEGATIVE" runat="server" Text="NEGATIVE" GroupName="HBSG" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:Label runat="server" ClientIDMode="Static" ID="lblValidateHBSAG" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="divHIV" runat="server" class="col-md-12 HideControl">

        <div id="HIV_Container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">HIV</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkHIV" CssClass="CheckSave" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="HIV_ContainerBody" class="box-body" style="display: none">
                <div class="col-md-12">
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkhiv_NA" runat="server" Text="NA" GroupName="HIV" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkhiv_POSITIVE" runat="server" Text="POSITIVE" GroupName="HIV" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group">
                            <asp:RadioButton ID="chkhiv_NEGATIVE" runat="server" Text="NEGATIVE" GroupName="HIV" ClientIDMode="Static" />
                        </div>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:Label runat="server" ClientIDMode="Static" ID="lblValidateHIV" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="divFBS_RUA" runat="server" class="col-md-12 HideControl">

        <div id="FBS_RUA_Container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">FBS, RUA</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkFBS_RUA" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="FBS_RUA_ContainerBody" class="box-body" style="display: none">


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Duration</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtDuration" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>FBS</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtFBS" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="ValidateFBS()"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>HBA1C</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtHBA1C" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="ValidateFBS()"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        <label>RBC</label>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtRBC" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2 form-group">
                        <label>ALBUMIN</label>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList ID="ddl_ALBUMIN" CssClass="form-control validate lblLable" AutoPostBack="false" ClientIDMode="Static" runat="server">
                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                <asp:ListItem Value="Nil">Nil</asp:ListItem>
                                <asp:ListItem Value="Trace">Trace</asp:ListItem>
                                <asp:ListItem Value="1+">1+</asp:ListItem>
                                <asp:ListItem Value="2+">2+</asp:ListItem>
                                <asp:ListItem Value=">2+">>2+</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        <label>SUGAR</label>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSUGAR" CssClass="form-control validate lblLable" AutoPostBack="false" ClientIDMode="Static" runat="server">
                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                <asp:ListItem Value="Nil">Nil</asp:ListItem>
                                <asp:ListItem Value="Trace">Trace</asp:ListItem>
                                <asp:ListItem Value="1+">1+</asp:ListItem>
                                <asp:ListItem Value="2+">2+</asp:ListItem>
                                <asp:ListItem Value="3+">3+</asp:ListItem>
                                <asp:ListItem Value="4+">4+</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2 form-group">
                        <label>PUS CELLS</label>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtPUS" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        <label>Others</label>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:DropDownList ID="ddlOthers" CssClass="form-control validate lblLable" AutoPostBack="false" ClientIDMode="Static" runat="server">
                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                <asp:ListItem Value="Nil">Nil</asp:ListItem>
                                <asp:ListItem Value="Cast cells">Cast cells</asp:ListItem>
                                <asp:ListItem Value="Uric acid crystal">Uric acid crystal</asp:ListItem>
                                <asp:ListItem Value="Bacteria">Bacteria</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

            </div>
        </div>


    </div>

    <div id="divLFT_Test" runat="server" class="col-md-12 HideControl">

        <div id="LFT_Test_Container" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">LFT Test</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkLFT" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="LFT_Test_ContainerBody" class="box-body" style="display: none">

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>SGOT</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtSGOT" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>SGPT</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtSGPT" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--<div class="col-md-3"></div>--%>


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>GGT</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtGGT" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Direct BILLIRUBIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtDirectBILLIRUBIN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <%--<div class="col-md-3"></div>--%>


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Indirect BILLIRUBIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtBILLIRUBIN2" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id); GetTotalBILLIRUBIN();"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Total BILLIRUBIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtTotalBILLIRUBIN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>ALP</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtALP" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>S-GLOBILIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtGLOBILIN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--<div class="col-md-3"></div>--%>

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>S-ALBUMIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtS_ALBUMIN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>TOTAL PROTEIN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtTOTALPROTEIN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--<div class="col-md-3"></div>--%>



                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>AG Ratio</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtAgRatio" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        
                    </div>
                </div>
            </div>

        </div>


    </div>

    <div id="divLIPIDS" runat="server" class="col-md-12 HideControl">

        <div id="LIPIDSContainer" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">LIPIDS Test</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkLIPIDS" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="LIPIDSContainerBody" class="box-body" style="display: none">
                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>CHOLESTEROL</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtCHOLESTEROL" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>HDL</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtHDL" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id); GetTc_HdlRatio();"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>TRIGLYCERIDE</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtTRIGLYCERIDE" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>TC/HDL RATIO</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtTcRatio" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" ReadOnly="true" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>--%>
                            <asp:TextBox ID="txtTCHDLRatio" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" ReadOnly="true" Text="" runat="server" onchange="GetTc_HdlRatio()"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>
        </div>



    </div>


    <div id="divRFT" runat="server" class="col-md-12 HideControl">
        <div id="RFTContainer" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">RFT Test</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkRFT" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="RFTContainerBody" class="box-body" style="display: none">


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>S.CREATININE</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtS_CREATININE" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>URIC ACID</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtUricAcid" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>BUN</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtBUN" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server" onblur="FeildErrorWarning(this.id)"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>
        </div>



    </div>

    <div id="divECG" runat="server" class="col-md-12 HideControl">

        <div id="ECGContainer" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">ECG Test</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkECG" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="ECGContainerBody" class="box-body" style="display: none">


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Date of test</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtDateOfTest" Width="120px" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Decision</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtDecision" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>--%>
                            <asp:TextBox ID="txtECGDecision" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>
        </div>



    </div>

    <div id="divCTMT" runat="server" class="col-md-12 HideControl">

        <div id="CTMTContainer" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">CTMT Test</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <%--<div class="col-md-18" style="float: right">
                                    <asp:LinkButton ID="lnkApplicationDtlsRefresh" OnClick="lnkApplicationDtlsRefresh_Click" runat="server"><span class="glyphicon glyphicon-refresh"></span></asp:LinkButton>
                                </div>--%>
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="chkCTMTC" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="CTMTContainerBody" class="box-body" style="display: none">

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Date of test</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="dtTestMedication" Width="120px" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Medication</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtDecision" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>--%>
                            <asp:TextBox ID="txtMedication" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>




                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Exercise Time</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtExerciseTime" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Work Load</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtWorkLoad" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>BP</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtBP" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>THR</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <asp:TextBox ID="txtTHR" CssClass="form-control validate lblLable Numeric " ClientIDMode="Static" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Reason for termination</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtDecision" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>--%>
                            <asp:TextBox ID="txtResonTermination" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Decision</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtDecision" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>--%>
                            <asp:TextBox ID="txtCTMTDecision" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>
                <div class="col-md-12">
                </div>

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>CMO Decision</label>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <%--<asp:TextBox ID="txtDecision" CssClass="form-control validate lblLable" ClientIDMode="Static" Text="" runat="server"></asp:TextBox>--%>
                            <asp:TextBox ID="txtCMODecisionCTMT" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>
        </div>



    </div>


    <div id="divDecision" runat="server" class="col-md-12 HideControl">

        <div id="DecisionContainer" class="box box-warning box-solid ">
            <div class="box-header with-border">
                <div class="col-md-12">
                    <div class="col-md-9">
                        <div class="col-md-3">
                            <h3 class="box-title ">Decision</h3>
                            <i class="fa fa-pencil fa-fw" aria-hidden="true"></i>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="col-md-3">
                      
                        <div class="col-md-4" style="float: right">
                            <asp:CheckBox ID="ChkDesicion" CssClass="CheckSave" ClientIDMode="Static" runat="server" Text="Edit" EnableViewState="False" />
                            <%--  <input id="chkAppDtls" class="CheckSave" type="checkbox" value="Edit" />--%>
                        </div>
                        <div class="col-md-3" style="float: right">
                            <%--<asp:Button ID="btnAppDtlsSave1" OnCommand="btnCommonEvent_Command" CommandName="ApplicationDetails" CssClass="btn-primary HideControl" OnClientClick="return ValidateApplicationBlog();" runat="server" Text="Save" OnClick="btnAppDtlsSave_Click" />--%>
                        </div>
                    </div>
                </div>
                <div class="box-tools ">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" runat="server">
                        <i class="fa fa-plus"></i>
                    </button>
                </div>
            </div>
            <div id="DecisionContainerBody" class="box-body" style="display: none">

                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Other Comments / Finding</label><br />
                            <asp:TextBox ID="txtOtherComments" TextMode="MultiLine" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        <label>Medical Reason</label><br />
                        <asp:DropDownList ID="ddlMedicalreason" AutoPostBack="false" ClientIDMode="Static" CssClass="form-control lblLable" runat="server"></asp:DropDownList>

                    </div>
                    <div id="divExreason" runat="server" class="col-md-2 form-group hidden">
                        <label>Exception Reason</label><br />
                        <asp:DropDownList ID="ddlExreason" AutoPostBack="false" ClientIDMode="Static" CssClass="form-control lblLable" runat="server"></asp:DropDownList>

                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                          
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label>Total EMR</label>
                            <%--<asp:Button ID="btntotal" runat="server" OnClick="btntotal_Click" Text="Calculate Total EMR" /><br />--%>
                            <asp:TextBox ID="txttotalEMR" TextMode="MultiLine" Font-Size="Medium" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>Manual EMR</label>
                            <%--<asp:Button ID="btntotal" runat="server" OnClick="btntotal_Click" Text="Calculate Total EMR" /><br />--%>
                            <asp:TextBox ID="txtmanualEMR" Font-Size="Medium" CssClass="form-control validate lblLable" onblur="AddManulaEMR()" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="col-md-2">
                        <div class="form-group">
                            <label>CMO Decision</label><br />
                            <asp:TextBox ID="txtCMODecision" TextMode="MultiLine" ClientIDMode="Static" Font-Size="X-Small" CssClass="form-control validate lblLable" Rows="5" Text="" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>


            </div>
        </div>

    </div>

    <div style="text-align: center">
    </div>


</asp:Panel>
