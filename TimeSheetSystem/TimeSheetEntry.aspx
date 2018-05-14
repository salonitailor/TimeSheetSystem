<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeSheetEntry.aspx.cs" Inherits="TimeSheetSystem.TimeSheetList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    <style>
        .formclass {
            text-align: center;
            color: #FFFFFF;
            font-size: x-large;
            background-color: #336699
        }

        .auto-style2 {
            width: 302px;
            text-align: center;
        }

        .auto-style3 {
            width: 1249px;
        }

        .auto-style4 {
            height: 24px;
            text-align: left;
        }

        .auto-style5 {
            height: 24px;
            width: 117px;
        }

        .auto-style6 {
            width: 117px;
        }

        #form1 {
            text-align: right;
        }
    </style>
    
</head>
<body>
    <script type="text/javascript">
        function validate() {
            if (document.getElementById("<%=txtDescription.ClientID%>").value == "") {
                alert("Please Enter Description");
                document.getElementById("<%=txtDescription.ClientID%>").focus();
                return false;
            }
            if (document.getElementById("<%=txtRate.ClientID%>").value == "") {
                alert("Please Enter Rate");
                document.getElementById("<%=txtRate.ClientID%>").focus();
                return false;
            }

             if(parseInt(document.getElementById("<%=txtRate.ClientID%>").value) <= 0)
              
                alert('Please Enter positive Integer');
        }

       
     </script>
     
    <script type="text/javascript">
    function checkDate(sender, args) 
            {
                if (sender._selectedDate > new Date()) 
                {
                    alert("You cannot select future date!");
                    sender._selectedDate = new Date();
                    // set the date back to the current date
                    sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                                    
                }
        }
                     

    </script>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="formclass">
            Welcome to Timesheet Reporting System
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblUserDetail" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:GridView ID="gvTimeSheet" runat="server" CellPadding="4"
            ForeColor="#333333" GridLines="None" ShowFooter="True" AutoGenerateColumns="False"
            OnRowUpdating="gvTimeSheet_RowUpdating" OnRowDataBound="gvTimeSheet_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Date">
                    <EditItemTemplate>                   


                        <asp:TextBox ID="txtTimeSheetDate" runat="server" TextMode="Date"    Text='<%#Bind("TimeSheetDate")%>'></asp:TextBox>
                       
                        <ajaxToolkit:CalendarExtender ID="caltxtTimeSheetDate" runat="server" Enabled="true" Format="MM/dd/yyyy" PopupPosition="Right" OnClientDateSelectionChanged="checkDate" TargetControlID="txtTimeSheetDate"/>
                          <asp:RequiredFieldValidator ID="DateRequiredValidator" ForeColor="Red"
                                                  ControlToValidate="txtTimeSheetDate"
                                                  ErrorMessage="Required Field" 
                              validationgroup="PersonalInfoGroup"
                                                  runat ="server" />
                        </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTimeSheetDate" runat="server" Text='<%#Bind("TimeSheetDate")%>' ></asp:Label>
                    </ItemTemplate>
 
                </asp:TemplateField>
                <asp:TemplateField HeaderText="WorkTime(In Minutes)"  HeaderStyle-HorizontalAlign="Left">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtWorkTime" style="text-align: right" runat="server" Text='<%# Bind("WorkTime") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="WorkTimeRequiredValidator" ForeColor="Red"
                                                   ControlToValidate="txtWorkTime"
                                                   ErrorMessage="Required Field" 
                                                   validationgroup="PersonalInfoGroup"
                                                   runat="server" />

                        <asp:CompareValidator ID="CompareValidator1"   validationgroup="PersonalInfoGroup" ForeColor="Red" runat="server" ValueToCompare="0" ControlToValidate="txtWorkTime" 

                           ErrorMessage="Enter Positive Integer"  Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblWorkTime"  runat="server" Text='<%# Bind("WorkTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Button ID="btnSave" CommandName="Update" runat="server" validationgroup="PersonalInfoGroup" Text="Save"  />                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        
                        
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
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">Description </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" ></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Rate</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtRate" runat="server" AutoPostBack="True" OnTextChanged="TextBoxRate_TextChanged"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ValueToCompare="0" ControlToValidate="txtRate" 

                           ErrorMessage="Please Enter Positive Integer" Operator="GreaterThan" Type="Integer"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">TotalTime(Hour)</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtTotalTime" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Total Cost</td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtTotalCost" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="return validate()" OnClick="btnSave_Click" />
                </td>
                <td style="text-align: left">&nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                    &nbsp;&nbsp;
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
