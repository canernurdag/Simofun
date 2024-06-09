using log4net.Util;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Slot;
using Simofun.DevCaseStudy.Unity.Assets.TapDragToSort.Scripts.Runtime.Actors._Sortable.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;
using static UnityEditor.UIElements.ToolbarMenu;

namespace Simofun.DevCaseStudy.Unity
{
	[CustomEditor(typeof(Slot))]
	public class SlotEditor : Editor
	{

		public Sortable Cake;
		public Sortable Donut;
		public Sortable Cookiee;

		private void OnEnable()
		{
			Slot slot = (Slot)target;
			slot.SetSortableParentEditor(slot.transform.GetChild(0));

			var sortable = slot.GetComponentInChildren<Sortable>(true);
			if (sortable != null)
			{
				slot.SetSortable(sortable);
			}
		}


		public override void OnInspectorGUI()
		{

			GUILayout.Space(30);
			GUILayout.Label("LEVEL DESIGN");
			GUILayout.Space(10);
			Slot slot = (Slot)target;

			GUILayout.Label("CAKE");
			Sortable cakeSource = (Sortable)AssetDatabase.LoadAssetAtPath("Assets/TapDragToSort/Prefabs/Actors/Sortables/Variants/Sortable_Cake.prefab", typeof(Sortable));
			Cake = (Sortable)EditorGUILayout.ObjectField(cakeSource, typeof(Sortable), false);
			GUILayout.Space(10);

			GUILayout.Label("DONUT");
			Sortable donutSource = (Sortable)AssetDatabase.LoadAssetAtPath("Assets/TapDragToSort/Prefabs/Actors/Sortables/Variants/Sortable_Donut.prefab", typeof(Sortable));
			Donut = (Sortable)EditorGUILayout.ObjectField(donutSource, typeof(Sortable), false);
			GUILayout.Space(10);

			GUILayout.Label("COOKIEE");
			Sortable cookieeSource = (Sortable)AssetDatabase.LoadAssetAtPath("Assets/TapDragToSort/Prefabs/Actors/Sortables/Variants/Sortable_Cookie.prefab", typeof(Sortable));
			Cookiee = (Sortable)EditorGUILayout.ObjectField(cookieeSource, typeof(Sortable), false);

			if (GUILayout.Button("Place Cake"))
			{
				var currentSortable = slot.GetComponentInChildren<Sortable>(true);
				if(currentSortable != null) return; 

				var sortable = Instantiate(Cake);
				slot.SetSortableEditor(sortable);
			}

			if (GUILayout.Button("Place Donut"))
			{
				var currentSortable = slot.GetComponentInChildren<Sortable>(true);
				if (currentSortable != null) return;

				var sortable = Instantiate(Donut);
				slot.SetSortableEditor(sortable);
			}

			if (GUILayout.Button("Place Cookie"))
			{
				var currentSortable = slot.GetComponentInChildren<Sortable>(true);
				if (currentSortable != null) return;

				var sortable = Instantiate(Cookiee);
				slot.SetSortableEditor(sortable);
			}

			if (GUILayout.Button("Remove Sortable"))
			{
				slot.DestroyEditor();

			}



			if(GUI.changed)
			{
				EditorUtility.SetDirty(slot);
				serializedObject.ApplyModifiedProperties();
			}

		}


	}
}

