using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    public List<GameObject> Fruits;
    public Rigidbody achievement;
    int stopSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFruits", 1, 2);
        StartCoroutine(StopFruitsSpawn());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void SpawnFruits()
    {
        if (stopSpawn == 0)
        {
            int totalfruits = Random.Range(0, Fruits.Count);
            Vector3 position = new Vector3(Random.Range(-7.6f, 14), transform.position.y, 10);
            foreach (GameObject Fruit in Fruits)
            {
                Instantiate(Fruits[totalfruits], position, Fruit.transform.rotation);
            }
        }
    }
    IEnumerator StopFruitsSpawn()
    {
        yield return new WaitForSeconds(8);
        stopSpawn = 1;
        for(int i = 0; i <3; i++) 
        {
            int yposition = Random.Range(1, 4);
            Vector3 position = new Vector3(Random.Range(0, 14), transform.position.y+yposition, 10);
            Instantiate(achievement, position, achievement.transform.rotation);
            if (achievement.transform.position.z > 136)
            {
                achievement.isKinematic = true;
            }
        }
        
    }
}
