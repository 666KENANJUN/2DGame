using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//*****************************************
//创建人：BPS
//创建时间：
//功能说明：
//*****************************************
public class Sign : MonoBehaviour
{
    public GameObject prefab;
    public RPGTalk rPGalk;
    public GameObject interact;
    [HideInInspector]
    bool isComplete = false;
    bool isTrigger = true;
    bool isClicked = false;
    [HideInInspector]
    public bool isInstantiated = false;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            interact.SetActive(true);
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            interact.SetActive(false);
            isTrigger = false;
        }
    }

    void Update()
    {
        if (!isComplete && isClicked)
        {
            isComplete = !isComplete;
            rPGalk.NewTalk("3", "8");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTrigger && !isInstantiated)
            {
                interact.SetActive(false);
                Instantiate(prefab);
                isInstantiated = true;
                isClicked = true;
            }
        }
    }
}
