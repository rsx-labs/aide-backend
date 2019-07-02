Imports GDC.PH.AIDE.Entity
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class MailConfigSet
    Implements IMailConfigSet, INotifyPropertyChanged



    Private cMailConfig As clsMailConfig
    Private cMailConfigFactory As clsMailConfigFactory
    Public Sub New()
        cMailConfig = New clsMailConfig()
        cMailConfigFactory = New clsMailConfigFactory()
    End Sub

    Public Sub New(ByVal objMailConfig As clsMailConfig)
        cMailConfig = objMailConfig
        cMailConfigFactory = New clsMailConfigFactory()
    End Sub

    Public Function GetMailConfig() As MailConfigSet Implements IMailConfigSet.GetMailConfig
        Try
            Dim cMailConfig As clsMailConfig
            cMailConfig = cMailConfigFactory.GetItem()
            If Not IsNothing(cMailConfig) Then
                Dim cMailConfigSet As New MailConfigSet(cMailConfig)
                Return cMailConfigSet
            Else
                Throw New MailConfigNotFoundException("Config not set!")
            End If

        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Property SCBody As String Implements IMailConfigSet.SCBody
        Get
            Return cMailConfig.SC_BODY
        End Get
        Set(value As String)
            cMailConfig.SC_BODY = value
        End Set
    End Property

    Public Property SCEnableSSL As Integer Implements IMailConfigSet.SCEnableSSL
        Get
            Return cMailConfig.SC_ENABLE_SSL
        End Get
        Set(value As Integer)
            cMailConfig.SC_ENABLE_SSL = value
        End Set
    End Property

    Public Property SCHost As String Implements IMailConfigSet.SCHost
        Get
            Return cMailConfig.SC_HOST
        End Get
        Set(value As String)
            cMailConfig.SC_HOST = value
        End Set
    End Property

    Public Property SCPort As Integer Implements IMailConfigSet.SCPort
        Get
            Return cMailConfig.SC_PORT
        End Get
        Set(value As Integer)
            cMailConfig.SC_PORT = value
        End Set
    End Property

    Public Property SCSenderEmail As String Implements IMailConfigSet.SCSenderEmail
        Get
            Return cMailConfig.SC_SENDER_EMAIL
        End Get
        Set(value As String)
            cMailConfig.SC_SENDER_EMAIL = value
        End Set
    End Property

    Public Property SCSenderPassword As String Implements IMailConfigSet.SCSenderPassword
        Get
            Return cMailConfig.SC_SENDER_PASSWORD
        End Get
        Set(value As String)
            cMailConfig.SC_SENDER_PASSWORD = value
        End Set
    End Property

    Public Property SCSubject As String Implements IMailConfigSet.SCSubject
        Get
            Return cMailConfig.SC_SUBJECT
        End Get
        Set(value As String)
            cMailConfig.SC_SUBJECT = value
        End Set
    End Property

    Public Property SCTimeout As Integer Implements IMailConfigSet.SCTimeout
        Get
            Return cMailConfig.SC_TIMEOUT
        End Get
        Set(value As Integer)
            cMailConfig.SC_TIMEOUT = value
        End Set
    End Property
    Public Property SCUseDfltCredentials As Integer Implements IMailConfigSet.SCUseDfltCredentials
        Get
            Return cMailConfig.SC_USE_DFLT_CREDENTIALS
        End Get
        Set(value As Integer)
            cMailConfig.SC_USE_DFLT_CREDENTIALS = value
        End Set
    End Property
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Public Property SCPasswordExpiry As Integer Implements IMailConfigSet.SCPasswordExpiry
        Get
            Return cMailConfig.SC_PASSWORD_EXPIRY
        End Get
        Set(value As Integer)
            cMailConfig.SC_PASSWORD_EXPIRY = value
        End Set
    End Property
End Class
