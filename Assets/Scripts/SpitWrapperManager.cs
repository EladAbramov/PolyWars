using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitWrapperManager : MonoBehaviour
{
    public float spitSpeed = 8f;
    public float spitSize;
    public GameObject spitObject;
    public float spitSizeFactor = 0.01f;
    private float spitPowerFactor = 1f;
    public float spitSplitThreshold = 3f;
    private int spitSplitCount;

   
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= transform.right * spitSpeed * Time.deltaTime;
    }

    public void setSpitParams(float spitPower, float newSpitSize, int currentSpitSplitCount)
    {
        spitSplitCount = currentSpitSplitCount;
        spitSize = newSpitSize;
        float sizeFactor = ((spitSize * spitSize) * spitSizeFactor);

        float powerFactor = Mathf.Sqrt(spitPower) * 2;
        spitSpeed += powerFactor;

        spitObject.transform.localScale = new Vector3(spitObject.transform.localScale.x + sizeFactor, spitObject.transform.localScale.y + sizeFactor, spitObject.transform.localScale.z);
    }

    public int getSpitSplitCount()
    {
        return spitSplitCount;
    }
}
