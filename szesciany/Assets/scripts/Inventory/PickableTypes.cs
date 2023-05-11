using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pickable", menuName = "Pickable")]
public class PickableTypes : ScriptableObject
{
    public int type; // 0 - collect; 1 - door; 2 - meta
    public int toCollect; // how much is needed to collect
}
