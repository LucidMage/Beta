//	Scene Setup
function Lesson3A_Forest::Setup(%this)
{
	%this.setName("Lesson3A_Forest");

	//	Add Tiled Map
	%mapSprite = new TmxMapSprite()
	{
		Map = "Year8:lesson3A_map";
	};
	
	%this.add(%mapSprite);

	%this.SetupCharacters();
	%this.SetupObstacles();
}

//	Characters
function Lesson3A_Forest::SetupCharacters(%this)
{
	//  Create Player
	SetupPlayer(%this, PlayerPos.getPosition(), PlayerPos.getSceneLayer());
	Player.direction = $SpriteDirectionUp;
	Player.UpdateImages();

	//	NPCs
	//  Underarm Hair Person
	new CompositeSprite(L3A_UnderarmHairPerson)
	{
		displayName = "Girl with Raised Arms";
		class = "Character";
		dialogueTree = L3A_UnderarmHairDialogueTree;
		//state = $SpriteStateUnderarm;
		//direction = $SpriteDirectionLeft;
		//state = $SpriteStateEmbarrassed;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();
		/*hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();*/
		torso = $SpriteTorsoTShirtF;
		//legs = GetRandomLegs();
		accessory = GetRandomAccessory();

		Position = L3A_UnderarmHairPos.getPosition();
		SceneLayer = L3A_UnderarmHairPos.getSceneLayer();
	};
	GetRandomHair(L3A_UnderarmHairPerson);
	GetRandomLegs(L3A_UnderarmHairPerson);
	%this.SetupLostPerson(L3A_UnderarmHairPerson);
	
	//	Girl Developing Breasts
	new CompositeSprite(L3A_DevelopBreastGirl)
	{
		displayName = "Girl Covering Chest";
		class = "Character";
		dialogueTree = L3A_DevelopBreastDialogueTree;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();
		/*hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();*/
		accessory = GetRandomAccessory();

		Position = L3A_DevelopBreastGirlPos.getPosition();
		SceneLayer = L3A_DevelopBreastGirlPos.getSceneLayer();
	};
	GetRandomHair(L3A_DevelopBreastGirl);
	GetRandomTorso(L3A_DevelopBreastGirl);
	GetRandomLegs(L3A_DevelopBreastGirl);
	%this.SetupLostPerson(L3A_DevelopBreastGirl);

	//  Sweaty Person
	new CompositeSprite(L3A_SweatyPerson)
	{
		displayName = "Sweaty Boy";
		class = "Character";
		dialogueTree = L3A_SweatyDialogueTree;
		
		gender = $SpriteGenderMale;
		ethnicity = GetRandomEthnicity();
		/*hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();*/
		torso = $SpriteTorsoTShirt;//GetRandomTorso();
		legs = $SpriteLegsShorts;//GetRandomLegs();
		accessory = GetRandomAccessory();

		Position = L3A_SweatyPersonPos.getPosition();
		SceneLayer = L3A_SweatyPersonPos.getSceneLayer();
	};
	GetRandomHair(L3A_SweatyPerson);
	%this.SetupLostPerson(L3A_SweatyPerson);

	//  Broad Shouldered Person
	new CompositeSprite(L3A_BroadShoulderPerson)
	{
		displayName = "Broad shouldered boy";
		class = "Character";
		dialogueTree = L3A_BroadShoulderDialogueTree;
		
		gender = $SpriteGenderMale;
		ethnicity = GetRandomEthnicity();
		/*hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();*/
		accessory = GetRandomAccessory();

		Position = L3A_BroadShoulderPersonPos.getPosition();
		SceneLayer = L3A_BroadShoulderPersonPos.getSceneLayer();
	};
	GetRandomHair(L3A_BroadShoulderPerson);
	GetRandomTorso(L3A_BroadShoulderPerson);
	GetRandomLegs(L3A_BroadShoulderPerson);
	%this.SetupLostPerson(L3A_BroadShoulderPerson);

	//  Pubic Hair Person
	new CompositeSprite(L3A_PubicHairPerson)
	{
		displayName = "Girl looking down";
		class = "Character";
		dialogueTree = L3A_PubicHairDialogueTree;
		
		gender = $SpriteGenderFemale;
		ethnicity = GetRandomEthnicity();
		/*hairColour = GetRandomHairColour();
		hairStyle = GetRandomHairStyle();
		torso = GetRandomTorso();
		legs = GetRandomLegs();*/
		accessory = GetRandomAccessory();

		Position = L3A_PubicHairPos.getPosition();
		SceneLayer = L3A_PubicHairPos.getSceneLayer();
	};
	GetRandomHair(L3A_PubicHairPerson);
	GetRandomTorso(L3A_PubicHairPerson);
	GetRandomLegs(L3A_PubicHairPerson);
	%this.SetupLostPerson(L3A_PubicHairPerson);
}

//	Obstacles
function Lesson3A_Forest::SetupObstacles(%this)
{
	//	Stone Sign
	new CompositeSprite(L3A_StoneSign)
	{
		displayName = "Stone Sign";
		class = "Readable";
		
		collisionSize = "1.25, 1";
		imageName = "Assets:StoneSign";
		imagePos = "0, 0.2";
		imageSize = "2, 2";
		
		dialogueTree = L3A_StoneSignDialogueTree;

		Position = StoneSignPos.getPosition();
		SceneLayer = StoneSignPos.getSceneLayer();
	};
	L3A_StoneSign.Setup(%this);
	
	//	Exit Obstacle
	new CompositeSprite(L3A_ExitObstacle)
	{
		displayName = "Hedge";
		class = "Static";
		
		collisionSize = "6, 2";
		imageName = "Assets:Hedge";
		imagePos = "0, 0";
		imageSize = "6, 2";

		Position = EndObstaclePos.getPosition();
		SceneLayer = EndObstaclePos.getSceneLayer();
	};
	L3A_ExitObstacle.Setup(%this);
}

// Setup Lost People
function Lesson3A_Forest::SetupLostPerson(%this, %person)
{
   if (Lesson3A.totalLost $= "")
      Lesson3A.totalLost = 0;
   
   %person.helped = false;
   %person.Setup(%this);
	%this.helpedPeople[Lesson3A.totalLost] = %person;
	//echo(Lesson3A.totalLost @ ":" SPC %this.helpedPeople[Lesson3A.totalLost]);
	Lesson3A.totalLost++;
}

function Lesson3A_Forest::CountHelped(%this)
{
   %count = 0;
   
   for (%i = 0; %i < Lesson3A.totalLost; %i++)
      if (%this.helpedPeople[%i].helped)
         %count++;
   
   return %count;
}

//	Triggers
function L3A_Exit::onEnter(%this, %object)
{
	if (%object.getName() $= Player)
	{
		UpdateHelpBar(Lesson3A, "Leaving Mix 'n Match");

		// New scenes cannot be called during onCollision else the game will crash
		/*%this.schedule(100, */EndActivity(Lesson3A);//);
	}
}
function L3A_ExitWarn::onEnter(%this, %object)
{
	UpdateHelpBar(Lesson3A, "You are about to leave Mix 'n Match");
}
function L3A_ExitWarn::onLeave(%this, %object)
{
	UpdateHelpBar(Lesson3A);
}