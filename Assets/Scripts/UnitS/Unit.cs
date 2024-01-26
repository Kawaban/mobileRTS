using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, PointOfInterest, Damagable
{
    [SerializeField] private UnitData unitData;
    [SerializeField] private NavMeshAgent agent;
    private float health;
    private Vector3 destinationPoint;
    private PointOfInterest targetObject;
    private PriorityObserver enemyObserver;
    private UnitStartegyOverseer startegyOverseer;
    private bool dead = false;
    

    public UnitData UnitData { get => unitData;  }
    public NavMeshAgent Agent { get => agent;  }
    public float Health { get => health; set => health = value; }
    public Vector3 DestinationPoint { get => destinationPoint; set => destinationPoint = value; }
    public PriorityObserver EnemyObserver { get => enemyObserver; set => enemyObserver = value; }
    public PointOfInterest TargetObject { get => targetObject; set => targetObject = value; }

    void Start()
    {
        startegyOverseer = new UnitStartegyOverseer(this);
        health = unitData.Health;
        NavigationConfiguration();
        startegyOverseer.setDefaultStrategy();
    }

    

    void Update()
    {
        startegyOverseer.reconsiderStrategy();
        startegyOverseer.ExecuteStrategy();
    }

    private void NavigationConfiguration()
    {
        agent.speed = unitData.Speed;
        agent.acceleration = unitData.Acceleration;
        agent.angularSpeed = unitData.RotationSpeed;
    }

    public PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = PointType.UNIT;
        return priorityInfo;
    }

    public bool damageTaken(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
            return true;
        }
        return false;
    }

    

    private void Death()
    {
        dead = true;
        Destroy(gameObject);
    }

    public void AttackCooldown(UnitAttack unitAttack)
    {
       StartCoroutine(unitAttack.AttackCooldown(unitData.ReloadTime));
    }

    public  bool isDead()
    {
        return dead;
    }
}
