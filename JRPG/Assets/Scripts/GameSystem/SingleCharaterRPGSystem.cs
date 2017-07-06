using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleCharaterRPGSystem : MonoBehaviour {
    public enum GAME_STATE {
        TRIP,   /*冒険状態*/
        TALK,   /*会話状態*/
        PHASE,  /*一時停止状態*/
    }

    public enum HERO_MOVE_METHOD {
        MOVE_DIR_SHARE,     /*チャラが移動する方向を向かう*/
        MOVE_DIR_SEPARATE,  /*移動の操作と方向の操作が分かれている*/
    }

    [SerializeField] private GameObject       hero;
    [SerializeField] private HERO_MOVE_METHOD hero_move_method      = HERO_MOVE_METHOD.MOVE_DIR_SHARE;
    [SerializeField] private float            hero_location_speed   = 4f;
    [SerializeField] private float            hero_rotate_speed     = 4f;

    private InputManager m_input_manager;
    private DataStorage  m_data_storage;
    private GAME_STATE   m_game_state = GAME_STATE.TRIP;

    void Start( ) {
        //Dataの保存のために必要
        m_data_storage = FindObjectOfType<DataStorage>( );
        if ( !m_data_storage ) {
            GameObject data_storage = new GameObject( "DataStorage" );
            data_storage.AddComponent<DataStorage>( );
        }

        //操作のためには必要
        m_input_manager = GetComponent<InputManager>( );
        if ( !m_input_manager ) {
            gameObject.AddComponent<InputManager>( );
        }

        //HeroのComponent管理
        if ( !hero.GetComponent<Hero>( ) ) {
            hero.AddComponent<Hero>( );
        }
        if ( !hero.GetComponent<CharacterController>( ) ) {
            hero.AddComponent<CharacterController>( );
        }
    }

    void Update( ) {
        if ( !hero ) {
            Debug.LogError( "'SingleCharaterRPGSystem' need 'Hero' GameObject. Plaese put 'Hero' GameObject in 'SingleCharaterRPGSystem' commponent" );
            return;
        }
        UpdateHeroMove( );
    }

    /*Heroの移動関連スタート*/
    void UpdateHeroMove( ) {
        if ( m_game_state != GAME_STATE.TRIP ) return;

        switch( hero_move_method ) {
            case HERO_MOVE_METHOD.MOVE_DIR_SHARE:
                MoveDirShareUpdate( );
                break;
            case HERO_MOVE_METHOD.MOVE_DIR_SEPARATE:
                MoveDirSeparateUpdate( );
                break;
        }
    }

    void MoveDirShareUpdate( ) {
        CharacterController chara_controller = hero.GetComponent<CharacterController>( );

        Vector3 hero_change_pos = ( m_input_manager.GetMoveInput * hero_location_speed ) + Physics.gravity;
        chara_controller.Move( hero_change_pos * Time.deltaTime );

        if ( m_input_manager.GetMoveInput != Vector3.zero ) {
            Quaternion target_dir = Quaternion.LookRotation( m_input_manager.GetMoveInput );
            float rotate_speed = hero_rotate_speed * Time.deltaTime;
            hero.transform.rotation = Quaternion.Lerp( hero.transform.rotation, target_dir, rotate_speed );
        }
    }

    void MoveDirSeparateUpdate( ) {
        CharacterController chara_controller = hero.GetComponent<CharacterController>( );

        Vector3 hero_change_pos = ( hero.transform.forward * m_input_manager.GetMoveInput.z * hero_location_speed ) + Physics.gravity;
        chara_controller.Move( hero_change_pos * Time.deltaTime );

        float rotate_speed = m_input_manager.GetMoveInput.x * hero_rotate_speed;
        hero.transform.Rotate( Vector3.up, rotate_speed );
    }
    /*Heroの移動関連エンド*/

    /*Heroのアクション関連スタート*/
    void Action( ) {

    }
    /*Heroのアクション関連エンド*/
}
