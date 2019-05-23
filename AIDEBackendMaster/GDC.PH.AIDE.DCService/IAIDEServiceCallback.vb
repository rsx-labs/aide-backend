Public Interface IAIDEServiceCallback
    <OperationContract(IsOneWay:=True)>
    Sub NotifySuccess(ByVal message As String)
    <OperationContract(IsOneWay:=True)>
    Sub NotifyError(ByVal message As String)
    <OperationContract(IsOneWay:=True)>
    Sub NotifyPresent(ByVal EmployeeName As String)
    <OperationContract(IsOneWay:=True)>
    Sub NotifyOffline(ByVal EmployeeName As String)
    <OperationContract(IsOneWay:=True)>
    Sub NotifyUpdate(ByVal objData As Object)
End Interface
