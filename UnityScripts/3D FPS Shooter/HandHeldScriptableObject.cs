using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Handheld",menuName = "HandHeld", order = 1)]

public class HandHeldScriptableObject : ScriptableObject
{
    public GameObject HandHeldPrefab;
    public RuntimeAnimatorController RigAnimationController;
}
