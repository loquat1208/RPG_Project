using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    /*
	 WASD_MOUSE : Change position with WASD, direction with Mouse;
	 */
    public enum INPUT_METHOD {
        KEY_MOUSE,
    }

    [SerializeField] private INPUT_METHOD input_method = INPUT_METHOD.KEY_MOUSE;

    private Vector3 m_pos;
    private bool    m_fire_1;

    public Vector3 GetMoveInput  { get { return m_pos;    } }
    public bool    GetFire1Input { get { return m_fire_1; } }

    void Update( ) {
        switch ( input_method ) {
            case INPUT_METHOD.KEY_MOUSE:
                UpdateKeyMouse( );
                break;
        }
    }

    void UpdateKeyMouse( ) {
        m_pos.x = Input.GetAxis( "Horizontal" );
        m_pos.z = Input.GetAxis( "Vertical" );

        if ( Input.GetButtonDown( "Fire1" ) ) {
            m_fire_1 = true;
        } else {
            m_fire_1 = false;
        }
    }
}
