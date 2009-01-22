<%@ Import Namespace="Superi.Features"%>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MainMenu.ascx.cs" Inherits="Controls_MainMenu" %>
    <asp:Repeater runat="server" ID="rItems">
        <ItemTemplate>
            <div class="mainMenuItem" onmouseover="switchClass(this, 'mainMenuItemA')" onmouseout="switchClass(this, 'mainMenuItem')">
                <div class="mmiLabel">
                    <a href="<%# WebSession.BaseUrl+Eval("Path") %>">
                        <%# ((Navigation)Container.DataItem).Texts[WebSession.Language] %>
                    </a>
                    <div class="mmiRightBorder">
                        
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
