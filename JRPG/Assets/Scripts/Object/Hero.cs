using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
	[SerializeField] private Sprite 	picture;
	[SerializeField] private GameObject answerWindow;

	private GameObject m_meet_object;
	private bool 		m_answer_yes = false;

	public GameObject MeetObject 	{ get { return m_meet_object;	} }
	public Sprite 	  Picture 	 	{ get { return picture; 		} }
	public bool 	  IsAnswerYes 	{ get { return m_answer_yes; 	} }

	void Start( ) {
		if (!answerWindow) {
			answerWindow = Resources.Load ("Prefabs/AnswerWindow") as GameObject;
		}
	}

    void OnTriggerEnter( Collider meet_object ) {
        m_meet_object = meet_object.gameObject;
    }

    void OnTriggerExit( Collider meet_object ) {
        m_meet_object = null;
    }

	void AnswerYes( ) {
		m_answer_yes = true;
	}

	void AnswerNo( ) {
		m_answer_yes = false;
	}
}
