Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class UserDashboard

    Inherits System.Web.UI.Page
    Dim cmd As New SqlCommand
    Dim con As New SqlConnection
    Dim p As New SqlParameter

    Private Sub form_Load(sender As Object, e As EventArgs) Handles form.Load

        Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString
        con.ConnectionString = c
        cmd.Connection = con
        If con.State = False Then
            con.Open()
        End If
        ToDateDatePicker.Attributes("onchange") = "SubmitDates(this)"
        FromDateDatePicker.Attributes("onchange") = "SubmitDates2(this)"
        If Not IsPostBack Then
            'If Session(Session("TokenID") + "PackageType") <> "Trial" And Session(Session("TokenID") + "UserID") <> "" Then
            '    FilterList.SelectedValue = "6"
            '    CurrentFilter.InnerHtml = "All Time Stats"
            '    DatePickerBody.Visible = "false"
            '    DashboardContentSearch()
            'Else
            'End If
            FilterList.SelectedValue = "6"
            CurrentFilter.InnerHtml = "All Time Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        End If
        con.Close()
    End Sub
    Protected Sub DashboardContentSearch()
        Try
            If con.State = False Then
                con.Open()
            End If
            cmd.Parameters.Clear()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "Dashboard_Content_Search"

            p = New SqlParameter
            p.ParameterName = "@UserID"
            p.Value = Session(Session("TokenID") + "UserID")
            cmd.Parameters.Add(p)

            If FilterList.SelectedValue = "0" Then
                FromDateDatePicker.Value = Date.Today
                ToDateDatePicker.Value = Date.Today
            ElseIf FilterList.SelectedValue = "1" Then
                FromDateDatePicker.Value = Date.Today.AddDays(-1)
                ToDateDatePicker.Value = Date.Today.AddDays(-1)
            ElseIf FilterList.SelectedValue = "2" Then
                FromDateDatePicker.Value = Date.Today.AddDays(-7)
                ToDateDatePicker.Value = Date.Today
            ElseIf FilterList.SelectedValue = "3" Then
                FromDateDatePicker.Value = Date.Now.AddDays(-30)
                ToDateDatePicker.Value = Date.Today
            ElseIf FilterList.SelectedValue = "4" Then
                FromDateDatePicker.Value = Date.Now.AddDays(-183)
                ToDateDatePicker.Value = Date.Today
            ElseIf FilterList.SelectedValue = "6" Then
                FromDateDatePicker.Value = Date.Now.AddDays(-10000)
                ToDateDatePicker.Value = Date.Today
            ElseIf FilterList.SelectedValue = "5" Then
                If FromDateDatePicker.Value = "" Then
                    FromDateDatePicker.Value = Date.Today
                ElseIf ToDateDatePicker.Value = "" Then
                    ToDateDatePicker.Value = Date.Today
                End If
                Dim dateFrom As Date = FromDateDatePicker.Value
                Dim dateTo As Date = ToDateDatePicker.Value
                CurrentFilter.InnerHtml = "Stats From " + dateFrom.Date.ToString("dd/MMM/yyyy") + " " + "To " + dateTo.Date.ToString("dd/MMM/yyyy")
            End If

            Dim p1 As New SqlParameter
            p1.ParameterName = "@FilterTypeFrom"
            Session(Session("TokenID") + "DateFrom") = Convert.ToDateTime(FromDateDatePicker.Value)
            p1.Value = Convert.ToDateTime(FromDateDatePicker.Value)
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@FilterTypeTo"
            Session(Session("TokenID") + "DateTo") = Convert.ToDateTime(ToDateDatePicker.Value)
            p2.Value = Convert.ToDateTime(ToDateDatePicker.Value)
            cmd.Parameters.Add(p2)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "Table")
            TotalEmails.InnerHtml = DS.Tables("Table").Rows(0)("TotalEmails").ToString()
            TotalUnsentEmails.InnerHtml = DS.Tables("Table1").Rows(0)("TotalUnsentEmails").ToString()
            TotalSentEmails.InnerHtml = DS.Tables("Table2").Rows(0)("TotalSentEmails").ToString()
            TotalFollowedUpEmails.InnerHtml = DS.Tables("Table3").Rows(0)("TotalFollowedUpEmails").ToString()
            TotalOpenedEmails.InnerHtml = DS.Tables("Table4").Rows(0)("TotalOpenedEmails").ToString()
            TotalUnopenedEmails.InnerHtml = DS.Tables("Table5").Rows(0)("TotalUnopenedEmails").ToString()
            If DS.Tables("Table6").Rows.Count = 0 Then
                TopClient.InnerHtml = "None yet!"
            Else
                TopClient.InnerHtml = DS.Tables("Table6").Rows(0)("TopClient").ToString()
            End If
            con.Close()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub FilterList_SelectedIndexChanged(sender As Object, e As EventArgs)
        If FilterList.SelectedValue = "0" Then
            CurrentFilter.InnerHtml = "Today Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "1" Then
            CurrentFilter.InnerHtml = "Yesterday Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "2" Then
            CurrentFilter.InnerHtml = "Last Week Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "3" Then
            CurrentFilter.InnerHtml = "Last Month Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "4" Then
            CurrentFilter.InnerHtml = "Last 6 Months Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "6" Then
            CurrentFilter.InnerHtml = "All Time Stats"
            DatePickerBody.Visible = "false"
            DashboardContentSearch()
        ElseIf FilterList.SelectedValue = "5" Then
            Dim dateFrom As Date = FromDateDatePicker.Value
            Dim dateTo As Date = ToDateDatePicker.Value
            CurrentFilter.InnerHtml = "Stats From " + dateFrom.Date.ToString("dd/MMM/yyyy") + " " + "To " + dateTo.Date.ToString("dd/MMM/yyyy")
            DatePickerBody.Visible = "true"
        End If
    End Sub

    Protected Sub DateSubmitBtn_Click(sender As Object, e As EventArgs)
        DashboardContentSearch()
    End Sub

    Protected Sub DateSubmitBtn2_Click(sender As Object, e As EventArgs)
        DashboardContentSearch()
    End Sub

End Class
