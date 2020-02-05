using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject target;
    public float NPCSpeed = 1f;
    private float NPCLife;
    private float NPCWorth;
    private bool isDying = false;
    private float deathTimer = 1f;
    private float timerCounter = 0f;

    public GameObject ShardsEffectObj;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveMonster();
    }

    void MoveMonster()
    {
        if (target != null && !isDying)
        {
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(directionToTarget.x * NPCSpeed,
                                        directionToTarget.y * NPCSpeed);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (isDying)
        {
            timerCounter += Time.deltaTime;
            if (timerCounter >= deathTimer)
            {
                timerCounter = 0f;
                Destroy(gameObject);
            }
        }
    }

    public void setNPCParams(float life, float worth, float speed)
    {
        NPCLife = life;
        NPCWorth = worth;
        NPCSpeed = speed;
    }

    public void initDeath()
    {
        gameObject.GetComponent<Animator>().SetTrigger("DeathAction");
        Instantiate(ShardsEffectObj, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
        isDying = true;
    }
}
