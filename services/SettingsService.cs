namespace InfiWheelDesktop.services
{
    public class SettingsManager
    {
        private static SettingsManager _instance;
        private static readonly object _lock = new object();
        private bool Darkmode = false;

        public string BgColor { get; } = "#14213D";
        public string BgLightColor { get; } = "#E9E9E9";

        public string FgColor { get; } = "#E9E9E9";
        public string FgLightColor { get; } = "#14213D";
        public string SidebarOrange { get; } = "#FCA311";

        private SettingsManager() { }

        public static SettingsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SettingsManager();
                        }
                    }
                }
                return _instance;
            }
        }
        public void SetDarkmode(bool value)
        {
            Darkmode = value;
        }
        public bool GetDarkmode()
        {
            return Darkmode;
        }

    }
}

