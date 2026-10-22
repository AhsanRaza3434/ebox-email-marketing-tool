Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Sockets
Imports ASPSnippets.GoogleAPI
Imports System.Web.Script.Serialization

Partial Class Default3
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter
    Dim activation_code As String
    Dim author_id As String
    Dim repeating_status As Integer
    Dim validatedEmail As Integer

    Private Sub GmailLoginBtn_Click(sender As Object, e As EventArgs) Handles GmailLoginBtn.Click
        'GoogleConnect.Clear(Request.QueryString("code"))
        Session(Session("TokenID") + "GoogleSignup") = "True"
        GoogleConnect.Authorize("profile", "email")
    End Sub
    Public Class GoogleProfile
        Public Property Id() As String
        Public Property Email() As String
        Public Property Name() As String
    End Class
    Private Sub Sava_button_Click(sender As Object, e As EventArgs) Handles Sava_button.Click

        If repeating_status = 1 Then

        ElseIf repeating_status = 0 Then
            If author_email_TextBox.Text <> "" And author_first_name_TextBox.Text <> "" And NewPassword.Text <> "" And author_password_TextBox.Text <> "" Then
                If NewPassword.Text.Count >= 6 Then
                    If NewPassword.Text = author_password_TextBox.Text Then
                        Generate_UserID()
                        mail_send()
                        insert()
                        Session(Session("TokenID") + "NewUserID") = ""
                        Session(Session("TokenID") + "ActivationCode") = ""
                        validatedEmail = 0
                        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "LoginExpired('Success! &#9989;', 'Success! Please verify your email address to continue.');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Something went wrong!', 'Your confirm password did not match to the new passwod.');", True)
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Check Password!', 'Your password should be atleast 6 characters long.');", True)
                End If
            Else
                CheckFields()
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'You left something empty.');", True)
            End If
        End If
    End Sub
    Private Sub CheckFields()
        If con.State = False Then
            con.Open()
        End If
        If author_password_TextBox.Text = "" Then
            author_password_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        Else
            author_password_TextBox.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
        End If
        If author_email_TextBox.Text = "" Then
            author_email_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        Else
            author_email_TextBox.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
        End If
        If author_first_name_TextBox.Text = "" Then
            author_first_name_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        Else
            author_first_name_TextBox.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
        End If
        If NewPassword.Text = "" Then
            NewPassword.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        Else
            NewPassword.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
        End If
        EventValidation.Text = "You must fill all the * fields."
        con.Close()
    End Sub
    Private Sub Author_Signup_page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        If Not IsPostBack Then
            If Request.QueryString("EmailAddress") <> Nothing And Request.QueryString("UserID") <> Nothing And Request.QueryString("Sr") <> Nothing And Request.QueryString("ReadStatus") <> Nothing And Request.QueryString("EmailType") <> Nothing Then
                UpdateReadReceipt(Request.QueryString("EmailAddress"), Request.QueryString("UserID"), Request.QueryString("Sr"), Request.QueryString("ReadStatus"), Request.QueryString("EmailType"))
                'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "Email has been read', 'Email Address:' + '" & Request.QueryString("EmailAddress") & "' + 'User ID:' + '" & Request.QueryString("UserID") & "' + 'Sr:' + '" & Request.QueryString("Sr") & "' + 'ReadStatus:' + '" & Request.QueryString("ReadStatus") & "' + 'Email Type:' + '" & Request.QueryString("EmailType") & "');", True)
            End If
            EventValidation4.Text = "Must be 6 characters long*"
        End If
    End Sub


    Protected Sub UpdateReadReceipt(Email As String, UserID As Integer, Sr As Integer, ReadStatus As String, EmailType As String)
        If con.State = False Then
            con.Open()
        End If
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "UpdateReadReceipt_Modify"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = UserID
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = Email
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Sr"
            p.Value = Sr
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@ReadStatus"
            p.Value = ReadStatus
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@EmailType"
            p.Value = EmailType
            cmd.Parameters.Add(p)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub



    Private Sub Generate_UserID()
        If con.State = False Then
            con.Open()
        End If
        Dim Adp As SqlDataAdapter = New SqlDataAdapter("select top 1 UserID from Users_Management order by UserID DESC ", con)
        Dim dst As New DataSet
        Dim dt As New DataTable
        Adp.Fill(dst, "UserManagement_UserID")
        dt = dst.Tables("UserManagement_UserID")
        If dt.Rows.Count > 0 Then
            Session(Session("TokenID") + "NewUserID") = dst.Tables("UserManagement_UserID").Rows(0)("UserID") + 1
        Else
            Session(Session("TokenID") + "NewUserID") = 10340001
        End If

        activation_code = Guid.NewGuid().ToString()
        Session(Session("TokenID") + "ActivationCode") = activation_code
        con.Close()
    End Sub
    Protected Sub check_repearting()
        If con.State = False Then
            con.Open()
        End If
        cmd.Parameters.Clear()
        cmd.CommandText = "User_Email_Repetition_Search"
        cmd.CommandType = CommandType.StoredProcedure

        p = New SqlParameter
        p.ParameterName = "@EmailAddress"
        p.Value = author_email_TextBox.Text
        cmd.Parameters.Add(p)
        Dim d As New DataSet
        Dim dpt As New SqlDataAdapter
        dpt.SelectCommand = cmd
        dpt.Fill(d, "tab")
        If d.Tables("tab").Rows(0)("cnt") > 0 Then
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('We are sorry!', 'But the email you are trying is already taken.');", True)
            repeating_status = 1
        Else
            repeating_status = 0
        End If
        con.Close()

    End Sub
    Protected Sub mail_send()
        If con.State = False Then
            con.Open()
        End If
        Try
            Using mm As New MailMessage(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), author_email_TextBox.Text)
                mm.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), "Ebox Marketing Solutions")
                mm.Subject = "Bulk Email Sender - Account Activation"
                Dim body As String = "<br/><b>Dear " + author_first_name_TextBox.Text + ",</b>"
                body += "<br /><br />Please click the following link to activate your account which will redirect you to the login page."
                body += "<br /><a href = '" + ("https://www.eboxmarketing.com/UserLogin.aspx?AC=") & Session(Session("TokenID") + "ActivationCode") + "&U=" & Session(Session("TokenID") + "NewUserID").ToString + "'>Click here to activate your account.</a>"
                body += "<br /><br /><b>Kind Regards,</b>"
                body += "<br />EBox Marketing Solutions"
                mm.Body = body
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), System.Configuration.ConfigurationManager.AppSettings("SmtpPassword"))
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = 587
                smtp.Send(mm)
            End Using
            'Open this link and allow less secure devices to send the mails and authenticate
            'https://www.google.com/settings/security/lesssecureapps 
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    Protected Sub author_first_name_TextBox_TextChanged(sender As Object, e As EventArgs)
        If author_first_name_TextBox.Text = "" Then
            author_first_name_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        Else
            author_first_name_TextBox.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
            author_email_TextBox.Focus()
        End If
    End Sub

    Protected Sub author_email_TextBox_TextChanged(sender As Object, e As EventArgs)
        IsValidEmailFormat(author_email_TextBox.Text)
        check_repearting()
        If author_email_TextBox.Text <> "" And validatedEmail = 1 And repeating_status = 0 Then
            EventValidation3.Text = "Available!"
            EventValidation3.ForeColor = System.Drawing.Color.Green
            author_email_TextBox.Attributes.Add("style", "border-bottom:1px solid #c7c7c7!important;")
            author_email_TextBox.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
            NewPassword.Focus()
        Else
            EventValidation3.Text = "Unavailable!"
            EventValidation3.ForeColor = System.Drawing.Color.Crimson
            author_email_TextBox.Focus()
            author_email_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        End If
        'EmailValidation()
    End Sub

    'Private Sub EmailValidation()
    '    Try
    '        Dim host As String() = author_email_TextBox.Text.Split("@"c)
    '        Dim hostname As String = host(1)
    '        Dim IPhst As IPHostEntry = Dns.GetHostEntry(hostname)
    '        Dim endPt As IPEndPoint = New IPEndPoint(IPhst.AddressList(0), 25)
    '        Dim s As Socket = New Socket(endPt.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
    '        s.Connect(endPt)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Function IsValidEmailFormat(ByVal s As String) As Boolean
        If Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
            validatedEmail = 1
        Else
            validatedEmail = 0
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Invalid Format!', 'Email is not in correct format.');", True)
        End If

    End Function

    Protected Sub author_password_TextBox_TextChanged(sender As Object, e As EventArgs)
        If NewPassword.Text = author_password_TextBox.Text Then
            EventValidation.Text = ""
            EventValidation5.Text = "Passwords Matched!"
            EventValidation5.ForeColor = Drawing.Color.Green
            author_password_TextBox.Attributes.Add("style", "border-bottom:1px solid #c7c7c7!important;")
        ElseIf NewPassword.Text <> author_password_TextBox.Text Then
            EventValidation.Text = ""
            EventValidation5.Text = "Passwords Didn't Matched!"
            EventValidation5.ForeColor = Drawing.Color.Crimson
            author_password_TextBox.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
            NewPassword.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        End If
        Sava_button.Focus()
    End Sub
    Protected Sub author_password_TextBox_TextChanged2(sender As Object, e As EventArgs)
        If NewPassword.Text <> "" Then
            EventValidation.Text = ""
            NewPassword.Attributes.Add("style", "border-bottom:1px solid #d0d0d0 !important;")
        Else
            NewPassword.Attributes.Add("style", "border-bottom:1px solid Crimson!important;")
        End If
        Select Case PasswordStrength(NewPassword.Text)
            Case 0
                EventValidation4.Text = "Your password should be atleast 6 characters long."
                EventValidation4.ForeColor = System.Drawing.Color.Crimson
                NewPassword.Focus()
            Case 1
                EventValidation4.Text = "It will work but your password is still weak."
                EventValidation4.ForeColor = System.Drawing.Color.BlueViolet
                author_password_TextBox.Focus()
            Case 2
                EventValidation4.Text = "Alot better, try adding a symbol or numeric digit."
                EventValidation4.ForeColor = System.Drawing.Color.Goldenrod
                author_password_TextBox.Focus()
            Case 3
                EventValidation4.Text = "A Perfect Piece of String!"
                EventValidation4.ForeColor = System.Drawing.Color.Green
                author_password_TextBox.Focus()
        End Select
    End Sub
    Private Function PasswordStrength(ByVal password As String) As Integer
        Dim strength As Integer = 0
        If NewPassword.Text.Count >= 6 Then
            If password.Any(Function(x) Char.IsLetter(x)) Then
                strength += 1
            End If
            If password.Any(Function(x) Char.IsDigit(x)) Then
                strength += 1
            End If
            If password.Any(Function(x) Char.IsPunctuation(x) Or Char.IsSymbol(x)) Then
                strength += 1
            End If
        Else
            strength = 0
        End If
        Return strength
    End Function

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If Not String.IsNullOrEmpty(Request.QueryString("code")) Then
            Session(Session("TokenID") + "SignupGoogleCode") = Request.QueryString("code")
            GoogleConnect.Clear(Request.QueryString("code"))
        End If
        GoogleConnect.ClientId = System.Configuration.ConfigurationManager.AppSettings("GoogleClientId")
        GoogleConnect.ClientSecret = System.Configuration.ConfigurationManager.AppSettings("GoogleClientSecret")
        GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split("?"c)(0)
        If Not IsPostBack Then
            If Session(Session("TokenID") + "SignupGoogleCode") <> "" Then
                Dim code As String = Session(Session("TokenID") + "SignupGoogleCode")
                Dim json As String = GoogleConnect.Fetch("me", code)
                Dim profile As GoogleProfile = New JavaScriptSerializer().Deserialize(Of GoogleProfile)(json)
                Session(Session("TokenID") + "profileEmail") = profile.Email
                author_email_TextBox.Text = profile.Email
                Session(Session("TokenID") + "profileName") = profile.Name
                Session(Session("TokenID") + "profileID") = profile.Id
                check_repearting()
                If repeating_status = 1 Then
                    author_email_TextBox.Text = ""
                    Session(Session("TokenID") + "SignupGoogleCode") = ""
                ElseIf repeating_status = 0 Then
                    author_email_TextBox.Text = ""
                    Generate_UserID()
                    insert()
                    load_author_id()
                    save_cookie()
                    'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "SubExpiry('Success', 'Dear " & profile.Name & "' + ', your trial has been activited successfully which will expire in 3 days.');", True)
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "SubExpiry('Success', 'Welcome " & profile.Name & "' + '! Lets start sending free bulk emails right away.');", True)
                End If
            End If
            If Request.QueryString("error") = "access_denied" Then
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Alert', 'Access denied.');", True)
            End If
        End If

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
        p.Value = Session(Session("TokenID") + "profileEmail")
        cmd.Parameters.Add(p)
        Dim dset As New DataSet
        Dim dpt As New SqlDataAdapter
        dpt.SelectCommand = cmd
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

    Protected Sub insert()
        If con.State = False Then
            con.Open()
        End If
        Try
            Dim AvailableEmails As Integer
            Dim SubscriptionDays As Integer
            Dim RemainingSendableEmails As Integer
            Dim RemainingFollowUpEmails As Integer
            cmd.Parameters.Clear()
            cmd.CommandText = "User_Signup_Insert"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "NewUserID")
            cmd.Parameters.Add(p)
            If Session(Session("TokenID") + "GoogleSignup") = "True" Then
                p = New SqlParameter
                p.ParameterName = "@UserName"
                p.Value = Session(Session("TokenID") + "profileName")
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = Session(Session("TokenID") + "profileEmail")
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@Password"
                p.Value = Session(Session("TokenID") + "profileID")
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@VerificationStatus"
                p.Value = "1"
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@SignupType"
                p.Value = "Google"
                cmd.Parameters.Add(p)

            Else
                p = New SqlParameter
                p.ParameterName = "@UserName"
                p.Value = author_first_name_TextBox.Text
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = author_email_TextBox.Text
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@Password"
                p.Value = NewPassword.Text
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@VerificationStatus"
                p.Value = "0"
                cmd.Parameters.Add(p)

                p = New SqlParameter
                p.ParameterName = "@SignupType"
                p.Value = "Normal"
                cmd.Parameters.Add(p)

            End If
            p = New SqlParameter
            p.ParameterName = "@Activation"
            p.Value = Session(Session("TokenID") + "ActivationCode")
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@PackageType"
            p.Value = Session(Session("TokenID") + "PackageTypeEntry")
            cmd.Parameters.Add(p)

            'If Session(Session("TokenID") + "PackageTypeEntry") = "Trial" Then
            '    SubscriptionDays = 3
            '    AvailableEmails = 100
            '    RemainingSendableEmails = 300
            '    RemainingFollowUpEmails = 300
            'ElseIf Session(Session("TokenID") + "PackageTypeEntry") = "Business" Then
            '    SubscriptionDays = 30
            '    AvailableEmails = 500
            '    RemainingSendableEmails = 15000
            '    RemainingFollowUpEmails = 15000
            'ElseIf Session(Session("TokenID") + "PackageTypeEntry") = "Premium" Then
            '    SubscriptionDays = 30
            '    AvailableEmails = 100000
            '    RemainingSendableEmails = 100000
            '    RemainingFollowUpEmails = 100000
            'End If

            SubscriptionDays = 30
            AvailableEmails = 100000
            RemainingSendableEmails = 100000
            RemainingFollowUpEmails = 100000
            p = New SqlParameter
            p.ParameterName = "@SubscriptionDays"
            p.Value = SubscriptionDays
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@AvailableEmails"
            p.Value = AvailableEmails
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@RemainingSendableEmails"
            p.Value = RemainingSendableEmails
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@RemainingFollowUpEmails"
            p.Value = RemainingFollowUpEmails
            cmd.Parameters.Add(p)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub
End Class
