using UnityEngine;
using UnityEditor;

public class AxisSortOrder : MonoBehaviour {
	
	Renderer myRenderer;

	public enum Axis { X, Y, Z	}

	public Axis axis = Axis.Y;

	public float offset;
	public bool visibleOffset = true;
	public bool reverseDirection = false;

	/// <summary>
	/// Caches the renderer for runtime use.
	/// </summary>
	void Start() {
		myRenderer = GetComponent<Renderer> ();
	}

	/// <summary>
	/// Sort order fixing ideally should happen in this overrided function, since it executes last in the update order
	/// </summary>
	void LateUpdate() {
		FixLayerDepth (myRenderer);
	}

	/// <summary>
	/// Fixes the sorting order based on the selected axis and offset values.
	/// </summary>
	/// <param name="renderer">Renderer.</param>
	void FixLayerDepth(Renderer renderer) {
		float axisPosition = axis == Axis.X ? transform.position.x : axis == Axis.Y ? transform.position.y : axis == Axis.Z ? transform.position.z : 0f;
		float axisScale = axis == Axis.X ? transform.lossyScale.x : axis == Axis.Y ? transform.lossyScale.y : axis == Axis.Z ? transform.lossyScale.z : 1f;

		renderer.sortingOrder = Mathf.RoundToInt ((axisPosition + offset) * axisScale * 100) * (reverseDirection ? 1 : -1);
	}

	/// <summary>
	/// Does sort order fixing in the Editor
	/// </summary>
	void OnDrawGizmos() {
		FixLayerDepth (GetComponent<SpriteRenderer> ());
	}

	/// <summary>
	/// Shows the exact position the offset is at in the Scene view
	/// </summary>
	void OnDrawGizmosSelected() {
		if (visibleOffset) {
			Gizmos.DrawIcon (new Vector3 (transform.position.x + (axis == Axis.X ? offset * transform.lossyScale.x : 0f), transform.position.y + (axis == Axis.Y ? offset * transform.lossyScale.y : 0f), transform.position.z + (axis == Axis.Z ? offset * transform.lossyScale.z : 0f)), "AxisSortOrder_Offset", true);
		}
	}
}