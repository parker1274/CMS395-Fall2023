using UnityEngine;

public class mapManager : MonoBehaviour
{
    public money map1;
    bool flip = false;
    public GameObject map;
    float waitingTime = 0f; // Waiting time in seconds
    public GameObject info;
    public playerMove counting;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;

    void Start()
    {
        GameObject mapObject = GameObject.Find("player");
        GameObject dockObject = GameObject.Find("docker");
        map1 = mapObject.GetComponent<money>();
        counting = dockObject.GetComponent<playerMove>();
    }

    void Update()
    {
        // Reduce the waiting time based on real-time seconds
        waitingTime -= Time.deltaTime;

        if (Input.GetKey(KeyCode.M))
        {
            if (map1.unlockMap == true && waitingTime <= 0)
            {
                if (flip == false)
                {
                    map.SetActive(true);
                    flip = true;
                    waitingTime = 2f; // Set waiting time to 5 seconds
                }
                else if (flip == true)
                {
                    map.SetActive(false);
                    flip = false;
                    waitingTime = 2f; // Set waiting time to 5 seconds
                }
            }
        }

        if (Input.GetKey(KeyCode.I))
        {
            if (waitingTime <= 0)
            {
                if (flip == false)
                {
                    info.SetActive(true);
                    flip = true;
                    waitingTime = 2f; // Set waiting time to 5 seconds
                }
                else if (flip == true)
                {
                    info.SetActive(false);
                    flip = false;
                    waitingTime = 2f; // Set waiting time to 5 seconds
                }
            }
        }
        if (counting.downing >= 1)
        {
            a1.SetActive(true);
        }
        if (counting.downing >= 10)
        {
            a2.SetActive(true);
        }
        if (counting.downing >= 50)
        {
            a3.SetActive(true);
        }

    }
}

