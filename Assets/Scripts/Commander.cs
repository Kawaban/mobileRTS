using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    private List<Unit> units;
    private List<Building> buildings;
    [SerializeField] private List<Commander> enemyCommanders;
    [SerializeField] private CommanderData commanderData;
    [SerializeField] private NeutralObjectManager neutralObjectManager;

    public List<Unit> Units { get => units; }
    public List<Building> Buildings { get => buildings; }

    void Start()
    {
        units = new List<Unit>();
        buildings = new List<Building>();

    }

    public void createFactory()
    {
        GameObject factory = Instantiate(commanderData.Factory);
        Factory factoryObj = factory.GetComponent<Factory>();

        factoryObj.UnitEvent.AddListener(addUnit);
        factoryObj.EventDeath.AddListener(BuildingDeath);
        buildings.Add(factoryObj);
    }

    public void addUnit(Unit unit)
    {
        unit.EnemyCommanders = enemyCommanders;
        unit.NeutralObjectManager = neutralObjectManager;

        unit.EventDeath.AddListener(UnitDeath);
        units.Add(unit);
    }

    public List<Unit> getUnits()
    {
        return units;
    }

    public List<Building> getBuildings()
    {
        return buildings;
    }

    public List<PointOfInterest> getPointsOfInterest()
    {
        List<PointOfInterest> points = new List<PointOfInterest>();

        foreach (var unit in units) { points.Add(unit); }
        foreach (var building in buildings) { points.Add(building); }

        return points;
    }

    public void UnitDeath(Unit unit)
    {
        units.Remove(unit);
    }

    public void BuildingDeath(Building building)
    {
        buildings.Remove(building);
    }








}
