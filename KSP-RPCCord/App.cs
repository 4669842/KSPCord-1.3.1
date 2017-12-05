using System.Windows;
using UnityEngine;
namespace KSPCord
{
    /// <summary>
    /// Interaction logic for discord RPC
    /// </summary>
    public partial class App : MonoBehaviour
    {
        // 32bit Discord RPC DLL
        public const string DLL = "discord-rpc-w32";

        public App() : base()
        {
            if (!System.IO.File.Exists(DLL + ".dll"))
            {
                Debug.Log("Beep, Boop! " +
                    "Missing " + DLL + ".dll\n\n" +
                    "Need compiled Discord RPC libary, please download it and place it in the same plugin folder as KSPCord.dll, then restart the game.\n\n" +
                    "https://github.com/nostrenz/cshap-discord-rpc-demo"
                );
            }
        }
    }
}