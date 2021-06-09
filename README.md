# Compilacion

* Cambiar el conectionstring si es necesario para la base de datos
```
  <connectionStrings>
    <add name="DBContext" connectionString="data source=localhost;initial catalog=FinandinaTestDb;Integrated Security=true;MultipleActiveResultSets=True" providerName="System.Data.SqlClient"/>
  </connectionStrings>
```

* Sobre el proyecto DAL ejecutar:
```
  update-database -Verbose
```

* Compilar y ejecutar el Proyecto WCF
* Compilar y ejecutar el Proyecto UI