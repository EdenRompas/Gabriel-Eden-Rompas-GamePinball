using UnityEngine;

public class TriggerZoomoutController : MonoBehaviour
{
    public CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            cameraController.GoBackToDefault();
        }
    }
}