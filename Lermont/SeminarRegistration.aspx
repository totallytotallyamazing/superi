<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SeminarRegistration.aspx.cs" Inherits="SeminarRegistration" Title="Untitled Page" %>
<%@ Register TagPrefix="Controls" Namespace="CustomControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="seminarRegistrationForm">
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regName" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regSeminar" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
            <asp:TextBox runat="server" ID="tbSeminar"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regPlace" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbPlace"></asp:TextBox>
            </div>
        </div>
        <div class="regRow"> 
            <div class="regLabel">
                <Controls:TextWriter TextName="regTime" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbTime"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regPhone" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbPhone"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regMail" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbMail"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regCity" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbCity"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <div class="regLabel">
                <Controls:TextWriter TextName="regComments" runat="server"></Controls:TextWriter>
            </div>
            <div class="regField">
                <asp:TextBox runat="server" ID="tbComments"></asp:TextBox>
            </div>
        </div>
        <div class="regRow">
            <center>
                <Controls:ResourceButton runat="server" ID="bSend"/>&nbsp;
                <Controls:ResourceButton runat="server" ID="bClear" TextName="bClear" />
            </center>
        </div>
    </div>
</asp:Content>

