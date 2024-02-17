using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{
    private List<Unit> units;
    private List<Building> buildings;
    [SerializeField] private List<Commander> enemyCommanders;
    [SerializeField] private CommanderData commanderData;
    [SerializeField] private NeutralObjectManager neutralObjectManager;


    private float minerals = 100;

    public List<Unit> Units { get => units; }
    public List<Building> Buildings { get => buildings; }
    public float Minerals { get => minerals;  }
    public CommanderData CommanderData { get => commanderData; }

    void Start()
    {
        units = new List<Unit>();
        buildings = new List<Building>();
      /*  createMiningComplex();
        createFactory();*/
    }


    /*private void createFactory(Vector3 position)
    {
        debugPointfactory.position = position;
        GameObject factory = Instantiate(commanderData.Factory, debugPointfactory);
        Factory factoryObj = factory.GetComponent<Factory>();

        factoryObj.Commander = this;
        factoryObj.UnitEvent.AddListener(addUnit);
        factoryObj.EventDeath.AddListener(BuildingDeath);
        buildings.Add(factoryObj);
    }*/

    public void createBuilding(BuildingType buildingType, Vector3 position)
    {

        GameObject createdBulding;
            switch (buildingType)
            {
            case BuildingType.FACTORY:
                if(!mineralLoss(commanderData.Factory.GetComponent<Factory>().BuildingData.ConstructionCost))
                    return;
                createdBulding = Instantiate(commanderData.Factory, position, Quaternion.identity);
                Factory factory = createdBulding.GetComponent<Factory>();
                factory.Commander = this;
                factory.UnitEvent.AddListener(addUnit);
                factory.EventDeath.AddListener(BuildingDeath);
                buildings.Add(factory);


                break;
            case BuildingType.MINING_COMPLEX:
                if (!mineralLoss(commanderData.MiningComplex.GetComponent<Factory>().BuildingData.ConstructionCost))
                    return;
                createdBulding = Instantiate(commanderData.MiningComplex, position, Quaternion.identity);
                factory= createdBulding.GetComponent<Factory>();
                factory.Commander = this;
                factory.UnitEvent.AddListener(addUnit);
                factory.EventDeath.AddListener(BuildingDeath);
                buildings.Add(factory);
                break;

            default:
                break;
                
            }

            
            
           
    }

  /*  private void createMiningComplex(Vector3 position)
    {
        debugPointmining.position = position;
        GameObject factory = Instantiate(commanderData.MiningComplex, debugPointmining);
        Factory factoryObj = factory.GetComponent<MiningComplex>();

        factoryObj.Commander = this;
        factoryObj.UnitEvent.AddListener(addUnit);
        factoryObj.EventDeath.AddListener(BuildingDeath);
        buildings.Add(factoryObj);
    }*/

    public void addUnit(Unit unit)
    {
        unit.EnemyCommanders = enemyCommanders;
        unit.NeutralObjectManager = neutralObjectManager;
        unit.OurCommander = this;

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

    public void mineralIncome(float value)
    {
        minerals += value;
    }

    public bool mineralLoss(float value)
    {
        if (value > minerals)
            return false;
        
        minerals -= value;
        return true;
    }








}
