using UnityEngine;

public class DeleteTool : BuildingTool
{
    public override void Execute()
    {

    }

    public override void OnSelect() => editor.SetTool(this);

    public override void Undo()
    {

    }
}
