<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimeSheetSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 291px;
            text-align: right;
        }
        .auto-style3 {
            width: 241px;
        }
        .auto-style5 {
            color: #FFFFFF;
        }
        .auto-style6 {
            font-size: x-large;
            text-align: center;
            color: #336699;
        }
        .auto-style7 {
            width: 241px;
            font-size: x-large;
            text-align: center;
            color: #336699;
        }
        .auto-style8 {
            width: 291px;
            text-align: center;
            font-size: x-large;
            color: #336699;
        }
    </style>
    <style>

        .formclass
        {
           font-weight: 700; 
           font-size: xx-large; 
           text-align: center; 
           background-color: #336699

        }


    </style>
    <script language="javascript" type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtUserName.ClientID%>").value == "") {
                alert("Please Enter User Name");
                document.getElementById("<%=txtUserName.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtPassword.ClientID%>").value == "") {
                alert("Please Enter Password");
                document.getElementById("<%=txtPassword.ClientID%>").focus();
                return false;
            }
        }

        </Script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="formclass">
            <span class="auto-style5">Timesheet System </span>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">&nbsp;</td>
                <td class="auto-style7">Log In Form</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">UserName&nbsp; </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUserName" runat="server" Width="180px" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Password</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnLogin" runat="server" OnClientClick="return validate()" OnClick="btnLogin_Click" style="background-color: #0099FF" Text="Login" Width="191px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Label ID="lblLoginInvalid" runat="server" ForeColor="Red" Text="Invalid UserName or Password" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
