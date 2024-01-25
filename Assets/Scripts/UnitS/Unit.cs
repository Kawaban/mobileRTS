using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, PointOfInterest, Damagable
{
    [SerializeField] private UnitData unitData;
    [SerializeField] private NavMeshAgent agent;
    private float health;
    private Vector3 destinationPoint;
    private PriorityObserver enemyObserver;
    private UnitStrategy strategy;
    private UnitStrategyType strategyType;
    private Dictionary<UnitStrategyType, UnitStrategy> strategies;

    public UnitData UnitData { get => unitData;  }
    public NavMeshAgent Agent { get => agent;  }
    public float Health { get => health; set => health = value; }
    public Vector3 DestinationPoint { get => destinationPoint; set => destinationPoint = value; }
    public PriorityObserver EnemyObserver { get => enemyObserver; set => enemyObserver = value; }

    void Start()
    {
        strategies = new Dictionary<UnitStrategyType, UnitStrategy>
        {
            { UnitStrategyType.PASSIVE, new UnitPassive() },
            { UnitStrategyType.MOVE, new UnitMove(this) },
            { UnitStrategyType.ATTACK, new UnitAttack(this) }
        };
        health = unitData.Health;
        NavigationConfiguration();
        setDefaultStrategy();
    }

    private void setDefaultStrategy()
    {
        strategyType = UnitStrategyType.PASSIVE;
        strategy = strategies[strategyType];
    }

    void Update()
    {
        strategy.Execute();
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
        Destroy(gameObject);
    }

}
