using UnityEditor;

[CustomEditor(typeof(StrategyCamera))]
public class StrategyCameraEditor : Editor
{
    private bool SectionMouseRotation = true;
    private bool SectionMovement = true;
    private bool SectionZoom = true;
    public override void OnInspectorGUI()
    {
        EditorGUI.indentLevel++;
        SectionMouseRotation = EditorGUILayout.Foldout(SectionMouseRotation, "Mouse orbiting");
        if (SectionMouseRotation)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("HorizontalOrbitingAxis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("VerticalOrbitingAxis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("OrbitingMouseButton"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("InvertHorizontal"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("InvertVertical"));

            EditorGUILayout.PropertyField(serializedObject.FindProperty("HorizontalRotateSpeed"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("VerticalRotateSpeed"));

            EditorGUILayout.PropertyField(serializedObject.FindProperty("MinVerticalAngle"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxVerticalAngle"));
        }

        EditorGUILayout.Space();
        SectionMovement = EditorGUILayout.Foldout(SectionMovement, "Movement");
        if (SectionMovement)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("MovementForwardAxis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("MovementSidewaysAxis"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("FastSpeedKey"));

            var allowDragging = serializedObject.FindProperty("AllowMouseDragging");
            EditorGUILayout.PropertyField(allowDragging);
            if (allowDragging.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("DraggingMouseButton"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("InvertDragging"));
                EditorGUI.indentLevel--;
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("MovementSpeed"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("FastMovementMultiplier"));

            if (allowDragging.boolValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("DraggingSpeed"));
            }

            var constraintPosition = serializedObject.FindProperty("ConstrainPosition");
            EditorGUILayout.PropertyField(constraintPosition);

            if (constraintPosition.boolValue)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("MinPosition"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxPosition"));
                EditorGUI.indentLevel--;
            }
        }

        EditorGUILayout.Space();
        SectionZoom = EditorGUILayout.Foldout(SectionZoom, "Zooming");
        if (SectionZoom)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("InputAxisZoom"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("InvertZooming"));

            EditorGUILayout.PropertyField(serializedObject.FindProperty("ZoomSensitivity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("ZoomInterpolationSpeed"));

            EditorGUILayout.PropertyField(serializedObject.FindProperty("MinZoomDistance"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxZoomDistance"));

            var preventClipping = serializedObject.FindProperty("PreventClipping");
            EditorGUILayout.PropertyField(preventClipping);

            if (preventClipping.boolValue)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ClippingDistance"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ClippingMask"));
            }
        }
        EditorGUI.indentLevel--;

        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();
    }
}
