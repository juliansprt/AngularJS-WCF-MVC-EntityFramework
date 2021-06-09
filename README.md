# Compilacion

* Crear una base datos: FinandinaTestDb
* Ejecutar el script: ScriptBaseDatos.sql sobre dicha base de datos
* Cambiar el conectionstring si es necesario
```
  <connectionStrings>
    <add name="DBContext" connectionString="data source=localhost;initial catalog=FinandinaTestDb;Integrated Security=true;MultipleActiveResultSets=True" providerName="System.Data.SqlClient"/>
  </connectionStrings>
```

* El proyecto utiliza EntityFramework CodeFirst por lo tanto se puede ejecutar el comando
```
  update-database -Verbose
```

* Compilar y ejecutar el Proyecto WCF
* Compilar y ejecutar el Proyecto UI
