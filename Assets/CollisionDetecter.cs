using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    public float parryWindow = 0.5f;
    private float startTime;
    private bool touchedPlayer = false;
    private bool parried = false;

    private void Update()
    {
        // If we touchedPlayer, determine parry status
        if (touchedPlayer) // if we touched the player, see if they parry
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        startTime = Time.time;
        touchedPlayer = true;
        parried = false;
    }
}
