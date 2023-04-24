

Imports System.Text

Public Class Simulator
    Public Property Fps As Integer
    Public Property Font As Font
    Public Property Bounds As Rectangle
    Public Property Target As Material
    Public Property Plotter As Plotter
    Public Property StopOnBreak As Boolean
    Public Event SimState(state As CState)
    Private Property DeltaTime As Single
    Sub New(bounds As Rectangle, fps As Integer, sob As Boolean, m As Material)
        Me.StopOnBreak = sob
        Me.Fps = fps
        Me.Bounds = bounds
        Me.Target = m
        Me.Font = New Font("Consolas", 7.5)
        Me.Plotter = New Plotter(10, bounds.Height - 70, 500, 64)
    End Sub

    Public Sub Update(dt As Single)
        If (dt > 1.0) Then dt = 1.0
        If (dt < -1.0) Then dt = -1.0
        Me.DeltaTime = dt
        Me.Target.Update(dt, 1, AddressOf Me.OnEventBreak)
    End Sub

    Public Sub Draw(g As Graphics)
        Using sf As New StringFormat
            With Me.Target
                sf.Alignment = StringAlignment.Near
                sf.LineAlignment = StringAlignment.Near
                For Each spr In .Fibers
                    If (spr.Visible) Then
                        g.DrawLine(New Pen(spr.ToColor), spr.Top.Position.ToPointF, spr.Bottom.Position.ToPointF)
                    End If
                Next
                g.DrawString(Me.GetRenderData, Me.Font, Brushes.Black, 30, 30, sf)
                Me.Plotter.Draw(g, Me.Font)
            End With
        End Using
    End Sub

    Public ReadOnly Property GetRenderData() As String
        Get
            Dim tmp As New StringBuilder
            With Me.Target
                tmp.Append(String.Format("Frames      : {1}{0}", ControlChars.NewLine, Me.Fps))
                tmp.Append(String.Format("Springs     : {1}{0}", ControlChars.NewLine, Me.Target.Fibers.Count))
                tmp.Append(String.Format("Connections : {1}{0}", ControlChars.NewLine, Me.Target.Connections.Count))
                tmp.Append(String.Format("Frequency   : {1}Hz{0}", ControlChars.NewLine, Me.Target.Frequency))
                tmp.Append(String.Format("Broken      : {1}{0}", ControlChars.NewLine, .Counter))
                Dim f As Vector2 = .Force
                Me.Plotter.Add(0, f.X)
                Me.Plotter.Add(1, f.Y)
                Return tmp.ToString
            End With
        End Get
    End Property

    Public Shared Function Create(rows As Integer, cols As Integer, spacing As Single, boundary As Rectangle, damping As Single, mass As Single, stiffness As Single, failure As Single, failureR As Single, assertion As Single, freq As Single, ampl As Single, tint As Color, gravity As Vector2) As Material
        Dim mat As New Material With {.Columns = cols, .Rows = rows, .Damping = damping, .Tint = tint, .Gravity = gravity, .Frequency = freq, .Amplitude = ampl}
        Dim width As Single = cols * spacing
        Dim height As Single = rows * spacing
        Dim sx As Single = boundary.X + (boundary.Width - width) / 2
        Dim sy As Single = boundary.Y + (boundary.Height - height) / 2 + (rows / 2)
        ' Create connections
        For r As Integer = 0 To rows - 1
            For c As Integer = 0 To cols - 1
                Dim vis As Boolean = False
                Dim x As Single = sx + c * spacing
                Dim y As Single = sy + r * spacing
                vis = (c = cols - 1) Or (c = 0)
                mat.Connections.Add(New Connection(New Vector2(x, y), vis, mass, spacing, assertion))
            Next
        Next
        ' Create horizontal fibers
        For r As Integer = 0 To rows - 1
            For c As Integer = 0 To cols - 2
                Dim i As Integer = r * cols + c
                Dim j As Integer = i + 1
                mat.Fibers.Add(New Fiber(mat.Connections(i), mat.Connections(j), spacing, stiffness, failure, failureR))
            Next
        Next
        ' Create vertical fibers
        For r As Integer = 0 To rows - 2
            For c As Integer = 0 To cols - 1
                Dim i As Integer = r * cols + c
                Dim j As Integer = i + cols
                mat.Fibers.Add(New Fiber(mat.Connections(i), mat.Connections(j), spacing, stiffness, failure, failureR))
            Next
        Next
        Return mat
    End Function

    Private Sub OnEventBreak(c As CState)
        If (c = CState.Damaged AndAlso Me.StopOnBreak) Then
            RaiseEvent SimState(c)
        End If
    End Sub

    Public Shared Function Signal(freq As Single, ampl As Single, time As Single, value As Single, dt As Single) As Vector2
        Dim u As Single = value * freq * dt
        Dim v As Single = time * freq
        Dim w As Single = ampl * Math.Sin(u + v) * Math.PI
        Return New Vector2(w, w)
    End Function

    Public Shared Function Randomizer() As Random
        Static r As New Random
        Return r
    End Function

End Class