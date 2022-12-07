Imports Inventor

Module Module1
'Export DXF from Flat Pattern

'Code by @ClintBrown3D originally posted at https://clintbrown.co.uk/DXF
'Set your filepath here:
SETFilePath = "C:\Temp"

Dim partDoc As PartDocument
  If ThisApplication.ActiveDocument.DocumentType <> kPartDocumentObject Then
MessageBox.Show ("Please open a part document", "iLogic")
End If

  'Check for flat pattern >> create one if needed
  Dim oDoc As PartDocument
oDoc = ThisApplication.ActiveDocument
Dim oCompDef As SheetMetalComponentDefinition
oCompDef = oDoc.ComponentDefinition
If oCompDef.HasFlatPattern = False Then
oCompDef.Unfold

Else
oCompDef.FlatPattern.Edit
End If

  'DXF Settings
  Dim sOut As String
  Dim sPATH As String
sOut = "FLAT PATTERN DXF?AcadVersion=2000&OuterProfileLayer=IV_INTERIOR_PROFILES"
Dim sFname As String
sFname = SETFilePath & "\" & ThisDoc.FileName(False) & ".dxf"

'Export the DXF and fold the model back up
oCompDef.DataIO.WriteDataToFile( sOut, sFname)
Dim oSMDef As SheetMetalComponentDefinition
oSMDef = oDoc.ComponentDefinition
oSMDef.FlatPattern.ExitEdit

'ThisApplication.StatusBarText = "@ClintBrown3D:  DXF saved to: " & sFname
MessageBox.Show("DXF saved to: " & sFname, "@ClintBrown3D:     Success!")

End Module
