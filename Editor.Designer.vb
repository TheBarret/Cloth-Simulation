<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editor
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
        Me.components = New System.ComponentModel.Container()
        Me.Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Canvas = New Sandbox.Canvas()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbAmp = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbDamp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbMass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbStiffness = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdRun = New System.Windows.Forms.Button()
        Me.tbBreak = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbSRange = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbBreaker = New System.Windows.Forms.CheckBox()
        Me.sFreq = New System.Windows.Forms.TrackBar()
        CType(Me.sFreq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Clock
        '
        Me.Clock.Interval = 50
        '
        'Canvas
        '
        Me.Canvas.Location = New System.Drawing.Point(12, 12)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Size = New System.Drawing.Size(520, 520)
        Me.Canvas.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(719, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Amplitude"
        '
        'tbAmp
        '
        Me.tbAmp.Location = New System.Drawing.Point(722, 169)
        Me.tbAmp.Name = "tbAmp"
        Me.tbAmp.Size = New System.Drawing.Size(59, 20)
        Me.tbAmp.TabIndex = 6
        Me.tbAmp.Text = "5"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(538, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Frequency"
        '
        'tbDamp
        '
        Me.tbDamp.Location = New System.Drawing.Point(541, 28)
        Me.tbDamp.Name = "tbDamp"
        Me.tbDamp.Size = New System.Drawing.Size(59, 20)
        Me.tbDamp.TabIndex = 8
        Me.tbDamp.Text = "0.8"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(538, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Damp"
        '
        'tbMass
        '
        Me.tbMass.Location = New System.Drawing.Point(609, 28)
        Me.tbMass.Name = "tbMass"
        Me.tbMass.Size = New System.Drawing.Size(59, 20)
        Me.tbMass.TabIndex = 10
        Me.tbMass.Text = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(606, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mass"
        '
        'tbStiffness
        '
        Me.tbStiffness.Location = New System.Drawing.Point(675, 28)
        Me.tbStiffness.Name = "tbStiffness"
        Me.tbStiffness.Size = New System.Drawing.Size(59, 20)
        Me.tbStiffness.TabIndex = 12
        Me.tbStiffness.Text = "0.2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(672, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Stiffness"
        '
        'cmdRun
        '
        Me.cmdRun.Location = New System.Drawing.Point(541, 499)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(240, 33)
        Me.cmdRun.TabIndex = 13
        Me.cmdRun.Text = "Run"
        Me.cmdRun.UseVisualStyleBackColor = True
        '
        'tbBreak
        '
        Me.tbBreak.Location = New System.Drawing.Point(541, 67)
        Me.tbBreak.Name = "tbBreak"
        Me.tbBreak.Size = New System.Drawing.Size(59, 20)
        Me.tbBreak.TabIndex = 15
        Me.tbBreak.Text = "20"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(538, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Break"
        '
        'tbSRange
        '
        Me.tbSRange.Location = New System.Drawing.Point(609, 67)
        Me.tbSRange.Name = "tbSRange"
        Me.tbSRange.Size = New System.Drawing.Size(59, 20)
        Me.tbSRange.TabIndex = 17
        Me.tbSRange.Text = "0.2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(606, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "S-Range"
        '
        'cbBreaker
        '
        Me.cbBreaker.AutoSize = True
        Me.cbBreaker.Location = New System.Drawing.Point(541, 476)
        Me.cbBreaker.Name = "cbBreaker"
        Me.cbBreaker.Size = New System.Drawing.Size(93, 17)
        Me.cbBreaker.TabIndex = 18
        Me.cbBreaker.Text = "Stop on break"
        Me.cbBreaker.UseVisualStyleBackColor = True
        '
        'sFreq
        '
        Me.sFreq.Location = New System.Drawing.Point(541, 106)
        Me.sFreq.Minimum = 1
        Me.sFreq.Name = "sFreq"
        Me.sFreq.Size = New System.Drawing.Size(240, 45)
        Me.sFreq.TabIndex = 19
        Me.sFreq.Value = 1
        '
        'Editor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(793, 546)
        Me.Controls.Add(Me.sFreq)
        Me.Controls.Add(Me.cbBreaker)
        Me.Controls.Add(Me.tbSRange)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbBreak)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdRun)
        Me.Controls.Add(Me.tbStiffness)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbMass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbDamp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbAmp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Canvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Editor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editor"
        CType(Me.sFreq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Clock As Timer
    Friend WithEvents Canvas As Canvas
    Friend WithEvents Label2 As Label
    Friend WithEvents tbAmp As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbDamp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbMass As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbStiffness As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdRun As Button
    Friend WithEvents tbBreak As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbSRange As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbBreaker As CheckBox
    Friend WithEvents sFreq As TrackBar
End Class
