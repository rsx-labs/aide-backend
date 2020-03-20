Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class ReportsSet
    Implements IReportsSet, INotifyPropertyChanged


    Private cReports As clsReports
    Private cReportsFactory As clsReportsFactory

    Public Sub New()
        cReports = New clsReports()
        cReportsFactory = New clsReportsFactory()
    End Sub
    Public Sub New(ByVal objReports As clsReports)
        cReports = objReports
        cReportsFactory = New clsReportsFactory()
    End Sub

    Public Property DESCRIPTION As String Implements IReportsSet.DESCRIPTION
        Get
            Return Me.cReports.DESCRIPTION
        End Get
        Set(value As String)
            Me.cReports.DESCRIPTION = value
        End Set
    End Property

    Public Property FILE_PATH As String Implements IReportsSet.FILE_PATH
        Get
            Return Me.cReports.FILE_PATH
        End Get
        Set(value As String)
            Me.cReports.FILE_PATH = value
        End Set
    End Property

    Public Property MODULE_ID As Integer Implements IReportsSet.MODULE_ID
        Get
            Return Me.cReports.MODULE_ID
        End Get
        Set(value As Integer)
            Me.cReports.MODULE_ID = value
        End Set
    End Property

    Public Property OPT_ID As Integer Implements IReportsSet.OPT_ID
        Get
            Return Me.cReports.OPT_ID
        End Get
        Set(value As Integer)
            Me.cReports.OPT_ID = value
        End Set
    End Property

    Public Property REPORT_ID As Integer Implements IReportsSet.REPORT_ID
        Get
            Return Me.cReports.REPORT_ID
        End Get
        Set(value As Integer)
            Me.cReports.REPORT_ID = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetAllReports() As List(Of ReportsSet) Implements IReportsSet.GetAllReports
        Try
            Dim cList As List(Of clsReports)
            Dim cListSet As New List(Of ReportsSet)

            cList = cReportsFactory.GetAllReports()

            If Not IsNothing(cList) Then
                For Each objClsReports As clsReports In cList
                    cListSet.Add(New ReportsSet(objClsReports))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function


End Class
