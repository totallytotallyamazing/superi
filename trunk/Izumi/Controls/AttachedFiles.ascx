<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachedFiles.ascx.cs" Inherits="Controls_AttachedFiles" %>
<div id="extraLeftMenu">
    <asp:Repeater runat="server" ID="rItems">
        <ItemTemplate>
            <a class="subMenuLink" href="<%# DefaultValues.BaseUrl+"Files/AttachableFiles/"+Eval("FileName") %>">
                <%# Eval("Title") %>
            </a><br />
        </ItemTemplate>
    </asp:Repeater>
</div>