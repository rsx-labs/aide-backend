Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports GDC.PH.AIDE.BusinessLayer.DataLayer

''' <summary>
''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
''' </summary>
''' <remarks></remarks>

Public Class ConcernSet
    Implements IConcernSet, INotifyPropertyChanged

    Private clsConcern As clsConcern
    Private clsConcernFactory As clsConcernFactory

    Public Sub New()
        clsConcern = New clsConcern()
        clsConcernFactory = New clsConcernFactory
    End Sub

    Public Sub New(ByVal cList As clsConcern)
        clsConcern = cList
        clsConcernFactory = New clsConcernFactory
    End Sub

#Region "Properties"

    Public Property RefID As String Implements IConcernSet.REF_ID
        Get
            Return Me.clsConcern.REF_ID
        End Get
        Set(value As String)
            Me.clsConcern.REF_ID = value
        End Set
    End Property

    Public Property CONCERN As String Implements IConcernSet.CONCERN
        Get
            Return Me.clsConcern.CONCERN
        End Get
        Set(value As String)
            Me.clsConcern.CONCERN = value
        End Set
    End Property


    Public Property CAUSE As String Implements IConcernSet.CAUSE
        Get
            Return Me.clsConcern.CAUSE
        End Get
        Set(value As String)
            Me.clsConcern.CAUSE = value
        End Set
    End Property


    Public Property COUNTERMEASURE As String Implements IConcernSet.COUNTERMEASURE
        Get
            Return Me.clsConcern.COUNTERMEASURE
        End Get
        Set(value As String)
            Me.clsConcern.COUNTERMEASURE = value
        End Set
    End Property

    Public Property EMP_ID As String Implements IConcernSet.EMP_ID
        Get
            Return Me.clsConcern.EMP_ID
        End Get
        Set(value As String)
            Me.clsConcern.EMP_ID = value
        End Set
    End Property

    Public Property ACT_REFERENCE As String Implements IConcernSet.ACT_REFERENCE
        Get
            Return Me.clsConcern.ACT_REFERENCE
        End Get
        Set(value As String)
            Me.clsConcern.ACT_REFERENCE = value
        End Set
    End Property


    Public Property DUE_DATE As Date Implements IConcernSet.DUE_DATE
        Get
            Return Me.clsConcern.DUE_DATE
        End Get
        Set(value As Date)
            Me.clsConcern.DUE_DATE = value
        End Set
    End Property

    Public Property DESCR As String Implements IConcernSet.STATUS
        Get
            Return Me.clsConcern.DESCR
        End Get
        Set(value As String)
            Me.clsConcern.DESCR = value
        End Set
    End Property



    Public Property GENERATEDREF_IDS As String Implements IConcernSet.GENERATEDREF_ID
        Get
            Return Me.clsConcern.GENERATEDREF_ID
        End Get
        Set(value As String)
            Me.clsConcern.GENERATEDREF_ID = value
        End Set
    End Property


    Public Property ACTREF As String Implements IConcernSet.ACTREF
        Get
            Return Me.clsConcern.ACTREF
        End Get
        Set(value As String)
            Me.clsConcern.ACTREF = value
        End Set
    End Property

    Public Property ACT_MESSAGE As String Implements IConcernSet.ACT_MESSAGE
        Get
            Return Me.clsConcern.ACT_MESSAGE
        End Get
        Set(value As String)
            Me.clsConcern.ACT_MESSAGE = value
        End Set
    End Property

    Public Property ACTION_REFERENCES As String Implements IConcernSet.ACTION_REFERENCES
        Get
            Return Me.clsConcern.ACTION_REFERENCES
        End Get
        Set(value As String)
            Me.clsConcern.ACTION_REFERENCES = value
        End Set
    End Property


    Public Property DATE1 As Date Implements IConcernSet.DATE1
        Get
            Return Me.clsConcern.DATE1
        End Get
        Set(value As Date)
            Me.clsConcern.DATE1 = value
        End Set
    End Property

    Public Property DATE2 As Date Implements IConcernSet.DATE2
        Get
            Return Me.clsConcern.DATE2
        End Get
        Set(value As Date)
            Me.clsConcern.DATE2 = value
        End Set
    End Property

#End Region

#Region "Methods"
    'BY CHRISTIAN VALONDO
    ''INSERT FUNCTION
    Public Function InsertIntoConcerns(_conern As ConcernSet, email As String) As Boolean Implements IConcernSet.InsertIntoConcerns
        Try
            Return Me.clsConcernFactory.Insert(clsConcern, email)
            ' clsConcernFactory.insert(clsConcern)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    ' BY GIANN CARLO CAMILO
    ''GET ALL CONCERN FUNCTION
    Public Function GetAllConcernList(empID As Integer) As List(Of ConcernSet) Implements IConcernSet.GetAllConcernList
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.GetAllConcernList(empID)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function
    ''GET GENERATED REF NO FUNCTION

    ' BY GIANN CARLO CAMILO
    Public Function GetGeneratedRefNo() As ConcernSet Implements IConcernSet.GetGeneratedRefNo
        Try
            Dim objConcern As clsConcern
            Dim _concern As ConcernSet

            objConcern = Me.clsConcernFactory.GetGeneratedRefNo()

            If IsNothing(objConcern) Then
                Throw New EmployeeNotFoundException("Employee Not Found")
            End If

            _concern = New ConcernSet(objConcern)


            Return _concern

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try

    End Function

    ' BY GIANN CARLO CAMILO
    ''search By KEYWORD
    Public Function GetResultSearch(email As String, searchKeyword As String, offsetVal As Integer, nextVal As Integer) As List(Of ConcernSet) Implements IConcernSet.GetResultSearch
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.Search(email, searchKeyword, offsetVal, nextVal)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    ' BY GIANN CARLO CAMILO
    ''LISTVIEW ACTION
    ''GET ALL CONCERN FUNCTION
    Public Function GetListOfACtion(Ref_id As String, email As String) As List(Of ConcernSet) Implements IConcernSet.GetListOfACtion
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.GetACtionList(Ref_id, email)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function


    'BY CHRISTIAN VALONDO
    'Listview ACTION
    'GET ALL ACtion References of Each Concern
    Public Function GetListOfACtionsReferences(Ref_id As String) As List(Of ConcernSet) Implements IConcernSet.GetListOfACtionsReferences
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.GetACtionListReferences(Ref_id)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    'BY CHRISTIAN VALONDO
    ''INSERT selected action FUNCTION
    Public Function insertAndDeleteSelectedAction(_conern As ConcernSet) As Boolean Implements IConcernSet.insertAndDeleteSelectedAction
        Try

            Return Me.clsConcernFactory.insertAndDeleteSelectedAction(clsConcern)

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    ' BY GIANN CARLO CAMILO
    ''UPDATE selected CONCERN FUNCTION
    Public Function UpdateSelectedConcern(_conern As ConcernSet) As Boolean Implements IConcernSet.UpdateSelectedConcern
        Try

            Return Me.clsConcernFactory.UpdateSelectedConcern(clsConcern)

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Lesson Learnt Failed!")
            End If
        End Try
    End Function

    ' BY GIANN CARLO CAMILO
    ''GET ALL CONCERN FUNCTION BETWEEN DATES
    Public Function GetBetweenSearchConcern(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of ConcernSet) Implements IConcernSet.GetBetweenSearchConcern
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.GetBetweenSearchConcern(email, offsetVal, nextVal, date1, date2)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    'BY CHRISTIAN VALONDO
    ''LISTVIEW ACTION
    ''GET ALL CONCERN FUNCTION VIA SEARCH ACTION
    Public Function GetSearchAction(_keywordAction As String, Ref_id As String, email As String) As List(Of ConcernSet) Implements IConcernSet.GetSearchAction
        Try
            Dim lstConcern As List(Of clsConcern)
            Dim lstConcernSet As New List(Of ConcernSet)

            lstConcern = clsConcernFactory.GetSearchAction(_keywordAction, Ref_id, email)

            If Not IsNothing(lstConcern) Then
                For Each cList As clsConcern In lstConcern
                    lstConcernSet.Add(New ConcernSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return lstConcernSet

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

#End Region

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

End Class
