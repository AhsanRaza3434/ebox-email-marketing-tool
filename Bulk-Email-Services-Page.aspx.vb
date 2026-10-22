Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class Home

    Inherits System.Web.UI.Page
    'Dim cmd As New SqlCommand
    'Dim con As New SqlConnection
    'Dim p As New SqlParameter

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        'Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        'con.ConnectionString = c
        'cmd.Connection = con
        'If con.State = False Then
        '    con.Open()
        'End If
        If Not IsPostBack Then
            'Session(Session("TokenID") + "PackageTypeUpdate") = ""
            'Session(Session("TokenID") + "AvailableEmailsUpdate") = ""
            'Session(Session("TokenID") + "RemainingSendableEmailsUpdate") = ""
            'Session(Session("TokenID") + "PaymentStatus") = ""
            'Session(Session("TokenID") + "SendableEmailsText") = ""
            Session(Session("TokenID") + "NewUserID") = ""
            Session(Session("TokenID") + "ActivationCode") = ""
            Session(Session("TokenID") + "profileEmail") = ""
            Session(Session("TokenID") + "profileName") = ""
            Session(Session("TokenID") + "profileID") = ""
            Session(Session("TokenID") + "GoogleSignup") = ""
            Session(Session("TokenID") + "SignupGoogleCode") = ""
            Session(Session("TokenID") + "LoginGoogleCode") = ""
            Session(Session("TokenID") + "GoogleCode") = ""
            Session(Session("TokenID") + "JsonCode") = ""

            '    Dim RemainingDays As Integer
            '    If Request.Cookies("UID") IsNot "" And Request.Cookies("USN") IsNot Nothing Then
            '        Dim diff2 As String = (Convert.ToDateTime(Session(Session("TokenID") + "SubscriptionExpiryDate")) - Date.Today).TotalDays.ToString()
            '        RemainingDays = diff2
            '    Else
            '    End If
            '    If Session(Session("TokenID") + "UserID") = "" Then
            '        TrialSubscribedText.Visible = False
            '        PremiumPackageText.Visible = False
            '        BusinessPackageText.Visible = False
            '        PremiumPackageClick.Visible = False
            '        BusinessPackageClick.Visible = False
            '        packageInstructionsText.Visible = True
            '        packagePoliciesURL.Visible = False
            '    Else
            '        packageInstructionsText.Visible = False
            '        packagePoliciesURL.Visible = True
            '    End If
            '    If Session(Session("TokenID") + "PackageType") = "Trial" Then
            '        FreeTrialPackageClick.Visible = False
            '        TrialSubscribedText.Visible = True
            '        PremiumPackageText.Visible = False
            '        BusinessPackageText.Visible = False
            '        If RemainingDays <= 0 Then
            '            TrialSubscribedText.InnerText = "Expired"
            '        End If
            '    ElseIf Session(Session("TokenID") + "PackageType") = "Business" Then
            '        FreeTrialPackageClick.Visible = False
            '        TrialSubscribedText.Visible = True
            '        TrialSubscribedText.InnerText = "Not Available"
            '        BusinessPackageClick.Visible = False
            '        BusinessPackageText.Visible = True
            '        PremiumPackageText.Visible = False
            '        If RemainingDays <= 0 Then
            '            BusinessPackageText.InnerText = "Expired"
            '            BusinessPackageClick.InnerText = "Renew"
            '            BusinessPackageClick.Visible = True
            '        End If
            '    ElseIf Session(Session("TokenID") + "PackageType") = "Premium" Then
            '        FreeTrialPackageClick.Visible = False
            '        TrialSubscribedText.Visible = True
            '        TrialSubscribedText.InnerText = "Not Available"
            '        BusinessPackageText.Visible = False
            '        PremiumPackageClick.Visible = False
            '        PremiumPackageText.Visible = True
            '        If RemainingDays <= 0 Then
            '            PremiumPackageText.InnerText = "Expired"
            '            PremiumPackageClick.Visible = True
            '            PremiumPackageClick.InnerText = "Renew"
            '        End If
            '    End If
        End If
        'con.Close()
    End Sub

    ''Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
    ''    Dim AES As New System.Security.Cryptography.RijndaelManaged
    ''    Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
    ''    Dim encrypted As String = ""
    ''    Try
    ''        Dim hash(31) As Byte
    ''        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
    ''        Array.Copy(temp, 0, hash, 0, 16)
    ''        Array.Copy(temp, 0, hash, 15, 16)
    ''        AES.Key = hash
    ''        AES.Mode = Security.Cryptography.CipherMode.ECB
    ''        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
    ''        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
    ''        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    ''        Return encrypted
    ''    Catch ex As Exception
    ''    End Try
    ''End Function

    ''Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
    ''    Dim AES As New System.Security.Cryptography.RijndaelManaged
    ''    Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
    ''    Dim decrypted As String = ""
    ''    Try
    ''        Dim hash(31) As Byte
    ''        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
    ''        Array.Copy(temp, 0, hash, 0, 16)
    ''        Array.Copy(temp, 0, hash, 15, 16)
    ''        AES.Key = hash
    ''        AES.Mode = Security.Cryptography.CipherMode.ECB
    ''        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
    ''        Dim Buffer As Byte() = Convert.FromBase64String(input)
    ''        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
    ''        Return decrypted
    ''    Catch ex As Exception
    ''    End Try
    ''End Function

    'Private Sub FreeTrialPackageClick_ServerClick(sender As Object, e As EventArgs) Handles FreeTrialPackageClick.ServerClick
    '    If Session(Session("TokenID") + "UserID") = "" Then
    '        Session(Session("TokenID") + "SubscriptionExpiryDateEntry") = (Date.Today).AddDays(3)
    '        Session(Session("TokenID") + "PackageTypeEntry") = "Trial"
    '        Response.Redirect("/UserRegistration.aspx")
    '    Else

    '    End If
    'End Sub

    'Private Sub FetchPackagePaymentDetails(PackageType As String, PayableAmount As String, SendableEmails As String, StartingDate As String, ExpiryDate As String)
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        PackageTypeText.InnerText = PackageType
    '        PayableAmountText.InnerText = "$" + PayableAmount
    '        SendableEmailsText.InnerText = SendableEmails
    '        StartingDateText.InnerText = StartingDate
    '        ExpiryDateText.InnerText = ExpiryDate
    '        con.Close()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Private Sub BusinessPackageClick_ServerClick(sender As Object, e As EventArgs) Handles BusinessPackageClick.ServerClick
    '    Session(Session("TokenID") + "PackageTypeUpdate") = "Business"
    '    Session(Session("TokenID") + "AvailableEmailsUpdate") = "500"
    '    Session(Session("TokenID") + "RemainingSendableEmailsUpdate") = "15000"
    '    Session(Session("TokenID") + "SendableEmailsText") = "15,000 Emails"
    '    Session(Session("TokenID") + "subscriptionType") = "Business"
    '    Session(Session("TokenID") + "subscriptionPrice") = "59"
    '    Session(Session("TokenID") + "NoOfMonths") = 1
    '    Session(Session("TokenID") + "DiscountAvailed") = "0"
    '    Session(Session("TokenID") + "TotalSendableEmails") = "15000"
    '    Session(Session("TokenID") + "SubscriptionDurationType") = "Monthly"
    '    subscriptionType.Text = Session(Session("TokenID") + "subscriptionType")
    '    subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '    RadioButtonList1.Items(0).Text = "Monthly ($59)"
    '    RadioButtonList1.Items(1).Text = "Annually ($637)"

    '    FetchPackagePaymentDetails(Session(Session("TokenID") + "PackageTypeUpdate"), Session(Session("TokenID") + "subscriptionPrice"), Session(Session("TokenID") + "SendableEmailsText"), Date.Today, Date.Today.AddMonths(Session(Session("TokenID") + "NoOfMonths")))
    '    ScriptManager.RegisterStartupScript(Page, [GetType](), "Pop", "openModal();", True)
    'End Sub

    'Private Sub PremiumPackageClick_ServerClick(sender As Object, e As EventArgs) Handles PremiumPackageClick.ServerClick
    '    If Session(Session("TokenID") + "UserID") = "" Then
    '        Response.Redirect("/UserRegistration.aspx")
    '    Else
    '        Session(Session("TokenID") + "PackageTypeUpdate") = "Premium"
    '        Session(Session("TokenID") + "AvailableEmailsUpdate") = "999999"
    '        Session(Session("TokenID") + "RemainingSendableEmailsUpdate") = "999999"
    '        Session(Session("TokenID") + "SendableEmailsText") = "Unlimited Emails"
    '        Session(Session("TokenID") + "subscriptionType") = "Premium"
    '        Session(Session("TokenID") + "subscriptionPrice") = "99"
    '        Session(Session("TokenID") + "NoOfMonths") = 1
    '        Session(Session("TokenID") + "DiscountAvailed") = "0"
    '        Session(Session("TokenID") + "TotalSendableEmails") = "999999"
    '        Session(Session("TokenID") + "SubscriptionDurationType") = "Monthly"
    '        subscriptionType.Text = Session(Session("TokenID") + "subscriptionType")
    '        subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '        RadioButtonList1.Items(0).Text = "Monthly ($99)"
    '        RadioButtonList1.Items(1).Text = "Annually ($1010)"
    '        FetchPackagePaymentDetails(Session(Session("TokenID") + "PackageTypeUpdate"), Session(Session("TokenID") + "subscriptionPrice"), Session(Session("TokenID") + "SendableEmailsText"), Date.Today, Date.Today.AddMonths(Session(Session("TokenID") + "NoOfMonths")))
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "Pop", "openModal();", True)
    '    End If
    'End Sub

    'Protected Sub UserSubscription_Update()
    '    Try
    '        If con.State = False Then
    '            con.Open()
    '        End If
    '        cmd.Parameters.Clear()
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = "UserSubscription_Update"

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@PackageType"
    '        p.Value = Session(Session("TokenID") + "PackageTypeUpdate")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@AvailableEmails"
    '        p.Value = Session(Session("TokenID") + "AvailableEmailsUpdate")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@RemainingSendableEmails"
    '        p.Value = Session(Session("TokenID") + "RemainingSendableEmailsUpdate")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@NoOfMonths"
    '        p.Value = Session(Session("TokenID") + "NoOfMonths")
    '        cmd.Parameters.Add(p)

    '        cmd.ExecuteNonQuery()
    '        con.Close()
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub load_author_id()

    '    If con.State = False Then
    '        con.Open()
    '    End If

    '    cmd.Parameters.Clear()
    '    cmd.CommandText = "select_user_id_by_email"
    '    cmd.CommandType = CommandType.StoredProcedure

    '    p = New SqlParameter
    '    p.ParameterName = "@EmailAddress"
    '    p.Value = Session(Session("TokenID") + "EmailAddress")
    '    cmd.Parameters.Add(p)
    '    Dim dset As New DataSet
    '    Dim dpt As New SqlDataAdapter
    '    dpt.SelectCommand = cmd
    '    dpt.Fill(dset, "UM_USerID")
    '    Session(Session("TokenID") + "UserID") = dset.Tables("UM_USerID").Rows(0)("UserID").ToString
    '    Session(Session("TokenID") + "EmailAddress") = dset.Tables("UM_USerID").Rows(0)("EmailAddress").ToString
    '    Session(Session("TokenID") + "UserName") = dset.Tables("UM_USerID").Rows(0)("Name").ToString
    '    Session(Session("TokenID") + "PackageType") = dset.Tables("UM_USerID").Rows(0)("PackageType").ToString
    '    Session(Session("TokenID") + "SubscriptionDate") = dset.Tables("UM_USerID").Rows(0)("SubscriptionDate").ToString
    '    Session(Session("TokenID") + "PackageStatus") = dset.Tables("UM_USerID").Rows(0)("PackageStatus").ToString
    '    Session(Session("TokenID") + "SubscriptionExpiryDate") = dset.Tables("UM_USerID").Rows(0)("SubscriptionExpiryDate").ToString
    '    con.Close()
    'End Sub

    'Protected Sub save_cookie()
    '    If con.State = False Then
    '        con.Open()
    '    End If
    '    Dim UID As HttpCookie = New HttpCookie("UID")
    '    UID.Values.Add("UID", Session(Session("TokenID") + "UserID"))
    '    UID.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(UID)
    '    Dim USN As HttpCookie = New HttpCookie("USN")
    '    USN.Values.Add("USN", Session(Session("TokenID") + "UserName"))
    '    USN.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(USN)
    '    Dim PkT As HttpCookie = New HttpCookie("PkT")
    '    PkT.Values.Add("PkT", Session(Session("TokenID") + "PackageType"))
    '    PkT.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(PkT)
    '    Dim SBD As HttpCookie = New HttpCookie("SBD")
    '    SBD.Values.Add("SBD", Session(Session("TokenID") + "SubscriptionDate"))
    '    SBD.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(SBD)
    '    Dim PkS As HttpCookie = New HttpCookie("PkS")
    '    PkS.Values.Add("PkS", Session(Session("TokenID") + "PackageStatus"))
    '    PkS.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(PkS)
    '    Dim SBE As HttpCookie = New HttpCookie("SBE")
    '    SBE.Values.Add("SBE", Session(Session("TokenID") + "SubscriptionExpiryDate"))
    '    SBE.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(SBE)
    '    Dim EAD As HttpCookie = New HttpCookie("EAD")
    '    EAD.Values.Add("EAD", Session(Session("TokenID") + "EmailAddress"))
    '    EAD.Expires = DateTime.Now.AddDays(15)
    '    Response.Cookies.Add(EAD)
    '    con.Close()
    'End Sub

    'Protected Sub PaymentStatus_TextChanged(sender As Object, e As EventArgs)
    '    'ScriptManager.RegisterStartupScript(Page, [GetType](), "showDiv", "showDiv();", True)
    '    If PaymentStatus.Text = "Success" Then
    '        mail_send()
    '        ProductSale_Insert()
    '        UserSubscription_Update()
    '        load_author_id()
    '        save_cookie()
    '        'Response.Redirect("/Bulk-Email-Services-Page.aspx#Packages")
    '        ScriptManager.RegisterStartupScript(Page, [GetType](), "script", "SubExpiry('Success! &#9989;', 'Your package has been upgraded and renewed to " + Session(Session("TokenID") + "PackageTypeUpdate").ToString() + " Package successfully.');", True)
    '    Else
    '    End If
    'End Sub

    'Protected Sub mail_send()
    '    Try
    '        Using mm As New MailMessage(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), Session(Session("TokenID") + "EmailAddress"))
    '            mm.From = New MailAddress(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), "Ebox Marketing Solutions")
    '            mm.Subject = "Ebox Subscription Successfully Purchased"
    '            Dim body As String = "<br/><b>Dear " + Session(Session("TokenID") + "UserName") + ",</b>"
    '            body += "<br /><br /> Thank you for purchasing and renewing you mass email marketing subscription on Ebox Marketing Solutons."
    '            body += "<br />To learn more efficient ways of e-mailing in bulk to your potential clients, read the FAQ section: <a href = '" + ("https://www.eboxmarketing.com/#FAQ") + "'> Improve your emails for a better end result.</a>"
    '            body += "<br /><h4>Your purchase details are as followed,</h4>"
    '            body += "<b style='margin-bottom:7px;display:inline-flex;color: #098601;font-size:14px;'>Package Type: </b> " + Session(Session("TokenID") + "PackageTypeUpdate") + " Package."
    '            body += "<br/><b style='margin-bottom:7px;display:inline-flex;color: #098601;font-size:14px;'>Paid Amount: </b> " + "$" + Session(Session("TokenID") + "subscriptionPrice") + "."
    '            body += "<br/><b style='margin-bottom:7px;display:inline-flex;color: #098601;font-size:14px;'>Sendable Emails: </b> " + Session(Session("TokenID") + "SendableEmailsText") + "."
    '            body += "<br/><b style='margin-bottom:7px;display:inline-flex;color: #098601;font-size:14px;'>Subscription Date: </b> " + Date.Today + "."
    '            body += "<br/><b style='margin-bottom:7px;display:inline-flex;color: #098601;font-size:14px;'>Subscription Expiry Date: </b> " + Date.Today.AddMonths(Session(Session("TokenID") + "NoOfMonths")) + "."
    '            body += "<br /><br /><b>Kind Regards,</b>"
    '            body += "<br />Ebox Marketing Solutions<br /><br />"
    '            body += "<img src='https://www.eboxmarketing.com/img/EBoxMarketingLogo.png' height='60px' alt='Image-Profile' border='0'>"
    '            mm.Body = body
    '            mm.IsBodyHtml = True
    '            Dim smtp As New SmtpClient()
    '            smtp.Host = "smtp.gmail.com"
    '            smtp.EnableSsl = True
    '            Dim NetworkCred As New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("SmtpUser"), System.Configuration.ConfigurationManager.AppSettings("SmtpPassword"))
    '            smtp.UseDefaultCredentials = True
    '            smtp.Credentials = NetworkCred
    '            smtp.Port = 587
    '            smtp.Send(mm)
    '        End Using
    '        'Open this link and allow less secure devices to send the mails and authenticate
    '        'https://www.google.com/settings/security/lesssecureapps 
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    'ScriptManager.RegisterStartupScript(Page, [GetType](), "Pop1", "closeModal();", True)
    '    'ScriptManager.RegisterStartupScript(Page, [GetType](), "Pop", "openModal();", True)
    '    If Session(Session("TokenID") + "subscriptionType") = "Premium" Then
    '        If RadioButtonList1.SelectedValue = "0" Then
    '            Session(Session("TokenID") + "NoOfMonths") = 1
    '            Session(Session("TokenID") + "subscriptionPrice") = "99"
    '            subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '            Session(Session("TokenID") + "TotalSendableEmails") = "999999"
    '            Session(Session("TokenID") + "SubscriptionDurationType") = "Monthly"
    '            Session(Session("TokenID") + "DiscountAvailed") = "0"
    '        ElseIf RadioButtonList1.SelectedValue = "1" Then
    '            Session(Session("TokenID") + "NoOfMonths") = 12
    '            Session(Session("TokenID") + "subscriptionPrice") = "1010"
    '            Session(Session("TokenID") + "DiscountAvailed") = "15"
    '            subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '            Session(Session("TokenID") + "TotalSendableEmails") = "999999"
    '            Session(Session("TokenID") + "SubscriptionDurationType") = "Annually"
    '        End If
    '    ElseIf Session(Session("TokenID") + "subscriptionType") = "Business" Then
    '        If RadioButtonList1.SelectedValue = "0" Then
    '            Session(Session("TokenID") + "NoOfMonths") = 1
    '            Session(Session("TokenID") + "subscriptionPrice") = "59"
    '            subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '            Session(Session("TokenID") + "SendableEmailsText") = "15,000 Emails"
    '            Session(Session("TokenID") + "TotalSendableEmails") = "15000"
    '            Session(Session("TokenID") + "SubscriptionDurationType") = "Monthly"
    '            Session(Session("TokenID") + "DiscountAvailed") = "0"
    '        ElseIf RadioButtonList1.SelectedValue = "1" Then
    '            Session(Session("TokenID") + "NoOfMonths") = 12
    '            Session(Session("TokenID") + "subscriptionPrice") = "637"
    '            Session(Session("TokenID") + "DiscountAvailed") = "10"
    '            subscriptionPrice.Text = Session(Session("TokenID") + "subscriptionPrice")
    '            Session(Session("TokenID") + "SendableEmailsText") = "15,000 * 12 (180,000) Emails"
    '            Session(Session("TokenID") + "TotalSendableEmails") = "180000"
    '            Session(Session("TokenID") + "SubscriptionDurationType") = "Annually"
    '        End If
    '    End If
    '    FetchPackagePaymentDetails(Session(Session("TokenID") + "PackageTypeUpdate"), Session(Session("TokenID") + "subscriptionPrice"), Session(Session("TokenID") + "SendableEmailsText"), Date.Today, Date.Today.AddMonths(Session(Session("TokenID") + "NoOfMonths")))
    'End Sub

    'Protected Sub ProductSale_Insert()
    '    If con.State = False Then
    '        con.Open()
    '    End If
    '    Try
    '        cmd.Parameters.Clear()
    '        cmd.CommandText = "ProductSale_Insert"
    '        cmd.CommandType = CommandType.StoredProcedure

    '        p = New SqlParameter
    '        p.ParameterName = "@UserID"
    '        p.Value = Session(Session("TokenID") + "UserID")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@User_EmailAddress"
    '        p.Value = Session(Session("TokenID") + "EmailAddress")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Product_Name"
    '        p.Value = Session(Session("TokenID") + "subscriptionType")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Subscription_Type"
    '        p.Value = Session(Session("TokenID") + "SubscriptionDurationType")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Charges_Paid"
    '        p.Value = "$" + Session(Session("TokenID") + "subscriptionPrice")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Total_SendableEmails"
    '        p.Value = Session(Session("TokenID") + "TotalSendableEmails")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Discount_Availed"
    '        p.Value = Session(Session("TokenID") + "DiscountAvailed")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Subscription_Duration"
    '        p.Value = Session(Session("TokenID") + "NoOfMonths")
    '        cmd.Parameters.Add(p)

    '        p = New SqlParameter
    '        p.ParameterName = "@Duration_Type"
    '        p.Value = "Months"
    '        cmd.Parameters.Add(p)

    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try

    '    con.Close()
    'End Sub
End Class
