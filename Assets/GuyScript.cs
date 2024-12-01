using UnityEngine;

public class GuyScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public int jumpForce = 10;
    public int horizontalSpeed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentLinearVelocity = myRigidBody.linearVelocity;
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            //Vector2 up = new(0, 1);
            currentLinearVelocity.y = jumpForce;
        }
        
        if (Input.GetKey(KeyCode.A) == true)
        {
            //Vector2 left = new(-1 * horizontalSpeed, 0);
            currentLinearVelocity.x = -horizontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            //Vector2 right = new(1 * horizontalSpeed, 0);
            currentLinearVelocity.x = horizontalSpeed;
        }
        else
        {
            currentLinearVelocity.x = 0;
        }
        myRigidBody.linearVelocity = currentLinearVelocity;
    }
}
