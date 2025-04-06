using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // プレイヤーの位置を参照
    public Vector3 offset;    // カメラとプレイヤーとのオフセット

    void Update()
    {
        // プレイヤーの位置にカメラを追従させる
        transform.position = player.position + offset;
    }
}
