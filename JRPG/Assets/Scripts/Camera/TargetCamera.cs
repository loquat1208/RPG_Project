using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour {
    private enum CAMERA_METHOD {
        FIXED,
        ROTATE,
    }

    [SerializeField] private GameObject target;
    [SerializeField] private CAMERA_METHOD method       = CAMERA_METHOD.FIXED;
    [SerializeField] private float height_from_ground   = 2f;
    [SerializeField] private float XZ_diff_from_target  = 5f;
    [SerializeField] private float rotate_camera_angle  = 45f;
    [SerializeField] private float loaction_speed       = 4f;
    [SerializeField] private float rotate_speed         = 4f;

    void Update( ) {
        if ( !target ) {
            Debug.LogError( "This camera dont have target." );
            return;
        }
        switch ( method ) {
            case CAMERA_METHOD.FIXED:
                UpdateFixedCameraMove( );
                break;
            case CAMERA_METHOD.ROTATE:
                UpdateRotateCameraMove( );
                break;
            default:
                UpdateFixedCameraMove( );
                break;
        }
    }

    void UpdateFixedCameraMove( ) {
        Vector3 tmp_pos = target.transform.position + ( -transform.forward * XZ_diff_from_target );
        tmp_pos.y = target.transform.position.y + height_from_ground;
        transform.position = Vector3.Lerp( transform.position, tmp_pos, loaction_speed * Time.deltaTime );
    }

    void UpdateRotateCameraMove( ) {
        Vector3 tmp_pos = target.transform.position + ( -transform.forward * XZ_diff_from_target );
        tmp_pos.y = target.transform.position.y + height_from_ground;
        transform.position = Vector3.Lerp( transform.position, tmp_pos, loaction_speed * Time.deltaTime );

        Vector3 target_dir_vec = target.transform.localEulerAngles + new Vector3( rotate_camera_angle, 0, 0 );
        Quaternion vec_to_quaternion = Quaternion.Euler( target_dir_vec );
        transform.rotation = Quaternion.Lerp( transform.rotation, vec_to_quaternion, rotate_speed * Time.deltaTime );
    }
}
