using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleCharaterRPGSystem : MonoBehaviour {
	[SerializeField] private GameObject main_character;

	private InputManager m_input_manager;

	void Start () {
		m_input_manager = GetComponent<InputManager> ();
		if (!m_input_manager) {
			Debug.LogError ("'GameSystem' need 'InputManager' commponent. Plaese put 'InputManager' script in 'GameSystem' gameobject");
		}
	}

	void Update () {
		
	}

	void CharacterMove( ) {
		
	}
}
