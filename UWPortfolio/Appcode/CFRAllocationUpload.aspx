<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFRAllocationUpload.aspx.cs" Inherits="Appcode_CFRAllocationUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <script type="text/javascript" language="javascript">
             function confirmation() {
                 if (confirm('Do you want to Upload Excel ?')) {
                     return true;
                 }
                 else {
                     return false;
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
    <div>
           <table style="margin: 0 auto; height: 146px; width: 751px; border-style: solid; border-color: Black">
                <tr>
                    <td colspan="2" class="style1">
                        <h1>
                            <b>CFR Allocation</b>
                        </h1>
                    </td>
                </tr>
                 
                <tr>
                    <td class="style2">
                        <b>Excel File to Upload :</b>
                    </td>
                    <td class="style3">
                        <asp:FileUpload ID="FileUp1" runat="server" Style="margin-right: 19px"
                            Width="264px" Height="21px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; background-color: #D9ECFF">
                        <b>
                            <asp:Button ID="btnSavetoDB0" runat="server" Text="Save" 
                                Width="117px" OnClientClick="return confirmation();" OnClick="btnSavetoDB0_Click" />

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
