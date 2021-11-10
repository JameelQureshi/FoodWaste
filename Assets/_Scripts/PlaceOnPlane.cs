using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        public GameObject spawnedObject;
        public GameObject DisableTrackingButton;
        public GameObject EnableTrackingButton;
        public ARPlaneManager m_ARPlaneManager;
        public GameObject TakeImageButton;
        public GameObject instructions;
        private int NewIndex;
        public Text debugLog;
        public GameObject[] Models;
        private int placeableindex;
        public void EnableTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(true);
            EnableTrackingButton.SetActive(false);
            DisableTrackingButton.SetActive(true);
        }
        public void DisbleTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(false);
            DisableTrackingButton.SetActive(false);
            EnableTrackingButton.SetActive(true);

        }
        public void SelectModel(int index)
        {
            NewIndex = index;
            debugLog.text = "Tap to place new Model!";
            TakeImageButton.SetActive(false);
            
        }
        public void SelectModelAnimation(int index)
        {
           placeableindex= NewIndex + index;
            debugLog.text = "Tap to place new Model!";
            TakeImageButton.SetActive(false);
            print(placeableindex);
        }
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
      

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_ARPlaneManager = GetComponent<ARPlaneManager>();
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(Models[NewIndex], hitPose.position, hitPose.rotation);
                    TakeImageButton.SetActive(true);
                    instructions.SetActive(false);
                }
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}
