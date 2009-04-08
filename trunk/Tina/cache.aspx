<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" %>
<%@ OutputCache VaryByParam="*" NoStore="true" Duration="1" %>
<script runat="server">
    protected void Page_Load(object sender, System.EventArgs e) {
        Response.Cache.SetNoStore();
    }
</script>

<html />
