what ive learn.

in backend of this the aps .net
the program cs is the main its the one that sets the backend like the routes beging registered there and the settings liek the ports etc. and setting of cors

now the controllers are the one that interact wiht the models (the tables of the database) to do the quesirs like crud, then create the api endpoints like name basing so if usercontrolelr is the name, it jsut automatiicaly make the ewndppitns (api/user) its automaticalyl like magic yeah

nowthe models are the table creation it has the fileds of that models table 

now in appdbcontext,. the context is the database itself and there we register those tagble swe created in the models to make it working,, so the flow will be we create the db context then now creat the models to be its tables then register in dbcotnext,, now the controlelr is the busienss logics has the routes set up, queisries and uses just the models table  and also the db cointext

app settings holds the configuration settings on how we can connect to the dataabse liek the port, localhost etc. passwrod user etc.

in program cs we buld things,, we get the db context ,etc.. we passed the object needed of the db context like the confi connection of app settings to make the db context work connected to database and more 