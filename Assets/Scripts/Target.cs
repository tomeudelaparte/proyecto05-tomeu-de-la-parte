using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points;
    private float lifeTime = 1f;

    public ParticleSystem explosionParticle;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        lifeTime = gameManager.spawnRate;
        Destroy(gameObject, lifeTime);
    }

    private void OnMouseDown()
    {
        if (!gameManager.isGameOver)
        {
            gameManager.UpdateScore(points);

            explosionParticle = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositions.Remove(transform.position);
    }
}
