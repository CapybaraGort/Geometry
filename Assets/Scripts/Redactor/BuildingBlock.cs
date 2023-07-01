using Unity.VisualScripting;
using UnityEngine;

public class BuildingBlock : MonoBehaviour
{
    private Editor editor;
    [field: SerializeField] public GameObject Block { get; private set; }
    public void Init(Editor e)
    {
        editor = e;
    }
    public GameObject GetBlockWithoutCollider()
    {
        Object block = Resources.Load("Preview");
        SpriteRenderer sr = Block.GetComponent<SpriteRenderer>();
        block.GetComponent<SpriteRenderer>().sprite = sr.sprite;
        block.GetComponent<Transform>().transform.localScale = Block.transform.localScale;
        return (GameObject)block;
    }
        
    public void OnSelect() => editor.SetBlock(this);
}
