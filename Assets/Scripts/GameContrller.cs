
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using Mono.Cecil.Cil;
//*****************************************
//创建人：BPS
//创建时间：
//功能说明：
//*****************************************
public class GameContrller : MonoBehaviour
{
    public Image image;
    public float showTime;
    public GameObject RPGTalk;
    private RPGTalk rPGTalk;
    public AudioSource AudioSource;
    public AudioClip AudioClip;
    public Player player;
    bool iscomplete;
    private void Awake()
    {
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponentInChildren<Player>();
            player.isControled = false;
        }
    }
    void Start()
    {
        rPGTalk = RPGTalk.GetComponent<RPGTalk>();
        StartCoroutine(showCanvas());
    }

     void Update()
    {
        
    }
    IEnumerator showCanvas()
    {
        //TODO:闹钟响起
        if(AudioSource != null) { AudioSource.PlayOneShot(AudioClip); }
        
        for (int i = 0; i < 255; i++)
        {
            image.color = new Color(0f, 0f, 0f, image.color.a - 1 / 255f);
            yield return new WaitForSeconds(showTime / 255f);
        }
        RPGTalk.SetActive(true);
        while (RPGTalk.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            yield return new WaitForEndOfFrame();
        }
        player.isControled = true;
        image.transform.parent.gameObject.SetActive(false);
        yield return null;
    }
}
