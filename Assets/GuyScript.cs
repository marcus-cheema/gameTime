using UnityEngine;

public class GuyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public int jumpForce = 20;
    public int horizontalSpeed = 5;
    public bool onPlatform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentLinearVelocity = myRigidBody.linearVelocity;
        if (Input.GetKeyDown(KeyCode.Space) && onPlatform)
        {
            currentLinearVelocity.y = jumpForce;
            onPlatform = false; // now, we're off the platform.
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            currentLinearVelocity.x = -horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentLinearVelocity.x = horizontalSpeed;
        }
        else
        {
            currentLinearVelocity.x = 0;
        }
        myRigidBody.linearVelocity = currentLinearVelocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) // if we hit the platform, onPlatform.
        {
            onPlatform = true;
        }
    }
}
