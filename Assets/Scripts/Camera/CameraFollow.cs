using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // �v���C���[�̈ʒu���Q��
    public Vector3 offset;    // �J�����ƃv���C���[�Ƃ̃I�t�Z�b�g

    void Update()
    {
        // �v���C���[�̈ʒu�ɃJ������Ǐ]������
        transform.position = player.position + offset;
    }
}
