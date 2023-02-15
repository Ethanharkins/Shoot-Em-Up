using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static Level instance;

    uint numEnemies = 0;
    bool startNextLevel = false;
    float nextLevelTimer = 3;

    string[] levels = { "Level1", "Level2" };
    int currentLevel = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startNextLevel)
        {
            if (nextLevelTimer <= 0)
            {
                currentLevel++;
                if (currentLevel <= levels.Length)
                {
                    string scneneName = levels[currentLevel - 1];
                    SceneManager.LoadSceneAsync(scneneName);
                }
                else
                {
                    Debug.Log("GAME OVER!!");
                }
                nextLevelTimer = 3;
                startNextLevel = false;
            }
            else
            {
                nextLevelTimer -= Time.deltaTime;
            }
        }
    }

    public void AddEnemy()
    {
        numEnemies++;

    }
    public void RemoveEnemy()
    {
        numEnemies--;

        if (numEnemies == 0)
        {
            startNextLevel = true;
        }
    }
}
