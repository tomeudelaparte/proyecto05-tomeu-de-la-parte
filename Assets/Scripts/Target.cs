using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 2f;

    private GameManager gameManager;

    void Start()
    {
        Destroy(gameObject, lifeTime);

        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Bad"))
        {
            gameManager.isGameOver = true;
        }
    }

    private void OnDestroy()
    {
        gameManager.targetPositions.Remove(transform.position);
    }
}
