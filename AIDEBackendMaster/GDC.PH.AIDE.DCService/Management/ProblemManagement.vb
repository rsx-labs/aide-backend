Imports GDC.PH.AIDE.BusinessLayer
Imports GDC.PH.AIDE.DCService
Imports GDC.PH.AIDE.Entity
Public Class ProblemManagement
    Inherits ManagementBase

#Region "Base"
    Public Overrides Function GetStateData(status As NotifyType, Optional data As Object = Nothing, Optional message As String = "") As StateData
        Dim state As New StateData
        state.Data = data
        state.Message = message
        state.NotifyType = status
        Return state
    End Function
    Public Overrides Function GetExceptionMessage(ex As Exception) As String
        Dim message As String = ex.Message
        Return message
    End Function
#End Region

#Region "Problems"
    Public Function GetAllProblems(ByVal empID As Integer)
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblems(empID)

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFields(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblem(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields(problemSet, objProblem)
            If problemSet.InsertProblem() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateProblem(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFields2(problemSet, objProblem)
            If problemSet.UpdateProblem() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Overrides Sub SetFields(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet
        problemData.EmployeeID = objProblem.EmployeeID
        problemData.ProblemDescr = objProblem.ProblemDescr
        problemData.ProblemInvolve = objProblem.ProblemInvolve

        objResult = problemData
    End Sub
    Public Sub SetFields2(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet
        problemData.EmployeeID = objProblem.EmployeeID
        problemData.ProblemID = objProblem.ProblemID
        problemData.ProblemDescr = objProblem.ProblemDescr
        problemData.ProblemInvolve = objProblem.ProblemInvolve

        objResult = problemData
    End Sub

    Public Overrides Function GetMappedFields(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.EmployeeID = objProblem.EmployeeID
        problemData.EmployeeName = objProblem.EmployeeName
        problemData.ProblemID = objProblem.ProblemID
        problemData.ProblemDescr = objProblem.ProblemDescr
        problemData.ProblemInvolve = objProblem.ProblemInvolve

        Return problemData
    End Function
#End Region

#Region "Cause"
    Public Function GetAllProblemCause()
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblemCause()

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFieldsCause(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblemCause(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsCause(problemSet, objProblem)
            If problemSet.InsertProblemCause() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function
    Public Function UpdateProblemCause(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsCause2(problemSet, objProblem)
            If problemSet.UpdateProblemCause() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function
    Public Sub SetFieldsCause(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ProblemID = objProblem.ProblemID
        problemData.CauseDescr = objProblem.CauseDescr
        problemData.CauseWhy = objProblem.CauseWhy

        objResult = problemData
    End Sub

    Public Sub SetFieldsCause2(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.CauseID = objProblem.CauseID
        problemData.ProblemID = objProblem.ProblemID
        problemData.CauseDescr = objProblem.CauseDescr
        problemData.CauseWhy = objProblem.CauseWhy

        objResult = problemData
    End Sub

    Public Function GetMappedFieldsCause(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.CauseID = objProblem.CauseID
        problemData.ProblemID = objProblem.ProblemID
        problemData.CauseDescr = objProblem.CauseDescr
        problemData.CauseWhy = objProblem.CauseWhy

        Return problemData
    End Function
#End Region

#Region "Option"
    Public Function GetAllProblemOption()
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblemOption()

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFieldsOption(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblemOption(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsOption(problemSet, objProblem)
            If problemSet.InsertProblemOption() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateProblemOption(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsOption2(problemSet, objProblem)
            If problemSet.UpdateProblemOption() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function
    Public Sub SetFieldsOption(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionDescr = objProblem.OptionDescr

        objResult = problemData
    End Sub
    Public Sub SetFieldsOption2(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.OptionID = objProblem.OptionID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionDescr = objProblem.OptionDescr

        objResult = problemData
    End Sub

    Public Function GetMappedFieldsOption(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.OptionID = objProblem.OptionID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionDescr = objProblem.OptionDescr

        Return problemData
    End Function
#End Region

#Region "Solution"
    Public Function GetAllProblemSolution()
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblemSolution()

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFieldsSolution(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblemSolution(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsSolution(problemSet, objProblem)
            If problemSet.InsertProblemSolution() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateProblemSolution(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsSolution2(problemSet, objProblem)
            If problemSet.UpdateProblemSolution() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function
    Public Sub SetFieldsSolution(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.SolutionDescr = objProblem.SolutionDescr

        objResult = problemData
    End Sub

    Public Sub SetFieldsSolution2(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.SolutionID = objProblem.SolutionID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.SolutionDescr = objProblem.SolutionDescr

        objResult = problemData
    End Sub

    Public Function GetMappedFieldsSolution(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.SolutionID = objProblem.SolutionID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.SolutionDescr = objProblem.SolutionDescr

        Return problemData
    End Function
#End Region

#Region "Implement"
    Public Function GetAllProblemImplement()
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblemImplement()

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFieldsImplement(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblemImplement(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsImplement(problemSet, objProblem)
            If problemSet.InsertProblemImplement() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Function UpdateProblemImplement(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsImplement2(problemSet, objProblem)
            If problemSet.UpdateProblemImplement() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Sub SetFieldsImplement(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.ImplementDescr = objProblem.ImplementDescr
        problemData.ImplementAssignee = objProblem.ImplementAssignee
        problemData.ImplementValue = objProblem.ImplementValue

        objResult = problemData
    End Sub

    Public Sub SetFieldsImplement2(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ImplementID = objProblem.ImplementID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.ImplementDescr = objProblem.ImplementDescr
        problemData.ImplementAssignee = objProblem.ImplementAssignee
        problemData.ImplementValue = objProblem.ImplementValue

        objResult = problemData
    End Sub

    Public Function GetMappedFieldsImplement(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.ImplementID = objProblem.ImplementID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.ImplementDescr = objProblem.ImplementDescr
        problemData.ImplementAssignee = objProblem.ImplementAssignee
        problemData.ImplementValue = objProblem.ImplementValue

        Return problemData
    End Function
#End Region

#Region "Result"
    Public Function GetAllProblemResult(ByVal ProblemID As Integer, ByVal OptionID As Integer)
        Dim problemSet As New ProblemSet
        Dim lstProjectSet As List(Of ProblemSet)
        Dim objProblem As New List(Of Problem)
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType

        Try
            lstProjectSet = problemSet.GetAllProblemResult(ProblemID, OptionID)

            If Not IsNothing(lstProjectSet) Then
                For Each objList As ProblemSet In lstProjectSet
                    objProblem.Add(DirectCast(GetMappedFieldsResult(objList), Problem))
                Next
                status = NotifyType.IsSuccess
            End If

        Catch ex As Exception
            status = NotifyType.IsError
            message = GetExceptionMessage(ex)
        End Try
        state = GetStateData(status, objProblem, message)
        Return state
    End Function

    Public Function InsertProblemResult(ByVal objProblem As Problem) As StateData
        Dim problemSet As New ProblemSet
        Dim message As String = ""
        Dim state As StateData
        Dim status As NotifyType
        Try
            SetFieldsResult(problemSet, objProblem)
            If problemSet.InsertProblemResult() Then
                status = NotifyType.IsSuccess
            End If
        Catch ex As Exception
            status = NotifyType.IsError
        End Try
        state = GetStateData(status)
        Return state
    End Function

    Public Sub SetFieldsResult(ByRef objResult As Object, objData As Object)
        Dim objProblem As Problem = DirectCast(objData, Problem)
        Dim problemData As New ProblemSet

        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.ResultDescr = objProblem.ResultDescr
        problemData.ResultValue = objProblem.ResultValue

        objResult = problemData
    End Sub

    Public Function GetMappedFieldsResult(objData As Object) As Object
        Dim objProblem As ProblemSet = DirectCast(objData, ProblemSet)
        Dim problemData As New Problem

        problemData.ResultID = objProblem.ResultID
        problemData.ProblemID = objProblem.ProblemID
        problemData.OptionID = objProblem.OptionID
        problemData.ResultDescr = objProblem.ResultDescr
        problemData.ResultValue = objProblem.ResultValue

        Return problemData
    End Function
#End Region
End Class
