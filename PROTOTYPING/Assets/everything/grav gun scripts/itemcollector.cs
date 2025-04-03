using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemcollector : MonoBehaviour
{
    private int Score;
    private bool meatScored;
    private bool veggieScored;
    private bool spiceScored;
    private bool waterScored;
    [SerializeField]private Text ScoreText;
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            if(meatScored== false)
            {
                Destroy(collision.gameObject);
                Score++;
                ScoreText.text = "Score:" + Score;
                meatScored = true;
            }
            else
            {
                Destroy(collision.gameObject);
            }
            
        }

        if (collision.gameObject.CompareTag("Veggie"))
        {
            if (veggieScored == false)
            {
                Destroy(collision.gameObject);
                Score++;
                ScoreText.text = "Score:" + Score;
                veggieScored = true;
            }
            else
            {
                Destroy(collision.gameObject);
            }

        }

        if (collision.gameObject.CompareTag("Spice"))
        {
            if (spiceScored == false)
            {
                Destroy(collision.gameObject);
                Score++;
                ScoreText.text = "Score:" + Score;
                spiceScored = true;
            }
            else
            {
                Destroy(collision.gameObject);
            }

        }

        if (collision.gameObject.CompareTag("Water"))
        {
            if (waterScored == false)
            {
                Destroy(collision.gameObject);
                Score++;
                ScoreText.text = "Score:" + Score;
                waterScored = true;
            }
            else
            {
                Destroy(collision.gameObject);
            }

        }

    }

    

}

