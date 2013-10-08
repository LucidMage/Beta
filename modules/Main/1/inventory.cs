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
	//	If this item doesn't do anything special
	if (%item.onPickUp())
	{
		echo("New Item" SPC %item.getName());

		%this.item[%this.count] = %item;
		
		%this.selected = %this.count;
		%this.count++;

		for (%i = 0; %i < %this.count; %i++)
		{
			echo("Item" SPC %i SPC ":" SPC %this.item[%i].getName());
		}

		echo("Inventory Count" SPC %this.count);
		
		%this.DisplaySelected();
	}
}

//	Using items
function Inventory::UseItem(%this, %slot)
{
	echo("Slot:" SPC %slot);
	echo("Using Item" SPC %this.item[%slot].getName());
	%item = %this.item[%slot];
	%this.item[%slot] = 0;
	
	%this.Organize();
	warn("Returning Item" SPC %item.getName());
	return %item;
}
function Inventory::UseSelectedItem(%this)	{	return %this.UseItem(%this.selected);	}

//	Return slot number
function Inventory::FindItem(%this, %item)
{
	echo("Finding Item:" SPC %item);
	
	for (%i = 0; %i < %this.count; %i++)
	{
		echo(%i SPC %this.item[%i].getName());
		if (%this.item[%i] $= %item)
		{
			return %i;
		}
	}
	
	return -1;
}

// Move items into empty array slots
function Inventory::Organize(%this)
{
	echo("Organizing:" SPC %this.count);
	for (%i = 0; %i < %this.count; %i++)
	{
		echo(%i SPC %this.item[%i].getName());
		if (%this.item[%i] $= 0)
		{
			//	Shift all items by one slot
			for (%j = %i + 1; %j < %this.count; %j++)
			{
			   echo((%j - 1) SPC %this.item[%j - 1].getName());
			   echo(%j SPC %this.item[%j].getName());
				%this.item[%j - 1] = %this.item[%j];
			   echo((%j - 1) SPC %this.item[%j - 1].getName());
			   echo(%j SPC %this.item[%j].getName());
			}

			%this.count--;
			%this.selected--;
		}
	}
	
	if (%this.count <= 0)
		%this.selected = -1;
	// temp
	else
	   %this.selected = 0;
   // temp
		
   echo("Current inventory:");
	for (%i = 0; %i < %this.count; %i++)
	{
		echo(%i SPC %this.item[%i].getName());
	}
		
	%this.DisplaySelected();
	echo("End of Organizing:" SPC %this.count);
}

//	Show the currently selected item on the GUI
function Inventory::DisplaySelected(%this)
{
	echo("Displaying Selected Item");
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
	
	echo("Setting Inventory Selected Image");
	warn(%image);
	InventorySelectedItem.setAnimation(%image);
	
	echo("Setting Inventory Selected Text");
	warn(%text);
	InventorySelectedText.setText(%text);
}