﻿Feature: Refunded or replaced items should be returned to stock

Scenario 1: Refunded items should be returned to stock
	Given a customer buys a black jumper
	And I have 3 black jumpers left in stock 
	When he returns the jumper for a refund 
	Then I should have 4 black jumpers in stock 
	
Scenario 2: Replaced items should be returned to stock
	Given that a customer buys a blue garment 
	And I have 2 blue garments in stock 
	And I have 3 black garments in stock
	When he returns the garment for a replacement in black, 
	Then I should have 3 blue garments in stock 
	And I should have 2 black garments in stock