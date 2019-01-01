using System;
using Autofac;
using Topshelf;
using Topshelf.Autofac;

namespace SampleProgram
{
    class Program
    {
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

        public class SampleService
        {
            private readonly ISampleDependency _sample;

            public SampleService(ISampleDependency sample)
            {
                _sample = sample;
            }

            public bool Start()
            {
                Console.WriteLine("Sample Service Started.");
                Console.WriteLine("Sample Dependency: {0}", _sample);
                return _sample != null;
            }

            public bool Stop()
            {
                return _sample != null;
            }
        }

        public interface ISampleDependency
        {
        }

        public class SampleDependency : ISampleDependency
        {
        }
    }
}
