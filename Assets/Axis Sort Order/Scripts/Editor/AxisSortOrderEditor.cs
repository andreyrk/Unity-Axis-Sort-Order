using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AxisSortOrder))]
public class AxisSortOrderEditor : Editor {

	SerializedProperty useAxisX;
	SerializedProperty useAxisY;
	SerializedProperty useAxisZ;
	SerializedProperty offset;
	SerializedProperty visibleOffset;
	SerializedProperty reverseDirection;

	/// <summary>
	/// Sets up all needed SerialiozedProperty for multiple object editing
	/// </summary>
	void OnEnable() {
		useAxisX = serializedObject.FindProperty ("useAxisX");
		useAxisY = serializedObject.FindProperty ("useAxisY");
		useAxisZ = serializedObject.FindProperty ("useAxisZ");
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

		EditorGUILayout.LabelField ("Which axis should be used?");

		// Shows/hides the axis' toggles
		if (!script.useAxisY && !script.useAxisZ) {
			useAxisX.boolValue = EditorGUILayout.Toggle (new GUIContent ("Axis X", "Uses the X axis position for sorting."), script.useAxisX);
		}

		if (!script.useAxisX && !script.useAxisZ) {
			useAxisY.boolValue = EditorGUILayout.Toggle (new GUIContent ("Axis Y", "Uses the Y axis position for sorting. This is what most 2D games would use."), script.useAxisY);
		}

		if (!script.useAxisX && !script.useAxisY) {
			useAxisZ.boolValue = EditorGUILayout.Toggle (new GUIContent ("Axis Z", "Uses the Z axis position for sorting."), script.useAxisZ);
		}

		EditorGUILayout.Separator ();
		EditorGUILayout.LabelField ("What should the offset be?");

		offset.floatValue = EditorGUILayout.FloatField (new GUIContent ("Offset", "This offsets the selected axis position. Useful since some sprites might need to be sorted before or after their position."), script.offset);

		EditorGUILayout.Separator ();
		EditorGUILayout.LabelField ("Other settings");

		visibleOffset.boolValue = EditorGUILayout.Toggle (new GUIContent ("Visible offset", "Toggles whether the offset should be shown in the Scene view or not."), script.visibleOffset);
		reverseDirection.boolValue = EditorGUILayout.Toggle (new GUIContent ("Reverse direction", "If selected the direction of the sorting will be reversed. When OFF lower sprites in the axis direction will be shown on top."), script.reverseDirection);

		serializedObject.ApplyModifiedProperties ();
	}
}