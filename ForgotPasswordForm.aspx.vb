Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net
Partial Class ForgotPassword
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter
    Dim activation_code As String
    Dim author_id As String
    Dim repeating_status As Integer

    Private Sub ForgotPassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        If Not IsPostBack Then
            EmailDiv.Visible = True
            VerificationCodeDiv.Visible = False
            NewPasswordDiv.Visible = False
            ConfirmPasswordDiv.Visible = False
            SubmitBtn.Visible = True
            VerifyBtn.Visible = False
            SaveChangesBtn.Visible = False
        End If
    End Sub

    Private Sub CheckPasswords()
        If NewPassword.Text = "" Then
            NewPasswordValidation.Text = "*"
            NewPassword.Attributes.Add("style", "border:1px solid red!important;")
        End If
        If ConfirmPassword.Text = "" Then
            ConfirmPasswordValidation.Text = "*"
            ConfirmPassword.Attributes.Add("style", "border:1px solid red!important;")
        End If
    End Sub

    Private Sub CheckEmail()
        If con.State = False Then
            con.Open()
        End If
        If EmailAddress.Text = "" Then
            EmailValidation.Text = "*"
            EmailAddress.Attributes.Add("style", "border:1px solid red!important;")
        End If
        con.Close()
    End Sub

    Private Sub CheckCode()
        If VerificationCode.Text = "" Then
            VerificationCodeValidation.Text = "*"
            VerificationCode.Attributes.Add("style", "border:1px solid red!important;")
        End If
    End Sub

    Protected Sub VerificationMail()
        If con.State = False Then
            con.Open()
        End If
        Try
            Using mm As New MailMessage(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), EmailAddress.Text)
                mm.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), "Ebox Marketing Solutions")
                mm.Subject = "Password Reset Verification Code"
                Dim a As String = Guid.NewGuid().ToString().Substring(0, 6)
                Session(Session("TokenID") + "VerificationCode") = a
                Dim body As String = "Your Verification Code Is " + a
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

    'Protected Sub VerificationCode_TextChanged(sender As Object, e As EventArgs)
    '    If VerificationCode.Text <> "" Then
    '        EventValidation.Text = ""
    '        VerificationCodeValidation.Text = ""
    '        VerificationCode.Attributes.Add("style", "border:1px solid #c7c7c7!important;")
    '    End If
    'End Sub
    Protected Sub EmailAddress_TextChanged(sender As Object, e As EventArgs)
        If EmailAddress.Text <> "" Then
            EventValidation.Text = ""
            EmailValidation.Text = ""
            EmailAddress.Attributes.Add("style", "border:1px solid #c7c7c7!important;")
        End If
        IsValidEmailFormat(EmailAddress.Text)
    End Sub

    Function IsValidEmailFormat(ByVal s As String) As Boolean
        If Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Invalid Email!', 'Email is not in correct format.');", True)
        End If
    End Function
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
    Protected Sub NewPassword_TextChanged(sender As Object, e As EventArgs)
        If NewPassword.Text <> "" Then
            EventValidation.Text = ""
            NewPasswordValidation.Text = ""
            NewPassword.Attributes.Add("style", "border:1px solid #c7c7c7!important;")
        End If
        Select Case PasswordStrength(NewPassword.Text)
            Case 0
                EventValidation4.Text = "Your password should be atleast 6 characters long."
                EventValidation4.ForeColor = System.Drawing.Color.Crimson
            Case 1
                EventValidation4.Text = "It will work but your password is still weak."
                EventValidation4.ForeColor = System.Drawing.Color.BlueViolet
            Case 2
                EventValidation4.Text = "Alot better, try adding a symbol or numeric digit."
                EventValidation4.ForeColor = System.Drawing.Color.Goldenrod
            Case 3
                EventValidation4.Text = "A Perfect Piece of String!"
                EventValidation4.ForeColor = System.Drawing.Color.Green
        End Select
    End Sub

    Protected Sub ConfirmPassword_TextChanged(sender As Object, e As EventArgs)
        If ConfirmPassword.Text <> "" Then
            EventValidation.Text = ""
            ConfirmPasswordValidation.Text = ""
            ConfirmPassword.Attributes.Add("style", "border:1px solid #c7c7c7!important;")
        End If
        If NewPassword.Text <> ConfirmPassword.Text Then
            EventValidation5.Text = "Passwords did not match."
            EventValidation4.ForeColor = System.Drawing.Color.Crimson
        Else
            EventValidation5.Text = "Passwords matched."
            EventValidation4.ForeColor = System.Drawing.Color.Green
        End If
    End Sub



    Protected Sub ResetPassword()

        cmd.CommandText = "Reset_Password"
        cmd.CommandType = CommandType.StoredProcedure

        p = New SqlParameter
        p.ParameterName = "@EmailAddress"
        p.Value = EmailAddress.Text
        cmd.Parameters.Add(p)

        p = New SqlParameter
        p.ParameterName = "@NewPassword"
        p.Value = ConfirmPassword.Text
        cmd.Parameters.Add(p)

        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()

    End Sub

    Private Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click

        If con.State = False Then
            con.Open()
        End If
        CheckEmail()
        If EmailAddress.Text <> "" Then
            cmd.Parameters.Clear()
            cmd.CommandText = "User_Email_Repetition_Search"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = EmailAddress.Text
            cmd.Parameters.Add(p)
            Dim d As New DataSet
            Dim dpt As New SqlDataAdapter
            dpt.SelectCommand = cmd
            dpt.Fill(d, "tab")
            If d.Tables("tab").Rows(0)("cnt") > 0 Then
                VerificationMail()
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Found Your Email!', 'Please enter the code fromy your Email.');", True)
                EmailDiv.Visible = False
                VerificationCodeDiv.Visible = True
                NewPasswordDiv.Visible = False
                ConfirmPasswordDiv.Visible = False
                SubmitBtn.Visible = False
                VerifyBtn.Visible = True
                SaveChangesBtn.Visible = False
            Else
                ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('404: Not Found!', 'This email does not exist. Please try again.');", True)
            End If

        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'You may have left the email field empty.');", True)
        End If
        con.Close()
    End Sub

    Private Sub VerifyBtn_Click(sender As Object, e As EventArgs) Handles VerifyBtn.Click
        If con.State = False Then
            con.Open()
        End If
        CheckCode()
        If VerificationCode.Text = Session(Session("TokenID") + "VerificationCode") Then
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Code Matched!', 'Now you can enter a new password.');", True)
            EmailDiv.Visible = False
            VerificationCodeDiv.Visible = False
            NewPasswordDiv.Visible = True
            ConfirmPasswordDiv.Visible = True
            SubmitBtn.Visible = False
            VerifyBtn.Visible = False
            SaveChangesBtn.Visible = True
        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Oops!', 'The code did not match.');", True)
        End If
        con.Close()
    End Sub

    Private Sub SaveChangesBtn_Click(sender As Object, e As EventArgs) Handles SaveChangesBtn.Click

        If con.State = False Then
            con.Open()
        End If
        CheckPasswords()
        If NewPassword.Text <> ConfirmPassword.Text Then
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Sorry!', 'Your new password did not match with the confirm password.');", True)
            EmailDiv.Visible = False
            VerificationCodeDiv.Visible = False
            NewPasswordDiv.Visible = True
            ConfirmPasswordDiv.Visible = True
        Else
            ResetPassword()
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "LoginExpired('Success!', 'Your password has been reset successfully.');", True)
        End If
        con.Close()
    End Sub
End Class
