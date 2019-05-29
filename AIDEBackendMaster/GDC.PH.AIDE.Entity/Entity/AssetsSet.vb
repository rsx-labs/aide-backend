Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.Entity
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient

Public Class AssetsSet

    Implements IAssetsSet, INotifyPropertyChanged

    Private cAssets As clsAssets
    Private cAssetsFactory As clsAssetsFactory

    Public Sub New()
        cAssets = New clsAssets()
        cAssetsFactory = New clsAssetsFactory()
    End Sub

    Public Sub New(ByVal objAssets As clsAssets)
        cAssets = objAssets
        cAssetsFactory = New clsAssetsFactory()
    End Sub

#Region "Properties"
    Public Property ASSET_ID As Integer Implements IAssetsSet.ASSET_ID
        Get
            Return Me.cAssets.ASSET_ID
        End Get
        Set(value As Integer)
            Me.cAssets.ASSET_ID = value
        End Set
    End Property

    Public Property EMP_ID As Integer Implements IAssetsSet.EMP_ID
        Get
            Return Me.cAssets.EMP_ID
        End Get
        Set(value As Integer)
            Me.cAssets.EMP_ID = value
        End Set
    End Property

    Public Property ASSET_DESC As String Implements IAssetsSet.ASSET_DESC
        Get
            Return Me.cAssets.ASSET_DESC
        End Get
        Set(value As String)
            Me.cAssets.ASSET_DESC = value
        End Set
    End Property

    Public Property MANUFACTURER As String Implements IAssetsSet.MANUFACTURER
        Get
            Return Me.cAssets.MANUFACTURER
        End Get
        Set(value As String)
            Me.cAssets.MANUFACTURER = value
        End Set
    End Property

    Public Property MODEL_NO As String Implements IAssetsSet.MODEL_NO
        Get
            Return Me.cAssets.MODEL_NO
        End Get
        Set(value As String)
            Me.cAssets.MODEL_NO = value
        End Set
    End Property

    Public Property SERIAL_NO As String Implements IAssetsSet.SERIAL_NO
        Get
            Return Me.cAssets.SERIAL_NO
        End Get
        Set(value As String)
            Me.cAssets.SERIAL_NO = value
        End Set
    End Property

    Public Property ASSET_TAG As String Implements IAssetsSet.ASSET_TAG
        Get
            Return Me.cAssets.ASSET_TAG
        End Get
        Set(value As String)
            Me.cAssets.ASSET_TAG = value
        End Set
    End Property

    Public Property DATE_PURCHASED As Date Implements IAssetsSet.DATE_PURCHASED
        Get
            Return Me.cAssets.DATE_PURCHASED
        End Get
        Set(value As Date)
            Me.cAssets.DATE_PURCHASED = value
        End Set
    End Property

    Public Property STATUS As String Implements IAssetsSet.STATUS
        Get
            Return Me.cAssets.STATUS
        End Get
        Set(value As String)
            Me.cAssets.STATUS = value
        End Set
    End Property

    Public Property OTHER_INFO As String Implements IAssetsSet.OTHER_INFO
        Get
            Return Me.cAssets.OTHER_INFO
        End Get
        Set(value As String)
            Me.cAssets.OTHER_INFO = value
        End Set
    End Property

    Public Property COMMENTS As String Implements IAssetsSet.COMMENTS
        Get
            Return Me.cAssets.COMMENTS
        End Get
        Set(value As String)
            Me.cAssets.COMMENTS = value
        End Set
    End Property

    Public Property FULL_NAME As String Implements IAssetsSet.FULL_NAME
        Get
            Return Me.cAssets.FULL_NAME
        End Get
        Set(value As String)
            Me.cAssets.FULL_NAME = value
        End Set
    End Property

    Public Property DEPARTMENT As String Implements IAssetsSet.DEPARTMENT
        Get
            Return Me.cAssets.DEPARTMENT
        End Get
        Set(value As String)
            Me.cAssets.DEPARTMENT = value
        End Set
    End Property

    Public Property DATE_ASSIGNED As Date Implements IAssetsSet.DATE_ASSIGNED
        Get
            Return Me.cAssets.DATE_ASSIGNED
        End Get
        Set(value As Date)
            Me.cAssets.DATE_ASSIGNED = value
        End Set
    End Property

    Public Property ASSIGNED_TO As String Implements IAssetsSet.ASSIGNED_TO
        Get
            Return Me.cAssets.ASSIGNED_TO
        End Get
        Set(value As String)
            Me.cAssets.ASSIGNED_TO = value
        End Set
    End Property

    Public Property APPROVAL As Integer Implements IAssetsSet.APPROVAL
        Get
            Return Me.cAssets.APPROVAL
        End Get
        Set(value As Integer)
            Me.cAssets.APPROVAL = value
        End Set
    End Property

    Public Property TABLE_NAME As String Implements IAssetsSet.TABLE_NAME
        Get
            Return Me.cAssets.TABLE_NAME
        End Get
        Set(value As String)
            Me.cAssets.TABLE_NAME = value
        End Set
    End Property

    Public Property STATUS_DESCR As String Implements IAssetsSet.STATUS_DESCR
        Get
            Return Me.cAssets.STATUS_DESCR
        End Get
        Set(value As String)
            Me.cAssets.STATUS_DESCR = value
        End Set
    End Property

#End Region

#Region "Sql Functions"
    Public Function GetAllAssetsByEmpID(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsByEmpID
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsByEmpID(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetMyAssets(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetMyAssets
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetMyAssets(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAllAssetsBySearch(empID As Integer, input As String) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsBySearch
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsBySearch(empID, input)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function InsertAssets(assets As AssetsSet) As Boolean Implements IAssetsSet.InsertAssets
        Try
            Return Me.cAssetsFactory.InsertAssets(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAssets(assets As AssetsSet) As Boolean Implements IAssetsSet.UpdateAssets
        Try
            Return Me.cAssetsFactory.UpdateAssets(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetAllAssetsInventoryByEmpID(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsInventoryByEmpID
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsInventoryByEmpID(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAllAssetsInventoryUnApproved(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsInventoryUnApproved
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsInventoryUnApproved(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function InsertAssetsInventory(assets As AssetsSet) As Boolean Implements IAssetsSet.InsertAssetsInventory
        Try
            Return Me.cAssetsFactory.InsertAssetsInventory(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Insert Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetAllAssetsUnAssigned(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsUnAssigned
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsUnAssigned(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function UpdateAssetsInventory(assets As AssetsSet) As Boolean Implements IAssetsSet.UpdateAssetsInventory
        Try
            Return Me.cAssetsFactory.UpdateAssetsInventory(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAssetsInventoryApproval(assets As AssetsSet) As Boolean Implements IAssetsSet.UpdateAssetsInventoryApproval
        Try
            Return Me.cAssetsFactory.UpdateAssetsInventoryApproval(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function UpdateAssetsInventoryCancel(assets As AssetsSet) As Boolean Implements IAssetsSet.UpdateAssetsInventoryCancel
        Try
            Return Me.cAssetsFactory.UpdateAssetsInventoryCancel(cAssets)
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed!")
            Else
                Throw New UpdateFailedException("Update Success Register Failed!")
            End If
        End Try
    End Function

    Public Function GetAllAssetsHistory(empID As Integer) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsHistory
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsHistory(empID)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAllAssetsHistoryBySearch(empID As Integer, input As String) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsHistoryBySearch
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsHistoryBySearch(empID, input)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAllAssetsInventoryBySearch(empID As Integer, input As String, page As String) As List(Of AssetsSet) Implements IAssetsSet.GetAllAssetsInventoryBySearch
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAllAssetsInventoryBySearch(empID, input, page)

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAssetManufacturer() As List(Of AssetsSet) Implements IAssetsSet.GetAssetManufacturer
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAssetManufacturer()

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function

    Public Function GetAssetDescription() As List(Of AssetsSet) Implements IAssetsSet.GetAssetDescription
        Dim cList As List(Of clsAssets)
        Dim cListSet As New List(Of AssetsSet)
        Try

            cList = cAssetsFactory.GetAssetDescription()

            If Not IsNothing(cList) Then
                For Each cAssets As clsAssets In cList
                    cListSet.Add(New AssetsSet(cAssets))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return cListSet

        Catch ex As Exception
            If ex.HResult = -2146233088 Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw New RetrieveFailedException("Retrieving Failed")

            End If
            Console.WriteLine("Error encountered.." & ex.Message.ToString())
            Return Nothing
        End Try
    End Function
#End Region

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
End Class
