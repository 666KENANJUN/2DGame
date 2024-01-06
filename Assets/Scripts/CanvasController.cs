using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//*****************************************
//创建人：BPS
//创建时间：
//功能说明：
//*****************************************
public class CanvasController : MonoBehaviour
{
    public Button exit;
    public Text text;
    public Sign sign;
    private void Awake()
    {
        sign = GameObject.Find("Sign").GetComponent<Sign>();
        exit.onClick.AddListener(() =>
        {
            sign.isInstantiated = false;
            Destroy(gameObject);
        });
    }
}
