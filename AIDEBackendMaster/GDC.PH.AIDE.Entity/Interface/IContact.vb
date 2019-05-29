Imports GDC.PH.AIDE.BusinessLayer
Public Interface IContact
    Property EMP_ID As Integer
    Property EMAIL_ADDRESS As String
    Property EMAIL_ADDRESS2 As String
    Property LOCATION As String
    Property CEL_NO As String
    Property LOCAL As Integer
    Property HOMEPHONE As String
    Property OTHER_PHONE As String
    Property DT_REVIEWED As Date
    Property POS_ID As Integer
    Property DESCR As String
    Property FIRST_NAME As String
    Property LAST_NAME As String
    Property IMAGE_PATH As String

    Function GetContactsByID(ByVal EMP_ID As Integer)
    Function GetAllContacts(ByVal email As String) As List(Of ContactSet)
    Function CreateContacts(ByVal contact As ContactSet) As Boolean
    Function UpdateContacts(ByVal contact As ContactSet) As Boolean
End Interface
