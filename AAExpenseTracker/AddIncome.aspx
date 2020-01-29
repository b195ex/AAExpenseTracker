<%@ Page Title="Add Income" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddIncome.aspx.cs" Inherits="AAExpenseTracker.AddIncome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="AddPanel" GroupingText="Log a new Income" runat="server">
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
                    <label class="col-md-2" for="<%=AmntTxt.ClientID %>">Amount:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="AmntTxt" runat="server" CssClass="form-control form-control-sm" required="true" placeholder="0.00"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*This must be a number" ControlToValidate="AmntTxt" Display="Dynamic" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2">Add Tags:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="TagTxt" CssClass="form-control form-control-sm" placeholder="Multiple tags are separated by commas, i.e. Tag1, Tag2, etc" runat="server"></asp:TextBox>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>

            </Triggers>
        </asp:UpdatePanel>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-6">
                <asp:Button ID="AddBtn" runat="server" Text="Add" CssClass="btn btn-primary" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ListPanel" GroupingText="This month's expenses" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-sm" GridLines="None" runat="server">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
