using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camS : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public Button map;
    // Start is called before the first frame update
    void Start()
    {
        map.onClick.AddListener(OnClickButtonOne);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickButtonOne()
    {
        Debug.Log("click");
        if (c1.activeSelf == false)
        {
            c1.SetActive(true);
            c2.SetActive(false);
        } else
        {
            c2.SetActive(true);
            c1.SetActive(false);
        }

    }
}
