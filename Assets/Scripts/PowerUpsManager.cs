using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsManager : MonoBehaviour
{
    public GameObject PowerUpsCanvas;
    public GameObject PowrUpsPanel;
    private bool isPowerUpsCanvasShown = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchToPowerUpsMenu()
    {
        PowerUpsCanvas.GetComponent<Canvas>().sortingOrder = isPowerUpsCanvasShown ? -1 : 5;
        PowrUpsPanel.GetComponent<Image>().raycastTarget = !isPowerUpsCanvasShown;
        isPowerUpsCanvasShown = !isPowerUpsCanvasShown;
    }

    
}