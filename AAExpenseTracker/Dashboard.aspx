<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AAExpenseTracker.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <asp:Chart ID="Chart1" runat="server" CssClass="img-fluid rounded" Width="570px" ImageLocation="~/Images/ChartPic_#SEQ(300,3)" ImageStorageMode="UseImageLocation">
            <Series>
                <asp:Series Name="Series1" ChartType="Pie" Legend="Legend1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
            <Titles>
                <asp:Title Name="Title1" Text="Remainder after expenses">
                </asp:Title>
            </Titles>
        </asp:Chart>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" OnDataBinding="Repeater1_DataBinding">
        <ItemTemplate>
            <div class="alert alert-danger alert-dismissible" role="alert" id="Notification" runat="server">
            <span><asp:Label ID="ErrorLabel" runat="server" Text='<%#Eval("Message") %>'></asp:Label></span>
            <button type="button" class="close" data-dissmiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
