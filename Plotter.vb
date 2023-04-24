Imports System.Drawing.Drawing2D

Public Class Plotter
    Private ReadOnly Pen As Pen
    Private ReadOnly Maximum As Integer
    Private ReadOnly Rectangle As RectangleF
    Private ReadOnly Samples As Dictionary(Of Integer, List(Of Single))

    Public Sub New(x As Single, y As Single, width As Single, height As Single, Optional maximum As Integer = 64)
        Me.Maximum = maximum
        Me.Samples = New Dictionary(Of Integer, List(Of Single))
        Me.Rectangle = New RectangleF(x, y, width, height)
        Me.Pen = New Pen(Color.Red, 1.0F) With {.DashStyle = DashStyle.Dot}
    End Sub

    Public Sub Add(index As Integer, value As Single)
        If (Single.IsInfinity(value) Or Single.IsNaN(value)) Then value = 0F
        SyncLock Me.Samples
            If (Not Me.Samples.ContainsKey(index)) Then
                Me.Samples.Add(index, New List(Of Single))
            ElseIf (Me.Samples.ContainsKey(index)) Then
                Me.Samples(index).Add(value / Me.Samples.Count)
                If Me.Samples(index).Count > Me.Maximum Then
                    Me.Samples(index).RemoveAt(0)
                End If
            End If
        End SyncLock
    End Sub

    Public Sub Draw(g As Graphics, f As Font)
        ' Draw X/Y axis lines
        g.DrawLine(Pens.Black, Me.Rectangle.Left, Me.Rectangle.Bottom, Me.Rectangle.Right, Me.Rectangle.Bottom)
        g.DrawLine(Pens.Black, Me.Rectangle.Left, Me.Rectangle.Bottom, Me.Rectangle.Left, Me.Rectangle.Top)

        ' Draw plot data
        For Each l As List(Of Single) In Me.Samples.Values
            If l.Count > 1 Then
                Dim offset As Single = Me.Rectangle.Width / (l.Count - 1)
                Dim maxY As Single = l.Max()
                Dim minY As Single = l.Min()
                If maxY = minY Then ' Handle edge case where all values are the same
                    maxY = minY + 1
                End If
                Dim scale As Single = Me.Rectangle.Height / (maxY - minY)
                Dim previous As PointF = PointF.Empty
                Dim last As Single = l.Last
                For i = 0 To l.Count - 1
                    Dim x As Single = Me.Rectangle.Left + i * offset
                    Dim y As Single = Me.Rectangle.Bottom - (l(i) - minY) * scale
                    Dim point = New PointF(x, y)
                    If previous <> PointF.Empty Then
                        g.DrawLine(Me.Pen, previous, point)

                    End If
                    previous = point
                Next
            End If
        Next
    End Sub
End Class
