using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int destroyPoints;
    public ParticleSystem explosionParticles;

    private Rigidbody targetRb;
    private GameManager gameManager;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float yRange = -2.0f;
    private float zRange = 0.0f;
    private void Start()
    {
        targetRb = GetComponent<Rigidbody>();    
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!gameManager.isGameActive) return;

        Destroy(gameObject);
        
        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);

        gameManager.UpdateScore(destroyPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange, zRange);
    }
}
