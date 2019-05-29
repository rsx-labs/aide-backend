Imports GDC.PH.AIDE.BusinessLayer

Public Interface IProfileSet

    Property EmployeeID As Integer
    Property WsEmpID As String
    Property DeptID As Short
    Property LastName As String
    Property FirstName As String
    Property MiddleName As String
    Property NickName As String
    Property BirthDate As DateTime
    Property DateHired As DateTime
    Property ImagePath As String
    Property Department As String
    Property Division As String
    Property Position As String
    Property EmailAddress As String
    Property EmailAddress2 As String
    Property Location As String
    Property CelNo As String
    Property Local As Integer
    Property HomePhone As String
    Property OtherPhone As String
    Property DtReviewed As DateTime
    Property Permission As String
    Property CivilStatus As String
    Property ShiftStatus As String


    Function GetProfile(ByVal EmpId As String) As ProfileSet
    Function GetProfileByEmailAddress(ByVal EmailAddress As String) As ProfileSet
    'Function UpdateProfile() As Boolean

End Interface
