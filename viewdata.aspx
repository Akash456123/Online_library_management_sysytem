<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdata.aspx.cs" Inherits="viewprofile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
        }
    </style>


   

</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong><span 
            class="style1">&nbsp; 
        DISPLAY&nbsp; ALL DATA</span></strong><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">

         <Columns>
                
                <asp:TemplateField HeaderText="name">

                <ItemTemplate>

                    <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("name")%>'></asp:TextBox>
                   
                </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="mobile" HeaderText="mobile" 
                    SortExpression="mobile" />
                <asp:BoundField DataField="address" HeaderText="address" 
                    SortExpression="address" />

                <asp:TemplateField HeaderText="password">

                <ItemTemplate>

                    <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("password")%>'></asp:TextBox>
                   
                </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="update">
                <ItemTemplate>
                   
                    <asp:Button ID="Button4" runat="server" Text="update" onclick="btn1_click"/>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="delete">
                <ItemTemplate>
                    <asp:Button ID="Button5" runat="server" Text="delete" onclick="btn2_click"/>
                </ItemTemplate>
                </asp:TemplateField>

                
        </Columns>
        </asp:GridView>

        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
