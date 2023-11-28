using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    private bool checkOne = false;
    private bool checkTwo = false;
    private bool checkThree = false;
    private bool clear = true;
    private int One = 0;
    private int Two = 0;
    private int Three = 0;
    private int Four = 0;
    private int Five = 0;
    private int Six = 0;
    private int Seven = 0;
    private int Eight = 0;
    private int Nine = 0;
    private int Ten = 0;

    public GameObject islandOne;
    public GameObject islandTwo;
    public GameObject islandThree;
    public GameObject islandFour;
    public GameObject islandFive;
    public GameObject islandSix;
    public GameObject islandSeven;
    public GameObject islandEight;
    public GameObject islandNine;
    public GameObject islandTen;
    public GameObject islandEleven;
    public GameObject storyOne;
    public GameObject storyTwo;
    public GameObject storyThree;

    public GameObject ocean;
    Vector3 start = new Vector3(0, 0, 0);
    private int[,] myArray = new int[25, 25];
    

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
                if (x == 10 & i == 10)
                {
                    if(checkOne == false && checkTwo == false && checkThree == false)
                    {
                        clear = false;
                    }
                }
                if (x == 15 & i == 15)
                {
                   if(checkOne == false && checkTwo == false)
                    {
                        clear = false;
                    }
                    if (checkOne == false && checkThree == false)
                    {
                        clear = false;
                    }
                    if (checkTwo == false && checkThree == false)
                    {
                        clear = false;
                    }
                }
                if (x == 20 & i == 20)
                {
                    if(checkOne == false || checkTwo == false || checkThree == false)
                    {
                        clear = false;
                    }
                }
                float randomInt = (int)Random.Range(1f, 1001f);
                if (myArray[i, x] == 1)
                {
                    Instantiate(ocean, start, Quaternion.identity);
                }
                else if (myArray[i, x] == 0 && randomInt >= 947 && clear == true)
                {
                    if (randomInt <= 948 && checkOne == false)
                    {
                        Instantiate(storyOne, start, Quaternion.identity);
                        checkOne = true;
                    }
                    else if (randomInt > 948 & randomInt <= 949 && checkTwo == false)
                    {
                        Instantiate(storyTwo, start, Quaternion.identity);
                        checkTwo = true;
                    }
                    else if (randomInt > 949 & randomInt <= 950 && checkThree == false)
                    {
                        Instantiate(storyThree, start, Quaternion.identity);
                        checkThree = true;
                    }
                    else if (randomInt <= 999 && randomInt > 950)
                    {
                        spin();
                    } 
                    else 
                    {
                        Instantiate(islandEleven, start, Quaternion.identity);
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
                else if (myArray[i, x] == 0 && clear == false)
                {
                    if (checkOne == false)
                    {
                        Instantiate(storyOne, start, Quaternion.identity);
                        checkOne = true;
                        clear = true;
                    } else if (checkTwo == false)
                    {
                        Instantiate(storyTwo, start, Quaternion.identity);
                        checkTwo = true;
                        clear = true;
                    } else
                    {
                        Instantiate(storyThree, start, Quaternion.identity);
                        checkThree = true;
                        clear = true;
                    }
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
    void spin()
    {

        float randomIsland = (int)Random.Range(1f, 11f);
        if (randomIsland == 1 && One <= 2)
        {
            Instantiate(islandOne, start, Quaternion.identity);
            One += 1;
        }
        else if (randomIsland == 2 && Two <= 2)
        {
            Instantiate(islandTwo, start, Quaternion.identity);
            Two += 1;
        }
        else if (randomIsland == 3 && Three <= 2)
        {
            Instantiate(islandThree, start, Quaternion.identity);
            Three += 1;
        }
        else if (randomIsland == 4 && Four <= 2)
        {
            Instantiate(islandFour, start, Quaternion.identity);
            Four += 1;
        }
        else if (randomIsland == 5 && Five <= 2)
        {
            Instantiate(islandFive, start, Quaternion.identity);
            Five += 1;
        }
        else if (randomIsland == 6 && Six <= 2)
        {
            Instantiate(islandSix, start, Quaternion.identity);
            Six += 1;
        }
        else if (randomIsland == 7 && Seven <= 2)
        {
            Instantiate(islandSeven, start, Quaternion.identity);
            Seven += 1;
        }
        else if (randomIsland == 8 && Eight <= 2)
        {
            Instantiate(islandEight, start, Quaternion.identity);
            Eight += 1;
        }
        else if (randomIsland == 9 && Nine <= 2)
        {
            Instantiate(islandNine, start, Quaternion.identity);
            Nine += 1;
        }
        else if (randomIsland == 10 && Ten <= 2)
        {
            Instantiate(islandTen, start, Quaternion.identity);
            Ten += 1;
        }
        else if (One > 2 && Two > 2 && Three > 2 && Four > 2 && Five > 2 && Six > 2 && Seven > 2 && Eight > 2 && Nine > 2 && Ten > 2)
        {
            Instantiate(ocean, start, Quaternion.identity);
        } else
        {
            spin();
        }

    }
}
