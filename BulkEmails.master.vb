Imports System.Data
Imports System.Data.SqlClient
Partial Class BulkEmails
    Inherits MasterPage
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter

    Private Sub BulkEmails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        'If con.State = False Then
        '    con.Open()
        'End If

        If Not IsPostBack Then
            Session(Session("TokenID") + "CurrentPage") = Page.AppRelativeVirtualPath.ToString().Substring(2)
            If Session(Session("TokenID") + "CurrentPage") = "Bulk-Email-Services-Page.aspx" Then
                AboutUsLink.HRef = "#AboutUs"
                'PackagesLink.HRef = "#Packages"
                TutorialLink.HRef = "#Tutorial"
                FAQLink.HRef = "#FAQ"
                FAQLink2.HRef = "#FAQ"
                ContactUsLink.HRef = "#ContactUs"
                ContactUsLink2.HRef = "#ContactUs"
                SignUpLink.HRef = "/UserRegistration.aspx"
                HomePage.HRef = "/index.aspx"
                Homepage2.HRef = "/index.aspx"
            Else
                AboutUsLink.HRef = "/Bulk-Email-Services-Page.aspx#AboutUs"
                'PackagesLink.HRef = "/Bulk-Email-Services-Page.aspx#Packages"
                TutorialLink.HRef = "/Bulk-Email-Services-Page.aspx#Tutorial"
                FAQLink.HRef = "/Bulk-Email-Services-Page.aspx#FAQ"
                FAQLink2.HRef = "/Bulk-Email-Services-Page.aspx#FAQ"
                ContactUsLink.HRef = "/Bulk-Email-Services-Page.aspx#ContactUs"
                ContactUsLink2.HRef = "/Bulk-Email-Services-Page.aspx#ContactUs"
                SignUpLink.HRef = "/UserRegistration.aspx"
                HomePage.HRef = "/index.aspx"
                Homepage2.HRef = "/index.aspx"
            End If
            If Request.Cookies("UID") IsNot "" And Request.Cookies("USN") IsNot Nothing Then
                If Session("TokenID") = "" Then
                    Session("TokenID") = Guid.NewGuid().ToString + (Server.HtmlEncode(Request.Cookies("UID").Value).ToString().Substring(4))
                Else
                End If
                Session(Session("TokenID") + "UserID") = (Server.HtmlEncode(Request.Cookies("UID").Value).ToString().Substring(4))
                Session(Session("TokenID") + "EmailAddress") = (Server.HtmlEncode(Request.Cookies("EAD").Value).ToString().Substring(4))
                Session(Session("TokenID") + "UserName") = Server.HtmlEncode(Request.Cookies("USN").Value.ToString().Substring(4))
                'Session(Session("TokenID") + "PackageType") = Server.HtmlEncode(Request.Cookies("PkT").Value.ToString().Substring(4))
                'Session(Session("TokenID") + "SubscriptionDate") = Server.HtmlEncode(Request.Cookies("SBD").Value.ToString().Substring(4))
                'Session(Session("TokenID") + "PackageStatus") = Server.HtmlEncode(Request.Cookies("PkS").Value.ToString().Substring(4))
                'Session(Session("TokenID") + "SubscriptionExpiryDate") = Server.HtmlEncode(Request.Cookies("SBE").Value.ToString().Substring(4))
                'UserNameText.InnerText = Session(Session("TokenID") + "UserName")
                'SubscriptionTypeText.InnerText = Session(Session("TokenID") + "PackageType")
                'PackageStatusText.InnerText = Session(Session("TokenID") + "PackageStatus")
                'SubscriptionDateText.InnerText = Session(Session("TokenID") + "SubscriptionDate")
                'ExpiryDateText.InnerText = Session(Session("TokenID") + "SubscriptionExpiryDate")
                'If Session(Session("TokenID") + "PackageStatus") = "Active" Then
                '    packageStatusIcon.Attributes.Add("class", "fa fa-calendar-check-o")
                'Else
                '    packageStatusIcon.Attributes.Add("class", "fa fa-calendar-times-o")
                'End If
            Else
                Session(Session("TokenID") + "UserID") = ""
                Session(Session("TokenID") + "UserName") = ""
                Session(Session("TokenID") + "EmailAddress") = ""
                'Session(Session("TokenID") + "PackageType") = ""
                'Session(Session("TokenID") + "SubscriptionDate") = ""
                'Session(Session("TokenID") + "PackageStatus") = ""
                'Session(Session("TokenID") + "SubscriptionExpiryDate") = ""
            End If

            If Session(Session("TokenID") + "UserID") = "" Then
                LoginLink.Visible = True
                RegistrationLink.Visible = True
                CurrentUser.Visible = False
                CurrentUserText.Visible = False
                SignOutLink.Visible = False
                DashboardLink.Visible = False
                'EmailMarketingLinkBtn.Visible = False
                'ElseIf Session(Session("TokenID") + "PackageStatus") = "Expired" And Session(Session("TokenID") + "UserID") <> "" Then
                '    LoginLink.Visible = False
                '    RegistrationLink.Visible = False
                '    CurrentUser.Visible = True
                '    SignOutLink.Visible = True
                '    DashboardLink.Visible = True
                '    'EmailMarketingLinkBtn.Visible = True
                '    CurrentUserText.InnerText = Session(Session("TokenID") + "UserName")
            Else
                LoginLink.Visible = False
                RegistrationLink.Visible = False
                CurrentUser.Visible = True
                CurrentUserText.Visible = True
                SignOutLink.Visible = True
                DashboardLink.Visible = True
                'EmailMarketingLinkBtn.Visible = True
                CurrentUserText.InnerText = Session(Session("TokenID") + "UserName")
            End If
            'If Session(Session("TokenID") + "PackageType") = "Trial" Then
            '    DashboardLink.Visible = False
            'ElseIf Session(Session("TokenID") + "PackageType") = "Business" Then
            '    DashboardLink.Visible = True
            'ElseIf Session(Session("TokenID") + "PackageType") = "Premium" Then
            '    DashboardLink.Visible = True
            'End If
        End If
        con.Close()
    End Sub

    Private Sub SignOutLink_ServerClick(sender As Object, e As EventArgs) Handles SignOutLink.ServerClick
        If con.State = False Then
            con.Open()
        End If
        Dim UID As HttpCookie = Request.Cookies("UID")
        UID.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(UID)
        Session(Session("TokenID") + "UserID") = ""

        Dim USN As HttpCookie = Request.Cookies("USN")
        USN.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(USN)
        Session(Session("TokenID") + "UserName") = ""

        'Dim PkT As HttpCookie = Request.Cookies("PkT")
        'PkT.Expires = DateTime.Now.AddDays(-1)
        'Response.Cookies.Add(PkT)
        'Session(Session("TokenID") + "PackageType") = ""

        'Dim SBD As HttpCookie = Request.Cookies("SBD")
        'SBD.Expires = DateTime.Now.AddDays(-1)
        'Response.Cookies.Add(SBD)
        'Session(Session("TokenID") + "SubscriptionDate") = ""

        'Dim PkS As HttpCookie = Request.Cookies("PkS")
        'PkS.Expires = DateTime.Now.AddDays(-1)
        'Response.Cookies.Add(PkS)
        'Session(Session("TokenID") + "PackageStatus") = ""

        'Dim SBE As HttpCookie = Request.Cookies("SBE")
        'SBE.Expires = DateTime.Now.AddDays(-1)
        'Response.Cookies.Add(SBE)
        'Session(Session("TokenID") + "SubscriptionExpiryDate") = ""

        Dim EAD As HttpCookie = Request.Cookies("EAD")
        EAD.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(EAD)
        Session(Session("TokenID") + "EmailAddress") = ""

        con.Close()
        BulkEmails_Load(sender, e)
        Response.Redirect("/Bulk-Email-Services-Page.aspx")
    End Sub

    Private Sub SignUpLink_ServerClick(sender As Object, e As EventArgs) Handles SignUpLink.ServerClick
        Session(Session("TokenID") + "SubscriptionExpiryDateEntry") = (Date.Today).AddDays(3)
        Session(Session("TokenID") + "PackageTypeEntry") = "Trial"
        Response.Redirect("/UserRegistration.aspx")
    End Sub
End Class

