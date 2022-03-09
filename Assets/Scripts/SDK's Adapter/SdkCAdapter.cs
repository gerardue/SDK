public class SdkCAdapter : ISdk
{
    private SDK_C sdkC;

    public SdkCAdapter()
    {
        sdkC = new SDK_C();
    }

    public string Job()
    {
        return sdkC.Message();
    }
}