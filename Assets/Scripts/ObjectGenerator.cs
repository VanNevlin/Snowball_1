using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array to hold the object prefabs
    public float[] spawnYPositions; // Array of Y positions for object spawn
    public float minSpawnInterval; // Minimum time interval between spawns
    public float maxSpawnInterval; // Maximum time interval between spawns
    public float minMoveSpeed; // Minimum move speed for the spawned objects
    public float maxMoveSpeed; // Maximum move speed for the spawned objects

    private float nextSpawnTime; // Time to spawn the next object

    private void Start()
    {
        // Initialize the next spawn time
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        // Check if it's time to spawn a new object
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            // Calculate the next spawn time
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    private void SpawnObject()
    {
        // Randomly select an object prefab
        int randomObjectIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectPrefab = objectPrefabs[randomObjectIndex];

        // Randomly select a Y position from the array
        float spawnYPosition = spawnYPositions[Random.Range(0, spawnYPositions.Length)];

        // Calculate the spawn position using the generator's position and the selected Y position
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnYPosition, 0f);

        // Instantiate the object
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        if (newObject.CompareTag("Trap") && spawnYPosition > 0)
        {
            newObject.transform.Rotate(new Vector3(0, 0, 180));
        }

        // Set up the object's movement
        ObjectController objectController = newObject.GetComponent<ObjectController>();
        objectController.moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed); // Customize the object movement speed within the given range
        objectController.destroyDelay = Random.Range(4f, 8f); // Customize the object destruction delay as needed

        // Make sure the object moves towards the left (use -1 for left, 1 for right, if needed)
        Rigidbody2D objectRigidbody = newObject.GetComponent<Rigidbody2D>();
        objectRigidbody.velocity = Vector2.left * objectController.moveSpeed;
    }
}
