Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class ComcellSet

    Implements IComcellSet, INotifyPropertyChanged

    Private cComcell As clsComcell
    Private cComcellFactory As clsComcellFactory

    Public Sub New()
        cComcell = New clsComcell()
        cComcellFactory = New clsComcellFactory()
    End Sub

    Public Sub New(ByVal objComcell As clsComcell)
        cComcell = objComcell
        cComcellFactory = New clsComcellFactory()
    End Sub

    Public Property COMCELL_ID As Integer Implements IComcellSet.COMCELL_ID
        Get
            Return Me.cComcell.COMCELL_ID
        End Get
        Set(value As Integer)
            Me.cComcell.COMCELL_ID = value
        End Set
    End Property

    Public Property YEAR As Integer Implements IComcellSet.YEAR
        Get
            Return Me.cComcell.YEAR
        End Get
        Set(value As Integer)
            Me.cComcell.YEAR = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IComcellSet.EMP_ID
        Get
            Return Me.cComcell.EMP_ID
        End Get
        Set(value As Integer)
            Me.cComcell.EMP_ID = value
        End Set
    End Property

    Public Property MONTH As String Implements IComcellSet.MONTH
        Get
            Return Me.cComcell.MONTH
        End Get
        Set(value As String)
            Me.cComcell.MONTH = value
        End Set
    End Property

    Public Property MINUTES_TAKER As String Implements IComcellSet.MINUTES_TAKER
        Get
            Return Me.cComcell.MINUTES_TAKER
        End Get
        Set(value As String)
            Me.cComcell.MINUTES_TAKER = value
        End Set
    End Property

    Public Property FACILITATOR As String Implements IComcellSet.FACILITATOR
        Get
            Return Me.cComcell.FACILITATOR
        End Get
        Set(value As String)
            Me.cComcell.FACILITATOR = value
        End Set
    End Property

    Public Property SCHEDULE As String Implements IComcellSet.SCHEDULE
        Get
            Return Me.cComcell.SCHEDULE
        End Get
        Set(value As String)
            Me.cComcell.SCHEDULE = value
        End Set
    End Property

    Public Property FY_START As DateTime Implements IComcellSet.FY_START
        Get
            Return Me.cComcell.FY_START
        End Get
        Set(value As DateTime)
            Me.cComcell.FY_START = value
        End Set
    End Property

    Public Property FY_END As DateTime Implements IComcellSet.FY_END
        Get
            Return Me.cComcell.FY_END
        End Get
        Set(value As DateTime)
            Me.cComcell.FY_END = value
        End Set
    End Property

    Public Function GetComcellMeeting(empID As Integer, year As Integer) As List(Of ComcellSet) Implements IComcellSet.GetComcellMeeting
        Dim cList As List(Of clsComcell)
        Dim cListSet As New List(Of ComcellSet)
        Try

            cList = cComcellFactory.GetComcellMeeting(empID, year)

            If Not IsNothing(cList) Then
                For Each cComcell As clsComcell In cList
                    cListSet.Add(New ComcellSet(cComcell))
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

    Public Function InsertComcellMeeting(contacts As ComcellSet) As Boolean Implements IComcellSet.InsertComcellMeeting
        Try
            Return Me.cComcellFactory.InsertComcellMeeting(cComcell)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateComcellMeeting(contacts As ComcellSet) As Boolean Implements IComcellSet.UpdateComcellMeeting
        Try
            Return Me.cComcellFactory.UpdateComcellMeeting(cComcell)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
