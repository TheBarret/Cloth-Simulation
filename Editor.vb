Public Class Editor
    Private Const FRAMERATE As Integer = 30
    Public Property Previous As Double
    Public Property Simulator As Simulator
    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Me.Simulator = New Simulator(Me.ClientRectangle)
        Me.Clock.Interval = Editor.FRAMERATE
        Me.Previous = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond
        Me.Clock.Start()
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
End Class
