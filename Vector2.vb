Public Class Vector2
    Public Const Epsilon As Single = 0.00001F
    Public Const Radians As Single = 57.2957795
    Public Property X As Single
    Public Property Y As Single

    Sub New(x As Single, y As Single)
        Me.X = x
        Me.Y = y
    End Sub

#Region "Functions"
            ' TODO: this is wrong, needs math.sqrt().
            ' Removed: magnitude function since its identical to length.
    Public Function Length() As Single
        Return (Me.X * Me.X) + (Me.Y * Me.Y)
    End Function

    Public Sub Normalize()
        Dim length As Single = Me.Length
        If (length <> 0.0F) Then
            Me.X /= length
            Me.Y /= length
        End If
    End Sub

    Public Function Angle() As Single
        Dim value As Single = If(Me.X = 0, 90.0F, CSng(Math.Atan(Me.Y / Me.X) * Vector2.Radians))
        If Me.X < 0.0F Then value += 180.0F
        Return value
    End Function

    Public Function Angle(other As Vector2) As Single
        Dim offset As Vector2 = Me - other
        Return Math.Atan2(offset.Y, offset.X)
    End Function

    Public Shared Function Cross(v1 As Vector2, v2 As Vector2) As Single
        Return v1.X * v2.Y - v2.X * v1.Y
    End Function

    Public Shared Function Dot(a As Vector2, b As Vector2) As Single
        Return a.X * b.X + a.Y * b.Y
    End Function

    Public Shared Function Empty() As Vector2
        Return New Vector2(0, 0)
    End Function

    Public Shared Function Distance(a As Vector2, b As Vector2) As Single
        Dim dx As Single = a.X - b.X
        Dim dy As Single = a.Y - b.Y
        Return CSng(Math.Sqrt(dx * dx + dy * dy))
    End Function

    Public Shared Function Normalize(ByVal value As Vector2) As Vector2
        Dim ls As Single = value.X * value.X + value.Y * value.Y
        Dim invNorm As Single = 1.0F / CSng(Math.Sqrt(CDbl(ls)))
        Return New Vector2(value.X * invNorm, value.Y * invNorm)
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("X{0}Y{1}", Me.X, Me.Y)
    End Function
#End Region

#Region "Properties"
    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return Me.X = 0 And Me.Y = 0
        End Get
    End Property
    Public ReadOnly Property ToPointF As PointF
        Get
            Return New PointF(Me.X, Me.Y)
        End Get
    End Property
    Public ReadOnly Property ToSizeF As SizeF
        Get
            Return New SizeF(Me.X, Me.Y)
        End Get
    End Property
#End Region

#Region "Operators"

    Public Shared Operator +(v As Vector2, v2 As Vector2) As Vector2
        Return New Vector2(v.X + v2.X, v.Y + v2.Y)
    End Operator
    Public Shared Operator +(v As Vector2, v2 As Single) As Vector2
        Return New Vector2(v.X + v2, v.Y + v2)
    End Operator
    Public Shared Operator +(v As Vector2, v2 As Double) As Vector2
        Return New Vector2(v.X + v2, v.Y + v2)
    End Operator
    Public Shared Operator +(v As Vector2, v2 As Integer) As Vector2
        Return New Vector2(v.X + v2, v.Y + v2)
    End Operator

    Public Shared Operator -(v As Vector2, v2 As Vector2) As Vector2
        Return New Vector2(v.X - v2.X, v.Y - v2.Y)
    End Operator
    Public Shared Operator -(v As Vector2, v2 As Single) As Vector2
        Return New Vector2(v.X - v2, v.Y - v2)
    End Operator
    Public Shared Operator -(v As Vector2, v2 As Double) As Vector2
        Return New Vector2(v.X - v2, v.Y - v2)
    End Operator
    Public Shared Operator -(v As Vector2, v2 As Integer) As Vector2
        Return New Vector2(v.X - v2, v.Y - v2)
    End Operator

    Public Shared Operator *(v As Vector2, v2 As Vector2) As Vector2
        Return New Vector2(v.X * v2.X, v.Y * v2.Y)
    End Operator
    Public Shared Operator *(v As Vector2, v2 As Single) As Vector2
        Return New Vector2(v.X * v2, v.Y * v2)
    End Operator
    Public Shared Operator *(v As Vector2, v2 As Double) As Vector2
        Return New Vector2(v.X * v2, v.Y * v2)
    End Operator
    Public Shared Operator *(v As Vector2, v2 As Integer) As Vector2
        Return New Vector2(v.X * v2, v.Y * v2)
    End Operator

    Public Shared Operator /(v As Vector2, v2 As Vector2) As Vector2
        Return New Vector2(v.X / v2.X, v.Y / v2.Y)
    End Operator
    Public Shared Operator /(v As Vector2, v2 As Single) As Vector2
        Return New Vector2(v.X / v2, v.Y / v2)
    End Operator
    Public Shared Operator /(v As Vector2, v2 As Double) As Vector2
        Return New Vector2(v.X / v2, v.Y / v2)
    End Operator
    Public Shared Operator /(v As Vector2, v2 As Integer) As Vector2
        Return New Vector2(v.X / v2, v.Y / v2)
    End Operator

    Public Shared Operator =(v As Vector2, v2 As Vector2) As Boolean
        Return v.X = v2.X And v.Y = v2.Y
    End Operator
    Public Shared Operator =(v As Vector2, v2 As Single) As Boolean
        Return v.X = v2 And v.Y = v2
    End Operator
    Public Shared Operator =(v As Vector2, v2 As Double) As Boolean
        Return v.X = v2 And v.Y = v2
    End Operator
    Public Shared Operator =(v As Vector2, v2 As Integer) As Boolean
        Return v.X = v2 And v.Y = v2
    End Operator

    Public Shared Operator <>(v As Vector2, v2 As Vector2) As Boolean
        Return v.X <> v2.X And v.Y <> v2.Y
    End Operator
    Public Shared Operator <>(v As Vector2, v2 As Single) As Boolean
        Return v.X <> v2 And v.Y <> v2
    End Operator
    Public Shared Operator <>(v As Vector2, v2 As Double) As Boolean
        Return v.X <> v2 And v.Y <> v2
    End Operator
    Public Shared Operator <>(v As Vector2, v2 As Integer) As Boolean
        Return v.X <> v2 And v.Y <> v2
    End Operator

    Public Shared Operator <(v As Vector2, v2 As Vector2) As Boolean
        Return v.X < v2.X And v.Y < v2.Y
    End Operator
    Public Shared Operator <(v As Vector2, v2 As Single) As Boolean
        Return v.X < v2 And v.Y < v2
    End Operator
    Public Shared Operator <(v As Vector2, v2 As Double) As Boolean
        Return v.X < v2 And v.Y < v2
    End Operator
    Public Shared Operator <(v As Vector2, v2 As Integer) As Boolean
        Return v.X < v2 And v.Y < v2
    End Operator

    Public Shared Operator >(v As Vector2, v2 As Vector2) As Boolean
        Return v.X > v2.X And v.Y > v2.Y
    End Operator
    Public Shared Operator >(v As Vector2, v2 As Single) As Boolean
        Return v.X > v2 And v.Y > v2
    End Operator
    Public Shared Operator >(v As Vector2, v2 As Double) As Boolean
        Return v.X > v2 And v.Y > v2
    End Operator
    Public Shared Operator >(v As Vector2, v2 As Integer) As Boolean
        Return v.X > v2 And v.Y > v2
    End Operator

    Public Shared Operator <=(v As Vector2, v2 As Vector2) As Boolean
        Return v.X <= v2.X And v.Y <= v2.Y
    End Operator
    Public Shared Operator <=(v As Vector2, v2 As Single) As Boolean
        Return v.X <= v2 And v.Y <= v2
    End Operator
    Public Shared Operator <=(v As Vector2, v2 As Double) As Boolean
        Return v.X <= v2 And v.Y <= v2
    End Operator
    Public Shared Operator <=(v As Vector2, v2 As Integer) As Boolean
        Return v.X <= v2 And v.Y <= v2
    End Operator

    Public Shared Operator >=(v As Vector2, v2 As Vector2) As Boolean
        Return v.X >= v2.X And v.Y >= v2.Y
    End Operator
    Public Shared Operator >=(v As Vector2, v2 As Single) As Boolean
        Return v.X >= v2 And v.Y >= v2
    End Operator
    Public Shared Operator >=(v As Vector2, v2 As Double) As Boolean
        Return v.X >= v2 And v.Y >= v2
    End Operator
    Public Shared Operator >=(v As Vector2, v2 As Integer) As Boolean
        Return v.X >= v2 And v.Y >= v2
    End Operator
#End Region

End Class
