using System.Collections;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble;
    private Rigidbody rig;
    
    void Awake()
    {

        rig = GetComponent<Rigidbody>();
        
    }

   
    void Start()
    {
        rig.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
