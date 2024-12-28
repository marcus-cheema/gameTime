using UnityEngine;

// This script identifies when the enemy interacts with the Player.
// Should be applied to Enemy Attacks.

public class EnemyHitDetection : MonoBehaviour
{
    [SerializeField] private float parryWindow = 0.25f;
    
    private float startTime;
    private bool touchedPlayer = false;
    private bool parried = false;

    private void Update()
    {
        PlayerParry();
    }

    private void PlayerParry()
    {
        // If we touchedPlayer, determine parry status
        if (touchedPlayer)
        {
            bool withinParryWindow = (Time.time - startTime <= parryWindow);
            
            if (Input.GetKey(KeyCode.K) && !parried && withinParryWindow)
            {
                Debug.Log("Parry");
                parried = true;
                touchedPlayer = false;
            }
            // If outside of ParryWindow and haven't Parried, we've been Hit.
            if (!withinParryWindow && !parried)
            {
                Debug.Log("Hit!");
                touchedPlayer = false;
            }
        }
    }
    
    // If the enemy touches the player, then begin Parry Window Timer
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startTime = Time.time;
            touchedPlayer = true;
            parried = false;
        }
    }
}
