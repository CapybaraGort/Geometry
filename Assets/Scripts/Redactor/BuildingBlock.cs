using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    [SerializeField] private Editor editor;
    public GameObject Block { get; private set; }
    public void Init(Editor e)
    {
        editor = e;
    }
    public void OnSelect() => editor.SetBlock(this);
}
