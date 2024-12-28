using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{ 
    // SerializeField allows for editability w/o publicizing variable.

    [SerializeField] private int jumpForce = 10;    
    [SerializeField] private int horizontalSpeed = 5;
    [SerializeField] private double maxJumpTime = 0.25;

    private Rigidbody2D myRigidBody;
    private bool onPlatform;
    private bool jumped;
    private float airTime = 0;
    
    // Assign RigidBody automatically (prevent drag/drop human error)
    private void Awake()    
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleHorizontalMovement();
    }
    
    private void HandleJump()
    {
        // Creating new Vec2 variable is not much of a performance issue in Unity b/c of Stack (negligable overhead)

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

        myRigidBody.linearVelocity = currentLinearVelocity;
    }

    private void HandleHorizontalMovement()
    {
        Vector2 currentLinearVelocity = myRigidBody.linearVelocity;
     
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

    // Logic for determining if player is onPlatform or not
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) // if we hit the platform, onPlatform.
        {
            onPlatform = true;
            jumped = false;
        }
    }
}
