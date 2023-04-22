Public Class Editor
    Private Const FRAMERATE As Integer = 30
    Public Property Previous As Double
    Public Property Simulator As Simulator
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Dim m As Material = Simulator.Create(24, 24, 15, Me.ClientRectangle,    'dimension + spacing and bounds
                                             0F, 1.0F, 0.8F,                    'damp, mass, stiffness
                                             1.3F, 0.1F,                        'breakforce, strength randomizer
                                             15.0F,                             'assertion force
                                             5.0F, 1.0F,                        'Hz at amplitude
                                             Color.Black,                       'line colors
                                             New Vector2(0F, -9.4F))            'gravity factor
        Me.Simulator = New Simulator(Me.ClientRectangle, m)
        Me.Clock.Interval = Editor.FRAMERATE
    End Sub

    Private Sub Clock_Tick(sender As Object, e As EventArgs) Handles Clock.Tick
        Dim current As Double = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
        Me.UpdateParticles(CSng((current - Me.Previous) / 1000))
        Me.Previous = current
    End Sub

    Public Sub UpdateParticles(dt As Single)
        If (Me.InvokeRequired) Then
            Me.Invoke(Sub() Me.UpdateParticles(dt))
        Else
            Using bm As New Bitmap(Me.Simulator.Bounds.Width, Me.Simulator.Bounds.Height)
                Using g As Graphics = Graphics.FromImage(bm)
                    g.Clear(Color.CornflowerBlue)
                    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    Me.Simulator.Update(dt)
                    Me.Simulator.Draw(g)
                End Using
                Me.BackgroundImage = CType(bm.Clone, Image)
            End Using
        End If
    End Sub

    Private Sub Editor_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Space) Then
            Me.Previous = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
            Me.Clock.Stop()
            Me.Clock.Start()
        End If
    End Sub
End Class
