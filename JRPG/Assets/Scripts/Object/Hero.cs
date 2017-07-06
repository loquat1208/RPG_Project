using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    private GameObject m_meet_object;

    public GameObject MeetObject { get { return m_meet_object; } }

    void OnTriggerEnter( Collider meet_object ) {
        m_meet_object = meet_object.gameObject;
    }

    void OnTriggerExit( Collider meet_object ) {
        m_meet_object = null;
    }
}
