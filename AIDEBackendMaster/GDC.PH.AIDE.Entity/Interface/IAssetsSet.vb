Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAssetsSet
    Property ASSET_ID As Integer
    Property TRANSFER_ID As Integer
    Property PREVIOUS_ID As Integer
    Property PREVIOUS_OWNER As String
    Property EMP_ID As Integer
    Property ASSET_DESC As String
    Property MANUFACTURER As String
    Property MODEL_NO As String
    Property SERIAL_NO As String
    Property ASSET_TAG As String
    Property DATE_PURCHASED As DateTime
    Property STATUS As String
    Property OTHER_INFO As String
    Property COMMENTS As String
    Property FULL_NAME As String
    Property DEPARTMENT As String
    Property DATE_ASSIGNED As DateTime
    Property ASSIGNED_TO As String
    Property APPROVAL As Integer
    Property TABLE_NAME As String
    Property STATUS_DESCR As String
    Property Nick_Name As String
    Property ToDisplay As Integer
    Property First_Name As String
    Property Employee_Name As String
    Property TRANS_FG As Integer
    Property DATE_BORROWED As DateTime
    Property DATE_RETURNED As DateTime
    Property ASSET_BORROWING_ID As Integer

    Function GetMyAssets(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllDeletedAssetsByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsBySearch(ByVal empID As Integer, ByVal input As String) As List(Of AssetsSet)
    Function InsertAssets(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssets(ByVal assets As AssetsSet) As Boolean
    Function DeleteAsset(ByVal assets As AssetsSet) As Boolean
    Function GetAllAssetsInventoryByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsBorrowingByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsBorrowingRequestByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsReturnsByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAssetBorrowersLog(ByVal empID As Integer, ByVal assetID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsInventoryUnApproved(ByVal empID As Integer) As List(Of AssetsSet)
    Function InsertAssetsInventory(ByVal assets As AssetsSet) As Boolean
    Function InsertAssetsBorrowing(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventory(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventoryApproval(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventoryCancel(ByVal assets As AssetsSet) As Boolean
    Function GetAllAssetsUnAssigned(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsHistory(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsHistoryBySearch(ByVal empID As Integer, ByVal input As String) As List(Of AssetsSet)
    Function GetAllAssetsInventoryBySearch(ByVal empID As Integer, ByVal input As String, ByVal page As String) As List(Of AssetsSet)
    Function GetAssetManufacturer() As List(Of AssetsSet)
    Function GetAssetDescription() As List(Of AssetsSet)
    Function GetAllManagersByDeptorDiv(ByVal deptID As Integer, ByVal divID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsCustodian(ByVal empID As Integer) As List(Of AssetsSet)
End Interface
