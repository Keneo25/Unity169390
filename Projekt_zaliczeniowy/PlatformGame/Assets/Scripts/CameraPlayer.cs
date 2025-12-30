using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [Header("Ustawienia Śledzenia")]
    [SerializeField] private Transform target;
    
    private void LateUpdate()
    {
        float lastZ = transform.position.z;
        transform.position = new Vector3(target.position.x, target.position.y, lastZ);
    }
}
