Imports System.Globalization

Public Class Editor
    Private Const FRAMERATE As Integer = 30
    Public Property Previous As Double
    Public Property Material As Material
    Public Property Simulator As Simulator
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        Me.Material.Frequency = Me.GetFrequency
        Me.Material.Amplitude = Me.GetAmplitude
        Dim current As Double = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
        Me.UpdateSim(CSng((current - Me.Previous) / 1000))
        Me.Previous = current
    End Sub

    Private Sub cmdRun_Click(sender As Object, e As EventArgs) Handles cmdRun.Click
        If (Me.Clock.Enabled) Then Me.StopSim() Else Me.BeginSim()
    End Sub

    Private Sub BeginSim()
        Me.SetGUI(False)
        Me.Clock.Stop()
        Me.Clock.Interval = Editor.FRAMERATE
        Me.Material = Simulator.Create(4, 24, 16, Me.Canvas.ClientRectangle,   'dimension + spacing and bounds
                                       Me.GetDamp, Me.GetMass, Me.GetStiffness, 'damp, mass, stiffness
                                       Me.GetBreak, Me.GetSRng,                 'breakforce, strength randomizer
                                       0F,                                   'assertion force
                                       1.0F, 1.0F,                              'Hz at amplitude
                                       Color.Black,                             'line colors
                                       New Vector2(0, -9.4))                     'gravity factor
        Me.Simulator = New Simulator(Me.Canvas.ClientRectangle, Editor.FRAMERATE, Me.cbBreaker.Checked, Me.Material)
        AddHandler Me.Simulator.SimState, AddressOf Me.EventStateChanged
        Me.Previous = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
        Me.Clock.Start()
    End Sub

    Private Sub EventStateChanged(c As CState)
        Me.StopSim()
    End Sub

    Private Sub StopSim()
        Me.Clock.Stop()
        Me.SetGUI(True)
        RemoveHandler Me.Simulator.SimState, AddressOf Me.EventStateChanged
    End Sub

    Private Sub UpdateSim(dt As Single)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateSim(dt))
        Else
            Using bm As New Bitmap(Me.Canvas.Bounds.Width, Me.Canvas.Bounds.Height)
                Using g As Graphics = Graphics.FromImage(bm)
                    g.ScaleTransform(1.0F, 1.0F)
                    g.Clear(Color.CornflowerBlue)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    Me.Simulator.Update(dt)
                    Me.Simulator.Draw(g)
                End Using
                Me.Canvas.BackgroundImage = CType(bm.Clone, Image)
            End Using
        End If
    End Sub

    Public Function GetFrequency() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetFrequency())
        Else
            Return CSng(Me.sFreq.Value)
        End If
    End Function

    Public Function GetAmplitude() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetAmplitude())
        Else
            Return Me.Adjust(Me.tbAmp.Text)
        End If
    End Function

    Public Function GetDamp() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetDamp())
        Else
            Return Me.Adjust(Me.tbDamp.Text)
        End If
    End Function

    Public Function GetMass() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetMass())
        Else
            Return Me.Adjust(Me.tbMass.Text)
        End If
    End Function

    Public Function GetStiffness() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetStiffness())
        Else
            Return Me.Adjust(Me.tbStiffness.Text)
        End If
    End Function

    Public Function GetBreak() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetBreak())
        Else
            Return Me.Adjust(Me.tbBreak.Text)
        End If
    End Function

    Public Function GetSRng() As Single
        If (Me.InvokeRequired) Then
            Return Me.Invoke(Function() Me.GetSRng())
        Else
            Return Me.Adjust(Me.tbSRange.Text)
        End If
    End Function

    Private Function Adjust(value As String) As Single
        If (Not String.IsNullOrEmpty(value) And Char.IsDigit(value)) Then
            Dim result As Single = 0F
            Dim nformat As New NumberFormatInfo
            nformat.NumberDecimalSeparator = If(value.Contains("."), ".", ",")
            Return Single.Parse(value, nformat)
        End If
        Return 0F
    End Function

    Private Sub SetGUI(state As Boolean)
        If (state) Then Me.cmdRun.Text = "Run" Else Me.cmdRun.Text = "Stop"
        Me.tbAmp.Enabled = state
        Me.tbDamp.Enabled = state
        Me.tbMass.Enabled = state
        Me.tbStiffness.Enabled = state
        Me.tbBreak.Enabled = state
        Me.tbSRange.Enabled = state
    End Sub

End Class
