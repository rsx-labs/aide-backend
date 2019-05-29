Imports GDC.PH.AIDE.BusinessLayer
Public Interface IBirthday
    Property EMP_ID As Integer
    Property FIRST_NAME As String
    Property LAST_NAME As String
    Property BIRTHDAY As Date
    Property IMAGE_PATH As String

    Function GetAllBirthday(ByVal email As String) As List(Of BirthdaySet)
    Function GetBirthdayByMonth(ByVal email As String) As List(Of BirthdaySet)
    Function GetBirthdayByDay(ByVal email As String) As List(Of BirthdaySet)
End Interface
