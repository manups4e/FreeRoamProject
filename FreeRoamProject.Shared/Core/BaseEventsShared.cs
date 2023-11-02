namespace FreeRoamProject.Shared.Core
{
    public enum DeathType
    {
        Killer,
        Victim,
        Bystander
    }

    public class PlayerDeadInfo
    {
        public int Victim { get; set; }
        public int Killer { get; set; }
        public DeathType DeathType { get; set; }
        public Position VictimCoords { get; set; }
        public int DeathReason { get; set; }
        public PlayerDeadInfo(int VictimHandle, int KillerHandle, DeathType typeOfEvent, int deathReason, Position victimCoords)
        {
            Victim = VictimHandle;
            Killer = KillerHandle;
            DeathType = typeOfEvent;
            VictimCoords = victimCoords;
            DeathReason = deathReason;
        }
    }
}
