using UnityEditor;

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VRBuilder.XRInteraction;

namespace VRBuilder.Editor.XRInteraction
{
    [CustomEditor(typeof(TeleportationAreaVRBuilder)), CanEditMultipleObjects]
    public class TeleportationAreaVRBuilderEditor : UnityEditor.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationAreaEditor
    {
        private const string teleportLayerName = "XR Teleport";
        private const string reticlePrefab = "TeleportReticle";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Configure VR Builder Defaults"))
            {
                foreach (UnityEngine.Object targetObject in serializedObject.targetObjects)
                {
                    if (targetObject is TeleportationAreaVRBuilder teleportationArea)
                    {
                        ConfigureVRBuilderDefaults(teleportationArea);
                    }
                }
            }
        }

        protected virtual void ConfigureVRBuilderDefaults(TeleportationAreaVRBuilder teleportationArea)
        {
            teleportationArea.teleportTrigger = UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.BaseTeleportationInteractable.TeleportTrigger.OnDeactivated;

            InteractionLayerMask teleportLayer = InteractionLayerMask.NameToLayer(teleportLayerName);
            LayerMask teleportRaycastLayer = LayerMask.NameToLayer(teleportLayerName);

            teleportationArea.gameObject.layer = teleportRaycastLayer;
            teleportationArea.interactionLayers = 1 << teleportLayer;

            teleportationArea.customReticle = Resources.Load<GameObject>(reticlePrefab);

            EditorUtility.SetDirty(teleportationArea);
        }
    }
}