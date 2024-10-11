using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
namespace Dice
{
    public class DiceManager : MonoBehaviour
    {
        public Button rollDice;
        public TMP_Text D6result;
        public TMP_Text D12result;
        public TMP_Text D20result;
        public void Start()
        {
            List<int> diceValues = new List<int>();
            diceValues.Add(6);
            diceValues.Add(12);
            diceValues.Add(20);
            rollDice.onClick.AddListener(DiceRoll);
        }

        
        private void DiceRoll()
        {
            int D6result = Random.Range(1, 7);
            int D12result = Random.Range(1, 13);
            int D20result = Random.Range(1, 21);
            Debug.Log("D6: " + D6result);
            Debug.Log("D12: " + D12result);
            Debug.Log("D20: " + D20result);
        }
}
    }
