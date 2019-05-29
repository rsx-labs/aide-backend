Imports GDC.PH.AIDE.BusinessLayer

''' <summary>
''' By Marivic Espino
''' </summary>
Public Interface ILessonLearnt

    Property ReferenceNo As String
    Property EmployeeID As Integer
    Property Nickname As String
    Property Problem As String
    Property Resolution As String
    Property ActionNo As String

    Function InsertNewLessonLearnt(ByVal lessonLearnt As LessonLearntSet) As Boolean
    Function UpdateLessonLearnt(ByVal lessonLearnt As LessonLearntSet) As Boolean
    Function GetAllLessonLearnts(ByVal email As String) As List(Of LessonLearntSet)
    Function GetLessonLearntsByProblem(ByVal searchProblem As String, ByVal email As String) As List(Of LessonLearntSet)

End Interface
