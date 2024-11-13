using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float health, damage, defence, speed, hitPeriod;
    public bool isEnemy;
    public string myName;
    public string[] typeList = {"Player","Enemy","h"};

    private float _xAxis, _yAxis, _fixedSpeed, _timer;
    private Rigidbody2D _rb;
    
    [Header("Enemy exclusive")]
    public GameObject player;
    public float minLockOnDist = 3f, maxDistanceDelta = 0.005f;
    private float _currentTimer = 0f, _timeToComplete = 5f;

    //fix speedy diagonal movement

    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        foreach (string type in typeList)
        {
            switch (type)
            {
                case "Player":
                    PlayerMovement();
                    _timer += Time.deltaTime;
                    if (_timer >= 3f)
                    {
                        Debug.Log(_rb.velocity);
                        _timer = 0f;
                    }
                    break;

                case "Enemy":
                    EnemyMovement();
                    break;

                default:
                    Debug.LogWarning("Unknown pawn type");
                    break;
            }
        }
    }

    public void PlayerMovement()
    {
        _fixedSpeed = speed * Time.deltaTime;
        _xAxis = Input.GetAxis("Horizontal");
        _yAxis = Input.GetAxis("Vertical");
        Vector2 blah = new Vector2 (_xAxis, _yAxis).normalized;
        _rb.velocity = blah * _fixedSpeed;
    }
    
    public void EnemyMovement()
    {
        Vector2 vectDiff = player.transform.position - transform.position;
        _fixedSpeed = maxDistanceDelta * Time.deltaTime;
        if (vectDiff.magnitude < minLockOnDist)
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
