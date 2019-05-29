Public Class RetrieveFailedException
    Inherits Exception

    Public Sub New()

    End Sub
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, ByVal inner As Exception)
        MyBase.New(message, inner)

    End Sub
End Class
