namespace FreeRoamProject.Client.Core.Utility.HUD
{
    // THIS EXTENDS STOCK PARTICLE EFFECT ASSET CLASS WITH NETWORKED PARTICLES..
    // SO THAT EVERYONE CAN SEE THE PARTICLES WITHOUT HAVING TO ADD THEM TO EACH CLIENT
    public class ParticleEffectsAssetNetworked : ParticleEffectsAsset
    {
        private readonly string _assetName;

        public ParticleEffectsAssetNetworked(string assetName) : base(assetName)
        {
            _assetName = assetName;
        }

        internal bool SetNextCall()
        {
            if (!IsLoaded) Request();

            if (IsLoaded)
            {
                SetPtfxAssetNextCall(_assetName);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Starts a Particle Effect on an <see cref="Entity"/> that runs once then is destroyed.
        /// </summary>
        /// <param name="effectName">the name of the effect.</param>
        /// <param name="entity">The <see cref="Entity"/> the effect is attached to.</param>
        /// <param name="off">The offset from the <paramref name="entity"/> to attach the effect.</param>
        /// <param name="rot">The rotation, relative to the <paramref name="entity"/>, the effect has.</param>
        /// <param name="scale">How much to scale the size of the effect by.</param>
        /// <param name="invertAxis">Which axis to flip the effect in. For a car side exahust you may need to flip in the Y Axis</param>
        /// <returns><c>true</c>If the effect was able to start; otherwise, <c>false</c>.</returns>
        public bool StartNonLoopedOnEntityNetworked(string effectName, Entity entity, Vector3 off = default, Vector3 rot = default, float scale = 1.0f, InvertAxis invertAxis = InvertAxis.None)
        {
            if (!SetNextCall()) return false;
            SetPtfxAssetNextCall(_assetName);

            return StartNetworkedParticleFxNonLoopedOnEntity(effectName, entity.Handle, off.X, off.Y, off.Z, rot.X, rot.Y, rot.Z, scale, invertAxis.HasFlag(InvertAxis.X), invertAxis.HasFlag(InvertAxis.Y), invertAxis.HasFlag(InvertAxis.Z));
        }

        /// <summary>
        /// Starts a Particle Effect on an <see cref="EntityBone"/> that runs once then is destroyed.
        /// </summary>
        /// <param name="effectName">the name of the effect.</param>
        /// <param name="entityBone">The <see cref="EntityBone"/> the effect is attached to.</param>
        /// <param name="off">The offset from the <paramref name="entityBone"/> to attach the effect.</param>
        /// <param name="rot">The rotation, relative to the <paramref name="entityBone"/>, the effect has.</param>
        /// <param name="scale">How much to scale the size of the effect by.</param>
        /// <param name="invertAxis">Which axis to flip the effect in. For a car side exahust you may need to flip in the Y Axis</param>
        /// <returns><c>true</c>If the effect was able to start; otherwise, <c>false</c>.</returns>
        public bool StartNonLoopedOnEntityNetworked(string effectName, EntityBone entityBone, Vector3 off = default, Vector3 rot = default, float scale = 1.0f, InvertAxis invertAxis = InvertAxis.None)
        {
            if (!SetNextCall()) return false;
            SetPtfxAssetNextCall(_assetName);

            return StartNetworkedParticleFxNonLoopedOnPedBone(effectName, entityBone.Owner.Handle, off.X, off.Y, off.Z, rot.X, rot.Y, rot.Z, entityBone, scale, invertAxis.HasFlag(InvertAxis.X), invertAxis.HasFlag(InvertAxis.Y), invertAxis.HasFlag(InvertAxis.Z));
        }
    }
}
