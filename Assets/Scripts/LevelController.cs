using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    uint numEnemies = 0;
    bool startNextLevel = false;

    float nextLevelTimer = 3;

    string[] levels = { "Level-1", "Level-2" };
    int currentLevel = 1;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
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
    public void ReoveEnemy()
    {
        numEnemies--;

        if (numEnemies == 0)
        {

        }
    }
}
