Imports System.Math

Namespace Important
  Public Class Cray
    Dim origin, direction, directionInverse As FVector

    Public Sub Ray(_origin As FVector, _direction As FVector)
      origin = _origin
      direction = _direction

      directionInverse.X = 1.0F / direction.X
      directionInverse.Y = 1.0F / direction.Y
      directionInverse.Z = 1.0F / direction.Z
    End Sub

    Public Sub New(_origin As FVector, _direction As FVector)
      origin = _origin
      direction = _direction
      directionInverse = New FVector(1.0F / direction.X, 1.0F / direction.Y, 1.0F / direction.Z)
    End Sub

    Public Shared Function AngleToDirection(angle As FVector) As FVector
      angle.X = angle.X * 3.14159265 / 180
      angle.Y = angle.Y * 3.14159265 / 180

      Dim sinYaw As Single = Sin(angle.Y)
      Dim cosYaw As Single = Cos(angle.Y)

      Dim sinPitch As Single = Sin(angle.X)
      Dim cosPitch As Single = Cos(angle.X)

      Dim direction As FVector = angle
      direction.X = cosPitch * cosYaw
      direction.Y = cosPitch * sinYaw
      direction.Z = -sinPitch

      Return direction
    End Function

    Public Function Trace(leftbottom As FVector, righttop As FVector, ByRef distance As Single) As Boolean

      If (direction.X = 0.0F And (origin.X < Min(leftbottom.X.Value, righttop.X.Value) Or origin.X.Value > Max(leftbottom.X.Value, righttop.X.Value))) Then Return False

      If (direction.Y = 0.0F And (origin.Y < Min(leftbottom.Y.Value, righttop.Y.Value) Or origin.Y.Value > Max(leftbottom.Y.Value, righttop.Y.Value))) Then Return False


      If direction.Z = 0.0F And (origin.Z < Min(leftbottom.Z.Value, righttop.Z.Value Or origin.Z.Value > Max(leftbottom.Z.Value, righttop.Z.Value))) Then Return False

      Dim t1 As Single = (leftbottom.X - origin.X) * directionInverse.X
      Dim t2 As Single = (righttop.X - origin.X) * directionInverse.X
      Dim t3 As Single = (leftbottom.Y - origin.Y) * directionInverse.Y
      Dim t4 As Single = (righttop.Y - origin.Y) * directionInverse.Y
      Dim t5 As Single = (leftbottom.Z - origin.Z) * directionInverse.Z
      Dim t6 As Single = (righttop.Z - origin.Z) * directionInverse.Z


      Dim tmin As Single = Max(Max(Min(t1, t2), Min(t3, t4)), Min(t5, t6))
      Dim tmax As Single = Min(Min(Max(t1, t2), Max(t3, t4)), Max(t5, t6))

      If tmax < 0 Then
        distance = tmax
        Return False
      End If


      If tmin > tmax Then
        distance = tmax
        Return False
      End If

      distance = tmin
      Return True
    End Function
  End Class
End Namespace