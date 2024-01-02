<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InvestigationReport.ascx.cs" Inherits="UserControl_InvestigationReport" %>
<asp:Panel class="box  box-warning box-solid " runat="server" ID="Panel1">
    <style type="text/css">
        .lblLable {
            background-color: #E5E5E5;
            /*font-weight: bold;*/
            pointer-events: none;
        }

        .CheckSave {
        }


        .divfloatLeft1 {
            float: left;
            padding-right: 100px;
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
    <script type="text/javascript">
        function fnValidate() {
            $('#<%=lblManualAllocationMsg.ClientID%>').html('');
            if ($('#<%=ddlCaseRef.ClientID%>').val() == '0') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Select Case referred by');
                $('#<%=ddlCaseRef.ClientID%>').focus();
                return false;
            }
            else
                if ($('#<%=ddlCatOFMis.ClientID%>').val() == '0') {
                    $('#<%=lblManualAllocationMsg.ClientID%>').html('Select Category of Misconduct');
                    $('#<%=ddlCatOFMis.ClientID%>').focus();
                    return false;
                }

            if ($('#<%=txtPolicyNo.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Policy No To Text Box');
                $('#<%=txtPolicyNo.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtLoginDate.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Select Proposal Login Date');
                $('#<%=txtLoginDate.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtCustSubName.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Customer/Subject Name To Text Box');
                $('#<%=txtCustSubName.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtPremiumAmt.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Premium Amount To Text Box');
             $('#<%=txtPremiumAmt.ClientID%>').focus();
             return false;
         }
         if ($('#<%=txtBranchName.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Branch Name To Text Box');
            $('#<%=txtBranchName.ClientID%>').focus();
            return false;
        }
        if ($('#<%=txtChannelName.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Channel Name To Text Box');
                    $('#<%=txtChannelName.ClientID%>').focus();
                    return false;
                }
                if ($('#<%=txtPolicyStatus.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Policy Status To Text Box');
                    $('#<%=txtPolicyStatus.ClientID%>').focus();
                    return false;
                }
                if ($('#<%=txtPIVCRemark.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter PIVC Remarks To Text Box');
                    $('#<%=txtPIVCRemark.ClientID%>').focus();
                    return false;
                }
                if ($('#<%=txtAgencyPartnerCode.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Agency Partner E Code To Text Box');
                $('#<%=txtAgencyPartnerCode.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtAgencyPartnerName.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Agency Partner Name To Text Box');
                $('#<%=txtAgencyPartnerName.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtRepMangerCode.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Reporting Manager E Code To Text Box');
                $('#<%=txtRepMangerCode.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtRepManName.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Reporting Manager Name To Text Box');
                $('#<%=txtRepManName.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtProd.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Product To Text Box');
                $('#<%=txtProd.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtAgentStatus.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Agent Status To Text Box');
                $('#<%=txtAgentStatus.ClientID%>').focus();
                return false;
            }
            
<%--            if ($('#<%=txtPolicyIssueDate.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Policy Issue Date To Text Box');
                $('#<%=txtPolicyIssueDate.ClientID%>').focus();
                return false;
            }--%>
            if ($('#<%=txtReferredDate.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Referred Date To Text Box');
                $('#<%=txtReferredDate.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtPreAlle.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Reason for referring to SalesCompliance');
                $('#<%=txtPreAlle.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtACRSign.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter ACR Signed by-Employee Name');
                $('#<%=txtACRSign.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtMHRSign.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter MHR Signed by Employee Name & Designation');
                $('#<%=txtMHRSign.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtF2fSign.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter F2F Signed by Employee Name');
                $('#<%=txtF2fSign.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtCLSSRNNo.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter CLS/SRN No');
                $('#<%=txtCLSSRNNo.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtEnqCmnt.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Enquiry Comment');
                $('#<%=txtEnqCmnt.ClientID%>').focus();
                return false;
            }
            if ($('#<%=txtTypeOfDisp.ClientID%>').val() == '') {
                $('#<%=lblManualAllocationMsg.ClientID%>').html('Please Enter Type Of Disposal');
                $('#<%=txtTypeOfDisp.ClientID%>').focus();
                return false;
            }

            return true;

        }
    </script>




    <div class="box-body" id="Section2" runat="server">

       

        <div class="form-group">
            <div class="col-md-12">
                <%-- <div class="col-md-12">
                    <asp:Label runat="server" ID="Label1" Font-Bold="True" ForeColor="Red"></asp:Label>
                </div>--%>

                <table style="width:80%">
                    <tr>
                        <td style="width:35%">
                            <label for="lblPolicyNo">Policy No </label>
                            <br />
                        </td>
                        <td style="width:45%">
                           <asp:TextBox runat="server" ID="txtPolicyNo" CssClass="form-control validate " MaxLength="15"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                            <label for="lblAppNo">Application Number</label>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAppNo" CssClass="form-control validate " MaxLength="15"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%" >

                            <label for="lblProposalDate">Proposal Login Date<br /></label>
                            <br />
                        </td>
                        <td>
                               <asp:TextBox runat="server" ID="txtLoginDate" CssClass="form-control validate DatePicker " ReadOnly="True"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                     <tr>
                        <td style="width:35%">

                            <label for="lblCustName">Customer/Subject Name<br /></label>
                            <br />

                        </td>
                        <td>
                              <asp:TextBox runat="server" ID="txtCustSubName" CssClass="form-control validate  " MaxLength="200"></asp:TextBox>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td style="width:35%">
                            <label for="lblPreAmt">Premium Amount<br /></label>
                            <br />

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPremiumAmt" CssClass="form-control validate " MaxLength="20"></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                            <label for="lblChannelName">Branch Name<br /></label>
                             <br />
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtBranchName" CssClass="form-control validate " MaxLength="100"></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblChannelName">Channel Name<br /></label>
                             <br />
                        </td>
                        
                        <td>
                           <asp:TextBox runat="server" ID="txtChannelName" CssClass="form-control validate " MaxLength="100"></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                            <label for="lblPIVCRem">Policy Status</label>
                             <br />
                        </td>
                        <td>
                                <asp:TextBox runat="server" ID="txtPolicyStatus" CssClass="form-control validate "></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                               <label for="lblPIVCRem">PIVC Remarks</label>
                             <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPIVCRemark" CssClass="form-control validate "></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                             <label for="lblAdvisorCode">Advisor code / IM/ AO/ IBM/ Agency Partner E Code</label>
                             <br />
                        </td>
                        <td>
                               <asp:TextBox runat="server" ID="txtAgencyPartnerCode" CssClass="form-control validate "></asp:TextBox>
                             <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblAdvisorName">Advisor Name /IM/ AO/ IBM/ Agency Partner Name</label> <br />
                        </td>
                        <td>
                          <asp:TextBox runat="server" ID="txtAgencyPartnerName" CssClass="form-control validate " MaxLength="200"></asp:TextBox> <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                              <label for="lblRepManager">Reporting Manager E Code</label> <br />
                        </td>
                        <td>
                          <asp:TextBox runat="server" ID="txtRepMangerCode" CssClass="form-control validate "></asp:TextBox> <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                             <label for="lblRepMangName">Reporting Manager Name</label> <br />
                        </td>
                        <td>
                          <asp:TextBox runat="server" ID="txtRepManName" CssClass="form-control validate " MaxLength="100"></asp:TextBox> <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblProd">Product</label> <br />
                        </td>
                        <td>
                          <asp:TextBox runat="server" ID="txtProd" CssClass="form-control validate " MaxLength="100" Width="270px"></asp:TextBox> <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                          <label for="lblAgentStatus">Agent Status</label> <br />
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtAgentStatus" CssClass="form-control validate " MaxLength="50"></asp:TextBox> <br />
                        </td>
                    </tr>
                    
                    <%--<tr>
                        <td style="width:35%">
                             <label for="lblPolicyIsDate">Policy Issue Date</label> <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPolicyIssueDate" CssClass="form-control validate DatePicker "></asp:TextBox> <br />
                        </td>
                    </tr>--%>
                    
                 
                    <tr>
                        <td style="width:35%">
                              <label for="lblRefdate">Referred Date</label> <br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtReferredDate" CssClass="form-control validate DatePicker "></asp:TextBox> <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                             <label for="lblCatOfMisc">Category of Misconduct</label> <br />
                        </td>
                        <td>
                       <asp:DropDownList ID="ddlCatOFMis" CssClass="form-control validate" runat="server"> 
                        </asp:DropDownList><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                             <label for="lblCaseRefBy">Case referred by/Issue Highlighted by</label><br />
                        </td>
                        <td>
                             <asp:DropDownList ID="ddlCaseRef" CssClass="form-control validate" runat="server">
                        </asp:DropDownList><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblPrimAlleg">Pri-Allegations/Reason for referring to SalesCompliance</label><br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPreAlle" CssClass="form-control validate " MaxLength="200"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                            <label for="lblACRSignEmpName">ACR Signed by-Employee Name</label><br />
                        </td>
                        <td>
                         <asp:TextBox runat="server" ID="txtACRSign" CssClass="form-control validate "></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                                <label for="lblMHRSign">MHR Signed by Employee Name & Designation</label><br />
                        </td>
                        <td>
                              <asp:TextBox runat="server" ID="txtMHRSign" CssClass="form-control validate " MaxLength="100"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                             <label for="lblF2fEmp">F2F Signed by Employee Name (only for PD)</label><br />
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtF2fSign" CssClass="form-control validate "></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblCLSNo">CLS/SRN No (if Any)</label><br />
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtCLSSRNNo" CssClass="form-control validate " MaxLength="20"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                           <label for="lblEnqCmnt">Enquiry Cmnt</label><br />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEnqCmnt" CssClass="form-control validate " MaxLength="150"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:35%">
                            <label for="lblTypeOfDisp">Type Of Disposal</label><br />
                        </td>
                        <td>
                                 <asp:TextBox runat="server" ID="txtTypeOfDisp" CssClass="form-control validate " MaxLength="100"></asp:TextBox><br />
                        </td>
                    </tr>
                  


                </table>

         

            </div>
        </div>



        <div class="form-group col-md-12">
            <div style="clear: both;"></div>
            <div class="col-md-12 table-responsive">

                <div class="col-md-12">
                    <div id="divSaveButtonBlock" runat="server" class="form-group">
                        <asp:Button runat="server" ID="btnsave" CssClass="btn-primary col-md-offset-5" Text="Save" OnClick="btnsave_Click" OnClientClick="return fnValidate();" Height="26px" Width="80px"></asp:Button>
                         <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

         <div class="form-group">
            <div class="col-md-12">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lblManualAllocationMsg" Font-Bold="True" ForeColor="Red"></asp:Label>
                </div>

            </div>
        </div>

    </div>
</asp:Panel>
