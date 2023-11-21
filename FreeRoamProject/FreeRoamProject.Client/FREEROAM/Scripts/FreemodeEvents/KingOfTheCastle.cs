using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Environment = FreeRoamProject.Client.GameMode.FREEROAM.Managers.Environment;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Scripts.EventiFreemode
{
    public class KingOfTheCastle : IWorldEvent
    {
        private Blip radius;
        private Blip icon;
        private Vector3 CurrentPlace;
        TimeSpan TempoCastello = TimeSpan.Zero;
        private List<Vector3> places = new List<Vector3>()
        {
            new Vector3(-429.50573730469f, 1109.7385253906f, 327.68228149414f),
            new Vector3(2747.3190917969f, 1524.2060546875f, 42.893901824951f),
            new Vector3(-1806.5964355469f, 443.03262329102f, 128.50791931152f),
            new Vector3(937.27996826172f, -3033.9206542969f, 5.9020395278931f),
            new Vector3(1459.8696289063f, 1112.6547851563f, 114.33392333984f),
            new Vector3(100.60562133789f, -1937.0286865234f, 20.803699493408f),
            new Vector3(-1033.8146972656f, -1072.1015625f, 4.0820965766907f),
            new Vector3(-1651.9538574219f, -1099.3696289063f, 13.078674316406f),
            new Vector3(1234.7498779297f, -648.01989746094f, 66.377662658691f),
            new Vector3(1364.8551025391f, -579.05023193359f, 74.380249023438f),
            new Vector3(-1664.5391845703f, -152.79943847656f, 58.008377075195f),
            new Vector3(1448.15625f, 6350.9267578125f, 23.653469085693f),
            new Vector3(1665.9049072266f, -15.893600463867f, 173.77449035645f),
            new Vector3(-367.48580932617f, 6076.2182617188f, 31.478071212769f),
            new Vector3(-531.49578857422f, 5322.77734375f, 91.377044677734f),
        };

        public KingOfTheCastle(int id, string name, double countdownTime, double seconds) : base(id, name, countdownTime, seconds, false, "KOTC_KLLALL", (PlayerStats)(-1), isTimeEvent: true)
        {
        }

        public override void OnEventActivated()
        {
            CurrentPlace = places[new Random().Next(places.Count - 1)];
            radius = World.CreateBlip(CurrentPlace, 50f);
            radius.Color = (BlipColor)50;
            radius.Alpha = 128;
            icon = World.CreateBlip(CurrentPlace);
            icon.Sprite = BlipSprite.Castle;
            icon.Name = Game.GetGXTEntry("BLIP_438");
            icon.Color = (BlipColor)50;
            ClientMain.Instance.AddTick(OnTick);
        }

        public override void ResetEvent()
        {
            if (radius is not null) radius.Delete();
            if (icon is not null) icon.Delete();
            CurrentPlace = Vector3.Zero;
            Environment.EnableWanted(true);
            ClientMain.Instance.RemoveTick(OnTick);
            base.ResetEvent();
        }

        private int _timer = 0;

        private async Task OnTick()
        {
            try
            {
                if (!IsActive) { return; }

                if (!IsStarted)
                    Screen.ShowSubtitle(Game.GetGXTEntry("AMCH_PREPARE").Replace("~a~", Name), 50);
                else
                {
                    if (!Cache.PlayerCache.MyClient.Position.IsInRangeOf(CurrentPlace, 50f))
                    {
                        Screen.ShowSubtitle(Game.GetGXTEntry("KOTC_1STHELP"), 50);
                        if (CurrentAttempt > 0) CurrentAttempt = 0;
                    }
                    else
                    {
                        if (PlayerCache.MyClient.Player.WantedLevel > 0)
                            Environment.EnableWanted(false);
                        Screen.ShowSubtitle(Game.GetGXTEntry("KOTC_KINGOB1"), 1);
                        if (GetNetworkTime() - _timer > 1000)
                        {
                            _timer = GetNetworkTime();
                            CurrentAttempt++;
                            ClientMain.Logger.Debug(CurrentAttempt.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientMain.Logger.Error(ex.ToString());
            }
            await Task.FromResult(0);
        }
    }
}
