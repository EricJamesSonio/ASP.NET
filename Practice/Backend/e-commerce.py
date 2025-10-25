from typing import List

# User

class User:
    def __init__(self, name, id):
        self.name = name
        self.id = id
        
    def get_details(self):
        return f"Name : {self.name}, Id : {self.id}"
    
class Customer(User):
    def __init__(self, name, id):
        super(name, id)
        
class Admin(User):
    def __init__(self,name,id):
        super(name, id)
        
# Account

class Auth:
    def __init__(self, id,user : User, email, password):
        self.id = id
        self.user = user
        self.email = email
        self.password = password
        
    def get_details(self):
        return f"Email : {self.email}, Password : {self.password}"

# Items
class Item:
    def __init__(self, name, id, price, description):
        self.name = name
        self.id = id
        self.price = price
        self.descripttion = description
        
    def get_details(self):
        return f"Name : {self.name}, Id : {self.id}, Price : {self.price}"
    
class Gown(Item):
    def __init__(self, name, id, price, description):
        super(name,id,price,description)
        
class BlueGown(Gown):
    def __init__(self,name, id, price, description):
        super(name, id, price,description)
        
class RedGown(Gown):
    def __init__(self, name, id , price, description):
        super(name, id, price, description)
        
class BlackGown(Gown):
    def __init__(self, name, id , price, description):
        super(name, id, price, description)
        
class BrownGown(Gown):
    def __init__(self, name, id , price, description):
        super(name, id, price, description)
        
# Database

class Table:
    def __init__(self, name,id):
        self.name = name
        self.id = id
        self.items = []
        
    def add_item(self, item):
        existing = self.find_item(item.id)
        
        if existing:
            return None
        else:
            self.items.append(item)
        
    def find_item(self, id):
        for item in self.items:
            if item.id == id:
                return item
        return None
    
    def remove_item(self, id):
        existing = self.find_item(id)
        
        if existing:
            self.items.remove(existing)
        else:
            return None
        
    def display_items(self):
        for item in self.items:
            print(item.get_details())
            
class UserTable(Table):
    def __init__(self, name, id):
        self.items : List[User] = []
        super(name, id)
        
class ItemTable(Table):
    def __init__(self, name, id):
        self.items : List[Item] = []
        super(name, id)
        
    
class AuthTable(Table):
    def __init__(self, name, id):
        self.items : List[Auth] = []
        super(name, id)
        
# Models

class Model:
    def __init__(self, table : Table):
        self.table = table
        
    def get_all(self):
        items = []
        for item in self.table.items:
            items.append(item)
        return items
    
    def get_item(self, id):
        for item in self.table.items:
            if item.id == id:
                return item
        return None
    
    def add_item(self, item):
        self.table.add_item(item)
        
    def remove_item(self, id):
        self.table.remove_item(id)
        
    def display_items(self):
        self.table.display_items()
        
class UserModel(Model):
    def __init__(self, table : UserTable):
        super().__init__(table)
        
class AuthModel(Model):
    def __init__(self, table : AuthTable):
        super().__init__(table)
class ItemModel(Model):
    def __init__(self, table : ItemTable):
        super().__init__(table)
        
# Controllers

class Controller:
    def __init__(self, model : Model):
        self.model = model
        
    def add_item(self, item):
        if item != None:
            self.model.add_item(item)
        else:
            return None
        
    def remove_item(self, id):
        self.model.remove_item(id)
        
    def get_all(self):
        self.model.get_all()
        
    def get_item(self, id):
        self.model.get_item()
        
    def display_items(self):
        if self.model.get_all != None:
            self.model.display_items()
        else:
            return None
        
class UserController(Controller):
    def __init__(self, model : UserModel):
        super().__init__(model)
        
class AuthController(Controller):
    def __init__(self, model : AuthModel):
        super().__init__(model)
        
class ItemController(Controller):
    def __init__(self, model):
        super().__init__(model)         
        
        