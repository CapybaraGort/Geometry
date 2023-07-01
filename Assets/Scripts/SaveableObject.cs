using UnityEngine;

public abstract class SaveableObject : MonoBehaviour
{
    [field: SerializeField] public float xPos { get; private set; }
    [field: SerializeField] public float yPos { get; private set; }
    public float GetXPosition()
    {
        xPos = transform.position.x;
        return xPos;
    }
    public float GetYPosition()
    {
        yPos = transform.position.y;
        return yPos;
    }
}
