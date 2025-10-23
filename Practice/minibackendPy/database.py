from typing import List

class Field:
    def __init__(self, name, id,value):
        self.name = name
        self.value = value
        self.id = id
        
    def set_value(self, new_value):
        self.value = new_value
        
    def get_details(self):
        return f"Name : {self.name}, Id : {self.id}, Value : {self.value}"

class Table:
    def __init__(self, name):
        self.name = name
        self.fields : List[Field] = []
        
    def add_field(self, field : Field):
        existing = self.find_field(field.id)
        
        if existing:
            return "Already Exist"
        else:
            self.fields.append(field)
    
    def remove_field(self, id):
        existing = self.find_field(id)
        
        if existing:
            self.fields.remove(existing)
        else:
            return "Doesn't exist"
        
    
    def find_field(self, id):
        for field in self.fields:
            if field.id == id:
                return field
        return None    
    
class TableViewer:
    def display_fields(self, table : Table):
        for field in self.table.fields:
            print(field.get_details())
        
class Database:
    def __init__(self, name):
        self.name = name
        self.tables : List[Table] = []
        
    def add_table(self, table : Table):
        existing = self.find_table(table.name)
        
        if existing:
            return "Already exist"
        else:
            self.tables.append(table)
    
    def remove_table(self, name):
        existing = self.tables(name)
        
        if existing:
            self.tables.remove(existing)
        else:
            return "Table Doesn't exist"
    
    def find_table(self, name):
        for table in self.tables:
            if table.name == name:
                return table
        return None
    
class DatabaseViewer:
    def display_tables(self, database : Database, table_viewer : TableViewer):
        for table in database.tables:
            print(table_viewer.display_fields(table))
    