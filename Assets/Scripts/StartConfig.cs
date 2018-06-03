using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SartConfig", menuName = "Create StartConfig")]
public class StartConfig : ScriptableObject {

    public Vector3 startPositionPlayer;
    public float score;
    public float speedMoving;
    public float speedRotation;
    public float time;
    public float timeToDestroy;
}
