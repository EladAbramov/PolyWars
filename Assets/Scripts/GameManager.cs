using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject exitPanelCanvas;
    public GameObject exitPanel;
    private bool isExitCanvasShown = false;
    private bool isFreezed = false;

    float intensityRate = 2f;
    float intensityRateCounter = 0f;
    public float npcIntensityRate = 0.05f;
    public float cactiIntensityRate = 0.01f;
    private NPCManager npcMgr;
    private CactiManager cactiMgr;


    // Start is called before the first frame update
    private void Start()
    {
        npcMgr = gameObject.GetComponent<NPCManager>();
        cactiMgr = gameObject.GetComponent<CactiManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        intensityRateCounter += Time.deltaTime;
        if (intensityRateCounter >= intensityRate)
        {
            intensityRateCounter = 0;
            incIntensity();
        }
    }

    public void incIntensity()
    {
        if (npcMgr.spawnRate - npcIntensityRate > 0)
        {
            npcMgr.spawnRate -= npcIntensityRate;
        }
        if (cactiMgr.spawnRate - cactiIntensityRate > 0)
        {
            cactiMgr.spawnRate -= cactiIntensityRate;
        }
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void loadScene()
    {
        SceneManager.LoadScene("Opening", LoadSceneMode.Single);
    }

    public void toggleMenu(GameObject menu)
    {
        menu.SetActive(!menu.active);
    }

    public void toggleFreeze()
    {
        Time.timeScale = isFreezed ? 1 : 0;
        isFreezed = !isFreezed;
    }
}