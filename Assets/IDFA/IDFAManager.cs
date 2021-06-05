#if UNITY_IOS
using System;
using System.Runtime.InteropServices;

public static class IDFAManager
{
    [DllImport("__Internal")]
    private static extern void _RequestIDFA();

    public static void RequestIDFA()
    {
#if !UNITY_EDITOR
        _RequestIDFA();
#endif
    }
}
#endif
