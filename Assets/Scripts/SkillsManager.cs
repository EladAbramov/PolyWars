using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillsManager : MonoBehaviour
{
    public GameObject redCactusSkill;
    public GameObject blueCactusSkill;
    public GameObject greenCactusSkill;
    GameObject player;
    public float freezeTime=5f;
    float timeLeft;
    DateTime invincible = DateTime.Now;

    public Sprite[] redSprites;
    public Sprite[] blueSprites;
    public Sprite[] greenSprites;

    int redCounter = 0;
    int blueCounter = 0;
    int greenCounter = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    public void incrementSkill(string skillType)
    {
        
        if (skillType.Contains("Red"))
        {
            incrementSkillAction(redCounter, redCactusSkill, redSprites, "red");
        } else if (skillType.Contains("Blue"))
        {
            incrementSkillAction(blueCounter, blueCactusSkill, blueSprites, "blue");
        } else if (skillType.Contains("Green"))
        {
            incrementSkillAction(greenCounter, greenCactusSkill, greenSprites, "green");
        }
    }

    private void incrementSkillAction(int selectedCounter, GameObject selectedCactusSkill, Sprite[] selectedSprites, string counterType)
    {
        if (selectedCounter < 3)
        {
            selectedCactusSkill.GetComponent<SpriteRenderer>().sprite = selectedSprites[selectedCounter];
            incrementCounter(counterType);
        }

        
    }

    void incrementCounter(string counterType)
    {
        switch (counterType)
        {
            case "red":
                redCounter++;
                return;
            case "blue":
                blueCounter++;
                return;
            case "green":
                greenCounter++;
                return;
        }
    }

    public void activeCactusRedSkill()
    {
        if (redCounter==3)
        {
            StartFreezePosition();
            redCounter = 0;
            redCactusSkill.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
    public void activeCactusBlueSkill()
    {
        if (blueCounter == 3)
        {
            player.GetComponent<PlayerManager>().spitRate=0.1f;
            blueCounter = 0;
            timeLeft = 5.0f;

            while (timeLeft > 0)
            {
                Debug.Log(timeLeft);
                timeLeft -= Time.deltaTime;
            }
            player.GetComponent<PlayerManager>().spitRate = 2f;
            blueCactusSkill.GetComponent<SpriteRenderer>().sprite = null;

        }
    }

    public void activeCactusGreenSkill()
    {
        if (greenCounter == 3){

            startGetInvulnerable();
            greenCounter = 0;
            greenCactusSkill.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void startGetInvulnerable()
    {
        StartCoroutine("GetInvulnerable");
    }

    public IEnumerator GetInvulnerable()
    {
        Debug.Log("jj");
        if (invincible <= DateTime.Now)
        {
            invincible = DateTime.Now.AddSeconds(5);

        }
        Debug.Log("CC");

        Physics2D.IgnoreLayerCollision(0, 1, true);
        yield return new WaitForSeconds(10f);
        Physics2D.IgnoreLayerCollision(0, 1, false);

    }

    public void StartFreezePosition()
{
        StartCoroutine(freezePosition());
    }
    public IEnumerator freezePosition()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            npc.GetComponent<NPCController>().enabled = false;
        }
        yield return new WaitForSeconds(freezeTime);

        foreach (GameObject npc in npcs)
        {
            npc.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            npc.GetComponent<NPCController>().enabled = true;
        }
        
        
    }


    public void resetSkillsStatus()
    {
        redCounter = 0;
        blueCounter = 0;
        greenCounter = 0;
        redCactusSkill.GetComponent<SpriteRenderer>().sprite = null;
        blueCactusSkill.GetComponent<SpriteRenderer>().sprite = null;
        greenCactusSkill.GetComponent<SpriteRenderer>().sprite = null;
    }

   
}
