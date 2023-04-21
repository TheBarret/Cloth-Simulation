Imports System.IO

Public Class Spring
    Public Const MAXLENGTH As Single = 50.0F
    Public Property Top As Connection
    Public Property Bottom As Connection
    Public Property Length As Single
    Public Property Offset As Single
    Public Property Stiffness As Single
    Public Property Displacement As Single

    Sub New(top As Connection, bottom As Connection, length As Single, stiffness As Single)
        Me.Top = top
        Me.Bottom = bottom
        Me.Length = length
        Me.Offset = 0F
        Me.Displacement = 1.0F
        Me.Stiffness = stiffness
        If (length > Spring.MAXLENGTH) Then Me.Length = Spring.MAXLENGTH
    End Sub

    Public ReadOnly Property Distance As Single
        Get
            Return Vector2.Distance(Me.Top.Position, Me.Bottom.Position)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return String.Format("Spring between {0} and {1} [L{2},S{3}]", Me.Top, Me.Bottom, Me.Length, Me.Stiffness)
    End Function
End Class