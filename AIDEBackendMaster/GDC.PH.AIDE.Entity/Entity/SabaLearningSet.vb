Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class SabaLearningSet
    Implements ISabaLearningSet, INotifyPropertyChanged




    Private cSabaLearning As clsSabaLearning
    Private cSabaLearningFactory As clsSabaLearningFactory

    Public Sub New()
        cSabaLearning = New clsSabaLearning()
        cSabaLearningFactory = New clsSabaLearningFactory()
    End Sub
    Public Sub New(ByVal objSabaLearning As clsSabaLearning)
        cSabaLearning = objSabaLearning
        cSabaLearningFactory = New clsSabaLearningFactory()
    End Sub

    Public Property EMP_ID As Integer Implements ISabaLearningSet.EMP_ID
        Get
            Return Me.cSabaLearning.EMP_ID
        End Get
        Set(value As Integer)
            Me.cSabaLearning.EMP_ID = value
        End Set
    End Property
    Public Property END_DATE As Date Implements ISabaLearningSet.END_DATE
        Get
            Return Me.cSabaLearning.END_DATE
        End Get
        Set(value As Date)
            Me.cSabaLearning.END_DATE = value
        End Set
    End Property

    Public Function GetAllSabaCourses(empID As Integer) As List(Of SabaLearningSet) Implements ISabaLearningSet.GetAllSabaCourses
        Try
            Dim cList As List(Of clsSabaLearning)
            Dim cListSet As New List(Of SabaLearningSet)

            cList = cSabaLearningFactory.GetAll(empID)

            If Not IsNothing(cList) Then
                For Each objclsSabaLearning As clsSabaLearning In cList
                    cListSet.Add(New SabaLearningSet(objclsSabaLearning))
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

    Public Property SABA_ID As Integer Implements ISabaLearningSet.SABA_ID
        Get
            Return Me.cSabaLearning.SABA_ID
        End Get
        Set(value As Integer)
            Me.cSabaLearning.SABA_ID = value
        End Set
    End Property

    Public Property TITLE As String Implements ISabaLearningSet.TITLE
        Get
            Return Me.cSabaLearning.TITLE
        End Get
        Set(value As String)
            Me.cSabaLearning.TITLE = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property DATE_COMPLETED As String Implements ISabaLearningSet.DATE_COMPLETED
        Get
            Return Me.cSabaLearning.DATE_COMPLETED
        End Get
        Set(value As String)
            Me.cSabaLearning.DATE_COMPLETED = value
        End Set
    End Property

    Public Function GetAllSabaXref(empID As Integer, sabaID As Integer) As List(Of SabaLearningSet) Implements ISabaLearningSet.GetAllSabaXref
        Try
            Dim cList As List(Of clsSabaLearning)
            Dim cListSet As New List(Of SabaLearningSet)

            cList = cSabaLearningFactory.GetAllSabaXref(empID, sabaID)

            If Not IsNothing(cList) Then
                For Each objclsSabaLearning As clsSabaLearning In cList
                    cListSet.Add(New SabaLearningSet(objclsSabaLearning))
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

    Public Property IMAGE_PATH As String Implements ISabaLearningSet.IMAGE_PATH
        Get
            Return Me.cSabaLearning.IMAGE_PATH
        End Get
        Set(value As String)
            Me.cSabaLearning.IMAGE_PATH = value
        End Set
    End Property

    Public Function InsertSabaCourses() As Boolean Implements ISabaLearningSet.InsertSabaCourses
        Try
            Return Me.cSabaLearningFactory.Insert(cSabaLearning)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateSabaCourses() As Boolean Implements ISabaLearningSet.UpdateSabaCourses
        Try
            Return Me.cSabaLearningFactory.Update(cSabaLearning)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function UpdateSabaXref() As Boolean Implements ISabaLearningSet.UpdateSabaXref
        Try
            Return Me.cSabaLearningFactory.UpdateXref(cSabaLearning)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Function GetAllSabaCourseTitle(saba_message As String, empID As Integer) As List(Of SabaLearningSet) Implements ISabaLearningSet.GetAllSabaCourseByTitle
        Try
            Dim keys As clsSabaLearningKeys = New clsSabaLearningKeys(saba_message)
            Dim cList As List(Of clsSabaLearning)
            Dim cListSet As New List(Of SabaLearningSet)

            cList = cSabaLearningFactory.GetAllByTitle(keys, empID)

            If Not IsNothing(cList) Then
                For Each objclsSabaLearning As clsSabaLearning In cList
                    cListSet.Add(New SabaLearningSet(objclsSabaLearning))
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
