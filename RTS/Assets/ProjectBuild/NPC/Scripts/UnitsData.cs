


using System.Collections.Generic;
using UnityEngine;

public class UnitsData : MonoBehaviour
{
    public static UnitsData Instance { get; private set; }

    public List<UnitBase> AllUnits { get; private set; } = new List<UnitBase>();
    public List<UnitBase> SelectedUnit { get; private set; } = new List<UnitBase>();

    


    private void Awake()
    {
        Instance = this;
    }

    public void AddSelected(UnitBase unit)
    {
        SelectedUnit.Add(unit);
    }

    public void RemoveSelected(UnitBase unit)
    {
        SelectedUnit.Remove(unit);
    }

    public void AddUnits(UnitBase unit)
    {
        AllUnits.Add(unit);
    }

    public void RemoveUnits(UnitBase unit)
    {
        AllUnits.Remove(unit);
    }

    public void AddRangeSelectedUnits(List<UnitBase> units)
    {
        SelectedUnit.AddRange(units);
    }

    public void RemoveAllSelectedUnits()
    {

        foreach (UnitBase unit in AllUnits)
        {
            unit.UnSelect();
        }

        SelectedUnit.Clear();
    }

}
