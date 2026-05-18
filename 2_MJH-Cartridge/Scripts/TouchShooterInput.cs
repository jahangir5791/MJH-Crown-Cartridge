using UnityEngine;

public class TouchShooterInput : MonoBehaviour
{
    public LayerMask shootableMask;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, 100f, shootableMask))
                {
                    ShootAtPoint(hit.point);
                }
            }
        }
    }
    
    void ShootAtPoint(Vector3 point)
    {
        GameObject bullet = Instantiate(Properties.Resources.BulletPrefab, transform.position, Quaternion.LookRotation(point - transform.position));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = (point - transform.position).normalized * 20f;
    }
}
