using UnityEngine;

public class StrategyCamera : MonoBehaviour
{
    [Header("Orbiting Input settings")]
    public string HorizontalOrbitingAxis = "Mouse X";
    public string VerticalOrbitingAxis = "Mouse Y";
    public MouseButton OrbitingMouseButton = MouseButton.MiddleMouseButton;
    public bool InvertVertical;
    public bool InvertHorizontal;

    [Header("Orbiting speeds")]
    public float HorizontalRotateSpeed;
    public float VerticalRotateSpeed = 1f;

    [Header("Orbiting limits")]
    [Range(0, 90)]
    public float MinVerticalAngle = 10;
    [Range(0, 90)]
    public float MaxVerticalAngle = 80;


    [Header("Movement Input settings")]
    public string MovementForwardAxis = "Vertical";
    public string MovementSidewaysAxis = "Horizontal";
    public KeyCode FastSpeedKey = KeyCode.LeftShift;
    public bool AllowMouseDragging = true;
    public MouseButton DraggingMouseButton = MouseButton.RightMouseButton;
    public bool InvertDragging = false;

    [Header("Movement speeds")]
    public float MovementSpeed = 2f;
    public float FastMovementMultiplier = 3f;
    public float DraggingSpeed = 1f;

    [Header("Movement limits")]
    public bool ConstrainPosition;
    public Vector3 MinPosition;
    public Vector3 MaxPosition;



    [Header("Zooming Input settings")]
    public string InputAxisZoom = "Mouse ScrollWheel";
    public bool InvertZooming = false;

    [Header("Zooming speeds")]
    public float ZoomSensitivity = 1f;
    public float ZoomInterpolationSpeed = 1f;

    [Header("Zooming limits")]
    public float MinZoomDistance = 1;
    public float MaxZoomDistance = 10;

    public bool PreventClipping;
    public float ClippingDistance;
    public LayerMask ClippingMask;

    [Header("Focus")]
    public Transform Target;

    private Vector3 movementForward;
    private Vector3 movementRight;

    private Camera cam;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float targetZoom;
    private float currentZoom;

    // Start is called before the first frame update
    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void OnEnable()
    {
        targetPosition = transform.position;
        targetRotation = transform.rotation;
        targetZoom = cam.transform.position.z;
    }

    private void OnDrawGizmosSelected()
    {
        if (ConstrainPosition)
        {
            var size = MaxPosition - MinPosition;
            var center = MinPosition + size / 2;
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(center, size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();


        if (Target != null)
        {
            targetPosition = Target.position;
        }
        else
        {
            Movement();
        }

        ZoomInput();
        var minZoom = RestrictClipping();
        Zoom(minZoom);

        transform.SetPositionAndRotation(targetPosition, targetRotation);
    }

    private void Movement()
    {
        var forwards = 0f;
        var sideways = 0f;

        if (Input.GetMouseButton((int)DraggingMouseButton))
        {
            var multiplier = InvertDragging ? DraggingSpeed : -DraggingSpeed;
            forwards -= multiplier * Input.GetAxis(VerticalOrbitingAxis);
            sideways += multiplier * Input.GetAxis(HorizontalOrbitingAxis);
        }
        else
        {
            forwards = Input.GetAxisRaw(MovementForwardAxis);
            sideways = -Input.GetAxisRaw(MovementSidewaysAxis);
        }

        movementForward = transform.forward;
        movementForward.y = 0;
        movementForward.Normalize();
        movementRight = Vector3.Cross(movementForward, Vector3.up);

        Vector3 worldMovement = Time.unscaledDeltaTime * (movementForward * forwards + sideways * movementRight);

        worldMovement *= Input.GetKey(FastSpeedKey) ? MovementSpeed * FastMovementMultiplier : MovementSpeed;

        targetPosition = targetPosition + worldMovement;
        if (ConstrainPosition)
        {
            targetPosition = Vector3.Min(Vector3.Max(targetPosition, MinPosition), MaxPosition);
        }
    }

    void MouseMovement()
    {
        if (!Input.GetMouseButton((int)OrbitingMouseButton))
        {
            return;
        }

        var mouseMovementX = Input.GetAxis(HorizontalOrbitingAxis);
        var mouseMovementY = -Input.GetAxis(VerticalOrbitingAxis);

        if (InvertVertical)
        {
            mouseMovementY *= -1;
        }

        if (InvertHorizontal)
        {
            mouseMovementX *= -1;
        }

        var euler = targetRotation.eulerAngles;

        euler.y += HorizontalRotateSpeed * mouseMovementX;

        euler.x = Mathf.Clamp(euler.x + VerticalRotateSpeed * mouseMovementY, MinVerticalAngle, MaxVerticalAngle);

        targetRotation = Quaternion.Euler(euler);
    }

    private float RestrictClipping()
    {
        if (!PreventClipping)
        {
            return MinZoomDistance;
        }

        var fwd = targetRotation * Vector3.forward;
        var origin = targetPosition + -fwd * MaxZoomDistance;
        var direction = fwd;
        var maxDistance = MaxZoomDistance - MinZoomDistance;
        Debug.DrawRay(origin, direction * maxDistance, Color.cyan);
        if (Physics.Raycast(origin, direction, out var hit, maxDistance, ClippingMask.value))
        {
            var minDistance = (MaxZoomDistance - hit.distance) + ClippingDistance;
            Debug.DrawRay(targetPosition, -direction * minDistance, Color.red);
            return minDistance;
        }

        return MinZoomDistance;
    }

    /// <summary>
    /// Perform the zoom operation
    /// </summary>
    private void Zoom(float minZoom)
    {
        var localPos = cam.transform.localPosition;
        var frameZoom = targetZoom;

        if (ZoomInterpolationSpeed > 0)
        {
            frameZoom = Mathf.Lerp(localPos.z, targetZoom, Time.unscaledDeltaTime * ZoomInterpolationSpeed);
        }

        currentZoom = Mathf.Clamp(frameZoom, -MaxZoomDistance, -minZoom);

        localPos.z = currentZoom;

        cam.transform.localPosition = localPos;
    }

    /// <summary>
    /// Listen for input to determine target zoom.
    /// </summary>
    private void ZoomInput()
    {
        //Use default scrollwheel input axis if none is configured.
        var inputAxis = !string.IsNullOrWhiteSpace(InputAxisZoom) ? InputAxisZoom : "Mouse ScrollWheel";

        var input = Input.GetAxis(inputAxis) * ZoomSensitivity;

        if (InvertZooming)
        {
            input *= -1;
        }

        targetZoom = Mathf.Clamp(targetZoom + input, -MaxZoomDistance, -MinZoomDistance);
    }

    public enum MouseButton
    {
        LeftMouseButton = 0,
        RightMouseButton = 1,
        MiddleMouseButton = 2
    }
}
