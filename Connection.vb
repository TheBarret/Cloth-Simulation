Public Class Connection
    Public Property Radius As Single

    Public Property Fixed As Boolean
    Public Property Mass As Single
    Public Property Assertion As Single
    Public Property Position As Vector2
    Public Property Velocity As Vector2

    Public Sub New(position As Vector2, fixed As Boolean, mass As Single, radius As Single, assertion As Single)
        Me.Radius = radius
        Me.Mass = mass
        Me.Fixed = fixed
        Me.Assertion = assertion
        Me.Position = position
        Me.Velocity = Vector2.Empty
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("Connection at {0} [M{1},V{2},F{3}]", Me.Position, Me.Mass, Me.Velocity, Me.Fixed)
    End Function
End Class
