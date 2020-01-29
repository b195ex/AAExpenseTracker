<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AAExpenseTracker._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Expense Tracker</h1>
        <p class="lead">This small web application helps track your income, and your expenses, and give you personalized alerts about your expense limits.</p>
        
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Getting started</h2>
            <p>
                You can start immediately by going to our Sign in page.
            </p>
            <p>
                <a class="btn btn-default" href="Login.aspx">Sign In</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Check out the Source Code</h2>
            <p>
                The source code can be found in my public GitHub Repo, check it out!.
            </p>
            <p>
                <a class="btn btn-default" href="https://github.com/b195ex/AAExpenseTracker">Source</a>
            </p>
        </div>
        <%-- <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div> --%>
    </div>

</asp:Content>
