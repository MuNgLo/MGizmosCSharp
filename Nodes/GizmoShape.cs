using System.Collections.Generic;
using Godot;

namespace MGizmosCSharp;

[GlobalClass, Tool]
public partial class GizmoShape : GizmoNode3D
{
    [Export] private GSHAPES shape = GSHAPES.DIAMOND;
    [Export] private float shapeScale = 1.0f;
    [Export] private Color shapeColor = Colors.Yellow;

    public override void GizmoUpdate(float showFor = 0.0f)
    {
        GizmoUtils.DrawShape(Transform, shape, showFor, shapeScale, shapeColor);
    }
}// EOF CLASS
