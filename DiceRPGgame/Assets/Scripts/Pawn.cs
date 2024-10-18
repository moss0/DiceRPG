using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float health, damage, defence, speed, hitPeriod, minLockOnDist, maxDistanceDelta = 0.005f;
    private float _xAxis, _yAxis, _fixedSpeed;
    public bool isEnemy;
    public string myName;
    public Rigidbody2D myRigidBody;
    public GameObject player;

    private float _currentTimer = 0f, _timeToComplete = 5f;

    // fix speedy diagonal movement

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
        _fixedSpeed = speed * Time.deltaTime;
        _xAxis = Input.GetAxis("Horizontal");
        _yAxis = Input.GetAxis("Vertical");
        myRigidBody.velocity = new Vector2(_xAxis * _fixedSpeed, _yAxis * _fixedSpeed);
    }
    
    public void EnemyMovement()
    {
        Vector2 vectDiff = player.transform.position - transform.position;
        _fixedSpeed = maxDistanceDelta * Time.deltaTime;
        if (Mathf.Sqrt(vectDiff.x * vectDiff.x + vectDiff.y * vectDiff.y) < minLockOnDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, maxDistanceDelta);
        }
        else
        {
            if (_currentTimer >= _timeToComplete)
            {
                // do what you need to here
                //float randomMagnitude = Random.Range(0.5f, 5f);
                Vector3 randomVector = Random.insideUnitCircle; //* randomMagnitude;
                Vector3 targetPosition = transform.position + randomVector;
                Vector3 interpPos = Vector3.Lerp(transform.position, targetPosition,_currentTimer);
                transform.position += interpPos;
                
                _currentTimer = 0f;
            }
            else
            {
                _currentTimer += Time.deltaTime;
            }
        }
    }

    public void TakeDamage()
    {
        
    }
    public void Attack()
    {

    }

    private void Timer()
    {

    }
}
