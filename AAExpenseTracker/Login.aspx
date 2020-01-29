<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AAExpenseTracker.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sign in - Expense Tracker</title>

    <link href="/Content/bootstrap.css" rel="stylesheet">
    <link href="Content/signin.css" rel="stylesheet">
</head>
<body class="text-center">
    <form class="form-signin" id="form1" runat="server">
        <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
        <label class="sr-only" for="inputEmail">Email address</label>
        <asp:TextBox ID="inputEmail" CssClass="form-control" autofocus="" required="" placeholder="Email address" TextMode="Email" runat="server"></asp:TextBox>
        <label class="sr-only" for="inputPassword">Password</label>
        <asp:TextBox ID="inputPassword" CssClass="form-control" required="" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign in" OnClick="Button1_Click" />
    </form>
    <div class="alert alert-warning alert-dismissable collapse" role="alert" id="SignInFailed" runat="server">
                <button type="button" class="close" aria-label="Close">
                    <span aria-hidden="true" id="CloseFailAlert" runat="server">&times;</span>
                </button>
                <span>Wrong password, friend.</span>
            </div>
            <div class="alert alert-danger alert-dismissable collapse" role="alert" id="LoginException" runat="server">
                <button type="button" class="close" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
                <span>
                    <asp:Label ID="ErrorLabel" runat="server" Text="Label"></asp:Label>
                </span>
            </div>
</body>
</html>
