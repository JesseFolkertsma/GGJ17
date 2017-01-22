using UnityEngine;

namespace Corn.Components
{
    public interface ILives
    {
        int lives { get; set; }
        void Die ();
        void Heal (int amount);
        bool isDead { get; set; }
        void Respawn (Transform location);
        int respawnsLeft { get; set; }
        Kernel[] GetKernals { get; }
    }
}