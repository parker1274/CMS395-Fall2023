using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coincounter : MonoBehaviour
{
        // Start is called before the first frame update
        Rigidbody2D rd;
        public Text point;
        public static int count;
        void Start()
        {
            count = 0;
            SetCountText();
        }
        // Update is called once per frame
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("coin"))
            {
                gameObject.SetActive(false);
                count++;
                SetCountText();
            }
        }

        void SetCountText()
        {
        point.text = " "+count.ToString();
        }
        // Start is called before the first frame update
}
