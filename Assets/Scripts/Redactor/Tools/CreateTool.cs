using System;
using UnityEngine;

public class CreateTool : BuildingTool, Command
{
    public void Execute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider == null)
        {
            Vector2 moousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(editor?.GetCurrentBlock()?.Block, Gmath.Math.Round(moousePos), Quaternion.identity, editor.Parent.transform);
        }
    }
    public void Undo()
    {

    }
    public override void OnSelect()
    {
        editor.SetTool(this);
        editor.SetMode(Mode.BuildMode);
    }

}
