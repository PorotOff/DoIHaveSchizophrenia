using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBootstrap : MonoBehaviour
{
    #region Security cameras settings
        [Header("Security cameras settings")]
        [SerializeField] private List<GameObject> securityCameraObjects;
        private List<SecurityCamera> securityCameras = new List<SecurityCamera>();
        private List<BackAndForthAnimation> securityCameraAnimations = new List<BackAndForthAnimation>();
        [SerializeField] private SecurityCameraConfig securityCameraConfig;
    
        [SerializeField] private SecurityCameraSwitching securityCameraSwitching;
        [SerializeField] private SwitchHandler switchHandler;
        [SerializeField] private int currentCameraIndex = 0;
    #endregion

    #region Filling containers with buttons settings
        [Header("Filling containers with buttons settings")]
        [SerializeField] private AnomalyRoomsContainer anomalyRoomsContainer;
    
        [SerializeField] private Button buttonPrefab;
    
        [SerializeField] private FillingContainerWithAnomalyLocationButtons anomalyLocationButtonsFiller;
        [SerializeField] private FillingContainerWithAnomalyTypesButtons anomalyTypesButtonsFiller;
        [SerializeField] private FillingContainerWithAnomalyObjectButtons anomalyObjectButtonsButtonsFiller;
    #endregion

    private void Awake()
    {
        // security cameras
        securityCameraSwitching.Initialise(securityCameras, currentCameraIndex);
        switchHandler.Initialise(securityCameraSwitching);

        SetSecurityCameras();
        SetSecurityCameraAnimations();
        StartSecurityCameraAnimations();

        // Filling containers with buttons
        anomalyRoomsContainer.Initialise();

        anomalyLocationButtonsFiller.Initialise(buttonPrefab);
        anomalyTypesButtonsFiller.Initialise(buttonPrefab);
        anomalyObjectButtonsButtonsFiller.Initialise(buttonPrefab);

        anomalyLocationButtonsFiller.Initialise(anomalyRoomsContainer, anomalyTypesButtonsFiller, anomalyObjectButtonsButtonsFiller);
    }

    #region Security cameras methods
        private void SetSecurityCameras()
        {
            foreach (GameObject SecurityCameraObject in securityCameraObjects)
            {
                securityCameras.Add(SecurityCameraObject.GetComponent<SecurityCamera>());
            }
        }
    
        private void SetSecurityCameraAnimations()
        {
            foreach (GameObject SecurityCameraObject in securityCameraObjects)
            {
                securityCameraAnimations.Add(SecurityCameraObject.GetComponent<BackAndForthAnimation>());
            }
        }
    
        private void StartSecurityCameraAnimations()
        {
            foreach (BackAndForthAnimation securityCameraAnimation in securityCameraAnimations)
            {
                securityCameraAnimation.Initialise(securityCameraConfig);
            }
        }
    #endregion


}