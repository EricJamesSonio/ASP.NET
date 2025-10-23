class Starbucksitem:
    def __init__(self, name, barcode, price, description):
        self.name = name
        self.barcode = barcode
        self.price = price
        self.description = description
        
    def get_details(self):
        return f"Name : {self.name}, Barcode : {self.barcode}, Price : {self.price}, Decription : {self.description}"
    
class Food(Starbucksitem):
    def __init__(self, name, barcode, price, description):
        super().__init__(name, barcode, price, description)
        
class Beverage(Starbucksitem):
    def __init__(self, name, barcode, price, description):
        super().__init__(name, barcode, price, description)
        
        