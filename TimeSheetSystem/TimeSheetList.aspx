<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSheetList.aspx.cs" Inherits="TimeSheetSystem.LineItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 1249px;
        }

        .auto-style2 {
            width: 302px;
            text-align: center;
        }

        .auto-style1 {
            width: 100%;
        }
    </style>
    <style type="text/css">
    .CenteredGrid { width:640px; margin-left:auto; margin-right:auto; }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; font-size: x-large; color: #FFFFFF; background-color: #336699">
            Time Sheet Details
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2" id="lblUserDetail">
                    <asp:Label ID="lblUserDetail1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnLogOut1" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="CenteredGrid" ForeColor="#333333"  GridLines="None">
            <RowStyle HorizontalAlign="left" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Description">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Rate">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Rate") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Total Cost">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Cost") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "TimeSheetEntry.aspx?id=" +Eval("ID")%>'>View</a>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>        
                   <table class="auto-style1">
                <tr>
                    <td style="text-align: center">            
            <asp:Button ID="btnAddTimeSheet0"  runat="server"  OnClick="btnAddTimeSheet_Click" Text="Add New TimeSheet" />

                    </td>
                </tr>
            </table>
       
    </form>
</body>
</html>
