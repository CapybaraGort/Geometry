using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Controls")]
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    private Vector3 _moveSpeed = Vector3.zero;

    private void Update()
    {
        Vector3 acceleration = HandleKeyInput();

        _moveSpeed = acceleration;

        //HandleDeceleration(acceleration);

        if (_moveSpeed.magnitude > 1)
        {
            _moveSpeed = _moveSpeed.normalized;
        }
        transform.Translate(_moveSpeed * Time.deltaTime * speed);
    }

    private Vector3 HandleKeyInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 acceleration = new Vector3(moveX, moveY);

        return acceleration.normalized;
    }
}
