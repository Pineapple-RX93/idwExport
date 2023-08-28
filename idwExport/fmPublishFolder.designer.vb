<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmPublishFolder
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmPublishFolder))
    Me.PDFCheckBox = New System.Windows.Forms.CheckBox()
    Me.DWGCheckBox = New System.Windows.Forms.CheckBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btExport = New System.Windows.Forms.Button()
    Me.btCancel = New System.Windows.Forms.Button()
        Me.DXFCheckBox = New System.Windows.Forms.CheckBox()
        Me.WebCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'PDFCheckBox
        '
        Me.PDFCheckBox.AutoSize = True
        Me.PDFCheckBox.Checked = True
        Me.PDFCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PDFCheckBox.Location = New System.Drawing.Point(12, 65)
        Me.PDFCheckBox.Name = "PDFCheckBox"
        Me.PDFCheckBox.Size = New System.Drawing.Size(80, 17)
        Me.PDFCheckBox.TabIndex = 0
        Me.PDFCheckBox.Text = "Export PDF"
        Me.PDFCheckBox.UseVisualStyleBackColor = True
        '
        'DWGCheckBox
        '
        Me.DWGCheckBox.AutoSize = True
        Me.DWGCheckBox.Location = New System.Drawing.Point(98, 65)
        Me.DWGCheckBox.Name = "DWGCheckBox"
        Me.DWGCheckBox.Size = New System.Drawing.Size(86, 17)
        Me.DWGCheckBox.TabIndex = 1
        Me.DWGCheckBox.Text = "Export DWG"
        Me.DWGCheckBox.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(408, 20)
        Me.TextBox1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select folder to export"
        '
        'btExport
        '
        Me.btExport.Location = New System.Drawing.Point(12, 88)
        Me.btExport.Name = "btExport"
        Me.btExport.Size = New System.Drawing.Size(75, 23)
        Me.btExport.TabIndex = 4
        Me.btExport.Text = "Export"
        Me.btExport.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(345, 88)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 5
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'DXFCheckBox
        '
        Me.DXFCheckBox.AutoSize = True
        Me.DXFCheckBox.Checked = True
        Me.DXFCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.DXFCheckBox.Location = New System.Drawing.Point(190, 65)
        Me.DXFCheckBox.Name = "DXFCheckBox"
        Me.DXFCheckBox.Size = New System.Drawing.Size(80, 17)
        Me.DXFCheckBox.TabIndex = 2
        Me.DXFCheckBox.Text = "Export DXF"
        Me.DXFCheckBox.UseVisualStyleBackColor = True
        '
        'WebCheckBox
        '
        Me.WebCheckBox.AutoSize = True
        Me.WebCheckBox.Checked = True
        Me.WebCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WebCheckBox.Location = New System.Drawing.Point(276, 65)
        Me.WebCheckBox.Name = "WebCheckBox"
        Me.WebCheckBox.Size = New System.Drawing.Size(82, 17)
        Me.WebCheckBox.TabIndex = 7
        Me.WebCheckBox.Text = "Export Web"
        Me.WebCheckBox.UseVisualStyleBackColor = True
        '
        'fmPublishFolder
        '
        Me.AcceptButton = Me.btExport
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(432, 124)
        Me.Controls.Add(Me.WebCheckBox)
        Me.Controls.Add(Me.DXFCheckBox)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btExport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DWGCheckBox)
        Me.Controls.Add(Me.PDFCheckBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmPublishFolder"
        Me.Text = "IDW Export"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PDFCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents DWGCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btExport As System.Windows.Forms.Button
  Friend WithEvents btCancel As System.Windows.Forms.Button

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

    Friend WithEvents DXFCheckBox As Windows.Forms.CheckBox
    Friend WithEvents WebCheckBox As Windows.Forms.CheckBox
End Class
