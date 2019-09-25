Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class KPITargetsSet
    Implements IKPITargetsSet, INotifyPropertyChanged

    Private _kpiTargets As ClsKPITargets
    Private _kpiTargetsFactory As ClsKPITargetsFactory

    Public Sub New()
        _kpiTargets = New ClsKPITargets()
        _kpiTargetsFactory = New ClsKPITargetsFactory()
    End Sub

    Public Sub New(ByVal objKPITargets As ClsKPITargets)
        _kpiTargets = objKPITargets
        _kpiTargetsFactory = New ClsKPITargetsFactory()
    End Sub

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property Id As Integer Implements IKPITargetsSet.Id
        Get
            Return _kpiTargets.ID
        End Get
        Set(value As Integer)
            _kpiTargets.ID = value
        End Set
    End Property

    Public Property EmpId As Integer Implements IKPITargetsSet.Emp_Id
        Get
            Return _kpiTargets.EMP_ID
        End Get
        Set(value As Integer)
            _kpiTargets.EMP_ID = value
        End Set
    End Property

    Public Property FYStart As Date Implements IKPITargetsSet.FYStart
        Get
            Return _kpiTargets.FY_START
        End Get
        Set(value As Date)
            _kpiTargets.FY_START = value
        End Set
    End Property

    Public Property FYEnd As Date Implements IKPITargetsSet.FYEnd
        Get
            Return _kpiTargets.FY_END
        End Get
        Set(value As Date)
            _kpiTargets.FY_END = value
        End Set
    End Property
    Public Property KPIReferenceNo As String Implements IKPITargetsSet.KPIReferenceNo
        Get
            Return _kpiTargets.KPI_REF
        End Get
        Set(value As String)
            _kpiTargets.KPI_REF = value
        End Set
    End Property

    Public Property Description As String Implements IKPITargetsSet.Description
        Get
            Return _kpiTargets.DESCRIPTION
        End Get
        Set(value As String)
            _kpiTargets.DESCRIPTION = value
        End Set
    End Property

    Public Property Subject As String Implements IKPITargetsSet.Subject
        Get
            Return _kpiTargets.SUBJECT
        End Get
        Set(value As String)
            _kpiTargets.SUBJECT = value
        End Set
    End Property

    Public Property CreateDate As Date Implements IKPITargetsSet.CreateDate
        Get
            Return _kpiTargets.DATE_CREATED
        End Get
        Set(value As Date)
            _kpiTargets.DATE_CREATED = value
        End Set
    End Property

    Public Function GetKPITargetById(Id As Integer) As List(Of IKPITargetsSet) Implements IKPITargetsSet.GetKPITargetById
        Try
            Dim lstKPITargets = New List(Of ClsKPITargets)
            Dim lstKPITargetsSet = New List(Of IKPITargetsSet)

            lstKPITargets = _kpiTargetsFactory.GetKPITargetsById(Id)
            If Not lstKPITargets Is Nothing Then
                For Each item In lstKPITargets
                    lstKPITargetsSet.Add(New KPITargetsSet(item))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstKPITargetsSet
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
    Public Function GetKPITargetByFiscalYear(EmpId As Integer, FYear As Date) As List(Of IKPITargetsSet) Implements IKPITargetsSet.GetKPITargetByFiscalYear
        Try
            Dim key As ClsKPITargetsKeys = New ClsKPITargetsKeys(1, EmpId, FYear)
            Dim lstKPITargets = New List(Of ClsKPITargets)
            Dim lstKPITargetsSet = New List(Of IKPITargetsSet)

            lstKPITargets = _kpiTargetsFactory.GetKPITargetsByFiscalYear(key)
            If Not lstKPITargets Is Nothing Then
                For Each item In lstKPITargets
                    lstKPITargetsSet.Add(New KPITargetsSet(item))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstKPITargetsSet
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

    Public Function InsertKPITargets() As Boolean Implements IKPITargetsSet.InsertKPITargets
        Try
            Return _kpiTargetsFactory.InsertKPITargets(_kpiTargets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert KPITargets Failed!")
            End If
        End Try
    End Function

    Public Function UpdateKPITargets() As Boolean Implements IKPITargetsSet.UpdateKPITargets
        Try
            Return _kpiTargetsFactory.UpdateKPITargets(_kpiTargets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update KPITargets Failed!")
            End If
        End Try
    End Function
End Class
