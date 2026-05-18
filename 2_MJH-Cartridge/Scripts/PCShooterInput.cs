using UnityEngine;

public class PCShooterInput : MonoBehaviour
{
    public LayerMask shootableMask;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100f, shootableMask))
            {
                ShootAtPoint(hit.point);
            }
        }
    }
    
    void ShootAtPoint(Vector3 point)
    {
        Vector3 direction = (point - transform.position).normalized;
        gameObject.transform.LookAt(point);
        
        AudioManager.Instance?.PlaySFX("Gunshot_Pistol");
    }
}
