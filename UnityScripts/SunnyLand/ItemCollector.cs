using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int coin=0;
    [SerializeField] private TextMeshProUGUI coinText;
    void OnTriggerEnter2D(Collider2D collider2D) {
         if (collider2D.gameObject.CompareTag("Coin")) {
             Destroy (collider2D.gameObject);
             ++coin;
             coinText.text = "Coins: "+ coin;}
    }
}