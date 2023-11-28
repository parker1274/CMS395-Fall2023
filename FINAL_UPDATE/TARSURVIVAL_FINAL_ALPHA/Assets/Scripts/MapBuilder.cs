using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    private int[,] myArray = new int[25, 25];
    Vector3 start = new Vector3(0, 0, 0);

    public GameObject islandOne;
    public GameObject islandTwo;

    public GameObject islandThree;
    public GameObject islandFour;

    public GameObject ocean;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                if (i == 0 || i == 24 || j == 0 || j == 24)
                {
                    myArray[i, j] = 1;
                }
                else
                {
                    myArray[i, j] = 0;
                }
            }
        }
        for (int i = 0; i < 25; i++)
        {
            for (int x = 0; x < 25; x++)
            {
                int randomInt = (int)Random.Range(1f, 100f);
                if (myArray[i, x] == 1)
                {
                    Instantiate(ocean, start, Quaternion.identity);
                }
                else if (myArray[i, x] == 0 && randomInt >= 95)
                {
                    if (randomInt <= 97)
                    {
                        Instantiate(islandOne, start, Quaternion.identity);
                    }
                    else if (randomInt <= 98)
                    {
                        Instantiate(islandTwo, start, Quaternion.identity);
                    }
                    else if (randomInt <= 99)
                    {
                        Instantiate(islandThree, start, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(islandFour, start, Quaternion.identity);
                    }
                    

                    // Boundary checks to ensure you're not accessing outside the array bounds
                    if (i + 1 < 25)
                        myArray[i + 1, x] = 1;
                    if (i - 1 >= 0)
                        myArray[i - 1, x] = 1;
                    if (x + 1 < 25)
                        myArray[i, x + 1] = 1;
                    if (x - 1 >= 0)
                        myArray[i, x - 1] = 1;

                    // Additional boundaries
                    if (i + 1 < 25 && x + 1 < 25)
                        myArray[i + 1, x + 1] = 1;
                    if (i + 1 < 25 && x - 1 >= 0)
                        myArray[i + 1, x - 1] = 1;
                    if (i - 1 >= 0 && x + 1 < 25)
                        myArray[i - 1, x + 1] = 1;
                    if (i - 1 >= 0 && x - 1 >= 0)
                        myArray[i - 1, x - 1] = 1;
                }
                else
                {
                    Instantiate(ocean, start, Quaternion.identity);
                }
                start.x += 20f;
            }
            start.x = 0;
            start.y += 20f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
