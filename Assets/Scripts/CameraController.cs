using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f; // 相机与人物的默认距离
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = Vector3.zero; // 相机相对于人物的偏移量
    private Vector3 targetPosition;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = target.position - transform.position; // 计算初始偏移量
    }
    private void Update()
    {
        if (offset != Vector3.zero) // 如果偏移量不为零，即人物在移动
        {
            targetPosition = target.position - offset; // 计算目标位置，使相机始终在人物的左下方
            targetPosition = new Vector3(Mathf.Max(0,targetPosition.x), targetPosition.y, targetPosition.z);
            targetPosition = new Vector3(Mathf.Min(140,targetPosition.x), targetPosition.y, targetPosition.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            
        }
    }
}