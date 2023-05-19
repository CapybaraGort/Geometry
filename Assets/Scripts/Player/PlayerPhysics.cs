using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    public System.Action OnDie;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float distX = (transform.position.x + (sprite.size.x / 2)) - (collision.transform.position.x - (collision.gameObject.GetComponent<SpriteRenderer>().size.x / 2));
        if(collision.gameObject.layer == 7 || distX < 0)
        {
            OnDie?.Invoke();
            transform.position = new Vector2(0, 0);
        }
    }
}
