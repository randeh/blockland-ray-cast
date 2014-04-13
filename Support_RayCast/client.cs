// find out max/min points of ray
// record all bricks inside the box
// loop through each cell the ray intersects checking if there's a brick

function player::clientRayCast(%this, %dist)
{
	%eyePoint = %this.getEyePoint();
	%eyeVector = %this.getEyeVector();
	%rayVector = vectorScale(%eyeVector, %dist);
	%endPoint = vectorAdd(%eyePoint, %rayVector);
	for(%i = 0; %i < 3; %i++)
	{
		%min[%i] = mMin(getWord(%eyePoint, %i), getWord(%endPoint, %i));
		%max[%i] = mMax(getWord(%eyePoint, %i), getWord(%endPoint, %i));
	}
	for(%i = 0; %i < serverConnection.getCount(); %i++)
	{
		%obj = serverConnection.getObject(%i);
		if(%obj.getClassName() !$= "fxDtsBrick")
		{
			continue;
		}
		%objData = %obj.getDataBlock();
		%objPos = %obj.getPosition();
		%objPos[0] = getWord(%objPos, 0);
		%objPos[1] = getWord(%objPos, 1);
		%objPos[2] = getWord(%objPos, 2);
		if(%obj.getAngleID() % 2)
		{
			//if((%objPos[0] - %objData.brickSizeY) > %min[0]
		}
		else
		{
			
		}
	}
}

function mMax(%a, %b)
{
	return %a > %b ? %a : %b;
}

function mMin(%a, %b)
{
	return %a < %b ? %a : %b;
}

//function getGridXY(%pos)
//{
//	return mFloor(%pos * 2);
//}

//function getGridZ(%pos)
//{
//	return mFloor(%pos * 5);
//}