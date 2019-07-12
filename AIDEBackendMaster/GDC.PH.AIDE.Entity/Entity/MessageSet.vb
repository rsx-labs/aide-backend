Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class MessageSet
    Implements IMessageSet, INotifyPropertyChanged

    Private cMessage As clsMessage
    Private cMessageFactory As clsMessageFactory

    Public Sub New()
        cMessage = New clsMessage()
        cMessageFactory = New clsMessageFactory()
    End Sub

    Public Sub New(ByVal objMessage As clsMessage)
        cMessage = objMessage
        cMessageFactory = New clsMessageFactory()
    End Sub

    Public Function GetAllMessage(msg_id As Integer, sec_id As Integer) As List(Of MessageSet) Implements IMessageSet.GetAllMessage
        Dim cList As List(Of clsMessage)
        Dim cListSet As New List(Of MessageSet)
        Try

            cList = cMessageFactory.GetMessage(msg_id, sec_id)

            If Not IsNothing(cList) Then
                For Each cMsg As clsMessage In cList
                    cListSet.Add(New MessageSet(cMsg))
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

    Public Property MESSAGE_DESCR As String Implements IMessageSet.MESSAGE_DESCR
        Get
            Return Me.cMessage.MESSAGE_DESCR
        End Get
        Set(value As String)
            Me.cMessage.MESSAGE_DESCR = value
        End Set
    End Property

    Public Property TITLE As String Implements IMessageSet.TITLE
        Get
            Return Me.cMessage.TITLE
        End Get
        Set(value As String)
            Me.cMessage.TITLE = value
        End Set
    End Property

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
