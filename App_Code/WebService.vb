Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services

<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class WebService
    Inherits System.Web.Services.WebService
    Public con As New SqlConnection
    Public cmd As New SqlCommand
    Public Shared dt As New DataTable
    Dim p As New SqlParameter
    Dim c As String = ConfigurationManager.ConnectionStrings("con1").ConnectionString

    <WebMethod(EnableSession:=True)>
    Public Function TotalEmailsGraph() As String
        Try
            con.ConnectionString = c
            cmd.Connection = con
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

            Dim p1 As New SqlParameter
            p1.ParameterName = "@FilterTypeFrom"
            p1.Value = Session(Session("TokenID") + "DateFrom")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@FilterTypeTo"
            p2.Value = Session(Session("TokenID") + "DateTo")
            cmd.Parameters.Add(p2)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "Table")

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In DS.Tables("Table7").Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In DS.Tables("Table7").Columns
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                Next
                rows.Add(row)
            Next
            con.Close()
            Return serializer.Serialize(rows)
        Catch ex As Exception
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function TotalUnreadEmailsGraph() As String
        Try
            con.ConnectionString = c
            cmd.Connection = con
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

            Dim p1 As New SqlParameter
            p1.ParameterName = "@FilterTypeFrom"
            p1.Value = Session(Session("TokenID") + "DateFrom")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@FilterTypeTo"
            p2.Value = Session(Session("TokenID") + "DateTo")
            cmd.Parameters.Add(p2)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "Table")

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In DS.Tables("Table8").Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In DS.Tables("Table8").Columns
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                Next
                rows.Add(row)
            Next
            con.Close()
            Return serializer.Serialize(rows)
        Catch ex As Exception
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function TotalReadEmailsGraph() As String
        Try
            con.ConnectionString = c
            cmd.Connection = con
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

            Dim p1 As New SqlParameter
            p1.ParameterName = "@FilterTypeFrom"
            p1.Value = Session(Session("TokenID") + "DateFrom")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@FilterTypeTo"
            p2.Value = Session(Session("TokenID") + "DateTo")
            cmd.Parameters.Add(p2)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "Table")

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In DS.Tables("Table9").Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In DS.Tables("Table9").Columns
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                Next
                rows.Add(row)
            Next
            con.Close()
            Return serializer.Serialize(rows)
        Catch ex As Exception
        End Try
    End Function

    <WebMethod(EnableSession:=True)>
    Public Function OverviewOfEmailsGraph() As String
        Try
            con.ConnectionString = c
            cmd.Connection = con
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

            Dim p1 As New SqlParameter
            p1.ParameterName = "@FilterTypeFrom"
            p1.Value = Session(Session("TokenID") + "DateFrom")
            cmd.Parameters.Add(p1)

            Dim p2 As New SqlParameter
            p2.ParameterName = "@FilterTypeTo"
            p2.Value = Session(Session("TokenID") + "DateTo")
            cmd.Parameters.Add(p2)

            Dim DS As New DataSet
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(DS, "Table")

            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In DS.Tables("Table10").Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In DS.Tables("Table10").Columns
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                Next
                rows.Add(row)
            Next
            con.Close()
            Return serializer.Serialize(rows)
        Catch ex As Exception
        End Try
    End Function

End Class