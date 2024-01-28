using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public void CoinSpend(){
        if(CoinsCounter.coin>=50){
    CoinsCounter.coin-=50;
    Turret.range+=3f;
        }
}}
