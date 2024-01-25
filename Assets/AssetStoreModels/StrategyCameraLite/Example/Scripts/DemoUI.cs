using UnityEngine;
using UnityEngine.UI;

public class DemoUI : MonoBehaviour
{
    public StrategyCamera StrategyCamera;

    public Toggle ShowSettingsToggle;
    public GameObject SettingsPanelRoot;

    public Toggle InvertMouseOrbitingHorizontal;
    public Toggle InvertMouseOrbitingVertical;
    public Toggle InvertMouseDragging;
    public Toggle InvertZooming;

    public Slider MovementSpeed;
    public Slider FastMovementMultiplier;
    public Slider ZoomingSpeed;

    void Start()
    {
        if (StrategyCamera == null)
        {
            Debug.LogWarning("Demo UI needs to have the strategy camera configured!");
            enabled = false;
        }

        if (SettingsPanelRoot == null)
        {
            Debug.LogWarning("Demo UI needs to have the settings panel root configured!");
            enabled = false;
        }

        InitializeControls();
        RegisterUiCallbacks();
        ToggleShowSettings(false);
    }

    /// <summary>
    /// Make sure that we receive UI change events.
    /// </summary>
    private void RegisterUiCallbacks()
    {
        ShowSettingsToggle.onValueChanged.AddListener(ToggleShowSettings);

        InvertMouseOrbitingHorizontal.onValueChanged.AddListener(OnToggleInvertOrbitingHorizontal);
        InvertMouseOrbitingVertical.onValueChanged.AddListener(OnToggleInvertOrbitingVertical);
        InvertMouseDragging.onValueChanged.AddListener(OnToggleInvertMouseDragging);
        InvertZooming.onValueChanged.AddListener(OnToggleInvertZooming);

        MovementSpeed.onValueChanged.AddListener(OnChangeMovementSpeed);
        FastMovementMultiplier.onValueChanged.AddListener(OnChangeFastMovementMultiplier);
        ZoomingSpeed.onValueChanged.AddListener(OnChangeZoomSpeed);
    }

    /// <summary>
    /// Make sure that the UI controls display the current camera settings.
    /// </summary>
    private void InitializeControls()
    {
        InvertMouseOrbitingHorizontal.isOn = StrategyCamera.InvertHorizontal;
        InvertMouseOrbitingVertical.isOn = StrategyCamera.InvertVertical;
        InvertMouseDragging.isOn = StrategyCamera.InvertDragging;
        InvertZooming.isOn = StrategyCamera.InvertZooming;

        MovementSpeed.value = StrategyCamera.MovementSpeed;
        FastMovementMultiplier.value = StrategyCamera.FastMovementMultiplier;
        ZoomingSpeed.value = StrategyCamera.ZoomSensitivity;
    }

    private void ToggleShowSettings(bool value)
    {
        SettingsPanelRoot.SetActive(value);
    }

    private void OnToggleInvertOrbitingHorizontal(bool value)
    {
        StrategyCamera.InvertHorizontal = value;
    }

    private void OnToggleInvertOrbitingVertical(bool value)
    {
        StrategyCamera.InvertVertical = value;
    }

    private void OnToggleInvertMouseDragging(bool value)
    {
        StrategyCamera.InvertDragging = value;
    }

    private void OnToggleInvertZooming(bool value)
    {
        StrategyCamera.InvertZooming = value;
    }

    private void OnChangeMovementSpeed(float value)
    {
        StrategyCamera.MovementSpeed = value;
    }

    private void OnChangeFastMovementMultiplier(float value)
    {
        StrategyCamera.FastMovementMultiplier = value;
    }

    private void OnChangeZoomSpeed(float value)
    {
        StrategyCamera.ZoomSensitivity = value;
    }
}
