using UnityEngine;

public class DeleteTool : BuildingTool, Command
{
    public void Execute()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null && hit.collider.tag == "Placed")
        {
            Destroy(hit.collider.gameObject);
        }
    }
    public void Undo()
    {

    }

    public override void OnSelect()
    {
        editor.SetTool(this);
        editor.SetMode(Mode.DeleteMode);
    }
}
