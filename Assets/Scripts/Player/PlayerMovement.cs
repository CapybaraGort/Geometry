using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 footSize;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform foot;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        if(Input.GetKeyDown(KeyCode.Return))
        {
            transform.position = new Vector2(0,0);
        }
    }
    
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void Jump()
    {
        foot.position = new Vector2(transform.position.x, transform.position.y - 0.6f);
        if((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0)) && GroundCheck())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void RotatePlayer()
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Lerp(transform.eulerAngles.z, transform.eulerAngles.z - 90, Time.deltaTime));
    }
    private bool GroundCheck() => 
        Physics2D.OverlapBox(foot.position, footSize, 0, groundLayer);

    private void OnDrawGizmosSelected() =>
        Gizmos.DrawWireCube(foot.position, footSize);
}
