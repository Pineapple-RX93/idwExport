Public NotInheritable Class ClsFilename

  Public Shared Sub SplitPath(Fullname As String, ByRef Path As String, ByRef Filename As String)
    Dim PathLength As Integer
    Dim PathEnd As Integer
    Dim i As Integer

    i = 1
    PathLength = Len(Fullname)
    While i <= PathLength
      If Mid(Fullname, i, 1) = "\" Then
        PathEnd = i
      End If
      i = i + 1
    End While
    Path = Left(Fullname, PathEnd)
    Filename = Mid(Fullname, PathEnd + 1, PathLength - PathEnd - 4)
  End Sub

End Class
