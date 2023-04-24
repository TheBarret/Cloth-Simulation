Public Class Material
    Public Property Rows As Integer
    Public Property Columns As Integer
    Public Property Tint As Color
    Public Property Frequency As Single
    Public Property Amplitude As Single
    Public Property Damping As Single
    Public Property Gravity As Vector2
    Public Property Fibers As List(Of Fiber)
    Public Property Connections As List(Of Connection)
    Public Property Counter As Integer
    Public Property Broken As HashSet(Of Fiber)

    Sub New()
        Me.Counter = 0
        Me.Damping = 0.5F
        Me.Frequency = 5.0F
        Me.Amplitude = 0.5F
        Me.Gravity = New Vector2(0, 1.0F)
        Me.Fibers = New List(Of Fiber)
        Me.Connections = New List(Of Connection)
        Me.Broken = New HashSet(Of Fiber)
    End Sub
    Public Overrides Function ToString() As String
        Return String.Format("Material {0} Connections {1} fibers [G[{2}],D{3}]", Me.Connections.Count, Me.Fibers.Count, Me.Gravity, Me.Damping)
    End Function

    Public Sub Update(dt As Single, elapsed As Integer, callbackBreak As Action(Of CState))
        'Validate and remove broken fibers
        If (Me.Broken.Any) Then
            For Each b As Fiber In Me.Broken
                Me.Fibers.Remove(b)
                Me.Counter += 1
            Next
            callbackBreak.Invoke(CState.Damaged)
            Me.Broken.Clear()
        End If
        'Update fibers with Hook's law
        For Each fbr As Fiber In Me.Fibers
            Dim top As Connection = fbr.Top
            Dim bottom As Connection = fbr.Bottom
            Dim distance As Vector2 = bottom.Position - top.Position
            Dim length As Single = distance.Length
            Dim displacement As Single = (length - fbr.Length) / length
            If displacement > 0 Then
                fbr.Force = distance * (fbr.Stiffness * displacement)
                top.Velocity += fbr.Force / top.Mass
                bottom.Velocity -= fbr.Force / bottom.Mass
                If (fbr.Broken) Then Me.HandleBroken(fbr)
            End If
        Next
        'Update connections
        Dim noise As Vector2, dgrav As Vector2
        For Each conn As Connection In Me.Connections
            If Not conn.Fixed Then
                noise = Simulator.Signal(Me.Frequency, Me.Amplitude, 1, conn.Position.X, dt)
                dgrav = Me.Gravity - Me.Damping
                conn.Velocity += ((dgrav * conn.Velocity) / conn.Mass) * dt
                conn.Velocity.X += noise.Y
                conn.Velocity.Y += noise.X
                conn.Position += conn.Velocity * dt
                Me.HandleCollision(conn, conn.Radius, conn.Assertion, dt)
            End If
        Next
    End Sub

    Private Sub HandleBroken(fbr As Fiber)
        Dim top As Connection = fbr.Top
        Dim bottom As Connection = fbr.Bottom
        top.Position = fbr.Bottom.Position
        bottom.Position = fbr.Top.Position
        Me.Broken.Add(fbr)
    End Sub

    Private Sub HandleCollision(current As Connection, dist As Single, force As Single, dt As Single)
        For Each other As Connection In Me.Connections
            If other IsNot current Then
                Dim distance As Single = Vector2.Distance(current.Position, other.Position)
                If distance < dist Then
                    Dim displacement As Vector2 = Vector2.Normalize(current.Position - other.Position)
                    Dim overlap As Single = dist - distance
                    Dim collisionForce As Single = overlap * force
                    current.Velocity += displacement * collisionForce / current.Mass * dt
                    other.Velocity -= displacement * collisionForce / other.Mass * dt
                End If
            End If
        Next
    End Sub

    Public ReadOnly Property Force As Vector2
        Get
            Dim tF As New Vector2(0, 0)
            For Each fbr As Fiber In Me.Fibers
                tF += fbr.Force
            Next
            Return tF / Me.Fibers.Count
        End Get
    End Property
End Class