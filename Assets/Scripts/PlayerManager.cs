using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    Touch touch;
    public float speed = 2f;
    public float angleFactor = 0f;
    public GameObject spit;
    public RectTransform spitSpawn;
    public float spitWrapperFactor = 100f;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public int heartCounter = 3;
    public GameObject GameOverPanel;
    public GameObject gameOverCanvas;
    private bool isGameOverCanvasShown = false;
    public GameObject GameManagerObject;
    float spitRateCounter = 2f;
    public float spitRate = 2f;

    private bool isAnchorSet = false;
    private float anchorFirstY;
    private float anchorLastY;

    public GameObject anchor;

    public float anchorFactor = 2f;
    private float spitPowerFactor = 1f;
    private float spitSizeFactor = 1f;
    public float spitSizeGap = 3f;

    public GameObject PlayerHead;
    float playerHeadAnchor;
    public float headWidthrawFactor;

    private bool releaseHead = false;
    public float headReleaseFactor;

    public GameObject Chevron;

    public GameObject Bar;

    private GameObject SizeBar;
    private GameObject SpeedBar;

    public GameObject SizeIcon;
    public GameObject SpeedIcon;

    private float SpeedGap = 12f;

    private LevelsController lvlsController;


    // Start is called before the first frame update
    void Start()
    {
        instantiateBars();
        playerHeadAnchor = PlayerHead.transform.localPosition.y;
        lvlsController = GameManagerObject.GetComponent<LevelsController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (spitSizeFactor < spitSizeGap)
            {
                spitSizeFactor += Time.deltaTime;
            }

            // Player Spin
            touch = Input.GetTouch(0);
            Vector2 direction = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle + angleFactor, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            float distance = Vector3.Distance(Camera.main.ScreenToWorldPoint(touch.position), transform.position);

            if (!isAnchorSet)
            {
                // setting an imaginary anchor to calculate spit power via its relative y to player
                isAnchorSet = true;
                anchorFirstY = (distance * anchorFactor);
                anchor.transform.localPosition = new Vector3(anchor.transform.localPosition.x, -(anchorFirstY), anchor.transform.localPosition.z);
            }

            float currentAnchorY = (distance * anchorFactor);

            if (currentAnchorY < anchorFirstY)
            {
                removeSpitBars();
                Chevron.SetActive(false);
                releaseHead = true;
                spitSizeFactor = 1f;
                isAnchorSet = false;
            }

            if (currentAnchorY > anchorFirstY && isAnchorSet)
            {
                Chevron.SetActive(true);

                updateSpitSizeBar(spitSizeFactor);
                updateSpitSpeedBar(currentAnchorY, anchorFirstY);

                pullHead(currentAnchorY, anchorFirstY);
            }


        }

        spitRateCounter += Time.deltaTime;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Chevron.SetActive(false);
            if (spitRateCounter >= spitRate)
            {
                float distance = Vector3.Distance(Camera.main.ScreenToWorldPoint(touch.position), transform.position);
                anchorLastY = (distance * anchorFactor);
                if (anchorLastY > anchorFirstY && isAnchorSet)
                {
                    // vector of slide is positive and can spit
                    // power = (anchorLastY - anchorFirstY) with some factor
                    spitPowerFactor = (anchorLastY - anchorFirstY);

                    spitRateCounter = 0;
                    if (!gameObject.GetComponent<AudioSource>().isPlaying)
                    {
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                    LaunchProjectile(transform, spitPowerFactor, spitSizeFactor);

                    releaseHead = true;
                }
            }
            spitSizeFactor = 1f;
            isAnchorSet = false;
            removeSpitBars();
        }

        if (Input.touchCount == 0)
        {
            removeSpitBars();
            Chevron.SetActive(false);
            releaseHead = true;
            spitSizeFactor = 1f;
            isAnchorSet = false;
        }

        if (releaseHead)
        {
            releaseHeadAction();
        }
    }

    private void updateSpitSpeedBar(float currentAnchorY, float anchorFirstY)
    {

        SpeedBar.SetActive(true);
        float speedFormat;
        if (currentAnchorY - anchorFirstY > SpeedGap)
        {
            speedFormat = 1;
        }
        else
        {
            speedFormat = (currentAnchorY - anchorFirstY) / 12;
        }
        SpeedBar.GetComponent<PowerAndSpeedSpitBars>().SetSize(speedFormat);
    }

    private void updateSpitSizeBar(float spitSizeFactor)
    {
        SizeBar.SetActive(true);
        SizeBar.GetComponent<PowerAndSpeedSpitBars>().SetSize((spitSizeFactor - 1) / 2);
    }

    private void removeSpitBars()
    {
        SizeBar.SetActive(false);
        SpeedBar.SetActive(false);
    }

    private void releaseHeadAction()
    {
        if (PlayerHead.transform.localPosition.y < playerHeadAnchor)
        {
            PlayerHead.transform.localPosition = new Vector3(PlayerHead.transform.localPosition.x, PlayerHead.transform.localPosition.y + headReleaseFactor, PlayerHead.transform.localPosition.z);
        } else
        {
            releaseHead = false;
        }
    }

    private void pullHead(float currentAnchorY, float anchorFirstY)
    {
        float headPosition = Mathf.Sqrt(currentAnchorY - anchorFirstY) * headWidthrawFactor;
        PlayerHead.transform.localPosition = new Vector3(PlayerHead.transform.localPosition.x, playerHeadAnchor - headPosition, PlayerHead.transform.localPosition.z);
    }

    public void LaunchProjectile(Transform transform, float spitPowerFactor, float spitSizeFactor)
    {
        GameObject spitObject = Instantiate(spit, spitSpawn.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - spitWrapperFactor)) as GameObject;
        spitObject.GetComponent<SpitWrapperManager>().setSpitParams(spitPowerFactor, spitSizeFactor, lvlsController.getSplitCount());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("NPC"))
        {
            collision.gameObject.GetComponent<NPCController>().initDeath();
            heartCounter--;
             
        }
        if (heartCounter == 2)
        {
            Heart3.SetActive(false);
        }
        if (heartCounter == 1)
        {
            Heart2.SetActive(false);
        }
        if (heartCounter == 0)
        {
            GameManagerObject.GetComponent<GameManager>().toggleFreeze();
            switchToGameOver();
            Heart1.SetActive(false);
        }


    }

    public void switchToGameOver()
    {
        GameManagerObject.GetComponent<GameManager>().toggleMenu(gameOverCanvas);
    }

    public void resetLife()
    {
        heartCounter = 3;
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
    }

    public void instantiateBars()
    {
        SizeBar = Instantiate(Bar, new Vector3(-9.6f, -2f, 0), Quaternion.Euler(0, 0, 90));
        SpeedBar = Instantiate(Bar, new Vector3(9.6f, -2f, 0), Quaternion.Euler(0, 0, 90));

        Instantiate(SizeIcon, new Vector3(-9.6f, -4.2f, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(SpeedIcon, new Vector3(9.6f, -4.2f, 0), Quaternion.Euler(0, 0, 0));
    }
}
