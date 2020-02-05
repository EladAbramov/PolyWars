using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public Sprite[] nPCSprites;
    public GameObject NPCPrefab;
    public float spawnRate = 5f;
    private float spawnRateAnchor;
    bool isFreezeMode;
    float spawnCounter = 0f;
    float xAnchor = 11;
    float yAnchor = 6;
    public GameObject playerTarget;
    private LevelsController lvlsController;

    // Start is called before the first frame update
    void Start()
    {
        lvlsController = gameObject.GetComponent<LevelsController>();
        spawnRateAnchor = lvlsController.getNpcSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = lvlsController.getNpcSpawnRate();
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnRate)
        {
            spawnRate = lvlsController.getNpcSpawnRate();
            spawnCounter = 0;
            int randomNPCIndex = Random.Range(0, nPCSprites.Length);
            Vector3 randomizedSpawnPoint = randomizeSpawnPoint();
            GameObject npc = Instantiate(NPCPrefab, randomizedSpawnPoint, Quaternion.identity) as GameObject;
            npc.GetComponent<SpriteRenderer>().sprite = nPCSprites[randomNPCIndex];
            npc.GetComponent<NPCController>().target = playerTarget;
            npc.GetComponent<NPCController>().setNPCParams(lvlsController.getNpcLife(), lvlsController.getNpcWorth(), lvlsController.getNpcSpeed());
        }
    }

    private Vector3 randomizeSpawnPoint()
    {
        bool xMainAnchor = (Random.Range(0, 2) == 0) ? true : false;

        if (xMainAnchor)
        {
            float ySpawnPoint = Random.Range(-yAnchor, yAnchor);
            if (Random.Range(0, 2) == 0)
            {
                // right side
                return new Vector3(xAnchor, ySpawnPoint, 0);
            }
            else
            {
                // left side
                return new Vector3(-xAnchor, ySpawnPoint, 0);
            }
        }
        else
        {
            float xSpawnPoint = Random.Range(-xAnchor, xAnchor);
            if (Random.Range(0, 2) == 0)
            {
                // up side
                return new Vector3(xSpawnPoint, yAnchor, 0);
            }
            else
            {
                // down side
                return new Vector3(xSpawnPoint, -yAnchor, 0);
            }
        }

    }

    public void resetNPC()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            Destroy(npc);
        }
    }

    public void resetNPCStats()
    {
        spawnRate = spawnRateAnchor;
    }
}
