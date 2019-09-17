Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class KPISummarySet
    Implements IKPISummarySet, INotifyPropertyChanged

    Private _kpiSummary As ClsKPISummary
    Private _kpiSummaryFactory As ClsKPISummaryFactory

    Public Sub New()
        _kpiSummary = New ClsKPISummary()
        _kpiSummaryFactory = New ClsKPISummaryFactory()
    End Sub

    Public Sub New(ByVal objKPISummary As ClsKPISummary)
        _kpiSummary = objKPISummary
        _kpiSummaryFactory = New ClsKPISummaryFactory()
    End Sub

    Public Property Id As Integer Implements IKPISummarySet.Id
        Get
            Return _kpiSummary.ID
        End Get
        Set(value As Integer)
            _kpiSummary.ID = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property FYStart As Date Implements IKPISummarySet.FYStart
        Get
            Return _kpiSummary.FY_START
        End Get
        Set(value As Date)
            _kpiSummary.FY_START = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property FYEnd As Date Implements IKPISummarySet.FYEnd
        Get
            Return _kpiSummary.FY_END
        End Get
        Set(value As Date)
            _kpiSummary.FY_END = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property KPIMonth As Short Implements IKPISummarySet.KPIMonth
        Get
            Return _kpiSummary.KPI_MONTH
        End Get
        Set(value As Short)
            _kpiSummary.KPI_MONTH = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property KPIReferenceNo As String Implements IKPISummarySet.KPIReferenceNo
        Get
            Return _kpiSummary.KPI_REF
        End Get
        Set(value As String)
            _kpiSummary.KPI_REF = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property Subject As String Implements IKPISummarySet.Subject
        Get
            Return _kpiSummary.SUBJECT
        End Get
        Set(value As String)
            _kpiSummary.SUBJECT = value
            NotifyPropertyChanged()
        End Set
    End Property


    Public Property Description As String Implements IKPISummarySet.Description
        Get
            Return _kpiSummary.DESCRIPTION
        End Get
        Set(value As String)
            _kpiSummary.DESCRIPTION = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property KPITarget As Double Implements IKPISummarySet.KPITarget
        Get
            Return _kpiSummary.KPI_TARGET
        End Get
        Set(value As Double)
            _kpiSummary.KPI_TARGET = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property KPIActual As Double Implements IKPISummarySet.KPIActual
        Get
            Return _kpiSummary.KPI_ACTUAL
        End Get
        Set(value As Double)
            _kpiSummary.KPI_ACTUAL = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property KPIOverall As Double Implements IKPISummarySet.KPIOverall
        Get
            Return _kpiSummary.KPI_OVERALL
        End Get
        Set(value As Double)
            _kpiSummary.KPI_OVERALL = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Property DatePosted As Date Implements IKPISummarySet.DatePosted
        Get
            Return _kpiSummary.DATE_POSTED
        End Get
        Set(value As Date)
            _kpiSummary.DATE_POSTED = value
            NotifyPropertyChanged()
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Function GetKPISummaryByMonth(FY_Start As Date, FY_End As Date, Month As Short) As List(Of IKPISummarySet) Implements IKPISummarySet.GetKPISummaryByMonth
        Try
            Dim keys As ClsKPISummaryKeys = New ClsKPISummaryKeys(FYStart, FY_End, Month)
            Dim lstKPISummarySet As New List(Of IKPISummarySet)
            Dim lstKPISummary As List(Of ClsKPISummary)

            lstKPISummary = _kpiSummaryFactory.GetKPISummaryByMonth(keys)
            If IsNothing(lstKPISummary) Then
                Throw New NoRecordFoundException("No records found")
            Else
                For Each summary As ClsKPISummary In lstKPISummary
                    lstKPISummarySet.Add(New KPISummarySet(summary))
                Next
            End If
            Return lstKPISummarySet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
    Public Function GetAllKPISummary(FY_Start As Date, FY_End As Date) As List(Of IKPISummarySet) Implements IKPISummarySet.GetAllKPISummary
        Try
            Dim keys As ClsKPISummaryKeys = New ClsKPISummaryKeys(FY_Start, FY_End, 1)
            Dim lstKPISummarySet As New List(Of IKPISummarySet)
            Dim lstKPISummary As List(Of ClsKPISummary)

            lstKPISummary = _kpiSummaryFactory.GetAllKPISummary(keys)
            If IsNothing(lstKPISummary) Then
                Throw New NoRecordFoundException("No records found")
            Else
                For Each summary As ClsKPISummary In lstKPISummary
                    lstKPISummarySet.Add(New KPISummarySet(summary))
                Next
            End If
            Return lstKPISummarySet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertKPISummary() As Boolean Implements IKPISummarySet.InsertKPISummary
        Try
            If _kpiSummaryFactory.Insert(_kpiSummary) Then
                Return True
            Else
                Throw New InsertFailedException("Insert KPI Summary Failed!")
            End If
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateKPISummary() As Boolean Implements IKPISummarySet.UpdateKPISummary
        Try
            If _kpiSummaryFactory.Update(_kpiSummary) Then
                Return True
            Else
                Throw New UpdateFailedException("Update KPI Summary Failed!")
            End If
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

End Class
