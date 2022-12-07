Imports Inventor
Imports System.Runtime.InteropServices
'Imports Microsoft.Win32

Namespace idwExport
  <ProgId("idwExport.StandardAddInServer"),
  Guid("3bc1b654-b648-4173-9af6-1d459b782c1c")>
  Public Class StandardAddInServer
    Implements ApplicationAddInServer

#Region "Data"
    ' Inventor application object.
    Private m_inventorApplication As Application
    Private addInObj As ApplicationAddInSite

    'For adding Toolbar Buttons
    Private m_AddInCLSID As String
    Private WithEvents M_PDFOutButtonDef As ButtonDefinition
    Private WithEvents M_DWGOutButtonDef As ButtonDefinition
    Private WithEvents M_FolderOutButtonDef As ButtonDefinition
    Private WithEvents M_UserInterfaceEvents As UserInterfaceEvents
    Dim c_Toolbar As String = "idwExportToolbarIntName"
    Dim c_Env As String = "DLxDrawingEnvironment"
#End Region

#Region "ApplicationAddInServer Members"

    Public Sub Activate(ByVal addInSiteObject As ApplicationAddInSite, ByVal firstTime As Boolean
                        ) Implements ApplicationAddInServer.Activate
      Dim DllName As String

      Try
        ' This method is called by Inventor when it loads the AddIn.
        ' The AddInSiteObject provides access to the Inventor Application object.
        ' The FirstTime flag indicates if the AddIn is loaded for the first time.
        ' Initialize AddIn members.
        m_inventorApplication = addInSiteObject.Application
        addInObj = addInSiteObject
        'MsgBox("Loaded")
        ' TODO:  Add ApplicationAddInServer.Activate implementation.
        ' e.g. event initialization, command creation etc.

        'Retrieve the GUID for this class
        Dim AddInCLSID As GuidAttribute
        AddInCLSID = CType(System.Attribute.GetCustomAttribute(GetType(StandardAddInServer), GetType(GuidAttribute)), GuidAttribute)
        m_AddInCLSID = "{" & AddInCLSID.Value & "}"

        ' Set a reference to the user interface events.
        M_UserInterfaceEvents = m_inventorApplication.UserInterfaceManager.UserInterfaceEvents

        ' Define Buttons
        Dim IconSmallIPictureDisp As Object = Type.Missing
        Dim IconLargeIPictureDisp As Object = Type.Missing

        Try
          Dim IconStream As IO.Stream =
            Me.GetType().Assembly.GetManifestResourceStream("idwExport.PDFOut.png")
          Dim IconImage As Drawing.Image = New Drawing.Bitmap(IconStream)

          IconSmallIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
          IconLargeIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
        Catch ex As Exception
        End Try

        M_PDFOutButtonDef = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
          "Export PDF", "idwExportPDFCmdIntName", Inventor.CommandTypesEnum.kQueryOnlyCmdType, m_AddInCLSID,
          "Export PDF", "Export PDF", IconSmallIPictureDisp, IconLargeIPictureDisp)

        M_PDFOutButtonDef.Enabled = True

        Try
          Dim IconStream As System.IO.Stream =
            Me.GetType().Assembly.GetManifestResourceStream("idwExport.DWGOut.png")
          Dim IconImage As System.Drawing.Image = New System.Drawing.Bitmap(IconStream)

          IconSmallIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
          IconLargeIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
        Catch ex As Exception
        End Try

        M_DWGOutButtonDef = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
          "Export DWG", "idwExportDWGCmdIntName", Inventor.CommandTypesEnum.kQueryOnlyCmdType, m_AddInCLSID,
          "Export DWG", "Export DWG", IconSmallIPictureDisp, IconLargeIPictureDisp)

        M_DWGOutButtonDef.Enabled = True

        Try
          Dim IconStream As System.IO.Stream =
            Me.GetType().Assembly.GetManifestResourceStream("idwExport.publishfolder.png")
          Dim IconImage As System.Drawing.Image = New System.Drawing.Bitmap(IconStream)

          IconSmallIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
          IconLargeIPictureDisp = PictureDispConverter.ToIPictureDisp(IconImage)
        Catch ex As Exception
        End Try

        M_FolderOutButtonDef = m_inventorApplication.CommandManager.ControlDefinitions.AddButtonDefinition(
          "Export Folder", "idwExportFolderCmdIntName", Inventor.CommandTypesEnum.kQueryOnlyCmdType, m_AddInCLSID,
          "Export Folder", "Export Folder", IconSmallIPictureDisp, IconLargeIPictureDisp)

        M_FolderOutButtonDef.Enabled = True

        'create the command category
        'Dim CommandCategory As Inventor.CommandCategory
        'CommandCategory = m_inventorApplication.CommandManager.CommandCategories.Add(
        '  "idwExport", "idwExportCatIntName", m_AddInCLSID)

        'if AddIn is called first time, create toolbar and add button to toolbar
        'CommandCategory.Add(m_ButtonDef)
        'Dim CommandBar As Inventor.CommandBar
        'Dim Environment As Inventor.Environment
        'If firstTime = True Then

        'create a new toolbar
        'CommandBar = m_inventorApplication.UserInterfaceManager.CommandBars.Add(
        '  "idwExport", c_Toolbar, , m_AddInCLSID)

        'add the button to the toolbar
        'CommandBar.Controls.AddButton(m_ButtonDef)

        ' Get the Inventor environment base object.
        'Environment = m_inventorApplication.UserInterfaceManager.Environments.Item("PMxPartEnvironment")

        ' Make this command bar accessable in the panel menu for the Inventor main frame environment.
        'Environment.PanelBar.CommandBarList.Add(CommandBar)

        'End If
        DLLPath = " "
        DllName = " "
        ClsFilename.SplitPath(addInSiteObject.Parent.Location, DLLPath, DllName)

        If firstTime = True Then
          RibbonSetup()
        End If

      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub RibbonSetup()
      ' Set a reference to the user interface manager.
      Dim oUIManager As UserInterfaceManager
      oUIManager = m_inventorApplication.UserInterfaceManager

      ' Get the ribbon associated with part documents
      Dim oRibbon As Ribbon
      oRibbon = oUIManager.Ribbons.Item("Drawing")

      ' Create a new tab
      Dim oTab As RibbonTab
      oTab = oRibbon.RibbonTabs.Item("id_TabPlaceViews")

      ' Create a new panel within the tab
      Dim oPanel As RibbonPanel
      oPanel = oTab.RibbonPanels.Add("idw Export", "id_PanelA_BWM", m_AddInCLSID)

      ' Create a control within the panel
      Call oPanel.CommandControls.AddButton(M_PDFOutButtonDef, True)
      Call oPanel.CommandControls.AddButton(M_DWGOutButtonDef, True)
      Call oPanel.CommandControls.AddButton(M_FolderOutButtonDef, True)

      oTab = oRibbon.RibbonTabs.Item("id_TabAnnotate")
      oPanel = oTab.RibbonPanels.Add("idw Export", "id_PanelA_BWM", m_AddInCLSID)
      Call oPanel.CommandControls.AddButton(M_PDFOutButtonDef, True)
      Call oPanel.CommandControls.AddButton(M_DWGOutButtonDef, True)
      Call oPanel.CommandControls.AddButton(M_FolderOutButtonDef, True)

    End Sub

    Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

      ' This method is called by Inventor when the AddIn is unloaded.
      ' The AddIn will be unloaded either manually by the user or
      ' when the Inventor session is terminated.

      ' TODO:  Add ApplicationAddInServer.Deactivate implementation
      'Try

      ' Release objects.
      M_PDFOutButtonDef.Delete()
      M_PDFOutButtonDef = Nothing
      M_DWGOutButtonDef.Delete()
      M_DWGOutButtonDef = Nothing
      'Marshal.ReleaseComObject(m_inventorApplication)
      m_inventorApplication = Nothing
      GC.WaitForPendingFinalizers()
      GC.Collect()
      'Catch ex As Exception
      'System.Windows.Forms.MessageBox.Show(ex.ToString())
      'End Try
    End Sub

    Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation

      ' This property is provided to allow the AddIn to expose an API 
      ' of its own to other programs. Typically, this  would be done by
      ' implementing the AddIn's API interface in a class and returning 
      ' that class object through this property.

      Get
        Return Nothing
      End Get

    End Property

    Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand

      ' Note:this method is now obsolete, you should use the 
      ' ControlDefinition functionality for implementing commands.

    End Sub

    Private Sub M_PDFOutButtonDef_OnExecute(ByVal Context As NameValueMap
                                                   ) Handles M_PDFOutButtonDef.OnExecute

      Try
        PDF(m_inventorApplication)
      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub M_DWGOutButtonDef_OnExecute(ByVal Context As NameValueMap
                                               ) Handles M_DWGOutButtonDef.OnExecute

      Try
        DWG(m_inventorApplication)
      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub M_FolderOutButtonDef_OnExecute(Context As NameValueMap) Handles M_FolderOutButtonDef.OnExecute
      Try
        Dim m_Folder_Option_Form = New fmPublishFolder(addInObj)
        'm_Folder_Option_Form.oApp = m_inventorApplication
        m_Folder_Option_Form.ShowDialog()
        If m_Folder_Option_Form.Path <> "" Then
          Folder(m_inventorApplication, m_Folder_Option_Form.Path,
                 m_Folder_Option_Form.PDF, m_Folder_Option_Form.DWG)
        End If
        m_Folder_Option_Form = Nothing
      Catch ex As Exception
        Windows.Forms.MessageBox.Show(ex.ToString())
      End Try

    End Sub

    Private Sub M_UserInterfaceEvents_OnResetRibbonInterface(Context As NameValueMap) Handles M_UserInterfaceEvents.OnResetRibbonInterface
      RibbonSetup()
    End Sub

#End Region

  End Class
End Namespace