using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour
{
    public Vector2 forsePart;
    public int spin;
    //public GameObject Knife;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(forsePart);
        rigidbody.AddTorque(spin);
    }
}
