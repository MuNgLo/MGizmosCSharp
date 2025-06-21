#if TOOLS
using Godot;

namespace GizmosCSharp;
[Tool]
public partial class GizmosCSharpAddon : EditorPlugin
{
    public override void _EnterTree()
    {
        GD.Print("Loaded GizmosCSharp Plugin : Current version has no added functionality as a loaded in addon. It is still usable in code.");
    }
    public override void _ExitTree()
    {
        GD.Print("Unloaded GizmosCSharp Plugin");
    }

    public override bool _HasMainScreen()
    {
        return false;
    }
    public override string _GetPluginName()
    {
        return "GizmosCSharp";
    }
}// EOF CLASS
#endif