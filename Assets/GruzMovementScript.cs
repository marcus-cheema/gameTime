using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GruzScript : MonoBehaviour
{

    [SerializeField] private Rigidbody2D gruzRigidBody;
    [SerializeField] private static int horizontalVelocity = 5;
    [SerializeField] private static int verticalVelocity = 10;

    private Vector2 currentLinearVelocity;
    private bool bounce;
    private bool onWall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLinearVelocity = new(horizontalVelocity, verticalVelocity);
        gruzRigidBody.linearVelocity = currentLinearVelocity;
    }
    private void Awake()
    {
        gruzRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bounce) // Reverse Vertical Velocity
        {
            currentLinearVelocity.y = -currentLinearVelocity.y;
            bounce = false;
        }

        if (onWall) // Reverse Horizontal Velocity
        {
            currentLinearVelocity.x = -currentLinearVelocity.x;
            onWall = false;
        }

        gruzRigidBody.linearVelocity = currentLinearVelocity;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Ceiling"))
        {
            bounce= true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall = true; 
        } 
    }
}
