using BepInEx;
using BepInEx.Logging;
using Chauffeur.Managers;
using Chauffeur.Utils.MenuUtils;
using TaxiTrainer.Trainer;

namespace TaxiTrainer;

[BepInDependency("com.alwaysintreble.Chauffeur")]
[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
public class Main : BaseUnityPlugin
{
    public const string PluginGuid = "com.alwaysintreble.TaxiTrainer";
    public const string PluginName = "TaxiTrainer";
    public const string PluginVersion = "0.2.0";

    public const string ModDisplayInfo = $"{PluginName} v{PluginVersion}";
    public static ManualLogSource ChauffeurLogger;
    public static Main Instance;

    private void Awake()
    {
        ChauffeurLogger = Logger;
        Instance = this;

        MenuManager.AddButtons += () =>
        {
            var trainerMenu = new TrainerMenu();
            MenuManager.AddPauseMenuButton(new MenuButton("Trainer", trainerMenu.LoadMenu, () => true));
        };
    }
}
