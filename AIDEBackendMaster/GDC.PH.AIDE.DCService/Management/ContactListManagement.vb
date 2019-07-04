Imports gdc.ph.AIDE.Entity
Imports gdc.ph.AIDE.BusinessLayer

Public Class ContactListManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objContacts As ContactSet = DirectCast(objData, ContactSet)
        Dim contactData As New ContactList
        contactData.EmpID = objContacts.EmpID
        contactData.EMADDRESS = objContacts.EMADDRESS
        contactData.EMADDRESS2 = objContacts.EMADDRESS2
        contactData.POSITION = objContacts.POSITION
        contactData.MARITAL_STATUS = objContacts.MARITAL_STATUS
        contactData.HOUSEPHONE = objContacts.HOUSEPHONE
        contactData.OTHERPHONE = objContacts.OTHERPHONE
        contactData.LOC = objContacts.LOC
        contactData.lOCAL = objContacts.lOCAL
        contactData.CELL_NO = objContacts.CELL_NO
        contactData.DateReviewed = objContacts.DateReviewed
        contactData.FIRST_NAME = objContacts.FIRST_NAME
        contactData.LAST_NAME = objContacts.LAST_NAME
        contactData.IMAGE_PATH = objContacts.IMAGE_PATH
        contactData.Nick_Name = objContacts.NICK_NAME
        contactData.MIDDLE_NAME = objContacts.MIDDLE_NAME
        contactData.ACTIVE = objContacts.ACTIVE
        'contactData.STATUS = objContacts.STATUS
        contactData.PERMISSION_GROUP = objContacts.PERMISSION_GROUP
        contactData.DEPARTMENT = objContacts.DEPARTMENT
        contactData.DIVISION = objContacts.DIVISION
        contactData.SHIFT = objContacts.SHIFT
        contactData.BIRTHDATE = objContacts.BIRTHDATE
        contactData.DT_HIRED = objContacts.DT_HIRED

        Return contactData
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Function CreateContactList(ByVal contacts As ContactList) As StateData
        Dim contactSet As New ContactSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(contactSet, contacts)
            If contactSet.CreateContacts(contactSet) Then
                status = NotifyType.IsSuccess
                message = "Create Contacts successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetContactListAll(email As String) As StateData
        Dim contactListSet As New ContactSet
        Dim lstContacts As List(Of ContactSet)
        Dim objContacts As New List(Of ContactList)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstContacts = contactListSet.GetAllContacts(email)

            If Not IsNothing(lstContacts) Then
                For Each objList As ContactSet In lstContacts
                    objContacts.Add(DirectCast(GetMappedFields(objList), ContactList))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objContacts, message)
        Return state
    End Function

    Public Function DeleteSuccessRegister(ByVal successID As Integer) As StateData
        Dim successSet As New SuccessRegisterSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            'SetFields(successSet, successID)
            If successSet.DeleteSuccessRegister(successID) Then
                status = NotifyType.IsSuccess
                message = "Update Success Register Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Function UpdateContactList(ByVal contacts As ContactList) As StateData
        Dim contactSet As New ContactSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(contactSet, contacts)
            If contactSet.UpdateContact(contactSet) Then
                status = NotifyType.IsSuccess
                message = "Update Success Register Information successful!"
            End If

        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status, Nothing, message)
        Return state
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional ByVal data As Object = Nothing, Optional ByVal message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objContacts As ContactList = DirectCast(objData, ContactList)
        Dim contactData As New ContactSet
        contactData.EmpID = objContacts.EmpID
        contactData.EMADDRESS = objContacts.EMADDRESS
        contactData.EMADDRESS2 = objContacts.EMADDRESS2
        contactData.POSITION = objContacts.POSITION
        contactData.MARITAL_STATUS = objContacts.MARITAL_STATUS
        contactData.HOUSEPHONE = objContacts.HOUSEPHONE
        contactData.OTHERPHONE = objContacts.OTHERPHONE
        contactData.LOC = objContacts.LOC
        contactData.lOCAL = objContacts.lOCAL
        contactData.CELL_NO = objContacts.CELL_NO
        contactData.DateReviewed = objContacts.DateReviewed
        contactData.MIDDLE_NAME = objContacts.MIDDLE_NAME
        contactData.NICK_NAME = objContacts.Nick_Name
        contactData.ACTIVE = objContacts.ACTIVE
        'contactData.STATUS = objContacts.STATUS
        contactData.PERMISSION_GROUP = objContacts.PERMISSION_GROUP
        contactData.DEPARTMENT = objContacts.DEPARTMENT
        contactData.DIVISION = objContacts.DIVISION
        contactData.SHIFT = objContacts.SHIFT
        contactData.BIRTHDATE = objContacts.BIRTHDATE
        contactData.DT_HIRED = objContacts.DT_HIRED

        objResult = contactData
    End Sub
End Class
