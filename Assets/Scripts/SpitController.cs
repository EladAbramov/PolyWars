using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitController : MonoBehaviour
{

    public GameObject parentWrapper;
    SpitWrapperManager spitWrapperMgr;
    public GameObject SpitRicochet;
    private bool isAllowedToSplit = true;
    // Start is called before the first frame update
    void Start()
    {
        spitWrapperMgr = parentWrapper.GetComponent<SpitWrapperManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Wall"))
        {

            Destroy(parentWrapper);
        }
        if (collision.gameObject.tag.Contains("NPC"))
        {
            ScoreManager.scoreValue = ScoreManager.scoreValue + 1;

            collision.gameObject.GetComponent<NPCController>().initDeath();

            Destroy(parentWrapper);
        }
        if (collision.gameObject.tag.Contains("Cactus"))
        {
            string skillType = collision.gameObject.GetComponent<SpriteRenderer>().sprite.ToString();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillsManager>().incrementSkill(skillType);
            Destroy(collision.gameObject);
            Destroy(parentWrapper);
        }

        if (collision.gameObject.tag.Contains("Spit"))
        {
            // Attempt to Split Spit
            attemptSplit();
            collision.gameObject.GetComponent<SpitController>().attemptSplit();
            
        }
    }

    private void attemptSplit()
    {
        if (spitWrapperMgr.spitSize >= spitWrapperMgr.spitSplitThreshold && isAllowedToSplit)
        {
            // ************************************** WARNING ******************************************
            // Must Prevent from splitting again, otherwise will cause massive instantiating amount
            isAllowedToSplit = false;
            // *****************************************************************************************

            // current spit is ready to split
            splitSpit();
        }
    }

    private void splitSpit()
    {
        int spitSplitCount = spitWrapperMgr.getSpitSplitCount();
        float degree = 360 / spitSplitCount;
        float degreeOffset = degree / (spitSplitCount + 1);

        for (int i = 1; i <= spitSplitCount; i++)
        {
            GameObject spitObject = Instantiate(SpitRicochet, parentWrapper.transform.position, Quaternion.Euler(0, 0, (degree * i) )) as GameObject;
            spitObject.GetComponent<SpitWrapperManager>().setSpitParams(5, 1, spitSplitCount);
        }

        Destroy(parentWrapper);
    }
}
