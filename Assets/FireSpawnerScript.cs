using System.Threading;
using UnityEngine;

public class FireSpawnerScript : MonoBehaviour
{
    public GameObject Fire;
    public float spawnRate = 2;
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            float x = transform.position.x, y = transform.position.y, z = transform.position.z;
            Vector3 spawnPosition = new(x, y - 2.0f, z);
            Instantiate(Fire, spawnPosition, transform.rotation);
            timer = 0;
        }
    }
}
