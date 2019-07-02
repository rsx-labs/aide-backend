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
    Property POSITION As String
    Property MARITAL_STATUS As String
    Property FIRST_NAME As String
    Property LAST_NAME As String
    Property IMAGE_PATH As String
    Property MIDDLE_NAME As String
    Property NICK_NAME As String
    Property BIRTHDATE As Date
    Property DT_HIRED As Date
    Property STATUS As String
    Property PERMISSION_GROUP As String
    Property DEPARTMENT As String
    Property DIVISION As String
    Property SHIFT As String

    Function GetContactsByID(ByVal EMP_ID As Integer)
    Function GetAllContacts(ByVal email As String) As List(Of ContactSet)
    Function CreateContacts(ByVal contact As ContactSet) As Boolean
    Function UpdateContacts(ByVal contact As ContactSet) As Boolean
End Interface
