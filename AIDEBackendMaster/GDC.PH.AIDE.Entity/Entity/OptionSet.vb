Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports GDC.PH.AIDE.BusinessLayer
Imports System.Data.SqlClient
Public Class OptionSet
    Implements IOptionSet, INotifyPropertyChanged

    Private cOption As clsOption
    Private cOptionFactory As clsOptionFactory

    Public Sub New()
        cOption = New clsOption()
        cOptionFactory = New clsOptionFactory()
    End Sub
    Public Sub New(_clsOption As clsOption)
        cOption = _clsOption
        cOptionFactory = New clsOptionFactory()
    End Sub
    Public Property OptionID As Integer Implements IOptionSet.OptionID
        Get
            Return Me.cOption.OPTION_ID
        End Get
        Set(value As Integer)
            Me.cOption.OPTION_ID = value
            NotifyPropertyChanged("OptionID")
        End Set
    End Property

    Public Property ModuleID As Integer Implements IOptionSet.ModuleID
        Get
            Return Me.cOption.MODULE_ID
        End Get
        Set(value As Integer)
            Me.cOption.MODULE_ID = value
            NotifyPropertyChanged("ModuleID")
        End Set
    End Property

    Public Property FunctionID As Integer Implements IOptionSet.FunctionID
        Get
            Return Me.cOption.FUNCTION_ID
        End Get
        Set(value As Integer)
            Me.cOption.FUNCTION_ID = value
            NotifyPropertyChanged("FunctionID")
        End Set
    End Property

    Public Property Description As String Implements IOptionSet.Description
        Get
            Return Me.cOption.DESCRIPTION
        End Get
        Set(value As String)
            Me.cOption.DESCRIPTION = value
            NotifyPropertyChanged("Description")
        End Set
    End Property

    Public Property Value As String Implements IOptionSet.Value
        Get
            Return Me.cOption.VALUE
        End Get
        Set(value As String)
            Me.cOption.VALUE = value
            NotifyPropertyChanged("Value")
        End Set
    End Property

    Public Property ModuleDescr As String Implements IOptionSet.ModuleDescr
        Get
            Return Me.cOption.MODULE_DESCR
        End Get
        Set(value As String)
            Me.cOption.MODULE_DESCR = value
            NotifyPropertyChanged("ModuleDescr")
        End Set
    End Property

    Public Property FunctionDescr As String Implements IOptionSet.FunctionDescr
        Get
            Return Me.cOption.FUNCTION_DESCR
        End Get
        Set(value As String)
            Me.cOption.FUNCTION_DESCR = value
            NotifyPropertyChanged("FunctionDescr")
        End Set
    End Property

    Public Function GetOptions(optionID As Integer, moduleID As Integer, functionID As Integer) As List(Of OptionSet) Implements IOptionSet.GetOptions
        Try
            Dim OptionLst As List(Of clsOption)
            Dim OptionSetLst As New List(Of OptionSet)

            OptionLst = cOptionFactory.GetOptions(optionID, moduleID, functionID)

            If Not IsNothing(OptionLst) Then
                For Each cList As clsOption In OptionLst
                    OptionSetLst.Add(New OptionSet(cList))
                Next
            Else
                Throw New NoRecordFoundException("No records found!")
            End If

            Return OptionSetLst
        Catch ex As Exception
            If (ex.InnerException.GetType() = GetType(SqlException)) Then
                Throw New DatabaseConnExceptionFailed("Database Connection Failed")
            Else
                Throw ex.InnerException
            End If
        End Try
    End Function

    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Private Sub NotifyPropertyChanged(<CallerMemberName> Optional propertyName As [String] = "")
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub


End Class
