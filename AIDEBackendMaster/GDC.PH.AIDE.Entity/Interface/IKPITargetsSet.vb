Imports GDC.PH.AIDE.BusinessLayer
Public Interface IKPITargetsSet
    Property Id As Integer
    Property FYStart As Date
    Property FYEnd As Date
    Property KPIReferenceNo As String
    Property Description As String
    Property Subject As String
    Property CreateDate As Date

    Function GetKPITargetById(ByVal Id As Integer) As List(Of IKPITargetsSet)
    Function GetKPITargetByFiscalYear(ByVal FYear As Date) As List(Of IKPITargetsSet)
    Function InsertKPITargets(ByVal kpiTargets As IKPITargetsSet) As Boolean
    Function UpdateKPITargets(ByVal kpiTargets As IKPITargetsSet) As Boolean

End Interface
