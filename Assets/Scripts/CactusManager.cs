using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CactusManager : MonoBehaviour
{
    private float CactusSkiilStart = 0f;
    public float CactusSkillCooldown = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CactusSkiilStart += Time.deltaTime;
        if (CactusSkiilStart >= CactusSkillCooldown)
        {
            CactusSkiilStart = 0;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Cacti"))
        {
            Destroy(collision.gameObject);
        }
    }
}
