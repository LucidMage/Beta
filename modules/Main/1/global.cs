//==	Activity    ==//
$ModuleTypeActivity = "YearGroup";

//==	Data    ==//
$DataSavePath = "Data/";
$DataSaveExtension = ".taml";
$DataSaveFormat = xml;

//==	Dialogue    ==//
$DialogueResponseMax = 9;

//==	GUI    ==//
$GUIHelpUpdateDelay = 5000;
$GUIResponseHeight = 40;

//==	Sprites    ==//
//	Directions
$SpriteDirectionUp = "North";
$SpriteDirectionDown = "South";
$SpriteDirectionLeft = "West";
$SpriteDirectionRight = "East";

//	Gender
$SpriteGenderFemale = "Female";
$SpriteGenderMale = "Male";
$SpriteGenderArray[0] = $SpriteGenderFemale;
$SpriteGenderArray[1] = $SpriteGenderMale;
$SpriteGenderCount = 2;

//	Ethnicity
$SpriteEthnicityMaori = "Maori";
$SpriteEthnicityPI = "PI";	$SpriteEthnicityPIFull = "Pacific Islander";
$SpriteEthnicityPakeha = "Pakeha";
$SpriteEthnicityAsian = "Asian";
$SpriteEthnicityArray[0] = $SpriteEthnicityMaori;
$SpriteEthnicityArray[1] = $SpriteEthnicityPIFull;
$SpriteEthnicityArray[2] = $SpriteEthnicityPakeha;
$SpriteEthnicityArray[3] = $SpriteEthnicityAsian;
$SpriteEthnicityCount = 4;

//	Hair
//$SpriteHairNone = "Bald";

//	Hair Colour
$SpriteHairColourBlonde = "Blonde";
$SpriteHairColourBrown = "Brown";
$SpriteHairColourPurple = "Purple";
$SpriteHairColourGrey = "Grey";	$SpriteHairColourGreyFull = "Grey Androgenous";
$SpriteHairColourArray[0] = $SpriteHairColourBlonde;
$SpriteHairColourArray[1] = $SpriteHairColourBrown;
$SpriteHairColourArray[2] = $SpriteHairColourPurple;
$SpriteHairColourArray[3] = $SpriteHairColourGrey;
$SpriteHairColourCount = 4;

//	Hair Style
$SpriteHairStyleWavy = "Wavy";
$SpriteHairStyleLongFem = "Femme";		$SpriteHairStyleLongFemFull = "Long Femme";
$SpriteHairStyleLongAndro = "Andro";	$SpriteHairStyleLongAndroFull = "Long Androgenous";
$SpriteHairStylePunk = "Punk";
$SpriteHairStyleArray[0] = $SpriteHairStyleWavy;
$SpriteHairStyleArray[1] = $SpriteHairStyleLongFem;
$SpriteHairStyleArray[2] = $SpriteHairStyleLongAndro;
$SpriteHairStyleArray[3] = $SpriteHairStylePunk;
$SpriteHairStyleCount = 4;

//	Torso
//$SpriteTorsoNone = "";	$SpriteTorsoNoneFull = "Dress";
$SpriteTorsoPlaid = "Plaid";
$SpriteTorsoHoodie = "Hoodie";
$SpriteTorsoTShirt = "TShirt";	$SpriteTorsoTShirtFull = "T-Shirt";
$SpriteTorsoTShirtF = "TShirtF";
//$SpriteTorsoArray[0] = $SpriteTorsoNone;
$SpriteTorsoArray[0] = $SpriteTorsoPlaid;
$SpriteTorsoArray[1] = $SpriteTorsoHoodie;
$SpriteTorsoArray[2] = $SpriteTorsoTShirt;
$SpriteTorsoArray[3] = $SpriteTorsoTShirtF;
$SpriteTorsoCount = 4;

//	Legs
$SpriteLegsDress = "Dress";
$SpriteLegsShorts = "Shorts";
$SpriteLegsJeans = "Jeans";
$SpriteLegsPants = "Pants";
$SpriteLegsSkirt = "Skirt";
$SpriteLegsArray[0] = $SpriteLegsDress;
$SpriteLegsArray[1] = $SpriteLegsShorts;
$SpriteLegsArray[2] = $SpriteLegsJeans;
$SpriteLegsArray[3] = $SpriteLegsPants;
$SpriteLegsArray[4] = $SpriteLegsSkirt;
$SpriteLegsCount = 5;

//	Accessories
$SpriteAccessoryNone = "";	$SpriteAccessoryNoneFull = "None";
$SpriteAccessoryScarf = "Scarf";
$SpriteAccessoryGlasses = "Glasses";
$SpriteAccessoryCap = "Cap";
$SpriteAccessoryArray[0] = $SpriteAccessoryNone;
$SpriteAccessoryArray[1] = $SpriteAccessoryScarf;
$SpriteAccessoryArray[2] = $SpriteAccessoryGlasses;
$SpriteAccessoryArray[3] = $SpriteAccessoryCap;
$SpriteAccessoryCount = 4;

//	States
$SpriteStateIdle = "Idle";
$SpriteStateWalk = "Walk";
$SpriteStateAngry = "Angry";
$SpriteStateCheerful = "Cheer";
$SpriteStateEmbarassed = "Embarassed";
$SpriteStateReading = "Read";
$SpriteStateShocked = "Shock";