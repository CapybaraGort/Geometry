using Cinemachine;
using TMPro.Examples;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float speed;
    private Vector2 _moveSpeed = Vector2.zero;
    private float currentZoom = 0;
    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        currentZoom = _camera.orthographicSize;
    }
    private void Update()
    {
        Movement();
        Zoom();
    }
    private void Movement()
    {
        _moveSpeed = HandleKeyInput();
        if (_moveSpeed.magnitude > 1)
        {
            _moveSpeed = _moveSpeed.normalized;
        }
        CheckingBorder();
        transform.Translate((_moveSpeed * Time.deltaTime * speed) * currentZoom);
    }
    private Vector3 HandleKeyInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 acceleration = new Vector2(moveX, moveY);

        return acceleration.normalized;
    }
    private void Zoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, 2, 12) - Input.mouseScrollDelta.y;
            currentZoom = _camera.orthographicSize;
        }
    }
    private void CheckingBorder()
    {
        if (_camera.transform.position.x <= 0 && _moveSpeed.x < 0)
            _moveSpeed.x = 0;
        if (_camera.transform.position.x >= 9940 && _moveSpeed.x > 0)
            _moveSpeed.x = 0;
        if (_camera.transform.position.y <= 12.25f && _moveSpeed.y < 0)
            _moveSpeed.y = 0;
        if(_camera.transform.position.y >= 500 && _moveSpeed.y > 0)
            _moveSpeed.y = 0;
    }
}
