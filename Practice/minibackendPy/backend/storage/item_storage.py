from typing import List
from starbucksitem import *
from menu_item import Menu_item

class Item_Storage:
    def __init__(self):
        self.items : List[Menu_item] = []
        
    def add_item(self, item : Starbucksitem, quantity):
        existing = self.find_item(item.id)
        
        if existing:
            new_qtty = existing.quantity + quantity
            existing.set_quantity(new_qtty)
        else:
            new_item = Menu_item(item, quantity)
            self.items.append(new_item)
            
    def find_item(self, id):
        for item in self.items:
            if item.item.id == id:
                return item
        return None
        
    def remove_item(self, id):
        existing = self.find_item(id)
        
        if existing:
            self.items.remove(existing)
        else:
            return "Doesn't exist"
        
    def get_items(self):
        return self.items
        
class Storage_viewer:
    def display_item(self, storage : Item_Storage):
        for item in storage.items:
            print(item.get_details())
            