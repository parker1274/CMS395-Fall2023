using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinscript : MonoBehaviour
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
            if (other.gameObject.CompareTag("player"))
            {
                gameObject.SetActive(false);
                count++;
                SetCountText();
            }
        }

        void SetCountText()
        {
        point.text = "Coins: "+count.ToString();
        }
        // Start is called before the first frame update
}

