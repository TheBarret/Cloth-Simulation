Public Class Material
    Public Property Rows As Integer
    Public Property Columns As Integer
    Public Property Tint As Color
    Public Property Damping As Single
    Public Property Gravity As Vector2
    Public Property Springs As List(Of Spring)
    Public Property Connections As List(Of Connection)

    Sub New()
        Me.Damping = 0.9F
        Me.Gravity = New Vector2(0, 1.0F)
        Me.Springs = New List(Of Spring)
        Me.Connections = New List(Of Connection)
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("Material with {0} Connections and {1} springs [G[{2}],D{3}]", Me.Connections.Count, Me.Springs.Count, Me.Gravity, Me.Damping)
    End Function

    Public Sub Update(connections As List(Of Connection), dt As Single)
        For Each spring As Spring In Springs
            Dim top As Connection = spring.Top
            Dim bottom As Connection = spring.Bottom

            Dim distance As Vector2 = bottom.Position - top.Position
            Dim length As Single = distance.Length()
            Dim maxLength As Single = Spring.MAXLENGTH
            Dim displacement As Single = (length - maxLength) / length
            Dim mlDelta As Single = Math.Min(Math.Abs(displacement), Spring.MAXLENGTH)
            If displacement > 0 Then
                Dim force As Vector2 = distance * (spring.Stiffness * displacement)
                spring.Displacement = displacement
                top.Velocity += force / top.Mass
                bottom.Velocity -= force / bottom.Mass
            Else
                spring.Displacement = 1.0F
            End If
        Next
        For Each connection As Connection In connections
            If Not connection.Fixed Then
                Dim dgrav As Vector2 = Gravity - Damping
                connection.Velocity += (dgrav * connection.Velocity / connection.Mass) * dt
                connection.Position += connection.Velocity * dt
                Me.HandleCollision(connection, connections, 20.0F, 100.0F, dt)
            End If
        Next
    End Sub

    Private Sub HandleCollision(current As Connection, connections As List(Of Connection), d As Single, f As Single, dt As Single)
        For Each other As Connection In connections
            If other IsNot current Then
                Dim distance As Single = Vector2.Distance(current.Position, other.Position)
                If (distance > Spring.MAXLENGTH) Then Continue For
                If distance < d Then
                    Dim displacement As Vector2 = Vector2.Normalize(current.Position - other.Position)
                    Dim magnitude As Single = (d - distance) / 2
                    current.Velocity += displacement * f / current.Mass * dt
                    other.Velocity -= displacement * f / other.Mass * dt
                End If
            End If
        Next
    End Sub

End Class