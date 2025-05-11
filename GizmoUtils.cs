using System.Collections.Generic;
using Godot;

namespace GizmosCSharp;
/// <summary>
/// Static utility Class for drawing Gizmos
/// </summary>
[Tool]
public static class GizmoUtils
{
    /// <summary>
    /// Draws a line between start and end in globalspace for the duration
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="duration"></param>
    public static void DrawLine(Vector3 start, Vector3 end, float duration = 1.0f)
    {
        DrawLine(start, end, duration, Colors.Yellow);
    }
    /// <summary>
    /// Draws a line between start and end in globalspace for the duration in the given color
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="duration"></param>
    public static void DrawLine(Vector3 start, Vector3 end, float duration, Color col)
    {
        SegmentedGizmo gizmo = new SegmentedGizmo(); gizmo.pathScale = 1.0f;
        gizmo.color = col;
        if (Engine.IsEditorHint())
        {
            EditorInterface.Singleton.GetEditedSceneRoot().AddChild(gizmo);
        }
        else
        {
            MainLoop ml = Engine.GetMainLoop();
            (ml as SceneTree).Root.AddChild(gizmo);
        }
        List<Vector3> path = new List<Vector3>() { start, end };
        gizmo.ClearSegments();
        gizmo.AddSegments(path);
        gizmo.UpdateGizmo(duration);
    }
    /// <summary>
    /// Draws a shape at world location for the duration and with the size of scale
    /// Shapes are defined in the static Class GizmoShapes
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="duration"></param>
    /// <param name="scale"></param>
    public static void DrawShape(Vector3 location, GSHAPES shape, float duration = 1.0f, float scale = 1.0f)
    {
        DrawShape(location, shape, duration, scale, Colors.Yellow);
    }
      /// <summary>
    /// Draws a shape at world location for the duration and with the size of scale and given color
    /// Shapes are defined in the static Class GizmoShapes
    /// </summary>
    /// <param name="location"></param>
    /// <param name="shape"></param>
    /// <param name="duration"></param>
    /// <param name="scale"></param>
    /// <param name="col"></param>
    public static void DrawShape(Vector3 location, GSHAPES shape, float duration, float scale, Color col)
    {
        SegmentedGizmo gizmo = new SegmentedGizmo(); gizmo.pathScale = 1.0f;
        gizmo.color = col;
        EditorInterface.Singleton.GetEditedSceneRoot().AddChild(gizmo);
        gizmo.GlobalPosition = location;
        gizmo.Scale = Vector3.One * scale;
        gizmo.ClearSegments();
        gizmo.AddSegments(GizmoShapes.GetShape(shape));
        gizmo.UpdateGizmo(duration);
    }
}// EOF CLASS

