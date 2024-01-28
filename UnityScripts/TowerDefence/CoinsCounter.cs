using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    public static int coin=200;
    public GameObject CoinCounter;
    private TMP_Text txt;

    
    private void Update(){
        txt = CoinCounter.GetComponent<TMPro.TextMeshProUGUI>();
        txt.text = ""+coin +"$";
    }
}
