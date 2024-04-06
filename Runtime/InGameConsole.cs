using UnityEngine;
using TMPro;

namespace Yuchen.InGameConsole
{
    public class InGameConsole : MonoBehaviour
    {
        [SerializeField] private TMP_Text m_LogText;

        [SerializeField] private bool m_ShowStackTrace;

        private string m_CurrentLog = "";

        private void OnEnable()
        {
            Application.logMessageReceived += OnLogMessageReceived;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            m_CurrentLog = m_ShowStackTrace ? condition + "\n" + stackTrace + "\n\n" + m_CurrentLog : condition + "\n\n" + m_CurrentLog;
        }

        private void Update()
        {
            m_LogText.text = m_CurrentLog;
        }

        public void ClearLog()
        {
            m_CurrentLog = "";
        }
    }
}
