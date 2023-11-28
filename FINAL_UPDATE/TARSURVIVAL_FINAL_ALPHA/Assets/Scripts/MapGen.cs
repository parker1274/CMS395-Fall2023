using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public GameObject ocean;
    public GameObject island1;
    bool islandGen = false;

    void Start()
    {
        Vector3 start = new Vector3(0,0,0);
        for(int i = 0; i < 25; i++)
        {
           for(int x = 0; x < 25; x++)
            {
                int randomInt = (int)Random.Range(1f, 100f);
                if (randomInt < 95 || islandGen == true)
                {
                    Instantiate(ocean, start, Quaternion.identity);
                    islandGen = false;
                } else if (randomInt >= 95 && islandGen == false)
                {
                    Instantiate(island1, start, Quaternion.identity);
                    islandGen = true;
                } 
                start.x += 20f;
            }
            start.x = 0;
            start.y += 20f;
        }



    }
}
