using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AxisSortOrder))]
public class AxisSortOrderEditor : Editor {

	SerializedProperty axis;
	SerializedProperty offset;
	SerializedProperty visibleOffset;
	SerializedProperty reverseDirection;

	/// <summary>
	/// Sets up all needed SerialiozedProperty for multiple object editing
	/// </summary>
	void OnEnable() {
		axis = serializedObject.FindProperty ("axis");
		offset = serializedObject.FindProperty ("offset");
		visibleOffset = serializedObject.FindProperty ("visibleOffset");
		reverseDirection = serializedObject.FindProperty ("reverseDirection");
	}

	/// <summary>
	/// Displays controls and gets inputs on the Inspector window
	/// </summary>
	override public void OnInspectorGUI()
	{
		serializedObject.Update ();

		var script = target as AxisSortOrder;

		EditorGUILayout.PropertyField (axis, new GUIContent ("Axis", "Which axis position will be used for sorting."));

		offset.floatValue = EditorGUILayout.FloatField (new GUIContent ("Offset", "This offsets the selected axis position. Useful since some sprites might need to be sorted before or after their position."), script.offset);

		visibleOffset.boolValue = EditorGUILayout.Toggle (new GUIContent ("Visible offset", "Toggles whether the offset should be shown in the Scene view or not."), script.visibleOffset);
		reverseDirection.boolValue = EditorGUILayout.Toggle (new GUIContent ("Reverse direction", "If selected the direction of the sorting will be reversed. When OFF lower sprites in the axis direction will be shown on top."), script.reverseDirection);

		serializedObject.ApplyModifiedProperties ();
	}
}