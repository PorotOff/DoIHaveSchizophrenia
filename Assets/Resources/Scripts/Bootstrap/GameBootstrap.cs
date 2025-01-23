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

    #region Data containers
    [Header("Data containers")]
    private AnomalyReportData anomalyReportData;
    [SerializeField] private AnomalyRoomsContainer anomalyRoomsContainer;
    #endregion

    #region Filling containers with buttons settings
    [Header("Filling containers with buttons settings")]
    [SerializeField] private Button buttonPrefab;

    [SerializeField] private FillingContainerWithAnomalyLocationButtons anomalyLocationButtonsFiller;
    [SerializeField] private FillingContainerWithAnomalyTypesButtons anomalyTypesButtonsFiller;
    [SerializeField] private FillingContainerWithAnomalyObjectButtons anomalyObjectButtonsButtonsFiller;
    #endregion

    [Header("Anomalies reporting and fixing")]
    [SerializeField] private AnomalyReportMessageView anomalyReportMessageView;
    [SerializeField] private AnomalyFixing anomalyFixing;

    [Header("Anomalies summoner settings")]
    [SerializeField] private AnomaliesSummoner anomaliesSummoner;
    [SerializeField] private AnomaliesSummonerConfig anomaliesSummonerConfig;

    private void Awake()
    {
        #region Security cameras
        securityCameraSwitching.Initialise(securityCameras, currentCameraIndex);
        switchHandler.Initialise(securityCameraSwitching);

        SetSecurityCameras();
        SetSecurityCameraAnimations();
        StartSecurityCameraAnimations();
        #endregion

        #region Data containers
        anomalyReportData = new AnomalyReportData();
        anomalyRoomsContainer.Initialise();
        #endregion

        anomalyReportMessageView.Initialise(anomalyReportData);
        anomalyFixing.Initialise(anomalyReportData);

        #region Filling containers with buttons
        anomalyLocationButtonsFiller.Initialise(anomalyReportData, buttonPrefab);
        anomalyTypesButtonsFiller.Initialise(anomalyReportData, buttonPrefab);
        anomalyObjectButtonsButtonsFiller.Initialise(anomalyReportData, buttonPrefab);

        anomalyLocationButtonsFiller.Initialise(anomalyRoomsContainer, anomalyTypesButtonsFiller, anomalyObjectButtonsButtonsFiller);
        #endregion

        anomaliesSummoner.Initialize(anomalyRoomsContainer, anomaliesSummonerConfig);
    }

    private void Start()
    {
        anomaliesSummoner.StartUp();
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