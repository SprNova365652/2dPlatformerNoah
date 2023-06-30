using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;


namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player is spawned after dying.
    /// </summary>
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        //Vector3 spawnPoint = CheckpointController;
        // CheckpointController checkpointController;

        public override void Execute()
        {
            var player = model.player;
            player.collider2d.enabled = true;
            player.controlEnabled = false;
            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);
            player.health.Increment();
            //player.Teleport(model.spawnPoint.transform.position);
            // checkpointController = new CheckpointController();
            // UnityEngine.Vector3 location = checkpointController.checkpoint;
            player.Teleport(player.respawnPoint);
            player.jumpState = PlayerController.JumpState.Grounded;
            player.animator.SetBool("dead", false);
            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;
            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}