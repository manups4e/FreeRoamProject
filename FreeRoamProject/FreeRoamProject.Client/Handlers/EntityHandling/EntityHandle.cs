using FreeRoamProject.Client.Handlers.Animations;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers.EntityHandling
{
    public enum TypeSpawn
    {
        Network,
        Local
    }

    #region Entity
    public abstract class EntityHandle
    {
        public int Handle { get; set; }
        public Position Position { get; set; }
        public Model Model { get; set; }
        public TypeSpawn TypeSpawn { get; set; }

        protected EntityHandle()
        {
        }

        protected EntityHandle(Position pos, TypeSpawn type)
        {
            Position = pos;
            TypeSpawn = type;
        }

        protected virtual void Delete()
        {
        }
    }
    #endregion

    #region Ped

    public class PedHandle : EntityHandle
    {
        public Ped Ped { get; set; }
        public AnimationQueue AnimQueue;

        public PedHandle()
        {
        }

        public PedHandle(string model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = new Model(model);
        }

        public PedHandle(PedHash model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = new Model(model);
        }

        public PedHandle(Model model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = model;
        }

        public async Task<Ped> SpawnResult()
        {
            Ped result;
            if (TypeSpawn == TypeSpawn.Local)
                result = await Functions.CreatePedLocally(Model.Hash, Position.ToVector3, Position.Heading);
            else
                result = await Functions.SpawnPed(Model.Hash, Position);

            return result;
        }

        public async Task Spawn()
        {
            if (TypeSpawn == TypeSpawn.Local)
                Ped = await Functions.CreatePedLocally(Model.Hash, Position.ToVector3, Position.Heading);
            else
                Ped = await Functions.SpawnPed(Model.Hash, Position);
            AnimQueue = new AnimationQueue(Ped.Handle);
        }
    }

    #endregion

    #region Vehicle

    public class VehicleHandle : EntityHandle
    {
        public Vehicle Vehicle { get; set; }

        public VehicleHandle()
        {
        }

        public VehicleHandle(string model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = new Model(model);
        }

        public VehicleHandle(PedHash model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = new Model(model);
        }

        public VehicleHandle(Model model, Position pos, TypeSpawn type) : base(pos, type)
        {
            Model = model;
        }

        public async Task<Vehicle> SpawnResult()
        {
            Vehicle result;
            if (TypeSpawn == TypeSpawn.Local)
                result = await Functions.SpawnLocalVehicle(Model.Hash, Position.ToVector3, Position.Heading);
            else
                result = await Functions.SpawnVehicleNoPlayerInside(Model.Hash, Position.ToVector3, Position.Heading);

            return result;
        }

        public async Task Spawn()
        {
            if (TypeSpawn == TypeSpawn.Local)
                Vehicle = await Functions.SpawnLocalVehicle(Model.Hash, Position.ToVector3, Position.Heading);
            else
                Vehicle = await Functions.SpawnVehicleNoPlayerInside(Model.Hash, Position.ToVector3, Position.Heading);
        }
    }

    #endregion

    #region Prop

    public class PropHandle : EntityHandle
    {
        public Prop Prop { get; set; }
        private readonly bool _placeOnGround;
        private readonly bool _dynamic;

        public PropHandle()
        {
        }

        public PropHandle(string model, Position pos, TypeSpawn type, bool placeOnGround = true, bool dynamic = true) : base(pos, type)
        {
            Model = new Model(model);
            _placeOnGround = placeOnGround;
            _dynamic = dynamic;
        }

        public PropHandle(PedHash model, Position pos, TypeSpawn type, bool placeOnGround = true, bool dynamic = true) : base(pos, type)
        {
            Model = new Model(model);
            _placeOnGround = placeOnGround;
            _dynamic = dynamic;
        }

        public PropHandle(Model model, Position pos, TypeSpawn type, bool placeOnGround = true, bool dynamic = true) : base(pos, type)
        {
            Model = model;
            _placeOnGround = placeOnGround;
            _dynamic = dynamic;
        }

        public async Task<Prop> SpawnResult()
        {
            Prop result;
            if (TypeSpawn == TypeSpawn.Local)
                result = await Functions.SpawnLocalProp(Model.Hash, Position.ToVector3, _dynamic, _placeOnGround);
            else
                result = await Functions.CreateProp(Model.Hash, Position.ToVector3, Vector3.Zero);

            return result;
        }

        public async Task Spawn()
        {
            if (TypeSpawn == TypeSpawn.Local)
                Prop = await Functions.SpawnLocalProp(Model.Hash, Position.ToVector3, _dynamic, _placeOnGround);
            else
                Prop = await Functions.CreateProp(Model.Hash, Position.ToVector3, Vector3.Zero);
        }
    }

    #endregion
}