using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Unit
{
    [SerializeField] private FighterData fighterData;
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private GunRotationController gunRotationController = null;

    public FighterData FighterData { get => fighterData; }
    public ParticleSystem AttackEffect { get => attackEffect; }
    public GunRotationController GunRotationController { get => gunRotationController; }
    public override PriorityInfo getPriorityInofrmation()
    {
        PriorityInfo priorityInfo = new PriorityInfo();
        priorityInfo.position = gameObject.transform.position;
        priorityInfo.type = fighterData.TypeOf;
        return priorityInfo;
    }

    public override List<PointOfInterest> GetPointOfInterests()
    {
        List<PointOfInterest> points = new List<PointOfInterest>();

        foreach (Commander commander in base.EnemyCommanders)
            points.AddRange(commander.getPointsOfInterest());

        foreach (NeutralObject neutralObject in base.NeutralObjectManager.objects)
            if (!(neutralObject is Mineral))
                points.Add(neutralObject);

        return points;
    }

    public void AttackCooldown(UnitAttack unitAttack)
    {
        StartCoroutine(unitAttack.AttackCooldown(fighterData.ReloadTime));
    }

    public override void onStart()
    {
        base.onStart();
        strategyOverseer = new FighterStrategyOverseer(this);
        strategyOverseer.setDefaultStrategy();
    }


}
