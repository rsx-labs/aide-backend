Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class LateSet

    Implements ILateSet, INotifyPropertyChanged

    Private cLate As clsLate
    Private cLateFactory As clsLateFactory

    Public Sub New()
        cLate = New clsLate()
        cLateFactory = New clsLateFactory()
    End Sub

    Public Sub New(ByVal objLate As clsLate)
        cLate = objLate
        cLateFactory = New clsLateFactory()
    End Sub

    Public Property FIRST_NAME As String Implements ILateSet.FIRST_NAME
        Get
            Return Me.cLate.FIRST_NAME
        End Get
        Set(value As String)
            Me.cLate.FIRST_NAME = value
        End Set
    End Property

    Public Property STATUS As Integer Implements ILateSet.STATUS
        Get
            Return Me.cLate.STATUS
        End Get
        Set(value As Integer)
            Me.cLate.STATUS = value
        End Set
    End Property

    Public Property MONTH As String Implements ILateSet.MONTH
        Get
            Return Me.cLate.MONTH
        End Get
        Set(value As String)
            Me.cLate.MONTH = value
        End Set
    End Property

    Public Property NUMBER_OF_LATE As Integer Implements ILateSet.NUMBER_OF_LATE
        Get
            Return Me.cLate.NUMBER_OF_LATE
        End Get
        Set(value As Integer)
            Me.cLate.NUMBER_OF_LATE = value
        End Set
    End Property


    Public Function GetLate(empID As Integer, month As Integer, year As Integer, toDisplay As Integer) As List(Of LateSet) Implements ILateSet.GetLate
        Try
            Dim cList As List(Of clsLate)
            Dim cListSet As New List(Of LateSet)

            cList = cLateFactory.GetLate(empID, month, year, toDisplay)

            If Not IsNothing(cList) Then
                For Each cLate As clsLate In cList
                    cListSet.Add(New LateSet(cLate))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
