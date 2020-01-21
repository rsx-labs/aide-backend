Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer

Public Class SabaLearningManagement
    Inherits ManagementBase

    Private m_stateData As StateData

    Public Sub New()
        m_stateData = New StateData()
    End Sub



    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function

    Public Overrides Function GetMappedFields(ByVal objData As Object) As Object
        Dim objSabaLearning As SabaLearningSet = DirectCast(objData, SabaLearningSet)
        Dim SabaLearningData As New SabaLearning
        SabaLearningData.SABA_ID = objSabaLearning.SABA_ID
        SabaLearningData.EMP_ID = objSabaLearning.EMP_ID
        SabaLearningData.TITLE = objSabaLearning.TITLE
        SabaLearningData.END_DATE = objSabaLearning.END_DATE
        SabaLearningData.DATE_COMPLETED = objSabaLearning.DATE_COMPLETED
        SabaLearningData.IMAGE_PATH = objSabaLearning.IMAGE_PATH
        SabaLearningData.TOTAL_ENROLL = objSabaLearning.TOTAL_ENROLL
        SabaLearningData.TOTAL_COMPLETED = objSabaLearning.TOTAL_COMPLETED


        Return SabaLearningData
    End Function

    Public Function GetAllSabaCourses(empID As Integer) As StateData
        Dim SabaLearning As New SabaLearningSet
        Dim lstSabaLearning As List(Of SabaLearningSet)
        Dim objSabaLearning As New List(Of SabaLearning)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSabaLearning = SabaLearning.GetAllSabaCourses(empID)

            If Not IsNothing(lstSabaLearning) Then
                For Each objList As SabaLearningSet In lstSabaLearning
                    objSabaLearning.Add(DirectCast(GetMappedFields(objList), SabaLearning))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSabaLearning, message)
        Return state
    End Function

    Public Function GetAllSabaXref(empID As Integer, sabaID As Integer) As StateData
        Dim SabaLearning As New SabaLearningSet
        Dim lstSabaLearning As List(Of SabaLearningSet)
        Dim objSabaLearning As New List(Of SabaLearning)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSabaLearning = SabaLearning.GetAllSabaXref(empID, sabaID)

            If Not IsNothing(lstSabaLearning) Then
                For Each objList As SabaLearningSet In lstSabaLearning
                    objSabaLearning.Add(DirectCast(GetMappedFields(objList), SabaLearning))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSabaLearning, message)
        Return state
    End Function

    Public Function InsertSabaCourses(ByVal _obj As SabaLearning) As StateData
        Dim _SabaLearningSet As New SabaLearningSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(_SabaLearningSet, _obj)
            If _SabaLearningSet.InsertSabaCourses() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateSabaCourses(ByVal _obj As SabaLearning) As StateData
        Dim _SabaLearningSet As New SabaLearningSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(_SabaLearningSet, _obj)
            If _SabaLearningSet.UpdateSabaCourses() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateSabaXref(ByVal _obj As SabaLearning) As StateData
        Dim _SabaLearningSet As New SabaLearningSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(_SabaLearningSet, _obj)
            If _SabaLearningSet.UpdateSabaXref() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function GetAllSabaCourseByTitle(saba_message As String, empID As Integer) As StateData
        Dim SabaLearning As New SabaLearningSet
        Dim lstSabaLearning As List(Of SabaLearningSet)
        Dim objSabaLearning As New List(Of SabaLearning)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstSabaLearning = SabaLearning.GetAllSabaCourseTitle(saba_message, empID)

            If Not IsNothing(lstSabaLearning) Then
                For Each objList As SabaLearningSet In lstSabaLearning
                    objSabaLearning.Add(DirectCast(GetMappedFields(objList), SabaLearning))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objSabaLearning, message)
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
        Dim objSabaLearning As SabaLearning = DirectCast(objData, SabaLearning)
        Dim SabaLearningData As New SabaLearningSet
        SabaLearningData.SABA_ID = objSabaLearning.SABA_ID
        SabaLearningData.EMP_ID = objSabaLearning.EMP_ID
        If Not IsNothing(objSabaLearning.TITLE) Then
            SabaLearningData.TITLE = objSabaLearning.TITLE
        Else

            SabaLearningData.TITLE = String.Empty
        End If
        If Not IsNothing(objSabaLearning.END_DATE) Then
            SabaLearningData.END_DATE = objSabaLearning.END_DATE
        Else

            SabaLearningData.END_DATE = String.Empty
        End If

        If Not IsNothing(objSabaLearning.DATE_COMPLETED) Then
            SabaLearningData.DATE_COMPLETED = objSabaLearning.DATE_COMPLETED
        Else

            SabaLearningData.DATE_COMPLETED = String.Empty
        End If

        If Not IsNothing(objSabaLearning.IMAGE_PATH) Then
            SabaLearningData.IMAGE_PATH = objSabaLearning.IMAGE_PATH
        Else
            SabaLearningData.IMAGE_PATH = String.Empty
        End If

        objResult = SabaLearningData
    End Sub
End Class
