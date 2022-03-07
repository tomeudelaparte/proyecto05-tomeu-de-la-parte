using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtton : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gameManagerScript;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManagerScript = FindObjectOfType<GameManager>();
    }

    public void SetDifficulty()
    {
        gameManagerScript.StartGame(difficulty);
    }
}
