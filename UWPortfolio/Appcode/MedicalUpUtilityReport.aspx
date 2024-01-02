<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicalUpUtilityReport.aspx.cs" Inherits="MedicalUploadUtility.MedicalUpUtilityReport" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" lang="javascript">
        function confirmation() {
            if (confirm('Do you want to Upload Excel ?')) {
                return true;
            }
            else {
                return false;
            }
        }


        function dateCompare() {
            var fd = document.getElementById('txtFromDate').value;
            var td = document.getElementById('txtToDate').value;
            //var d1 = new Date(fd);
            //var d2 = new Date(td); //assuming today's date is 03/11/2018
            if (fd < td) {
                //validate the input date
                alert('From Date not be greater than To Date');
                return false;
            }
            else {
                return true;
            }
        }


    </script>

    <style type="text/css">
        .style1 {
            text-align: center;
            background-color: #6699FF;
        }

        .style2 {
            text-align: right;
            background-color: #D9ECFF;
            height: 35px;
        }

        .style3 {
            text-align: left;
            background-color: #D9ECFF;
            height: 35px;
        }

        .style4 {
            height: 197px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table style="margin: 0 auto; height: 146px; width: 751px; border-style: solid; border-color: Black">
                <tr>
                    <td colspan="2" class="style1">
                        <h1>
                            <b>Medical Upload Utility Report </b>
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <b>
                            <label>From Date <span style="color: red;">*</span></label></b>
                    </td>
                    <td class="style3">

                        <asp:TextBox ID="txtFromDate" runat="server" CausesValidation="true" ValidationGroup="Date" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="reqtxtFromDate" runat="server" ErrorMessage="From Date Required"
                            ControlToValidate="txtFromDate" ValidationGroup="Date" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <%--   <asp:CompareValidator ID="CompareValidator2" ValidationGroup="Date" ForeColor="Red" runat="server" ControlToValidate="txtFromDate"
                            ControlToCompare="txtToDate" Operator="LessThan" Type="Date" ErrorMessage="From date must be less than To-date."></asp:CompareValidator>--%>



                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <b>
                            <label>To Date <span style="color: red;">*</span></label></b>
                    </td>
                    <td class="style3">

                        <asp:TextBox ID="txtToDate" runat="server" CausesValidation="true" ValidationGroup="Date" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="reqtxtToDate" runat="server" ErrorMessage="To Date Required"
                            ControlToValidate="txtToDate" ValidationGroup="Date" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <%--   <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red" runat="server" ControlToValidate="txtToDate"
                            ControlToCompare="txtFromDate" Operator="GreaterThan" Type="Date" ErrorMessage="To-date must be greater than From date."></asp:CompareValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align: center; background-color: #D9ECFF">
                        <b>
                            <asp:Button ID="btnExportToExcel" runat="server" OnClientClick="return dateCompare()" Text="Export To Excel" ValidationGroup="Date"
                                Width="117px" OnClick="btnExportToExcel_Click" />

                        </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #D9ECFF">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>


            </table>
        </div>
    </form>
</body>
</html>
