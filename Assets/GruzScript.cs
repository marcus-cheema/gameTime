using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GruzScript : MonoBehaviour
{

    public Rigidbody2D gruzRigidBody;
    public static int horizontalVelocity = 5;
    public static int verticalVelocity = 10;

    private Vector2 currentLinearVelocity;
    private bool bounce;
    private bool onWall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLinearVelocity = new(horizontalVelocity, verticalVelocity);
        gruzRigidBody.linearVelocity = currentLinearVelocity;
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

    public void OnCollisionEnter2D(Collision2D collision)
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
