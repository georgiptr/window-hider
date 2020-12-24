using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace WindowHider
{
    public class WinStruct
    {
        public string WinTitle {get; set; }
        public int WinHwnd { get; set; }
    }

    public enum State
    {
       Show,
       Hide,
       Toggle
    }

    /**
     * Hide or show multiple windows based on partial title match.
     */
    public class WindowHider
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED =  2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_SHOWMINNOACTIVE = 7;
        private const int SW_SHOWNA = 8;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        
        private const int GWL_STYLE = -16;
        private const int WS_VISIBLE = 0x10000000;
        
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(CallBackPtr lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        
        [DllImport("user32.dll", SetLastError=true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private delegate bool CallBackPtr(int hwnd, int lParam);
        private List<WinStruct> WinStructList = new List<WinStruct>();

        private bool Callback(int hWnd, int lparam)
        {
            StringBuilder sb = new StringBuilder(256);
            GetWindowText((IntPtr) hWnd, sb, 256);
            WinStructList.Add(new WinStruct {WinHwnd = hWnd, WinTitle = sb.ToString()});
            return true;
        }

        private List<WinStruct> GetWindows()
        {
            WinStructList = new List<WinStruct>();
            EnumWindows(Callback, IntPtr.Zero);
            return WinStructList;
        }
        
        private bool IsWindowVisible(IntPtr winHwnd)
        {
            int style = GetWindowLong(winHwnd, GWL_STYLE);
            return (style & WS_VISIBLE) == WS_VISIBLE;
        }
        
        public IEnumerable<string> ModifyWindowState(State state, IEnumerable<string> partialWindowTitles)
        {
            var windows = GetWindows();
            var modifiedWindowTitles = new List<string>();
            foreach (var w in windows)
            {
                foreach (var partialTitle in partialWindowTitles)
                {
                    if (!w.WinTitle.ToLower().Contains(partialTitle.ToLower())) continue;
                    modifiedWindowTitles.Add(w.WinTitle);
                    var handle = (IntPtr) w.WinHwnd;
                    switch (state)
                    {
                        case State.Hide:
                            ShowWindowAsync(handle, SW_HIDE); 
                            break;
                        case State.Show:
                            ShowWindowAsync(handle, SW_SHOWDEFAULT);
                            break;
                        case State.Toggle:
                            ShowWindowAsync(handle, IsWindowVisible(handle) ? SW_HIDE : SW_SHOWDEFAULT);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(state), state, null);
                    }
                }
            }
            return modifiedWindowTitles;
        }
    }
}