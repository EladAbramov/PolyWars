using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAndSpeedSpitBars : MonoBehaviour
{
    private Transform powerBar;

    // Start is called before the first frame update
    private void Awake()
    {
        powerBar = transform.Find("pAnchorBar");
    }

    public void SetSize(float sizeNormalized)
    {
        powerBar.localScale = new Vector3(sizeNormalized, 1f);
    }
    public void SetColor(Color color)
    {
        powerBar.Find("pAnchorBarSprite").GetComponent<SpriteRenderer>().color = color;

    }
}