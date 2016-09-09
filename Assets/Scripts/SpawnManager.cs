using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject path;
    public GameObject player;
    public GameObject[] trees;
    public GameObject ground;
    public float spawnTimer = 4.0f;
    public float pathSpawnTimer = 1.5f;
    public float treeSpawnTimer = 0.1f;
    public float groundSpawnTimer = 1f;
    private float pathX = 18;

	// Use this for initialization
	void Start () {
	    SpawnPath();
        SpawnTrees();
	}
	
	// Update is called once per frame
	void Update () {
        if (DataManagement.dataManage.gameOn) {
            spawnTimer -= Time.deltaTime;
            pathSpawnTimer -= Time.deltaTime;
            treeSpawnTimer -= Time.deltaTime;
            groundSpawnTimer -= Time.deltaTime;

	        if (spawnTimer < 0.01) {
                SpawnObstacle();
            }
            if (pathSpawnTimer < 0.01) {
                SpawnPath();
            }
            if (treeSpawnTimer < 0.01) {
                SpawnTrees();
            }
            if (groundSpawnTimer < 0.01) {
                SpawnGround();
            }
        }
	}

    void SpawnObstacle () {
        GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3 (player.transform.position.x + 40, -0.15f, 0.05f), Quaternion.identity) as GameObject;
        newObstacle.transform.localScale = new Vector3 (0.1574803f, 0.1574803f, 0.1574803f);
        spawnTimer = Random.Range(2.0f, 4.0f);
    }

    void SpawnPath () {
        pathX += 11.5f;
        GameObject newPath = Instantiate(path, new Vector3 (pathX, 0.75f, 1.5f), Quaternion.identity) as GameObject;
        pathSpawnTimer = 1.5f;
    }

    void SpawnTrees() {
        GameObject newTree = Instantiate(trees[Random.Range(0, trees.Length)], new Vector3 (player.transform.position.x + 40, 0, Random.Range(3, 22)), Quaternion.identity) as GameObject;
        treeSpawnTimer = 0.1f;
    }

    void SpawnGround() {
        GameObject newGround = Instantiate(ground, new Vector3 (player.transform.position.x + 40, Random.Range(3.79f, 4f), 7), Quaternion.identity) as GameObject;
        groundSpawnTimer = 3f;
    } 
}
