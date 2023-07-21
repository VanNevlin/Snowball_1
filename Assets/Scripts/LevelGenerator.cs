using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform levelPart_1;
    //public Transform playerTransform;

    private Vector3 lastEndPosition;
    
    private const float playerDistanceToEnd = 200f;
    private void Awake()
    {

        //  lastEndPosition = levelPart_Start.Find("EndPosition").position;
        //   spawnLevel();
        //  spawnLevel();
        //   spawnLevel();
        Transform lastLevelPartTransform;
        lastLevelPartTransform = spawnLevelPart(levelPart_Start.Find("EndPosition").position);
        lastLevelPartTransform = spawnLevelPart(lastLevelPartTransform.Find("EndPosition").position);
        


    }

 /*   private void Update()
    {
        if (Vector3.Distance(playerTransform.position, lastEndPosition) < playerDistanceToEnd)
        {
            spawnLevelPart();
        }
    } */

  /*  private void spawnLevelPart()
    {
        Transform lastLevelPartTransform = spawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

    }*/

    private Transform spawnLevelPart(Vector3 spawnPos)
    {
       Transform levelPartTransform = Instantiate(levelPart_1, new Vector3(87,-4), Quaternion.identity);
       return levelPartTransform;
    }
}
