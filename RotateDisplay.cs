using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static DisplayOrientation.RotateDisplay;


// Running is only in windows 10-11
namespace DisplayOrientation
{
    public static class RotateDisplay
    {
        //https://learn.microsoft.com/en-us/windows/win32/gdi/enumeration-and-display-control
        public static bool Running(uint deviceID_a, uint rotateMode_a, bool firstDisplay_a, bool secondDisplay, ref int width_a, ref int height_a)
        {
            uint deviceID = deviceID_a;
            uint rotateMode = rotateMode_a;

            DISPLAY_DEVICE _device = new DISPLAY_DEVICE();
            DEVMODE _dm = new DEVMODE();
            _device.cb = Marshal.SizeOf(_device);
            uint DispNum = 0;
            // get all display devices
            while (NativeMethods.EnumDisplayDevices(null, DispNum, ref _device, 0))
            {
                //ZeroMemory(&dm, sizeof(DEVMODE));
                _dm = new DEVMODE();
                _dm.dmSize = (short)Marshal.SizeOf(_dm);
                //dm.dmSize = sizeof(DEVMODE);
                if (0 == NativeMethods.EnumDisplaySettings(_device.DeviceName, NativeMethods.ENUM_CURRENT_SETTINGS, ref _dm))
                {
                    return false;
                   // OutputDebugString("Store default failed\n");
                }
               // int _temp = (int)(d.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop);
               // var tt = d.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop;
                if (((int)(_device.StateFlags & DisplayDeviceStateFlags.AttachedToDesktop) != 0) && firstDisplay_a)
                { 
                    DEVMODE DevMode;
                    DEVMODE devMode = new DEVMODE();
                    // ZeroMemory(&DevMode, sizeof(DevMode));
                    // DevMode.dmSize = sizeof(DevMode);
                    devMode.dmSize |= (short)Marshal.SizeOf(devMode);
                    //DevMode.dmFields = DM_PELSWIDTH | DM_PELSHEIGHT | DM_BITSPERPEL | DM_POSITION
                    //            | DM_DISPLAYFREQUENCY | DM_DISPLAYFLAGS;
                    DevMode.dmFields = DM.PelsWidth | DM.PelsHeight | DM.BitsPerPixel | DM.Position | DM.DisplayFrequency | DM.DisplayFlags;

                    rotate(rotateMode_a, ref _dm);

                    DISP_CHANGE iRet = NativeMethods.ChangeDisplaySettingsEx(_device.DeviceName,
                                                    ref _dm, 
                                                    IntPtr.Zero,
                                                    DisplaySettingsFlags.CDS_UPDATEREGISTRY, 
                                                    IntPtr.Zero);
                    if (iRet != DISP_CHANGE.Successful)
                    {
                        return false;
                    }
                    width_a = _dm.dmPelsWidth;
                    height_a = _dm.dmPelsHeight;
                }
                //_dm = new DEVMODE();                
                DispNum++;
            }

            return true;
        }

        public static bool Running(uint deviceID_a, uint rotateMode_a, ref int width_a, ref int height_a)
        {
            uint deviceID = deviceID_a;
            uint rotateMode = rotateMode_a;

            DISPLAY_DEVICE d = new DISPLAY_DEVICE();
            DEVMODE dm = new DEVMODE();
            d.cb = Marshal.SizeOf(d);
            //https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdisplaydevicesa
            if (!NativeMethods.EnumDisplayDevices(null, deviceID, ref d, 0))
            {
                return false;
            }


            if (0 != NativeMethods.EnumDisplaySettings(
                d.DeviceName, NativeMethods.ENUM_CURRENT_SETTINGS, ref dm))
            {
                int _w = dm.dmPelsWidth;
                int _h = dm.dmPelsHeight;
                //dm.dmPelsHeight = dm.dmPelsWidth;
                //dm.dmPelsWidth = temp;
                //  int temp = 0;
                switch (rotateMode)
                {
                    case 270:
                        if (_w > _h)
                        {
                            dm.dmPelsHeight = _w;
                            dm.dmPelsWidth = _h;
                        }
                        dm.dmDisplayOrientation = NativeMethods.DMDO_270;
                        break;
                    case 180:
                        if (_h > _w)
                        {
                            dm.dmPelsHeight = _w;
                            dm.dmPelsWidth = _h;
                        }
                        dm.dmDisplayOrientation = NativeMethods.DMDO_180;
                        break;
                    case 90:
                        if (_w > _h)
                        {
                            dm.dmPelsHeight = _w;
                            dm.dmPelsWidth = _h;
                        }                     
                        dm.dmDisplayOrientation = NativeMethods.DMDO_90;
                        break;
                    case 0:
                        if (_h > _w)
                        {
                            dm.dmPelsHeight = _w;
                            dm.dmPelsWidth = _h;
                        }
                        dm.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                        break;
                    default:
                        break;
                }               
            }
            else
            {
                return false;
            }
            DISP_CHANGE iRet = NativeMethods.ChangeDisplaySettingsEx(
            d.DeviceName, ref dm, IntPtr.Zero,
            DisplaySettingsFlags.CDS_UPDATEREGISTRY, IntPtr.Zero);
            if (iRet != DISP_CHANGE.Successful)
            {
                return false;
            }
            width_a = dm.dmPelsWidth;
            height_a = dm.dmPelsHeight;
            return true;
        }

        private static void rotate(uint rotateMode_a, ref DEVMODE dm_a) 
        {
            int _w = dm_a.dmPelsWidth;
            int _h = dm_a.dmPelsHeight;
            switch (rotateMode_a)
            {
                case 270:
                    if (_w > _h)
                    {
                        dm_a.dmPelsHeight = _w;
                        dm_a.dmPelsWidth = _h;
                    }
                    dm_a.dmDisplayOrientation = NativeMethods.DMDO_270;
                    break;
                case 180:
                    if (_h > _w)
                    {
                        dm_a.dmPelsHeight = _w;
                        dm_a.dmPelsWidth = _h;
                    }
                    dm_a.dmDisplayOrientation = NativeMethods.DMDO_180;
                    break;
                case 90:
                    if (_w > _h)
                    {
                        dm_a.dmPelsHeight = _w;
                        dm_a.dmPelsWidth = _h;
                    }
                    dm_a.dmDisplayOrientation = NativeMethods.DMDO_90;
                    break;
                case 0:
                    if (_h > _w)
                    {
                        dm_a.dmPelsHeight = _w;
                        dm_a.dmPelsWidth = _h;
                    }
                    dm_a.dmDisplayOrientation = NativeMethods.DMDO_DEFAULT;
                    break;
                default:
                    break;
            }
        }

        /*internal*/
        public static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern DISP_CHANGE ChangeDisplaySettingsEx(
                string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd,
                DisplaySettingsFlags dwflags, IntPtr lParam);
        
            [DllImport("user32.dll")]
            internal static extern bool EnumDisplayDevices(
                string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice,
                uint dwFlags);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            internal static extern int EnumDisplaySettings(
                string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

            public const int DMDO_DEFAULT = 0;
            public const int DMDO_90 = 3;
            public const int DMDO_180 = 2;
            public const int DMDO_270 = 1;

            public const int ENUM_CURRENT_SETTINGS = -1;
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
        /*internal*/ public struct DEVMODE
        {
            public const int CCHDEVICENAME = 32;
            public const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            [System.Runtime.InteropServices.FieldOffset(0)]
            public string dmDeviceName;
            [System.Runtime.InteropServices.FieldOffset(32)]
            public Int16 dmSpecVersion;
            [System.Runtime.InteropServices.FieldOffset(34)]
            public Int16 dmDriverVersion;
            [System.Runtime.InteropServices.FieldOffset(36)]
            public Int16 dmSize;
            [System.Runtime.InteropServices.FieldOffset(38)]
            public Int16 dmDriverExtra;
            [System.Runtime.InteropServices.FieldOffset(40)]
            public DM dmFields;

            [System.Runtime.InteropServices.FieldOffset(44)]
            Int16 dmOrientation;
            [System.Runtime.InteropServices.FieldOffset(46)]
            Int16 dmPaperSize;
            [System.Runtime.InteropServices.FieldOffset(48)]
            Int16 dmPaperLength;
            [System.Runtime.InteropServices.FieldOffset(50)]
            Int16 dmPaperWidth;
            [System.Runtime.InteropServices.FieldOffset(52)]
            Int16 dmScale;
            [System.Runtime.InteropServices.FieldOffset(54)]
            Int16 dmCopies;
            [System.Runtime.InteropServices.FieldOffset(56)]
            Int16 dmDefaultSource;
            [System.Runtime.InteropServices.FieldOffset(58)]
            Int16 dmPrintQuality;

            [System.Runtime.InteropServices.FieldOffset(44)]
            public POINTL dmPosition;
            [System.Runtime.InteropServices.FieldOffset(52)]
            public Int32 dmDisplayOrientation;
            [System.Runtime.InteropServices.FieldOffset(56)]
            public Int32 dmDisplayFixedOutput;

            [System.Runtime.InteropServices.FieldOffset(60)]
            public short dmColor;
            [System.Runtime.InteropServices.FieldOffset(62)]
            public short dmDuplex;
            [System.Runtime.InteropServices.FieldOffset(64)]
            public short dmYResolution;
            [System.Runtime.InteropServices.FieldOffset(66)]
            public short dmTTOption;
            [System.Runtime.InteropServices.FieldOffset(68)]
            public short dmCollate;
            [System.Runtime.InteropServices.FieldOffset(72)]
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            [System.Runtime.InteropServices.FieldOffset(102)]
            public Int16 dmLogPixels;
            [System.Runtime.InteropServices.FieldOffset(104)]
            public Int32 dmBitsPerPel;
            [System.Runtime.InteropServices.FieldOffset(108)]
            public Int32 dmPelsWidth;
            [System.Runtime.InteropServices.FieldOffset(112)]
            public Int32 dmPelsHeight;
            [System.Runtime.InteropServices.FieldOffset(116)]
            public Int32 dmDisplayFlags;
            [System.Runtime.InteropServices.FieldOffset(116)]
            public Int32 dmNup;
            [System.Runtime.InteropServices.FieldOffset(120)]
            public Int32 dmDisplayFrequency;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        /*internal*/ public struct DISPLAY_DEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;
            [MarshalAs(UnmanagedType.U4)]
            public DisplayDeviceStateFlags StateFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTL
        {
            long x;
            long y;
        }

        public enum DISP_CHANGE : int
        {
            Successful = 0,
            Restart = 1,
            Failed = -1,
            BadMode = -2,
            NotUpdated = -3,
            BadFlags = -4,
            BadParam = -5,
            BadDualView = -6
        }

        [Flags()]
        public enum DisplayDeviceStateFlags : int
        {
            AttachedToDesktop = 0x1,
            MultiDriver = 0x2,

            PrimaryDevice = 0x4,

            MirroringDriver = 0x8,

            VGACompatible = 0x16,

            Removable = 0x20,

            ModesPruned = 0x8000000,
            Remote = 0x4000000,
            Disconnect = 0x2000000
        }

        [Flags()]
        public enum DisplaySettingsFlags : int
        {
            CDS_UPDATEREGISTRY = 1,
            CDS_TEST = 2,
            CDS_FULLSCREEN = 4,
            CDS_GLOBAL = 8,
            CDS_SET_PRIMARY = 0x10,
            CDS_RESET = 0x40000000,
            CDS_NORESET = 0x10000000
        }

        [Flags()]
        public enum DM : int
        {
            Orientation = 0x1,
            PaperSize = 0x2,
            PaperLength = 0x4,
            PaperWidth = 0x8,
            Scale = 0x10,
            Position = 0x20,
            NUP = 0x40,
            DisplayOrientation = 0x80,
            Copies = 0x100,
            DefaultSource = 0x200,
            PrintQuality = 0x400,
            Color = 0x800,
            Duplex = 0x1000,
            YResolution = 0x2000,
            TTOption = 0x4000,
            Collate = 0x8000,
            FormName = 0x10000,
            LogPixels = 0x20000,
            BitsPerPixel = 0x40000,
            PelsWidth = 0x80000,
            PelsHeight = 0x100000,
            DisplayFlags = 0x200000,
            DisplayFrequency = 0x400000,
            ICMMethod = 0x800000,
            ICMIntent = 0x1000000,
            MediaType = 0x2000000,
            DitherType = 0x4000000,
            PanningWidth = 0x8000000,
            PanningHeight = 0x10000000,
            DisplayFixedOutput = 0x20000000
        }
        //  DM_PELSWIDTH | DM_PELSHEIGHT | DM_BITSPERPEL | DM_POSITION
        //  | DM_DISPLAYFREQUENCY | DM_DISPLAYFLAGS;
        //  PelsWidth | PelsHeight | BitsPerPixel | Position | DisplayFrequency | DisplayFlags
    }
}