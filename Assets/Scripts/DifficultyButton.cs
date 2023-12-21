using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;

    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    public void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " difficulty is set");
        gameManager.StartGame(difficulty);
    }
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
