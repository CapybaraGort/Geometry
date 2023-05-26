using UnityEngine;

public abstract class BuildingTool : MonoBehaviour
{
    protected Editor editor;
    public void Init(Editor e)
    {
        editor = e;
    }
    public abstract void Execute();
    public abstract void Undo();
    public abstract void OnSelect();
}
