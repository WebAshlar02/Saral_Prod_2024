<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFRData.aspx.cs" Inherits="Appcode_CFRData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="../dist/css/skins/_all-skins.min.css" rel="stylesheet" />
    <script src="../dist/js/html5shiv.min.js"></script>
    <script src="../dist/js/respond.min.js"></script>
    <link href="../dist/css/styles-app.css" rel="stylesheet" />
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />

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
            var td =  document.getElementById('txtToDate').value;
            debugger;
            var arrStartDate = fd.split("/");
            var date1 = new Date(arrStartDate[2], arrStartDate[1] - 1, arrStartDate[0]); //
            var arrEndDate = td.split("/");
            var date2 = new Date(arrEndDate[2], arrEndDate[1] - 1, arrEndDate[0]);

            if (date1 > date2) {
                alert('From Date not be greater than To Date');
                return false;
            }
            else {
                return true;
            }
            //var fd = document.getElementById('txtFromDate').value;
            //var td = document.getElementById('txtToDate').value;
            ////var d1 = new Date(fd);
            ////var d2 = new Date(td); //assuming today's date is 03/11/2018
            //if (fd > td) {
            //    //validate the input date
            //    alert('From Date not be greater than To Date');
            //    return false;
            //}
            //else {
            //    return true;
            //}
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
            text-align: center;
            background-color: #D9ECFF;
        }

        .auto-style1 {
            height: 13px;
        }

        .auto-style2 {
            text-align: center;
            background-color: #6699FF;
            height: 14px;
        }

        .FixedHeader {
            position: absolute;
            font-weight: bold;

        }

        .table {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <table style="margin: 0 auto; height: 726px; width: 988px; border-style: solid; border-color: Black">
                <tr>
                    <td colspan="2" class="auto-style2">
                        <h1>
                            <b>CFR DATA</b>
                        </h1>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <b>
                            <label>From Date <span style="color: red;">*</span></label></b>
                    </td>
                    <td class="style3">

                        <asp:TextBox ID="txtFromDate" runat="server" CausesValidation="true" ValidationGroup="Date"  ></asp:TextBox>
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

                        <asp:TextBox ID="txtToDate" runat="server" CausesValidation="true" ValidationGroup="Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="reqtxtToDate" runat="server" ErrorMessage="To Date Required"
                            ControlToValidate="txtToDate" ValidationGroup="Date" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <%--   <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Date" ForeColor="Red" runat="server" ControlToValidate="txtToDate"
                            ControlToCompare="txtFromDate" Operator="GreaterThan" Type="Date" ErrorMessage="To-date must be greater than From date."></asp:CompareValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td class="style2">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" ValidationGroup="Date"
                            Width="108px" Height="26px" OnClick="btnsubmit_Click"  OnClientClick="return dateCompare();" />
                    </td>
                    <td class="style3">
                        <asp:Button ID="btnExportToExcel" runat="server" OnClientClick="return dateCompare();" Text="Export To Excel" ValidationGroup="Date"
                            Width="117px" OnClick="btnExportToExcel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #D9ECFF" class="auto-style1">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="background-color: #D9ECFF"> 
                         <div runat="server" style="height: 540px; overflow: auto; width: 971px;" >
                            <asp:GridView ID="dgvCFRData" runat="server" style="height: 600px;  overflow: auto" AutoGenerateColumns="False" 
                              Height="181px" Width="972px" CellPadding="4" ForeColor="#333333" GridLines="None" >  

                                <Columns>
                                    <asp:TemplateField HeaderText="ApplicationNo"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="120px" ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApplicationNo" runat="server"
                                                Text='<%#Eval("ApplicationNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <Columns>
                                    <asp:TemplateField HeaderText="Questions" HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="200px"   ItemStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuestions" runat="server"
                                                Text='<%#Eval("Questions")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                  <Columns>
                                    <asp:TemplateField HeaderText="Answer"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="90px" ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnswer" runat="server"
                                                Text='<%#Eval("Answer")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                  <Columns>
                                    <asp:TemplateField HeaderText="Catagory"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="90px" ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCatagory" runat="server"
                                                Text='<%#Eval("Catagory")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                  <Columns>
                                    <asp:TemplateField HeaderText="SavedDate"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="100px" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSavedDate" runat="server"
                                                Text='<%#Eval("SavedDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                  <Columns>
                                    <asp:TemplateField HeaderText="Remark"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="140px" ItemStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRemark" runat="server"
                                                Text='<%#Eval("Remark")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                  <Columns>
                                    <asp:TemplateField HeaderText="User"  HeaderStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="90px" ItemStyle-Width="90px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUser" runat="server"
                                                Text='<%#Eval("User")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1"  Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                             </div>
                    </td>
                </tr>



            </table>
        </div>
    </form>
</body>
</html>
