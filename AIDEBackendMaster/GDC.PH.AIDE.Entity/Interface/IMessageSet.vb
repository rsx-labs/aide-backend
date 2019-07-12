Imports GDC.PH.AIDE.BusinessLayer
Public Interface IMessageSet
    Property MESSAGE_DESCR As String
    Property TITLE As String

    Function GetAllMessage(ByVal msg_id As Integer, ByVal sec_id As Integer) As List(Of MessageSet)
End Interface
