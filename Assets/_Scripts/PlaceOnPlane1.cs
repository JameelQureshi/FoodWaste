using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using Siccity.GLTFUtility;
using System.Collections;
using UnityEngine.SceneManagement;

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
    public class PlaceOnPlane1 : MonoBehaviour
    {
        public GameObject PlacedPrefab;
        public GameObject TakeImageButton;
        public GameObject Featheredplane;
      //  public GameObject EnableTrackingButton;
      //  public GameObject DisableTrackingButton;
      //  public GameObject Instructions;
        public ARPlaneManager m_ARPlaneManager;
        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        //   public GameObject placedPrefab
        // {
        // get { return m_PlacedPrefab; }
        //   set { m_PlacedPrefab = value; }
        //  }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        /// 
        private void Start()
        {
           // Instructions.SetActive(true);
        }
        public void EnableTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(true);
           // EnableTrackingButton.SetActive(false);
           // DisableTrackingButton.SetActive(true);
        }
        public void DisbleTracking()
        {
            foreach (var plane in m_ARPlaneManager.trackables)
                plane.gameObject.SetActive(false);
         //   DisableTrackingButton.SetActive(false);
          //  EnableTrackingButton.SetActive(true);
            
        }
        public void Back()
        {
            SceneManager.LoadScene(0);
        }
        public GameObject spawnedObject { get; private set; }

        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            m_ARPlaneManager = GetComponent<ARPlaneManager>();
        }

       
        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
    #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
    #else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
    #endif

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
                
                if(spawnedObject == null)
                {
                    spawnedObject = Instantiate(PlacedPrefab, hitPose.position, hitPose.rotation);
                    Handheld.Vibrate();
                    TakeImageButton.SetActive(true);
                   // Instructions.SetActive(false);
                  //  EnableTrackingButton.SetActive(true);
                  //  DisableTrackingButton.SetActive(true);
                }
            }
        }
       

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}