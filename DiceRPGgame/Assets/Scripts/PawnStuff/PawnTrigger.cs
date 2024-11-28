using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }
    }
}
