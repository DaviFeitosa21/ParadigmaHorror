using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;
    public Transform characterHand;

    float sensitivityX = 1.0f, sensitivityY = 1.0f;

    float rotationX = 0, rotationY = 0;

    float angleYmin = -45, angleYmax = 45;

    float smoothRotx = 0, smoothRoty = 0;

    float smoothCoefx = 0.05f, smoothCoefy = 0.05f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
        characterHead.rotation = transform.rotation;
        characterHand.rotation = transform.rotation;
    }

    void Update()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx;
        rotationY += smoothRoty;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        //characterHead.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
