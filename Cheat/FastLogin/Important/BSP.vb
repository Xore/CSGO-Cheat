Imports System.IO
Imports System.Text

Namespace Important
  Public Class Bsp
    Private _mHeader As Header
    Private _mEdges As List(Of UShort())
    Private _mVertices As FVector()
    Private _mOriginalFaces As Face()
    Private _mFaces As Face()
    Private _mPlanes As Plane()
    Private _mBrushes As Brush()
    Private _mBrushsides As BrushSide()
    Private _mNodes As Node()
    Private _mLeafs As Leaf()
    Private _mSurfedges As Integer()
    Private _mTextureInfo As SurfFlag()
    Private _mEntityBuffer As String

    Public ReadOnly Property Header As Header
      Get
        Return _mHeader
      End Get
    End Property

    Public ReadOnly Property Edges As List(Of UShort())
      Get
        Return _mEdges
      End Get
    End Property

    Public ReadOnly Property Vertices As FVector()
      Get
        Return _mVertices
      End Get
    End Property

    Public ReadOnly Property OriginalFaces As Face()
      Get
        Return _mOriginalFaces
      End Get
    End Property

    Public ReadOnly Property Faces As Face()
      Get
        Return _mFaces
      End Get
    End Property

    Public ReadOnly Property Planes As Plane()
      Get
        Return _mPlanes
      End Get
    End Property

    Public ReadOnly Property Brushes As Brush()
      Get
        Return _mBrushes
      End Get
    End Property

    Public ReadOnly Property Brushsides As BrushSide()
      Get
        Return _mBrushsides
      End Get
    End Property

    Public ReadOnly Property Nodes As Node()
      Get
        Return _mNodes
      End Get
    End Property

    Public ReadOnly Property Leafs As Leaf()
      Get
        Return _mLeafs
      End Get
    End Property

    Public ReadOnly Property Surfedges As Integer()
      Get
        Return _mSurfedges
      End Get
    End Property

    Public ReadOnly Property TextureInfo As SurfFlag()
      Get
        Return _mTextureInfo
      End Get
    End Property

    Public ReadOnly Property EntityBuffer As String
      Get
        Return _mEntityBuffer
      End Get
    End Property

    Public Sub New(stream As Stream)
      Load(stream)
    End Sub
    Public Sub New(filePath As String)
      Using stream As FileStream = File.OpenRead(filePath)
        Load(stream)
      End Using
    End Sub

    Private Sub Load(stream As Stream)
      _mHeader = GetHeader(stream)
      _mEdges = GetEdges(stream)
      _mVertices = GetVertices(stream)
      _mOriginalFaces = GetOriginalFaces(stream)
      _mFaces = GetFaces(stream)
      _mPlanes = GetPlanes(stream)
      _mSurfedges = GetSurfedges(stream)
      _mTextureInfo = GetTextureInfo(stream)
      _mBrushes = GetBrushes(stream)
      _mBrushsides = GetBrushsides(stream)
      _mEntityBuffer = GetEntities(stream)
      _mNodes = GetNodes(stream)
      _mLeafs = GetLeafs(stream)
    End Sub

    Private Function GetEntities(stream As Stream) As String
      Dim lump As Lump = _mHeader.Lumps(LumpType.Entities)
      stream.Position = lump.Offset
      Dim data = FileReader.ReadBytes(stream, lump.Length)
      Return Encoding.ASCII.GetString(data)
    End Function

    Private Function GetHeader(stream As Stream) As Header
      Dim headerData As New Header()
      headerData.Ident = FileReader.ReadInt(stream)

      'If header.Ident = 86 + 66 + 8 + 83 + 16 + 80 + 24 Then
      '  FileReader.BigEndian = False
      'Else
      '  FileReader.BigEndian = True
      'End If

      headerData.Version = FileReader.ReadInt(stream)
      headerData.Lumps = New Lump(63) {}

      For i = 0 To headerData.Lumps.Length - 1
        headerData.Lumps(i) = New Lump()
        headerData.Lumps(i).Type = DirectCast(i, LumpType)
        headerData.Lumps(i).Offset = FileReader.ReadInt(stream)
        headerData.Lumps(i).Length = FileReader.ReadInt(stream)
        headerData.Lumps(i).Version = FileReader.ReadInt(stream)
        headerData.Lumps(i).FourCc = FileReader.ReadInt(stream)
      Next

      headerData.MapRevision = FileReader.ReadInt(stream)
      Return headerData
    End Function

    Private Function GetEdges(stream As Stream) As List(Of UShort())
      Dim edgesData As New List(Of UShort())()
      Dim lump As Lump = _mHeader.Lumps(LumpType.Edges)
      stream.Position = lump.Offset

      For i = 0 To (lump.Length / 2) / 2 - 1
        Dim edge = New UShort(1) {}
        edge(0) = FileReader.ReadUShort(stream)
        edge(1) = FileReader.ReadUShort(stream)
        edgesData.Add(edge)
      Next

      Return edgesData
    End Function

    Private Function GetVertices(stream As Stream) As FVector()
      Dim lump = _mHeader.Lumps(LumpType.Vertexes)
      stream.Position = lump.Offset
      Dim verticesData = New FVector((lump.Length / 3) / 4 - 1) {}

      For i = 0 To verticesData.Length - 1
        verticesData(i) = New FVector()
        verticesData(i).X = FileReader.ReadFloat(stream)
        verticesData(i).Y = FileReader.ReadFloat(stream)
        verticesData(i).Z = FileReader.ReadFloat(stream)
      Next

      Return verticesData
    End Function

    Private Function GetOriginalFaces(stream As Stream) As Face()
      Dim lump = _mHeader.Lumps(LumpType.OriginalFaces)
      stream.Position = lump.Offset
      Dim originalFacesData = New Face(lump.Length / 56 - 1) {}

      For i = 0 To originalFacesData.Length - 1
        originalFacesData(i) = New Face()
        originalFacesData(i).PlaneNumber = FileReader.ReadUShort(stream)
        originalFacesData(i).Side = FileReader.ReadByte(stream)
        originalFacesData(i).OnNode = FileReader.ReadByte(stream)
        originalFacesData(i).FirstEdge = FileReader.ReadInt(stream)
        originalFacesData(i).NumEdges = FileReader.ReadShort(stream)
        originalFacesData(i).TexInfo = FileReader.ReadShort(stream)
        originalFacesData(i).DispInfo = FileReader.ReadShort(stream)
        originalFacesData(i).SurfaceFogVolumeId = FileReader.ReadShort(stream)
        originalFacesData(i).Styles = New Byte(3) {}
        originalFacesData(i).Styles(0) = FileReader.ReadByte(stream)
        originalFacesData(i).Styles(1) = FileReader.ReadByte(stream)
        originalFacesData(i).Styles(2) = FileReader.ReadByte(stream)
        originalFacesData(i).Styles(3) = FileReader.ReadByte(stream)
        originalFacesData(i).LightOffset = FileReader.ReadInt(stream)
        originalFacesData(i).Area = FileReader.ReadFloat(stream)
        originalFacesData(i).LightmapTextureMinsInLuxels = New Integer(1) {}
        originalFacesData(i).LightmapTextureMinsInLuxels(0) = FileReader.ReadInt(stream)
        originalFacesData(i).LightmapTextureMinsInLuxels(1) = FileReader.ReadInt(stream)
        originalFacesData(i).LightmapTextureSizeInLuxels = New Integer(1) {}
        originalFacesData(i).LightmapTextureSizeInLuxels(0) = FileReader.ReadInt(stream)
        originalFacesData(i).LightmapTextureSizeInLuxels(1) = FileReader.ReadInt(stream)
        originalFacesData(i).OriginalFace = FileReader.ReadInt(stream)
        originalFacesData(i).NumPrims = FileReader.ReadUShort(stream)
        originalFacesData(i).FirstPrimId = FileReader.ReadUShort(stream)
        originalFacesData(i).SmoothingGroups = FileReader.ReadUInt(stream)
      Next

      Return originalFacesData
    End Function

    Private Function GetFaces(stream As Stream) As Face()
      Dim lump = _mHeader.Lumps(LumpType.Faces)
      stream.Position = lump.Offset
      Dim facesData = New Face(lump.Length / 56 - 1) {}

      For i = 0 To facesData.Length - 1
        facesData(i) = New Face()
        facesData(i).PlaneNumber = FileReader.ReadUShort(stream)
        facesData(i).Side = FileReader.ReadByte(stream)
        facesData(i).OnNode = FileReader.ReadByte(stream)
        facesData(i).FirstEdge = FileReader.ReadInt(stream)
        facesData(i).NumEdges = FileReader.ReadShort(stream)
        facesData(i).TexInfo = FileReader.ReadShort(stream)
        facesData(i).DispInfo = FileReader.ReadShort(stream)
        facesData(i).SurfaceFogVolumeId = FileReader.ReadShort(stream)
        facesData(i).Styles = New Byte(3) {}
        facesData(i).Styles(0) = FileReader.ReadByte(stream)
        facesData(i).Styles(1) = FileReader.ReadByte(stream)
        facesData(i).Styles(2) = FileReader.ReadByte(stream)
        facesData(i).Styles(3) = FileReader.ReadByte(stream)
        facesData(i).LightOffset = FileReader.ReadInt(stream)
        facesData(i).Area = FileReader.ReadFloat(stream)
        facesData(i).LightmapTextureMinsInLuxels = New Integer(1) {}
        facesData(i).LightmapTextureMinsInLuxels(0) = FileReader.ReadInt(stream)
        facesData(i).LightmapTextureMinsInLuxels(1) = FileReader.ReadInt(stream)
        facesData(i).LightmapTextureSizeInLuxels = New Integer(1) {}
        facesData(i).LightmapTextureSizeInLuxels(0) = FileReader.ReadInt(stream)
        facesData(i).LightmapTextureSizeInLuxels(1) = FileReader.ReadInt(stream)
        facesData(i).OriginalFace = FileReader.ReadInt(stream)
        facesData(i).NumPrims = FileReader.ReadUShort(stream)
        facesData(i).FirstPrimId = FileReader.ReadUShort(stream)
        facesData(i).SmoothingGroups = FileReader.ReadUInt(stream)
      Next

      Return facesData
    End Function

    Private Function GetPlanes(stream As Stream) As Plane()
      Dim lump = _mHeader.Lumps(LumpType.Planes)
      Dim planesData = New Plane(lump.Length / 20 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To planesData.Length - 1
        planesData(i) = New Plane()

        Dim normal As New FVector()
        normal.X = FileReader.ReadFloat(stream)
        normal.Y = FileReader.ReadFloat(stream)
        normal.Z = FileReader.ReadFloat(stream)

        planesData(i).Normal = normal
        planesData(i).Distance = FileReader.ReadFloat(stream)
        planesData(i).Type = FileReader.ReadInt(stream)
      Next

      Return planesData
    End Function

    Private Function GetBrushes(stream As Stream) As Brush()
      Dim lump = _mHeader.Lumps(LumpType.Brushes)
      Dim brushesData = New Brush(lump.Length / 12 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To brushesData.Length - 1
        brushesData(i) = New Brush()
        brushesData(i).FirstSide = FileReader.ReadInt(stream)
        brushesData(i).NumSides = FileReader.ReadInt(stream)
        brushesData(i).Contents = DirectCast(FileReader.ReadInt(stream), ContentsFlag)
      Next

      Return brushesData
    End Function

    Private Function GetBrushsides(stream As Stream) As BrushSide()
      Dim lump = _mHeader.Lumps(LumpType.Brushes)
      Dim brushSidesData = New BrushSide(lump.Length / 8 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To brushSidesData.Length - 1
        brushSidesData(i) = New BrushSide()
        brushSidesData(i).Planenum = FileReader.ReadUShort(stream)
        brushSidesData(i).TexInfo = FileReader.ReadShort(stream)
        brushSidesData(i).DispInfo = FileReader.ReadShort(stream)
        brushSidesData(i).Bevel = FileReader.ReadShort(stream)
      Next

      Return brushSidesData
    End Function

    Private Function GetSurfedges(stream As Stream) As Integer()
      Dim lump = _mHeader.Lumps(LumpType.SurfEdges)
      Dim surfEdgesData = New Integer(lump.Length / 4 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To lump.Length / 4 - 1
        surfEdgesData(i) = FileReader.ReadInt(stream)
      Next

      Return surfEdgesData
    End Function

    Private Function GetTextureInfo(stream As Stream) As SurfFlag()
      Dim lump = _mHeader.Lumps(LumpType.TextInfo)
      Dim textureData = New SurfFlag(lump.Length / 72 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To textureData.Length - 1
        stream.Position += 64
        textureData(i) = DirectCast(FileReader.ReadInt(stream), SurfFlag)
        stream.Position += 4
      Next

      Return textureData
    End Function

    Private Function GetNodes(stream As Stream) As Node()
      Dim lump = _mHeader.Lumps(LumpType.Nodes)
      Dim nodesData = New Node(lump.Length / 32 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To nodesData.Length - 1
        nodesData(i) = New Node()
        nodesData(i).Planenum = FileReader.ReadInt(stream)
        nodesData(i).Children = New Integer(1) {}
        nodesData(i).Children(0) = FileReader.ReadInt(stream)
        nodesData(i).Children(1) = FileReader.ReadInt(stream)
        nodesData(i).Mins = New Short(2) {}
        nodesData(i).Mins(0) = FileReader.ReadShort(stream)
        nodesData(i).Mins(1) = FileReader.ReadShort(stream)
        nodesData(i).Mins(2) = FileReader.ReadShort(stream)
        nodesData(i).Maxs = New Short(2) {}
        nodesData(i).Maxs(0) = FileReader.ReadShort(stream)
        nodesData(i).Maxs(1) = FileReader.ReadShort(stream)
        nodesData(i).Maxs(2) = FileReader.ReadShort(stream)
        nodesData(i).FirstFace = FileReader.ReadUShort(stream)
        nodesData(i).NumFaces = FileReader.ReadUShort(stream)
        nodesData(i).Area = FileReader.ReadShort(stream)
        nodesData(i).Paddding = FileReader.ReadShort(stream)
      Next

      Return nodesData
    End Function

    Private Function GetLeafs(stream As Stream) As Leaf()
      Dim lump = _mHeader.Lumps(LumpType.Leafs)
      Dim leafData = New Leaf(lump.Length / 56 - 1) {}
      stream.Position = lump.Offset

      For i = 0 To leafData.Length - 1
        leafData(i) = New Leaf()
        leafData(i).Contents = DirectCast(FileReader.ReadInt(stream), ContentsFlag)
        leafData(i).Cluster = FileReader.ReadShort(stream)
        leafData(i).Area = FileReader.ReadShort(stream)
        leafData(i).Flags = FileReader.ReadShort(stream)
        leafData(i).Mins = New Short(2) {}
        leafData(i).Mins(0) = FileReader.ReadShort(stream)
        leafData(i).Mins(1) = FileReader.ReadShort(stream)
        leafData(i).Mins(2) = FileReader.ReadShort(stream)
        leafData(i).Maxs = New Short(2) {}
        leafData(i).Maxs(0) = FileReader.ReadShort(stream)
        leafData(i).Maxs(1) = FileReader.ReadShort(stream)
        leafData(i).Maxs(2) = FileReader.ReadShort(stream)
        leafData(i).FirstLeafFace = FileReader.ReadUShort(stream)
        leafData(i).NumLeafFaces = FileReader.ReadUShort(stream)
        leafData(i).FirstLeafBrush = FileReader.ReadUShort(stream)
        leafData(i).NumLeafBrushes = FileReader.ReadUShort(stream)
        leafData(i).LeafWaterDataId = FileReader.ReadShort(stream)
      Next

      Return leafData
    End Function

    Public Function GetLeafForPoint(point As FVector) As Leaf
      Dim node = 0
      Dim pNode As Node
      Dim pPlane As Plane

      While node >= 0
        pNode = _mNodes(node)
        pPlane = _mPlanes(pNode.Planenum)

        Dim d = point.DotProduct(pPlane.Normal) - pPlane.Distance

        If d > 0 Then
          node = pNode.Children(0)
        Else
          node = pNode.Children(1)
        End If
      End While

      Dim newLeaf As New Leaf
      newLeaf.Area = -1
      newLeaf.Contents = ContentsFlag.Empty

      Return (If((-node - 1) >= 0 AndAlso -node - 1 < _mLeafs.Length, _mLeafs(-node - 1), newLeaf))
    End Function
    Public Function IsVisible(start As FVector, [end] As FVector) As Boolean
      Dim vDirection As FVector = [end] - start
      Dim vPoint As FVector = start
      Dim iStepCount As Integer = vDirection.Length()

      vDirection /= iStepCount

      Dim pLeaf As New Leaf()
      pLeaf.Area = -1

      While iStepCount > 0
        vPoint += vDirection
        pLeaf = GetLeafForPoint(vPoint)

        If pLeaf.Area <> -1 Then
          If (pLeaf.Contents And ContentsFlag.Solid) = ContentsFlag.Solid OrElse (pLeaf.Contents And ContentsFlag.Detail) = ContentsFlag.Detail Then
            Exit While
          End If
        End If

        iStepCount -= 1
      End While

      Return (pLeaf.Contents And ContentsFlag.Solid) <> ContentsFlag.Solid
    End Function
  End Class


  Public Enum ContentsFlag
    Empty = 0
    Solid = &H1
    Window = &H2
    Aux = &H4
    Grate = &H8
    Slime = &H10
    Water = &H20
    Mist = &H40
    Opaque = &H80
    TestFogVolume = &H100
    Unused = &H200
    Unused6 = &H400
    Team1 = &H800
    Team2 = &H1000
    IgnoreNoDrawOpaque = &H2000
    Moveable = &H4000
    AreaPortal = &H8000
    PlayerClip = &H10000
    MonsterClip = &H20000
    Current0 = &H40000
    Current90 = &H80000
    Current180 = &H100000
    Current270 = &H200000
    CurrentUp = &H400000
    CurrentDown = &H800000
    Origin = &H1000000
    Monster = &H2000000
    Debris = &H4000000
    Detail = &H8000000
    Translucent = &H10000000
    Ladder = &H20000000
    HitBox = &H40000000
  End Enum

  Public Enum LumpType
    Entities = 0
    Planes = 1
    TextData = 2
    Vertexes = 3
    Visibility = 4
    Nodes = 5
    TextInfo = 6
    Faces = 7
    Lighting = 8
    Occlusion = 9
    Leafs = 10
    FaceIds = 11
    Edges = 12
    SurfEdges = 13
    Models = 14
    WorldLights = 15
    LeafFaces = 16
    LeafBrushes = 17
    Brushes = 18
    BrushSides = 19
    Areas = 20
    AreaPortals = 21
    PropCollision = 22
    PropHulls = 23
    PropHullVerts = 24
    Proptris = 25
    DispInfo = 26
    OriginalFaces = 27
    PhysDisp = 28
    PhysCollide = 29
    VertNormals = 30
    VertNormalIndices = 31
    DispLightMapAlphas = 32
    DispVerts = 33
    DispLightMapSamplePositions = 34
    GameLump = 35
    LeafWaterData = 36
    Primitives = 37
    PrimVerts = 38
    PrimIndices = 39
    PakFile = 40
    ClipPortalVerts = 41
    CubeMaps = 42
    TextDataStringData = 43
    TextDataStringTable = 44
    Overlays = 45
    LeafMinDistToWater = 46
    FaceMacroTextureInfo = 47
    DispTris = 48
    PropBlob = 49
    WaterOverlays = 50
    LeafAmbientIndexHdr = 51
    LeafAmbientIndex = 52
    LightingHdr = 53
    WorldLightsHdr = 54
    LeafAmbientLightingHdr = 55
    LeafAmbientLighting = 56
    XZippakFile = 57
    FacesHdr = 58
    MapFlags = 59
    OverlayFades = 60
    OverlaySystemLevels = 61
    PhysLevel = 62
    DispMultiBlend = 63
  End Enum

  Public Enum SurfFlag
    Light = &H1
    Sky2D = &H2
    Sky = &H4
    Warp = &H8
    Trans = &H10
    NoPortal = &H20
    Trigger = &H40
    NoDraw = &H80
    Hint = &H100
    Skip = &H200
    NoLight = &H400
    BumpLight = &H800
    NoShadows = &H1000
    NoDecals = &H2000
    NoChop = &H4000
    Hitbox = &H8000
  End Enum

  Public Structure Brush
    Public FirstSide, NumSides As Integer
    Public Contents As ContentsFlag
  End Structure

  Public Structure BrushSide
    Public Planenum As UShort
    Public TexInfo, DispInfo, Bevel As Short
  End Structure

  Public Structure Face
    Public PlaneNumber, NumPrims, FirstPrimId As UShort
    Public Side, OnNode As Byte
    Public NumEdges, TexInfo, DispInfo, SurfaceFogVolumeId As Short
    Public FirstEdge, LightOffset, OriginalFace As Integer
    Public Styles As Byte()
    Public Area As Single
    Public LightmapTextureMinsInLuxels, LightmapTextureSizeInLuxels As Integer()
    Public SmoothingGroups As UInteger
  End Structure

  Public Structure Header
    Public Ident, Version, MapRevision As Integer
    Public Lumps As Lump()
  End Structure

  Public Structure Leaf
    Public Contents As ContentsFlag
    Public Cluster, Area, Flags As Short
    Public Mins, Maxs As Short()
    Public FirstLeafFace, NumLeafFaces As UShort
    Public FirstLeafBrush, NumLeafBrushes, LeafWaterDataId As UShort
  End Structure

  Public Structure Lump
    Public Offset, Length, Version, FourCc As Integer
    Public Type As LumpType
  End Structure

  Public Structure Node
    Public Planenum As Integer
    Public Children As Integer()
    Public Mins, Maxs As Short()
    Public FirstFace, NumFaces As UShort
    Public Area, Paddding As Short
  End Structure

  Public Structure Plane
    Public Normal As FVector
    Public Distance As Single
    Public Type As Integer
  End Structure

End Namespace