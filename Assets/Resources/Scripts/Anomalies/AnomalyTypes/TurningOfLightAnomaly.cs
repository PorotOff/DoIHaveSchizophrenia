using UnityEngine;

public class TurningOfLightAnomaly : BaseAnomalyType
{
    private Light bulbLight;

    public override void Initialise()
    {
        base.Initialise();

        bulbLight = GetComponent<Light>();
    }

    public override void Occur()
    {
        base.Occur();

        bulbLight.enabled = false;
    }

    public override void Fix()
    {
        base.Fix();

        bulbLight.enabled = true;
    }
}