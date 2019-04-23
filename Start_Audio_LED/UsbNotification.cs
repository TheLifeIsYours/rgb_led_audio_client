using System;
using System.Runtime.InteropServices;

internal static class UsbNotification
{
    public const int DbtDeviceArrival = 0x8000;
    public const int DbtDeviceRemovalComplete = 0x8004;
    public const int WmDeviceChange = 0x0219;
    private const int DbtDevtypeDeviceinterface = 5;
    private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
    private static IntPtr notificationHandle;

    public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
    {
        DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
        {
            DeviceType = DbtDevtypeDeviceinterface,
            Reserved = 0,
            ClassGuid = GuidDevinterfaceUSBDevice,
            Name = 0
        };

        dbi.Size = Marshal.SizeOf(dbi);
        IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
        Marshal.StructureToPtr(dbi, buffer, true);

        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
    }

    public static void UnregisterUsbDeviceNotification()
    {
        UnregisterDeviceNotification(notificationHandle);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr RegisterDeviceNotification(IntPtr recipent, IntPtr notificationFilter, int flags);

    [DllImport("user32.dll")]
    private static extern bool UnregisterDeviceNotification(IntPtr handle);

    [StructLayout(LayoutKind.Sequential)]
    private struct DevBroadcastDeviceinterface
    {
        internal int Size;
        internal int DeviceType;
        internal int Reserved;
        internal Guid ClassGuid;
        internal short Name;
    }
}