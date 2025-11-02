class Item:
    def __init__(self, name, id, price):
        self.name = name
        self.id = id
        self.price = price
    
    def get_details(self):
        return f"Name : {self.name}, Id : {self.id}, Price : {self.price}"
        
class MenuItem:
    def __init__(self, item : Item, quantity):
        self.item = item
        self.quantity = quantity

    def get_details(self):
        return f"Item : {self.item.get_details()}, Quantity : {self.quantity}"
    
    def get_id(self):
        return self.item.id
    
class Inventory:
    def __init__(self):
        self.storage = []
        
    def add_item(self, menuitem : MenuItem):
        existing = self.find_item(menuitem.get_id())
        
        if existing:
            existing.quantity += menuitem.quantity
        else:
            self.storage.append(menuitem)
    
    def find_item(self, id):
        for item in self.storage:
            if item.get_id() == id:
                return item
        return None
    
    