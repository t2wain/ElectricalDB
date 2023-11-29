## EntityFramework Core Base Library

This is a demo of an EntityFramework Core project using code-first design. The configuration of the entity model uses the following approaches in these order of preferences:

1. Common conventions
2. Mapping attributes
3. Fluent APIs

This project define a single abstract DbContext without a specific database provider which is to be specified by its subclasses. The TestRepo class uses the DbContext base class to insert and query test data.