Public Class fmPublishFolder

  Friend oApp As Inventor.Application
  Friend Path As String
  Friend PDF As Boolean
  Friend DWG As Boolean
  Private DLLPath As String
  Private DLLName As String

  Private Sub TextBox1_Click(sender As Object, e As Windows.Forms.MouseEventArgs) Handles TextBox1.MouseClick
    Dim folderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Dim oDoc As Inventor.Document
    Dim folderName As String = " "
    Dim DrawingName As String = " "

    folderBrowserDialog1 = New Windows.Forms.FolderBrowserDialog()
    folderBrowserDialog1.Description = _
    "Select the folder with idw you want to export"

    ' Do not allow the user to create New files via the FolderBrowserDialog. 
    folderBrowserDialog1.ShowNewFolderButton = False
    PDF = PDFCheckBox.Checked
    DWG = DWGCheckBox.Checked
    oDoc = oApp.ActiveDocument
    Dim DrawingFullName As String = oDoc.FullFileName
    'MsgBox("<" + DrawingFullName + ">")
    If DrawingFullName = "" Then
      folderBrowserDialog1.SelectedPath = oApp.DesignProjectManager.ActiveDesignProject.WorkspacePath
    Else
      ClsFilename.SplitPath(DrawingFullName, folderName, DrawingName)
      folderBrowserDialog1.SelectedPath = folderName
    End If
    'MsgBox("<" + folderBrowserDialog1.RootFolder + ">")

    Dim result As Windows.Forms.DialogResult = folderBrowserDialog1.ShowDialog()
    'MsgBox("<" + result + ">")

    If (result = Windows.Forms.DialogResult.OK) Then
      Path = folderBrowserDialog1.SelectedPath
      TextBox1.Text = Path
    Else
      Path = ""
    End If
  End Sub

  Private Sub BtCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
    Path = ""
    PDF = PDFCheckBox.Checked
    DWG = DWGCheckBox.Checked
    Close()
  End Sub

  Private Sub BtExport_Click(sender As Object, e As EventArgs) Handles btExport.Click
    'Publish.Folder(oApp, Path, PDF, DWG)
    PDF = PDFCheckBox.Checked
    DWG = DWGCheckBox.Checked
    Close()
  End Sub

  Private Sub DWGCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles DWGCheckBox.CheckedChanged
    If Not PDFCheckBox.Checked Then
      DWGCheckBox.Checked = True
    End If
  End Sub

  Private Sub PDFCheckBox_CheckStateChanged(sender As Object, e As EventArgs) Handles PDFCheckBox.CheckStateChanged
    If Not DWGCheckBox.Checked Then
      PDFCheckBox.Checked = True
    End If
  End Sub

  Public Sub New(ByVal addInSiteObject As Inventor.ApplicationAddInSite)

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    ' Get Addin PAth, look for DWGOut.ini
    DLLPath = " "
    DLLName = " "
    oApp = addInSiteObject.Application
    ClsFilename.SplitPath(addInSiteObject.Parent.Location, DLLPath, DLLName)
  End Sub

  Private Sub FmPublishFolder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    Dim oDoc As Inventor.Document = oApp.ActiveDocument
    Dim folderName As String = " "
    Dim DrawingName As String = " "
    Dim DrawingFullName As String = oDoc.FullFileName

    'MsgBox("<" + DrawingFullName + ">")
    If DrawingFullName <> "" Then
      ClsFilename.SplitPath(DrawingFullName, folderName, DrawingName)
      TextBox1.Text = folderName
      Path = folderName
    End If

  End Sub
End Class