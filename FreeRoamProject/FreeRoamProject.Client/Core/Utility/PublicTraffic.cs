namespace FreeRoamProject.Client.Core.Utility
{
    // TODO: TAKEN FROM RP.. THIS HANDLES TRAFFIC BASED ON TIME OF THE DAY AND WEATHER (IN GAME)
    /*
    public class PublicTraffic
    {
        private static float baseTraffic { get; set; }
        private static float divMultiplier { get; set; }
        private static TimeSpan LastCheck;

        public static void Init()
        {
            AccessingEvents.OnRoleplaySpawn += Spawned;
            AccessingEvents.OnRoleplayLeave += onPlayerLeft;
        }

        public static void Spawned(PlayerClient client)
        {
            baseTraffic = Client.Settings.RolePlay.Main.BaseTraffic;
            divMultiplier = Client.Settings.RolePlay.Main.DivMultiplier;
            LastCheck = World.CurrentDayTime;
            SetDensity();
            ClientMain.Instance.AddTick(Check);
        }

        public static void onPlayerLeft(PlayerClient client)
        {
            baseTraffic = Client.Settings.RolePlay.Main.BaseTraffic;
            divMultiplier = Client.Settings.RolePlay.Main.DivMultiplier;
            LastCheck = World.CurrentDayTime;
            ClientMain.Instance.RemoveTick(Check);
        }

        public static async Task Check()
        {
            if (World.CurrentDayTime.Subtract(LastCheck).Seconds >= 30)
            {
                SetDensity();
                LastCheck = World.CurrentDayTime;
            }

            await Task.FromResult(0);
        }

        private static void SetDensity()
        {
            TimeSpan time = World.CurrentDayTime;

            if (time.Hours >= 20 || time.Hours <= 5)
            {
                //Debug.WriteLine("it's the night!");
                API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic + baseTraffic / 2);
                API.SetPedDensityMultiplierThisFrame(baseTraffic / divMultiplier);
                API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier);
                API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic / divMultiplier, baseTraffic / divMultiplier);
                API.SetVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier);
            }
            else
            {
                //Debug.WriteLine("it's the day!");
                API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                API.SetPedDensityMultiplierThisFrame(baseTraffic);
                API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                API.SetVehicleDensityMultiplierThisFrame(baseTraffic);
            }

            switch (World.Weather)
            {
                case Weather.Blizzard:
                    {
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetPedDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic / divMultiplier, baseTraffic / divMultiplier);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier / 2));

                        break;
                    }
                case Weather.Christmas:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(2.5f);
                        API.SetPedDensityMultiplierThisFrame(2.5f);
                        API.SetScenarioPedDensityMultiplierThisFrame(3f, 3f);
                        API.SetRandomVehicleDensityMultiplierThisFrame(2f);
                        API.SetVehicleDensityMultiplierThisFrame(2f);

                        break;
                    }
                case Weather.Clear:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Clearing:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Clouds:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.ExtraSunny:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(1.2f);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic + 1.2f);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic + 1.2f);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic + 1.2f, baseTraffic + 1.2f);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic + 1.2f);

                        break;
                    }
                case Weather.Foggy:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Neutral:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Overcast:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Raining:
                    {
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetPedDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic / divMultiplier, baseTraffic / divMultiplier);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier / 2));

                        break;
                    }
                case Weather.Smog:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.Snowing:
                    {
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetPedDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic / divMultiplier, baseTraffic / divMultiplier);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier / 2));

                        break;
                    }
                case Weather.Snowlight:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                case Weather.ThunderStorm:
                    {
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetPedDensityMultiplierThisFrame(baseTraffic / (divMultiplier - divMultiplier / 2));
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic / divMultiplier, baseTraffic / divMultiplier);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic / (divMultiplier / 2));

                        break;
                    }
                case Weather.Unknown:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
                default:
                    {
                        API.SetParkedVehicleDensityMultiplierThisFrame(baseTraffic / divMultiplier + baseTraffic / 2);
                        API.SetPedDensityMultiplierThisFrame(baseTraffic);
                        API.SetRandomVehicleDensityMultiplierThisFrame(baseTraffic);
                        API.SetScenarioPedDensityMultiplierThisFrame(baseTraffic, baseTraffic);
                        API.SetVehicleDensityMultiplierThisFrame(baseTraffic);

                        break;
                    }
            }

            API.SetRandomBoats(true);
            API.SetRandomTrains(true);
        }
    }
    */
}