Public Class Connection
    Public Property Radius As Single
    Public Property Frequency As Single
    Public Property Amplitude As Single
    Public Property Fixed As Boolean
    Public Property Mass As Single
    Public Property Assertion As Single
    Public Property Position As Vector2
    Public Property Velocity As Vector2

    Public Sub New(position As Vector2, fixed As Boolean, mass As Single, radius As Single, assertion As Single, rippleFreq As Single, rippleAmpl As Single)
        Me.Radius = radius
        Me.Mass = mass
        Me.Fixed = fixed
        Me.Assertion = assertion
        Me.Frequency = rippleFreq
        Me.Amplitude = rippleAmpl
        Me.Position = position
        Me.Velocity = Vector2.Empty
    End Sub
    Public Function CreateNoise(dt As Single, f As Func(Of Double, Double)) As Single
        Return Me.Amplitude * f.Invoke((dt * Me.Frequency) + (Me.Position.X * 0.1))
    End Function
    Public Overrides Function ToString() As String
        Return String.Format("Connection at {0} [M{1},V{2},F{3}]", Me.Position, Me.Mass, Me.Velocity, Me.Fixed)
    End Function
End Class
