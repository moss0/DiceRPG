using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float health, damage, defence, speed, hitPeriod;
    public string myName;
    public float _rbVelocityMagnitude;
    [Header("0: Player, 1: Enemy, 2: h")]  public int typeIndex;

    private float _xAxis, _yAxis, _fixedSpeed, _timer;
    private Rigidbody2D _rb;

    [Header("Enemy exclusive")]
    private GameObject player;
    private static float minLockOnDist = 3f, maxDistanceDelta = 0.005f;
    
    public bool enemyInBattleRange, playerInBattleRange;

    private static float _enemyTimer1Threshold = 5f, _enemyTimer2Threshold = 3f;
    private float _enemyTimer1 = 0f, _enemyTimer2;

    private Vector3 targetPosition;
    private bool _enemyRandomPointGenerated = false;
    private Vector3 _enemyRandomPoint;
    [SerializeField] private bool _enemyLockedOn;

    private PawnTrigger triggerChild;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (typeIndex == 1)
        {
            player = GameObject.FindWithTag("Player");
        }
        _fixedSpeed = speed * Time.deltaTime;
        triggerChild = GetComponentInChildren<PawnTrigger>();
    }

    private void FixedUpdate()
    {
        PlayerMovementVectorSetup();
    }

    private void Update()
    {
        switch (typeIndex)
        {
            case 0:
                PlayerMovementInputs();
                break;

            case 1:
                EnemyMovement();
                break;

            case 2:

                break;

            default:
                Debug.LogWarning("Unknown pawn type");
                break;
        }
    }

    private void PlayerMovementInputs()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _yAxis = Input.GetAxisRaw("Vertical");
    }
    private void PlayerMovementVectorSetup()
    {
        Vector2 v = new Vector2(_xAxis, _yAxis).normalized;
        _rb.velocity = v * _fixedSpeed;
    }
    

    private void EnemyMovement()
    {
        Vector2 vectDiff = player.transform.position - transform.position;
        if (vectDiff.magnitude < minLockOnDist)
        {
            _enemyLockedOn = true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, maxDistanceDelta * _fixedSpeed);
            Debug.DrawLine(transform.position, player.transform.position);
        }
        else
        {
            _enemyLockedOn = false;
            _enemyTimer1 += Time.deltaTime;
            if (_enemyTimer1 >= _enemyTimer1Threshold)
            {
                _EnemyRandomIdleMovement();
            }
        }
    }

    private void _EnemyRandomIdleMovement()
    {
        if (_enemyRandomPointGenerated == false)
        {
            _enemyRandomPointGenerated = true;
            _enemyRandomPoint = Random.insideUnitCircle.normalized * 2f;
        }

        Debug.DrawLine(transform.position, targetPosition);
        targetPosition = transform.position + _enemyRandomPoint;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, maxDistanceDelta);
        
        _enemyTimer2 += Time.deltaTime;
        if (_enemyTimer2 >= _enemyTimer2Threshold)
        {
            _enemyTimer1 = 0;
            _enemyTimer2 = 0;
            _enemyRandomPointGenerated = false;
        }
    }




    // garbage pile


    //if (_EnemyRandomPointReached == true)
    //{
    //    float multiplier = Random.Range(3f, 7f);
    //    _EnemyRandomVector = Random.insideUnitCircle.normalized * multiplier;
    //    Vector3 h = transform.position;
    //    targetPosition = h + _EnemyRandomVector;
    //}
    //_EnemyRandomPointReached = false;
    //Debug.DrawLine(transform.position, targetPosition);

    //transform.position = Vector2.MoveTowards(transform.position, targetPosition, maxDistanceDelta);

    //if (transform.position == targetPosition)
    //{
    //    _currentTimer = 0f;
    //    _EnemyRandomPointReached = true;
    //}
}
