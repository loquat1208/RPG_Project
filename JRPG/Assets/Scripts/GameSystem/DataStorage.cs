using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData {
    public float time;
}

public class DataStorage : MonoBehaviour {
    private static DataStorage instance;

    public GameData GAME_DATA;
    public static DataStorage Instance {
        get {
            if ( instance == null ) {
                instance = new DataStorage( );
            }
            return instance;
        }
    }

    private void Awake( ) {
        if ( instance == null ) {
            DontDestroyOnLoad( gameObject );
            instance = this;
        } else {
            Destroy( gameObject );
        }
    }
}
