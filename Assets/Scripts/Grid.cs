using UnityEngine;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    private Dictionary<Vector2, Cell> placedBlocks = new();
    public void FillCell(Vector2 pos)
    {
        List<Vector2> positions = new List<Vector2>();
        Cell cell = new Cell(positions);
        foreach (Vector2 ps in positions)
        {
            if (placedBlocks.ContainsKey(ps))
            {
                print("already filled");
            }
            placedBlocks[ps] = cell;
        }
    }
    public void ClearCell()
    {

    }
    public bool CanPlaceBlock(Vector2 pos)
    {
        List<Vector2> positionsToOccupy = new()
        {
            pos
        };
        foreach (var ps in positionsToOccupy)
        {
            if (placedBlocks.ContainsKey(ps))
                return false;
        }
        return true;
    }
}
public class Cell
{
    public List<Vector2> OccupiedPos;
    public Cell(List<Vector2> occupiedPos)
    {
        OccupiedPos = occupiedPos;
    }
}