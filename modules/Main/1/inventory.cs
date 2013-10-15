function ToggleInventory()
{
	echo("Toggle Inventory");
	echo(InventoryContainer.Visible);
	echo(InventoryContainer.getPosition());
	
	if (InventoryContainer.Visible)
	{
		echo("Close Inventory");
		InventoryContainer.setVisible(false);
		InventoryButton.Text = "Open Inventory";
	}
	else
	{
		echo("Open Inventory");
		InventoryContainer.setVisible(true);
		InventoryButton.Text = "Close Inventory";
	}
}

function Inventory::Setup(%this)
{
	%this.count = 0;
	%this.selected = -1;
	%this.DisplaySelected();
}

//	Adding items to inventory
function Inventory::AddItem(%this, %item)
{
   %isItem = false;
   
	//	If this item doesn't do anything special
	if (%item.onPickUp())
	{
		if (%item.class $= Item)
		{
		   %isItem = true;
         %this.item[%this.count] = %item;
         %this.selected = %this.count;
         %this.count++;
		}
		else
		   error(%item SPC "of class" SPC %item.class SPC "is not an item.");
		
		%this.DisplaySelected();
	}
	
	return %isItem;
}

// Remove item from inventory
function Inventory::RemoveItem(%this, %slot)
{
	%item = %this.item[%slot];
	%this.item[%slot] = 0;
	%this.Organize();
	
	return %item;
}
function Inventory::RemoveSelectedItem(%this)	{	return %this.RemoveItem(%this.selected);	}

//	Using items
function Inventory::UseItem(%this, %slot)
{
	%item = %this.item[%slot];
	
	//%this.Organize();
	return %item;
}
function Inventory::UseSelectedItem(%this)	{	return %this.UseItem(%this.selected);	}

//	Return slot number
function Inventory::FindItem(%this, %item)
{
	for (%i = 0; %i < %this.count; %i++)
		if (%this.item[%i] $= %item)
			return %i;
	
	return -1;
}

// Move items into empty array slots
function Inventory::Organize(%this)
{
   //%this.ConsoleOutput();
   
	for (%i = 0; %i < %this.count; %i++)
	{
		if (%this.item[%i].class !$= Item)
		{
			//	Shift all items by one slot
			for (%j = %i + 1; %j < %this.count; %j++)
				%this.item[%j - 1] = %this.item[%j];

			%this.count--;
			%this.SelectPrevious();
		}
	}
	
	if (%this.count <= 0)
		%this.selected = -1;
   
   //%this.ConsoleOutput();
		
	%this.DisplaySelected();
	echo("End of Organizing:" SPC %this.count);
}

//	Show the currently selected item on the GUI
function Inventory::DisplaySelected(%this)
{
	if (%this.selected <= -1)
	{
		%image = "Assets:EmptyInventory";
		%text = "No items in inventory";
	}
	else
	{
		%image = %this.item[%this.selected].getSpriteAnimation();
		%text = %this.item[%this.selected].displayName;
	}
	
	InventorySelectedItem.setAnimation(%image);
	InventorySelectedText.setText(%text);
}

//	Go to the next item
function Inventory::SelectNext(%this)
{
	if (%this.count > 0)
	{
	   %this.selected++;
	   
	   if (%this.selected >= %this.count)
	      %this.selected = 0;
	}
	else
	   %this.selected = -1;
   
	%this.DisplaySelected();
}

//	Go to the previous item
function Inventory::SelectPrevious(%this)
{
	if (%this.count > 0)
	{
	   %this.selected--;
	   
	   if (%this.selected < 0)
	      %this.selected = %this.count - 1;
	}
	else
	   %this.selected = -1;
   
	%this.DisplaySelected();
}

// For debugging
function Inventory::ConsoleOutput(%this)
{
   ehco("Current inventory:");
   
   for (%i = 0; %i < %this.count; %i++)
      warn(%i SPC ":" SPC %this.item[%i] SPC %this.item[%i].getName());
   
   echo("Count" SPC %this.count);
   echo("Selected" SPC %this.selected);
}