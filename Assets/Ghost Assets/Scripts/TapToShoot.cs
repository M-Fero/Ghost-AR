//using UnityEngine;

//public class TapToShoot : MonoBehaviour
//{
//    Camera cam;

//    void Start()
//    {
//        cam = Camera.main;
//    }

//    void Update()
//    {
//        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
//            if (Physics.Raycast(ray, out RaycastHit hit))
//            {
//                if (hit.collider.CompareTag("Enemy"))
//                {
//                    Destroy(hit.collider.gameObject); // Enemy is shot
//                }
//            }
//        }
//    }
//}
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class TapToShoot : MonoBehaviour
//{
//    private Camera cam;

//    void Start()
//    {
//        cam = Camera.main;
//    }

//    void Update()
//    {
//        if (TryGetTouchPosition(out Vector2 touchPosition))
//        {
//            HandleTouch(touchPosition);
//        }
//    }

//    private bool TryGetTouchPosition(out Vector2 touchPosition)
//    {
//        touchPosition = default;

//        // Check if a touch began this frame using the new Input System
//        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
//        {
//            touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
//            return true;
//        }

//        return false;
//    }

//    private void HandleTouch(Vector2 touchPosition)
//    {
//        Ray ray = cam.ScreenPointToRay(touchPosition);
//        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.CompareTag("Enemy"))
//        {
//            Destroy(hit.collider.gameObject); // Enemy is shot
//        }
//    }
//}
using UnityEngine;

public class TapToShoot : MonoBehaviour
{
    [SerializeField] private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Make sure ARCamera is tagged as "MainCamera"
    }

    void Update()
    {
        // Touch input detection
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ProcessInput(Input.GetTouch(0).position);
        }

        // Mouse input detection for testing
        if (Input.GetMouseButtonDown(0))
        {
            ProcessInput(Input.mousePosition);
        }
    }

    private void ProcessInput(Vector3 inputPosition)
    {
        Ray ray = arCamera.ScreenPointToRay(inputPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Hit!");
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
