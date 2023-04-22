Public Class Fiber
    Public Property Top As Connection
    Public Property Bottom As Connection
    Public Property Length As Single
    Public Property Force As Vector2
    Public Property Breakforce As Single
    Public Property Stiffness As Single
    Sub New(top As Connection, bottom As Connection, length As Single, stiffness As Single, breakforce As Single, breakrange As Single)
        Me.Top = top
        Me.Bottom = bottom
        Me.Length = length
        Me.Force = Vector2.Empty
        Me.Breakforce = breakforce + CSng(Simulator.Randomizer.NextDouble - breakrange)
        Me.Stiffness = stiffness
    End Sub
    Public Function ToColor() As Color
        Dim result As Color = Color.DarkBlue
        If Me.Force.Length > 0 Then
            Dim fdir As Vector2 = Vector2.Normalize(Me.Force)
            Dim dot As Single = Vector2.Dot(fdir, New Vector2(0, -1))
            result = Fiber.Lerp(Color.DarkBlue, Color.Red, (dot + 1) / 2)
        End If
        Return result
    End Function
    Public Shared Function Lerp(ByVal color1 As Color, ByVal color2 As Color, ByVal amount As Single) As Color
        Dim r As Integer = CInt(color1.R) + (CInt(color2.R) - CInt(color1.R)) * amount
        Dim g As Integer = CInt(color1.G) + (CInt(color2.G) - CInt(color1.G)) * amount
        Dim b As Integer = CInt(color1.B) + (CInt(color2.B) - CInt(color1.B)) * amount
        Dim a As Integer = CInt(color1.A + (color2.A - color1.A) * amount)
        Return Color.FromArgb(a, r, g, b)
    End Function
    Public ReadOnly Property Broken() As Boolean
        Get
            Return Vector2.Distance(Me.Top.Position, Me.Bottom.Position) >= (Me.Length * Me.Breakforce)
        End Get
    End Property
    Public ReadOnly Property Distance As Single
        Get
            Return Vector2.Distance(Me.Top.Position, Me.Bottom.Position)
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return String.Format("Spring between {0} and {1} [L{2},S{3}]", Me.Top, Me.Bottom, Me.Length, Me.Stiffness)
    End Function
End Class