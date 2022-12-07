' Usage:
'   Dim mIPictureDisp1 As IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.Tools)
'   Dim mIPictureDisp2 As IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.wbTest)

Imports System.Runtime.InteropServices

Public NotInheritable Class PictureDispConverter

  <DllImport("OleAut32.dll", EntryPoint:="OleCreatePictureIndirect", ExactSpelling:=True, PreserveSig:=False)> _
  Private Shared Function OleCreatePictureIndirect( _
          <MarshalAs(UnmanagedType.AsAny)> _
          ByVal picdesc As Object, _
          ByRef iid As Guid, _
          <MarshalAs(UnmanagedType.Bool)> _
          ByVal fOwn As Boolean) As stdole.IPictureDisp
  End Function

  Shared iPictureDispGuid As Guid = _
      GetType(stdole.IPictureDisp).GUID

  Private NotInheritable Class PICTDESC
    Private Sub New()
    End Sub

    'Picture Types
    Public Const PICTYPE_UNINITIALIZED As Short = -1
    Public Const PICTYPE_NONE As Short = 0
    Public Const PICTYPE_BITMAP As Short = 1
    Public Const PICTYPE_METAFILE As Short = 2
    Public Const PICTYPE_ICON As Short = 3
    Public Const PICTYPE_ENHMETAFILE As Short = 4

    <StructLayout(LayoutKind.Sequential)> _
    Public Class Icon

      Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
      Friend picType As Integer = PICTDESC.PICTYPE_ICON
      Friend hicon As IntPtr = IntPtr.Zero
      Friend unused1 As Integer
      Friend unused2 As Integer

      Friend Sub New(ByVal icon As System.Drawing.Icon)
        hicon = icon.ToBitmap().GetHicon()
      End Sub

    End Class

    <StructLayout(LayoutKind.Sequential)> _
    Public Class Bitmap

      Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(Bitmap))
      Friend picType As Integer = PICTYPE_BITMAP
      Friend hbitmap As IntPtr = IntPtr.Zero
      Friend hpal As IntPtr = IntPtr.Zero
      Friend unused As Integer

      Friend Sub New(ByVal bitmap As Drawing.Bitmap)
        hbitmap = bitmap.GetHbitmap()
      End Sub

    End Class
  End Class

  Public Shared Function ToIPictureDisp(ByVal icon As Drawing.Icon) As stdole.IPictureDisp

    Dim pictIcon As New PICTDESC.Icon(icon)

    Return OleCreatePictureIndirect(pictIcon, iPictureDispGuid, True)

  End Function


  Public Shared Function ToIPictureDisp(ByVal bmp As Drawing.Bitmap) As stdole.IPictureDisp

    Dim pictBmp As New PICTDESC.Bitmap(bmp)

    Return OleCreatePictureIndirect(pictBmp, iPictureDispGuid, True)

  End Function

End Class
