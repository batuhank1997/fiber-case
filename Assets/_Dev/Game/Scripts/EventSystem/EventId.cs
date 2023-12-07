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
        on_resource_added = 20,
        on_resource_consumed = 21,
        on_resource_reset = 22,
        #endregion

        #region Input
        on_object_clicked = 30,
        #endregion

        #region UI
        on_view_shown = 40,
        on_view_closed = 41,
        #endregion
    }
}
