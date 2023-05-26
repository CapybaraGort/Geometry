using UnityEngine;

public class Editor : MonoBehaviour
{
    [SerializeField] private BuildingBlock[] blocks;
    [SerializeField] private BuildingTool[] tools;
    [SerializeField] private BuildingBlock currentBlock;
    [SerializeField] private BuildingTool currentTool;

    private void Start()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].Init(this);
        }
        for (int i = 0;i < tools.Length; i++)
        {
            tools[i].Init(this);
        }
    }
    public void SetTool(BuildingTool tool)
    {
        currentTool = tool;
    }
    public void SetBlock(BuildingBlock block)
    {
        currentBlock = block;
    }
}
