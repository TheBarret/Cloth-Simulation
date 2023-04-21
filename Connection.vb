Public Class Connection
    Public Property Fixed As Boolean
    Public Property Mass As Single
    Public Property Position As Vector2
    Public Property Velocity As Vector2

    Public Sub New(position As Vector2, fixed As Boolean, Optional mass As Single = 1.0F)
        Me.Position = position
        Me.Mass = mass
        Me.Fixed = fixed
        Me.Velocity = Vector2.Empty
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Connection at {0} [M{1},V{2},F{3}]", Me.Position, Me.Mass, Me.Velocity, Me.Fixed)
    End Function
End Class
