Topshelf.Autofac
================

Topshelf.Autofac provides extensions to construct your service class from your Autofac IoC container.

Usage example:

    static void Main(string[] args)
    {
        // Create your container
        var builder = new ContainerBuilder();
        builder.RegisterType<SampleDependency>().As<ISampleDependency>();
        builder.RegisterType<SampleService>();
        var container = builder.Build();

        HostFactory.Run(c =>
        {
            // Pass it to Topshelf
            c.UseAutofacContainer(container);

            c.Service<SampleService>(s =>
            {
                // Let Topshelf use it
                s.ConstructUsingAutofacContainer();
                s.WhenStarted((service, control) => service.Start());
                s.WhenStopped((service, control) => service.Stop());
            });
        });
    }
