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

    [SerializeField]private float _xAxis, _yAxis, _fixedSpeed, _timer;
    private Rigidbody2D _rb;

    [Header("Enemy exclusive")]
    public GameObject player;
    public float minLockOnDist = 3f, maxDistanceDelta = 0.005f;
    [SerializeField] private float _currentTimer = 0f, _timeToComplete = 5f;
    
    private Vector3 targetPosition;
    private bool _EnemyRandomPointReached = true;
    private Vector3 _EnemyRandomVector;
    private Vector3 _EnemyStoredPosition;
    public void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
                //_rbVelocityMagnitude = _rb.velocity.magnitude;
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

    public void PlayerMovementInputs()
    {
        _xAxis = Input.GetAxisRaw("Horizontal");
        _yAxis = Input.GetAxisRaw("Vertical");
    }
    private void PlayerMovementVectorSetup()
    {
        Vector2 v = new Vector2(_xAxis, _yAxis).normalized;
        _rb.velocity = v * speed * Time.deltaTime;
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
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _timeToComplete)
            {
                if (_EnemyRandomPointReached == true)
                {
                    float multiplier = Random.Range(3f, 7f);
                    _EnemyRandomVector = Random.insideUnitCircle.normalized * multiplier;
                    Vector3 h = transform.position;
                    targetPosition = h + _EnemyRandomVector;
                }
                _EnemyRandomPointReached = false;


                transform.position = Vector2.MoveTowards(transform.position, targetPosition, maxDistanceDelta);

                if (transform.position == targetPosition)
                {
                    _currentTimer = 0f;
                    _EnemyRandomPointReached = true;
                }

                
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
