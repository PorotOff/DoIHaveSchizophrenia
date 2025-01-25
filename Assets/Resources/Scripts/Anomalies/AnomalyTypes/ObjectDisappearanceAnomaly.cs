public class ObjectDisappearanceAnomaly : BaseAnomalyType
{
    public override void Occur()
    {
        base.Occur();
        
        gameObject.SetActive(false);
    }

    public override void Fix()
    {
        base.Fix();

        gameObject.SetActive(true);
    }
}