using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 5f; 
    public Vector2 minBounds;     
    public Vector2 maxBounds;   

    private Vector3 offset;       

    void Start()
    {
        // �ʱ� �Ÿ� ����
        offset = transform.position - target.position;

        ////�÷��̾� ã�ƿ��� �ҷ��� �ߴµ� �ȵǳ�? ����
        //target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = transform.position.z;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }
}
