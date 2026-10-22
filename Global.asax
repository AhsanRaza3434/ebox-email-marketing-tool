<%@ Application Language="VB" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Web.Optimization" %>

<script runat="server">

    Sub Application_Start(sender As Object, e As EventArgs)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

</script>