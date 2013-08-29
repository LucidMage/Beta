function testart::onAdd(%this)
{
}

//	Scene Setup
function testart::setup(%this)
{
   %this.setName("testart");

   //	Add Tiled Map
   %mapSprite = new TmxMapSprite()
   {
      Map = "Year8:testart_map";
   };
	
	%this.add(%mapSprite);
   
   %this.setupCharacters();
   %this.setupItems();
   
	%pushable = new Sprite()
	{
		class = Pushable;
		Image = "Assets:Tiles";
		Position = "-1 -2";
		SceneLayer = %layer;
	};
	%this.add(%pushable);
   
   %this.setupDialogue();
   %this.setupTriggers();
   /*
   //	Create GUI stuff here for now
   %label = createCustomLabel("ADD CHARACTER DIALOGUE");
   Dialogue.addGuiControl(%label);
   
	GlobalActionMap.bind( keyboard, "enter",  createDialogueBox);   // Press 'enter' to open dialogBox*/
}
/*
function createDialogueBox()
{
    // Is the console awake?
    if ( Dialogue.isAwake() )
    {
        Canvas.popDialog(Dialogue);    
        //Canvas.popDialog($label);   
        return;
    }
    
    Canvas.pushDialog(Dialogue);
    //Canvas.pushDialog($label);
}*/

//	Characters
function testart::setupCharacters(%this)
{
   //  Create Player
   SetupPlayer(%this, PlayerPos.getPosition(), PlayerPos.getSceneLayer());
   
   //	NPCs
   //  Person1
   %person1 = new CompositeSprite(Person1)
   {
      displayName = "Bob";
      class = "Character";
      gender = $SpriteGenderMale;
      ethnicity = $SpriteEthnicityMaori;
	  torso = "";
	  legs = $SpriteLegsDress;
	  
      Position = Person1Pos.getPosition();
      SceneLayer = Person1Pos.getSceneLayer();
   };
   %person1.Setup();
   
   //  Person2
   %person2 = new CompositeSprite(Person2)
   {
      displayName = "Mary";
      class = "Character";
      gender = $SpriteGenderFemale;
      ethnicity = $SpriteEthnicityPakeha;
	  torso = "";
	  legs = $SpriteLegsDress;
	  
      Position = Person2Pos.getPosition();
      SceneLayer = Person2Pos.getSceneLayer();
   };
   %person2.Setup();
   
   //  Person3
   %person3 = new CompositeSprite(Person3)
   {
      displayName = "Sue";
      class = "Character";
      gender = $SpriteGenderFemale;
      ethnicity = $SpriteEthnicityPI;
	  torso = "";
	  legs = $SpriteLegsDress;
	  
      Position = Person3Pos.getPosition();
      SceneLayer = Person3Pos.getSceneLayer();
   };
   %person3.Setup();
   
   //  Person4
   %person4 = new CompositeSprite(Person4)
   {
      displayName = "Lee";
      class = "Character";
      gender = $SpriteGenderMale;
      ethnicity = $SpriteEthnicityAsian;
	  torso = $SpriteTorsoPlaid;
	  legs = $SpriteLegsDress;
	  
      Position = Person4Pos.getPosition();
      SceneLayer = Person4Pos.getSceneLayer();
   };
   %person4.Setup();
   
   //	Guides
   //  Dragon
   %dragon = new Sprite(Dragon)
   {
      displayName = "Dragon";
      class = "Guide";
      imageName = "Assets:Dragon";  // temporary
      Position = DragonPos.getPosition();
      SceneLayer = DragonPos.getSceneLayer();
   };
   
   //  Fairy
   %fairy = new Sprite(Fairy)
   {
      displayName = "Fairy";
      class = "Guide";
      imageName = "Assets:Fairy";  // temporary
      Position = FairyPos.getPosition();
      SceneLayer = FairyPos.getSceneLayer();
   };
   
   //  Kea
   %kea = new Sprite(Kea)
   {
      displayName = "Kea";
      class = "Guide";
      imageName = "Assets:Kea";  // temporary
      Position = KeaPos.getPosition();
      SceneLayer = KeaPos.getSceneLayer();
   };
   
   //  Owl
   %owl = new Sprite(Owl)
   {
      displayName = "Owl";
      class = "Guide";
      imageName = "Assets:Owl";  // temporary
      Position = OwlPos.getPosition();
      SceneLayer = OwlPos.getSceneLayer();
   };

   // Add to Scene
   %this.add(%person1);
   %this.add(%person2);
   %this.add(%person3);
   %this.add(%person4);
   
   %this.add(%dragon);
   %this.add(%fairy);
   %this.add(%kea);
   %this.add(%owl);
}

//	Items
function testart::setupItems(%this)
{
   //  Red Gem
   %gemRed = new Sprite(RedGem)
   {
      displayName = "Red Gem";
      class = "Item";
      Position = RedGemPos.getPosition();
      SceneLayer = RedGemPos.getSceneLayer();
   };
   %gemRed.setImage("Assets:Gems", 32);
   
   // Blue Gem
   %gemBlue = new Sprite(BlueGem)
   {
      displayName = "Blue Gem";
      class = "Item";
      Position = BlueGemPos.getPosition();
      SceneLayer = BlueGemPos.getSceneLayer();
   };
   %gemBlue.setImage("Assets:Gems", 37);
   
   // Green Gem
   %gemGreen = new Sprite(GreenGem)
   {
      displayName = "Green Gem";
      class = "Item";
      Position = GreenGemPos.getPosition();
      SceneLayer = GreenGemPos.getSceneLayer();
   };
   %gemGreen.setImage("Assets:Gems", 35);

   //  Add to Scene
   %this.add(%gemRed);
   %this.add(%gemBlue);
   %this.add(%gemGreen);
}

//	Dialogue
function testart::SetupDialogue(%this)
{
	echo("Setup Dialogue");
	
	//	Dragon Dialogue
	Dragon.dialogueTree.rootDialogue[0].dialogue = "Hi there, I'm" SPC Dragon.displayName @ ". Who are you?";
	
	//	Root Dialogue 0 Response 1
	%response1 = new ScriptObject()	{ 	class = Dialogue;	};
	%response1.setup("Nice to meet you" SPC Player.displayName @ ".");
	%response1.canEnd = false;
	
	//	Response for Above
	%response1A = new ScriptObject()	{ 	class = Dialogue;	};
	%response1A.setup("My job is to help you on your journey along the road.");
	
	//	Assemble dialogue tree from end to beginning
	%response1.addResponse("What are you doing here?", %response1A);
	
	Dragon.dialogueTree.rootDialogue[0].addResponse("My name is" SPC Player.displayName @ ".", %response1);
	
	//	Root Dialogue 0 Response 2
	%response2 = new ScriptObject()	{ 	class = Dialogue;	};
	%response2.setup("Aww... I'm sad now.");
	
	Dragon.dialogueTree.rootDialogue[0].addResponse("No", %response2);
	
	//	Bobs Dialogue
	Person1.dialogueTree.rootDialogue[0].dialogue = "Hello, I seem to have lost three gems. Can you help me find them?";
	Person1.dialogueTree.rootDialogue[0].canEnd = false;
	
	//	Root Dialogue 0 Response 1
	%response1 = new ScriptObject()	{ 	class = Dialogue;	};
	%response1.setup("Thank you. I think I lost them at the dig site.");
	%response2 = new ScriptObject()	{ 	class = Dialogue;	};
	%response2.setup("Damn.");
	
	Person1.dialogueTree.rootDialogue[0].addResponse("Yes", %response1);
	Person1.dialogueTree.rootDialogue[0].addResponse("No", %response2);
}

//	Triggers
function testart::SetupTriggers(%this)
{
	echo("Setup Triggers");
	
	SetupTrigger(ToTestTown);
	SetupTrigger(ToTestTownWarn);

	//	Should already be created via Tiled
	//ToTestTown.class = Transition;
	ToTestTown.toScene = "testart";
}

//	Triggers
function ToTestTown::onEnter(%this, %object)
{
	HelpText.Text = "Transferring to Test Town";
}

function ToTestTownWarn::onEnter(%this, %object)
{
	HelpText.Text = "About to enter Test Town";
}
function ToTestTownWarn::onStay(%this, %object)
{
	echo(%this.getPosition());
	echo(%object.getPosition());
}