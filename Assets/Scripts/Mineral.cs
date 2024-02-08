using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mineral : NeutralObject
{
    [SerializeField] private MineralData data;
    private float mineralValue;
    private UnityEvent<Mineral> eventDeath;

    void Awake()
    {
        if(eventDeath == null)
            eventDeath = new UnityEvent<Mineral>();
    }


    void Start()
    {
        mineralValue = data.StartMineralValue;    
    }   

    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priority = new PriorityInfo();
        priority.position = gameObject.transform.position;
        priority.type = PointType.CONTROL_POINT;
        return priority;
    }

    public float extractMinerals(float value)
    {
        if(value < mineralValue)
        {
            mineralValue -= value;
            return value * data.MineralQuality;
        }
        else
        {
            Death();
            return mineralValue * data.MineralQuality;
        }
    }

    private void Death()
    {
        eventDeath.Invoke(this);
        Destroy(gameObject);
    }


}
