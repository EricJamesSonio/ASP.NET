from Practice.minibackendPy.backend.model import Item_Model
from starbucksitem import Starbucksitem

class Item_Controller:
    def __init__(self, model : Item_Model):
        self.model = model
        
    def add_item(self, item : Starbucksitem, quantity):
        self.model.add_item(item, quantity)
        
    def remove_item(self, id):
        self.model.remove_item(id)
        
    def get_items(self):
        self.model.get_items()
        

