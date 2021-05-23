using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 200f;
    [SerializeField]private Transform firstPart;
    [SerializeField]private List<Transform> LevelPartList;
    [SerializeField]private Jans player; 

    private Vector3 lastEndPosition;
private void Awake() { 
    lastEndPosition = firstPart.Find("EndPosition").position;
    SpawnLevelPart();
    int startingSpawnLevelParts = 1;
    for (int i = 0; i < startingSpawnLevelParts; i++){
        SpawnLevelPart();
    }
}

private void Update() {
    if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART){
        SpawnLevelPart();

    }

}
private void SpawnLevelPart() {
    Transform chosenLevelPart = LevelPartList[Random.Range(0, LevelPartList.Count)];
    Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition); 
    lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
}
private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) {
     Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
     return levelPartTransform;
}
}
