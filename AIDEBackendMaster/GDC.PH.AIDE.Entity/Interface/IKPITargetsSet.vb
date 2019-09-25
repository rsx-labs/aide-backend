Imports GDC.PH.AIDE.BusinessLayer
Public Interface IKPITargetsSet
    Property Id As Integer
    Property Emp_Id As Integer
    Property FYStart As Date
    Property FYEnd As Date
    Property KPIReferenceNo As String
    Property Description As String
    Property Subject As String
    Property CreateDate As Date

    Function GetKPITargetById(ByVal Id As Integer) As List(Of IKPITargetsSet)
    Function GetKPITargetByFiscalYear(ByVal EmpId As Integer, ByVal FYear As Date) As List(Of IKPITargetsSet)
    Function InsertKPITargets() As Boolean
    Function UpdateKPITargets() As Boolean

End Interface
