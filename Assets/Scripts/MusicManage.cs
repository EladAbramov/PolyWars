using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManage : MonoBehaviour
{
    private bool isFxMute = false;
    private bool isPlay = false;
    public GameObject[] fxObjects;
    public GameObject musicControllCanvas;
    public GameObject musicControllPanel;
    private bool isMusicControllCanvasShown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void togglePlay()
    {
        isPlay = !isPlay;
        gameObject.GetComponent<AudioSource>().mute = isPlay;
        
    }

    public void toggleFx()
    {
       isFxMute=!isFxMute;
       foreach(GameObject fxObject in fxObjects)
       {
            fxObject.GetComponent<AudioSource>().mute = isFxMute ;
        }
    }
}
