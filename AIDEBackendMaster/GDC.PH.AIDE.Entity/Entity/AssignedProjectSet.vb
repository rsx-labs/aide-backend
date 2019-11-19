﻿Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
''' <summary>
''' ''' GIANN CALRO CAMILO/LEMUELA ABULENCIA
''' </summary>
''' <remarks></remarks>
Public Class AssignedProjectSet
    Implements IAssignedProjects, INotifyPropertyChanged

    Private cAProj As clsAssignedProjects
    Private cAProjFactory As clsAssignedProjectsFactory
    Public Sub New()
        cAProj = New clsAssignedProjects()
        cAProjFactory = New clsAssignedProjectsFactory()
    End Sub

    Public Sub New(ByVal objAssignedProj As clsAssignedProjects)
        cAProj = objAssignedProj
        cAProjFactory = New clsAssignedProjectsFactory()
    End Sub

    Public Property EmpId As Integer Implements IAssignedProjects.EmpId
        Get
            Return Me.cAProj.EMP_ID
        End Get
        Set(value As Integer)
            Me.cAProj.EMP_ID = value
        End Set
    End Property

    Public Property ProjectId As Integer Implements IAssignedProjects.ProjectId
        Get
            Return Me.cAProj.PROJ_ID
        End Get
        Set(value As Integer)
            Me.cAProj.PROJ_ID = value
        End Set
    End Property

    Public Property DateCreated As Date Implements IAssignedProjects.DateCreated
        Get
            Return Me.cAProj.DATE_CREATED
        End Get
        Set(value As Date)
            Me.cAProj.DATE_CREATED = value
        End Set
    End Property

    Public Property StartPeriod As Date Implements IAssignedProjects.StartPeriod
        Get
            Return Me.cAProj.START_PERIOD
        End Get
        Set(value As Date)
            Me.cAProj.START_PERIOD = value
        End Set
    End Property

    Public Property EndPeriod As Date Implements IAssignedProjects.EndPeriod
        Get
            Return Me.cAProj.END_PERIOD
        End Get
        Set(value As Date)
            Me.cAProj.END_PERIOD = value
        End Set
    End Property

    Public Function InsertAssignedProj() As Boolean Implements IAssignedProjects.InsertAssignedProj
        Try
            Return Me.cAProjFactory.Insert(cAProj)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function DeleteAssignedProj(ByVal EmpID As Integer, ByVal projectID As Integer) As Boolean Implements IAssignedProjects.DeleteAssignedProj
        Try
            Return Me.cAProjFactory.Delete(EmpID, projectID)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function DeleteAllAssignedProj(ByVal projectID As Integer) As Boolean Implements IAssignedProjects.DeleteAllAssignedProj
        Try
            Return Me.cAProjFactory.DeleteAll(projectID)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Public Function GetAssignedProjects(projectID As Integer) As List(Of AssignedProjectSet) Implements IAssignedProjects.GetAssignedProjects
        Try
            Dim lstAssignedProject As List(Of clsAssignedProjects)
            Dim lstAssignedProjectSet As New List(Of AssignedProjectSet)

            lstAssignedProject = cAProjFactory.GetAssignedProjects(projectID)


            If Not IsNothing(lstAssignedProject) Then
                For Each cList As clsAssignedProjects In lstAssignedProject
                    lstAssignedProjectSet.Add(New AssignedProjectSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstAssignedProjectSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
End Class
