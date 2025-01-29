﻿using Chauffeur.Utils;
using TaxiTrainer.Managers;

namespace TaxiTrainer.Trainer;

public class TrainerMenu : CustomMenu
{
    private bool _allLevelsUnlocked;

    public TrainerMenu() : base("Trainer")
    {
        var teleportMenu = new TeleportMenu();
        AddButton(new MenuButton("Teleport", teleportMenu.LoadMenu));
        _allLevelsUnlocked = true;
        foreach (var data in Data.levelDataList)
        {
            if (data.levelUnlocked) continue;
            _allLevelsUnlocked = false;
            break;
        }
        // AddButton(new MenuButton(() => _allLevelsUnlocked ? "Lock All Levels" : "Unlock All Levels", ToggleLockedLevels));
        AddButton(new MenuButton(() => Master.instance.DEBUG ? "Disable Debug" : "Enable Debug",
            () => Master.instance.DEBUG = !Master.instance.DEBUG));
        AddButton(new MenuButton(
            () => Master.instance.SHOW_TESTER_BUTTONS ? "Disable Inputs Overlay" : "Enable Inputs Overlay",
            () => Master.instance.SHOW_TESTER_BUTTONS = !Master.instance.SHOW_TESTER_BUTTONS));

        var controlsMenu = new PlayerControlsMenu();
        AddButton(new MenuButton("Controls Restrictions", controlsMenu.LoadMenu));
        
        AddLevelManagementButtons();
    }

    private void AddLevelManagementButtons()
    {
        var levelManager = new LevelManager();
        AddButton(new MenuButton(levelManager.GetDeathTrainerText, levelManager.ChangeDeathBehavior));
        AddButton(new MenuButton(LocalizationHelper.GoBackText, GoBack));
    }

    private void ToggleLockedLevels()
    {
        _allLevelsUnlocked = !_allLevelsUnlocked;
        foreach (var data in Data.levelDataList)
        {
            data.levelUnlocked = _allLevelsUnlocked;
        }
    }
}