using UnityEngine;
using System.Collections.Generic;
public class Editor : MonoBehaviour
{
    [SerializeField] private BuildingBlock[] blocks;
    [SerializeField] private BuildingTool[] tools;
    [SerializeField] private BuildingBlock currentBlock;
    [SerializeField] private BuildingTool currentTool;
    [SerializeField] private Stack<Command> undoCommands = new Stack<Command>();
    [SerializeField] private Stack<Command> redoCommands = new Stack<Command>();
    [field: SerializeField] public GameObject Parent { get; private set; }
    private GameObject previewBlock;
    private Mode currentMode = Mode.None;

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
    private void Update()
    {
        Preview();
        Commands();
        UseTool();
    }
    private void UseTool()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && currentTool != null)
        {
            if(currentTool is CreateTool)
            {
                CreateTool tool = currentTool as CreateTool;
                ExecuteNewCommands(tool);
            }
            else if(currentTool is DeleteTool)
            {
                DeleteTool tool = currentTool as DeleteTool;
                ExecuteNewCommands(tool);
            }
        }
    }
    private void Preview()
    {
        if (currentBlock != null && currentMode == Mode.BuildMode)
        {
            Vector2 moousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (previewBlock != null)
            {
                previewBlock.transform.position = Gmath.Math.Round(moousePos);
                if (previewBlock.name != currentBlock.Block.name)
                {
                    Destroy(previewBlock);
                    previewBlock = Instantiate(currentBlock.GetBlockWithoutCollider(), Gmath.Math.Round(moousePos), Quaternion.identity);
                }
            }
            else
            {
                previewBlock = Instantiate(currentBlock.GetBlockWithoutCollider(), Gmath.Math.Round(moousePos), Quaternion.identity);
            }
        }
        else if (currentMode == Mode.DeleteMode)
        {
            if(previewBlock != null) Destroy(previewBlock);
        }

    }
    private void ExecuteNewCommands(Command command)
    {
        command.Execute();
        undoCommands.Push(command);
        redoCommands.Clear();
    }
    private void Commands()
    {
        if(undoCommands.Count > 0 && Input.GetKeyDown(KeyCode.U))
        {
            Command lastCommand = undoCommands.Pop();
            lastCommand.Undo();
            redoCommands.Push(lastCommand);
        }
        if (redoCommands.Count > 0 && Input.GetKeyDown(KeyCode.R))
        {
            Command nextCommand = redoCommands.Pop();
            nextCommand.Execute();
            undoCommands.Push(nextCommand);
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
    public void SetMode(Mode mode)
    {
        currentMode = mode;
    }
    public BuildingBlock GetCurrentBlock() => currentBlock;
    public BuildingTool GetCurrentTool() => currentTool;
}
public interface Command
{
    public void Undo();
    public void Execute();
}
public enum Mode
{
    BuildMode, DeleteMode, None
}