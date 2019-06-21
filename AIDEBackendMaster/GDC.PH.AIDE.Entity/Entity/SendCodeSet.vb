Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class SendCodeSet
    Implements ISendCode, INotifyPropertyChanged


    Private cSendCode As clsSendCode
    Private cSendCodeFactory As clsSendCodeFactory
    Public Sub New()
        cSendCode = New clsSendCode()
        cSendCodeFactory = New clsSendCodeFactory()
    End Sub

    Public Sub New(ByVal objSendCode As clsSendCode)
        cSendCode = objSendCode
        cSendCodeFactory = New clsSendCodeFactory()
    End Sub

    Public Function GetWorkEmailbyEmail(email As String) As SendCodeSet Implements ISendCode.GetWorkEmailbyEmail
        Try
            Dim cSendCode As clsSendCode
            Dim keys As clsSendCodeKey = New clsSendCodeKey(email)
            cSendCode = cSendCodeFactory.GetByPrimaryKey(keys)
            If Not IsNothing(cSendCode) Then
                Dim cSendCodeSet As New SendCodeSet(cSendCode)
                Return cSendCodeSet
            Else
                Throw New SendCodeNotFoundException("Email not set!")
            End If

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try


        'Try
        '    Dim key As clsSendCodeKey = New clsSendCodeKey(email)
        '    Dim objSendCodeList As List(Of clsSendCode)
        '    Dim listSendCode As New List(Of SendCodeSet)
        '    objSendCodeList = Me.cSendCodeFactory.GetByPrimaryKey(key)
        '    If Not IsNothing(objSendCodeList) Then
        '        For Each cSendCode As clsSendCode In objSendCodeList
        '            Dim newSendCode As New SendCodeSet(cSendCode)
        '            listSendCode.Add(newSendCode)
        '        Next
        '    Else
        '        Throw New NoRecordFoundException("No records found!")
        '    End If
        '    Return listSendCode
        'Catch ex As Exception
        '    If (ex.InnerException.GetType() = GetType(SqlException)) Then
        '        Throw New DatabaseConnExceptionFailed("Database Connection Failed")
        '    Else
        '        Throw ex.InnerException
        '    End If
        'End Try
    End Function

    Public Property SendCodeFName As String Implements ISendCode.SendCodeFName
        Get
            Return cSendCode.FNAME
        End Get
        Set(value As String)
            cSendCode.FNAME = value
        End Set
    End Property

    Public Property SendCodeLName As String Implements ISendCode.SendCodeLName
        Get
            Return cSendCode.LNAME
        End Get
        Set(value As String)
            cSendCode.LNAME = value
        End Set
    End Property

    Public Property SendCodeWorkEmail As String Implements ISendCode.SendCodeWorkEmail
        Get
            Return cSendCode.WORK_EMAIL
        End Get
        Set(value As String)
            cSendCode.WORK_EMAIL = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class
