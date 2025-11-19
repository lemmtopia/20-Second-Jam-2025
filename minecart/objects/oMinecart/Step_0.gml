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