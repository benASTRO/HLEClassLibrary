﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HLE.Twitch.Chatterino
{
    public static class ChatterinoHelper
    {
        public static List<string> GetChannelsFromChatterinoSettings()
        {
            List<string> result = new();
            try
            {
                string chatterinoSettingsDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Chatterino2\\Settings\\window-layout.json";
                JsonElement chatterinoTabs = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText(chatterinoSettingsDirectory)).GetProperty("windows")[0].GetProperty("tabs");
                for (int i = 0; i < chatterinoTabs.GetArrayLength(); i++)
                {
                    JsonElement tabSettings = chatterinoTabs[i].GetProperty("splits2");
                    try
                    {
                        if (tabSettings.GetProperty("data").GetProperty("type").GetString() == "twitch")
                        {
                            result.Add(tabSettings.GetProperty("data").GetProperty("name").GetString());
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            JsonElement tabItems = tabSettings.GetProperty("items");
                            for (int j = 0; j < tabItems.GetArrayLength(); j++)
                            {
                                if (tabItems[j].GetProperty("data").GetProperty("type").GetString() == "twitch")
                                {
                                    result.Add(tabItems[j].GetProperty("data").GetProperty("name").GetString());
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return result.Distinct().ToList();
        }
    }
}