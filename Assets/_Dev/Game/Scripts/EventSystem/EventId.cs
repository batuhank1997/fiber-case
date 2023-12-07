namespace _Dev.Game.Scripts.EventSystem
{
    public enum EventId
    {
        #region Game
        on_game_initialized = 0,
        #endregion

        #region InGame
        on_wave_started = 10,
        on_wave_ended = 11,
        on_enemy_died = 12,
        #endregion

        #region Resources
        on_resource_added,
        on_resource_consumed,
        on_resource_reset,
        #endregion

        #region Input
        on_object_clicked
        #endregion
    }
}
