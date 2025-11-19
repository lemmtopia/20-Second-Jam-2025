Reset();

function IncreaseTimer()
{
	global.levelTimer += 1 / game_get_speed(gamespeed_fps);
}	