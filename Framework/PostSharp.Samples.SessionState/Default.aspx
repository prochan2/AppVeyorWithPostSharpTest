<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PostSharp.Samples.SessionState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div>
        Session Counter: <asp:Label id="sessionCounterLabel" runat="server"/> <br/>
        Page View Counter: <asp:Label id="pageViewCounterLabel" runat="server"/> <br/>
        <asp:Button id="incrementButton" OnClick="incrementButton_OnClick" runat="server" Text="Increment"/> <br/>
        <a href="Default.aspx">Reload</a>
    </div>
</form>
</body>
</html>