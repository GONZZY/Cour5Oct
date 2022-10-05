using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // un objet de type collision contient de linformation propos de la
    // collision qui a eu lieu, à travers les ContactPoints, nous pouvons
    // accéder aux objects de la collision.

    // Cette prochaine ligne se retrouverais dans une autre classe habituellement
    // La classe serait une place pour contenir plusieurs informations globales
    public static int powerUpLayer = 6;
    [SerializeField] private Collider sensitiveSpot;
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contacts = collision.contacts;
        ContactPoint firstContact = contacts[0];
        Collider thisCollider = firstContact.thisCollider;
        Debug.Log($"onCollisionEnter was called! {firstContact.thisCollider.name}");
        
        // Filtrer les collisions par colliders
        if(thisCollider == sensitiveSpot)
        {
            Debug.Log("The sensitive spot was hit");
        }
        // Vérifie si le collider de l'autre gameObject est 6
        // Filtrer les collisions par layers
        // Détruit l'autre objet lorsqu'il s'accroche dessus s'il a layer 6
        GameObject o = firstContact.otherCollider.gameObject;
        if (o.layer == powerUpLayer)
        {
            Debug.Log("You got a power up!");
            Destroy(o);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        collision.collider.gameObject.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f), 0,0);
    }
}
