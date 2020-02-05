using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsController : MonoBehaviour
{
    public float microSegmentLength = 10f; // seconds
    public int macroSegmentCount = 6; // microSegmentLength * macroSegmentCount = amount of seconds per level

    private float microSegmentCounter = 0f;

    public float microGrowthFactor = 1.1f;

    public float macroGrowthFallbackPercentage = 0.3f;

    public float npcMainBaseValue = 1f;

    public float npcLifeFactor = 1f;
    public float npcSpeedFactor = 1f;
    public float npcWorthFactor = 1f;
    public float npcSpawnRateFactor = 8f;
    public float cactiSpawnRateFactor = 7f;
    public float healthGlobesSuccessRateFactor = 1f;

    private int microLevelCount = 1;
    private int macroLevelCount = 1;

    private float currentNpcTypeAWorth;
    private float currentNpcTypeBWorth;
    private float currentNpcTypeALife;
    private float currentNpcTypeBLife;

    private float currentNpcSpawnRate;
    private float currentCactiSpawnRate;
    private float currentHealthGlobesSuccessRate;

    public float currentNpcTypeASpeed = 1f;

    public int currentSpitSplitCount = 11;

    private int microLevelsFallback = 3;

    public GameObject lvlUpObject;
    private Animator lvlUpAnimator;

    public GameObject levelTextObject;
    private Text levelText;

    private NPCManager npcMgr;
    private GameManager gameMgr;

    public GameObject gameOverCanvas;
    public GameObject playerObj;
    private PlayerManager playerMgr;
    public GameObject scoreObj;
    private ScoreManager scoreMgr;
    private CactiManager cactiMgr;
    private SkillsManager skillsMgr;

    // Start is called before the first frame update
    void Start()
    {
        lvlUpAnimator = lvlUpObject.GetComponent<Animator>();
        levelText = levelTextObject.GetComponent<Text>();
        npcMgr = gameObject.GetComponent<NPCManager>();
        gameMgr = gameObject.GetComponent<GameManager>();
        playerMgr = playerObj.GetComponent<PlayerManager>();
        scoreMgr = scoreObj.GetComponent<ScoreManager>();
        cactiMgr = gameObject.GetComponent<CactiManager>();
        skillsMgr = gameObject.GetComponent<SkillsManager>();
        
        if (false)
        //if (PlayerPrefs.HasKey("currentLvl"))
        {
            currentNpcTypeAWorth = PlayerPrefs.GetFloat("npcTypeAWorth");
            currentNpcTypeALife = PlayerPrefs.GetFloat("npcTypeALife");
            currentNpcTypeASpeed = PlayerPrefs.GetFloat("npcTypeASpeed");
            currentNpcSpawnRate = PlayerPrefs.GetFloat("npcSpawnRate");
            currentCactiSpawnRate = PlayerPrefs.GetFloat("cactiSpawnRate");
            macroLevelCount = PlayerPrefs.GetInt("currentLvl");
        }
        else
        {
            currentNpcTypeAWorth = npcMainBaseValue * npcWorthFactor;
            currentNpcTypeALife = npcMainBaseValue * npcLifeFactor;
            currentNpcTypeASpeed = npcMainBaseValue * npcSpeedFactor;
            currentNpcSpawnRate = npcMainBaseValue * npcSpawnRateFactor;
            currentCactiSpawnRate = npcMainBaseValue * cactiSpawnRateFactor;
            PlayerPrefs.SetFloat("npcTypeAWorth", currentNpcTypeAWorth);
            PlayerPrefs.SetFloat("npcTypeALife", currentNpcTypeALife);
            PlayerPrefs.SetFloat("npcTypeASpeed", currentNpcTypeASpeed);
            PlayerPrefs.SetFloat("npcSpawnRate", currentNpcSpawnRate);
            PlayerPrefs.SetFloat("cactiSpawnRate", currentCactiSpawnRate);
            PlayerPrefs.SetInt("currentLvl", 1);
        }
        levelText.text = "Level: " + macroLevelCount;
    }

    // Update is called once per frame
    void Update()
    {
        microSegmentCounter += Time.deltaTime;
        if (microSegmentCounter >= microSegmentLength)
        {
            microLevelCount++;
            microSegmentCounter = 0f;

            if (microLevelCount / macroSegmentCount == 1)
            {
                // Level up! powering up with macro factor
                macroLevelCount++;
                microLevelCount = 1;

                powerUpMacro();
            } else
            {
                // Micro Sement up! powering up with micro factor
                PowerUpMicro();
            }
        }
    }

    private void PowerUpMicro()
    {
        // powering up speed and spawn rate on segment up
        currentNpcTypeASpeed += microGrowthFactor;
        currentNpcSpawnRate -= microGrowthFactor;
    }

    private void powerUpMacro()
    {
        // powering up life and worth on lvl up
        currentNpcTypeAWorth += microGrowthFactor * macroSegmentCount;
        currentNpcTypeALife += microGrowthFactor * macroSegmentCount;

        float factorValue = macroSegmentCount * microGrowthFactor * macroGrowthFallbackPercentage;
        currentNpcTypeAWorth -= factorValue;
        currentNpcTypeALife -= factorValue;
        currentNpcTypeASpeed -= factorValue;
        currentNpcSpawnRate -= factorValue;
        currentCactiSpawnRate -= factorValue;

        lvlUpAnimator.SetTrigger("LevelUp");
        levelText.text = "Level: " + macroLevelCount;

        // updating player prefs

        PlayerPrefs.SetFloat("npcTypeAWorth", currentNpcTypeAWorth);
        PlayerPrefs.SetFloat("npcTypeALife", currentNpcTypeALife);
        PlayerPrefs.SetFloat("npcTypeASpeed", currentNpcTypeASpeed);
        PlayerPrefs.SetFloat("npcSpawnRate", currentNpcSpawnRate);
        PlayerPrefs.SetFloat("cactiSpawnRate", currentCactiSpawnRate);
        PlayerPrefs.SetInt("currentLvl", macroLevelCount);
    }

    public void onRestartFight()
    {
        npcMgr.resetNPC();
        gameMgr.toggleFreeze();
        gameMgr.toggleMenu(gameOverCanvas);
        playerMgr.resetLife();
        scoreMgr.resetScore();
        cactiMgr.resetCactiStats();
        skillsMgr.resetSkillsStatus();

        // restarting to beginning of level
        microLevelCount = 1;
        currentNpcTypeAWorth = PlayerPrefs.GetFloat("npcTypeAWorth");
        currentNpcTypeALife = PlayerPrefs.GetFloat("npcTypeALife");
        currentNpcTypeASpeed = PlayerPrefs.GetFloat("npcTypeASpeed");
        currentNpcSpawnRate = PlayerPrefs.GetFloat("npcSpawnRate");
        currentCactiSpawnRate = PlayerPrefs.GetFloat("cactiSpawnRate");
    }


    public float getNpcSpeed()
    {
        return currentNpcTypeASpeed;
    }

    public float getNpcLife()
    {
        return currentNpcTypeALife;
    }

    public float getNpcWorth()
    {
        return currentNpcTypeAWorth;
    }

    public float getNpcSpawnRate()
    {
        return currentNpcSpawnRate;
    }

    public float getCactiSpawnRate()
    {
        return currentCactiSpawnRate;
    }

    public int getSplitCount()
    {
        return currentSpitSplitCount;
    }
}
