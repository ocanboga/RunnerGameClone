using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) {
            Destroy(other.gameObject);
            AddCoin();
            Debug.Log("Coine Çarptı");
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
