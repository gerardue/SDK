public class SdkAAdapter : ISdk
{
    private SDK_A sdkA;

    public SdkAAdapter()
    {
        sdkA = new SDK_A();
    }

    public string Job()
    {
        return sdkA.Message();
    }
}
