using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dice
{
    public class DiceManager : MonoBehaviour
    {
        public void Start()
        {
            List<string> diceValues = new List<string>();
            diceValues.Add("D6: ");
            diceValues.Add("D12: ");
            diceValues.Add("D20: ");
        }









        //public int D6value;
        //public int D12value;
        //public int D20value;


        //public void Dice6()
        //{
        //    int rng6 = Random.Range(1, 7);
        //    D6value = rng6;
        //}

        //public void Dice12()
        //{
        //    int rng12 = Random.Range(1, 13);
        //    D12value = rng12;
        //}

        //public void Dice20()
        //{
        //    int rng20 = Random.Range(1, 21);
        //    D20value = rng20;
        //}
    }
}
