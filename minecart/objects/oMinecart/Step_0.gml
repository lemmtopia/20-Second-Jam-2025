if (!instance_exists(target))
{
	exit;
}

if (canMove && !hasArrived)
{
	hsp = moveSpeed * moveDirection;
	
	with (oControl)
	{
		IncreaseTimer();
	}
}
else
{
	hsp = 0;	
}

var _distanceToPlayer = point_distance(x, y, oPlayer.x, oPlayer.y);
var _distanceToPlayerMin = 32;
if (place_meeting(x, y, oBat) || _distanceToPlayer > _distanceToPlayerMin)
{
	hsp = 0;
}

if (global.levelTimer >= global.levelTimerMax)
{
	canMove = false;	
}

if (x >= target.x)
{
	hasArrived = true;
	hsp = 0;
}

x += hsp;