using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float health, damage, defence, speed, hitPeriod;
    private float xAxis, yAxis, fixedSpeed;
    public bool isEnemy;
    public string myName;
    public Rigidbody2D myRigidBody;
    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (isEnemy == false)
        { 
            ControlMovement(); 
        }
        
    }

    public void ControlMovement()
    {
        fixedSpeed = speed * Time.deltaTime;
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector2(xAxis * fixedSpeed, yAxis * fixedSpeed);
    }
    public void TakeDamage()
    {
        
    }
    public void Attack()
    {

    }
}
