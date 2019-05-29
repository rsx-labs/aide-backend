Imports GDC.PH.AIDE.BusinessLayer

''' <summary>
''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
''' </summary>
''' <remarks></remarks>
Public Interface IConcernSet

#Region "Properties Declaration"
    Property REF_ID As String
    Property CONCERN As String
    Property CAUSE As String
    Property COUNTERMEASURE As String
    Property EMP_ID As String
    Property ACT_REFERENCE As String
    Property DUE_DATE As Date
    Property STATUS As String
    Property GENERATEDREF_ID As String
    Property ACTREF As String
    Property ACT_MESSAGE As String
    Property ACTION_REFERENCES As String
    Property DATE1 As Date
    Property DATE2 As Date
#End Region

#Region "Methods"
    Function selectAllConcern(email As String, offsetVal As Integer, nextVal As Integer) As List(Of ConcernSet)
    Function InsertIntoConcerns(concern As ConcernSet, email As String) As Boolean
    Function GetGeneratedRefNo() As ConcernSet
    Function GetResultSearch(email As String, searchKeyWord As String, offsetVal As Integer, nextVal As Integer) As List(Of ConcernSet)
    Function GetListOfACtion(Ref_Id As String, email As String) As List(Of ConcernSet)
    Function GetListOfACtionsReferences(Ref_id As String) As List(Of ConcernSet)
    Function insertAndDeleteSelectedAction(concern As ConcernSet) As Boolean
    Function UpdateSelectedConcern(concern As ConcernSet) As Boolean
    Function GetBetweenSearchConcern(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of ConcernSet)
    Function GetSearchAction(_keywrodAction As String, Ref_id As String, email As String) As List(Of ConcernSet)
#End Region

End Interface
