using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    [SerializeField] private float raider_radius = 3f;

	void Start( ) {
        init( );
    }

    void init( ) {
        //他のObjectとinterationのために'Raider'を作る
        GameObject raider = new GameObject( "Raider" );
        raider.transform.SetParent( gameObject.transform );
        raider.transform.position = transform.position;
        raider.transform.tag = "NPC";
        raider.AddComponent<SphereCollider>( );
        raider.GetComponent<SphereCollider>( ).isTrigger = true;
        raider.GetComponent<SphereCollider>( ).radius = raider_radius;
    }
}
