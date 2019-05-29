Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

''' <summary>
''' By Jester Sanchez/ Lemuela Abulencia
''' </summary>
''' <remarks></remarks>
Public Class ActionListSet
    Implements IActionLists, INotifyPropertyChanged



    Private cAction As clsActionLists
    Private cActionFactory As clsActionListsFactory
    Public Sub New()
        cAction = New clsActionLists()
        cActionFactory = New clsActionListsFactory()
    End Sub

    Public Sub New(ByVal objAction As clsActionLists)
        cAction = objAction
        cActionFactory = New clsActionListsFactory()
    End Sub

    Public Property ActionID As String Implements IActionLists.ActionID
        Get
            Return cAction.ACTREF
        End Get
        Set(value As String)
            cAction.ACTREF = value
        End Set
    End Property

    Public Property ActionMessage As String Implements IActionLists.ActionMessage
        Get
            Return cAction.ACT_MESSAGE
        End Get
        Set(value As String)
            cAction.ACT_MESSAGE = value
        End Set
    End Property

    Public Property ActionAssignee As Integer Implements IActionLists.ActionAssignee
        Get
            Return cAction.EMP_ID
        End Get
        Set(value As Integer)
            cAction.EMP_ID = value
        End Set
    End Property

    Public Property ActionNickName As String Implements IActionLists.ActionNickName
        Get
            Return cAction.NICK_NAME
        End Get
        Set(value As String)
            cAction.NICK_NAME = value
        End Set
    End Property


    Public Property ActionDueDate As Date Implements IActionLists.ActionDueDate
        Get
            Return cAction.DUE_DATE
        End Get
        Set(value As Date)
            cAction.DUE_DATE = value
        End Set
    End Property
    Public Property ActionDateClosed As String Implements IActionLists.ActionDateClosed
        Get
            Return cAction.DATE_CLOSED
        End Get
        Set(value As String)
            cAction.DATE_CLOSED = value
        End Set
    End Property


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub



    Public Function GetActionListByMessage(ByVal _ActionMessage As String, ByVal email As String) As List(Of ActionListSet) Implements IActionLists.GetActionListByMessage
        Try
            Dim key As clsActionListsKeys = New clsActionListsKeys(_ActionMessage)
            Dim objActionList As List(Of clsActionLists)
            Dim listActionList As New List(Of ActionListSet)
            objActionList = Me.cActionFactory.GetByPrimaryKey(key, email)
            If Not IsNothing(objActionList) Then
                For Each cAction As clsActionLists In objActionList
                    Dim newActionList As New ActionListSet(cAction)
                    listActionList.Add(newActionList)
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return listActionList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllActionList(ByVal email As String) As List(Of ActionListSet) Implements IActionLists.GetAllActionList
        Try
            Dim objActionList As List(Of clsActionLists)
            Dim lstActionList As New List(Of ActionListSet)
            objActionList = Me.cActionFactory.GetAll(email)
            If Not IsNothing(objActionList) Then
                For Each cAction As clsActionLists In objActionList
                    Dim newActionList As New ActionListSet(cAction)
                    lstActionList.Add(newActionList)
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If
            Return lstActionList
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function InsertActionList() As Boolean Implements IActionLists.InsertActionList
        Try
            Return Me.cActionFactory.Insert(cAction)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateActionList() As Boolean Implements IActionLists.UpdateActionList
        Try
            Return Me.cActionFactory.Update(cAction)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


End Class

