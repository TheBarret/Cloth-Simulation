
Imports System.Text.RegularExpressions

Public Class Simulator
    Public Property Bounds As Rectangle
    Public Property Materials As List(Of Material)

    Sub New(bounds As Rectangle)
        Me.Bounds = bounds
        Me.Materials = New List(Of Material)
        Me.Materials.Add(Me.Create(20, 20, 16, 0.1F, 2.0F, 1.0F, Color.Black, New Vector2(0F, -20.0F), Me.Bounds))
    End Sub

    Public Sub Update(dt As Single)
        For Each mat In Me.Materials
            mat.Update(mat.Connections, dt)
        Next
    End Sub

    Public Sub Draw(g As Graphics)
        For Each material In Me.Materials
            For Each spring In material.Springs
                g.DrawLine(New Pen(Color.Black, 2) With {.DashStyle = Drawing2D.DashStyle.DashDot}, spring.Top.Position.ToPointF, spring.Bottom.Position.ToPointF)
            Next
        Next
    End Sub

    Public Function Create(rows As Integer, cols As Integer, spacing As Single, damping As Single, mass As Single, stifness As Single, tint As Color, gravity As Vector2, boundary As Rectangle) As Material
        Dim mat As New Material With {.Columns = cols, .Rows = rows, .Damping = damping, .Tint = tint, .Gravity = gravity}
        Dim width As Single = cols * spacing
        Dim height As Single = rows * spacing
        Dim sx As Single = boundary.X + (boundary.Width - width) / 2
        Dim sy As Single = boundary.Y + (boundary.Height - height) / 2
        ' Create connections
        For r As Integer = 0 To rows - 1
            For c As Integer = 0 To cols - 1
                Dim x As Single = sx + c * spacing
                Dim y As Single = sy + r * spacing
                If (r = (rows - 1)) Then
                    mat.Connections.Add(New Connection(New Vector2(x, y), (r = 0), mass * 5))
                Else
                    mat.Connections.Add(New Connection(New Vector2(x, y), (r = 0), mass))
                End If
            Next
        Next
        ' Create horizontal springs
        For r As Integer = 0 To rows - 1
            For c As Integer = 0 To cols - 2
                Dim i As Integer = r * cols + c
                Dim j As Integer = i + 1
                mat.Springs.Add(New Spring(mat.Connections(i), mat.Connections(j), spacing, stifness))
            Next
        Next
        ' Create vertical springs
        For r As Integer = 0 To rows - 2
            For c As Integer = 0 To cols - 1
                Dim i As Integer = r * cols + c
                Dim j As Integer = i + cols
                mat.Springs.Add(New Spring(mat.Connections(i), mat.Connections(j), spacing, stifness))
            Next
        Next
        Return mat
    End Function

    Public Shared Function Randomizer() As Random
        Static r As New Random
        Return r
    End Function
End Class