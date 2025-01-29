﻿using System;
using System.Collections.Generic;
using Chauffeur.Utils;

namespace TaxiTrainer.Trainer;

public class TeleportMenu : CustomMenu
{
    private Dictionary<string, Action> _portalMap;

    public TeleportMenu() : base("Select Teleport Level")
    {
        BuildData();

        foreach (var kvp in _portalMap)
        {
            AddButton(new MenuButton(kvp.Key, kvp.Value));
        }
    }

    private void BuildData()
    {
        _portalMap = new Dictionary<string, Action>
        {
            { "Morio's Lab", () => Teleport(Levels.Index.level_hub, Data.LevelId.Hub) },
            { "Morio's Island", () => Teleport(Levels.Index.level_MoriosHome, Data.LevelId.L3_MoriosHome) },
            { "Bombeach", () => Teleport(Levels.Index.level_bombeach, Data.LevelId.L1_Bombeach) },
            { "Pizza Time", () => Teleport(Levels.Index.level_PizzaTime, Data.LevelId.L2_PizzaTime) },
            { "Arcade Panik", () => Teleport(Levels.Index.level_PanikArcade, Data.LevelId.L4_ArcadePanik) },
            { "Tosla HQ", () => Teleport(Levels.Index.level_ToslaHq, Data.LevelId.L14_ToslaHQ) },
            { "Tosla Offices", () => Teleport(Levels.Index.level_ToslaOffices, Data.LevelId.L5_ToslaOffices) },
            {
                "Crash Test Industries",
                () => Teleport(Levels.Index.level_CrashTestIndustries, Data.LevelId.L10_CrashTestIndustries)
            },
            { "Morio's Mind", () => Teleport(Levels.Index.level_MoriosMind, Data.LevelId.L12_MoriosMind) },
            { "City", () => Teleport(Levels.Index.level_City, Data.LevelId.L9_City) },
            { "Gym", () => Teleport(Levels.Index.level_Gym, Data.LevelId.L6_Gym) },
            { "Fecal Matters", () => Teleport(Levels.Index.level_PoopWorld, Data.LevelId.L7_PoopWorld) },
            { "Flushed Away", () => Teleport(Levels.Index.level_Sewers, Data.LevelId.L8_Sewers) },
            { "Ruined Observatory", () => Teleport(Levels.Index.level_StarmanCastle, Data.LevelId.L13_StarmanCastle) },
            { "Moon", () => Teleport(Levels.Index.level_Moon, Data.LevelId.L15_Moon) },
            { "Mosk's Rocket", () => Teleport(Levels.Index.level_Rocket, Data.LevelId.L16_Rocket) }
        };
    }

    private void Teleport(Levels.Index index, Data.LevelId id)
    {
        ClearMenus();
        PortalScript.GoToLevel(index, id);
    }
}