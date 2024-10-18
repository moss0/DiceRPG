using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float health, damage, defence, speed, hitPeriod, minLockOnDist, maxDistanceDelta = 0.005f;
    private float xAxis, yAxis, fixedSpeed;
    public bool isEnemy;
    public string myName;
    public Rigidbody2D myRigidBody;
    public GameObject player;
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
        if (isEnemy == true)
        {
            EnemyMovement();
        }
    }

    public void ControlMovement()
    {
        fixedSpeed = speed * Time.deltaTime;
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector2(xAxis * fixedSpeed, yAxis * fixedSpeed);
    }
    
    public void EnemyMovement()
    {
        Vector3 vectDiff = player.transform.position - transform.position;
        fixedSpeed = maxDistanceDelta * Time.deltaTime;
        if (Vector3.Magnitude(vectDiff) < minLockOnDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxDistanceDelta);
        }
        else
        {

        }
        /*for (int i = 0; i < 60f * 1 / Time.deltaTime; i++)
        {
            Debug.Log(Vector3.Magnitude(vectDiff));
            i = 0;
        }*/

    }

    public void TakeDamage()
    {
        
    }
    public void Attack()
    {

    }
}
