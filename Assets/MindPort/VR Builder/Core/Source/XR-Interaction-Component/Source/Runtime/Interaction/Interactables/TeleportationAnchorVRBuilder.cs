using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VRBuilder.XRInteraction
{
    /// <summary>
    /// Teleportation anchor override that ensures a teleport provider is found even when the rig
    /// has been spawned after loading the scene.
    /// </summary>
    [AddComponentMenu("VR Builder/Interactables/Teleportation Anchor (VR Builder)")]
    public class TeleportationAnchorVRBuilder : UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationAnchor
    {
        /// <inheritdoc />
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            CheckTeleportationProvider(args.interactorObject);

            base.OnSelectEntered(args);
        }

        /// <inheritdoc />
        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            CheckTeleportationProvider(args.interactorObject);

            base.OnSelectExited(args);
        }

        /// <inheritdoc />
        protected override void OnActivated(ActivateEventArgs args)
        {
            CheckTeleportationProvider(args.interactorObject);

            base.OnActivated(args);
        }

        /// <inheritdoc />
        protected override void OnDeactivated(DeactivateEventArgs args)
        {
            CheckTeleportationProvider(args.interactorObject);

            base.OnDeactivated(args);
        }

        private void CheckTeleportationProvider(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRInteractor interactor)
        {
            if (teleportationProvider != null)
            {
                return;
            }

            UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider provider = interactor.transform.GetComponentInParent<UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider>();

            if (provider != null)
            {
                teleportationProvider = provider;
            }
        }
    }
}