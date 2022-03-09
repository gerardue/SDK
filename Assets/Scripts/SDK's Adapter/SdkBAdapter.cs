public class SdkBAdapter : ISdk
{
    private SDK_B sdkB;

    public SdkBAdapter()
    {
        sdkB = new SDK_B();
    }

    public string Job()
    {
        return sdkB.Message();
    }
}
