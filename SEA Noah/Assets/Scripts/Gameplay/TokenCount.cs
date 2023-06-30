using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenCount : MonoBehaviour
{

    public int count;
    public Text tokenDisplayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            count++;
            tokenDisplayer.text = count.ToString(); 
        }
    }
}
