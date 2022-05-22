using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Button restartButton;
    public Text gameOverText;
    public bool isGameActive;

    public List<GameObject> targetPool;

    public List <GameObject> targets;
    private float spawnRate = 1.0f;

    void Awake()
    {
        //OBJECT POOLING
        if (targetPool == null)
        {
            targetPool = new List<GameObject>();
        }

        for (int i = 0; i < targets.Count*2; i++)
        {
            GameObject targetObject = Instantiate(targets[i%targets.Count]);
            targetObject.SetActive(false);
            targetPool.Add(targetObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        List<GameObject> inactivePool = new List<GameObject>();
        foreach (GameObject target in targetPool)
        {
            if (!target.activeSelf)
            {
                inactivePool.Add(target);
            }
        }
        int index = Random.Range(0, inactivePool.Count);
        inactivePool[index].SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE\n" + score;
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        if (score > MainManager.Instance.highscoreValue1)
        {
            MainManager.Instance.highscoreValue1 = score;
            MainManager.Instance.highscoreName1 = MainManager.Instance.username;
            MainManager.Instance.SaveScore();
            gameOverText.text = "HIGHSCORE!";
        }
    }

    public void RestartGame()
    {
        foreach (GameObject target in targetPool)
        {
            target.SetActive(false);
        }
        MainManager.Instance.Restart();
    }
}
