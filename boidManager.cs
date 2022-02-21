using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boidManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public List<boidBehavior> listOfBoids = new List<boidBehavior>(); //list updates

    [Header ("Boid stats")]
    public int numberOfBoids;
    public float maxSpeed, separationDist;

    [Range(0, 1f)] public float weight_alignment;
    [Range(0, 1f)] public float weight_cohesion;
    [Range(0, 1f)] public float weight_separation;
    [Range(0,1f)] public float weight_seeking;
    [Range(0, 1f)] public float weight_avoiding;

    public Transform target;
    public Transform obstacle;

    void Start()
    {
       
        for (int i = 0; i < numberOfBoids; i++)
        {
            CreateBoid();
        }
    }


    void CreateBoid()
    {
        GameObject newBoidObject =  Instantiate(boidPrefab, this.transform.position, Quaternion.identity);
        boidBehavior newBoid = newBoidObject.GetComponent<boidBehavior>();
        newBoid.myManager = this;
        listOfBoids.Add(newBoid);
        newBoid.transform.parent = this.transform;

        newBoid.speed = maxSpeed * Random.Range(0.8f, 1.2f);
    }
}
