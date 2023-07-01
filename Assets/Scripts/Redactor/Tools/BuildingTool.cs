
using System;
using UnityEngine;

public abstract class BuildingTool : MonoBehaviour
{
    protected Editor editor;
    public void Init(Editor e)
    {
        editor = e;
    }
    public abstract void OnSelect();
}