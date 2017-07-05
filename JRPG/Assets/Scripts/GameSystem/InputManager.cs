using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	/*
	 WASD_MOUSE : Change position with WASD, direction with Mouse;
	 */
	public enum INPUT_METHOD
	{
		WASD_MOUSE,
	}

	[SerializeField] private INPUT_METHOD input_method;

	private Vector3 m_pos;
	private Vector3 m_dir;

	public Vector3 GetPosInput { get { return m_pos; } }
	public Vector3 GetDirInput { get { return m_dir; } }

	void Update () {
		switch (input_method) {
		case INPUT_METHOD.WASD_MOUSE:
			UpdateWASDMouse ();
			break;
		}
	}

	void UpdateWASDMouse( ) {
		m_pos.x = Input.GetAxis ("Horizontal");
		m_pos.z = Input.GetAxis ("Vertical");
	}
}
