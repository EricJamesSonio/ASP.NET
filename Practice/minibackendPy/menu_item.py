from starbucksitem import *

class Menu_item:
    def __init__(self, item : Starbucksitem, quantity):
        self.item = item
        self.quantity = quantity
        
    def set_quantity(self, new_qtty):
        self.quantity = new_qtty
        
    def get_details(self):
        return f"Name : {self.name}, Quantity: {self.quantity}"