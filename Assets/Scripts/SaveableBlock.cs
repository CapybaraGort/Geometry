using UnityEngine;

public class SaveableBlock : SaveableObject
{
    [field: SerializeField] public int ID { get; private set; }
}
