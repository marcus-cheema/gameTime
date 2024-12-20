using UnityEngine;

public class GuyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public int jumpForce = 10;
    public int horizontalSpeed = 5;
    public double maxJumpTime = 0.25;

    private bool onPlatform;
    private bool jumped;
    private float airTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentLinearVelocity = myRigidBody.linearVelocity;
        
        if (Input.GetKeyDown(KeyCode.Space) && onPlatform) // Player Pressed {Jump}
        {
            currentLinearVelocity.y = jumpForce;
            onPlatform = false; // now, we're off the platform.
            jumped = true; 
        }

        if (Input.GetKeyUp(KeyCode.Space) && jumped) // PLayer lets go of {Jump} -> Cannot Jump Higher
        {
            jumped = false;
            airTime = 0;
        }

        if (Input.GetKey(KeyCode.Space) && jumped) // Player holds {Jump} -> Jumps higher until maxJumpTime
        {
            airTime += Time.deltaTime;
            currentLinearVelocity.y = jumpForce;
            if (airTime > maxJumpTime)
            {
                jumped = false;
                airTime = 0;
            }
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
            jumped = false;
        }
    }
}
