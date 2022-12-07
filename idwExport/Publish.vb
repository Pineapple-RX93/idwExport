Imports Inventor

Friend Module Publish
  Friend DLLPath As String

  Public Sub PDF(oApp As Application)
    ' Get the PDF translator Add-In.
    Dim PDFAddIn As TranslatorAddIn
    PDFAddIn = oApp.ApplicationAddIns.ItemById("{0AC6FD96-2F4D-42CE-8BE0-8AEA580399E4}")
    ' MsgBox(PDFAddIn.DisplayName)
    'Set a reference to the active document (the document to be published).
    Dim oDocument As Document
    oDocument = oApp.ActiveDocument
    ' MsgBox(oDocument.DisplayName)
    Dim oContext As TranslationContext
    oContext = oApp.TransientObjects.CreateTranslationContext
    oContext.Type = IOMechanismEnum.kFileBrowseIOMechanism

    ' Create a NameValueMap object
    Dim oOptions As NameValueMap
    oOptions = oApp.TransientObjects.CreateNameValueMap

    ' Create a DataMedium object
    Dim oDataMedium As DataMedium
    oDataMedium = oApp.TransientObjects.CreateDataMedium

    ' Check whether the translator has 'SaveCopyAs' options
    If PDFAddIn.HasSaveCopyAsOptions(oDocument, oContext, oOptions) Then

      ' Options for drawings...

      oOptions.Value("All_Color_AS_Black") = 0
      oOptions.Value("Remove_Line_Weights") = 0
      ' Resolutions: 150, 200, 300, 400, 600, 720, 1200, 2400, 4800
      oOptions.Value("Vector_Resolution") = 2400
      oOptions.Value("Sheet_Range") = PrintRangeEnum.kPrintAllSheets
      'oOptions.Value("Custom_Begin_Sheet") = 2
      'oOptions.Value("Custom_End_Sheet") = 4

    End If

    Dim DrawingName As String
    DrawingName = " "
    Dim DrawingPath As String
    DrawingPath = " "
    Dim DrawingFullName As String
    DrawingFullName = oDocument.FullFileName
    ' MsgBox(DrawingFullName + " " + DrawingPath + " " + DrawingName)
    If DrawingFullName = "" Then
      MsgBox("Please save Drawing File before export.")
    Else
      ClsFilename.SplitPath(DrawingFullName, DrawingPath, DrawingName)

      'Check if folder exist, create if not
      On Error Resume Next

      My.Computer.FileSystem.CreateDirectory(DrawingPath + "PDF")

      'Set the destination file name
      oDataMedium.FileName = DrawingPath + "PDF\" + DrawingName + ".pdf"

      'Publish document.
      PDFAddIn.SaveCopyAs(oDocument, oContext, oOptions, oDataMedium)
      ' MsgBox("PDF: " + DrawingPath + "PDF\" + DrawingName + ".pdf" + " Exported")
    End If
  End Sub

  Public Sub DWG(oApp As Application)
    ' Get the DWG translator Add-In.

    Dim DWGAddIn As TranslatorAddIn = oApp.ApplicationAddIns.ItemById("{C24E3AC2-122E-11D5-8E91-0010B541CD80}")

    'Set a reference to the active document (the document to be published).
    Dim oDocument As Document = oApp.ActiveDocument

    Dim oContext As TranslationContext = oApp.TransientObjects.CreateTranslationContext
    oContext.Type = Inventor.IOMechanismEnum.kFileBrowseIOMechanism

    ' Create a NameValueMap object
    Dim oOptions As NameValueMap = oApp.TransientObjects.CreateNameValueMap

    ' Create a DataMedium object
    Dim oDataMedium As DataMedium = oApp.TransientObjects.CreateDataMedium

    ' Check whether the translator has 'SaveCopyAs' options
    If DWGAddIn.HasSaveCopyAsOptions(oDocument, oContext, oOptions) Then

      Dim strIniFile As String = DLLPath & "DWGOut.ini"
      'MsgBox(strIniFile)
      ' Create the name-value that specifies the ini file to use.
      oOptions.Value("Export_Acad_IniFile") = strIniFile
    End If

    Dim DrawingName As String = " "
    Dim DrawingPath As String = " "
    Dim DrawingFullName As String = oDocument.FullFileName

    If DrawingFullName = "" Then
      MsgBox("Please save Drawing File before export.")
    Else
      ClsFilename.SplitPath(DrawingFullName, DrawingPath, DrawingName)

      'Check if folder exist, create if not
      On Error Resume Next
      My.Computer.FileSystem.CreateDirectory(DrawingPath + "DWG")

      'Set the destination file name
      oDataMedium.FileName = DrawingPath + "DWG\" + DrawingName + ".dwg"

      'Publish document.
      Call DWGAddIn.SaveCopyAs(oDocument, oContext, oOptions, oDataMedium)
      ' MsgBox("DWG: " + DrawingPath + "DWG\" + DrawingName + ".DWG" + " Exported")
    End If
  End Sub

  Public Sub Folder(oApp As Application, Path As String, PDF As Boolean, DWG As Boolean)
    Dim oDoc As Document
    Dim folderName As String = " "

    ' Default to the Project folder. 
    folderName = Path
    My.Computer.FileSystem.CurrentDirectory = folderName
    'MsgBox(folderName)
    For Each foundFile As String In My.Computer.FileSystem.GetFiles(
      folderName, FileIO.SearchOption.SearchTopLevelOnly, "*.idw")
      oDoc = oApp.Documents.Open(foundFile)
      If PDF Then Publish.PDF(oApp)
      If DWG Then Publish.DWG(oApp)
      oDoc.Close()
      'MsgBox(foundFile)
    Next

  End Sub

End Module
