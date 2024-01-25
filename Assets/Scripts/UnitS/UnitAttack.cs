using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : UnitStrategy
{
    private Unit unit;
    public UnitAttack(Unit unit) 
    {   
        this.unit = unit;
    }

    public void Execute()
    {
        
    }

    /*private void Shoot(Damagable obj)
    {
        if (obj.damageTaken(unitData.Damage))
            enemyObserver.PointsOfInterest.Remove((PointOfInterest)obj);
    }*/

}
