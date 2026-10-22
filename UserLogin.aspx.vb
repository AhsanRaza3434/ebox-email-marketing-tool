Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports ASPSnippets.GoogleAPI
Imports System.Web.Script.Serialization

Partial Class Default3
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter

    Dim dset As New DataSet
    Dim dpt As New SqlDataAdapter

    Private Sub GmailLoginBtn_Click(sender As Object, e As EventArgs) Handles GmailLoginBtn.Click
        'GoogleConnect.Clear(Request.QueryString("code"))
        Session(Session("TokenID") + "GoogleLogin") = "True"
        GoogleConnect.Authorize("profile", "email")
    End Sub
    Public Class GoogleProfile
        Public Property Id() As String
        Public Property Email() As String
    End Class
    Protected Sub save_cookie()
        If con.State = False Then
            con.Open()
        End If
        Dim UID As HttpCookie = New HttpCookie("UID")
        UID.Values.Add("UID", Session(Session("TokenID") + "UserID"))
        UID.Expires = DateTime.Now.AddDays(15)
        Response.Cookies.Add(UID)
        Dim USN As HttpCookie = New HttpCookie("USN")
        USN.Values.Add("USN", Session(Session("TokenID") + "UserName"))
        USN.Expires = DateTime.Now.AddDays(15)
        Response.Cookies.Add(USN)
        'Dim PkT As HttpCookie = New HttpCookie("PkT")
        'PkT.Values.Add("PkT", Session(Session("TokenID") + "PackageType"))
        'PkT.Expires = DateTime.Now.AddDays(15)
        'Response.Cookies.Add(PkT)
        'Dim SBD As HttpCookie = New HttpCookie("SBD")
        'SBD.Values.Add("SBD", Session(Session("TokenID") + "SubscriptionDate"))
        'SBD.Expires = DateTime.Now.AddDays(15)
        'Response.Cookies.Add(SBD)
        'Dim PkS As HttpCookie = New HttpCookie("PkS")
        'PkS.Values.Add("PkS", Session(Session("TokenID") + "PackageStatus"))
        'PkS.Expires = DateTime.Now.AddDays(15)
        'Response.Cookies.Add(PkS)
        'Dim SBE As HttpCookie = New HttpCookie("SBE")
        'SBE.Values.Add("SBE", Session(Session("TokenID") + "SubscriptionExpiryDate"))
        'SBE.Expires = DateTime.Now.AddDays(15)
        'Response.Cookies.Add(SBE)
        Dim EAD As HttpCookie = New HttpCookie("EAD")
        EAD.Values.Add("EAD", Session(Session("TokenID") + "EmailAddress"))
        EAD.Expires = DateTime.Now.AddDays(15)
        Response.Cookies.Add(EAD)
        con.Close()
    End Sub

    Protected Sub load_author_id()

        If con.State = False Then
            con.Open()
        End If
        cmd.Parameters.Clear()
        cmd.CommandText = "select_user_id_by_email"
        cmd.CommandType = CommandType.StoredProcedure

        p = New SqlParameter
        p.ParameterName = "@EmailAddress"
        p.Value = email_TextBox.Text
        cmd.Parameters.Add(p)
        Dim dset As New DataSet
        Dim dpt As New SqlDataAdapter
        dpt.SelectCommand = cmd
        email_TextBox.Text = ""
        dpt.Fill(dset, "UM_USerID")
        Session(Session("TokenID") + "UserID") = dset.Tables("UM_USerID").Rows(0)("UserID").ToString
        Session(Session("TokenID") + "EmailAddress") = dset.Tables("UM_USerID").Rows(0)("EmailAddress").ToString
        Session(Session("TokenID") + "UserName") = dset.Tables("UM_USerID").Rows(0)("Name").ToString
        'Session(Session("TokenID") + "PackageType") = dset.Tables("UM_USerID").Rows(0)("PackageType").ToString
        'Session(Session("TokenID") + "SubscriptionDate") = dset.Tables("UM_USerID").Rows(0)("SubscriptionDate").ToString
        'Session(Session("TokenID") + "PackageStatus") = dset.Tables("UM_USerID").Rows(0)("PackageStatus").ToString
        'Session(Session("TokenID") + "SubscriptionExpiryDate") = dset.Tables("UM_USerID").Rows(0)("SubscriptionExpiryDate").ToString
        con.Close()
    End Sub

    Protected Sub Load_User_By_SignupType()
        If con.State = False Then
            con.Open()
        End If
        cmd.Parameters.Clear()
        cmd.CommandText = "SearchUser_By_SignupType"
        cmd.CommandType = CommandType.StoredProcedure
        If Session(Session("TokenID") + "GoogleLogin") = "True" Then
            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = Session(Session("TokenID") + "profileEmail")
            email_TextBox.Text = Session(Session("TokenID") + "profileEmail")
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Password"
            p.Value = Session(Session("TokenID") + "profileID")
            cmd.Parameters.Add(p)
            Session(Session("TokenID") + "SignInType") = "Google"
        Else
            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = email_TextBox.Text
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Password"
            p.Value = password_TextBox.Text
            cmd.Parameters.Add(p)
            Session(Session("TokenID") + "SignInType") = "Normal"
        End If
        Dim dset As New DataSet
        Dim dpt As New SqlDataAdapter
        dpt.SelectCommand = cmd
        dpt.Fill(dset, "SignupType")
        If dset.Tables("SignupType").Rows.Count > 0 Then
            If dset.Tables("SignupType").Rows(0)("SignupType").ToString = "Google" And Session(Session("TokenID") + "SignInType") = "Normal" Then
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'You used Google Sign Up to register yourself, please use Google Sign In now to log back in.');", True)
            ElseIf dset.Tables("SignupType").Rows(0)("SignupType").ToString = "Normal" And Session(Session("TokenID") + "SignInType") = "Google" Then
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'You did not use Google Sign Up to register yourself, please login with your credentials that you used to sign up with.');", True)
            Else
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Incorrect Passowrd!', 'Please re-check your password and enter the correct one.');", True)
            End If
            Session(Session("TokenID") + "ContinueCheck") = "False"
        Else
            Session(Session("TokenID") + "ContinueCheck") = "True"
        End If
        con.Close()
    End Sub

    Private Sub Author_log_in_Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        If Not String.IsNullOrEmpty(Request.QueryString("code")) Then
            Session(Session("TokenID") + "LoginGoogleCode") = Request.QueryString("code")
            GoogleConnect.Clear(Request.QueryString("code"))
        End If
        GoogleConnect.ClientId = System.Configuration.ConfigurationManager.AppSettings("GoogleClientId")
        GoogleConnect.ClientSecret = System.Configuration.ConfigurationManager.AppSettings("GoogleClientSecret")
        GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split("?"c)(0)
        If Not IsPostBack Then
            If Session(Session("TokenID") + "LoginGoogleCode") <> "" Then
                Dim code As String = Session(Session("TokenID") + "LoginGoogleCode")
                Dim json As String = GoogleConnect.Fetch("me", code)
                Dim profile As GoogleProfile = New JavaScriptSerializer().Deserialize(Of GoogleProfile)(json)
                Session(Session("TokenID") + "profileEmail") = profile.Email
                Session(Session("TokenID") + "profileID") = profile.Id
                Userlogin()
            End If
            If Request.QueryString("error") = "access_denied" Then
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Alert', 'Access denied.');", True)
            End If
            If Request.QueryString("AC") <> Nothing And Request.QueryString("U") <> Nothing Then
                Try
                    cmd.Parameters.Clear()
                    cmd.CommandText = "VerifyAccount_Update"
                    cmd.CommandType = CommandType.StoredProcedure

                    p = New SqlParameter
                    p.ParameterName = "@UserID"
                    p.Value = Request.QueryString("U")
                    cmd.Parameters.Add(p)

                    p = New SqlParameter
                    p.ParameterName = "@Activation"
                    p.Value = Request.QueryString("AC")
                    cmd.Parameters.Add(p)

                    cmd.ExecuteNonQuery()
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Verified &#9989;', 'Your account has been verified, you are good to go now.');", True)
                Catch

                End Try
            End If
        End If
    End Sub
    Private Sub CreateyourAccount_ServerClick(sender As Object, e As EventArgs) Handles CreateyourAccount.ServerClick
        Session(Session("TokenID") + "SubscriptionExpiryDateEntry") = (Date.Today).AddDays(3)
        Session(Session("TokenID") + "PackageTypeEntry") = "Trial"
        Session(Session("TokenID") + "NewUserID") = ""
        Session(Session("TokenID") + "ActivationCode") = ""
        Session(Session("TokenID") + "profileEmail") = ""
        Session(Session("TokenID") + "profileName") = ""
        Session(Session("TokenID") + "profileID") = ""
        Session(Session("TokenID") + "GoogleSignup") = ""
        Session(Session("TokenID") + "SignupGoogleCode") = ""
        Session(Session("TokenID") + "LoginGoogleCode") = ""
        Session(Session("TokenID") + "SignInType") = ""
        Response.Redirect("/UserRegistration.aspx")
    End Sub

    Protected Sub Userlogin()
        If con.State = False Then
            con.Open()
        End If
        Load_User_By_SignupType()
        If Session(Session("TokenID") + "ContinueCheck") = "False" Then
        Else
            cmd.Parameters.Clear()
            cmd.CommandText = "User_login"
            cmd.CommandType = CommandType.StoredProcedure
            If Session(Session("TokenID") + "GoogleLogin") = "True" Then
                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = Session(Session("TokenID") + "profileEmail")
                email_TextBox.Text = Session(Session("TokenID") + "profileEmail")
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@Password"
                p.Value = Session(Session("TokenID") + "profileID")
                cmd.Parameters.Add(p)
                Session(Session("TokenID") + "SignInType") = "Google"
            Else
                Session(Session("TokenID") + "SignInType") = "Normal"
                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = email_TextBox.Text
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@Password"
                p.Value = password_TextBox.Text
                cmd.Parameters.Add(p)
            End If
            Dim dset As New DataSet
            Dim dpt As New SqlDataAdapter
            dpt.SelectCommand = cmd
            dpt.Fill(dset, "check_login")
            If (dset.Tables("check_login").Rows.Count > 0) Then
                Session("TokenID") = Guid.NewGuid().ToString + dset.Tables("check_login").Rows(0)("UserID").ToString()
                load_author_id()
                save_cookie()
                'If Session(Session("TokenID") + "PackageType") = "Trial" Then
                '    Response.Redirect("/Home.aspx")
                'Else
                '    Response.Redirect("/UserDashboard.aspx")
                'End If
                Response.Redirect("/UserDashboard.aspx")
            Else
                cmd.Parameters.Clear()
                cmd.CommandText = "NewUser_Search"
                cmd.CommandType = CommandType.StoredProcedure

                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = email_TextBox.Text
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@Password"
                p.Value = password_TextBox.Text
                cmd.Parameters.Add(p)

                Dim dset2 As New DataSet
                Dim dpt2 As New SqlDataAdapter
                dpt2.SelectCommand = cmd
                dpt2.Fill(dset2, "check_login2")
                If dset2.Tables("check_login2").Rows.Count > 0 Then
                    Dim UserIDUnverified As Integer = dset2.Tables("check_login2").Rows(0)("UserID")
                    Dim ActivationCodeUnverified As String = dset2.Tables("check_login2").Rows(0)("Activation").ToString()
                    Dim NameUnverified As String = dset2.Tables("check_login2").Rows(0)("Name").ToString()
                    mail_send(UserIDUnverified, ActivationCodeUnverified, NameUnverified)
                    Session("TokenID") = Guid.NewGuid().ToString + dset2.Tables("check_login2").Rows(0)("UserID").ToString()
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Not Verified', 'Please check your email box and verify your email address to login.');", True)
                Else
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'Please be honest with your information and re-try.');", True)
                End If
            End If
        End If
        Session(Session("TokenID") + "profileEmail") = ""
        Session(Session("TokenID") + "profileID") = ""
        Session(Session("TokenID") + "GoogleLogin") = ""
        Session(Session("TokenID") + "LoginGoogleCode") = ""
        Session(Session("TokenID") + "SignInType") = ""
        Session(Session("TokenID") + "ContinueCheck") = ""
        cmd.Parameters.Clear()
        con.Close()
    End Sub
    Protected Sub mail_send(UserID As Integer, Activation As String, Name As String)
        Try
            Using mm As New MailMessage(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), email_TextBox.Text)
                mm.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), "Ebox Marketing Solutions")
                mm.Subject = "Bulk Email Sender - Account Activation"
                Dim body As String = "<br/><b>Dear " + Name + ",</b>"
                body += "<br /><br />Please click the following link to activate your account which will redirect you to the login page."
                body += "<br /><a href = '" + ("https://www.eboxmarketing.com/UserLogin.aspx?AC=") & Activation + "&U=" & UserID.ToString + "'>Click here to activate your account.</a>"
                body += "<br /><br /><b>Kind Regards,</b>"
                body += "<br />EBox Marketing Solutions"
                mm.Body = body
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                smtp.UseDefaultCredentials = True
                Dim NetworkCred As New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), System.Configuration.ConfigurationManager.AppSettings("SmtpPassword"))
                smtp.Credentials = NetworkCred
                smtp.Port = 587
                smtp.Send(mm)
            End Using
            'Open this link and allow less secure devices to send the mails and authenticate
            'https://www.google.com/settings/security/lesssecureapps 
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        If password_TextBox.Text = "" Then
            EventValidation4.Text = ""
            password_TextBox.Attributes.Add("style", "border:1px solid #c7c7c7!important;")
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'Looks like you forgot to write your password.');", True)
        Else
            password_TextBox.Attributes.Add("style", "border:0!important;")
            Session(Session("TokenID") + "GoogleLogin") = False
            Userlogin()
        End If
    End Sub

    Private Sub ChangeForgotPasswordBtn_Click(sender As Object, e As EventArgs) Handles ChangeForgotPasswordBtn.Click
        Response.Redirect("~/ForgotPasswordForm.aspx")
    End Sub
End Class
