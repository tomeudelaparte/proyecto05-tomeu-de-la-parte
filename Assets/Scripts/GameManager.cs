using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] targetPrefabs;
    public List<Vector3> targetPositions;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenSquares = 2.5f;

    private float spawnRate = 0.5f;
    private Vector3 randomPos;

    public bool isGameOver;

    private int score = 0;

    void Start()
    {
        scoreText.text = $"Score: " + score;
        gameOverPanel.SetActive(false);

        StartCoroutine(SpawnRandomTarget());
    }

    private Vector3 RandomSpawnPosition()
    {
        int SaltosX = Random.Range(0, 4);
        int SaltosY = Random.Range(0, 4);

        float spawnPosX = minX + SaltosX * distanceBetweenSquares;
        float spawnPosY = minY + SaltosY * distanceBetweenSquares;

        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    private IEnumerator SpawnRandomTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            int randomIndex = Random.Range(0, targetPrefabs.Length);
            randomPos = RandomSpawnPosition();

            while (targetPositions.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomIndex], randomPos, targetPrefabs[randomIndex].transform.rotation);
            targetPositions.Add(randomPos);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
}