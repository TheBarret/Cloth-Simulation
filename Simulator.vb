

Public Class Simulator
    Public Property Bounds As Rectangle
    Public Property Materials As List(Of Material)
    Public Event ForceUpdate(f As Vector2)

    Sub New(bounds As Rectangle, m As Material)
        Me.Bounds = bounds
        Me.Materials = New List(Of Material)
        Me.Materials.Add(m)
    End Sub

    Public Sub Update(dt As Single)
        If (dt > 1.0) Then dt = 1.0
        For Each mat In Me.Materials
            mat.Update(dt)
        Next
    End Sub

    Public Sub Draw(g As Graphics)
        For Each material In Me.Materials
            For Each spring In material.Fibers
                g.DrawLine(New Pen(spring.ToColor), spring.Top.Position.ToPointF, spring.Bottom.Position.ToPointF)
            Next
        Next
    End Sub

    Public Shared Function Create(rows As Integer, cols As Integer, spacing As Single, boundary As Rectangle, damping As Single, mass As Single, stiffness As Single, failure As Single, failureR As Single, assertion As Single, rippleFreq As Single, rippleAmpl As Single, tint As Color, gravity As Vector2) As Material
        Dim mat As New Material With {.Columns = cols, .Rows = rows, .Damping = damping, .Tint = tint, .Gravity = gravity, .Ripple = AddressOf Math.Sin}
        Dim width As Single = cols * spacing
        Dim height As Single = rows * spacing
        Dim sx As Single = boundary.X + (boundary.Width - width) / 2
        Dim sy As Single = boundary.Y + (boundary.Height - height) / 2
        ' Create connections
        For r As Integer = 0 To rows - 1
            For c As Integer = 0 To cols - 1
                Dim x As Single = sx + c * spacing
                Dim y As Single = sy + r * spacing
                mat.Connections.Add(New Connection(New Vector2(x, y), (r = 0), mass, spacing, assertion, rippleFreq, rippleAmpl))
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

    Public Shared Function Randomizer() As Random
        Static r As New Random
        Return r
    End Function
End Class