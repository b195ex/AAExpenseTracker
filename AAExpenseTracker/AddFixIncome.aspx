﻿<%@ Page Title="Fixed Income" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFixIncome.aspx.cs" Inherits="AAExpenseTracker.AddFixIncome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="AddPanel" GroupingText="Add a new Fixed Income" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <label for="<%= ConceptTxt.ClientID %>" class="col-md-2 control-label">Concept:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="ConceptTxt" runat="server" CssClass="form-control form-control-sm" placeholder="Concept" required="true"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required Field" ControlToValidate="ConceptTxt" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2">Amount:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="AmntTxt" runat="server" CssClass="form-control form-control-sm" required="true" placeholder="0.00"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*This must be a number" ControlToValidate="AmntTxt" Display="Dynamic" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AddBtn" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-6">
                <asp:Button ID="AddBtn" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddBtn_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="EditPanel" GroupingText="Income List" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped table-sm" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" GridLines="None" OnPreRender="Grid_PreRender" DataKeyNames="ID" OnDataBinding="GridView1_DataBinding" OnRowDeleting="GridView1_RowDeleting">
                        <HeaderStyle CssClass="thead-dark" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                            <asp:BoundField DataField="Concept" HeaderText="Concept" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
