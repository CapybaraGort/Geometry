using UnityEngine;

public class CreateTool : BuildingTool
{
    public override void Execute()
    {

    }

    public override void OnSelect() => editor.SetTool(this);

    public override void Undo()
    {

    }
}
