using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit 
{
    Animator Animator { get; }
}

public interface ISelectable
{
    UnitSelectView SelectObject { get; }
    void Select();
    void UnSelect();
}