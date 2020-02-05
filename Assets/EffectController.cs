using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public float cooldown = 0.5f;
    private float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= cooldown)
        {
            Destroy(gameObject);
        }
    }
}
