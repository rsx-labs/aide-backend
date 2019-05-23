Imports GDC.PH.AIDE.Entity

''' <summary>
''' By John Harvey Sanchez
''' </summary>

Public Class LessonLearntManagement
    Inherits ManagementBase

    Public Function CreateNewLessonLearnt(ByVal lessonLearnt As LessonLearnt) As StateData
        Dim lessonLearntSet As New LessonLearntSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            SetFields(lessonLearntSet, lessonLearnt)
            If lessonLearntSet.InsertNewLessonLearnt(lessonLearntSet) Then
                status = NotifyType.IsSuccess
                message = "Create Lesson Learnt Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function UpdateLessonLearnt(ByVal lessonLearnt As LessonLearnt) As StateData
        Dim lessonLearntSet As New LessonLearntSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(lessonLearntSet, lessonLearnt)
            If lessonLearntSet.UpdateLessonLearnt(lessonLearntSet) Then
                status = NotifyType.IsSuccess
                message = "Update Lesson Learnt Successful!"
            End If
        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status)

        Return state
    End Function

    Public Function GetLessonLearntList(ByVal email As String) As StateData
        Dim lessonLearntSet As New LessonLearntSet
        Dim lstLessonLearnt As List(Of LessonLearntSet)
        Dim objLessonLearnt As New List(Of LessonLearnt)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstLessonLearnt = lessonLearntSet.GetAllLessonLearnts(email)

            If Not IsNothing(lstLessonLearnt) Then
                For Each objList As LessonLearntSet In lstLessonLearnt
                    objLessonLearnt.Add(DirectCast(GetMappedFields(objList), LessonLearnt))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objLessonLearnt, message)
        Return state
    End Function

    Public Function GetLessonLearntListByProblem(ByVal searchProblem As String, ByVal email As String) As StateData
        Dim lessonLearntSet As New LessonLearntSet
        Dim lstLessonLearnt As List(Of LessonLearntSet)
        Dim objLessonLearnt As New List(Of LessonLearnt)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstLessonLearnt = lessonLearntSet.GetLessonLearntsByProblem(searchProblem, email)

            If Not IsNothing(lstLessonLearnt) Then
                For Each objList As LessonLearntSet In lstLessonLearnt
                    objLessonLearnt.Add(DirectCast(GetMappedFields(objList), LessonLearnt))
                Next

                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objLessonLearnt, message)
        Return state
    End Function

    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Return ex.Message
    End Function

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objLessonLearnt As LessonLearntSet = DirectCast(objData, LessonLearntSet)
        Dim lessonLearntData As New LessonLearnt

        lessonLearntData.ReferenceNo = objLessonLearnt.ReferenceNo
        lessonLearntData.EmpID = objLessonLearnt.EmployeeID
        lessonLearntData.Nickname = objLessonLearnt.Nickname
        lessonLearntData.Problem = objLessonLearnt.Problem
        lessonLearntData.Resolution = objLessonLearnt.Resolution
        lessonLearntData.ActionNo = objLessonLearnt.ActionNo

        Return lessonLearntData
    End Function

    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objLessonLearnt As LessonLearnt = DirectCast(objData, LessonLearnt)
        Dim lessonLearntData As New LessonLearntSet

        lessonLearntData.ReferenceNo = objLessonLearnt.ReferenceNo
        lessonLearntData.EmployeeID = objLessonLearnt.EmpID
        lessonLearntData.Nickname = objLessonLearnt.Nickname
        lessonLearntData.Problem = objLessonLearnt.Problem
        lessonLearntData.Resolution = objLessonLearnt.Resolution
        lessonLearntData.ActionNo = objLessonLearnt.ActionNo

        objResult = lessonLearntData
    End Sub

End Class
