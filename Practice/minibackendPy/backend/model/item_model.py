from typing import List
from starbucksitem import *
from menu_item import Menu_item
from Practice.minibackendPy.backend.storage.item_storage import Item_Storage

class Item_Model:
    def __init__(self, storage : Item_Storage):
        self.storage = storage
        
    def add_item(self, item : Starbucksitem, quantity):
        self.storage.add_item(item, quantity)
        
    def remove_item(self, item : Menu_item):
        self.storage.remove_item(item.item.id)
        
    def get_items(self):
        self.storage.get_items()