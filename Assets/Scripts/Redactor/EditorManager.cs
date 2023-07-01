using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EditorManager : MonoBehaviour
{
    [SerializeField] private Editor editor;
    [SerializeField] private SaveableBlock[] blocks;
    
    private const string levelPath = "C:\\GeometryLevels\\";
    public void Save()
    {
        blocks = editor.Parent.GetComponentsInChildren<SaveableBlock>();
        using (StreamWriter file = File.CreateText("dodo.json"))
        {
            for (int i = 0; i < blocks.Length; i++)
            {
                Block block = new(blocks[i].GetXPosition(), blocks[i].GetYPosition(), blocks[i].ID);
                string json = JsonConvert.SerializeObject(block);
                file.Write(json);
            } 
        }
    }
    public void Load()
    {
        using (StreamReader file = File.OpenText("dodo.json"))
        {
            string str = file.ReadToEnd();
            print(str);
        }
    }
    private struct Block
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int ID { get; set; }
        public Block(float x, float y, int id)
        {
            X = x; Y = y; ID = id;
        }
    }
}
