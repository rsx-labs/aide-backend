Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
''' <summary>
''' BY GIANN CARLO CAMILO/CHRISTIAN VALONDO
''' </summary>
''' <remarks></remarks>
Public Class ConcernManagement
    Inherits ManagementBase

#Region "Concern"
    ''GET RESULT OF ALL CONCERN
    Public Function selectAllConcern(email As String, offsetVal As Integer, nextVal As Integer) As StateData
        Dim ConcernSet As New ConcernSet
        Dim listConcern As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcern = ConcernSet.selectAllConcern(email, offsetVal, nextVal)

            If Not IsNothing(listConcern) Then
                For Each objList As ConcernSet In listConcern
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

    ''INSERT CONCERN
    Public Function InsertIntoConcerns(ByVal _concern As Concern, email As String) As StateData
        Dim concernSet As New ConcernSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(concernSet, _concern)
            If concernSet.InsertIntoConcerns(concernSet, email) Then
                status = NotifyType.IsSuccess
                message = "inserted Concern Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    ''FUNCTION RETURN GENERATED REF NO
    Public Function GetGeneratedRefNo() As StateData
        Dim ConcernSet As New ConcernSet
        Dim objConcern As Concern = Nothing
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try

            ConcernSet = ConcernSet.GetGeneratedRefNo()

            If Not IsNothing(ConcernSet) Then
                objConcern = DirectCast(GetMappedFields(ConcernSet), Concern)
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try


        state = GetStateData(status, objConcern, message)
        Return state
    End Function

    ''SEARCH
    Public Function GetResultSearch(email As String, searchKeyWord As String, offsetVal As Integer, nextVal As Integer) As StateData
        Dim ConcernSet As New ConcernSet
        Dim listConcern As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcern = ConcernSet.GetResultSearch(email, searchKeyWord, offsetVal, nextVal)

            If Not IsNothing(listConcern) Then
                For Each objList As ConcernSet In listConcern
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

    ''DISPLAY ACTION LIST TO LISTVIEW 
    Public Function GetListOfACtion(Ref_id As String, email As String) As StateData
        Dim ConcernSet As New ConcernSet
        Dim listConcern As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcern = ConcernSet.GetListOfACtion(Ref_id, email)

            If Not IsNothing(listConcern) Then
                For Each objList As ConcernSet In listConcern
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

    ''DISPLAY ACTION REFERENCES TO LISTVIEW 
    Public Function GetListOfACtionsReferences(Ref_id As String) As StateData
        Dim ConcernACtionSet As New ConcernSet
        Dim listConcernActionReferences As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcernActionReferences = ConcernACtionSet.GetListOfACtionsReferences(Ref_id)

            If Not IsNothing(listConcernActionReferences) Then
                For Each objList As ConcernSet In listConcernActionReferences
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

    ''INSERT SELECTED ACTION
    Public Function insertAndDeleteSelectedAction(ByVal _concern As Concern) As StateData
        Dim concernSet As New ConcernSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(concernSet, _concern)
            If concernSet.insertAndDeleteSelectedAction(concernSet) Then
                status = NotifyType.IsSuccess
                message = "inserted Concern Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    ''UPDATE SELECTED CONCERN
    Public Function UpdateSelectedConcern(ByVal _concern As Concern) As StateData
        Dim concernSet As New ConcernSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(concernSet, _concern)
            If concernSet.UpdateSelectedConcern(concernSet) Then
                status = NotifyType.IsSuccess
                message = "Updated Concern Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)
        Return state
    End Function

    ''GET RESULT OF ALL CONCERN VIA BETWEEN DATE SEARCH
    Public Function GetBetweenSearchConcern(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As StateData
        Dim ConcernSet As New ConcernSet
        Dim listConcern As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcern = ConcernSet.GetBetweenSearchConcern(email, offsetVal, nextVal, date1, date2)

            If Not IsNothing(listConcern) Then
                For Each objList As ConcernSet In listConcern
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

    ''DISPLAY ACTION LIST TO LISTVIEW VIA SEARCH
    Public Function GetSearchAction(_keywordAction As String, Ref_id As String, email As String) As StateData
        Dim ConcernSet As New ConcernSet
        Dim listConcern As List(Of ConcernSet)
        Dim obConcern As New List(Of Concern)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            listConcern = ConcernSet.GetSearchAction(_keywordAction, Ref_id, email)

            If Not IsNothing(listConcern) Then
                For Each objList As ConcernSet In listConcern
                    obConcern.Add(DirectCast(GetMappedFields(objList), Concern))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, obConcern, message)
        Return state
    End Function

#End Region
    
#Region "Exception"
    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

#End Region
   
#Region "Mapping"
    ''PAG BABIND /PAG DIDISPLAY
    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objConcern As ConcernSet = DirectCast(objData, ConcernSet)
        Dim ConcernData As New Concern

        ConcernData.RefID = objConcern.RefID
        ConcernData.Concerns = objConcern.CONCERN
        ConcernData.Cause = objConcern.CAUSE
        ConcernData.CounterMeasure = objConcern.COUNTERMEASURE
        ConcernData.Act_Reference = objConcern.ACT_REFERENCE
        ConcernData.EmpID = objConcern.EMP_ID
        ConcernData.Due_Date = objConcern.DUE_DATE
        ConcernData.Status = objConcern.DESCR

        ConcernData.GENERATEDREF_ID = objConcern.GENERATEDREF_IDS
        ConcernData.ACT_MESSAGE = objConcern.ACT_MESSAGE
        ConcernData.ACTREF = objConcern.ACTREF
        ConcernData.ACTION_REFERENCES = objConcern.ACTION_REFERENCES


        Return ConcernData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
    ''PAG IINSERT SINESET SA SET ANG VALUE
    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objConcern As Concern = DirectCast(objData, Concern)
        Dim ConcernData As New ConcernSet

        ConcernData.RefID = objConcern.RefID
        ConcernData.CONCERN = objConcern.Concerns
        ConcernData.CAUSE = objConcern.Cause
        ConcernData.COUNTERMEASURE = objConcern.CounterMeasure
        ConcernData.ACT_REFERENCE = objConcern.Act_Reference
        ConcernData.EMP_ID = objConcern.EmpID
        ConcernData.DUE_DATE = objConcern.Due_Date
        ConcernData.DESCR = objConcern.Status

        ConcernData.GENERATEDREF_IDS = objConcern.GENERATEDREF_ID
        ConcernData.ACTION_REFERENCES = objConcern.ACTION_REFERENCES

        ConcernData.ACTREF = objConcern.ACTREF
        ConcernData.ACT_MESSAGE = objConcern.ACT_MESSAGE

        objResult = ConcernData
    End Sub

#End Region
    
End Class
