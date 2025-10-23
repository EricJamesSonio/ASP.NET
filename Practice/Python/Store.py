from typing import List

class BaseItem:
    def __init__(self, name, id, price):
        self.name = name
        self.id = id
        self.price = price
        
    def get_details(self):
        return f"Name : {self.name}, Id : {self.id}, Price : {self.price}"
    
class Food (BaseItem ):
    def __init__(self, name, id, price):
        super(name, id, price)
        
class Item (BaseItem):
    def __init__(self, name , id, price):
        super(name, id, price)
        
# StoreItem

class StoreItem:
    def __init__(self, item : BaseItem, quantity ) :
        self.item = item
        self.quantity = quantity
        self.id = item.id
        
    def getId(self):
        return self.id
    
    def get_details(self):
        return f"Name : {self.item.name}, Id : {self.getId()}, Quantity : {self.quantity}, Price : {self.item.price}"
        

# Inventory

class Inventory:
    def __init__(self):
        self.__items : List[StoreItem] = []
        
    def find_item(self, id):
        for item in self.items:
            if item.id == id:
                return item
        return None
    
    def add_item(self, item : BaseItem, quantity : int):
        existing = self.find_item(item, quantity)
        
        if existing:
            existing.quantity += quantity
        else :
            new_item = StoreItem(item, quantity)
            self.items.append(new_item)
            
    def remove_item(self, id) :
        existing = self.find_item(id)
        
    def getItems(self):
        return self.__items
        
class InventoryViewer:
    def __init__(self, inventory : Inventory):
        self.inventory = inventory
        
    def display_items(self):
        for item in self.inventory.getItems():
            item.item.get_details()
            
# Store

class Store:
    def __init__(self, inventory : Inventory, inventoryViewer : InventoryViewer):
        self.inventory = inventory
        self.inventoryViewer = inventoryViewer(self.inventory)
        
    def add_item(self, item, quantity):
        self.inventory.add_item(item, quantity)
        
    def remove_item(self, id):
        self.inventory.remove_item(id)
        
    def display_items(self):
        self.inventoryViewer.display_items()


item1 = Food("Exmpale", 2, 120)        
inv = Inventory()

action = inv.add_item(item1)
if action:
    print("succesfuly added!")
inv_viewer = InventoryViewer(inv)
store = Store(inv,inv_viewer)
store.display_items()

        
        
        