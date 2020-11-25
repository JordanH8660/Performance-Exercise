using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public static BallSpawner SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool; //the prefab of the object in the object pool
    public int amountToPool;
    public static int ballPoolNum;

    private float cooldown;
    private float cooldownLength = 0.5f;

    private void Awake()
    {
        SharedInstance = this;
    }
    private void Start()
    {
        pooledObjects = new List<GameObject>(); //creates the pool of objects
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        InvokeRepeating("SpawnBall", 0, 0.4f);
    }
    
   	public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++) //iterates through the pooled objects list
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        } 
        return null;
    }

    void SpawnBall()
    {
        GameObject selectedBall = BallSpawner.SharedInstance.GetPooledObject();

        if (selectedBall != null)
        {
            selectedBall.SetActive(true);
            Rigidbody selectedRigidBody = selectedBall.GetComponent<Rigidbody>();
            selectedBall.transform.position = transform.position;
        }
        ballPoolNum++;
        if (ballPoolNum >= amountToPool)
        {
            ballPoolNum = 0;
        }
    }
}
