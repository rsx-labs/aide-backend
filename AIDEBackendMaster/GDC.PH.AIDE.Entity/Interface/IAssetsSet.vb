Imports GDC.PH.AIDE.BusinessLayer
Public Interface IAssetsSet
    Property ASSET_ID As Integer
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


    Function GetMyAssets(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsBySearch(ByVal empID As Integer, ByVal input As String) As List(Of AssetsSet)
    Function InsertAssets(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssets(ByVal assets As AssetsSet) As Boolean
    Function GetAllAssetsInventoryByEmpID(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsInventoryUnApproved(ByVal empID As Integer) As List(Of AssetsSet)
    Function InsertAssetsInventory(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventory(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventoryApproval(ByVal assets As AssetsSet) As Boolean
    Function UpdateAssetsInventoryCancel(ByVal assets As AssetsSet) As Boolean
    Function GetAllAssetsUnAssigned(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsHistory(ByVal empID As Integer) As List(Of AssetsSet)
    Function GetAllAssetsHistoryBySearch(ByVal empID As Integer, ByVal input As String) As List(Of AssetsSet)
    Function GetAllAssetsInventoryBySearch(ByVal empID As Integer, ByVal input As String, ByVal page As String) As List(Of AssetsSet)
    Function GetAssetManufacturer() As List(Of AssetsSet)
    Function GetAssetDescription() As List(Of AssetsSet)
End Interface
