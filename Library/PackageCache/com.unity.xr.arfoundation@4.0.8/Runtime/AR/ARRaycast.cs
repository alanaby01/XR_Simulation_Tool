using System;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation
{
    /// <summary>
    /// Represents a raycast that updates automatically.
    /// </summary>
    /// <remarks>
    /// Generated by the <see cref="ARRaycastManager"/>. Create a raycast with
    /// <see cref="ARRaycastManager.AddRaycast(Vector2, float)"/>.
    /// </remarks>
    [DefaultExecutionOrder(ARUpdateOrder.k_Raycast)]
    [DisallowMultipleComponent]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/api/UnityEngine.XR.ARFoundation.ARRaycast.html")]
    public sealed class ARRaycast : ARTrackable<XRRaycast, ARRaycast>
    {
        bool m_Updated;

        /// <summary>
        /// Get a native pointer associated with this raycast.
        /// </summary>
        /// <remarks>
        /// The data pointed to by this member is implementation defined.
        /// The lifetime of the pointed to object is also
        /// implementation defined, but should be valid at least until the next
        /// <see cref="ARSession"/> update.
        /// </remarks>
        public IntPtr nativePtr => sessionRelativeData.nativePtr;

        /// <summary>
        /// The distance, in meters, between the raycast's origin and intersection point.
        /// </summary>
        public float distance => sessionRelativeData.distance;

        /// <summary>
        /// The <see cref="ARPlane"/> hit by the raycast, or `null` if the raycast does not intersect a plane.
        /// </summary>
        public ARPlane plane { get; internal set; }

        /// <summary>
        /// Invoked whenever this raycast is updated. The event is fired during this `MonoBehaviour`'s
        /// [Update](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html) callback. This event is not
        /// invoked if this component is [disabled](https://docs.unity3d.com/ScriptReference/Behaviour-enabled.html),
        /// although it may continue to receive positional updates.
        /// </summary>
        public event Action<ARRaycastUpdatedEventArgs> updated;

        /// <summary>
        /// Marks this raycast as updated, causing the <see cref="updated"/> event to be invoked during the Update
        /// callback.
        /// </summary>
        protected internal override void OnAfterSetSessionRelativeData() => m_Updated = true;

        void Update()
        {
            if (m_Updated)
            {
                updated?.Invoke(new ARRaycastUpdatedEventArgs
                {
                    raycast = this
                });
                m_Updated = false;
            }
        }
    }
}
