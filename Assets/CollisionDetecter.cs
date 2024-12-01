using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D collision)
    {
        // Print "Hit" to the console
        Debug.Log("Hit!");
    }
}
