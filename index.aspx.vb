
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub mail_send()
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        Try
            Using mm As New MailMessage(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), System.Configuration.ConfigurationManager.AppSettings("SmtpUser"))
                mm.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), contactName.Value)
                mm.Subject = contactSubject.Value
                Dim body As String = "<br/><b>" + contactName.Value + " has sent an email to you, using email address: " + contactEmail.Value + " has sent you an email,</b>"
                body += "<br /><br />" + contactMessage.Value
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

    Private Sub SubmitMailBtn_ServerClick(sender As Object, e As EventArgs) Handles SubmitMailBtn.ServerClick
        mail_send()
    End Sub

End Class
