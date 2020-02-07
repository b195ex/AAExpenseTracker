﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddAlert.aspx.cs" Inherits="AAExpenseTracker.AddAlert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" GroupingText="Add Alert" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="form-group row">
                    <label for="<%= TypeDropDn.ClientID %>" class="col-md-2 col-form-label">Type:</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="TypeDropDn" CssClass="form-control form-control-sm custom-select" runat="server" OnSelectedIndexChanged="TypeDropDn_SelectedIndexChanged" AutoPostBack="True" OnDataBinding="TypeDropDn_DataBinding"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="<%= TagDropDn.ClientID %>" class="col-md-2 col-form-label">Tag:</label>
                    <div class="col-md-6">
                        <asp:DropDownList ID="TagDropDn" CssClass="form-control form-control-sm custom-select" runat="server" OnDataBinding="TagDropDn_DataBinding"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="<%= AmntTxt.ClientID %>" class="col-md-2 col-form-label">Amount:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="AmntTxt" TextMode="Number" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" Display="Dynamic" ForeColor="Red" ControlToValidate="AmntTxt"></asp:RangeValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="<%= MsgTxt.ClientID %>" class="col-md-2 col-form-label">Message:</label>
                    <div class="col-md-6">
                        <asp:TextBox ID="MsgTxt" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="AddBtn" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="form-group row">
            <div class="offset-md-2 col-md-6">
                <asp:Button ID="AddBtn" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="AddBtn_Click" />
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel2" GroupingText="Alerts" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" DataKeyNames="ID" CssClass="table table-bordered table-striped table-sm" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" GridLines="None" OnPreRender="Grid_PreRender" runat="server" AutoGenerateColumns="False" OnDataBinding="GridView1_DataBinding" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Id" Visible="False" />
                            <asp:BoundField DataField="Amount" DataFormatString="{0:C}" HeaderText="Amount" />
                            <asp:BoundField DataField="Message" HeaderText="Message" />
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" CssClass="custom-control custom-switch" Checked='<%# Bind("Active") %>' Text=" " runat="server" OnPreRender="CheckBox1_PreRender" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    <asp:HiddenField ID="Field1" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
