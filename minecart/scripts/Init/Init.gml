randomize();

global.screenW = 160;
global.screenH = 144;

window_set_size(global.screenW * 3, global.screenH * 3);
window_center();

global.levelTimer = 0;
global.levelTimerMax = 20;

function Reset()
{
	global.levelTimer = 0;
}	