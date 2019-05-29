Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer

''' <summary>
''' By John Harvey Sanchez / Marivic Espino 
''' </summary>
Public Class LessonLearntSet
    Implements ILessonLearnt, INotifyPropertyChanged

    Private cLessonLearnt As clsLessonLearnt
    Private cLessonLearntFactory As clsLessonLearntFactory

    Public Sub New()
        cLessonLearnt = New clsLessonLearnt()
        cLessonLearntFactory = New clsLessonLearntFactory
    End Sub

    Public Sub New(ByVal cList As clsLessonLearnt)
        cLessonLearnt = cList
        cLessonLearntFactory = New clsLessonLearntFactory
    End Sub

    Public Property ReferenceNo As String Implements ILessonLearnt.ReferenceNo
        Get
            Return Me.cLessonLearnt.REF_NO
        End Get
        Set(value As String)
            Me.cLessonLearnt.REF_NO = value
        End Set
    End Property

    Public Property EmployeeID As Integer Implements ILessonLearnt.EmployeeID
        Get
            Return Me.cLessonLearnt.EMP_ID
        End Get
        Set(value As Integer)
            Me.cLessonLearnt.EMP_ID = value
        End Set
    End Property

    Public Property Nickname As String Implements ILessonLearnt.Nickname
        Get
            Return Me.cLessonLearnt.NICK_NAME
        End Get
        Set(value As String)
            Me.cLessonLearnt.NICK_NAME = value
        End Set
    End Property

    Public Property Problem As String Implements ILessonLearnt.Problem
        Get
            Return Me.cLessonLearnt.PROBLEM
        End Get
        Set(value As String)
            Me.cLessonLearnt.PROBLEM = value
        End Set
    End Property

    Public Property Resolution As String Implements ILessonLearnt.Resolution
        Get
            Return Me.cLessonLearnt.RESOLUTION
        End Get
        Set(value As String)
            Me.cLessonLearnt.RESOLUTION = value
        End Set
    End Property

    Public Property ActionNo As String Implements ILessonLearnt.ActionNo
        Get
            Return Me.cLessonLearnt.ACTION_NO
        End Get
        Set(value As String)
            Me.cLessonLearnt.ACTION_NO = value
        End Set
    End Property

    Public Function InsertNewLessonLearnt(lessonLearnt As LessonLearntSet) As Boolean Implements ILessonLearnt.InsertNewLessonLearnt
        Try
            Return Me.cLessonLearntFactory.Insert(cLessonLearnt)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Lesson Learnt Failed!")
            End If
        End Try
    End Function

    Public Function UpdateLessonLearnt(lessonLearnt As LessonLearntSet) As Boolean Implements ILessonLearnt.UpdateLessonLearnt
        Try
            Return Me.cLessonLearntFactory.Update(cLessonLearnt)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    Public Function GetAllLessonLearnts(email As String) As List(Of LessonLearntSet) Implements ILessonLearnt.GetAllLessonLearnts
        Try
            Dim lstLessonLearnt As List(Of clsLessonLearnt)
            Dim lstLessonLearntSet As New List(Of LessonLearntSet)

            lstLessonLearnt = cLessonLearntFactory.GetAll(email)

            If Not IsNothing(lstLessonLearnt) Then
                For Each cList As clsLessonLearnt In lstLessonLearnt
                    lstLessonLearntSet.Add(New LessonLearntSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstLessonLearntSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetLessonLearntsByProblem(searchProblem As String, email As String) As List(Of LessonLearntSet) Implements ILessonLearnt.GetLessonLearntsByProblem
        Try
            Dim lstLessonLearnt As List(Of clsLessonLearnt)
            Dim lstLessonLearntSet As New List(Of LessonLearntSet)
            Dim keys As clsLessonLearntKeys = New clsLessonLearntKeys(searchProblem)

            lstLessonLearnt = cLessonLearntFactory.GetByProblem(keys, email)

            If Not IsNothing(lstLessonLearnt) Then
                For Each cList As clsLessonLearnt In lstLessonLearnt
                    lstLessonLearntSet.Add(New LessonLearntSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstLessonLearntSet

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
