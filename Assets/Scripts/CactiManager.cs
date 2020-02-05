using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactiManager : MonoBehaviour
{
    public Sprite[] CactiSprites;
    public GameObject CactiPrefab;
    public float spawnRate = 6f;
    public float spawnRateAnchor;
    float counter = 0f;
    float xAnchor = 9;
    float yAnchor = 4;
    float xInnerAnchor = 1;
    float yInnerAnchor = 1;

    private LevelsController lvlsController;

    // Start is called before the first frame update
    void Start()
    {
        lvlsController = gameObject.GetComponent<LevelsController>();
        spawnRateAnchor = lvlsController.getCactiSpawnRate();
    }
    
    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= spawnRate)
        {
            spawnRate = lvlsController.getCactiSpawnRate();
            counter = 0;
            int randomCactiSkillsIndex = Random.Range(0, CactiSprites.Length);
            Vector3 randomizedSpwanPoint = randomizeSpawnPoint();
            GameObject cacti = Instantiate(CactiPrefab, randomizedSpwanPoint, Quaternion.identity) as GameObject;
            cacti.GetComponent<SpriteRenderer>().sprite = CactiSprites[randomCactiSkillsIndex];
        }

    }

    private Vector3 randomizeSpawnPoint()
    {
        float selectedX = 0f;
        float selectedY = 0f;
        bool isXPositive = (Random.Range(0, 2) == 0) ? true : false;
        bool isYPositive = (Random.Range(0, 2) == 0) ? true : false;

        if (isXPositive)
        {
            selectedX = Random.Range(xInnerAnchor, xAnchor);
        }
        else
        {
            selectedX = Random.Range(-xInnerAnchor, -xAnchor);
        }

        if (isYPositive)
        {
            selectedY = Random.Range(yInnerAnchor, yAnchor);
        }
        else
        {
            selectedY = Random.Range(-yInnerAnchor, -yAnchor);
        }

        return new Vector3(selectedX, selectedY, 0);
    }

    public void resetCactiStats()
    {
        spawnRate = spawnRateAnchor;
    }
}