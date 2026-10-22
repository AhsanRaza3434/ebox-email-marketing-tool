Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports EASendMail
Imports SmtpClient = EASendMail.SmtpClient

Partial Class Default3
    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter
    Dim activation_code As String
    Dim author_id As String
    Dim repeating_status As Integer

    Private Sub SendMailWithXOAUTH2(ByVal userEmail As String, ByVal accessToken As String)

        ' Gmail SMTP server address
        Dim oServer As SmtpServer = New SmtpServer("smtp.gmail.com")
        Dim i = 0
        Dim t = 0
        Dim dst2 As New DataSet
        Dim dt12 As New DataTable
        Dim SendableEmails As Integer
        Session(Session("TokenID") + "LetterBodyText") = LetterBody.Text
        Session(Session("TokenID") + "LetterSubjectText") = LetterSubject.Text
        Dim myDir As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "folderPath"))
        Dim myDir2 As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "LetterBodyAttachmentFolderPath"))
        dt12 = Session(Session("TokenID") + "TokenID3")
        radGrid2.DataSource = dst2.Tables("CallCenter_LetterBody1")
        While i < dt12.Rows.Count
            If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
                LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
            Else
                LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
                LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
            End If
            Session(Session("TokenID") + "Emails") = dt12.Rows(i)("Emails").ToString()
            If Session(Session("TokenID") + "Emails") <> "" Then
                Session(Session("TokenID") + "Names") = dt12.Rows(i)("Name")
                Session(Session("TokenID") + "CompanyNames") = dt12.Rows(i)("Company")
                Session(Session("TokenID") + "Sr") = dt12.Rows(i)("Sr")
                Session(Session("TokenID") + "SenderEmail") = userEmail
                ' set user authentication
                oServer.User = userEmail
                'oMail.From = Session(Session("TokenID") + "SenderEmail").ToString()
                If SenderCompanyEmailAddress.Text = "" Then
                    Session(Session("TokenID") + "SenderCompanyEmail") = userEmail
                Else
                    Session(Session("TokenID") + "SenderCompanyEmail") = SenderCompanyEmailAddress.Text
                End If
                If dt12.Rows.Count > 0 Then
                    Try
                        ' enable SSL connection
                        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto
                        ' Using 587 port, you can also use 465 port
                        oServer.Port = 587

                        ' use SMTP OAUTH 2.0 authentication
                        oServer.AuthType = SmtpAuthType.XOAUTH2
                        ' set user authentication
                        Session(Session("TokenID") + "accessToken") = accessToken
                        ' use access token as password
                        oServer.Password = Session(Session("TokenID") + "accessToken").ToString()

                        Dim oMail As SmtpMail = New SmtpMail("TryIt")
                        oMail.From = New EASendMail.MailAddress(SenderName.Text, Session(Session("TokenID") + "SenderCompanyEmail").ToString())
                        oMail.[To] = Session(Session("TokenID") + "Emails").ToString()
                        If dt12.Rows(i).Item("Name") Is DBNull.Value Then
                        Else
                            Dim SubjectText = LetterSubject.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
                            Dim newText = LetterBody.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                        End If
                        If dt12.Rows(i).Item("Company") Is DBNull.Value Then
                        Else
                            Dim SubjectText = LetterSubject.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            Dim newText = LetterBody.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                        End If
                        oMail.Subject = LetterSubject.Text
                        Dim body As String
                        body = LetterBody.Text
                        body += "<img src='https://www.eboxmarketing.com/UserRegistration.aspx?EmailAddress=" + Session(Session("TokenID") + "Emails") + "&UserID=" + Session(Session("TokenID") + "UserID").ToString + "&Sr=" + Session(Session("TokenID") + "Sr").ToString + "&ReadStatus=Opened&EmailType=Sent'" + " width=0 height=0>"
                        If (myDir.EnumerateFiles().Any()) Then
                            Try
                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "folderPath"), "*", IO.SearchOption.AllDirectories)
                                    oMail.AddAttachment(s)
                                Next
                            Catch ex As Exception
                                'MsgBox(ex.Message)
                            End Try
                        End If
                        If (myDir2.EnumerateFiles().Any()) Then
                            Try
                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "LetterBodyAttachmentFolderPath"), "*", IO.SearchOption.AllDirectories)
                                    If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                                        body += "<br/><img src='https://www.eboxmarketing.com/InnerAttachments/" + Session(Session("TokenID") + "AttachedImagePath").ToString + "' height=150>"
                                    Else
                                        oMail.HtmlBody = body
                                    End If
                                Next
                            Catch ex As Exception
                                'MsgBox(ex.Message)
                            End Try
                        End If
                        oMail.HtmlBody = body

                        If CCBCCText.Text = "CC Email" And CCBCCBothText.Text = "" Then
                            oMail.Cc.Add(CCBCCTextbox.Text)
                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "" Then
                            oMail.Bcc.Add(CCBCCTextbox.Text)
                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "CC Email" Then
                            oMail.Bcc.Add(CCBCCTextbox.Text)
                            oMail.Cc.Add(CCBCCTextboxBoth.Text)
                        Else

                        End If

                        Dim oSmtp As SmtpClient = New SmtpClient()
                        oSmtp.SendMail(oServer, oMail)

                        updateMailShedule()
                        t = t + 1

                    Catch ex As Exception
                        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                            LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
                            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
                        Else
                            LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
                            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
                        End If
                        Session(Session("TokenID") + "LetterBodyTextPrevious") = Session(Session("TokenID") + "LetterBodyText")
                        'MsgBox(ex.Message)
                        'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', 'Please make sure that you have allowed less secure devices through above link & your email address & password are correct.');", True)
                        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', '" + ex.Message + "');", True)
                    End Try
                Else
                    NotificationText.Text = "Alert: " + "Please Import Emails First To Send An Email."
                End If
            Else
                NotificationText.Text = "Alert: " + "Please make sure the Email Addresses are imported and in correct format."
            End If
            i = i + 1
        End While
        If Session(Session("TokenID") + "Emails") <> "" And t <> 0 Then
            'Session(Session("TokenID") + "TotalEmails") = SendableEmails
            'RemainingSendableEmailsFunc(SendableEmails)
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Success!', '" & t & "' + ' Email(s) have been sent.');", True)
            dst2.Clear()
            DeleteAttachments()
        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Failed!', 'Please make sure that you have imported emails and your email address & password are correct.');", True)
        End If

        Console.WriteLine("The email has been submitted to server successfully!")
    End Sub

    'Protected Sub Followup_mail_send()
    '    Dim i = 0
    '    Dim t = 0
    '    Dim dst As New DataSet
    '    Dim dt1 As New DataTable
    '    Dim SendableFollowups As Integer
    '    Session(Session("TokenID") + "LetterBodyText") = LetterBody.Text
    '    Session(Session("TokenID") + "LetterSubjectText") = LetterSubject.Text
    '    Dim myDir As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "folderPath"))
    '    dt1 = Session(Session("TokenID") + "TokenID")
    '    radGrid1.DataSource = dst.Tables("CallCenter_LetterBody")

    '    'If Session(Session("TokenID") + "PackageType") <> "Premium" Then
    '    '    If dt1.Rows.Count > RemainingFollowUpEmailsText.Text Then
    '    '        SendableFollowups = RemainingFollowUpEmailsText.Text
    '    '    Else
    '    '        SendableFollowups = dt1.Rows.Count
    '    '    End If
    '    'Else
    '    '    SendableFollowups = dt1.Rows.Count
    '    'End If
    '    While i < dt1.Rows.Count
    '        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '            LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
    '            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '        Else
    '            LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
    '            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '        End If
    '        Session(Session("TokenID") + "Emails") = dt1.Rows(i)("Emails")
    '        If Session(Session("TokenID") + "Emails") <> "" Then
    '            Session(Session("TokenID") + "Names") = dt1.Rows(i)("Name")
    '            Session(Session("TokenID") + "CompanyNames") = dt1.Rows(i)("Company")
    '            Session(Session("TokenID") + "Sr") = dt1.Rows(i)("Sr")
    '            Session(Session("TokenID") + "SenderEmail") = SenderEmailAddress.Text
    '            If SenderCompanyEmailAddress.Text = "" Then
    '                Session(Session("TokenID") + "SenderCompanyEmail") = SenderEmailAddress.Text
    '            Else
    '                Session(Session("TokenID") + "SenderCompanyEmail") = SenderCompanyEmailAddress.Text
    '            End If
    '            If dt1.Rows.Count > 0 Then
    '                Try
    '                    Using mm As New MailMessage(CType(Session(Session("TokenID") + "SenderCompanyEmail"), String), dt1.Rows(i)("Emails"))
    '                        mm.From = New Mail.MailAddress(Session(Session("TokenID") + "SenderCompanyEmail"), SenderName.Text)
    '                        If dt1.Rows(i).Item("Name") Is DBNull.Value Then
    '                        Else
    '                            Dim SubjectText = LetterSubject.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
    '                            Dim newText = LetterBody.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                        End If
    '                        If dt1.Rows(i).Item("Company") Is DBNull.Value Then
    '                        Else
    '                            Dim SubjectText = LetterSubject.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            Dim newText = LetterBody.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                        End If
    '                        mm.Subject = LetterSubject.Text
    '                        Dim body As String
    '                        body = LetterBody.Text
    '                        body += "<img src='https://www.eboxmarketing.com/UserRegistration.aspx?EmailAddress=" + Session(Session("TokenID") + "Emails") + "&UserID=" + Session(Session("TokenID") + "UserID").ToString + "&Sr=" + Session(Session("TokenID") + "Sr").ToString + "&ReadStatus=Opened&EmailType=Followed-Up'" + " width=0 height=0>"
    '                        If (myDir.EnumerateFiles().Any()) Then
    '                            Try
    '                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "folderPath"), "*", IO.SearchOption.AllDirectories)
    '                                    mm.Attachments.Add(New Mail.Attachment(s))
    '                                Next
    '                            Catch ex As Exception
    '                                'MsgBox(ex.Message)
    '                            End Try
    '                        End If
    '                        'If image_FileUpload.HasFile Then
    '                        '    For Each file As HttpPostedFile In image_FileUpload.PostedFiles
    '                        '        Dim fileName As String = Path.GetFileName(file.FileName)
    '                        '        file.SaveAs(Server.MapPath("~/Attachments/") & fileName)
    '                        '        mm.Attachments.Add(New Attachment(file.InputStream, fileName))
    '                        '    Next
    '                        'End If
    '                        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '                            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(body + "<br/><img src=cid:signaturefile height=150>", Nothing, "text/html")
    '                            Dim logo As LinkedResource = New LinkedResource(Session(Session("TokenID") + "LetterBodyAttachmentPath").ToString)
    '                            logo.ContentId = "signaturefile"
    '                            htmlView.LinkedResources.Add(logo)
    '                            mm.AlternateViews.Add(htmlView)
    '                        Else
    '                            mm.Body = body
    '                        End If
    '                        mm.IsBodyHtml = True

    '                        If CCBCCText.Text = "CC Email" And CCBCCBothText.Text = "" Then
    '                            mm.CC.Add(CCBCCTextbox.Text)
    '                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "" Then
    '                            mm.Bcc.Add(CCBCCTextbox.Text)
    '                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "CC Email" Then
    '                            mm.Bcc.Add(CCBCCTextbox.Text)
    '                            mm.CC.Add(CCBCCTextboxBoth.Text)
    '                        Else

    '                        End If
    '                        Dim smtp As New Mail.SmtpClient()
    '                        smtp.Host = "smtp.gmail.com"
    '                        smtp.EnableSsl = True
    '                        smtp.Port = 587
    '                        smtp.UseDefaultCredentials = False
    '                        Dim NetworkCred As New NetworkCredential(SenderEmailAddress.Text, SenderPassword.Text)
    '                        smtp.Credentials = NetworkCred

    '                        smtp.Send(mm)
    '                    End Using
    '                    updateMailSheduleFollowUp()
    '                    t = t + 1
    '                    'LoaderText.Text = dt12.Rows.Count.ToString() + " Out Of " + t.ToString() + " Emails Have Been Sent."
    '                Catch ex As Exception
    '                    If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '                        LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
    '                        LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '                    Else
    '                        LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
    '                        LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '                    End If
    '                    Session(Session("TokenID") + "LetterBodyTextPrevious") = Session(Session("TokenID") + "LetterBodyText")
    '                    'MsgBox(ex.Message)
    '                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', 'Please make sure that you have allowed less secure devices through above link & your email address & password are correct.');", True)
    '                End Try
    '            Else
    '                NotificationText.Text = "Alert: " + "Please Import Emails First To Send An Email."
    '            End If
    '        Else
    '            NotificationText.Text = "Alert: " + "Please make sure the Email Addresses are imported and in correct format."
    '        End If
    '        i = i + 1
    '    End While
    '    If Session(Session("TokenID") + "Emails") <> "" And t <> 0 Then
    '        'Session(Session("TokenID") + "TotalFollow-up") = SendableFollowups
    '        'RemainingFollowUpEmailsFunc(SendableFollowups)
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Success!', '" & t & "' + ' Follow-up(s) have been sent.');", True)
    '        dst.Clear()
    '        DeleteAttachments()
    '    Else
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Failed!', 'Please make sure that the sent emails are in the correct formats and your email address & password are correct.');", True)
    '    End If
    'End Sub
    Private Sub FollowupMailWithXOAUTH2(ByVal userEmail As String, ByVal accessToken As String)

        ' Gmail SMTP server address
        Dim oServer As SmtpServer = New SmtpServer("smtp.gmail.com")
        Dim i = 0
        Dim t = 0
        Dim dst2 As New DataSet
        Dim dt12 As New DataTable
        Dim SendableFollowups As Integer
        Session(Session("TokenID") + "LetterBodyText") = LetterBody.Text
        Session(Session("TokenID") + "LetterSubjectText") = LetterSubject.Text
        Dim myDir As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "folderPath"))
        Dim myDir2 As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "LetterBodyAttachmentFolderPath"))
        dt12 = Session(Session("TokenID") + "TokenID")
        radGrid1.DataSource = dst2.Tables("CallCenter_LetterBody1")
        While i < dt12.Rows.Count
            If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
                LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
            Else
                LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
                LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
            End If
            Session(Session("TokenID") + "Emails") = dt12.Rows(i)("Emails").ToString()
            If Session(Session("TokenID") + "Emails") <> "" Then
                Session(Session("TokenID") + "Names") = dt12.Rows(i)("Name")
                Session(Session("TokenID") + "CompanyNames") = dt12.Rows(i)("Company")
                Session(Session("TokenID") + "Sr") = dt12.Rows(i)("Sr")
                Session(Session("TokenID") + "SenderEmail") = userEmail
                ' set user authentication
                oServer.User = userEmail
                'oMail.From = Session(Session("TokenID") + "SenderEmail").ToString()
                If SenderCompanyEmailAddress.Text = "" Then
                    Session(Session("TokenID") + "SenderCompanyEmail") = userEmail
                Else
                    Session(Session("TokenID") + "SenderCompanyEmail") = SenderCompanyEmailAddress.Text
                End If
                If dt12.Rows.Count > 0 Then
                    Try
                        ' enable SSL connection
                        oServer.ConnectType = SmtpConnectType.ConnectSSLAuto
                        ' Using 587 port, you can also use 465 port
                        oServer.Port = 587

                        ' use SMTP OAUTH 2.0 authentication
                        oServer.AuthType = SmtpAuthType.XOAUTH2
                        ' set user authentication
                        Session(Session("TokenID") + "accessToken") = accessToken
                        ' use access token as password
                        oServer.Password = Session(Session("TokenID") + "accessToken").ToString()

                        Dim oMail As SmtpMail = New SmtpMail("TryIt")
                        oMail.From = New EASendMail.MailAddress(SenderName.Text, Session(Session("TokenID") + "SenderCompanyEmail").ToString())
                        oMail.[To] = Session(Session("TokenID") + "Emails").ToString()
                        If dt12.Rows(i).Item("Name") Is DBNull.Value Then
                        Else
                            Dim SubjectText = LetterSubject.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
                            Dim newText = LetterBody.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            SubjectText = LetterSubject.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
                            newText = LetterBody.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                        End If
                        If dt12.Rows(i).Item("Company") Is DBNull.Value Then
                        Else
                            Dim SubjectText = LetterSubject.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            Dim newText = LetterBody.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                            newText = LetterBody.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            SubjectText = LetterSubject.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
                            LetterBody.Text = newText
                            LetterSubject.Text = SubjectText
                        End If
                        oMail.Subject = LetterSubject.Text
                        Dim body As String
                        body = LetterBody.Text
                        body += "<img src='https://www.eboxmarketing.com/UserRegistration.aspx?EmailAddress=" + Session(Session("TokenID") + "Emails") + "&UserID=" + Session(Session("TokenID") + "UserID").ToString + "&Sr=" + Session(Session("TokenID") + "Sr").ToString + "&ReadStatus=Opened&EmailType=Followed-Up'" + " width=0 height=0>"
                        If (myDir.EnumerateFiles().Any()) Then
                            Try
                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "folderPath"), "*", IO.SearchOption.AllDirectories)
                                    oMail.AddAttachment(s)
                                Next
                            Catch ex As Exception
                                'MsgBox(ex.Message)
                            End Try
                        End If
                        If (myDir2.EnumerateFiles().Any()) Then
                            Try
                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "LetterBodyAttachmentFolderPath"), "*", IO.SearchOption.AllDirectories)
                                    If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                                        body += "<br/><img src='https://www.eboxmarketing.com/InnerAttachments/" + Session(Session("TokenID") + "AttachedImagePath").ToString + "' height=150>"
                                    Else
                                        oMail.HtmlBody = body
                                    End If
                                Next
                            Catch ex As Exception
                                'MsgBox(ex.Message)
                            End Try
                        End If
                        oMail.HtmlBody = body

                        If CCBCCText.Text = "CC Email" And CCBCCBothText.Text = "" Then
                            oMail.Cc.Add(CCBCCTextbox.Text)
                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "" Then
                            oMail.Bcc.Add(CCBCCTextbox.Text)
                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "CC Email" Then
                            oMail.Bcc.Add(CCBCCTextbox.Text)
                            oMail.Cc.Add(CCBCCTextboxBoth.Text)
                        Else

                        End If

                        Dim oSmtp As SmtpClient = New SmtpClient()
                        oSmtp.SendMail(oServer, oMail)

                        updateMailSheduleFollowUp()
                        t = t + 1
                    Catch ex As Exception
                        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
                            LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
                            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
                        Else
                            LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
                            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
                        End If
                        Session(Session("TokenID") + "LetterBodyTextPrevious") = Session(Session("TokenID") + "LetterBodyText")
                        'MsgBox(ex.Message)
                        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', 'Please make sure that you have allowed less secure devices through above link & your email address & password are correct.');", True)
                    End Try
                Else
                    NotificationText.Text = "Alert: " + "Please Import Emails First To Send An Email."
                End If
            Else
                NotificationText.Text = "Alert: " + "Please make sure the Email Addresses are imported and in correct format."
            End If
            i = i + 1
        End While
        If Session(Session("TokenID") + "Emails") <> "" And t <> 0 Then
            'Session(Session("TokenID") + "TotalFollow-up") = SendableFollowups
            'RemainingFollowUpEmailsFunc(SendableFollowups)
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Success!', '" & t & "' + ' Follow-up(s) have been sent.');", True)
            dst2.Clear()
            DeleteAttachments()
        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Failed!', 'Please make sure that the sent emails are in the correct formats and your email address & password are correct.');", True)
        End If
    End Sub

    ' client configuration
    Shared ReadOnly clientID As String = System.Configuration.ConfigurationManager.AppSettings("GoogleClientId")
    Shared ReadOnly clientSecret As String = System.Configuration.ConfigurationManager.AppSettings("GoogleClientSecret")
    Const scope As String = "openid%20profile%20email%20https://mail.google.com"
    Const authUri As String = "https://accounts.google.com/o/oauth2/v2/auth"
    Const tokenUri As String = "https://www.googleapis.com/oauth2/v4/token"


    Public Async Sub DoOauthAndSendEmail()
        ' Creates a redirect URI using an available port on the loopback address.
        Dim redirectUri As String = String.Format("https://localhost:44307/EmailMarketingTool/")
        'Console.WriteLine("redirect URI: " & redirectUri)

        ' Creates an HttpListener to listen for requests on that redirect URI.
        Dim http = New HttpListener()
        http.Prefixes.Add(redirectUri)
        'Console.WriteLine("Listening ...")
        http.Start()
        ' Creates the OAuth 2.0 authorization request.
        Dim authorizationRequest = String.Format("{0}?response_type=code&scope={1}&redirect_uri={2}&client_id={3}",
                                            authUri,
                                            scope,
                                            Uri.EscapeDataString(redirectUri),
                                            clientID)

        ' Opens request in the browser
        System.Diagnostics.Process.Start(authorizationRequest)

        ' Waits for the OAuth authorization response.
        Dim context = Await http.GetContextAsync()

        ' Checks for errors.
        If context.Request.QueryString.[Get]("error") IsNot Nothing Then
            Console.WriteLine(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.[Get]("error")))
            Return
        End If

        If context.Request.QueryString.[Get]("code") Is Nothing Then
            Console.WriteLine("Malformed authorization response. " & context.Request.RawUrl)
            Return
        End If

        ' extracts the authorization code
        Dim code = context.Request.QueryString.[Get]("code")
        Console.WriteLine("Authorization code: " & code)

        Dim responseText As String = Await RequestAccessToken(code, redirectUri)
        Console.WriteLine(responseText)

        Dim parser As OAuthResponseParser = New OAuthResponseParser()
        parser.Load(responseText)

        Dim user = parser.EmailInIdToken
        Dim accessToken = parser.AccessToken

        ' Sends an HTTP response to the browser.
        Dim response = context.Response
        Dim responseString As String = String.Format("<script language='javascript'>window.close();</script>")
        Dim buffer = Encoding.UTF8.GetBytes(responseString)
        response.ContentLength64 = buffer.Length
        Dim responseOutput = response.OutputStream
        Dim responseTask As Task = responseOutput.
                WriteAsync(buffer, 0, buffer.Length).
                ContinueWith(Sub(task)
                                 responseOutput.Close()
                                 http.[Stop]()
                                 Console.WriteLine("HTTP server stopped.")
                             End Sub)
        SendMailWithXOAUTH2(user, accessToken)
    End Sub

    Public Async Sub DoOauthAndSendFollowupEmail()
        ' Creates a redirect URI using an available port on the loopback address.
        Dim redirectUri As String = String.Format("http://localhost:65489/EmailMarketingTool")
        'Console.WriteLine("redirect URI: " & redirectUri)

        ' Creates an HttpListener to listen for requests on that redirect URI.
        Dim http = New HttpListener()
        http.Prefixes.Add(redirectUri)
        'Console.WriteLine("Listening ...")
        http.Start()
        ' Creates the OAuth 2.0 authorization request.
        Dim authorizationRequest = String.Format("{0}?response_type=code&scope={1}&redirect_uri={2}&client_id={3}",
                                            authUri,
                                            scope,
                                            Uri.EscapeDataString(redirectUri),
                                            clientID)

        ' Opens request in the browser
        System.Diagnostics.Process.Start(authorizationRequest)

        ' Waits for the OAuth authorization response.
        Dim context = Await http.GetContextAsync()

        ' Checks for errors.
        If context.Request.QueryString.[Get]("error") IsNot Nothing Then
            Console.WriteLine(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.[Get]("error")))
            Return
        End If

        If context.Request.QueryString.[Get]("code") Is Nothing Then
            Console.WriteLine("Malformed authorization response. " & context.Request.RawUrl)
            Return
        End If

        ' extracts the authorization code
        Dim code = context.Request.QueryString.[Get]("code")
        Console.WriteLine("Authorization code: " & code)

        Dim responseText As String = Await RequestAccessToken(code, redirectUri)
        Console.WriteLine(responseText)

        Dim parser As OAuthResponseParser = New OAuthResponseParser()
        parser.Load(responseText)

        Dim user = parser.EmailInIdToken
        Dim accessToken = parser.AccessToken

        ' Sends an HTTP response to the browser.
        Dim response = context.Response
        Dim responseString As String = String.Format("<script language='javascript'>window.close();</script>")
        Dim buffer = Encoding.UTF8.GetBytes(responseString)
        response.ContentLength64 = buffer.Length
        Dim responseOutput = response.OutputStream
        Dim responseTask As Task = responseOutput.
                WriteAsync(buffer, 0, buffer.Length).
                ContinueWith(Sub(task)
                                 responseOutput.Close()
                                 http.[Stop]()
                                 Console.WriteLine("HTTP server stopped.")
                             End Sub)
        FollowupMailWithXOAUTH2(user, accessToken)
    End Sub

    Private Async Function RequestAccessToken(ByVal code As String, ByVal redirectUri As String) As Task(Of String)
        'Console.WriteLine("Exchanging code for tokens...")

        ' builds the  request
        Dim tokenRequestBody = String.Format("code={0}&redirect_uri={1}&client_id={2}&client_secret={3}&grant_type=authorization_code",
                                            code,
                                            Uri.EscapeDataString(redirectUri),
                                            clientID,
                                            clientSecret)

        ' sends the request
        Dim tokenRequest As HttpWebRequest = CType(WebRequest.Create(tokenUri), HttpWebRequest)
        tokenRequest.Method = "POST"
        tokenRequest.ContentType = "application/x-www-form-urlencoded"
        tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"

        Dim _byteVersion As Byte() = Encoding.ASCII.GetBytes(tokenRequestBody)
        tokenRequest.ContentLength = _byteVersion.Length
        Dim stream As Stream = tokenRequest.GetRequestStream()
        Await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length)
        stream.Close()

        Try
            ' gets the response
            Dim tokenResponse As WebResponse = Await tokenRequest.GetResponseAsync()

            Using reader As StreamReader = New StreamReader(tokenResponse.GetResponseStream())
                ' reads response body
                Return Await reader.ReadToEndAsync()
            End Using

        Catch ex As WebException

            If ex.Status = WebExceptionStatus.ProtocolError Then
                Dim response = TryCast(ex.Response, HttpWebResponse)

                If response IsNot Nothing Then
                    Console.WriteLine("HTTP: " & response.StatusCode)

                    ' reads response body
                    Using reader As StreamReader = New StreamReader(response.GetResponseStream())
                        Dim responseText As String = reader.ReadToEnd()
                        Console.WriteLine(responseText)
                    End Using
                End If
            End If

            Throw ex
        End Try
    End Function

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        If Not IsPostBack Then
            'Dim RemainingDays As Integer
            'If Session(Session("TokenID") + "UserID") <> "" And Session(Session("TokenID") + "PackageStatus") <> "Expired" Then
            If Session(Session("TokenID") + "UserID") <> "" Then
                'Dim diff2 As String = (Convert.ToDateTime(Session(Session("TokenID") + "SubscriptionExpiryDate")) - Date.Today).TotalDays.ToString()
                'RemainingDays = diff2
                'If RemainingDays < 3 And RemainingDays > 0 Then
                '    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Subscription Notification!', 'Your " + Session(Session("TokenID") + "PackageType") + " account is expiring in " + RemainingDays.ToString() + " Day(s). Please choose or renew your package according to your needs after the expiry.');", True)
                'ElseIf RemainingDays <= 0 And Session(Session("TokenID") + "PackageStatus") <> "Expired" Then
                '    'UpdateSubscriptionStatus()
                '    Session(Session("TokenID") + "PackageStatus") = "Expired"
                'Else
                'End If
                bodyDisabled.Visible = True
                ImportEmailsUploader.Attributes("onchange") = "ImportEmails(this)"
                image_FileUpload.Attributes("onchange") = "UploadFile(this)"
                AttachEmailSignature.Attributes("onchange") = "UploadFile2(this)"

                CCBCCText.Text = ""
                CCBCCTextDiv.Visible = "false"
                CCBCCTextDivBoth.Visible = "false"
                CCBCCBothText.Text = ""
                Session(Session("TokenID") + "path") = ""
                Session(Session("TokenID") + "LetterBodyAttachmentPath") = ""
                Session(Session("TokenID") + "LetterBodyTextPrevious") = ""
                Session(Session("TokenID") + "AttachedImagePath") = ""
                Session(Session("TokenID") + "Names") = ""
                Session(Session("TokenID") + "Emails") = ""
                Session(Session("TokenID") + "CompanyNames") = ""
                Session(Session("TokenID") + "LetterBodyText") = ""
                Session(Session("TokenID") + "IndexNo") = ""
                Session(Session("TokenID") + "PreviousEmail") = ""
                Session(Session("TokenID") + "Sr") = ""
                Session(Session("TokenID") + "EmailValidation") = ""
                Session(Session("TokenID") + "TokenID") = ""
                Session(Session("TokenID") + "TokenID3") = ""
                Session(Session("TokenID") + "MailType") = ""
                Session(Session("TokenID") + "accessToken") = ""
                GridSearchForBulk()
                GridSearchForFollowups()
                GridSearchForUnsentMails()
                SearchSelectedUnsentEmails()
                EmailsDates()
                EmailsDatesFollowUp()
                'EmailCounterSearch()
                'SendableEmailCounterSearch()
                Search_SavedTemplates()
                Search_DefaultTemplates()
                SearchSelectedSentEmails()
                SearchSelectedFollowedEmails()

                Session(Session("TokenID") + "folderPath") = Server.MapPath("~/Attachments/")
                Session(Session("TokenID") + "folderPath2") = Server.MapPath("~/ImportedEmails/")
                Session(Session("TokenID") + "LetterBodyAttachmentFolderPath") = Server.MapPath("~/InnerAttachments/")
                If Session(Session("TokenID") + "folderPath") <> "" Then
                    Try
                        Dim directoryName As String = Session(Session("TokenID") + "folderPath")
                        For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                            File.Delete(filename)
                        Next
                    Catch ex As Exception
                    End Try
                Else

                End If
                If Session(Session("TokenID") + "folderPath2") <> "" Then
                    Try
                        Dim directoryName As String = Session(Session("TokenID") + "folderPath2")
                        For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                            File.Delete(filename)
                        Next
                    Catch ex As Exception
                    End Try
                Else
                End If
                If Session(Session("TokenID") + "LetterBodyAttachmentFolderPath") <> "" Then
                    Try
                        Dim directoryName As String = Session(Session("TokenID") + "LetterBodyAttachmentFolderPath")
                        For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                            File.Delete(filename)
                        Next

                    Catch ex As Exception
                    End Try
                Else
                End If
            ElseIf Session(Session("TokenID") + "UserID") = "" Then
                'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Login not found!', 'Please login/signup to continue.');", True)
                bodyDisabled.Visible = False
                SignInNotification.Text = "You need to <a href='/UserLogin.aspx'>Login</a> first to see the content of this page."
                'ElseIf Session(Session("TokenID") + "PackageStatus") = "Expired" And Session(Session("TokenID") + "UserID") <> "" Then
                '    bodyDisabled.Visible = False
                '    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "SubExpiry('Subscription Expired!', 'Your " + Session(Session("TokenID") + "PackageType") + " account has expired, please choose a package to continue.');", True)
            Else

            End If
            'If Session(Session("TokenID") + "PackageType") <> "Trial" And Session(Session("TokenID") + "UserID") <> "" Then
            '    FollowUp_button.Visible = True
            '    SendFollowUpstext.Visible = False
            '    NotForTrialText.Visible = True
            '    RemainingEmailsPreText.Text = "Remaining Emails For A Month: "
            'Else
            '    FollowUp_button.Visible = False
            '    NotForTrialText.Visible = False
            '    SendFollowUpstext.Visible = True
            '    RemainingFollowUpEmailsPreText.Visible = False
            '    RemainingFollowUpEmailsText.Visible = False
            '    RemainingEmailsPreText.Text = "Remaining Emails For Your Trial: "
            'End If
        End If
    End Sub

    'Protected Sub EmailCounterSearch()
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "EmailCounter_Search"

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@TodaysDate"
    '        p.Value = Date.Today.AddDays(-99)
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@AvailableEmails"
    '        If Session(Session("TokenID") + "PackageType") = "Trial" Then
    '            p.Value = 100
    '        ElseIf Session(Session("TokenID") + "PackageType") = "Business" Then
    '            p.Value = 500
    '        ElseIf Session(Session("TokenID") + "PackageType") = "Premium" Then
    '            p.Value = 100000
    '        End If
    '        cmd.Parameters.Add(p)

    '        Dim DS As New DataSet
    '        Dim da As New SqlDataAdapter
    '        da.SelectCommand = cmd
    '        da.Fill(DS, "AvailableEmailsCounter")
    '        If Session(Session("TokenID") + "PackageType") = "Premium" Then
    '            AvailableEmailsText.Text = "Unlimited"
    '        Else
    '            AvailableEmailsText.Text = DS.Tables("AvailableEmailsCounter").Rows(0)("AvailableEmails").ToString()
    '        End If
    '        If AvailableEmailsText.Text = "0" Then
    '            ImportEmailsUploader.Visible = False
    '            LimitReachedText.Visible = True
    '            AvailableEmailsStart.Visible = False
    '            AvailableEmailsText.Visible = False
    '        Else
    '            ImportEmailsUploader.Visible = True
    '            LimitReachedText.Visible = False
    '            AvailableEmailsText.Visible = True
    '            AvailableEmailsStart.Visible = True
    '        End If
    '        con.Close()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub SendableEmailCounterSearch()
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "SendableEmailCounter_Search"

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@TodaysDate"
    '        p.Value = Date.Today.AddDays(-99)
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@RemainingSendableEmails"
    '        If Session(Session("TokenID") + "PackageType") = "Trial" Then
    '            p.Value = 600
    '        ElseIf Session(Session("TokenID") + "PackageType") = "Business" Then
    '            p.Value = 15000
    '        ElseIf Session(Session("TokenID") + "PackageType") = "Premium" Then
    '            p.Value = 100000
    '        End If
    '        cmd.Parameters.Add(p)

    '        Dim DS As New DataSet
    '        Dim da As New SqlDataAdapter
    '        da.SelectCommand = cmd
    '        da.Fill(DS, "RemainingSendableEmails")
    '        If Session(Session("TokenID") + "PackageType") = "Premium" Then
    '            RemainingEmailsText.Text = "Unlimited"
    '            RemainingFollowUpEmailsText.Text = "Unlimited"
    '        Else
    '            RemainingEmailsText.Text = DS.Tables("RemainingSendableEmails").Rows(0)("RemainingSendableEmails").ToString()
    '            RemainingFollowUpEmailsText.Text = DS.Tables("RemainingSendableEmails").Rows(0)("RemainingFollowUpEmails").ToString()
    '        End If
    '        If RemainingEmailsText.Text = "0" Then
    '            Sava_button.Visible = False
    '            RemainingEmailsPreText.Visible = False
    '            RemainingEmailsText.Visible = False
    '        Else
    '            Sava_button.Visible = True
    '            RemainingEmailsPreText.Visible = True
    '            RemainingEmailsText.Visible = True
    '        End If
    '        If RemainingFollowUpEmailsText.Text = "0" Then
    '            FollowUp_button.Visible = False
    '            RemainingFollowUpEmailsPreText.Visible = False
    '            RemainingFollowUpEmailsText.Visible = False
    '        Else
    '            FollowUp_button.Visible = True
    '            RemainingFollowUpEmailsPreText.Visible = True
    '            RemainingFollowUpEmailsText.Visible = True
    '        End If
    '        con.Close()
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try
    'End Sub

    Protected Sub image_FileUpload_DataBinding(sender As Object, e As EventArgs)

    End Sub

    'Protected Sub Button1_Click(sender As Object, e As EventArgs)

    '    Dim folderPath As String = Server.MapPath("~/Attachments/")

    '    Dim extension As String = Path.GetExtension(image_FileUpload.PostedFile.FileName)
    '    'Check whether Directory (Folder) exists.
    '    If Not Directory.Exists(folderPath) Then
    '        'If Directory (Folder) does not exists Create it.
    '        Directory.CreateDirectory(folderPath)
    '    End If

    '    'Save the File to the Directory (Folder).
    '    image_FileUpload.SaveAs(folderPath & Path.GetFileName(image_FileUpload.FileName))
    '    Session(Session("TokenID") + "path") = folderPath & Path.GetFileName(image_FileUpload.FileName)
    '    Session(Session("TokenID") + "folderPath") = folderPath

    '    'Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/Attachments/"))
    '    'Dim files As List(Of ListItem) = New List(Of ListItem)
    '    'For Each filePath As String In filePaths
    '    '    files.Add(New ListItem(Path.GetFileName(filePath), filePath))
    '    'Next
    '    'GridView1.DataSource = files
    '    'GridView1.DataBind()

    'End Sub
    'Private Sub UpdateSubscriptionStatus()
    '    Try
    '        If Session(Session("TokenID") + "PackageStatus") <> "Expired" Then
    '            If con.State = False Then
    '                con.Open()
    '            End If
    '            cmd.Parameters.Clear()
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.CommandText = "SubscriptionStatus_Update"

    '            Dim p1 As New SqlParameter
    '            p1.ParameterName = "@UserID"
    '            p1.Value = Session(Session("TokenID") + "UserID")
    '            cmd.Parameters.Add(p1)

    '            Dim p2 As New SqlParameter
    '            p2.ParameterName = "@PackageType"
    '            p2.Value = Session(Session("TokenID") + "PackageType")
    '            cmd.Parameters.Add(p2)

    '            cmd.ExecuteNonQuery()
    '            con.Close()

    '            Dim c5 As HttpCookie = New HttpCookie("PkS")
    '            c5.Values.Add("PkS", "Expired")
    '            c5.Expires = DateTime.Now.AddDays(15)
    '            Response.Cookies.Add(c5)
    '        End If
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try

    'End Sub
    Private Sub EmailsDates()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("Select FORMAT (DateSent, 'ddd, MMM, yyyy') as DateSent From Client_Emails where Emails <> '' and  Status = 'Sent' and UserID = '" & Session(Session("TokenID") + "UserID") & "'", con)
            Dim dst3 As New DataSet
            Adp.Fill(dst3, "CallCenter_LetterBody12")
            If dst3.Tables("CallCenter_LetterBody12").Rows.Count = 0 Then
                LastMailSentDate.Text = "No Sent Emails"
            Else
                LastMailSentDate.Text = dst3.Tables("CallCenter_LetterBody12").Rows(0)("DateSent")
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub EmailsDatesFollowUp()

        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("Select FORMAT (DateSent, 'ddd, MMM, yyyy') as DateSent From Client_Emails where Emails <> '' and  Status = 'Followed-Up' and  UserID = '" & Session(Session("TokenID") + "UserID") & "'", con)
            Dim dst32 As New DataSet
            Adp.Fill(dst32, "CallCenter_LetterBody123")
            If dst32.Tables("CallCenter_LetterBody123").Rows.Count = 0 Then
                LastFollowupMailSentDate.Text = "No Followed-up Emails"
            Else
                LastFollowupMailSentDate.Text = dst32.Tables("CallCenter_LetterBody123").Rows(0)("DateSent").ToString()
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GridSearchForUnsentMails()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("Select Name, Emails, Company, FORMAT (DateSent, 'ddd, MMM, yyyy') as DateSent, Sr From Client_Emails where Emails <> '' and Status='Unsent' and  UserID = '" & Session(Session("TokenID") + "UserID") & "'", con)
            Dim dst3 As New DataSet
            Dim dt3 As New DataTable
            Session(Session("TokenID") + "dt3") = dt3
            Adp.Fill(dst3, "CallCenter_LetterBody3")
            dt3 = dst3.Tables("CallCenter_LetterBody3")
            radGrid3.DataSource = dst3.Tables("CallCenter_LetterBody3")
            radGrid3.DataBind()
            'Session(Session("TokenID") + "TokenID3") = dt3
            UnsentMailsQty.Text = dst3.Tables("CallCenter_LetterBody3").Rows.Count
            If dt3.Rows.Count > 0 Then
                AddEmailButton.Visible = True
                AddEmailRowBtn.Visible = False
                CancelAddBtn.Visible = False
                UpdateRecordUnsent.Visible = False
                DeleteAllUnsentMailsBtn.Visible = True
                ExportUnsentEmailsBtn.Visible = True
                SelectAllBtn.Visible = True
                UnSelectAllBtn.Visible = True
                Session(Session("TokenID") + "AddCommand") = "false"
            Else
                AddEmailButton.Visible = True
                AddEmailButton.Visible = True
                AddEmailRowBtn.Visible = False
                CancelAddBtn.Visible = False
                UpdateRecordUnsent.Visible = False
                DeleteAllUnsentMailsBtn.Visible = False
                ExportUnsentEmailsBtn.Visible = False
                SelectAllBtn.Visible = False
                UnSelectAllBtn.Visible = False
                Session(Session("TokenID") + "AddCommand") = "false"
            End If
            con.Close()
            SearchSelectedUnsentEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridSearchForFollowups()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("Select Name, Emails, Company, FORMAT (DateSent, 'ddd, MMM, yyyy') as DateSent, Sr, ReadStatus From Client_Emails where Emails <> '' and Status = 'Followed-Up' and  UserID = '" & Session(Session("TokenID") + "UserID") & "'", con)
            Dim dst2 As New DataSet
            Dim dt12 As New DataTable
            Adp.Fill(dst2, "CallCenter_LetterBody1")
            dt12 = dst2.Tables("CallCenter_LetterBody1")
            radGrid1.DataSource = dst2.Tables("CallCenter_LetterBody1")
            radGrid1.DataBind()
            'Session(Session("TokenID") + "TokenID1") = dt12
            FollowedUpMailsQty.Text = dst2.Tables("CallCenter_LetterBody1").Rows.Count
            If dt12.Rows.Count > 0 Then
                DeleteAllFollowedupMailsBtn.Visible = True
                ExportFollowedEmailsBtn.Visible = True
                CancelButtonFollowed.Visible = False
                UpdateRecordFollowed.Visible = False
                UnselectFollowedEmailsBtn.Visible = True
                SelectFollowedEmailsBtn.Visible = True
                For i As Integer = 0 To Me.radGrid1.Rows.Count - 1
                    'If Session(Session("TokenID") + "PackageType") <> "Trial" And Session(Session("TokenID") + "UserID") <> "" Then
                    '    If dt12.Rows(i)("ReadStatus") = "Unopened" Then
                    '        CType(radGrid1.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    '    Else
                    '        CType(radGrid1.Rows(i).FindControl("Status"), Label).ForeColor = Color.Green
                    '    End If
                    'Else
                    '    CType(radGrid1.Rows(i).FindControl("Status"), Label).Text = "Unavailable"
                    '    CType(radGrid1.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    'End If
                    If dt12.Rows(i)("ReadStatus") = "Unopened" Then
                        CType(radGrid1.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    Else
                        CType(radGrid1.Rows(i).FindControl("Status"), Label).ForeColor = Color.Green
                    End If
                Next
            Else
                DeleteAllFollowedupMailsBtn.Visible = False
                ExportFollowedEmailsBtn.Visible = False
                CancelButtonFollowed.Visible = False
                UpdateRecordFollowed.Visible = False
                UnselectFollowedEmailsBtn.Visible = False
                SelectFollowedEmailsBtn.Visible = False
            End If
            con.Close()
            SearchSelectedFollowedEmails()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GridSearchForBulk()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("Select Name, Emails, Company, FORMAT (DateSent, 'ddd, MMM, yyyy') as DateSent, Sr, ReadStatus From Client_Emails where Emails <> '' and Status = 'Sent' and  UserID = '" & Session(Session("TokenID") + "UserID") & "' ", con)
            Dim dst As New DataSet
            Dim dt1 As New DataTable
            Adp.Fill(dst, "CallCenter_LetterBody")
            dt1 = dst.Tables("CallCenter_LetterBody")
            radGrid2.DataSource = dst.Tables("CallCenter_LetterBody")
            radGrid2.DataBind()
            'Session(Session("TokenID") + "TokenID") = dt1
            SentMailsQty.Text = dst.Tables("CallCenter_LetterBody").Rows.Count
            If dt1.Rows.Count > 0 Then
                DeleteAllSentMailsBtn.Visible = True
                ExportSentEmailsBtn.Visible = True
                CancelButtonSent.Visible = False
                UpdateRecordSent.Visible = False
                SelectAllSentBtn.Visible = True
                UnSelectAllSentBtn.Visible = True

                For i As Integer = 0 To Me.radGrid2.Rows.Count - 1
                    'If Session(Session("TokenID") + "PackageType") <> "Trial" And Session(Session("TokenID") + "UserID") <> "" Then
                    '    If dt1.Rows(i)("ReadStatus") = "Unopened" Then
                    '        CType(radGrid2.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    '    Else
                    '        CType(radGrid2.Rows(i).FindControl("Status"), Label).ForeColor = Color.Green
                    '    End If
                    'Else
                    '    CType(radGrid2.Rows(i).FindControl("Status"), Label).Text = "Unavailable"
                    '    CType(radGrid2.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    'End If
                    If dt1.Rows(i)("ReadStatus") = "Unopened" Then
                        CType(radGrid2.Rows(i).FindControl("Status"), Label).ForeColor = Color.Crimson
                    Else
                        CType(radGrid2.Rows(i).FindControl("Status"), Label).ForeColor = Color.Green
                    End If
                Next
            Else
                DeleteAllSentMailsBtn.Visible = False
                ExportSentEmailsBtn.Visible = False
                CancelButtonSent.Visible = False
                UpdateRecordSent.Visible = False
                SelectAllSentBtn.Visible = False
                UnSelectAllSentBtn.Visible = False
            End If

            con.Close()
            SearchSelectedSentEmails()
        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub RemainingSendableEmailsFunc(RemainingSendableEmails As Integer)
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "RemainingSendableEmails_Update"

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@RemainingSendableEmails"
    '        p.Value = RemainingSendableEmails
    '        cmd.Parameters.Add(p)

    '        cmd.ExecuteNonQuery()
    '        con.Close()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub mail_send()
    '    Dim i = 0
    '    Dim t = 0
    '    Dim dst2 As New DataSet
    '    Dim dt12 As New DataTable
    '    Dim SendableEmails As Integer
    '    Session(Session("TokenID") + "LetterBodyText") = LetterBody.Text
    '    Session(Session("TokenID") + "LetterSubjectText") = LetterSubject.Text
    '    Dim myDir As DirectoryInfo = New DirectoryInfo(Session(Session("TokenID") + "folderPath"))
    '    dt12 = Session(Session("TokenID") + "TokenID3")
    '    radGrid1.DataSource = dst2.Tables("CallCenter_LetterBody1")
    '    'If Session(Session("TokenID") + "PackageType") <> "Premium" Then
    '    '    If dt12.Rows.Count > RemainingEmailsText.Text Then
    '    '        SendableEmails = RemainingEmailsText.Text
    '    '    Else
    '    '        SendableEmails = dt12.Rows.Count
    '    '    End If
    '    'Else
    '    '    SendableEmails = dt12.Rows.Count
    '    'End If
    '    'LoadingText.Text = "0"
    '    'LoadingText.ReadOnly = True

    '    While i < dt12.Rows.Count
    '        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '            LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
    '            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '        Else
    '            LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
    '            LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '        End If
    '        Session(Session("TokenID") + "Emails") = dt12.Rows(i)("Emails")
    '        If Session(Session("TokenID") + "Emails") <> "" Then
    '            Session(Session("TokenID") + "Names") = dt12.Rows(i)("Name")
    '            Session(Session("TokenID") + "CompanyNames") = dt12.Rows(i)("Company")
    '            Session(Session("TokenID") + "Sr") = dt12.Rows(i)("Sr")
    '            Session(Session("TokenID") + "SenderEmail") = SenderEmailAddress.Text
    '            If SenderCompanyEmailAddress.Text = "" Then
    '                Session(Session("TokenID") + "SenderCompanyEmail") = SenderEmailAddress.Text
    '            Else
    '                Session(Session("TokenID") + "SenderCompanyEmail") = SenderCompanyEmailAddress.Text
    '            End If
    '            If dt12.Rows.Count > 0 Then
    '                Try
    '                    Using mm As New MailMessage(CType(Session(Session("TokenID") + "SenderCompanyEmail"), String), dt12.Rows(i)("Emails"))
    '                        mm.From = New Mail.MailAddress(Session(Session("TokenID") + "SenderCompanyEmail"), SenderName.Text)
    '                        If dt12.Rows(i).Item("Name") Is DBNull.Value Then
    '                        Else
    '                            Dim SubjectText = LetterSubject.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
    '                            Dim newText = LetterBody.Text.Replace("@clientname", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@ClientName", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@Clientname", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            SubjectText = LetterSubject.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
    '                            newText = LetterBody.Text.Replace("@clientName", Session(Session("TokenID") + "Names"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                        End If
    '                        If dt12.Rows(i).Item("Company") Is DBNull.Value Then
    '                        Else
    '                            Dim SubjectText = LetterSubject.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            Dim newText = LetterBody.Text.Replace("@clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@ClientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@clientCompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                            newText = LetterBody.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            SubjectText = LetterSubject.Text.Replace("@Clientcompany", Session(Session("TokenID") + "CompanyNames"))
    '                            LetterBody.Text = newText
    '                            LetterSubject.Text = SubjectText
    '                        End If
    '                        mm.Subject = LetterSubject.Text
    '                        Dim body As String
    '                        body = LetterBody.Text
    '                        body += "<img src='https://www.eboxmarketing.com/UserRegistration.aspx?EmailAddress=" + Session(Session("TokenID") + "Emails") + "&UserID=" + Session(Session("TokenID") + "UserID").ToString + "&Sr=" + Session(Session("TokenID") + "Sr").ToString + "&ReadStatus=Opened&EmailType=Sent'" + " width=0 height=0>"
    '                        If (myDir.EnumerateFiles().Any()) Then
    '                            Try
    '                                For Each s As String In IO.Directory.GetFiles(Session(Session("TokenID") + "folderPath"), "*", IO.SearchOption.AllDirectories)
    '                                    mm.Attachments.Add(New Mail.Attachment(s))
    '                                Next
    '                            Catch ex As Exception
    '                                'MsgBox(ex.Message)
    '                            End Try
    '                        End If
    '                        'If image_FileUpload.HasFile Then
    '                        '    For Each file As HttpPostedFile In image_FileUpload.PostedFiles
    '                        '        Dim fileName As String = Path.GetFileName(file.FileName)
    '                        '        file.SaveAs(Server.MapPath("~/Attachments/") & fileName)
    '                        '        mm.Attachments.Add(New Attachment(file.InputStream, fileName))
    '                        '    Next
    '                        'End If
    '                        If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '                            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(body + "<br/><img src=cid:signaturefile height=150>", Nothing, "text/html")
    '                            Dim logo As LinkedResource = New LinkedResource(Session(Session("TokenID") + "LetterBodyAttachmentPath").ToString)
    '                            logo.ContentId = "signaturefile"
    '                            htmlView.LinkedResources.Add(logo)
    '                            mm.AlternateViews.Add(htmlView)
    '                        Else
    '                            mm.Body = body
    '                        End If
    '                        mm.IsBodyHtml = True

    '                        If CCBCCText.Text = "CC Email" And CCBCCBothText.Text = "" Then
    '                            mm.CC.Add(CCBCCTextbox.Text)
    '                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "" Then
    '                            mm.Bcc.Add(CCBCCTextbox.Text)
    '                        ElseIf CCBCCText.Text = "BCC Email" And CCBCCBothText.Text = "CC Email" Then
    '                            mm.Bcc.Add(CCBCCTextbox.Text)
    '                            mm.CC.Add(CCBCCTextboxBoth.Text)
    '                        Else

    '                        End If
    '                        'mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
    '                        Dim smtp As New Mail.SmtpClient()
    '                        smtp.Host = "smtp.gmail.com"
    '                        smtp.EnableSsl = True
    '                        smtp.Port = 587
    '                        smtp.UseDefaultCredentials = False
    '                        Dim NetworkCred As New NetworkCredential(SenderEmailAddress.Text, SenderPassword.Text)
    '                        smtp.Credentials = NetworkCred
    '                        'Dim userState As Object = mm
    '                        'AddHandler smtp.SendCompleted, New SendCompletedEventHandler(AddressOf SmtpClient_OnCompleted)
    '                        'smtp.SendAsync(mm, userState)
    '                        smtp.Send(mm)
    '                    End Using
    '                    updateMailShedule()
    '                    t = t + 1
    '                    'LoadingText.Text = t.ToString() + " Out Of " + dt12.Rows.Count.ToString() + " Emails Have Been Sent."
    '                Catch ex As Exception
    '                    If Session(Session("TokenID") + "AttachedImagePath") <> "" Then
    '                        LetterBody.Text = Session(Session("TokenID") + "LetterBodyTextPrevious")
    '                        LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '                    Else
    '                        LetterBody.Text = Session(Session("TokenID") + "LetterBodyText")
    '                        LetterSubject.Text = Session(Session("TokenID") + "LetterSubjectText")
    '                    End If
    '                    Session(Session("TokenID") + "LetterBodyTextPrevious") = Session(Session("TokenID") + "LetterBodyText")
    '                    'MsgBox(ex.Message)
    '                    'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', 'Please make sure that you have allowed less secure devices through above link & your email address & password are correct.');", True)
    '                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', '" + ex.Message + "');", True)
    '                End Try
    '            Else
    '                NotificationText.Text = "Alert: " + "Please Import Emails First To Send An Email."
    '            End If
    '        Else
    '            NotificationText.Text = "Alert: " + "Please make sure the Email Addresses are imported and in correct format."
    '        End If
    '        i = i + 1
    '    End While
    '    If Session(Session("TokenID") + "Emails") <> "" And t <> 0 Then
    '        'Session(Session("TokenID") + "TotalEmails") = SendableEmails
    '        'RemainingSendableEmailsFunc(SendableEmails)
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog('Success!', '" & t & "' + ' Email(s) have been sent.');", True)
    '        dst2.Clear()
    '        DeleteAttachments()
    '    Else
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Failed!', 'Please make sure that you have imported emails and your email address & password are correct.');", True)
    '    End If
    'End Sub

    'Public Shared Sub SmtpClient_OnCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
    '    Dim mail As MailMessage = CType(e.UserState, MailMessage)
    '    Dim subject As String = mail.Subject

    '    If e.Cancelled Then
    '        Console.WriteLine("Send canceled for mail with subject [{0}].", subject)
    '    End If

    '    If e.[Error] IsNot Nothing Then
    '        Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.[Error].ToString())
    '    Else
    '        Console.WriteLine("Message [{0}] sent.", subject)
    '    End If
    'End Sub
    Private Sub DeleteAttachments()
        If con.State = False Then
            con.Open()
        End If
        If Session(Session("TokenID") + "folderPath") <> "" Then
            Try
                Dim directoryName As String = Session(Session("TokenID") + "folderPath")
                For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(filename)
                Next
            Catch ex As Exception
            End Try
        Else

        End If
        If Session(Session("TokenID") + "folderPath2") <> "" Then
            Try
                Dim directoryName As String = Session(Session("TokenID") + "folderPath2")
                For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(filename)
                Next

            Catch ex As Exception
            End Try
        Else
        End If
        If Session(Session("TokenID") + "LetterBodyAttachmentFolderPath") <> "" Then
            Try
                Dim directoryName As String = Session(Session("TokenID") + "LetterBodyAttachmentFolderPath")
                For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(filename)
                Next

            Catch ex As Exception
            End Try
        Else
        End If
        Session(Session("TokenID") + "path") = ""
        Session(Session("TokenID") + "LetterBodyTextPrevious") = ""
        Session(Session("TokenID") + "LetterBodyAttachmentPath") = ""
        Session(Session("TokenID") + "AttachedImagePath") = ""
        Session(Session("TokenID") + "Names") = ""
        Session(Session("TokenID") + "Emails") = ""
        Session(Session("TokenID") + "CompanyNames") = ""
        Session(Session("TokenID") + "LetterBodyText") = ""
        Session(Session("TokenID") + "IndexNo") = ""
        Session(Session("TokenID") + "PreviousEmail") = ""
        Session(Session("TokenID") + "Sr") = ""
        Session(Session("TokenID") + "EmailValidation") = ""
        Session(Session("TokenID") + "GoogleCode") = ""
        Session(Session("TokenID") + "JsonCode") = ""
        CCBCCText.Text = ""
        AddEmailButton.Visible = True
        AddEmailRowBtn.Visible = False
        CancelAddBtn.Visible = False
        DeleteAllUnsentMailsBtn.Visible = True
        ExportUnsentEmailsBtn.Visible = True
        con.Close()
    End Sub

    Private Sub updateMailShedule()
        Try
            If con.State = False Then
                con.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "BulkEmails_Status_Update"
            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = Session(Session("TokenID") + "Emails")
            cmd.Parameters.Add(p)

            Dim p1 As New SqlParameter
            p1.ParameterName = "@UserID"
            p1.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@Sr"
            p2.Value = Session(Session("TokenID") + "Sr")
            cmd.Parameters.Add(p2)

            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub updateMailSheduleFollowUp()
        Try
            If con.State = False Then
                con.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "BulkEmails_Status_Followup_Update"
            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = Session(Session("TokenID") + "Emails")
            cmd.Parameters.Add(p)

            Dim p1 As New SqlParameter
            p1.ParameterName = "@UserID"
            p1.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@Sr"
            p2.Value = Session(Session("TokenID") + "Sr")
            cmd.Parameters.Add(p2)

            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub RemainingFollowUpEmailsFunc(RemainingFollowUpEmails As Integer)
        Try
            If con.State = False Then
                con.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "RemainingFollowUpEmails_Update"

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@RemainingFollowUpEmails"
            p.Value = RemainingFollowUpEmails
            cmd.Parameters.Add(p)

            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If RadioButtonList1.SelectedValue = "0" Then
            CCBCCTextDiv.Visible = "true"
            CCBCCText.Text = "CC Email"
            CCBCCTextDivBoth.Visible = "false"
            CCBCCBothText.Text = ""
        ElseIf RadioButtonList1.SelectedValue = "1" Then
            CCBCCTextDiv.Visible = "true"
            CCBCCText.Text = "BCC Email"
            CCBCCTextDivBoth.Visible = "false"
            CCBCCBothText.Text = ""
        ElseIf RadioButtonList1.SelectedValue = "3" Then
            CCBCCTextDiv.Visible = "true"
            CCBCCText.Text = "BCC Email"
            CCBCCTextDivBoth.Visible = "true"
            CCBCCBothText.Text = "CC Email"
        ElseIf RadioButtonList1.SelectedValue = "2" Then
            CCBCCTextDiv.Visible = "false"
            CCBCCTextDivBoth.Visible = "false"
            CCBCCBothText.Text = ""
            CCBCCText.Text = ""
        End If
    End Sub

    'Protected Sub RemainingExportableEmailsUpdate(GetLineCountLast As Integer)
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "RemainingExportEmails_Update"

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@RemainingEmails"
    '        p.Value = GetLineCountLast
    '        cmd.Parameters.Add(p)

    '        cmd.ExecuteNonQuery()
    '        con.Close()
    '        EmailCounterSearch()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub ImportEmailsBtn_Click(sender As Object, e As EventArgs) Handles ImportEmailsBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            If ImportEmailsUploader.HasFile Then
                Dim extension As String = Path.GetExtension(ImportEmailsUploader.FileName)
                If extension = ".csv" Or extension = ".CSV" Then
                    Dim GetLineCount As Integer
                    Dim GetLineCountLast As Integer
                    For Each files As HttpPostedFile In ImportEmailsUploader.PostedFiles
                        Dim fileName As String = Path.GetFileName(files.FileName)
                        files.SaveAs(Server.MapPath("~/ImportedEmails/") & fileName)
                        Dim csvPath As String = Server.MapPath("~/ImportedEmails/") & fileName
                        Dim csvData As String = File.ReadAllText(csvPath, System.Text.Encoding.UTF8)
                        Dim s As String() = Regex.Split(csvData, vbCr & vbLf)
                        With CreateObject("Scripting.FileSystemObject")
                            GetLineCount = UBound(Split(.OpenTextFile(csvPath, 1).ReadAll, vbNewLine)) + 1
                            GetLineCountLast = GetLineCount - 2
                        End With
                        'If Session(Session("TokenID") + "PackageType") <> "Premium" Then
                        '    If GetLineCountLast > AvailableEmailsText.Text Then
                        '        GetLineCountLast = AvailableEmailsText.Text
                        '    Else

                        '    End If
                        'Else
                        'End If
                        Dim NoOfCol As Integer
                        For i As Integer = 1 To GetLineCountLast
                            Dim r As String() = s(i).Split(","c)
                            Dim Name As String
                            Dim Company As String
                            NoOfCol = r.Length
                            If NoOfCol = 2 Then
                                Name = r(1)
                            Else
                                Name = ""
                            End If
                            Dim Emails As String = r(0)
                            If NoOfCol >= 3 Then
                                Name = r(1)
                                Company = r(2)
                            Else
                                Company = ""
                            End If
                            Dim UserID As Integer = Session(Session("TokenID") + "UserID")
                            If Emails <> "" Then
                                insertsql(Emails, Name, UserID, Company, "Unsent")
                            Else
                                Continue For
                            End If
                        Next
                    Next
                    'RemainingExportableEmailsUpdate(GetLineCountLast)
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!', '" & GetLineCountLast & "' + ' Email(s) Have Been Imported Successfully. <a href=EmailMarketingTool#ContentPlaceHolder1_RemainingEmailsText>View now</a>');", True)
                    GridSearchForUnsentMails()

                    NotificationText.Text = ""
                Else
                    NotificationText.Text = "Alert: " + "Please submit only .csv file format."
                End If
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Sub insertsql(Emails As String, Name As String, UserID As Integer, Company As String, Unsent As String)
        Dim constr As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        Using con As New SqlConnection(constr)

            Dim Sr As Integer
            Dim Adp As SqlDataAdapter = New SqlDataAdapter("select top 1 Sr from Client_Emails where Emails <> '' and  UserID = '" & Session(Session("TokenID") + "UserID") & "' order by Sr DESC ", con)
            Dim dst As New DataSet
            Dim dt As New DataTable
            Adp.Fill(dst, "Client_Emails_Sr")
            dt = dst.Tables("Client_Emails_Sr")
            If dt.Rows.Count > 0 Then
                Sr = dst.Tables("Client_Emails_Sr").Rows(0)("Sr") + 1
            Else
                Sr = 0
            End If
            Using cmd As New SqlCommand("insert into Client_Emails (Name,Emails,Company,Sr,UserID, Status, DateSent, ReadStatus) values (@Name, @Emails,@Company, '" & Sr & "', @UserID,  '" & Unsent & "', @DateSent, @ReadStatus)", con)
                cmd.Parameters.AddWithValue("@Emails", Emails)
                cmd.Parameters.AddWithValue("@Name", Name)
                cmd.Parameters.AddWithValue("@Company", Company)
                cmd.Parameters.AddWithValue("@UserID", UserID)
                cmd.Parameters.AddWithValue("@Sr", Sr)
                cmd.Parameters.AddWithValue("@Unsent", Unsent)
                cmd.Parameters.AddWithValue("@DateSent", Date.Now)
                cmd.Parameters.AddWithValue("@ReadStatus", "Unopened")
                If con.State = False Then
                    con.Open()
                End If
                Dim add As Integer = cmd.ExecuteNonQuery()
            End Using
        End Using
        con.Close()
    End Sub


    Protected Sub radGrid3_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub radGrid2_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub radGrid3_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim gvr As GridViewRow = CType((CType(e.CommandSource, LinkButton)).NamingContainer, GridViewRow)
            Dim RowIndex As Integer = gvr.RowIndex
            If e.CommandName = "Delete" Then
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
                Dim Sr As Label = (CType(radGrid3.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BulkEmails_Row_Delete"
                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = e.CommandArgument
                cmd.Parameters.Add(p)

                Dim p1 As New SqlParameter
                p1.ParameterName = "@Status"
                p1.Value = "Unsent"
                cmd.Parameters.Add(p1)

                Dim p2 As New SqlParameter
                p2.ParameterName = "@UserID"
                p2.Value = Session(Session("TokenID") + "UserID")
                cmd.Parameters.Add(p2)

                Dim p3 As New SqlParameter
                p3.ParameterName = "@Sr"
                p3.Value = Sr.Text
                cmd.Parameters.Add(p3)

                cmd.ExecuteNonQuery()
                GridSearchForUnsentMails()
            ElseIf e.CommandName = "Edit" Then
                Dim Name As TextBox = (CType(radGrid3.Rows(RowIndex).FindControl("Name"), TextBox))
                Dim CompanyName As TextBox = (CType(radGrid3.Rows(RowIndex).FindControl("CompanyName"), TextBox))
                Dim EmailAddress As TextBox = (CType(radGrid3.Rows(RowIndex).FindControl("EmailAddress"), TextBox))
                Dim DeleteRecord As LinkButton = (CType(radGrid3.Rows(RowIndex).FindControl("LinkButton2"), LinkButton))
                Dim EditRecord As LinkButton = (CType(radGrid3.Rows(RowIndex).FindControl("EditRecord"), LinkButton))
                Name.ReadOnly = False
                EmailAddress.ReadOnly = False
                CompanyName.ReadOnly = False
                Name.BackColor = Color.Moccasin
                EmailAddress.BackColor = Color.Moccasin
                CompanyName.BackColor = Color.Moccasin
                CancelAddBtn.Visible = True
                DeleteAllUnsentMailsBtn.Visible = False
                ExportUnsentEmailsBtn.Visible = False
                AddEmailButton.Visible = False
                radGrid3.HeaderRow.Cells(5).Text = " "
                DeleteRecord.Visible = False
                radGrid3.HeaderRow.Cells(6).Text = " "
                EditRecord.Visible = False
                UpdateRecordUnsent.Visible = True
                Dim SelectRecord As CheckBox = (CType(radGrid3.Rows(RowIndex).FindControl("SelectRecord"), CheckBox))
                radGrid3.HeaderRow.Cells(7).Text = " "
                SelectRecord.Visible = False
                SelectAllBtn.Visible = False
                UnSelectAllBtn.Visible = False
                'radGrid1.Focus()
                Session(Session("TokenID") + "PreviousEmail") = EmailAddress.Text
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
            End If
            CType(radGrid3.Rows(RowIndex).FindControl("Name"), TextBox).Focus()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub radGrid2_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Try
            If con.State = False Then
                con.Open()
            End If
            Dim gvr As GridViewRow = CType((CType(e.CommandSource, LinkButton)).NamingContainer, GridViewRow)
            Dim RowIndex As Integer = gvr.RowIndex
            If e.CommandName = "Delete" Then
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
                Dim Sr As Label = (CType(radGrid2.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BulkEmails_Row_Delete"
                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = e.CommandArgument
                cmd.Parameters.Add(p)

                Dim p1 As New SqlParameter
                p1.ParameterName = "@Status"
                p1.Value = "Sent"
                cmd.Parameters.Add(p1)

                Dim p2 As New SqlParameter
                p2.ParameterName = "@UserID"
                p2.Value = Session(Session("TokenID") + "UserID")
                cmd.Parameters.Add(p2)

                Dim p3 As New SqlParameter
                p3.ParameterName = "@Sr"
                p3.Value = Sr.Text
                cmd.Parameters.Add(p3)

                cmd.ExecuteNonQuery()
                GridSearchForBulk()
            ElseIf e.CommandName = "Edit" Then
                Dim Name As TextBox = (CType(radGrid2.Rows(RowIndex).FindControl("Name2"), TextBox))
                Dim CompanyName As TextBox = (CType(radGrid2.Rows(RowIndex).FindControl("CompanyName"), TextBox))
                Dim EmailAddress As TextBox = (CType(radGrid2.Rows(RowIndex).FindControl("EmailAddress2"), TextBox))
                Dim DeleteRecord As LinkButton = (CType(radGrid2.Rows(RowIndex).FindControl("LinkButton2"), LinkButton))
                Dim EditRecord As LinkButton = (CType(radGrid2.Rows(RowIndex).FindControl("EditRecord"), LinkButton))
                Name.ReadOnly = False
                EmailAddress.ReadOnly = False
                CompanyName.ReadOnly = False
                Name.BackColor = Color.Moccasin
                EmailAddress.BackColor = Color.Moccasin
                CompanyName.BackColor = Color.Moccasin
                CancelButtonSent.Visible = True
                DeleteAllSentMailsBtn.Visible = False
                ExportSentEmailsBtn.Visible = False
                radGrid2.HeaderRow.Cells(6).Text = ""
                DeleteRecord.Visible = False
                radGrid2.HeaderRow.Cells(7).Text = ""
                EditRecord.Visible = False
                UpdateRecordSent.Visible = True
                Dim SelectRecord As CheckBox = (CType(radGrid2.Rows(RowIndex).FindControl("SelectRecord"), CheckBox))
                radGrid2.HeaderRow.Cells(8).Text = " "
                SelectRecord.Visible = False
                SelectAllSentBtn.Visible = False
                UnSelectAllSentBtn.Visible = False
                'radGrid2.Focus()
                Session(Session("TokenID") + "PreviousEmail") = EmailAddress.Text
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
            End If
            CType(radGrid2.Rows(RowIndex).FindControl("Name2"), TextBox).Focus()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub radGrid1_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Try
            If con.State = False Then
                con.Open()
            End If
            Dim gvr As GridViewRow = CType((CType(e.CommandSource, LinkButton)).NamingContainer, GridViewRow)
            Dim RowIndex As Integer = gvr.RowIndex
            If e.CommandName = "Delete" Then
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
                Dim Sr As Label = (CType(radGrid1.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
                cmd.Parameters.Clear()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "BulkEmails_Row_Delete"
                p = New SqlParameter
                p.ParameterName = "@EmailAddress"
                p.Value = e.CommandArgument
                cmd.Parameters.Add(p)

                Dim p1 As New SqlParameter
                p1.ParameterName = "@Status"
                p1.Value = "Followed-Up"
                cmd.Parameters.Add(p1)

                Dim p2 As New SqlParameter
                p2.ParameterName = "@UserID"
                p2.Value = Session(Session("TokenID") + "UserID")
                cmd.Parameters.Add(p2)

                Dim p3 As New SqlParameter
                p3.ParameterName = "@Sr"
                p3.Value = Sr.Text
                cmd.Parameters.Add(p3)

                cmd.ExecuteNonQuery()
                GridSearchForFollowups()
            ElseIf e.CommandName = "Edit" Then
                Dim Name As TextBox = (CType(radGrid1.Rows(RowIndex).FindControl("Name3"), TextBox))
                Dim CompanyName As TextBox = (CType(radGrid1.Rows(RowIndex).FindControl("CompanyName"), TextBox))
                Dim EmailAddress As TextBox = (CType(radGrid1.Rows(RowIndex).FindControl("EmailAddress3"), TextBox))
                Dim DeleteRecord As LinkButton = (CType(radGrid1.Rows(RowIndex).FindControl("LinkButton2"), LinkButton))
                Dim EditRecord As LinkButton = (CType(radGrid1.Rows(RowIndex).FindControl("EditRecord"), LinkButton))
                Name.ReadOnly = False
                EmailAddress.ReadOnly = False
                CompanyName.ReadOnly = False
                Name.BackColor = Color.Moccasin
                EmailAddress.BackColor = Color.Moccasin
                CompanyName.BackColor = Color.Moccasin
                CancelButtonFollowed.Visible = True
                DeleteAllFollowedupMailsBtn.Visible = False
                ExportFollowedEmailsBtn.Visible = False
                radGrid1.HeaderRow.Cells(6).Text = ""
                DeleteRecord.Visible = False
                radGrid1.HeaderRow.Cells(7).Text = ""
                EditRecord.Visible = False
                UpdateRecordFollowed.Visible = True
                Dim SelectRecord As CheckBox = (CType(radGrid1.Rows(RowIndex).FindControl("SelectRecord"), CheckBox))
                radGrid1.HeaderRow.Cells(8).Text = " "
                SelectRecord.Visible = False
                UnselectFollowedEmailsBtn.Visible = False
                SelectFollowedEmailsBtn.Visible = False
                'radGrid1.Focus()
                Session(Session("TokenID") + "PreviousEmail") = EmailAddress.Text
                Session(Session("TokenID") + "IndexNo") = gvr.RowIndex
            End If
            CType(radGrid1.Rows(RowIndex).FindControl("Name3"), TextBox).Focus()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub radGrid1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

    End Sub

    Private Sub Field_Update(PreviousEmails As String, Emails As String, Name As String, Company As String, Status As String, UserID As Integer, Sr As Integer)
        Try
            If con.State = False Then
                con.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "BulkEmails_Fields_Update"

            p = New SqlParameter
            p.ParameterName = "@PreviousEmailAddress"
            p.Value = PreviousEmails
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@EmailAddress"
            p.Value = Emails
            cmd.Parameters.Add(p)

            Dim p1 As New SqlParameter
            p1.ParameterName = "@Name"
            p1.Value = Name
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@CompanyName"
            p2.Value = Company
            cmd.Parameters.Add(p2)

            Dim p3 As New SqlParameter
            p3.ParameterName = "@Status"
            p3.Value = Status
            cmd.Parameters.Add(p3)

            Dim p4 As New SqlParameter
            p4.ParameterName = "@UserID"
            p4.Value = UserID
            cmd.Parameters.Add(p4)

            Dim p5 As New SqlParameter
            p5.ParameterName = "@Sr"
            p5.Value = Sr
            cmd.Parameters.Add(p5)

            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub radGrid3_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub radGrid2_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub radGrid1_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Private Sub Sava_button_Click(sender As Object, e As EventArgs) Handles Sava_button.Click

        If con.State = False Then
            con.Open()
        End If
        NoFieldsEmptyChanges()
        If LetterSubject.Text <> "" And LetterBody.Text <> "" And SenderName.Text <> "" Then
            SearchSelectedUnsentEmails()
            NotificationText.Text = ""
            'mail_send()
            Try
                Dim p As Default3 = New Default3()
                p.DoOauthAndSendEmail()
            Catch ep As Exception
            End Try
        Else
            IfFieldsAreEmptyChecks()
        End If
        NotificationText.Text = ""
        'mail_send()
        con.Close()
    End Sub

    Private Sub NoFieldsEmptyChanges()

        If LetterSubject.Text <> "" And LetterSubject.CssClass = "form-control LetterBody mb-2 border border-danger" Then
            LetterSubject.CssClass = "form-control LetterBody mb-2 border border-success"
        ElseIf LetterBody.Text <> "" And LetterBody.CssClass = "form-control LetterBody mb-2 border border-danger" Then
            LetterBody.CssClass = "form-control LetterBody border border-success"
        ElseIf SenderName.Text <> "" And SenderName.CssClass = "form-control LetterBody mb-2 border border-danger" Then
            SenderName.CssClass = "form-control LetterBody mb-2 border border-success"
            'ElseIf SenderEmailAddress.Text <> "" And SenderEmailAddress.CssClass = "form-control LetterBody mb-2 border border-danger" Then
            '    SenderEmailAddress.CssClass = "form-control LetterBody mb-2 border border-success"
            'ElseIf SenderPassword.Text <> "" And SenderPassword.CssClass = "form-control LetterBody mb-2 border border-danger" Then
            '    SenderPassword.CssClass = "form-control LetterBody mb-2 border border-success"
        End If

    End Sub

    Private Sub IfFieldsAreEmptyChecks()
        'If SenderEmailAddress.Text = "" Then
        '    NotificationText.Text = "Alert: " + "Please Make Sure Your Provide The Correct Gmail Address Of The Sender."
        '    'SenderEmailAddress.Focus()
        '    SenderEmailAddress.CssClass = "form-control LetterBody mb-2 border border-danger"
        'ElseIf SenderPassword.Text = "" Then
        '    NotificationText.Text = "Alert: " + "Please Make Sure Your Provide The Correct Gmail Password Of The Sender's Email."
        '    'SenderPassword.Focus()
        '    SenderPassword.CssClass = "form-control LetterBody mb-2 border border-danger"
        If SenderName.Text = "" Then
            NotificationText.Text = "Alert: " + "Please Make Sure Your Provide A Name For Sender To Help Receiver Know That It Is From You."
            'SenderEmailAddress.Focus()
            SenderName.CssClass = "form-control LetterBody mb-2 border border-danger"
        ElseIf LetterSubject.Text = "" Then
            NotificationText.Text = "Alert: " + "Please Provide A Subject For The Email."
            'LetterSubject.Focus()
            LetterSubject.CssClass = "form-control LetterBody mb-2 border border-danger"
        ElseIf LetterBody.Text = "" Then
            NotificationText.Text = "Alert: " + "Please Provide A Body Text For The Email."
            'LetterBody.Focus()
            LetterBody.CssClass = "form-control LetterBody border border-danger"
        End If
    End Sub

    Private Sub FollowUp_button_Click(sender As Object, e As EventArgs) Handles FollowUp_button.Click

        If con.State = False Then
            con.Open()
        End If
        NoFieldsEmptyChanges()
        If LetterSubject.Text <> "" And LetterBody.Text <> "" And SenderName.Text <> "" Then
            SearchSelectedSentEmails()
            NotificationText.Text = ""
            'Followup_mail_send()
            Try
                Dim a As Default3 = New Default3()
                a.DoOauthAndSendFollowupEmail()
            Catch ep As Exception
            End Try
        Else
            IfFieldsAreEmptyChecks()
        End If
        con.Close()
    End Sub

    Protected Sub AttachEmailSignature_DataBinding(sender As Object, e As EventArgs)

    End Sub

    Private Sub AttachEmailSignatureBtn_Click(sender As Object, e As EventArgs) Handles AttachEmailSignatureBtn.Click
        If con.State = False Then
            con.Open()
        End If
        If AttachEmailSignature.HasFile Then
            'For Each file As HttpPostedFile In AttachEmailSignature.PostedFiles
            Dim extension As String = Path.GetExtension(AttachEmailSignature.FileName)
            If extension = ".png" Or extension = ".jpeg" Or extension = ".jpg" Then
                Dim folderPath As String = Server.MapPath("~/InnerAttachments/")

                'Check whether Directory (Folder) exists.
                If Not Directory.Exists(folderPath) Then
                    'If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath)
                End If

                Dim fileName As String = Path.GetFileName(AttachEmailSignature.FileName)
                AttachEmailSignature.SaveAs(Server.MapPath("~/InnerAttachments/") & fileName)
                Session(Session("TokenID") + "AttachedImagePath") = Path.GetFileName(AttachEmailSignature.FileName)
                Session(Session("TokenID") + "LetterBodyAttachmentPath") = folderPath + Path.GetFileName(AttachEmailSignature.FileName)
                Session(Session("TokenID") + "LetterBodyAttachmentFolderPath") = folderPath
                'gets count of all text files in c drive root folder

                Dim MyFiles1() As String = IO.Directory.GetFiles(Session(Session("TokenID") + "LetterBodyAttachmentFolderPath"), "*.*")
                InnerAttachmentText.Text = "Success!" + " Signature has been added successfully."
                InnerAttachmentText.CssClass = "pt-1 f-14 text-success"

                Session(Session("TokenID") + "LetterBodyTextPrevious") = LetterBody.Text
                LetterBody.Text += "<br/><img src='/InnerAttachments/" + Session(Session("TokenID") + "AttachedImagePath") + "' height=100>"
                'LetterBody.Text += "<img src='" + Session(Session("TokenID") + "LetterBodyAttachmentPath") + "' height=100 />"
            Else
                InnerAttachmentText.Text = "You can only upload .png, .jpg or .jpeg image files."
                InnerAttachmentText.CssClass = "pt-1 f-14 text-danger"
                'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('File not supported!', 'You can only upload .png, .jpg or .jpeg image files.');", True)
                'Sava_button.Focus()
            End If
            'Next
        End If
        'Sava_button.Focus()
        con.Close()
    End Sub
    Private Sub RemoveInnerAttachments_Click(sender As Object, e As EventArgs) Handles RemoveInnerAttachments.Click
        If con.State = False Then
            con.Open()
        End If
        If Session(Session("TokenID") + "LetterBodyAttachmentFolderPath") <> "" Then
            Try
                Dim directoryName As String = Session(Session("TokenID") + "LetterBodyAttachmentFolderPath")
                For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(filename)
                Next
                InnerAttachmentText.Text = "Signature is removed."
                InnerAttachmentText.CssClass = "pt-1 f-14 text-success"
                'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!', 'Attachments are removed.');", True)
                'Session(Session("TokenID") + "LetterBodyTextPrevious") = LetterBody.Text
                'LetterBody.Text = LetterBody.Text.Replace("<br/><img src='/InnerAttachments/" + Session(Session("TokenID") + "AttachedImagePath") + "' height=100>", "").Trim()

            Catch ex As Exception
            End Try
        Else
            InnerAttachmentText.Text = "Nothing to remove."
            InnerAttachmentText.CssClass = "pt-1 f-14 text-info"
        End If
        'Sava_button.Focus()
        con.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If con.State = False Then
            con.Open()
        End If
        If image_FileUpload.HasFile Then
            For Each file As HttpPostedFile In image_FileUpload.PostedFiles
                If file.ContentLength < 20728650 Then
                    Dim folderPath As String = Server.MapPath("~/Attachments/")

                    Dim extension As String = Path.GetExtension(file.FileName)
                    'Check whether Directory (Folder) exists.
                    If Not Directory.Exists(folderPath) Then
                        'If Directory (Folder) does not exists Create it.
                        Directory.CreateDirectory(folderPath)
                    End If

                    Dim fileName As String = Path.GetFileName(file.FileName)
                    file.SaveAs(Server.MapPath("~/Attachments/") & fileName)
                    Session(Session("TokenID") + "path") = folderPath & Path.GetFileName(file.FileName)
                    Session(Session("TokenID") + "folderPath") = folderPath
                    'gets count of all text files in c drive root folder
                    Dim MyFiles1() As String = IO.Directory.GetFiles(Session(Session("TokenID") + "folderPath"), "*.*")
                    FileUploadText.Text = "Success!" + " " + (MyFiles1.GetUpperBound(0) + 1).ToString + " " + "File(s) attached successfully."
                    FileUploadText.CssClass = "p-1 f-14 text-success"
                    'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Attachments Uploaded!', 'File(s) attached successfully.');", True)
                Else
                    FileUploadText.Text = "File size exceeds maximum limit of 20 MB."
                    FileUploadText.CssClass = "p-1 f-14 text-danger"
                    'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Error!', 'File size exceeds maximum limit of 20 MB.');", True)
                End If
            Next
        End If
        'Sava_button.Focus()
        con.Close()
    End Sub

    Private Sub RemoveAttachments_Click(sender As Object, e As EventArgs) Handles RemoveAttachments.Click
        If con.State = False Then
            con.Open()
        End If
        If Session(Session("TokenID") + "folderPath") <> "" Then
            Try
                Dim directoryName As String = Session(Session("TokenID") + "folderPath")
                For Each filename In Directory.GetFiles(directoryName, "*.*", SearchOption.TopDirectoryOnly)
                    File.Delete(filename)
                Next
                FileUploadText.Text = "Attachments are removed."
                FileUploadText.CssClass = "p-1 f-14 text-success"
                'ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!', 'Attachments are removed.');", True)

            Catch ex As Exception
            End Try
        Else

        End If
        'Sava_button.Focus()
        con.Close()
    End Sub
    Private Sub SetInitialRow()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim dt As DataTable = New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("Sr", GetType(String)))
            dt.Columns.Add(New DataColumn("Name", GetType(String)))
            dt.Columns.Add(New DataColumn("Emails", GetType(String)))
            dt.Columns.Add(New DataColumn("Company", GetType(String)))
            dt.Columns.Add(New DataColumn("DateSent", GetType(Date)))
            dr = dt.NewRow()
            dr("Sr") = 0
            dr("Name") = String.Empty
            dr("Emails") = String.Empty
            dr("Company") = String.Empty
            dr("DateSent") = Date.Today
            dt.Rows.Add(dr)
            ViewState("CurrentTable") = dt
            radGrid3.DataSource = dt
            radGrid3.DataBind()
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddNewRowToGrid()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim rowIndex As Integer = 0
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = CType(ViewState("CurrentTable"), DataTable)
                If dtCurrentTable.Rows.Count > 0 Then

                    Dim Sr As Integer
                    Dim Adp As SqlDataAdapter = New SqlDataAdapter("select top 1 Sr from Client_Emails where Emails <> '' and  UserID = '" & Session(Session("TokenID") + "UserID") & "' order by Sr DESC ", con)
                    Dim dst As New DataSet
                    Dim dt As New DataTable
                    Adp.Fill(dst, "Client_Emails_Sr")
                    dt = dst.Tables("Client_Emails_Sr")
                    If dt.Rows.Count > 0 Then
                        Sr = dst.Tables("Client_Emails_Sr").Rows(0)("Sr") + 1
                    Else
                        Sr = 0
                    End If
                    Dim Name As TextBox = (CType(radGrid3.Rows(0).FindControl("Name"), TextBox))
                    Dim CompanyName As TextBox = (CType(radGrid3.Rows(0).FindControl("CompanyName"), TextBox))
                    Dim EmailAddress As TextBox = (CType(radGrid3.Rows(0).FindControl("EmailAddress"), TextBox))
                    IsValidEmailFormat(EmailAddress.Text)
                    If Session(Session("TokenID") + "EmailValidation") = "Valid" And EmailAddress.Text <> "" Then
                        If con.State = False Then
                            con.Open()
                        End If
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "AddNewRowT_BulkEmails"

                        p = New SqlParameter
                        p.ParameterName = "@EmailAddress"
                        p.Value = EmailAddress.Text
                        cmd.Parameters.Add(p)

                        Dim p1 As New SqlParameter
                        p1.ParameterName = "@Name"
                        If Name.Text = "" Then
                            p1.Value = ""
                        Else
                            p1.Value = Name.Text
                        End If
                        cmd.Parameters.Add(p1)

                        Dim p2 As New SqlParameter
                        p2.ParameterName = "@CompanyName"
                        If Name.Text = "" Then
                            p2.Value = ""
                        Else
                            p2.Value = CompanyName.Text
                        End If
                        cmd.Parameters.Add(p2)

                        Dim p3 As New SqlParameter
                        p3.ParameterName = "@Status"
                        p3.Value = "Unsent"
                        cmd.Parameters.Add(p3)

                        Dim p4 As New SqlParameter
                        p4.ParameterName = "@UserID"
                        p4.Value = Session(Session("TokenID") + "UserID")
                        cmd.Parameters.Add(p4)

                        Dim p5 As New SqlParameter
                        p5.ParameterName = "@Sr"
                        p5.Value = Sr
                        cmd.Parameters.Add(p5)

                        Dim p6 As New SqlParameter
                        p6.ParameterName = "@ReadStatus"
                        p6.Value = "Unopened"
                        cmd.Parameters.Add(p6)

                        cmd.ExecuteNonQuery()
                    Else
                        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Invalid Format!', 'Email is not in correct format.');", True)
                    End If
                    radGrid3.DataSource = dtCurrentTable
                    radGrid3.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddEmailButton_Click(sender As Object, e As EventArgs) Handles AddEmailButton.Click
        SetInitialRow()
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Name As TextBox = (CType(radGrid3.Rows(0).FindControl("Name"), TextBox))
            Dim CompanyName As TextBox = (CType(radGrid3.Rows(0).FindControl("CompanyName"), TextBox))
            Dim EmailAddress As TextBox = (CType(radGrid3.Rows(0).FindControl("EmailAddress"), TextBox))
            Dim DateSent As Label = (CType(radGrid3.Rows(0).FindControl("DateSent"), Label))
            Dim DeleteRecord As LinkButton = (CType(radGrid3.Rows(0).FindControl("LinkButton2"), LinkButton))
            Dim EditRecord As LinkButton = (CType(radGrid3.Rows(0).FindControl("EditRecord"), LinkButton))
            Name.ReadOnly = False
            EmailAddress.ReadOnly = False
            CompanyName.ReadOnly = False
            Name.BackColor = Color.Moccasin
            EmailAddress.BackColor = Color.Moccasin
            CompanyName.BackColor = Color.Moccasin
            AddEmailButton.Visible = False
            AddEmailRowBtn.Visible = True
            CancelAddBtn.Visible = True
            DeleteAllUnsentMailsBtn.Visible = False
            ExportUnsentEmailsBtn.Visible = False
            DateSent.Visible = False
            radGrid3.HeaderRow.Cells(5).Text = ""
            radGrid3.HeaderRow.Cells(4).Text = " "
            DeleteRecord.Visible = False
            radGrid3.HeaderRow.Cells(6).Text = ""
            EditRecord.Visible = False
            Dim SelectRecord As CheckBox = (CType(radGrid3.Rows(0).FindControl("SelectRecord"), CheckBox))
            radGrid3.HeaderRow.Cells(7).Text = " "
            SelectRecord.Visible = False
            SelectAllBtn.Visible = False
            UnSelectAllBtn.Visible = False
            Session(Session("TokenID") + "AddCommand") = "True"
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub AddEmailRowBtn_Click(sender As Object, e As EventArgs) Handles AddEmailRowBtn.Click
        AddNewRowToGrid()
        GridSearchForUnsentMails()
    End Sub

    Private Sub CancelAddBtn_Click(sender As Object, e As EventArgs) Handles CancelAddBtn.Click
        GridSearchForUnsentMails()
    End Sub

    Private Sub CancelButtonFollowed_Click(sender As Object, e As EventArgs) Handles CancelButtonFollowed.Click
        GridSearchForFollowups()
    End Sub

    Private Sub CancelButtonSent_Click(sender As Object, e As EventArgs) Handles CancelButtonSent.Click
        GridSearchForBulk()
    End Sub

    Private Sub UpdateRecordUnsent_Click(sender As Object, e As EventArgs) Handles UpdateRecordUnsent.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Name As TextBox = (CType(radGrid3.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Name"), TextBox))
            Dim EmailAddress As TextBox = (CType(radGrid3.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("EmailAddress"), TextBox))
            Dim Company As TextBox = (CType(radGrid3.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("CompanyName"), TextBox))
            Dim Sr As Label = (CType(radGrid3.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
            If EmailAddress.Text = "" Then
                EmailAddress.BorderWidth = Unit.Pixel(1)
                EmailAddress.BorderColor = Color.Red
            Else
                IsValidEmailFormat(EmailAddress.Text)
                If Session(Session("TokenID") + "EmailValidation") = "Valid" Then
                    EmailAddress.BorderWidth = Unit.Pixel(0)
                    EmailAddress.BorderColor = Color.Transparent
                    Field_Update(Session(Session("TokenID") + "PreviousEmail"), EmailAddress.Text, Name.Text, Company.Text, "Unsent", Session(Session("TokenID") + "UserID"), Sr.Text)
                    GridSearchForUnsentMails()
                Else
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Invalid Format!', 'Email is not in correct format.');", True)
                End If
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateRecordFollowed_Click(sender As Object, e As EventArgs) Handles UpdateRecordFollowed.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Name As TextBox = (CType(radGrid1.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Name3"), TextBox))
            Dim EmailAddress As TextBox = (CType(radGrid1.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("EmailAddress3"), TextBox))
            Dim Company As TextBox = (CType(radGrid1.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("CompanyName"), TextBox))
            Dim Sr As Label = (CType(radGrid1.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
            If EmailAddress.Text = "" Then
                EmailAddress.BorderWidth = Unit.Pixel(1)
                EmailAddress.BorderColor = Color.Red
            Else
                IsValidEmailFormat(EmailAddress.Text)
                If Session(Session("TokenID") + "EmailValidation") = "Valid" Then
                    EmailAddress.BorderWidth = Unit.Pixel(0)
                    EmailAddress.BorderColor = Color.Transparent
                    Field_Update(Session(Session("TokenID") + "PreviousEmail"), EmailAddress.Text, Name.Text, Company.Text, "Followed-Up", Session(Session("TokenID") + "UserID"), Sr.Text)
                    GridSearchForFollowups()
                Else
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Invalid Format!', 'Email is not in correct format.');", True)
                End If
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UpdateRecordSent_Click(sender As Object, e As EventArgs) Handles UpdateRecordSent.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            Dim Name As TextBox = (CType(radGrid2.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Name2"), TextBox))
            Dim EmailAddress As TextBox = (CType(radGrid2.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("EmailAddress2"), TextBox))
            Dim Company As TextBox = (CType(radGrid2.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("CompanyName"), TextBox))
            Dim Sr As Label = (CType(radGrid2.Rows(Session(Session("TokenID") + "IndexNo")).FindControl("Sr"), Label))
            If EmailAddress.Text = "" Then
                EmailAddress.BorderWidth = Unit.Pixel(1)
                EmailAddress.BorderColor = Color.Red
            Else
                IsValidEmailFormat(EmailAddress.Text)
                If Session(Session("TokenID") + "EmailValidation") = "Valid" Then
                    EmailAddress.BorderWidth = Unit.Pixel(0)
                    EmailAddress.BorderColor = Color.Transparent
                    Field_Update(Session(Session("TokenID") + "PreviousEmail"), EmailAddress.Text, Name.Text, Company.Text, "Sent", Session(Session("TokenID") + "UserID"), Sr.Text)
                    GridSearchForBulk()
                Else
                    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Invalid Format!', 'Email is not in correct format.');", True)
                End If
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub
    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            If con.State = False Then
                con.Open()
            End If
            If Regex.IsMatch(s, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$") Then
                Session(Session("TokenID") + "EmailValidation") = "Valid"
                Return True
            Else
                Session(Session("TokenID") + "EmailValidation") = ""
                Return False
            End If
            con.Close()
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Protected Sub Update_SavedTemplates()
    '    If con.State = False Then
    '        con.Open()
    '    End If
    '    Try
    '        cmd.Parameters.Clear()
    '        cmd.CommandText = "Update_SavedTemplates"
    '        cmd.CommandType = CommandType.StoredProcedure

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Template_ID"
    '        p.Value = LetterBody.Text
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Template_Text"
    '        p.Value = LetterBody.Text
    '        cmd.Parameters.Add(p)

    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try

    '    con.Close()
    'End Sub

    Protected Sub Delete_SavedTemplates(templateID As Integer)
        If con.State = False Then
            con.Open()
        End If
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "Delete_SavedTemplates"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Template_ID"
            p.Value = templateID
            cmd.Parameters.Add(p)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub

    Protected Sub Search_SavedTemplates()
        If con.State = False Then
            con.Open()
        End If
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "Search_SavedTemplates"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "SavedTemplates_Table")
            If DS.Tables("SavedTemplates_Table").Rows.Count = 0 Then
                SavedTemplatesBtn.Visible = False
            Else
                SavedTemplatesBtn.Visible = True
            End If
            Using sda As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                sda.Fill(dt)
                ModalSlider_TemplateRepeater.DataSource = dt
                ModalSlider_TemplateRepeater.DataBind()
            End Using
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub


    Protected Sub Search_DefaultTemplates()
        If con.State = False Then
            con.Open()
        End If
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "Search_DefaultTemplates"
            cmd.CommandType = CommandType.StoredProcedure

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "DefaultTemplates_Table")
            Using sda As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                sda.Fill(dt)
                ModalSlider_DefaultTemplateRepeater.DataSource = dt
                ModalSlider_DefaultTemplateRepeater.DataBind()
            End Using
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub

    Protected Sub Insert_SavedTemplates()
        If con.State = False Then
            con.Open()
        End If
        Try
            cmd.Parameters.Clear()
            cmd.CommandText = "Insert_SavedTemplates"
            cmd.CommandType = CommandType.StoredProcedure

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Template_Text"
            p.Value = LetterBody.Text
            cmd.Parameters.Add(p)

            p = New SqlParameter
            p.ParameterName = "@Template_Subject"
            p.Value = LetterSubject.Text
            cmd.Parameters.Add(p)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub
    Protected Sub GetValue(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, RepeaterItem)
        Dim templateID As Integer = (TryCast(item.FindControl("SavedTemplateID"), Label)).Text
        Delete_SavedTemplates(templateID)
        Search_SavedTemplates()
        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Deleted!', 'Template has been deleted, successfully.');", True)
        'RemoveInnerAttachments.Focus()
    End Sub

    Protected Sub UseDefaultTemplate(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, RepeaterItem)
        Dim TemplateText As String = (TryCast(item.FindControl("TemplateText"), Label)).Text
        Dim TemplateSubject As String = (TryCast(item.FindControl("TemplateSubject"), Label)).Text
        LetterBody.Text = TemplateText
        LetterSubject.Text = TemplateSubject
        'RemoveInnerAttachments.Focus()
    End Sub

    Protected Sub GetSavedTemplateText(ByVal sender As Object, ByVal e As EventArgs)
        Dim item As RepeaterItem = TryCast((TryCast(sender, LinkButton)).NamingContainer, RepeaterItem)
        Dim TemplateText As String = (TryCast(item.FindControl("SavedTemplateText"), Label)).Text
        Dim TemplateSubject As String = (TryCast(item.FindControl("TemplateSubject"), Label)).Text
        LetterBody.Text = TemplateText
        LetterSubject.Text = TemplateSubject
        'RemoveInnerAttachments.Focus()
    End Sub

    Private Sub SaveTemplateBtn_Click(sender As Object, e As EventArgs) Handles SaveTemplateBtn.Click
        If LetterBody.Text <> "" Then
            Insert_SavedTemplates()
            Search_SavedTemplates()
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Saved!', 'Template has been saved, successfully.');", True)
            'RemoveInnerAttachments.Focus()
        Else
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Empty Content!', 'There is nothing to save.');", True)
            'RemoveInnerAttachments.Focus()
        End If
    End Sub

    'Private Sub SenderEmailAddress_TextChanged(sender As Object, e As EventArgs) Handles SenderEmailAddress.TextChanged
    '    googleEmailRef.InnerText = SenderEmailAddress.Text
    'End Sub

    Protected Sub SearchSelectedUnsentEmails()
        If con.State = False Then
            con.Open()
        End If
        Try
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company"), New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid3.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(7).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name"), TextBox).Text
                        Dim Sr As String = TryCast(row.Cells(1).FindControl("Sr"), Label).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        dt.Rows.Add(Name, Emails, Company, Sr)
                    End If
                End If
            Next

            Session(Session("TokenID") + "TokenID3") = dt
            SelectedRows.DataSource = dt
            SelectedRows.DataBind()
            SelectedUnsentEmails.Text = dt.Rows.Count()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub

    Protected Sub SearchSelectedSentEmails()
        If con.State = False Then
            con.Open()
        End If
        Try
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company"), New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name2"), TextBox).Text
                        Dim Sr As String = TryCast(row.Cells(1).FindControl("Sr"), Label).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress2"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        dt.Rows.Add(Name, Emails, Company, Sr)
                    End If
                End If
            Next

            Session(Session("TokenID") + "TokenID") = dt
            SelectedSentEmailRows.DataSource = dt
            SelectedSentEmailRows.DataBind()
            SelectedSentEmailsText.Text = dt.Rows.Count()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub
    Private Sub SelectAllBtn_Click(sender As Object, e As EventArgs) Handles SelectAllBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid3.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(7).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = True
                End If
            Next
            con.Close()
            SearchSelectedUnsentEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UnSelectAllBtn_Click(sender As Object, e As EventArgs) Handles UnSelectAllBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid3.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(7).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = False
                End If
            Next
            con.Close()
            SearchSelectedUnsentEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UnSelectAllSentBtn_Click(sender As Object, e As EventArgs) Handles UnSelectAllSentBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = False
                End If
            Next
            con.Close()
            SearchSelectedSentEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SelectAllSentBtn_Click(sender As Object, e As EventArgs) Handles SelectAllSentBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = True
                End If
            Next
            con.Close()
            SearchSelectedSentEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DeleteAllUnsentMailsBtn_Click(sender As Object, e As EventArgs) Handles DeleteAllUnsentMailsBtn.Click
        Try
            SearchSelectedUnsentEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(0) {New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid3.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(7).FindControl("SelectRecord"), CheckBox)
                    Dim Sr As Label = TryCast(row.Cells(1).FindControl("Sr"), Label)
                    If chkRow.Checked Then

                        dt.Rows.Add(Sr)
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "BulkEmails_Row_Delete_Bulk"

                        p = New SqlParameter
                        p.ParameterName = "@Status"
                        p.Value = "Unsent"
                        cmd.Parameters.Add(p)

                        Dim p3 As New SqlParameter
                        p3.ParameterName = "@Sr"
                        p3.Value = Sr.Text
                        cmd.Parameters.Add(p3)

                        Dim p2 As New SqlParameter
                        p2.ParameterName = "@UserID"
                        p2.Value = Session(Session("TokenID") + "UserID")
                        cmd.Parameters.Add(p2)

                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            con.Close()
            GridSearchForUnsentMails()
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!','" & dt.Rows.Count() & "' +' Selected Emails Have Been Deleted Successfully.');", True)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DeleteAllSentMailsBtn_Click(sender As Object, e As EventArgs) Handles DeleteAllSentMailsBtn.Click
        Try
            SearchSelectedSentEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(0) {New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    Dim Sr As Label = TryCast(row.Cells(1).FindControl("Sr"), Label)
                    If chkRow.Checked Then

                        dt.Rows.Add(Sr)
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "BulkEmails_Row_Delete_Bulk"

                        p = New SqlParameter
                        p.ParameterName = "@Status"
                        p.Value = "Sent"
                        cmd.Parameters.Add(p)

                        Dim p3 As New SqlParameter
                        p3.ParameterName = "@Sr"
                        p3.Value = Sr.Text
                        cmd.Parameters.Add(p3)

                        Dim p2 As New SqlParameter
                        p2.ParameterName = "@UserID"
                        p2.Value = Session(Session("TokenID") + "UserID")
                        cmd.Parameters.Add(p2)

                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            con.Close()
            GridSearchForBulk()
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!','" & dt.Rows.Count() & "' +' Selected Emails Have Been Deleted Successfully.');", True)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportSentEmailsBtn_Click(sender As Object, e As EventArgs) Handles ExportSentEmailsBtn.Click
        Try
            SearchSelectedSentEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(4) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company"), New DataColumn("DateSent"), New DataColumn("Status")})
            For Each row As GridViewRow In radGrid2.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name2"), TextBox).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress2"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        Dim DateSent As String = TryCast(row.Cells(4).FindControl("DateSent2"), Label).Text
                        Dim Status As String = TryCast(row.Cells(5).FindControl("Status"), Label).Text
                        dt.Rows.Add(Name, Emails, Company, DateSent, Status)
                    End If
                End If
            Next
            Dim FileName As String = "ExportSentEmails"
            ExportCSV(dt, FileName)
            con.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportUnsentEmailsBtn_Click(sender As Object, e As EventArgs) Handles ExportUnsentEmailsBtn.Click
        Try
            SearchSelectedUnsentEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company")})
            For Each row As GridViewRow In radGrid3.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(6).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name"), TextBox).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        dt.Rows.Add(Name, Emails, Company)

                    End If
                End If
            Next
            Dim FileName As String = "ExportUnesentEmails"
            ExportCSV(dt, FileName)
            con.Close()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ExportCSV(dt As DataTable, NameOfFile As String)
        Try
            'Build the CSV file data as a Comma separated string.
            Dim csv As String = String.Empty

            For Each column As DataColumn In dt.Columns
                'Add the Header row for CSV file.
                csv += column.ColumnName + ","c
            Next

            'Add new line.
            csv += vbCr & vbLf

            For Each row As DataRow In dt.Rows
                For Each column As DataColumn In dt.Columns
                    'Add the Data rows.
                    csv += row(column.ColumnName).ToString().Replace(",", ";") + ","c
                Next

                'Add new line.
                csv += vbCr & vbLf
            Next

            'Download the CSV file.
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + NameOfFile + ".csv")
            Response.Charset = ""
            Response.ContentType = "application/text"
            Response.Output.Write(csv)
            Response.Flush()
            Response.End()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub SelectFollowedEmailsBtn_Click(sender As Object, e As EventArgs) Handles SelectFollowedEmailsBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = True
                End If
            Next
            con.Close()
            SearchSelectedFollowedEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub UnselectFollowedEmailsBtn_Click(sender As Object, e As EventArgs) Handles UnselectFollowedEmailsBtn.Click
        Try
            If con.State = False Then
                con.Open()
            End If
            For Each row As GridViewRow In radGrid1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    chkRow.Checked = False
                End If
            Next
            con.Close()
            SearchSelectedFollowedEmails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DeleteAllFollowedupMailsBtn_Click(sender As Object, e As EventArgs) Handles DeleteAllFollowedupMailsBtn.Click

        Try
            SearchSelectedFollowedEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(0) {New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    Dim Sr As Label = TryCast(row.Cells(1).FindControl("Sr"), Label)
                    If chkRow.Checked Then

                        dt.Rows.Add(Sr)
                        cmd.Parameters.Clear()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandText = "BulkEmails_Row_Delete_Bulk"

                        p = New SqlParameter
                        p.ParameterName = "@Status"
                        p.Value = "Followed-Up"
                        cmd.Parameters.Add(p)

                        Dim p3 As New SqlParameter
                        p3.ParameterName = "@Sr"
                        p3.Value = Sr.Text
                        cmd.Parameters.Add(p3)

                        Dim p2 As New SqlParameter
                        p2.ParameterName = "@UserID"
                        p2.Value = Session(Session("TokenID") + "UserID")
                        cmd.Parameters.Add(p2)

                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            con.Close()
            GridSearchForFollowups()
            ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "AddedLog2('Success!','" & dt.Rows.Count() & "' +' Selected Emails Have Been Deleted Successfully.');", True)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExportFollowedEmailsBtn_Click(sender As Object, e As EventArgs) Handles ExportFollowedEmailsBtn.Click

        Try
            SearchSelectedFollowedEmails()
            If con.State = False Then
                con.Open()
            End If
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(4) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company"), New DataColumn("DateSent"), New DataColumn("Status")})
            For Each row As GridViewRow In radGrid1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name3"), TextBox).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress3"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        Dim DateSent As String = TryCast(row.Cells(4).FindControl("DateSent3"), Label).Text
                        Dim Status As String = TryCast(row.Cells(5).FindControl("Status"), Label).Text
                        dt.Rows.Add(Name, Emails, Company, DateSent, Status)
                    End If
                End If
            Next
            Dim FileName As String = "ExportFollowedEmails"
            ExportCSV(dt, FileName)
            con.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub SearchSelectedFollowedEmails()
        If con.State = False Then
            con.Open()
        End If
        Try
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(3) {New DataColumn("Name"), New DataColumn("Emails"), New DataColumn("Company"), New DataColumn("Sr")})
            For Each row As GridViewRow In radGrid1.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(row.Cells(8).FindControl("SelectRecord"), CheckBox)
                    If chkRow.Checked Then
                        Dim Name As String = TryCast(row.Cells(0).FindControl("Name3"), TextBox).Text
                        Dim Sr As String = TryCast(row.Cells(1).FindControl("Sr"), Label).Text
                        Dim Emails As String = TryCast(row.Cells(2).FindControl("EmailAddress3"), TextBox).Text
                        Dim Company As String = TryCast(row.Cells(3).FindControl("CompanyName"), TextBox).Text
                        dt.Rows.Add(Name, Emails, Company, Sr)
                    End If
                End If
            Next

            Session(Session("TokenID") + "TokenID1") = dt
            SelectedFollowedEmailRows.DataSource = dt
            SelectedFollowedEmailRows.DataBind()
            SelectedFollowedEmailsText.Text = dt.Rows.Count()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub

    'Private Sub UseDemoCredentialsBtn_Click(sender As Object, e As EventArgs) Handles UseDemoCredentialsBtn.Click
    '    SenderEmailAddress.Text = System.Configuration.ConfigurationManager.AppSettings("SmtpUser")
    '    SenderPassword.Text = "demo@123"
    '    SenderCompanyEmailAddress.Text = "demo@eboxmarketing.com"
    '    SenderCompanyEmailAddress.Text = "demo@eboxmarketing.com"
    '    SenderName.Text = "Ebox Marketing Solutions"
    '    SenderEmailAddress.Enabled = False
    '    SenderPassword.Enabled = False
    '    SenderCompanyEmailAddress.Enabled = False
    '    SenderName.Enabled = False
    '    InstructionsBody.Visible = False
    'End Sub

    'Private Sub PrintPage_Btn_Click(sender As Object, e As EventArgs) Handles PrintPage_Btn.Click
    '    ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "window.print();", True)
    'End Sub
End Class
