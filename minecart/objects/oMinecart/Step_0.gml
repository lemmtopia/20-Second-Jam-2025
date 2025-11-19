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

if (place_meeting(x, y, oBat))
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