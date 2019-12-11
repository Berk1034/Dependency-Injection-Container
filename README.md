# Task
## It is necessary to implement a simple Dependency Injection Container.

*Dependency Injection container is a generalized and configurable object factory. Data types whose implementation objects a DI container can create will be called **dependencies**.*

*The container should allow registering dependencies in the format: `Interface Type (TDependency) -> Implementation Type (TImplementation)`, where `TDependency` is any reference data type, and `TImplementation` is not an abstract class compatible with `TDependency`, the object of which can be created.*

*The container should be separated from its configuration: first, the configuration is created and dependencies are registered in it, and then the container is created on its basis. **The validation** of the container configuration at the time the container is created must be ensured.*

````C#
// illustration of the above
// specific API for registering / receiving dependencies at the discretion of the author
var dependencies = new DependenciesConfiguration ();
dependencies.Register <IService1, Service1> ();
dependencies.Register <AbstractService2, Service2> ();

// dependency type can match implementation type
// sometimes this is called registering "as self":
dependencies.Register <Service3, Service3> ();
 
var provider = new DependencyProvider (dependencies);
var service1 = provider.Resolve <IService1> ();
...
````

*Dependency injection must be done through the constructor. Dependencies must be created **recursively**, that is, if `TImplementation` has its own dependencies, and each of its dependencies has its own (etc.), then the container must create all of them.*

*It is necessary to implement two options for the dependency **lifetime** (set when registering the dependency):*
+ ***instance per dependency** - each new dependency request from the container creates a new object;*
+ ***singleton** - one instance of the object is returned for all dependency requests (parallel queries in **a multi-threaded environment** should be considered).*

*A dependency can have **a template type**, in particular, a type that affects specific types of its dependencies.*

*However, in addition to this, registration of such dependencies with **open generics** should be available:*

````C#
dependencies.Register(typeof(IService<>), typeof(ServiceImpl<>));
````

*It is enough to implement **first-order parameterized dependencies**, that is, when open generic is directly a dependency type, and not a parameter of another template.*
